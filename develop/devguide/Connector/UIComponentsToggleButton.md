---
uid: UIComponentsToggleButton
description: Learn how to configure a DataMiner connector toggle button with paired read and write parameters and two discrete values.
---

# Toggle button

A toggle button allows the user to choose one from two predefined options.

A toggle button is implemented as a read/write parameter pair:

- The read parameter reports the current state. Set its measurement type to "discreet".
- The write parameter changes the state. Set its measurement type to "togglebutton".

Define the same two discrete values on both parameters. DataMiner uses the value reported by the read parameter to determine which of the two values to send when the user clicks the toggle button. For example, when the read parameter reports "Disabled", clicking the toggle button will send "Enabled".

> [!IMPORTANT]
> A measurement type of "togglebutton" is only valid for the write parameter. The associated read parameter is required and must use the measurement type "discreet". A write parameter configured as a toggle button cannot determine the next value to send without its read parameter.

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
