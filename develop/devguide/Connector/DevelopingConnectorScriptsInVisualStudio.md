---
uid: DevelopingConnectorScriptsInVisualStudio
---

# Developing connector scripts in Visual Studio

You can use the **DataMiner Connector Script** project template to develop a Python-based integration for a DataMiner Edge Node in Visual Studio. The template provides the files and project settings needed for a consistent development experience and keeps the connector-specific data retrieval logic separate from the Edge Node communication.

> [!IMPORTANT]
> Edge Node mode is currently available in preview. For more information, see [About Edge Nodes](xref:About_Edge_Nodes).

## Prerequisites

Make sure the following are available:

- Visual Studio with Python development support.
- DataMiner Integration Studio (DIS) 2.42 or higher, which installs the latest DataMiner Visual Studio templates.
- A 64-bit Python 3.14 installation.
- A DataMiner connector solution.

Install the latest Python 3.14 patch release from the [Python downloads](https://www.python.org/downloads/) page. Do not install Python 3.15 for the connector script project; the connector runtime only supports Python 3.14.

## Creating a connector script project

To add a Python connector script to a connector solution:

1. Open the connector solution in Visual Studio.
1. In Solution Explorer, right-click the **Connector Scripts** solution folder.
1. Select **Add** > **New Project**.
1. Search for and select **DataMiner Connector Script**.
1. Enter a project name, for example `ConnectorScript_1`, and select **Create**.

The **Connector Scripts** solution folder is included in new connector solutions. If you are working with an older solution, create the solution folder manually before you add the project.

## Registering the script in the connector

Adding the project to the solution does not automatically register it in the connector. Add an `Edge` section and declare the script under `Edge.Scripts`.

The `Settings` and `Arguments` sections are optional. Include them only when the script requires connector-specific input. A script without input arguments only needs its `Script` declaration and schedule. The following example shows a script that uses optional connector settings:

```xml
<Settings>
  <Setting id="location" displayName="Location">
    <Text />
  </Setting>
  <Section displayName="Authentication">
    <Setting id="credentials" displayName="Credentials">
      <UsernamePasswordCredential />
    </Setting>
  </Section>
</Settings>

<Edge>
  <Scripts>
    <Script id="weatherScript" displayName="Weather script" guid="2d6e6fc6-a1c3-491a-b826-a988721e85c8">
      <Arguments>
        <Argument name="location">
          <SettingRef id="location" />
        </Argument>
        <Argument name="username">
          <SettingRef id="credentials" field="username" />
        </Argument>
        <Argument name="password">
          <SettingRef id="credentials" field="password" />
        </Argument>
      </Arguments>
      <Schedule>
        <Default>
          <Interval period="PT1H" />
        </Default>
      </Schedule>
    </Script>
  </Scripts>
</Edge>
```

Set the attributes as follows:

- `id`: A unique, connector-local identifier for the script.
- `displayName`: The name shown to users.
- `guid`: The `project.id` value from the script project's `manifest.json`.

The schedule in this example runs the script every hour. Configure the schedule and any script arguments according to the connector requirements.

### Passing connector settings to the script

Connector settings are not required for every script. When a script needs connector-specific configuration, define the values under `Settings` and map them to command-line arguments under `Edge.Scripts.Script.Arguments`, as shown in the example:

- `SettingRef.id` refers to the `id` of a setting defined under `Settings`.
- `SettingRef.field` selects a field from a compound setting, such as the `username` or `password` field of `UsernamePasswordCredential`.
- `Argument.name` defines the command-line option passed to the Python script. For example, `name="location"` is received as `--location`.

Define matching arguments in `parse_input()`:

```python
parser.add_argument("--location", required=True)
parser.add_argument("--username", required=True)
parser.add_argument("--password", required=True)
```

Use settings for deployment-specific values and credentials instead of hard-coding them in the script. The argument name does not have to match the setting ID, but the `SettingRef` ID must match an existing setting.

## Understanding the project structure

The generated project has the following structure:

```text
ConnectorScript_1/
├── manifest.json
├── README.md
├── requirements.txt
├── run/
│   └── main.py
└── tests/
    ├── __init__.py
    └── test_main.py
```

The project also contains development-only files such as the Python project file and `.gitignore`. These files are not part of the packaged connector script.

The main files have the following purpose:

- `manifest.json`: Defines the script identity, version, entry point, supported platforms, and supported Python version.
- `run/main.py`: Contains the script entry point.
- `requirements.txt`: Lists the direct third-party Python dependencies that must be resolved during packaging.
- `tests/test_main.py`: Contains the unit tests for the script and manifest.
- `README.md`: Contains project-specific development instructions.

## Implementing the connector logic

The generated entry point follows this workflow:

```python
def main():
    input_data = parse_input()
    data = get_data(input_data)
    push_data_to_edge_node(data)
```

Use each function for a distinct responsibility:

1. In `parse_input()`, define and parse the input arguments required by the connector script.
1. In `get_data()`, implement the communication with the data source and return the collected data.
1. Leave `push_data_to_edge_node()` responsible for returning that data to the Edge Node.

The object returned by `get_data()` must be JSON-serializable.

Keeping the data retrieval and Edge Node communication separate makes the connector-specific code easier to debug and test.

## Creating a virtual environment

Use a project-local virtual environment to isolate the packages used during development:

1. In Solution Explorer, expand **Python Environments**.
1. Add a virtual environment based on a 64-bit Python 3.14 interpreter.
1. Set the environment location to `.venv`.
1. Set the new environment as the current environment for the project.

The name `.venv` is a convention that makes the project-local environment easy to recognize. It is excluded from source control and packaging.

## Managing dependencies

Install each direct third-party dependency in the project virtual environment. To update `requirements.txt` in Visual Studio:

1. Right-click the `.venv` environment.
1. Select **Generate requirements.txt**.
1. Select **Replace entire file**.
1. Review the generated file and retain only the direct dependencies used by the connector script.

Do not list transitive dependencies manually. During packaging, the wheels resolver uses `pip` to resolve the transitive dependency graph from the direct dependencies in `requirements.txt`.

The Edge Node runtime provides CPython, the Python standard library, and `pip`. Other packages must be delivered as compatible wheels. Packages that are only available as source distributions are not supported.

Resolved wheels are separated according to their target:

- `universal`
- `x86_64-windows-msvc`
- `x86_64-linux-gnu`

For a package to work on every platform declared in `manifest.json`, a compatible wheel must be available for each required target, unless the package uses a universal wheel.

## Debugging the connector script

You can start `run/main.py` with the standard Visual Studio Python debugger. The project root is configured as the working directory.

If the connector script requires input arguments:

1. Open the Python project properties.
1. Go to the **Debug** tab.
1. Add the values under **Script Arguments**.
1. Set breakpoints in `parse_input()`, `get_data()`, or `push_data_to_edge_node()`.
1. Start debugging.

> [!CAUTION]
> Visual Studio stores the script arguments in the Python project file. Because this file is committed to Git, the arguments are also pushed to the remote repository. Never enter passwords, tokens, API keys, or other secrets as Debug arguments.

Use environment variables or another approved local secret mechanism for sensitive values. For local execution, `push_data_to_edge_node()` expects the execution secret in the `EDGE_RUN_SECRET` environment variable.

When reproducing a production issue, use representative non-sensitive input in your local debug configuration. If an input originates from the target system, capture or reconstruct only the minimum data needed to reproduce the behavior, and remove credentials and other confidential values before storing it locally.

## Testing the connector script

The project uses Python's built-in `unittest` framework. Run the tests from Test Explorer or from the project root:

```powershell
.\.venv\Scripts\python.exe -m unittest discover -s tests -t . -p "test*.py" -v
```

Unit tests do not inherit the Script Arguments configured on the Visual Studio Debug tab. Pass an argument list directly to `parse_input()` or patch `sys.argv` in the test.

Focus the tests on:

- Parsing valid and invalid inputs.
- The data returned by `get_data()`.
- Error handling for unavailable data sources and invalid responses.
- The interaction between `main()`, `get_data()`, and `push_data_to_edge_node()`.
- The script identity and entry point in `manifest.json`.

Mock external systems and HTTP requests so the unit tests remain deterministic and do not depend on network access.

## Working with Git

Commit the source code, manifest, dependency declaration, tests, README, and Python project file.

Do not commit:

- `.venv`
- `__pycache__` and compiled Python files
- Test and coverage caches
- Resolved dependency wheels
- Build and distribution output

The generated `.gitignore` excludes these development and packaging artifacts.

## Preparing the script for packaging

The source project remains a root-level project in the connector solution. During connector packaging, its runtime files are placed under a GUID-keyed `Scripts` directory in the `.dmprotocol` package:

```text
Scripts/<script-id>/
├── manifest.json
├── README.md
├── run/
│   └── main.py
└── dependencies/
```

The following values must identify the same connector script:

- The `project.id` value in `manifest.json`.
- The script GUID referenced by the connector.
- The name of the packaged `Scripts/<script-id>` directory.

The manifest generated by the template targets Python 3.14 and declares Windows x64 and Linux x64 support. Only declare platforms for which all required dependency wheels are available.

Before packaging, make sure that:

- The script and manifest tests pass.
- `protocol.xml` declares the script under `Edge.Scripts`.
- `requirements.txt` contains only direct third-party dependencies.
- The script does not contain credentials or environment-specific secrets.
- The returned data is JSON-serializable.
- The manifest entry point is `run/main.py`.
- The manifest identity matches the connector and packaged script identity.
