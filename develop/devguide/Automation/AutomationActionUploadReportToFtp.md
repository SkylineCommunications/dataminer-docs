---
metadata_version: 1
uid: AutomationActionUploadReportToFtp
description: "Use the report action to upload a generated report to an FTP destination, and validate the template, destination, and credentials."
---

# Upload report to FTP

Uploads a report to an FTP server.

## Audience and prerequisites

Use this action when an automation script must deliver a report to an FTP server. Before configuring it, make sure the report template exists and that the target FTP server and credentials are available to the DataMiner system.

## Scope

The `Template` element selects the report, `Destination` describes the FTP target, and `Include` elements identify the content to include. The action does not define or modify the report template itself.

## Expected result

When the action executes, DataMiner generates the selected report and attempts to upload it to the configured FTP destination.

## Failure and edge cases

An invalid template, destination format, network route, or credential set prevents a successful upload. Replace all sample host, path, and credential values before deploying the script, and verify that the FTP server accepts the configured connection.

```xml
<Exe id="2" type="report">
   <Template>Report 4</Template>
   <Destination type="email" title="" cc="" bcc="">ftp:host#20:/mypath/prefix:usernam:pw</Destination>
   <Message></Message>
   <Include params="4000(0)">DUMMY:1</Include>
   <Include params="65122(0),65123(*|0)">ELEMENT:346/1851</Include>
   <Include params="">ELEMENT:346/530092</Include>
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
