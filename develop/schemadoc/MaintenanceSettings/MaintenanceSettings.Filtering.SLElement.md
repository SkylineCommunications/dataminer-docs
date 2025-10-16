---
uid: MaintenanceSettings.Filtering.SLElement
---

# SLElement element

Configures filtering in SLElement.

## Parents

[Filtering](xref:MaintenanceSettings.Filtering)

## Attributes

| Name&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; | Type | Required | Description |
| --- | --- | --- | --- |
| [fallback](xref:MaintenanceSettings.Filtering.SLElement-fallback) | boolean |  | The order of operations in a table filter of type "fullFilter" (used in protocols and in the web services) can be determined by means of parentheses, e.g. `fullfilter=PK >= 0 AND (101 == 10 OR 101 > 20) AND (205 EXACT Service)`. However, in case you encounter issues with such filters because of this parsing behavior, it is possible to return to the legacy behavior by setting fallback to true. |

## Examples

```xml
<Filtering>
  <SLElement fallback="true" />
</Filtering>
```
