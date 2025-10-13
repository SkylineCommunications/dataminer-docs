---
uid: MaintenanceSettings.Replication.ConnectionMinDelayBeforeRetry
---

# ConnectionMinDelayBeforeRetry element

When a DataMiner Agent fails to set up a connection to another DataMiner Agent for replication purposes, further attempts to set up a connection are blocked during a fixed time interval (in seconds).

Default value: 60s.

## Content Type

integer

## Parents

[Replication](xref:MaintenanceSettings.Replication)

## Remarks

> [!NOTE]
>
> - If you change this setting, it will only be applied after a DMA restart.
> - This setting is not synchronized among DataMiner Agents in a DMS.

## Examples

```xml
<MaintenanceSettings>
  <Replication>
    <ConnectionMinDelayBeforeRetry>60</ConnectionMinDelayBeforeRetry>
    ...
  </Replication>
  ...
</MaintenanceSettings>
```
