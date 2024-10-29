---
uid: Protocol.Params.Param.Display.Positions
---

# Positions element

Defines the position of the parameter on the user interface.

## Parent

[Display](xref:Protocol.Params.Param.Display)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Position](xref:Protocol.Params.Param.Display.Positions.Position)|[0, *]|Defines the location of the parameter on the user interface.|

## Remarks

> [!NOTE]
>
> - As a parameter can be displayed on several locations on the user interface, the Protocol.Params.Param.Display.Positions tag can contain more than one Protocol.Params.Param.Display.Positions.Position tags.
> - If a table parameter needs to be displayed on a Visio page using a *ParameterControl* shape, it must have a position tag (as it must be shown on a connector page). Otherwise, the table will not be displayed in Visio. No position tag is needed when only a single value is to be displayed using the [Param:elementId,columnId,key] placeholder.

## Examples

```xml
<Positions>
   <Position>
   <Page>General</Page>
   <Row>0</Row>
   <Column>1</Column>
   </Position>
</Positions>
```

## See also

[Visualizing UI components](xref:UIComponentsVisualization)
