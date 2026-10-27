---
uid: TestConnectorScriptsPython
---

# Testing a Python script before you deploy it

A Python script reads data from a device and sends it to an Edge Node, which forwards it to DataMiner. This guide explains how to test such a script before you deploy it. It covers how to:

- Check that the data your script produces is correct and will be accepted.
- Mock the device your script reads from, and the push to the Edge Node.

## Overview

The guide uses one example throughout: a connector for an encoder. It reads the encoder status over HTTP and sends the device name, its CPU usage, and a table of network interfaces. Each section builds on the previous one, so if you start from scratch, follow them in order:

1. [Learn what the Edge Node expects](#learn-what-the-edge-node-expects)
1. [Look at the example connector script](#example-connector-script)
1. [Capture real device responses as fixtures](#capture-real-device-responses-as-fixtures)
1. [Validate the payload](#validate-the-payload)
1. [Replace the Edge Node endpoint with a mock and test the push](#replace-the-edge-node-with-a-mock)

## Learn what the Edge Node expects

Your data is validated twice on its way into DataMiner: first by the Edge Node, then by the Data API.

### The Edge Node checks the request

Your script sends its data with `POST http://localhost:5016/api/data`. The Edge Node only accepts the request when:

- The body is JSON and is not empty.
- The body is at most 1 MB. A larger body is refused with `413 Payload Too Large`.
- The `runSecret` header contains the value of the `EDGE_RUN_SECRET` environment variable, which the Edge Node sets for every run.

### The Data API reads the content

The Data API then turns your JSON into parameter values.

> [!NOTE]
> The Edge Node answers your script with `202 Accepted` before the Data API has seen the data. If the Data API rejects or drops the request, the script is not aware.

The rules below are applied to the JSON payload.

#### Single values become parameters

Every top-level key becomes a parameter. Numbers become numeric values, strings become text, and a nested object is flattened into dotted names. This payload:

```json
{
  "Device Name": "Encoder 1",
  "CPU Utilization": 42.5,
  "Details": { "Rack": 4 }
}
```

sets three parameters: `Device Name` to `Encoder 1`, `CPU Utilization` to `42.5`, and `Details.Rack` to `4`.

Booleans are converted to text. `{"Online": true}` sets `Online` to the text `True`, not to a number or a state.
Convert the boolean before you send it, e.g., send `Up` instead of `True` and `Down` instead of `False`.

#### `null` values are not updated

A top-level `null` does not clear a parameter. The Data API skips it, so the parameter keeps its last value, for example:

1. The first run sends `{"Firmware": "2.1"}`.

   `Firmware` shows `2.1`.

1. The second run sends `{"Firmware": null}`.

   `Firmware` still shows `2.1`, although the script no longer knows the version.

To show that a value is unknown, send it explicitly, e.g., `N/A`.

In a table row, `null` has a different effect: the cell is sent without a value and is shown empty.

#### Arrays of objects become tables

An array of objects becomes a table, and the keys of the objects become its columns. For example, the encoder's interfaces:

```json
{
  "Interfaces": [
    { "Id": 1, "Name": "eth0", "Status": "Up" },
    { "Id": 2, "Name": "eth1" }
  ]
}
```

This fills the `Interfaces` table with two rows. The second row has no `Status`, so that cell stays empty.

Two kinds of arrays are not turned into tables:

- **An empty array is ignored.** `"Interfaces": []` sends nothing for that table, so you cannot use it to clear the table.
- **An array of plain values is not supported.** In `"Tags": ["4K", "HEVC"]`, the items are skipped because they are not objects, and the Data API records an error that your script never sees. Wrap them instead, e.g., `"Tags": [{"Id": "4K"}, {"Id": "HEVC"}]`.

#### The `Id` column identifies each row

A key named `Id` becomes the primary key of the table. It determines which row each update is written to.
Every row needs an `Id` value that is not null or empty, and that value must be unique.
Without an `Id`, rows are numbered by their position: the first object is row 1, the second is row 2, and so on. If the device lists its interfaces in a different order next time, the values move to other rows.

#### Nested arrays become linked tables

An array inside a table row becomes a separate table, linked to its parent row by a foreign key. For example, each interface lists its VLANs:

```json
{
  "Interfaces": [
    { "Id": "eth0", "Vlans": [{ "Id": 100 }, { "Id": 200 }] },
    { "Id": "eth1", "Vlans": [{ "Id": 300 }] }
  ]
}
```

This fills two tables:

- `Interfaces`, with the rows `eth0` and `eth1`.
- `Vlans`, with the rows `100`, `200`, and `300`, and an `Interfaces_Foreign Key` column containing `eth0`, `eth0`, and `eth1`.

The VLANs of all interfaces end up in one table, so their `Id` values must be unique across all interfaces, not just within one. If `eth0` and `eth1` both had VLAN `100`, only one of those rows would be kept.

### How the Edge Node starts your script

Your tests should start the script the same way the Edge Node does:

- Arguments arrive as `--name=value`.
- Secrets arrive as environment variables, never as arguments.
- A run only counts as failed when the script ends with a non-zero exit code. If your script catches an exception and only prints it, the Edge Node reports a successful run, even though no data was sent.
- The script is stopped after 300 seconds by default, so every network call needs a timeout.

## Example connector script

Consider the following encoder connector script, where the work is divided over these functions:

- `parse_input()` reads the arguments.
- `collect()` retrieves the raw status from the device.
- `transform()` converts the raw status into the payload accepted by Edge Node and Data API.
- `get_data()` calls `collect()` and then `transform()`.
- `push_data_to_edge_node()` sends the payload to the Edge Node.

```python
import argparse
import os

import requests


EDGE_DATA_URL = "http://localhost:5016/api/data"


def parse_input(arguments=None):
    parser = argparse.ArgumentParser()
    parser.add_argument("--host", required=True)
    return parser.parse_args(arguments)


def collect(host):
    """Retrieve the raw status from the device."""
    response = requests.get(f"http://{host}/api/status", timeout=10)
    response.raise_for_status()
    return response.json()


def transform(raw):
    """Convert the raw device status into the payload for the Edge Node."""
    return {
        "Device Name": raw["name"],
        "CPU Utilization": float(raw["cpu"]),
        "Interfaces": [
            {
                "Id": interface["index"],
                "Name": interface["name"],
                "Status": "Up" if interface["up"] else "Down",
            }
            for interface in raw["interfaces"]
        ],
    }


def get_data(input_data):
    return transform(collect(input_data.host))


def push_data_to_edge_node(data):
    run_secret = os.getenv("EDGE_RUN_SECRET")
    if not run_secret:
        raise ValueError(
            "Required environment variable 'EDGE_RUN_SECRET' is missing"
        )

    response = requests.post(
        EDGE_DATA_URL,
        json=data,
        headers={"runSecret": run_secret},
        timeout=30,
    )
    response.raise_for_status()
    return response


def main():
    input_data = parse_input()
    data = get_data(input_data)
    push_data_to_edge_node(data)


if __name__ == "__main__":
    main()
```

The next sections test each of these functions.

## Capture real device responses as fixtures

To test `transform()`, you need input, preferably a real response from the device. Instead of calling the encoder in every test, save its response once in a file, called a fixture, and use that file in your tests.

1. Call the device and capture its response as `tests/fixtures/device_status.json`:

   ```json
   {
     "name": "Encoder 01",
     "cpu": "42.5",
     "interfaces": [
       { "index": 1, "name": "eth0", "up": true },
       { "index": 2, "name": "eth1", "up": false }
     ]
   }
   ```

1. Next to it, write down the payload that the script should send to the Edge Node for that input, as `tests/fixtures/expected_payload.json`:

   ```json
   {
     "Device Name": "Encoder 01",
     "CPU Utilization": 42.5,
     "Interfaces": [
       { "Id": 1, "Name": "eth0", "Status": "Up" },
       { "Id": 2, "Name": "eth1", "Status": "Down" }
     ]
   }
   ```

## Validate the payload

With the files in place, you can check that the output follows the rules from [Learn what the Edge Node expects](#learn-what-the-edge-node-expects).

### Write a payload validator

Instead of repeating these rules in every test, put them in one helper that takes a payload and returns a list of problems, for example `tests/payload_rules.py`:

```python
"""Checks a payload against the rules of the Edge Node and the Data API."""
import json


MAX_PAYLOAD_BYTES = 1024 * 1024


def find_payload_problems(data):
    """Return a list of problems; an empty list means the payload is valid."""
    if not isinstance(data, dict) or not data:
        return ["The payload must be a non-empty JSON object."]

    try:
        encoded = json.dumps(data, allow_nan=False).encode("utf-8")
    except (TypeError, ValueError) as error:
        return [f"The payload is not valid JSON: {error}"]

    problems = []
    if len(encoded) > MAX_PAYLOAD_BYTES:
        problems.append(
            f"The payload is {len(encoded)} bytes; the limit is {MAX_PAYLOAD_BYTES}."
        )

    tables = {}
    _check_object(data, "$", "", problems, tables)
    for table, rows in tables.items():
        _check_ids(table, rows, problems)
    return problems


def _check_object(obj, path, prefix, problems, tables, in_row=False):
    for key, value in obj.items():
        location = f"{path}.{key}"
        if not key.strip():
            problems.append(f"{location}: empty key.")
        if isinstance(value, bool):
            problems.append(f"{location}: boolean; it arrives as the text 'True' or 'False'.")
        elif isinstance(value, (str, int, float)):
            continue
        elif isinstance(value, list):
            # A linked table is named after its key only, so the same key in
            # every row feeds one shared table.
            table = key if in_row else prefix + key
            _collect_rows(value, location, table, problems, tables)
        elif value is None:
            if not in_row:
                problems.append(f"{location}: null value; the parameter keeps its previous value.")
        elif in_row:
            problems.append(f"{location}: object in a table row; use a nested array instead.")
        else:
            _check_object(value, location, f"{prefix}{key}.", problems, tables)


def _collect_rows(rows, path, table, problems, tables):
    for index, row in enumerate(rows):
        if not isinstance(row, dict):
            problems.append(f"{path}[{index}]: table rows must be objects.")
            continue
        if any(value is None or isinstance(value, (str, int, float)) for value in row.values()):
            tables.setdefault(table, []).append(row)
        else:
            problems.append(f"{path}[{index}]: row without plain values; it cannot become a table row.")
        _check_object(row, f"{path}[{index}]", "", problems, tables, in_row=True)


def _check_ids(table, rows, problems):
    spellings = {key for row in rows for key in row if key.lower() == "id"}
    if not spellings:
        return
    if len(spellings) > 1:
        problems.append(f"{table}: Id is spelled differently across rows: {sorted(spellings)}.")
        return

    id_key = spellings.pop()
    ids = [row.get(id_key) for row in rows]
    filled = [
        str(value).lower()
        for value in ids
        if isinstance(value, (str, int, float)) and value != ""
    ]
    if len(filled) != len(ids):
        problems.append(f"{table}: every row needs an Id value.")
    if len(filled) != len(set(filled)):
        problems.append(f"{table}: duplicate Id values; Id is the primary key.")
```

Some notes on the validator:

- `allow_nan=False` is needed because `NaN` and `Infinity` are not valid JSON, and `requests` refuses to send them.
- The size check counts the encoded bytes. The Edge Node counts the characters of the body instead. For the ASCII-only JSON that `requests` sends by default, both give the same result, and in other cases the validator is slightly stricter.
- `null` is only reported outside tables. In a table row, it leaves the cell empty, unless it is in the `Id` column.
- An `Id` must be a plain value. An array, an object, or an empty string counts as a missing `Id`.
- The `Id` checks run per table, after all rows are collected. This way, the VLANs of all interfaces are checked together, in the same way the Data API merges them into one table.

The validator does not know which parameters, tables, and columns the element's connector defines. A payload without problems can still contain a key that the connector does not have, and that key is lost. The expected payload test in the next section detects accidental key changes.

### Test the transformation

With the validator and the fixtures, you can test `transform()` with three kinds of tests:

- **The expected payload test** compares the result with `expected_payload.json`. It catches accidental key renames.
- **The rules test** runs the validator on the result.
- **Edge case tests** cover situations such as an empty table or a missing field. Decide what the correct behavior is, e.g., an empty table or an error, and write a test for it. Note that an empty array leaves the table in DataMiner unchanged.

Save them as `tests/test_payload.py`:

```python
import json
import unittest
from pathlib import Path

from run.main import transform
from tests.payload_rules import find_payload_problems


FIXTURES = Path(__file__).resolve().parent / "fixtures"


def load_fixture(name):
    return json.loads((FIXTURES / name).read_text(encoding="utf-8"))


class TransformTests(unittest.TestCase):
    def test_payload_matches_expected_file(self):
        payload = transform(load_fixture("device_status.json"))

        self.assertEqual(load_fixture("expected_payload.json"), payload)

    def test_payload_follows_edge_node_rules(self):
        payload = transform(load_fixture("device_status.json"))

        self.assertEqual([], find_payload_problems(payload))

    def test_device_without_interfaces_gives_empty_table(self):
        raw = load_fixture("device_status.json")
        raw["interfaces"] = []

        self.assertEqual([], transform(raw)["Interfaces"])

    def test_missing_field_fails_loudly(self):
        raw = load_fixture("device_status.json")
        del raw["cpu"]

        with self.assertRaises(KeyError):
            transform(raw)


class PayloadRulesTests(unittest.TestCase):
    def test_detects_booleans_and_top_level_nulls(self):
        problems = find_payload_problems({"Online": True, "Location": None})

        self.assertEqual(2, len(problems))

    def test_accepts_nested_object_at_top_level(self):
        self.assertEqual([], find_payload_problems({"Details": {"Rack": 4}}))

    def test_detects_object_inside_table_row(self):
        problems = find_payload_problems({"Ports": [{"Id": 1, "Details": {"Rack": 4}}]})

        self.assertEqual(1, len(problems))

    def test_detects_nan(self):
        problems = find_payload_problems({"Temperature": float("nan")})

        self.assertEqual(1, len(problems))
        self.assertIn("not valid JSON", problems[0])

    def test_detects_missing_ids(self):
        problems = find_payload_problems({"Ports": [{"Id": 1}, {"Name": "eth1"}]})

        self.assertEqual(["Ports: every row needs an Id value."], problems)

    def test_detects_mixed_id_spelling(self):
        problems = find_payload_problems({"Ports": [{"Id": 1}, {"id": 2}]})

        self.assertEqual(["Ports: Id is spelled differently across rows: ['Id', 'id']."], problems)

    def test_detects_array_as_id(self):
        problems = find_payload_problems({"Ports": [{"Id": 1}, {"Id": [], "Name": "eth1"}]})

        self.assertEqual(["Ports: every row needs an Id value."], problems)

    def test_detects_empty_row(self):
        problems = find_payload_problems({"Ports": [{"Id": 1}, {}]})

        self.assertEqual(["$.Ports[1]: row without plain values; it cannot become a table row."], problems)

    def test_detects_duplicate_ids(self):
        problems = find_payload_problems({"Ports": [{"Id": 1}, {"Id": 1}]})

        self.assertEqual(["Ports: duplicate Id values; Id is the primary key."], problems)

    def test_detects_duplicate_ids_across_linked_tables(self):
        problems = find_payload_problems({
            "Interfaces": [
                {"Id": "eth0", "Vlans": [{"Id": 100}]},
                {"Id": "eth1", "Vlans": [{"Id": 100}]},
            ],
        })

        self.assertEqual(["Vlans: duplicate Id values; Id is the primary key."], problems)


if __name__ == "__main__":
    unittest.main()
```

## Replace the Edge Node with a mock

The tests so far check the data. The next tests check that the script sends it correctly, and that it raises an error when the Edge Node does not accept it.

### Test the push

The following tests check that the payload is sent with the run secret and a timeout, and that a rejected or failed request raises an exception. Save them as `tests/test_push.py`:

```python
import unittest
from unittest.mock import patch

import requests

from run.main import push_data_to_edge_node


class PushTests(unittest.TestCase):
    def setUp(self):
        environment = patch.dict("os.environ", {"EDGE_RUN_SECRET": "test-secret"}, clear=True)
        environment.start()
        self.addCleanup(environment.stop)

    @patch("run.main.requests.post")
    def test_sends_payload_with_run_secret(self, mock_post):
        push_data_to_edge_node({"CPU Utilization": 42.5})

        mock_post.assert_called_once_with(
            "http://localhost:5016/api/data",
            json={"CPU Utilization": 42.5},
            headers={"runSecret": "test-secret"},
            timeout=30,
        )

    @patch("run.main.requests.post")
    def test_rejected_push_raises(self, mock_post):
        mock_post.return_value.raise_for_status.side_effect = requests.HTTPError("401 Unauthorized")

        with self.assertRaises(requests.HTTPError):
            push_data_to_edge_node({"CPU Utilization": 42.5})

    @patch("run.main.requests.post", side_effect=requests.ConnectionError("Edge Node unreachable"))
    def test_unreachable_edge_node_raises(self, mock_post):
        with self.assertRaises(requests.ConnectionError):
            push_data_to_edge_node({"CPU Utilization": 42.5})


if __name__ == "__main__":
    unittest.main()
```

### Test a complete run

The last test runs `main()` from start to finish, as the Edge Node would, with both the device call and the push mocked. It then checks the payload that would have been sent. The argument is passed as `--host=value`, the same way the Edge Node passes it. Save it as `tests/test_main.py`:

```python
import json
import unittest
from pathlib import Path
from unittest.mock import patch

from run.main import main
from tests.payload_rules import find_payload_problems


FIXTURES = Path(__file__).resolve().parent / "fixtures"


class MainTests(unittest.TestCase):
    @patch("run.main.requests.post")
    @patch("run.main.requests.get")
    def test_full_run_sends_valid_payload(self, mock_get, mock_post):
        mock_get.return_value.json.return_value = json.loads(
            (FIXTURES / "device_status.json").read_text(encoding="utf-8")
        )

        with patch("sys.argv", ["main.py", "--host=10.0.0.5"]), \
                patch.dict("os.environ", {"EDGE_RUN_SECRET": "test-secret"}, clear=True):
            main()

        mock_get.assert_called_once_with("http://10.0.0.5/api/status", timeout=10)
        sent_payload = mock_post.call_args.kwargs["json"]
        self.assertEqual([], find_payload_problems(sent_payload))
        self.assertEqual("Encoder 01", sent_payload["Device Name"])


if __name__ == "__main__":
    unittest.main()
```

## Summary

Run all tests from the project root:

```powershell
python -m unittest discover -s tests -t . -p "test*.py" -v
```

In Visual Studio, the tests also appear in Test Explorer, where you can run and debug them.

Together, these tests cover the script without a device or an Edge Node:

- `test_payload.py` checks that `transform()` produces the expected payload, and that the payload follows the rules of the Edge Node and the Data API.
- `test_push.py` checks that the payload is sent with the run secret and a timeout, and that a failed push raises an exception.
- `test_main.py` checks a complete run, started the same way the Edge Node starts it.
