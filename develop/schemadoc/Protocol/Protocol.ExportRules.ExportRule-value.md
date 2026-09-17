---
metadata_version: 1
uid: Protocol.ExportRules.ExportRule-value
description: "Reference the DataMiner connector protocol schema entry for value attribute, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# value attribute

Specifies the value that needs to be set in the XML element.

## Content Type

string

## Parent

[ExportRule](xref:Protocol.ExportRules.ExportRule)

## Examples

In the following example, a webpage is shown on a DVE. Parameter 221 is a column that contains the IP addresses, and table 200 is linked to table 4000 via the relation path:

```xml
<ExportRule table="4000" tag="Protocol/Display" attribute="pageOrder" value="General; Input/Output;Webpage#http://[id:211]" />
```
