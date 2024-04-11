---
uid: ConnectorsRequiredTagsChainsAndFields
---

# Chains and Fields

Within the EPM Manager connector, you will find the `<Chains>` tag that contains a number of `<Chain>` children. Each `<Chain>` represents a topology view visible in DataMiner.

## Example

```xml
<Chains>
    <Chain name="Customer Topology">
        <Field name="Customer" options="displayInFilter;showCPEChilds;ignoreEmptyFilterValues;tabs:3500-KPI;details:3500;ShowBubbleupAndInstanceAlarmLevel" pid="3502"/>
        <Field name="Device" options="displayInFilter;ignoreEmptyFilterValues;tabs:2500-KPI;details:2500;ShowBubbleupAndInstanceAlarmLevel" pid="2501"/>
    </Chain>
</Chains>
```

## Fields

Within a `<Chain>`, you can define multiple Fields. Each field represents a level from the respective topology.

```xml
<Field name="Customer" options="displayInFilter;showCPEChilds;ignoreEmptyFilterValues;tabs:3500-KPI;details:3500;ShowBubbleupAndInstanceAlarmLevel" pid="3502"/>
```

### Attributes

| Attribute | Description                                                                                                                                     |
|-----------|-------------------------------------------------------------------------------------------------------------------------------------------------|
| `name`    | Specifies the name of the field representing the level.                                                                                        |
| `options` | Used to define the topology options.                                                                                                           |
| `pid`     | Specifies the ID of the parameter to which the level is linked. The view table column should be used.                                                                                 |

#### Options

In the previous example the following options were used:

| Option                               | Description                                                                                                                                                                 |
|--------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| `displayInFilter`                   | Display the field in the filter column on the left side of the EPM UI.                                                                                                      |
| `ignoreEmptyFilterValues`           | Excludes empty values from the filter drop-down lists of the topology levels.                                                                                                 |
| `tab`                                | Display one or more links in the block and next to the filter corresponding to the field.                                                                                    |
| `detail`                             | Specify tables that will be displayed in the details pane with a filter on the selection.                                                                                    |
| `ShowBubbleupAndInstanceAlarmLevel` | Allow two alarm indications on every object: the alarm state of the object and the alarm state of all the objects below.                                                     |

> [!NOTE]
> For more options, refer to the [options attribute](xref:Protocol.Chains.Chain.Field-options)
