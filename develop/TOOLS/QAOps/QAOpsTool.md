---
uid: QAOps_Tool
---

# QAOps Tool

> [!IMPORTANT]
> This section includes information that is only applicable to Skyline employees.

The QAOps .NET Tool allows you to run automated test suites against DataMiner configurations remotely. This command-line tool integrates with the QAOps testing platform to execute your test packages and retrieve results programmatically.

**Key capabilities:**

- Execute test suites in fire-and-forget mode or wait for completion

- Override test packages with local `.dmtest` files

- Tag test runs for organization and filtering

- Retrieve detailed test results in JSON format

- Integrate with CI/CD pipelines for automated testing

This tool is available on our private NuGet store. More information can be found [here](https://internaldocs.skyline.be/DevDocs/Skyline%20Software%20Development%20Toolkit/Private%20NuGet%20Store.html).

## Installation

Install the tool globally using the .NET CLI:

```bash
dotnet tool install -g Skyline.DataMiner.QAOps
```

## Quick start

To run a test suite and wait for results:

```bash
# Set your authentication token
export QAOPS_TOKEN=<your-token>

# Run a test suite and save results
dataminer-qaops test-run-and-wait \
  --testsuite-id <your-testsuite-id> \
  --configuration-id <your-configuration-id> \
  --result-filepath ./test-results.json
```

> [!TIP]
> You can find your test suite and configuration IDs in the QAOps Operator application. Authentication tokens are created through the [QAOps User application](xref:QAOps_Main_UI#qaops-user-tokens).

## Common examples

### Run and wait for test completion

Most common use case - execute a test suite and wait for results:

```bash
dataminer-qaops test-run-and-wait \
  --testsuite-id 01ARZ3NDEKTSV4RRFFQ69G5FAV \
  --configuration-id 01ARZ3NDEKTSV4RRFFQ69G5FAW \
  --result-filepath ./test-results.json \
  --timeout-in-seconds 3600 \
  --tags "automation;regression"
```

### Fire-and-forget execution

Start a test suite without waiting for completion (useful for long-running tests):

```bash
dataminer-qaops test-run \
  -t 01ARZ3NDEKTSV4RRFFQ69G5FAV \
  -c 01ARZ3NDEKTSV4RRFFQ69G5FAW \
  --tags "smoke-test"
```

### Override test packages with local files

Replace test packages in a suite with your local `.dmtest` files:

```bash
dataminer-qaops test-run-and-wait \
  -t 01ARZ3NDEKTSV4RRFFQ69G5FAV \
  -c 01ARZ3NDEKTSV4RRFFQ69G5FAW \
  --override-test-packages \
    01ARZ3NDEKTSV4RRFFQ69G5FAX ./my-test1.dmtest \
    01ARZ3NDEKTSV4RRFFQ69G5FAY ./my-test2.dmtest
```

## Commands reference

### `dataminer-qaops test-run`

Executes a test suite in fire-and-forget mode (does not wait for completion).

```bash
dataminer-qaops test-run -t <testsuite-id> -c <configuration-id> [options]
```

### `dataminer-qaops test-run-and-wait`

Executes a test suite and waits for completion, with optional result output to file.

```bash
dataminer-qaops test-run-and-wait -t <testsuite-id> -c <configuration-id> [options]
```

## Parameters reference

### Required parameters

- **Test Suite ID** (`-t`, `--testsuite-id`): The unique ULID identifier of the QAOps Test Suite to run

- **Configuration ID** (`-c`, `--configuration-id`): The unique ULID identifier of the QAOps Configuration to run this Test Suite on

### Optional parameters

#### Common options (both commands)

- **Token** (`--token`): Authentication token (alternatively set via `QAOPS_TOKEN` environment variable)

- **Tags** (`-tags`, `--tags`): Semi-colon separated list of tags for organizing and filtering test runs

- **Hotfix ID** (`-whi`, `--hotfix-id`): Identifier returned after uploading a DataMiner upgrade package.

- **Override Test Packages** (`--override-test-packages`): Replace test packages in the suite with local `.dmtest` files. Specify as: `<package-id> <file-path>` pairs

#### Wait-specific options

These options only apply to the `test-run-and-wait` command:

- **Result File Path** (`-rf`, `--result-filepath`): File path to store JSON test results (overwrites existing file)

- **Timeout** (`-tim`, `--timeout-in-seconds`): Maximum time to wait for completion in seconds (default: 7200 seconds / 2 hours)

#### Global options

- **Debug** (`--debug`): Enable debug logging

- **Minimum Log Level** (`--minimum-log-level`): Set minimum log level (default: Information)

## Authentication

Authentication tokens are created through the [QAOps User application](xref:QAOps_Main_UI#qaops-user-tokens). Once you have your token, provide it using either method:

### Environment variable (recommended)

```bash
export QAOPS_TOKEN=<your-token>
dataminer-qaops test-run -t <testsuite-id> -c <configuration-id>
```

### Command line parameter

```bash
dataminer-qaops test-run --token <your-token> -t <testsuite-id> -c <configuration-id>
```

> [!NOTE]
> Using the environment variable is recommended for security reasons, especially in CI/CD environments.

## Advanced usage

### Overriding test packages

You can replace specific test packages in a test suite with your local `.dmtest` files. This is useful for testing modifications before uploading them to the Catalog.

**Single command with multiple overrides:**

```bash
dataminer-qaops test-run -t <testsuite-id> -c <config-id> \
  --override-test-packages <package-id-1> path/to/test1.dmtest <package-id-2> path/to/test2.dmtest
```

**Separate override parameters:**

```bash
dataminer-qaops test-run -t <testsuite-id> -c <config-id> \
  --override-test-packages <package-id-1> path/to/test1.dmtest \
  --override-test-packages <package-id-2> path/to/test2.dmtest
```

> [!IMPORTANT]
> Each override requires exactly two values: the test package identifier (ULID) and the file path to a `.dmtest` file. You can find package IDs in the QAOps web interface.

## Exit codes

The tool returns specific exit codes to indicate the outcome of the operation:

- **0**: Success - Test suite completed successfully

- **1**: Test failure - One or more tests failed

- **2**: Timeout - Test suite did not complete within the specified timeout

- **-1**: Unexpected exception - An error occurred during execution

- **-2**: Not implemented - Feature is not yet implemented

> [!TIP]
> These exit codes are useful for integrating the tool into CI/CD pipelines where you need to determine the success or failure of test runs programmatically.
