---
uid: UIComponentsAnalog
---

# Analog

Displays the numeric value of a parameter in accordance to the "graphic presentation" settings of the user interface.

Set the Type of the Measurement tag to "analog".

```xml
<Param id="266" trending="false">
  <Name>CPUUsage</Name>
  <Description>CPU Usage</Description>
  <Type>read</Type>
  <Interprete>
    <RawType>numeric text</RawType>
    <Type>double</Type>
    <LengthType>next param</LengthType>
  </Interprete>
  <Display>
    <RTDisplay>true</RTDisplay>
    <Units>%</Units>
    <Range>
      <Low>0</Low>
      <High>100</High>
    </Range>
  </Display>
  <Measurement>
    <Type>analog</Type>
  </Measurement>
</Param>
```

![alt text](../../images/uianalog.png "DataMiner Cube analog")

## See also

DataMiner Protocol Markup Language:

- [Protocol.Params.Param.Measurement.Type@options: analog](xref:Protocol.Params.Param.Measurement.Type-options#options-for-measurement-type-analog)
