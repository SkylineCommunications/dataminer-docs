---
uid: Protocol.Params.Param.Display.Steps
---

# Steps element

Defines the step size of a write parameter.

## Type

decimal

## Parent

[Display](xref:Protocol.Params.Param.Display)

## Remarks

For example, if a parameter has a minimum of -3 and a maximum of 18, and if the valid values for this parameter are -3, 0, 3, 6, 9, 12, 15 and 18, then you should set the minimum and maximum values in the Protocol.Params.Param.Display.Range tag, and the step value (in this case “3”) in the Protocol.Params.Param.Display.Steps tag. On the web interface, the parameter will then be represented by a control that allows the value to be adjusted with a step size of 3.

> [!NOTE]
> You can also use decimal numbers. In that case, use a period as the decimal separator.

## Examples

```xml
<Steps>3</Steps>
<Steps>0.5</Steps>

```
