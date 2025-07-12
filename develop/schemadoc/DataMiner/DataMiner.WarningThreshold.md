---
uid: DataMiner.WarningThreshold
---

# WarningThreshold element

Configures when messages are generated that indicate a DataMiner Agent is approaching the limit of its element license. By default, warning messages are generated.

## Content Type

decimal

## Parents

[DataMiner](xref:DataMiner)

## Remarks

When a DataMiner Agent is approaching the limit of its element license, by default, warning messages are generated. Using the **WarningThreshold** tag, it is possible to customize when these messages are generated.

The following values can be configured in this tag:

- A value lower than or equal to 0: The option will have no effect.

- A value between 0 and 1: The value represents the percentage of active elements compared to the total number of allowed elements. Once this percentage is reached, warnings will be generated. However, license limit warnings are never generated if the DataMiner Agent is below 80% of its total capacity, even if a value lower than 0.8 is configured here.

- A value higher than 1: No warnings will be generated.

For example, if you specify the following, warnings will only be generated once the DataMiner Agent is at 99% of its capacity:

```xml
<WarningThreshold>0.99\</WarningThreshold>
```
