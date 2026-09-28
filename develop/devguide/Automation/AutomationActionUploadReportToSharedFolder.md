---
metadata_version: 1
uid: AutomationActionUploadReportToSharedFolder
description: "Use the report action to upload a generated report to a shared network folder by specifying a template, the share path, and credentials."
---

# Upload report to shared folder

Uploads a generated report to a shared network folder. The `Template` element selects an existing report template, the `Destination` element specifies the share, and the `Include` element selects the content.

```xml
<Exe id="2" type="report">
   <Template>Report 4</Template>
   <Destination type="email" title="" cc="" bcc="">copy:prefix:\\host\path:username:pw:domain</Destination>
   <Message></Message>
   <Include params="">VIEW:-1</Include>
</Exe>
```

> [!IMPORTANT]
> Replace the sample share path and credentials before using this example. The report template must exist, and the DataMiner System must be able to access and write to the share.
