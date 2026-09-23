---
metadata_version: 1
uid: Protocol.Params.Param.Database.Connection.Type
description: "Learn how to use the Type element to choose direct database writes or SLProtocol access for a logger table in a DataMiner connector protocol."
---

# Type element

Specifies the connection type.

## Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|DirectConnection|A direct connection is used to push data.|
|&nbsp;&nbsp;Enumeration|SLProtocol|Interaction with the logger table is done via SLProtocol.|

## Parent

[Connection](xref:Protocol.Params.Param.Database.Connection)

## Remarks

Refer to [Defining a logger table of type DirectConnection with a primary key](xref:AdvancedLoggerTablesDefiningDirectConnectionTable) for more information.
