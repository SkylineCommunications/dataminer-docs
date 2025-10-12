---
uid: MaintenanceSettings.ProtocolSettings.DCF.CalculateAlarmState
---

# CalculateAlarmState element

Enables or disables DCF interface state calculation on system level.

## Content Type

boolean

## Parents

[DCF](xref:MaintenanceSettings.ProtocolSettings.DCF)

## Remarks

You can overrule the setting in a protocol, by setting the [Protocol.ParameterGroups.Group@calculateAlarmState](xref:Protocol.ParameterGroups.Group-calculateAlarmState) attribute to true or false.

## Examples

```xml
<MaintenanceSettings xmlns="http://www.skyline.be/config/maintenancesettings">
  <ProtocolSettings>
    <DCF>
      <CalculateAlarmState>false</CalculateAlarmState>
    </DCF>
  </ProtocolSettings>
</MaintenanceSettings>
```
