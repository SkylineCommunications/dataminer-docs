---
uid: Skyline_DataMiner_Core_DataMinerSystem_Range_1.2
---

# Skyline DataMiner Core DataMinerSystem Range 1.2

> [!NOTE]
> Range 1.2.x.x is supported as from **DataMiner 10.4.0**.

### 1.2.0.1

#### Breaking Change - Monitors now require includeCurrentValues parameter [ID 45095]

The `StartValueMonitor` methods on `IDmsStandaloneParameter`, `IDmsColumn` (cell), `IDmsColumn` (column), and `IDmsTable` now require an explicit `includeCurrentValues` boolean parameter.

Previously, behavior was inconsistent: some monitors (e.g., on a table cell) included current values by default, while others (e.g., on a complete table) did not. This parameter makes the behavior explicit and consistent across all value monitor types.

> [!IMPORTANT]
> This is a **breaking change**. Existing code calling `StartValueMonitor` without the `includeCurrentValues` argument will no longer compile and must be updated.

Pass `true` to receive the current parameter value immediately when the monitor starts, or `false` to only receive future changes.

> [!NOTE]
> When `includeCurrentValues` is set to `true` and the monitored table is a **partial table**, only the first page of the table will be included in the initial data. Changes to other pages will still trigger the `onChange` callback, but those pages will not be part of the initial snapshot.

Example usage for a table cell:

```csharp
IDmsElement element = dms.GetElement("MyElement");
var column = element.GetTable(1000).GetColumn<string>(1002);

void OnChange(CellValueChange<string> change)
{
    Log($"Cell changed to: {change.Value}");
}

column.StartValueMonitor("primaryKey", protocol, OnChange, includeCurrentValues: true);
```
