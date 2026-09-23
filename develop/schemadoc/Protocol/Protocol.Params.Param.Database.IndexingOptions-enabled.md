---
metadata_version: 1
uid: Protocol.Params.Param.Database.IndexingOptions-enabled
description: "Reference the DataMiner connector protocol schema entry for enabled attribute, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
---

# enabled attribute

Specifies whether the data of the logger table will be stored in the Elastic database instead of Cassandra. When set to true, the data of the logger table will be stored in the Elastic database instead of Cassandra

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[IndexingOptions](xref:Protocol.Params.Param.Database.IndexingOptions)

## Remarks

Default value: false.

## See also

- Development Guide:
  - [Logger tables](xref:AdvancedLoggerTables)
