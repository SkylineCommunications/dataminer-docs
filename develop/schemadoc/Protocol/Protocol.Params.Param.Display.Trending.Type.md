---
uid: Protocol.Params.Param.Display.Trending.Type
---

# Type element

Specifies the formula used to determine the average trending data.<!-- RN 5051 -->

## Type

[EnumTrendingType](xref:Protocol-EnumTrendingType)

## Parent

[Trending](xref:Protocol.Params.Param.Display.Trending)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[operations](xref:Protocol.Params.Param.Display.Trending.Type-operations)|string||Option to choose a logarithmic scale for the vertical axis.|

## Remarks

The following values are supported

| Value   | Description                                                                          |
|---------|--------------------------------------------------------------------------------------|
| Last    | Last value in the time span.                                                         |
| Sum     | Sum of all the values in the time span. This cannot be used for discreet parameters. |
| Max     | Maximum value in the time span.                                                      |
| Min     | Minimum value in the time span.                                                      |
| Average | Average value in the time span (default when no trending tag is present).            |
