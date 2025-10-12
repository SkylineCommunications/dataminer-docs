---
uid: MaintenanceSettings.SLASPConnection.ReportResponseTimeout
---

# ReportResponseTimeout element

Specifies how long the SLASPConnection process has to wait for a report to respond in minutes.
If it contains “0” or if the tag cannot be found, then the default timeout is 60 minutes.

## Content Type

integer

## Parents

[SLASPConnection](xref:MaintenanceSettings.SLASPConnection)

## Remarks

> [!NOTE]
> If this setting is adjusted, the report’s ASP page also has to be able to run for the modified period of time. This can be configured in IIS or in the ASP file itself, using “Server.ScriptTimeout = 3600;”. In long reports it is also advisable to force sending out the data in packets using “Response.Flush();”.

## Examples

```xml
<MaintenanceSettings
 xmlns="http://www.skyline.be/config/maintenancesettings">
  <SLASPConnection>
    <ReportResponseTimeout>60</ReportResponseTimeout>
  </SLASPConnection>
</MaintenanceSettings>
```

When the DMA is started, the following line in the SLASPConnection log file mentions this setting:

```txt
2015/02/09 09:01:22.020|SLASPConnection.exe 8.5.1451.1|6828|17292|CServiceModule::ReadMaintenanceSettings|DBG|5|ReportResponseTimeout set to 60 minutes (configurable in maintenance settings).
```
