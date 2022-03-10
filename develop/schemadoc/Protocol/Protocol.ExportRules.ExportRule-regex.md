---
uid: Protocol.ExportRules.ExportRule-regex
---

# regex attribute

Specifies a regular expression to match particular values.

## Content Type

string

## Parent

[ExportRule](xref:Protocol.ExportRules.ExportRule)

## Examples

In the example below, we search for tags containing “MCR”:

```xml
<ExportRule regex="MCR" />
```

For a full match, use the start-of-string anchor ‘^’ and the end-of-string anchor ‘$’:

```xml
<ExportRule table="1000" tag="Protocol/Params/Param/Display/Positions/Position/Page" value="General" regex="^Export Items$"/>
```
