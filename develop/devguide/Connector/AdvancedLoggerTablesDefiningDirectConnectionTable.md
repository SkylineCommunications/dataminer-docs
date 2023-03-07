---
uid: AdvancedLoggerTablesDefiningDirectConnectionTable
---

# Defining a logger table of type DirectConnection with a primary key

Starting from DataMiner 10.2.3 (RN 32375), it is possible to define a logger table of type DirectConnection with a primary key.

In the [Param](xref:Protocol.Params.Param) element of the logger table, do the following:

- Set [ArrayOptions\@index](xref:Protocol.Params.Param.ArrayOptions-index) to `1`.
- In [Database](xref:Protocol.Params.Param.Database), Set [IndexingOptions@enabled](xref:Protocol.Params.Param.Database.IndexingOptions-enabled) to `true` and [Connection.Type](xref:Protocol.Params.Param.Database.Connection.Type) to `Directconnection`.

> [!NOTE]
> The RTDisplay tag does not need to be set to true to offload via DirectConnection. However, if you want to show the offloaded parameters in a Dashboard via GQI, the tag should be true to enable this read mechanism.

For example:

```xml
<Param>
    <ArrayOptions index="1" options=";database" ...>
        ...
    </ArrayOptions>
    <Database>
        <IndexingOptions enabled="true" />
        <Connection>
            <Type>DirectConnection</Type>
        </Connection>
    </Database>
</Param>
```

## Overview of the possible ArrayOptions\@index and Connection.Type combinations

- Connection type: DirectConnection
  - No index defined: The data will be pushed via the direct connection and the ID will be assigned by the database. Updating the data will not be possible in this case.
  - Index defined: The data will be pushed via the direct connection and the ID will be assigned by the column template that is being sent via the direct connection by means of an “InitializeWriteAction”.

  > [!NOTE]
  > When DirectConnection is used in combination with a defined index, the TTL of the table should always be infinite.

- Connection type: SLProtocol
  - No index defined: Currently not supported.
  - Index defined: Default logger table configuration.
- No connection type defined
  - No index defined: Fallback to connection type “DirectConnection” with no index defined.
  - Index defined: Fallback to connection type “SLProtocol” with index defined.
