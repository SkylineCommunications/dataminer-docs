---
metadata_version: 1
uid: Protocol.Params.Param.Measurement.Discreets.Discreet.Value
description: "Learn how the Value element defines a value that triggers a discreet label or button action when it matches a parameter in a DataMiner connector protocol."
---

# Value element

Specifies when the discrete value has to be displayed.<!-- RN 5428 -->

## Type

string

## Parent

[Discreet](xref:Protocol.Params.Param.Measurement.Discreets.Discreet)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[location](xref:Protocol.Params.Param.Measurement.Discreets.Discreet.Value-location)|string||If type is "dll", the location of the DLL file.|
|[type](xref:Protocol.Params.Param.Measurement.Discreets.Discreet.Value-type)|[EnumDiscreteValue](xref:Protocol-EnumDiscreteValue)||Specifies the type.|

## Remarks

If the value of the parameter matches the value in this tag, the contents of the Protocol.Params.Param.Measurement.Discreets.Discreet.Display tag will be displayed.

When defining a button parameter, you can also use placeholders in the Value tag referring to Visio session variables. That way, when the button is clicked, the current value of one or more Visio session variables will be inserted in the value of the button parameter.

## Examples

In the following example, when you click the button parameter at a moment when the session variable MyVar contains "500", then the button parameter will get the value "someFixedText500":

```xml
<Discreets>
    <Discreet>
        <Display>Off</Display>
        <Value>someFixedText[Var:MyVar]</Value>
    </Discreet>
    ...
<Discreets>
```
