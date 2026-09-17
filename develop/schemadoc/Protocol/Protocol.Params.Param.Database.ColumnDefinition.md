---
metadata_version: 1
uid: Protocol.Params.Param.Database.ColumnDefinition
description: "Reference the DataMiner connector protocol schema entry for ColumnDefinition element, including its documented structure, attributes, values, and constrai."
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
> Depending on the backend database, the specified data type is automatically converted to a supported backend database type. For example, when using a Cassandra database, the specified type will be automatically mapped to a compatible Cassandra data type.

## Examples

```xml
<Database>
   <ColumnDefinition>VARCHAR(200)</ColumnDefinition>
</Database>
```
