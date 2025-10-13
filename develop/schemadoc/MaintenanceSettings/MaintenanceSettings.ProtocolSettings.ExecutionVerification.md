---
uid: MaintenanceSettings.ProtocolSettings.ExecutionVerification
---

# ExecutionVerification element

Enables or disables the parameter update verification feature. When this is enabled, DataMiner will check all parameter updates that are executed either via DataMiner client applications or SNMP set commands, and it will return the result of each check in the form of an information event.

Default timeout: 30000 milliseconds.

## Type

string

## Content Type

string

## Parents

[ProtocolSettings](xref:MaintenanceSettings.ProtocolSettings)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [timeout](xref:MaintenanceSettings.ProtocolSettings.ExecutionVerification-timeout) | string |  | Specifies the timeout in ms. |

## Remarks

> [!NOTE]
> In a DataMiner protocol, you can also specify update verification settings on parameter level. See [Protocol.Params.Param](xref:Protocol.Params.Param).
