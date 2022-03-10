---
uid: Protocol.Params.Param.Database.CQLOptions.TableProperty
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
