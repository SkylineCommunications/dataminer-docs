---
metadata_version: 1
uid: AutomationActionUploadReportToFtp
description: "Use the report action to upload a generated report to an FTP destination, and validate the template, destination, and credentials."
---

# Upload report to FTP

Uploads a generated report to an FTP server. The [`Template` element](xref:DMSScript.Script.Exe.Template) selects an existing report template, the [`Destination` element](xref:DMSScript.Script.Exe.Destination) specifies the FTP target, and [`Include` elements](xref:DMSScript.Script.Exe.Include) select the content.

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

> [!IMPORTANT]
> Replace the sample FTP host, path, and credentials before using this example. The report template must exist, and the DataMiner System must be able to reach and authenticate with the server.
