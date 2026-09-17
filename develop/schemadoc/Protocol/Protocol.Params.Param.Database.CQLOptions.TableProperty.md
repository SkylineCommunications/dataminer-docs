---
metadata_version: 1
uid: Protocol.Params.Param.Database.CQLOptions.TableProperty
description: "Reference the DataMiner connector protocol schema entry for TableProperty element, including its documented structure, attributes, values, and constraints."
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

# TableProperty element

Specifies the WITH clause that is to be used to set the necessary table properties.

## Type

string

## Parent

[CQLOptions](xref:Protocol.Params.Param.Database.CQLOptions)

## Examples

```xml
<Param>
    <Database>
        <CQLOptions>
            <Clustering>1;2</Clustering>
            <TableProperty>CLUSTERING ORDER BY (&quot;[PID:52]&quot; DESC)</TableProperty>
            <Finalizer>CREATE INDEX IF NOT EXISTS ON [TABLE] ([PID:52]);</Finalizer>
        </CQLOptions>
    </Database>
</Param>
```
