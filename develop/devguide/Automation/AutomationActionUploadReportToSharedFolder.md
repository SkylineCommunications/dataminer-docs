---
uid: AutomationActionUploadReportToSharedFolder
---

# Upload report to shared folder

Uploads a report to a shared network folder.

```xml
<Exe id="2" type="report">
   <Template>Report 4</Template>
   <Destination type="email" title="" cc="" bcc="">copy:prefix:\\host\path:username:pw:domain</Destination>
   <Message></Message>
   <Include params="">VIEW:-1</Include>
</Exe>
```
