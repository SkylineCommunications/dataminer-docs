---
uid: UIComponentsSlider
---

# Slider

A slider allows the user to set a value by moving an indicator.

## Creating a slider

To define a slider, provide a numeric range using the Range tag.

```xml
<Param id="160">
  <Name>AudioVolume</Name>
  <Description>Audio Volume</Description>
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
    <Type>number</Type>
  </Measurement>
</Param>
<Param id="161" setter="true">
  <Name>AudioVolume</Name>
  <Description>Audio Volume</Description>
  <Type>write</Type>
  <Interprete>
    <RawType>numeric text</RawType>
    <Type>double</Type>
    <LengthType>next param</LengthType>
  </Interprete>
  <Display>
    <RTDisplay>true</RTDisplay>
    <Units>%</Units>
    <Steps>5</Steps>
    <Range>
      <Low>0</Low>
      <High>100</High>
    </Range>
  </Display>
  <Measurement>
    <Type>number</Type>
  </Measurement>
</Param>
```

![alt text](../../images/uislider.png "DataMiner Cube slider")

> [!NOTE]
> The example above also illustrates the usage of a unit (via the Units tag) and a step size (via the Steps tag).

## Creating a slider with a check box

The following example illustrates how you can create a slider with a check box.

```xml
<Param id="170">
  <Name>AudioVolume</Name>
  <Description>Audio Volume</Description>
  <Type>read</Type>
  <Interprete>
    <RawType>numeric text</RawType>
    <Type>double</Type>
    <LengthType>next param</LengthType>
    <Exceptions>
      <Exception id="1" value="0">
        <Display state="disabled">Muted</Display>
        <Value>0</Value>
      </Exception>
    </Exceptions>
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
    <Type>number</Type>
  </Measurement>
</Param>
<Param id="171" setter="true">
  <Name>AudioVolume</Name>
  <Description>Audio Volume</Description>
  <Type>write</Type>
  <Interprete>
    <RawType>numeric text</RawType>
    <Type>double</Type>
    <LengthType>next param</LengthType>
  </Interprete>
  <Display>
    <RTDisplay>true</RTDisplay>
    <Units>%</Units>
    <Steps>5</Steps>
    <Range>
      <Low>0</Low>
      <High>100</High>
    </Range>
  </Display>
  <Measurement>
    <Type>number</Type>
    <Discreets>
      <Discreet>
        <Display>Mute</Display>
        <Value>0</Value>
      </Discreet>
    </Discreets>
  </Measurement>
</Param>
```

![alt text](../../images/uisliderwithcheckbox.png "DataMiner Cube slider with check box")

## Creating a slider with a drop-down List

If you provide multiple discrete entries with state "disabled", a drop-down list is shown, as illustrated in the following example:

```xml
<Param id="174">
  <Name>throughput</Name>
  <Description>Throughput</Description>
  <Type>read</Type>
  <Interprete>
    <RawType>numeric text</RawType>
    <Type>double</Type>
    <LengthType>next param</LengthType>
    <Exceptions>
      <Exception id="1" value="0">
        <Display state="disabled">None</Display>
        <Value>0</Value>
      </Exception>
      <Exception id="2" value="100">
        <Display state="disabled">Maximum</Display>
        <Value>100</Value>
      </Exception>
    </Exceptions>
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
    <Type>number</Type>
  </Measurement>
</Param>
<Param id="175" setter="true">
  <Name>throughput</Name>
  <Description>Throughput</Description>
  <Type>write</Type>
  <Interprete>
    <RawType>numeric text</RawType>
    <Type>double</Type>
    <LengthType>next param</LengthType>
  </Interprete>
  <Display>
    <RTDisplay>true</RTDisplay>
    <Units>%</Units>
    <Steps>5</Steps>
    <Range>
      <Low>0</Low>
      <High>100</High>
    </Range>
  </Display>
  <Measurement>
    <Type>number</Type>
    <Discreets dependencyId="176">
      <Discreet>
        <Display state="disabled">None</Display>
        <Value>0</Value>
      </Discreet>
      <Discreet>
        <Display state="disabled">Maximum</Display>
        <Value>100</Value>
      </Discreet>
    </Discreets>
  </Measurement>
</Param>
```

![alt text](../../images/uisliderwithcheckbox2.png "DataMiner Cube slider with drop-down list")

## See also

DataMiner Protocol Markup Language:

- [Protocol.Params.Param.Measurement.Type: number](xref:Protocol.Params.Param.Measurement.Type#number)
- [Protocol.Params.Param.Display.Range](xref:Protocol.Params.Param.Display.Range)
- [Protocol.Params.Param.Display.Steps](xref:Protocol.Params.Param.Display.Steps)
- [Protocol.Params.Param.Display.Units](xref:Protocol.Params.Param.Display.Units)
