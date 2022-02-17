---
uid: Protocol.ExportRules.ExportRule-value
---

# value attribute

Specifies the value that needs to be set in the XML element.

## Content Type

string

## Parent

[ExportRule](xref:Protocol.ExportRules.ExportRule)

## Examples

In the following example, a web page is shown on a DVE. Parameter 221 is a column that contains the IP addresses, and table 200 is linked to table 4000 via the relation path:

```xml
<ExportRule table="4000" tag="Protocol/Display" attribute="pageOrder" value="General; Input/Output;Webpage#http://[id:211]" />
```
