---
uid: Protocol.Type-databaseOptions
---

# databaseOptions attribute

Specifies a number of database options.

## Content Type

string

## Parent

[Type](xref:Protocol.Type)

## Remarks

In this attribute, you can enter the following values:

- customDataIDs: If you specify this option, the default autoincrement feature will be overruled. Instead, DataMiner will be in charge of defining the record IDs. Feature introduced in DataMiner 7.5 (RN 4271).
- partitionedTrending: If you specify this option, partitioning will be activated on the trending tables.

  ```xml
  <Type relativeTimers="true with reset" databaseOptions="partitionedTrending">serial</Type>
  ```

  *Feature introduced in DataMiner 8.0.1 (RN 5807).*

  > [!NOTE]
  > The partitionedTrending option only relates to an RDBMS database, so it has no influence on a Cassandra database.
