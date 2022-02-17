---
uid: Protocol.SeverityBubbleUp.Path
---

# Path element

Specifies the table path that needs to be followed when passing alarm severities.

## Type

[TypeSemicolonSeparatedNumbers](xref:Protocol-TypeSemicolonSeparatedNumbers)

## Parent

[SeverityBubbleUp](xref:Protocol.SeverityBubbleUp)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[statePid](xref:Protocol.SeverityBubbleUp.Path-statePid)|unsignedInt||Refers to a parameter that indicates whether the bubble-up path is disabled or enabled.|

## Remarks

The order does not need to be the same as the relation path. It depends on what table should have an effect on the other table.

## Examples

In the following example,

- the first path will cause alarm severity to bubble up from table 5000 to 4000 and up to table 3000, and
- the second path will case alarm severity to bubble up from table 2000 to 3000.

```xml
<SeverityBubbleUp>
  <Path>5000;4000;3000</Path>
  <Path>2000;3000</Path>
</SeverityBubbleUp>
```
