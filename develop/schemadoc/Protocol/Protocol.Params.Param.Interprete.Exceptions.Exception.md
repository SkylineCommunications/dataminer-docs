---
uid: Protocol.Params.Param.Interprete.Exceptions.Exception
---

# Exception element

Defines an exception for an exception value you want to intercept of which the Interprete.Type is identical to that of the parameter in question..

## Parent

[Exceptions](xref:Protocol.Params.Param.Interprete.Exceptions)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:Protocol.Params.Param.Interprete.Exceptions.Exception-id)|unsignedInt|Yes|Specifies the unique ID of the exception.|
|[value](xref:Protocol.Params.Param.Interprete.Exceptions.Exception-value)|string|Yes|Specifies the incoming text or numeric value that you want to match with an exception value.|

## Children

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Display](xref:Protocol.Params.Param.Interprete.Exceptions.Exception.Display)||Specifies the text that has to be displayed when the incoming value matches the contents of the value attribute of /Protocol/Params/Param/Interprete/Exceptions/Exception.|
|&nbsp;&nbsp;[Value](xref:Protocol.Params.Param.Interprete.Exceptions.Exception.Value)||Specifies the new value to which you want to internally map the incoming exception value specified in the value attribute of the /Protocol/Params/Param/Interprete/Exceptions/Exception element.|

## Remarks

See the following example:

```xml
<Exceptions>
	<Exception id="1" value="9999">
		<Display state="disabled">Upper Limit</Display>
		<Value>-1</Value>
	</Exception>
</Exceptions>
```

In the value attribute of the Exception tag, enter the incoming text or numeric value that you want to match
with an exception value.

In the Exception.Value tag, specify the new value to which you want to internally map the incoming exception value specified in the value attribute of the Exception tag. This new value will be stored in the alarm and trend database, and will be used to refer to the exception.

> [!NOTE]
>
> - Make sure that the value specified in the Exception.Value tag is out of the expected, normal value range. If not, this “normal” value will be displayed as an exception value and will generate alarms if exception values are monitored.
> - Performing protocol.GetParameter in a QAction always returns the text or numeric value as it was originally received.

### Exceptions on write parameters

Do not use Exception tags to add exceptions to write parameters. To do so, use Measurement.Discreets.Discreet tags instead.

- For analog, number and string write parameters, you do not need to set the state attribute of the Discreet.Display tag to “disabled” if you want to display a check box with the exception.
- For discreet parameters, you need to set the state attribute of the Discreet.Display tag to “disabled” if you want to display a check box with the exception.

> [!NOTE]
> If you use Discreet tags to define multiple exceptions for a particular write parameter, those exceptions will be displayed in a drop-down box.

### Exception values with decimals

When using an exception value with a decimal, also add the Decimals tag in the Display tag. Otherwise the decimals of the exception value will be ignored and get triggered on the wrong value.

Example:

```xml
<Interprete>
	<Exceptions>
		<Exception id="1" value="0.5">
			<Display>NA</Display>
			<Value>0.5</Value>
		</Exception>
	</Exceptions>
	<Decimals>6</Decimals>
...
```
