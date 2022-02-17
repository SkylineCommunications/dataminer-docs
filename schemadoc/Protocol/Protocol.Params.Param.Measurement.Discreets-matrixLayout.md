---
uid: Protocol.Params.Param.Measurement.Discreets-matrixLayout
---

# matrixLayout attribute

Configures the layout of the matrix.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|InputLeftOutputTop|Displays the inputs on the left and the outputs at the top. (This is the default configuration).|
|&nbsp;&nbsp;Enumeration|InputTopOutputLeft|Displays the inputs at the top and the outputs on the left.|

## Parent

[Discreets](xref:Protocol.Params.Param.Measurement.Discreets)

## Remarks

A typical matrix layout shows the inputs on the left and the outputs at the top. However, in certain circumstances, it can be useful to visualize a matrix in an alternative way. This can be done by this attribute.

From DataMiner 10.0.8 (RN 25456, RN 25892) onwards, you can use the matrixLayout attribute to configure the following matrix layouts:

- **InputLeftOutputTop**: Shows the inputs on the left and outputs at the top (default).
- **InputTopOutputLeft**: Shows the inputs at the top and outputs on the left.

> [!NOTE]
>
> - Only applicable for parameters of type "matrix".
> - The layout configuration can be overridden (per matrix) using the NotifyDataMiner call <xref:NT_UPDATE_PORTS_XML>.

## Examples

```xml
<Type link="labels.xml" options="matrix=64,64,0,1,0,64,pages">matrix</Type>
<Discreets matrixLayout="InputTopOutputLeft">
```
