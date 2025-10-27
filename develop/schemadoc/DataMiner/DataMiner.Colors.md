---
uid: DataMiner.Colors
---

# Colors element

Specifies the colors assigned to each of the alarm levels.

See [Changing the default alarm colors](xref:Changing_the_default_alarm_colors).

## Parents

[DataMiner](xref:DataMiner)

## Children

| Name | Occurrences | Description |
| --- | --- | --- |
| [Color](xref:DataMiner.Colors.Color) | [0, *] | Specifies a color as a set of RGB values. |

## Example

In the following example, the default alarm colors have been configured:

```xml
<DataMiner>
  <Colors>
    <Color type="normal" value="22,198,12"/>
    <Color type="warning" value="59,120,255"/>
    <Color type="minor" value="97,214,214"/>
    <Color type="major" value="245,210,40"/>
    <Color type="critical" value="240,50,65"/>
    <Color type="notMonitored" value="204,204,204"/>
    <Color type="initial" value="242,242,242"/>
    <Color type="timeout" value="255,155,15"/>
    <Color type="masked" value="136,23,152"/>
    <Color type="error" value="204,204,204"/>
    <Color type="notice" value="204,204,204"/>
    <Color type="information" value="204,204,204"/>
  </Colors>
</DataMiner>
```
