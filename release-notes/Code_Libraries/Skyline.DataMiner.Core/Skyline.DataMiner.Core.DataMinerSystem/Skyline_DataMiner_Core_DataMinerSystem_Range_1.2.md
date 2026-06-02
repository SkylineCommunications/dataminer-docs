---
uid: Skyline_DataMiner_Core_DataMinerSystem_Range_1.2
---

# Skyline DataMiner Core DataMinerSystem Range 1.2

> [!NOTE]
> Range 1.2.x.x is supported as from **DataMiner 10.4.0**.

### 1.2.0.2

#### Fix - Property IDmsElement.Connections was null or empty instead of containing the expected connections [ID 45627]

An issue has been resolved where `DmsElement.Connections` would be null or empty instead of containing the expected connections.

#### Deprecation - ILocalElement and ILocalTable interfaces marked obsolete [ID 45608]

The `ILocalElement` and `ILocalTable` interfaces have been marked obsolete. Because `ILocalElement` inherited from `IDmsElement`, SLNet-based methods and SLProtocol-based methods were mixed on the same interface, giving the false impression that all methods were equally efficient. In practice, any method going through SLNet has a significantly larger performance impact than direct interaction via SLProtocol.

When interacting with a local element, the SLProtocol interface should be used directly instead. This can be done by calling a method on the `SLProtocol` or `SLProtocolExt` interface, or by using a method provided by the [Skyline.DataMiner.Utils.Protocol.Extension](https://www.nuget.org/packages/Skyline.DataMiner.Utils.Protocol.Extension) NuGet package.

#### Fix - Cyclic alarm template group caused an infinite loop [ID 45606]

When retrieving an alarm template group that was cyclic, an infinite loop would occur. This issue has now been resolved. Instead of entering an infinite loop, the code will now detect cyclic alarm template groups and throw a `DmsException`, providing clear feedback about the configuration issue.

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
