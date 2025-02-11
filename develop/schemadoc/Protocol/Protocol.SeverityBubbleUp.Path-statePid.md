---
uid: Protocol.SeverityBubbleUp.Path-statePid
---

# statePid attribute

<!-- RN 15103, RN 15843 -->

Refers to a parameter that indicates whether the bubble-up path is disabled or enabled.

## Content Type

unsignedInt

## Parent

[Path](xref:Protocol.SeverityBubbleUp.Path)

## Remarks

The referred parameter must have 0 and 1 as possible values.

While the element is running, if the parameter value is set to 0, the bubble-up path will be disabled. If the parameter value is set to 1, the bubble-up path will be enabled.

If this attribute is absent, the bubble-up path will be enabled by default.

## Examples

```xml
<SeverityBubbleUp>
    <Path statePid="501">200;100</Path>
</SeverityBubbleUp>
```
