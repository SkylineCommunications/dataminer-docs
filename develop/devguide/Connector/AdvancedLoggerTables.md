---
uid: AdvancedLoggerTables
---

# Logger tables

Logger tables are used in scenarios where the amount of data stored can become very large. Logger tables are not held in memory but directly written to persistent storage (i.e., the database).

They are mainly used for the following purposes:

- For logging, i.e., the protocol only performs write operations to the logger table, but does not need to read from it.
- To be used by DataMiner applications, e.g., DataMiner Maps or an EPM interface, which query the logger table for display purposes.

Rows of logger tables are, unlike those of other tables, not loaded in the SLProtocol process, except for a limited number of rows. This number is by default 500, but it is configurable via the database option. For example, to specify that at most 1000 rows must be kept in memory, define the following in the ArrayOptions tag:

```xml
options=";database:1000"
```

> [!NOTE]
> This value should always be set to a reasonable number of rows (neither too small nor too high).

Because not all table data is loaded in the SLProtocol process, data from a logger table cannot be retrieved using methods defined in the SLProtocol interface (e.g., GetParameterIndexByKey) and trending and alarming are not supported.

> [!NOTE]
> Logger tables should have RTDisplay set to `true`. This is because logger tables are typically used with view tables/SLNet filters. Even for scenarios where the logger table is only used by third-party tools, it is OK to set RTDisplay to `true` as this does not cause a big impact.

Only the cached rows are loaded in the SLElement process. This means that not all rows of the table will be visible when the table is visualized on a page. Therefore, logger tables must not be visualized, as only partial content would be shown.

In order to keep a logger table from containing too many rows, old entries in a logger table can automatically be removed.

In this section:

- <xref:AdvancedLoggerTablesImplementation>
- <xref:AdvancedLoggerTablesQuerying>
- <xref:AdvancedLoggerTablesExtending>
- <xref:AdvancedLoggerTablesDefiningDirectConnectionTable>
