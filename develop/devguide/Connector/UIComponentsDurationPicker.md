---
metadata_version: 1
uid: UIComponentsDurationPicker
description: "Describe the DataMiner connector development topic Duration picker, including its purpose, behavior, implementation guidance, and relevant constraints."
area: develop
content_type: conceptual
authority: unknown
authority_source: unknown
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# Duration picker

Allows the user to select a duration.

```xml
<Param id="271" setter="true">
  <Name>EventDuration</Name>
  <Description>Event Duration</Description>
  <Type>write</Type>
  <Interprete>
    <RawType>numeric text</RawType>
    <Type>double</Type>
    <LengthType>next param</LengthType>
  </Interprete>
  <Display>
    <RTDisplay>true</RTDisplay>
  </Display>
  <Measurement>
    <Type options="time">number</Type>
  </Measurement>
</Param>
```

![DataMiner Cube duration picker](~/develop/images/uidurationpicker.png)

## See also

DataMiner Protocol Markup Language:

- [Protocol.Params.Param.Measurement.Type options: time](xref:Protocol.Params.Param.Measurement.Type-options#options-for-measurement-type-number)
