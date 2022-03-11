---
uid: Protocol.Params.Param.Database.ColumnDefinition
---

# ColumnDefinition element

Specifies the type of the corresponding column in the database table.

## Type

string

## Parent

[Database](xref:Protocol.Params.Param.Database)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[default](xref:Protocol.Params.Param.Database.ColumnDefinition-default)|string||Specifies the default value.|

## Remarks

- String types
  - VARCHAR
  - BLOB
  - TEXT
- Numeric types:
  - Integer types:
    - TINYINT
    - SMALLINT
    - MEDIUMINT
    - INT
    - BIGINT
  - Floating-point types
    - DOUBLE
    - FLOAT
    - DECIMAL
- Date and time data types:
  - DATETIME
 - The JSON data type: JSON

> [!NOTE]
> Depending on the back-end database, the specified data type is automatically converted to a a supported back-end database type. For example, when using a Cassandra database, the specified type will be automatically mapped to a compatible Cassandra data type.

## Examples

```xml
<Database>
   <ColumnDefinition>VARCHAR(200)</ColumnDefinition>
</Database>
```
