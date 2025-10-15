---
uid: MaintenanceSettings.Filtering.SLElement-fallback
---

# fallback attribute

The order of operations in a table filter of type "fullFilter" (used in protocols and in the web services) can be determined by means of parentheses, e.g. `fullfilter=PK >= 0 AND (101 == 10 OR 101 > 20) AND (205 EXACT Service)`. However, in case you encounter issues with such filters because of this parsing behavior, it is possible to return to the legacy behavior by setting fallback to true.

## Content Type

boolean

## Parents

[SLElement](xref:MaintenanceSettings.Filtering.SLElement)
