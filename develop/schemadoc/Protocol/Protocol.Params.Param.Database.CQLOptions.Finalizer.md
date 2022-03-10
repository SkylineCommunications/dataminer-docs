---
uid: Protocol.Params.Param.Database.CQLOptions.Finalizer
---

# Finalizer element

Specifies the query that has to be executed after creation of the table. This can for example be a query that will preload data or create indexes.

## Type

string

## Parent

[CQLOptions](xref:Protocol.Params.Param.Database.CQLOptions)

## Remarks

The following placeholders can be defined:

|Placeholder|Description
|--- |--- |
|[TABLE]|Sets the table name.|
|[PID:#]|Sets the parameter name of the parameter with ID #.|

## Examples

The query in this example will create an index (if one does not already exist) on the logger table for the column with parameter ID 52.

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
