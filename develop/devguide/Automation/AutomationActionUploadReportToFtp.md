---
uid: AutomationActionUploadReportToFtp
---

# Upload report to FTP

Uploads a report to an FTP server.

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
