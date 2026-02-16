---
uid: Protocol.Params.Param.Measurement.Discreets.Discreet.Value-type
---

# type attribute

Specifies the type.

## Content Type

[EnumDiscreteValue](xref:Protocol-EnumDiscreteValue)

## Parent

[Value](xref:Protocol.Params.Param.Measurement.Discreets.Discreet.Value)

## Remarks

### dll

This type makes it possible to run a DLL at the click of a button.

Example:

```xml
<Discreet>
    <Display>Delete outage...</Display>
    <Value type="dll" location="protocol">SLWfmControls\SLSLAOutageConfiguration/Skyline.DataMiner.WFM.SLSLAOutageConfiguration.Starter/StartDeleteOutageWizard</Value>
</Discreet>
```

### open

This type is used for buttons that open a URL, an element card, a view card or a service card.

- The discreet value should contain the link (ViewID, DmaID/ElementID, DmaID/ServiceID, name, URL).
- When used in tables, buttons of type "Open" can contain references to other columns.

In the following example, when the button is clicked, the value of parameter 112 will be triggered to open. [Value:ColId] will then be replaced at runtime by the value of the given column for the same row:

  ```xml
  <Discreet>
      <Display>Open Var1Link</Display>
      <Value type="Open">[Value:112]</Value>
  </Discreet>
  ```

- It is possible to bind an action to a button to open a specific spectrum analyzer element. Optionally, you can also define a measurement point and/or preset for the element. Single buttons, buttons inside a table and buttons in an EPM interface are all supported.<!-- RN 13458, RN 13533 -->

  To create such a button, in the Protocol.Params.Param.Measurement.Discreets.Discreet.Value tag, use the attribute type="Open" and specify a value using the following syntax:

  ```xml
  element=[SPECTRUM ELEMENT NAME OR ID]&measpt=[MEASUREMENTPOINTID]&preset=[PRESET NAME]
  ```

For example:

  ```xml
  <Discreet>
      <Display>View Spectrum</Display>
        <Value type="Open">element=MySpectrumElement&amp;measpt=1&amp;preset=myPreset (Public)</Value>
  </Discreet>
  ```

In the Value tag, it is also possible to use a placeholder for a table cell that contains the required string value. For example:

  ```xml
  <Discreet>
    <Display>View Spectrum</Display>
    <Value type="Open">[Value:101]</Value>
  </Discreet>
  ```

> [!NOTE]
>
> - To link to a public preset, it is important that (Public) is added after the preset name.
> - To add multiple measurement points, use a pipe character as a separator, e.g., 1|4.
> - Private presets are not supported in spectrum element links from Visio or EPM.

The following example is an excerpt from an EPM protocol. In the example, parameter 1610 has to contain a string like the following one:

```xml
element=Spectrum%20Analyzer%20DS&amp;measpt=164&amp;preset=inline:freqCenter:603000000%3bfreqSpan:6000000%3brefLevel:0%3brefScale:10
```

```xml
<Measurement>
    <Type width="110">button</Type>
    <Discreets>
        <Discreet>
            <Display>View Spectrum</Display>
            <Value type="open">[Value:1610]</Value>
        </Discreet>
    </Discreets>
</Measurement>
```

### setVar

This type is used for buttons that set one or more session variables (which can be used in Visio drawings) to a particular value.

When used in tables, buttons of type "setVar" can contain references to other columns.

The session variable names and values are defined in the discreet value.

In the following example, when the button is clicked, the value of parameter 1 will be set in variable Var1 and the value of parameter 602 will be set in variable Var2:

```xml
<Discreet>
    <Display>Button Text</Display>
    <Value type="setVar">Var1:[Value:1]|Var2:[Value:602]</Value>
</Discreet>
```

### setCardVar

Sets the Visio session variable, limited to the current card, with the specified name to the specified value.<!-- RN 7912 -->

Example

```xml
<Discreet>
    <Display>Set CardVar</Display>
    <Value type="setCardVar">CardVar1:[Param:2]</Value>
</Discreet>
```

### setPageVar

Sets the Visio session variable, limited to the current page, with the specified name to the specified value.<!-- RN 7912 -->

Example

```xml
<Discreet>
    <Display>Set PageVar</Display>
    <Value type="setPageVar">PageVar1:[Param:2]</Value>
</Discreet>
```
