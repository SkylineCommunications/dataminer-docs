---
uid: Protocol.Params.Param.Measurement.Type
---

# Type element

Specifies how the parameter has to be displayed on the user interface.

## Type

[EnumParamMeasurementType](xref:Protocol-EnumParamMeasurementType)

## Parent

[Measurement](xref:Protocol.Params.Param.Measurement)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[case](xref:Protocol.Params.Param.Measurement.Type-case)|[EnumParamMeasurementTypeCase](xref:Protocol-EnumParamMeasurementTypeCase)||Specifies the casing to be used.|
|[continuous](xref:Protocol.Params.Param.Measurement.Type-continuous)|[EnumOnOff](xref:Protocol-EnumOnOff)||*** No documentation available yet. ***|
|[hex](xref:Protocol.Params.Param.Measurement.Type-hex)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||Specifies whether the parameter value should be displayed as a hexadecimal number.|
|[lines](xref:Protocol.Params.Param.Measurement.Type-lines)|unsignedInt||Specifies the number of lines that will be displayed.|
|[link](xref:Protocol.Params.Param.Measurement.Type-link)|string||Specifies the file name in which the input and output labels are stored.|
|[number](xref:Protocol.Params.Param.Measurement.Type-number)|string||*** No documentation available yet ***|
|[options](xref:Protocol.Params.Param.Measurement.Type-options)|string||Specifies a number of options.|
|[scientificNotation](xref:Protocol.Params.Param.Measurement.Type-scientificNotation)|[EnumScientificNotation](xref:Protocol-EnumScientificNotation)||Specifies the scientific notation to be used.|
|[verificationDeviation](xref:Protocol.Params.Param.Measurement.Type-verificationDeviation)|decimal||Specifies a deviation on analog parameters.|
|[width](xref:Protocol.Params.Param.Measurement.Type-width)|unsignedInt||Specifies the width of a (page) button.|

## Remarks

Contains one of the following values:

### analog

The numeric value of the parameter will be displayed in accordance to the “graphic presentation” settings on the user interface:

- LED bar
- Color tube
- Oscilloscope
- Text only

In this case, the accompanying Protocol.Params.Param.Measurement.Discreets tag can be used to provide additional conditions, but ONLY with parameters of the type WRITE.

See also:

- [Analog](xref:UIComponentsAnalog)
- [Options for measurement type “analog”](xref:Protocol.Params.Param.Measurement.Type-options#options-for-measurement-type-analog)

### button

Only applicable for parameters of type "write".

When type is “button”, the parameter will be visualized as a button that, when clicked, will cause an action to be performed.

In this case, the accompanying Protocol.Params.Param.Measurement.Discreets tag has to be used to define the label of the button (Discreet/Display) and the value to be set (Discreet/Value). Multiple discrete entries can be defined to show multiple buttons.

From DataMiner version 7.5 onwards, a button can be used in a column. When you define multiple discreets, multiple buttons will be added in the same column. The same options as in a single button discreet can be used.

Example:

```xml
<Discreet>
    <Display>...</Display>
    <Value type="setvar">...</Value>
</Discreet>
<Discreet>
    <Display>...</Display>
    <Value type="open">...</Value>
</Discreet>
```

See also:

- [Button](xref:UIComponentsButton)

### chart

The parameter will be displayed as a chart.

- [Chart](xref:UIComponentsChart)

### digital threshold

Obsolete. Was used to interpret an analog signal as a digital signal by assigning a threshold value.

### discreet

Can be used to map discrete parameter values to a more meaningful display text.

In case of a parameter of type “read”, this measurement type allows you to display a user-defined string when the parameter contains a certain value.

In case of a parameter of type “write”, this measurement type allows you to display a drop-down box with predefined strings masking underlying values. In this case, the accompanying Protocol.Params.Param.Measurement.Discreets tag has to be used to define the various discreet values.

For example:

```xml
<Measurement>
    <Type>discreet</Type>
    <Discreets>
        <Discreet>
            <Display>Manual</Display>
            <Value>0</Value>
        </Discreet>
        <Discreet>
            <Display>Automatic</Display>
            <Value>1</Value>
        </Discreet>
    </Discreets>
</Measurement>
```

See also:

- [Options for measurement type “discreet”](xref:Protocol.Params.Param.Measurement.Type-options#options-for-measurement-type-discreet)
- [Drop-down list](xref:UIComponentsDropDownList)
- [Protocol.Params.Param.Measurement.Discreets](xref:Protocol.Params.Param.Measurement.Discreets)

### matrix

Used for visualizing a matrix. Only applicable for parameters of type “array” or “write”.

See also:

- [Options for measurement type “matrix”](xref:Protocol.Params.Param.Measurement.Type-options#options-for-measurement-type-matrix)
- [Matrix](xref:UIComponentsMatrix)

### number

The parameter will be displayed as a number.

See also:

- [Options for measurement type “number”](xref:Protocol.Params.Param.Measurement.Type-options#options-for-measurement-type-number)

### pagebutton

Only applicable for parameters of type "write".

When measurement type is “pagebutton”, the parameter will be visualized as a button giving access to a popup page.

In this case, the accompanying Protocol.Params.Param.Measurement.Discreets tag has to be used to define the label of the button. Multiple Protocol.Params.Param.Measurement.Discreets.Discreet tags can be specified to allow the parameter to have multiple page buttons, meaning to allow multiple page buttons on the same row and column.

Labels of page buttons must end with ”...”. So, inside a Protocol.Params.Param. Measurement.Discreets.Discreet tag, the Protocol.Params.Param.Measurement.Discreets.Discreet.Display tag must contain a button label ending with ”...”.

See also:

- [Page button](xref:UIComponentsPageButton)

### progress

The parameter will be displayed as a progress bar.

Progress bars are often used to indicate progress when a list is loaded.

The Param.Display.Range tag is used to define the range of the progress bar. If no range has been defined, a default 0-100 range will be used.

> [!NOTE]
> The measurement type "progress" is only used with parameters of type "read".

See also:

- [Progress bar](xref:UIComponentsProgressBar)

### string

The parameter will be displayed as a string.

Example:

```xml
<Type lines="3" case="upper" options="hscroll;tab=100;fixedfont">string</Type>
```

See also:

- [Options for measurement type “string”](xref:Protocol.Params.Param.Measurement.Type-options#options-for-measurement-type-string)

### table

Only applicable to parameters of type “array”, which will, in this case, be displayed as a table.

See also

- [Options for measurement type “table”](xref:Protocol.Params.Param.Measurement.Type-options#options-for-measurement-type-table)

### title

Allows you to display lines and boxes.

Example:

```xml
<Type options="end">title</Type>
```

> [!NOTE]
>
> - Protocol.Params.Param.Measurement.Discreets cannot be used in combination with this type.
> - The measurement type "title" is only used with parameters of type "read".
> - To include support for the legacy System Display application, add the “connect” option (`options="end;connect"`).

See also:

- [Options for measurement type “title”](xref:Protocol.Params.Param.Measurement.Type-options#options-for-measurement-type-title)
- [Title](xref:UIComponentsTitle)
- [Group box](xref:UIComponentsGroupBox)

### togglebutton

When a parameter of type “write” includes only two discreet values, it can be represented by a toggle button. When the “read” parameter associated with the “write” parameter contains the first discreet value, the second discreet value will be used in the set command when the toggle button is clicked.

See also:

- [Toggle button](xref:UIComponentsToggleButton)
