---
uid: Protocol.Params.Param.Database.CQLOptions.Clustering
---

# Clustering element

Specifies how the primary key of the table is defined.

## Type

string

## Parent

[CQLOptions](xref:Protocol.Params.Param.Database.CQLOptions)

## Remarks

Contains a comma- or semicolon-separated list of column idx values denoting the columns that form the primary key.

In Cassandra, the primary key can consist of a single column or of multiple columns. The latter case is referred to as a composite or compound row key. A composite or compound row key consists of two parts: a partition key and one or more clustering columns (referred to as clustering key). The partition key can consist of multiple columns. To indicate a composite partition key in the protocol, parentheses must be used (RN 12170). In case no parentheses are used, the first entry denotes the partition key and the remaining entries form the clustering key.

> [!NOTE]
> When the Clustering tag is used, the primary key (index) set in the index attribute of the ArrayOptions tag will not be used. Instead the complete key defined in the Clustering tag will be used.

## Examples

In this example, the partition key consists of the columns referred to by idx 3 and 1. Column indx 0 is a clustering column.

```xml
<Clustering>(3;1);0</Clustering>
```
