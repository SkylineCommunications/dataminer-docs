---
uid: QAOps_Tool
---

# QAOps tool

> [!IMPORTANT]
> This section contains information that is only applicable to Skyline employees.

The QAOps .NET tool allows you to run automated test suites against DataMiner configurations remotely. This command-line tool integrates with the QAOps testing platform to execute your test packages and retrieve results programmatically.

Key capabilities:

- Execute test suites in fire-and-forget mode or wait for completion.

- Override test packages with local .dmtest files.

- Upload supplementary files that are made available to test package scripts and test code during the run.

- Tag test runs for easy organization and filtering.

- Retrieve detailed test results in JSON format.

- Integrate with CI/CD pipelines for automated testing.

This tool is available on Skyline's private NuGet store. For more information, refer to the [internal Skyline documentation](https://internaldocs.skyline.be/DevDocs/Skyline%20Software%20Development%20Toolkit/Private%20NuGet%20Store.html) (link accessible for Skyline employees only).

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
> You can find your test suite and configuration IDs in the QAOps Operator application. Authentication tokens are created through the [QAOps User application](xref:QAOps_Main_UI#qaops-user---tokens).

## Common examples

### Run and wait for test completion

The most common use case is to execute a test suite and wait for results:

```bash
dataminer-qaops test-run-and-wait \
  --testsuite-id 01ARZ3NDEKTSV4RRFFQ69G5FAV \
  --configuration-id 01ARZ3NDEKTSV4RRFFQ69G5FAW \
  --result-filepath ./test-results.json \
  --timeout-in-seconds 3600 \
  --tags "automation;regression"
```

### Fire-and-forget execution

You can start a test suite without waiting for completion (useful for long-running tests):

```bash
dataminer-qaops test-run \
  -t 01ARZ3NDEKTSV4RRFFQ69G5FAV \
  -c 01ARZ3NDEKTSV4RRFFQ69G5FAW \
  --tags "smoke-test"
```

### Override test packages with local files

You can replace test packages in a suite with your local .dmtest files:

```bash
dataminer-qaops test-run-and-wait \
  -t 01ARZ3NDEKTSV4RRFFQ69G5FAV \
  -c 01ARZ3NDEKTSV4RRFFQ69G5FAW \
  --override-test-packages \
    01ARZ3NDEKTSV4RRFFQ69G5FAX ./my-test1.dmtest \
    01ARZ3NDEKTSV4RRFFQ69G5FAY ./my-test2.dmtest
```

### Run with supplementary files

You can upload files that are needed during a test run without including them in the .dmtest package:

```powershell
dataminer-qaops test-run-and-wait `
  -t 01ARZ3NDEKTSV4RRFFQ69G5FAV `
  -c 01ARZ3NDEKTSV4RRFFQ69G5FAW `
  --supplementary-file ".\configuration.json" `
  --supplementary-file ".\Scripts\PrepareEnvironment.ps1" `
  --result-filepath ".\test-results.json"
```

You can repeat the `--supplementary-file` option to provide multiple files. The `--supplementary-files` alias is also supported. Any file type can be uploaded.

The tool validates that every file exists and uploads the files as a single archive. Relative paths keep their folder structure in the archive. Absolute paths are stored using only the file name. If two paths would produce the same archive entry, the command is rejected.

> [!NOTE]
> Supplementary files are runtime inputs. If only a supplementary file changes, you do not need to rebuild or increment the version of the .dmtest package.

For information about accessing these files from PowerShell or C# test code, see [Accessing supplementary files](xref:QAOps_Test_Package#accessing-supplementary-files).

## Commands reference

- `dataminer-qaops test-run`

  Executes a test suite in fire-and-forget mode (does not wait for completion).

  ```bash
  dataminer-qaops test-run -t <testsuite-id> -c <configuration-id> [options]
  ```

- `dataminer-qaops test-run-and-wait`

  Executes a test suite and waits for completion, with optional result output to file.

  ```bash
  dataminer-qaops test-run-and-wait -t <testsuite-id> -c <configuration-id> [options]
  ```

## Parameters reference

### Required parameters

- **Test Suite ID** (`-t`, `--testsuite-id`): The unique ULID identifier of the QAOps test suite to run.

- **Configuration ID** (`-c`, `--configuration-id`): The unique ULID identifier of the QAOps configuration to run this test suite on.

### Optional parameters

#### Common options (both commands)

- **Token** (`--token`): Authentication token (alternatively set via the `QAOPS_TOKEN` environment variable).

- **Tags** (`-tags`, `--tags`): Semi-colon separated list of tags for organizing and filtering test runs.

- **Hotfix ID** (`-whi`, `--hotfix-id`): Identifier returned after uploading a DataMiner upgrade package.

- **Override Test Packages** (`--override-test-packages`): Replaces test packages in the suite with local .dmtest files. Specify these as `<package-id> <file-path>` pairs.

- **Supplementary Files** (`--supplementary-file`, `--supplementary-files`): Uploads one or more files that are made available on every Agent during the test run. Repeat the option for multiple files.

#### Wait-specific options

These options only apply to the `test-run-and-wait` command:

- **Result File Path** (`-rf`, `--result-filepath`): File path to store JSON test results (overwrites existing file).

- **Timeout** (`-tim`, `--timeout-in-seconds`): Maximum time to wait for completion in seconds (default: 7200 seconds/2 hours).

#### Global options

- **Debug** (`--debug`): Enables debug logging.

- **Minimum Log Level** (`--minimum-log-level`): Sets the minimum log level (default: *Information*).

## Authentication

Authentication tokens are created through the [QAOps User application](xref:QAOps_Main_UI#qaops-user---tokens). Once you have your token, provide it using either of the following methods:

- **Environment variable** (recommended)

  ```bash
  export QAOPS_TOKEN=<your-token>
  dataminer-qaops test-run -t <testsuite-id> -c <configuration-id>
  ```

- **Command line parameter**

  ```bash
  dataminer-qaops test-run --token <your-token> -t <testsuite-id> -c <configuration-id>
  ```

> [!NOTE]
> Using the environment variable is recommended for security reasons, especially in CI/CD environments.

## Overriding test packages

You can replace specific test packages in a test suite with your local .dmtest files. This is useful for testing modifications before uploading them to the Catalog.

- **Single command with multiple overrides**:

  ```bash
  dataminer-qaops test-run -t <testsuite-id> -c <config-id> \
    --override-test-packages <package-id-1> path/to/test1.dmtest <package-id-2> path/to/test2.dmtest
  ```

- **Separate override parameters**:

  ```bash
  dataminer-qaops test-run -t <testsuite-id> -c <config-id> \
    --override-test-packages <package-id-1> path/to/test1.dmtest \
    --override-test-packages <package-id-2> path/to/test2.dmtest
  ```

> [!IMPORTANT]
> Each override requires exactly two values: the test package identifier (ULID) and the file path to a .dmtest file. You can find the package IDs in the [QAOps Operator app](xref:QAOps_Main_UI#qaops-operator---test-suites).

## Supplementary file requirements

Supplementary files are uploaded with the same QAOps token that starts the test run.

> [!IMPORTANT]
> Tokens created before supplementary-file support was introduced may not have permission to upload to the supplementary files container. If the upload is rejected, create a new token in the [QAOps User application](xref:QAOps_Main_UI#qaops-user---tokens) and try again.

Every target server must run QAOps Bridge 1.1.0 or higher. If one or more servers use an older version, QAOps refuses the run instead of executing tests without the requested files.

The files are available to every process started by the test run. This capability has been verified by the security team as a safe mechanism for transferring secrets, credentials, and other sensitive data to your test execution environment.

## Exit codes

The tool returns specific exit codes to indicate the outcome of an operation:

- **0**: Success. Test suite completed successfully.

- **1**: Test failure. One or more tests failed.

- **2**: Timeout. The test suite did not complete within the specified timeout.

- **-1**: Unexpected exception. An error occurred during execution.

- **-2**: Not implemented. Feature is not yet implemented.

> [!TIP]
> These exit codes are useful for integrating the tool into CI/CD pipelines where you need to determine the success or failure of test runs programmatically.
