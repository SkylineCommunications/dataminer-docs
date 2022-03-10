---
uid: Protocol.Params.Param.Display.ParametersView.Parameters.Parameter
---

# Parameter element

If you use the Protocol.Params.Param.Display.ParametersView tag to display a parameter as a chart, then add a Parameter tag inside the Protocol.Params.Param.Display.ParametersView.Parameters tag for every parameter holding a value to be displayed.

## Parent

[Parameters](xref:Protocol.Params.Param.Display.ParametersView.Parameters)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:Protocol.Params.Param.Display.ParametersView.Parameters.Parameter-id)|[TypeParamId](xref:Protocol-TypeParamId)|Yes|Specifies the ID of the parameter.|
|[options](xref:Protocol.Params.Param.Display.ParametersView.Parameters.Parameter-options)|string||*Not yet implemented.*|
|[tableIndex](xref:Protocol.Params.Param.Display.ParametersView.Parameters.Parameter-tableIndex)|string||Specifies the row index (in case the “id” attribute refers to a table parameter).|

## Remarks

For an example, see [ParametersView](xref:Protocol.Params.Param.Display.ParametersView)

> [!NOTE]
> Only specify parameters of type “double”.




