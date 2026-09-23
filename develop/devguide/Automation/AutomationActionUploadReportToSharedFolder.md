---
metadata_version: 1
uid: AutomationActionUploadReportToSharedFolder
description: "Use the report action to upload a generated report to a shared network folder and validate the share path, credentials, and permissions."
content_type: conceptual
applies_to:
  - DataMiner
---

# Upload report to shared folder

Uploads a report to a shared network folder.

## Audience and prerequisites

Use this action when an automation script must deliver a report to a network share. Before configuring it, make sure the report template exists and that the DataMiner system can reach the share with the required credentials.

<a id="automation-action-upload-report-to-shared-folder-scope"></a>

## Scope

The `Template` element selects the report, `Destination` describes the shared-folder target, and `Include` elements identify the content to include. The action does not create the share or change its permissions.

## Expected result

When the action executes, DataMiner generates the selected report and attempts to copy it to the configured shared folder.

<a id="automation-action-upload-report-to-shared-folder-failure-and-edge-cases"></a>

## Failure and edge cases

An invalid template, share path, credential set, or folder permission prevents a successful upload. Replace all sample host, path, and credential values before deploying the script, and verify access from the DataMiner system.

```xml
<Exe id="2" type="report">
   <Template>Report 4</Template>
   <Destination type="email" title="" cc="" bcc="">copy:prefix:\\host\path:username:pw:domain</Destination>
   <Message></Message>
   <Include params="">VIEW:-1</Include>
</Exe>
```

## Related concepts

- [Automation script actions](xref:AutomationActions)
- [Template element](xref:DMSScript.Script.Exe.Template)
- [Destination element](xref:DMSScript.Script.Exe.Destination)
- [Include element](xref:DMSScript.Script.Exe.Include)

## Authoritative references

- [Exe element](xref:DMSScript.Script.Exe)
- [Report template action schema](xref:DMSScript.Script.Exe.Template)
