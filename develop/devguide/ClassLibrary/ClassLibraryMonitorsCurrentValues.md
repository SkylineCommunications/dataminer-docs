---
uid: ClassLibraryMonitorsCurrentValues
---

# Receiving current values when starting a monitor

Most monitors, when started, will immediately receive an event containing the current value or state. This allows you to act on the current situation without waiting for the first actual change.

## ParameterValueMonitors

For `StartValueMonitor` methods on `IDmsStandaloneParameter`, `IDmsColumn` (cell), `IDmsColumn` (column), and `IDmsTable`, this behavior is controlled by a mandatory `includeCurrentValues` boolean parameter.

Pass `true` to receive an initial event with the current value when the monitor starts, or `false` to only receive future changes.

```csharp
IDmsElement element = dms.GetElement("MyElement");
var column = element.GetTable(1000).GetColumn<string>(1002);

void OnChange(CellValueChange<string> change)
{
    Log($"Cell changed to: {change.Value}");
}

column.StartValueMonitor("primaryKey", protocol, OnChange, includeCurrentValues: true);
```

## Monitors that support subscribing to all objects

The following monitors can be started without specifying a target, meaning they subscribe to all objects of that type across the DMS:

- ElementAlarmLevelMonitor
- ElementNameMonitor
- ElementStateMonitor
- ServiceAlarmLevelMonitor
- ServiceStateMonitor
- ViewAlarmLevelMonitor
- ViewStateMonitor

When you start one of these monitors without a target, whether you receive current values is **not deterministic**. You may or may not receive them depending on internal timing, so your implementation must account for both cases.
