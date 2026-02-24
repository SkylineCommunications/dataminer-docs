---
uid: QAOps_Test_Result
---

# QAOps test result

> [!IMPORTANT]
> This section contains information that is only applicable to Skyline employees.

A QAOps test result contains the outcome of one test case execution.

## Required fields

Each test result must include the following fields:

- `Name`: A short, human-readable name for the test case. Any non-empty string is allowed.

- `Outcome`: The final test result. Allowed values are case-insensitive: `Ok`, `Fail`, `NotExecuted`, `NotApplicable`.

## Optional fields

You can add the following fields to provide more context:

- `Message`: Additional details, such as what was tested or how to investigate a failure.

- `Duration`: The execution time of the test case.

- `Tags`: A semicolon-separated or comma-separated list of tags that can be used for filtering in the Low-Code App or for ownership and categorization metadata.

- `TestAspect`: The result type. Allowed values are `Execution` and `Assertion`.
  
    - `Execution` indicates the health of the test framework or runner itself (for example, script setup failures).
  
    - `Assertion` indicates the outcome of the actual product or solution behavior under test.

## Storage behavior

At present, QAOps stores test results in memory and in STaaS through elements on the QAOps system.

This storage model is intended for short-term retention, similar to keeping only the most recent runs of a Jenkins pipeline or GitHub workflow.

Long-term retention through additional technology stacks is planned in 2026.

The current design prioritizes speed and cost efficiency. The framework and Low-Code App load active data directly from memory for each active user.

## Sending results to QAOps

You can send test results to QAOps in four ways:

1. Use the PowerShell API with `Push-TestCaseResult` to send test results from your QAOps test package pipeline.

1. Use HTTP Post calls to http://localhost:5200/QAOps/testcaseresult

1. For DataMiner source code tests (to support the current test pool), results sent through QAHelperLib are redirected to QAOps when they run on a QAOps system.

1. For legacy GitHub test projects that use QAPortalAPI, results are redirected to QAOps when they run on a QAOps system.

## PowerShell API reference

`Push-TestCaseResult` posts a single test case result to the QAOps Bridge API.

The cmdlet serializes input to camelCase JSON, omits null fields, and sends an HTTP POST request with a 30-second timeout.

### Endpoint resolution

The target endpoint is selected in this order:

1. `-ApiUrl` parameter (explicit override).

1. `QAOPS_API_URL` environment variable.

1. Built-in default: `http://localhost:5200/QAOps/testcaseresult`.

### Parameters

- `-Outcome` (required): `Ok`, `Fail`, `NotExecuted`, or `NotApplicable` (case-insensitive).

- `-Name` (required): Short test case name.

- `-TestCaseId` (optional): ULID string. If omitted or empty, a new ULID is generated client-side.

- `-Message` (optional): Free-form details. Omitted from payload if empty.

- `-DateTime` (optional): Timestamp of the result. If omitted, the server sets current UTC time.

- `-Duration` (optional): Test duration as a PowerShell `TimeSpan`.

- `-Tags` (optional): Tag string converted to a key-value dictionary.
  
    - Use `;` or `,` to separate items.
  
    - Use `key=value` or a bare key.
  
    - A bare key is stored as value `"true"`.
  
    - Only the first `=` splits key and value.
  
    - Duplicate keys are case-insensitive, and the last value wins.
  
    - If no valid tags are provided, the `tags` field is omitted.

- `-TestAspect` (optional, default `Assertion`): `Assertion` or `Execution` (case-insensitive).

- `-ApiUrl` (optional): Overrides endpoint selection.

### Syntax

```powershell
Push-TestCaseResult -Outcome {Ok | Fail | NotExecuted | NotApplicable} `
    -Name <string> `
    [-TestCaseId <string>] `
    [-Message <string>] `
    [-DateTime <datetime>] `
    [-Duration <timespan>] `
    [-Tags <string>] `
    [-TestAspect {Assertion | Execution}] `
    [-ApiUrl <string>] `
    [<CommonParameters>]
```

### Payload shape

```json
{
    "testCaseId": "<ULID>",
    "name": "<string>",
    "outcome": "<Ok|Fail|NotExecuted|NotApplicable>",
    "message": "<string|null>",
    "dateTime": "<ISO 8601|null>",
    "duration": "<TimeSpan|null>",
    "tags": {
        "<key>": "<value>"
    },
    "testAspect": "<Assertion|Execution|null>"
}
```

If no tags are supplied, the `tags` field is omitted.

### Examples

```powershell
# Minimal
Push-TestCaseResult -Outcome Ok -Name "Ping basic"

# With message and timing
Push-TestCaseResult -Outcome Fail -Name "Login form" `
    -Message "Submit returned 500" -Duration "00:00:02.340"

# With explicit timestamp
Push-TestCaseResult -Outcome NotExecuted -Name "Backup job" `
    -DateTime "2025-10-07 09:15:00"

# Tags with mixed separators
Push-TestCaseResult -Outcome Ok -Name "ETL step" `
    -Tags 'env=prod;team=data,runId=42;note="morning batch"'

# Bare tag flags
Push-TestCaseResult -Outcome Ok -Name "Feature check" `
    -Tags 'featureX;tenant=acme'

# Execution aspect
Push-TestCaseResult -Outcome Fail -Name "Setup containers" `
    -TestAspect Execution -Message "Docker daemon unavailable"

# Custom endpoint
Push-TestCaseResult -Outcome Ok -Name "Smoke" `
    -ApiUrl "https://qaops.example.com/QAOps/testcaseresult"

# Endpoint via environment variable
$env:QAOPS_API_URL = "https://bridge:5200/QAOps/testcaseresult"
Push-TestCaseResult -Outcome Ok -Name "Nightly sanity"
```

## Troubleshooting

- HTTP `400` or `422`: Verify `-Outcome` and `-Tags` format.

- HTTP `401` or `403`: Verify authentication and endpoint permissions.

- HTTP `404`: Verify the path `/QAOps/testcaseresult`.

- TLS or certificate errors: Verify HTTPS configuration and certificate trust.

- Timeout: Default client timeout is approximately 30 seconds. Verify connectivity and server health.

- Date parsing errors: Prefer ISO 8601 format, for example `2025-10-07T14:23:00Z`.

- Duration parsing errors: Use standard `TimeSpan` formats, for example `hh:mm:ss`.

- Missing tags in output: Empty or whitespace-only `-Tags` values are omitted.

## See also

- `Get-Help Push-TestCaseResult -Full`

- `Get-Help about_CommonParameters`

- `Get-Command Push-TestCaseResult -Syntax`
