---
uid: MaintenanceSettings.Aggregation.Source-ignoreExceptionValues
---

# ignoreExceptionValues attribute

If this attribute is set to "true", all aggregation rules in the DataMiner System will by default ignore parameter exception values. If the attribute is set to "false" or if it is not specified, by default exception values will be taken into account.

## Content Type

boolean

## Parents

[Source](xref:MaintenanceSettings.Aggregation.Source)

## Remarks

> [!NOTE]
> This setting can also be configured on rule level instead of system level, in which case the rule-level configuration takes priority. See [Aggregation](xref:Aggregation).

## Example

```xml
<MaintenanceSettings>
  ...
  <Aggregation>
    <Source ignoreExceptionValues="true"></Source>
  </Aggregation>
  ...
</MaintenanceSettings>
```