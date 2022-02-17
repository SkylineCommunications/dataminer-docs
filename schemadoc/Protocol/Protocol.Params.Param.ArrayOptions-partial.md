---
uid: Protocol.Params.Param.ArrayOptions-partial
---

# partial attribute

If set to *true*, the table will be subdivided into multiple pages (default: 1000 rows per page).

## Content Type

|Item|Facet Value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Pattern|`^false$|^(true(:\d+)?)$`||

## Parent

[ArrayOptions](xref:Protocol.Params.Param.ArrayOptions)

## Remarks

A page navigator will be displayed at the bottom of the table.

To manually set the number of rows per page, type a colon (”:”) after TRUE, followed by the number of rows per page. This value has to be a value between 10 and 5000.

## Examples

```xml
<ArrayOptions index="0" partial="true:200">
```
