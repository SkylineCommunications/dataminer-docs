---
uid: Protocol.Params.Param.Measurement.Type-options
---

# options attribute

Specifies a number of options.

## Content Type

string

## Parent

[Type](xref:Protocol.Params.Param.Measurement.Type)

## Remarks

In the options attribute, you can specify a number of options (separated by semicolons) depending on the measurement type. 

### Options for measurement type “analog”

Possible options for measurement type “analog”:

#### hscroll

Stretches the analog parameter vertically.

#### vertificationDeviation=

Allows you to specify a deviation on the command to be verified using Command Execution Verification (CEV or Confirm Sets):

```xml
<Type verificationDeviation="0.1">
```

> [!NOTE]
> Command Execution Verification has to be enabled in MaintenanceSettings.xml.

See also: [annalog](xref:Protocol.Params.Param.Measurement.Type#analog)

### Options for measurement type “discreet”

Possible options for measurement type “discreet”:

#### custom=disableWrite:pid=value

With this option you can make a column read-only based on a value of a different column in the same table. It is not possible to change this value at runtime.

Example:

```xml
<Measurement>
    <Type options="custom=disableWrite:102=Moxa serial port 01">discreet</Type>
    <Discreets>
        <Discreet>
            <Display>Up</Display>
            <Value>1</Value>
        </Discreet>
        <Discreet>
            <Display>Down</Display>
            <Value>2</Value>
        </Discreet>
        <Discreet>
            <Display>Testing</Display>
            <Value>3</Value>
        </Discreet>
    </Discreets>
</Measurement>
```

See also: [discreet](xref:Protocol.Params.Param.Measurement.Type#discreet)

### Options for measurement type “matrix”

Possible options for measurement type “matrix”:

#### matrix

With this option, you can set the properties of the matrix (separated by commas).

- **Number Inputs**: Total number of inputs.
- **Number Outputs**: Total number of outputs.
- **COMin**: Minimum number of connections for one output.
- **COMax**: Maximum number of connection for one output.
- **CIMin**: Minimum number of connections for one input.
- **CIMax**: Maximum number of connections for one input.
- **pages**: By default, if you specify “pages”, the inputs and outputs are grouped per 16 ins/outs.

  > [!NOTE]
  > This option is ignored if the number of visible matrix lines is less than 32 x 32.

- **evenSmallPages**: With this option, you can force the matrix to be split up into a number of pages, no matter how many matrix lines are visible.
- **noDisconnectsInBackup**: Some matrices do not support the disconnecting of crosspoints. As a consequence, backup scripts containing disconnects failed. Use the noDisconnectsInBackup option to omit disconnects from matrix backup scripts. Note that this option should always be the 8th matrix option.

Example:

```xml
<Type link="ports.xml" options="matrix=256,256,1,1,0,256">matrix</Type>
```

or:

```xml
<Param id="16" backup="true">
    <Name>matrix 64*64</Name>
    <Measurement>
        <!-- Sequence for matrix options COMin/COMax/CIMin/CIMax -->
        <Type options="matrix=64,64,0,64,0,64,pages,noDisconnectsInBackup"link="port64.xml">matrix</Type>
        <Discreets>
        ...
```

See also:

- [matrix](xref:Protocol.Params.Param.Measurement.Type#matrix)
- [matrix](xref:UIComponentsMatrix)

### Options for measurement type “number”

Possible options for measurement type “number”:

#### time

The parameter will be displayed as a time duration. The value represents the total number of seconds.

If, for example, you specify the following, the value “123.456” will be displayed as “02m 03s”. Decimals are ignored.

```xml
<Type options="time">number</Type>
```

An extra “timeofday” option can be added to display the value as the time-of-day in local format:

```xml
<Type options="time;timeofday">number</Type>
```

Internally, it works in the same way as the normal time option. The value is stored as either the total number of seconds or the total number of minutes (not an OLE Automation format).

*Feature introduced in DataMiner 8.0.3 (RN 6046).*

See also:

- [Duration picker](xref:UIComponentsDurationPicker)

#### time:minute

The parameter value represents the total number of minutes. The client displays decimal values as seconds.

If, for example, you specify the following, the value “123.456” will be displayed as “02h 03m 27s”.

```xml
<Type options="time:minute;timeofday">number</Type>
```

Read parameters with options=”time:minute” will not display seconds if their value is zero. 

*Feature introduced in DataMiner 8.0.5 (RN 5868).*

#### time:hour

The parameter value represents the total number of hours. The client displays decimal values as minutes and seconds.

If, for example, you specify the following, the value “123.456” will be displayed as “5 days 03h 27m 21s”.

```xml
<Type options="time:hour">number</Type>
```

> [!NOTE]
> Protocol.Params.Param.Measurement.Discreets cannot be used in combination with this type.

Read parameters with options=”time:hour” will not display seconds if their value is zero, and not display minutes if both minutes and seconds are zero. Feature introduced in DataMiner 8.0.5 (RN 5868).

#### date

The parameter will be displayed as a date. The value represents the total number of seconds. The Interprete.Decimals and Display.Decimals tags of this parameter need to be set to 8 to avoid rounding errors.

Example:

```xml
<Type options="date">number</Type>
```

- For write parameters, only a date (YYYY-MM-DD) needs to be entered.
- For read parameters, only the date in local format will be displayed.

The timestamp is stored internally as an OLE Automation date: a decimal number indicating the total number of days passed since Midnight 1899-12-30. Using the .NET framework, the double value can easily be converted to/from a DateTime type using the methods DateTime.FromOADate(x) and d.ToOADate().

*Feature introduced in DataMiner 8.0.3 (RN 6046).*

#### datetime

The parameter will be displayed as a datetime. The value represents a decimal number indicating the total number of days that have passed since midnight 1899-12-30. The Interprete/Decimals and Display/Decimals tags of this parameter need to be set to 8 to avoid rounding errors.

Example:

```xml
<Type options="datetime">number</Type>
```

- For write parameters, the date (YYYY-MM-DD) and the time (HH:MM:SS) need to be entered.
- For read parameters, both date and time will be displayed.

The timestamp is stored internally as an OLE Automation date: a decimal number indicating the total number of days passed since Midnight 1899-12-30. Using the .NET framework, the double value can easily be converted
to/from a DateTime type using the methods DateTime.FromOADate(x) and d.ToOADate().

*Feature introduced in DataMiner 8.0.3 (RN 6046).*

See also:

- [Datetime picker](xref:UIComponentsDateTimePicker)

#### datetime:minute

The “minute” option can be used to hide the seconds and to only display hours and minutes.

Example:

```xml
<Type options="datetime:minute">number</Type>
```

#### custom=disableWrite:pid=value

With this option you can make a column read-only based on a value of a different column in the same table. It is not possible to change this value at runtime.

Example:

```xml
<Measurement>
    <Type options="custom=disableWrite:102=Moxa serial port 01">number</Type>
    ...
</Measurement>
```

### Options for measurement type “string”

Possible options for measurement type “string”:

|Option|Description|
|--- |--- |
|hscroll|Adds a horizontal scroll bar to the string (mostly used in case of a list).|
|tab|The tab distance (the starting position of the text in the box).|
|fixedfont|Sets the font type of the string to a fixed font.|
|number|If set to true, the string can only contain numbers.|
|password|Use this option to create a password parameter. Every character entered in this parameter will be displayed as “*” (also works for dynamic table cells). When the password is used, the value is encrypted. Note that only in Cube the password option on a Read parameter will not display the value, but hide it.|
|custom=disableWrite:pid=value|With this option you can make a column read-only based on a value of a different column in the same table. It is not possible to change this value at runtime. Example: `custom=disableWrite:102=Moxa serial port 01`|

See also: [string](xref:Protocol.Params.Param.Measurement.Type#string)

### Options for measurement type “table”

Possible options for measurement type “table”:

#### tab

With this option, you can set the properties of the table (separated by commas).

- **columns**: The order of the column parameters.
- **lines**: The number of lines.
- **width**: The width of each column (in pixels).
- **sort**: The way in which columns are interpreted for sorting. You can add a sort order and a priority.

  Example:

  ```
  STRING|ASC|0
  ```

- **filter**: If set to true, a filter is added for the table.

Example:

```xml
<Type options="tab=columns:1|0-2|1-3|2,lines:20,width:50-50-100,sort:INT-INT-STRING,filter:true">table</Type>
```

See also: [table](xref:Protocol.Params.Param.Measurement.Type#table)

### Options for measurement type “title”

Possible options for measurement type “title”:

|Option|Description|
|--- |--- |
|begin|A single horizontal line on the user interface. Short lines go down from both ends of the line. The start of a page section.|
|end|A single horizontal line on the user interface. Short lines go up from both ends of the line. The end of a page section.|
|connect|Connects a “begin” and an “end” title. **NOTE**: This is only required to support the legacy System Display application.|

See also: [title](xref:Protocol.Params.Param.Measurement.Type#title)
