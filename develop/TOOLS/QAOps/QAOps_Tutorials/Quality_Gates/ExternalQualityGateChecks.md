---
uid: QAOps_Tutorials_External_Quality_Gate_Checks
description: Add an external check to a QAOps quality gate, create a source-scoped token, and report results from a script or CI pipeline with the QAOps tool.
---

# Adding and reporting external checks

In this tutorial, you will add an external validation check to a quality gate and report a result from PowerShell. The same command can run in a CI job or another process that produces the result.

Expected duration: 15 minutes.

An external check receives evidence; it does not run your validation. Your script or pipeline remains responsible for doing the work and reporting its actual outcome.

## Prerequisites

- A gate you can edit on [QAOps Sandbox](https://qaops-sandbox.skyline.be/public/qaops-quality-gates/index.html).

- Permission to create a token for the external reporting source.

- The [QAOps .NET tool](xref:QAOps_Tool), with `report-external-check` available.

Check the installed command before continuing:

```powershell
dataminer-qaops report-external-check --help
```

The examples use the sandbox storage account `saqaopssandbox`. Keep all gate IDs, source IDs, and tokens in the same sandbox environment. The `report-external-check` command requires `--storage-account-name`; it does not support the `-san` alias used by the test-run commands.

## Step 1: Add an external check

1. Open your gate.

1. Click *Configure gate*.

1. Under *Checks*, click *Add external check*.

1. Enter a *Check name*, for example `External release validation`.

   ![Gate editor with an external validation check and the message that a reporting source is created when saving](~/develop/images/QAOps_QualityGates_AddExternalCheck.png)

1. Click *Save gate*.

   Saving will create the gate-owned reporting source for this check.

1. Wait for save verification and open the saved gate's *Checks* tab.

1. Open *Manage source* for the external check.

1. Note the source ID and the gate ID.

   The gate ID is the identifier after `#/gates/` in the gate's URL. Use the **source ID**, not the check's ID, when sending reports. The source must remain enabled to accept new reports.

   ![External reporting source showing its identifier, maintainer, and enabled state](~/develop/images/QAOps_QualityGates_ExternalSource.png)

## Step 2: Create a reporting token

1. In the gate's *Checks* tab, click *Create reporting token* for your external check.

1. Check that the displayed scope matches your source.

   The helper preselects `qualitygatesources.<source-id>.report`. A token for another source, or a token that only permits QAOps test runs, does not authorize this report. The helper does not grant additional token-issuance permissions.

1. Set *Days until expiration*.

1. Set *Maximum uses*.

   For this exercise, one day and five uses are sufficient. New reports consume token uses. For recurring CI reporting, choose an appropriate expiration and usage policy, and plan for token rotation.

   ![Reporting-token helper with the external source scope preselected, one day until expiration, and a five-use limit](~/develop/images/QAOps_QualityGates_ReportingToken.png)

1. Click *Submit token request*.

1. Click *View generated token*.

   The existing QAOps token app will open the reveal for this request. The generated token name will start with `Reporting:` followed by your check name. Retrieve it promptly: the reveal expires after one hour and can be lost when the Accounts element restarts.

1. Copy the revealed token and store it securely.

   For a pipeline, use its secret store to inject the value as `QAOPS_TOKEN` into the reporting process. Do not put the value in source code, screenshots, command output, or build artifacts.

## Step 3: Send a result

1. Make the reporting token available as the `QAOPS_TOKEN` environment variable in the process that will run the command.

   The command reads this variable automatically. The same token provides transport authentication and authorization to report to the source; you do not need a separate Azure credential.

1. Replace the example gate and source IDs below with your saved IDs.

1. Run the command from PowerShell.

   ```powershell
   dataminer-qaops report-external-check `
     --gate-id "<your-sandbox-gate-id>" `
     --source-id "<your-sandbox-source-id>" `
     --status "OK" `
     --message "External release validation completed successfully." `
     --storage-account-name saqaopssandbox
   ```

   The tool will generate a report ID and UTC observation time when you omit them. The command waits for a bounded receipt response; acceptance does not guarantee that the app has refreshed already.

1. Check the command's response before treating the report as accepted.

   A successful receipt has `status: "ok"` and the command exits with code `0`. A report can be accepted with `publicationState: "retained"` without replacing newer evidence. Receipt success is not a passing verdict for the validation itself.

1. Return to the gate and refresh its status.

   The external check will use the latest accepted evidence by observation time. An accepted passing external report does not make the entire gate pass if another check fails or lacks usable evidence.

   ![Checks tab showing fresh OK external evidence while a separate QAOps check keeps the gate at FAIL](~/develop/images/QAOps_QualityGates_ExternalResult.png)

## Step 4: Report the actual result from your pipeline

Run the report command after the external validation finishes. Choose the status from its actual result:

- `OK`: Validation passed.

- `WARNING`: Validation needs attention or cannot provide a definite passing result.

- `FAIL`: Validation failed.

The following example assumes your validation step has already set `$validationExitCode`. It does not run the validation itself.

```powershell
$status = if ($validationExitCode -eq 0) { "OK" } else { "FAIL" }
$message = if ($validationExitCode -eq 0) {
    "External release validation passed."
} else {
    "External release validation failed. Inspect the validation job."
}

dataminer-qaops report-external-check `
  --gate-id "<your-sandbox-gate-id>" `
  --source-id "<your-sandbox-source-id>" `
  --status "$status" `
  --message "$message" `
  --result-link "https://ci.example.com/runs/123" `
  --storage-account-name saqaopssandbox

$reportExitCode = $LASTEXITCODE
if ($reportExitCode -ne 0) {
    throw "External report was not confirmed. Inspect the reporting response."
}
if ($validationExitCode -ne 0) {
    throw "External validation failed."
}
```

Replace the result link with an HTTPS link to your actual build or report. Do not include credentials, signed download URLs, or other secrets in the link or message. QAOps stores the link as a locator; it does not fetch the linked report.

Configure your pipeline so the reporting step also runs after validation fails. A successful report submission means evidence was accepted, not that the validation passed. Keep the validation outcome as part of your pipeline's own release decision.

## Handle retries and outdated results

For reliable retries, generate and retain a report identity **before** the first submission. Supply the same canonical uppercase ULID with `--report-id` and the same UTC observation timestamp with `--observed-at-utc` on every retry of that result.

An exact duplicate is idempotent and does not consume another report use. Reusing the ID with changed content is a conflict. A timeout does not prove rejection: retry the same report instead of sending a new identity for the same observation.

Use the time the validation was observed, not a newer retry time. Older or equal-time reports can be retained without replacing the current evidence, and resending them does not make evidence fresh. If the source stops reporting, the check will eventually become a warning when its evidence expires.

If reporting fails, check that the source is enabled, the gate and source IDs belong together, the token includes the exact source scope, and `--storage-account-name` still targets sandbox.

If sending succeeds but receipt polling returns HTTP 403 or 404, the report-specific response queue or its access permissions may not be ready. This does not prove that the report was rejected. Keep the printed report ID and observation time, allow time for permissions to propagate, and retry the unchanged report. If receipt access continues to fail, contact `support.boost@skyline.be`; do not change the report identity just to obtain a new response queue.
