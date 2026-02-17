---
uid: UIComponentsToggleButton
---

# Toggle button

A toggle button allows the user to choose one from two predefined options.

To define a toggle button, set Type to "togglebutton", and provide a discrete list with the two available options.

```xml
<Param id="200">
  <Name>PollingToggleButton</Name>
  <Description>Polling</Description>
  <Type>read</Type>
  <Interprete>
    <RawType>numeric text</RawType>
    <Type>double</Type>
    <LengthType>next param</LengthType>
  </Interprete>
  <Display>
    <RTDisplay>true</RTDisplay>
  </Display>
  <Measurement>
    <Type>discreet</Type>
    <Discreets>
      <Discreet>
        <Display>Disabled</Display>
        <Value>0</Value>
      </Discreet>
      <Discreet>
        <Display>Enabled</Display>
        <Value>1</Value>
      </Discreet>
    </Discreets>
  </Measurement>
</Param>
<Param id="201" setter="true">
  <Name>PollingToggleButton</Name>
  <Description>Polling</Description>
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
    <Type>togglebutton</Type>
    <Discreets>
      <Discreet>
        <Display>Disabled</Display>
        <Value>0</Value>
      </Discreet>
      <Discreet>
        <Display>Enabled</Display>
        <Value>1</Value>
      </Discreet>
    </Discreets>
  </Measurement>
</Param>
```

![DataMiner Cube toggle button](~/develop/images/uitogglebutton.png)

> [!NOTE]
> A toggle button is typically preferred over a dropdown list containing two entries when it is clear what the second entry will be from reading the first entry (e.g., On/Off, Enabled/Disabled, etc.).

## See also

DataMiner Protocol Markup Language:

- [Protocol.Params.Param.Measurement.Type: togglebutton](xref:Protocol.Params.Param.Measurement.Type#togglebutton)
