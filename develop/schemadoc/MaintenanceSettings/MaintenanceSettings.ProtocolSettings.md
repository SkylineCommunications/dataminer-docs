---
uid: MaintenanceSettings.ProtocolSettings
---

# ProtocolSettings element

Configures protocol-related settings.

## Parents

[MaintenanceSettings](xref:MaintenanceSettings)

## Children

| Name | Occurrences | Description |
| --- | --- | --- |
| All |  |  |
| &#160;&#160;[DCF](xref:MaintenanceSettings.ProtocolSettings.DCF) | [0, 1] | Configures DCF-related settings. |
| &#160;&#160;[ExecutionVerification](xref:MaintenanceSettings.ProtocolSettings.ExecutionVerification) | [0, 1] | Enables or disables the parameter update verification feature. When this is enabled, DataMiner will check all parameter updates that are executed either via DataMiner client applications or via SNMP set commands, and it will return the result of each check in the form of an information event. |
| &#160;&#160;[MaxAggregationThreads](xref:MaintenanceSettings.ProtocolSettings.MaxAggregationThreads) | [0, 1] | Specifies the maximum number of simultaneous aggregation threads within the SLProtocol process and simultaneous merge requests being launched in the SLDataMiner process. |
