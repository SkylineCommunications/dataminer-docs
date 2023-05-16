---
uid: AdvancedLoggerTablesImplementation
---

# Implementing logger tables

To implement a logger table, perform the following steps:

1. Create a table parameter that uses the database option (optionally defining the number of rows to keep in the SLProtocol process). Note that once the database option is used, all columns of the table are saved in the database, so it is not required to use the save option explicitly.

    ```xml
    <Param id="5200" trending="false">
       <Name>Traps Logger Table</Name>
       <Description>Traps Logger</Description>
       <Type>array</Type>
       <ArrayOptions index="0" options="database">
          <ColumnOption idx="0" pid="5201" type="retrieved" options="" />
          <ColumnOption idx="1" pid="5202" type="retrieved" options="" />
         ...
       </ArrayOptions>
      ...
    </Param>
    ```

    In case the logger table persists in Cassandra, also provide a [Database.CQLOptions.Clustering](xref:Protocol.Params.Param.Database.CQLOptions.Clustering) tag. From DataMiner version 9.0.0 onwards, if the Param.Database.CQLOptions.Clustering tag is used, the primary key (i.e. index) set in the ArrayOptions tag will be replaced by the primary key defined in the Clustering tag.

    ```xml
    <Param id="5200" trending="false">
       <Name>Traps Logger Table</Name>
       <Description>Traps Logger</Description>
       <Type>array</Type>
       <ArrayOptions index="0" options="database">
          <ColumnOption idx="0" pid="5201" type="retrieved" options="" />
          <ColumnOption idx="1" pid="5202" type="retrieved" options="" />
         ...
       </ArrayOptions>
       <Database>
          <CQLOptions>
             <Clustering>25;2;0</Clustering>
          </CQLOptions>
       </Database>
      ...
    </Param>
    ```

    The Clustering tag contains a semicolon-separated list of column idx references. (From DataMiner 9.0.0 onwards, a colon is also allowed as separator).

    In Cassandra, the primary key consists of two parts: the partitioning key and the clustering key. In the example above, the partitioning key is the column referred to by idx 25 (i.e. the first item in the semicolon-separated list) and the remaining columns form the clustering key (2;0).

    From DataMiner 9.0.0 onwards, parentheses can be used to form composite partitioning keys (RN12170).

1. For every column parameter, define the database type to be used. This is done via the [Database.ColumnDefinition](xref:Protocol.Params.Param.Database.ColumnDefinition) tag.

    ```xml
    <Param id="5204" trending="false">
       <Name>sip</Name>
       <Description>Source IP (Trap Log)</Description>
       <Information>
          <Subtext>Trap Log Source IP</Subtext>
       </Information>
       <Type>read</Type>
       <Interprete>
          <RawType>other</RawType>
          <Type>string</Type>
          <LengthType>next param</LengthType>
       </Interprete>
       <Database>
          <ColumnDefinition>VARCHAR(20)</ColumnDefinition>
       </Database>
       <Display>
          <RTDisplay>true</RTDisplay>
       </Display>
       <Measurement>
          <Type>string</Type>
       </Measurement>
    </Param>
    ```

    In the example above, this will result in a column with name "sip" of type VARCHAR(20) (in case of a MySQL database). The name of the parameter is used as the name of the corresponding column in the database (Note that it is therefore not allowed to change this name in an existing protocol).

    In case the logger table persists in Cassandra, the specified datatype will automatically be mapped to the corresponding Cassandra datatype.

    Note the following restrictions:

    - For RDBMS (MySQL), the following restrictions apply:
      - Schema, table and column names have a maximum length of 64 characters (exceeding characters will be dropped).
      - The following special characters are not allowed and will be replaced with underscores:
        - ' ' (space)
        - . (dot)
        - , (comma)
        - : (colon)
        - ; (semicolon)
        - \- (hyphen)
        - / (slash)
        - | (pipe)
        - ` (grave accent)
        - ' (single quote)
        - \* (asterisk)
        - ? (question mark)
        - ! (exclamation mark)
        - " (double quote)
        - ^ (caret)
        - ~ (tilde)
        - % (percent)
        - +(plus sign)
        - \# (number sign)
        - = (equal sign)
        - @ (at symbol)
        - & (ampersand)
        - <> (less than and greater than sign)
        - [] (opening and closing square brackets)
        - {} (opening and closing curly braces)
        - () (opening and closing parenthesis)
      - \ (backslash) is forbidden.
    - For Cassandra, the following restrictions apply:
      - Keyspace, table and column names have a maximum length of 48 characters (exceeding characters will be dropped).
      - Cassandra only supports alphanumerical characters and underscores in names.
      - Leading underscores are not allowed and will be dropped.

    The length of column names has a major influence on performance in Cassandra. Therefore, it is always advised to use very short names (preferably 1 or 2 characters). Also, it is advised to use lowercase characters only, no spaces and no 'special' characters.

    In order to keep a protocol compatible with both SQL and Cassandra, it is advised to use names that are supported by both SQL and Cassandra.
1. One column should be of type "DATETIME". This column also specifies the number of partitions to keep (defined using the Partition tag).

    ```xml
    <Param id="5202" trending="false">
       <Name>ts</Name>
       <Description>Database Timestamp (Trap Log)</Description>
       <Information>
          <Subtext>This is the principal timestamp used in the database.</Subtext>
       </Information>
       <Type>read</Type>
       <Interprete>
          <RawType>other</RawType>
          <Type>string</Type>
          <LengthType>next param</LengthType>
       </Interprete>
       <Database>
          <ColumnDefinition>DATETIME</ColumnDefinition>
          <Partition partitionsToKeep="7">day</Partition>
       </Database>
       <Display>
          <RTDisplay>true</RTDisplay>
       </Display>
       <Measurement>
          <Type>string</Type>
       </Measurement>
    </Param>
    ```

    In the example above, this will generate a partition per day and the seven most recent partitions will be kept. This way, obsolete data will automatically be cleared from the logger table.

    Note the following:

    - The expected format is as follows: 'YYYY-MM-DD HH:MM:SS'. In a QAction, you can obtain this format for a given DateTime instance using the following code:

      ```csharp
      string datetime = DateTime.UtcNow.ToString("G", CultureInfo.CreateSpecificCulture("fr-CA"));
      ```

    - DateTime values should be inserted in UTC.
    - It is not strictly necessary to include a column in a logger table used for partitioning. However, it is strongly advised to do so, as otherwise the table will not automatically remove old data.

    - Partitioning in Cassandra is supported from DataMiner version 9.0.0 (RN12170) onwards. If ColumnDefinition is set to "DATETIME" and the Partition tag is set, Cassandra will use a TTL with the specified time. (See [Time to live](xref:AdvancedDataMinerDataPersistenceNoSqlCassandra#time-to-live).)

      From DataMiner version 9.5.7 (RN 16738) onwards, you can specify the TTL of a logger table column via the Partition tag on any column. This is also supported for the indexing database.

      ```xml
      <Param id="1003" trending="false">
        ...
         <Database>
            <ColumnDefinition>VARCHAR(200)</ColumnDefinition>
            <Partition partitionsToKeep="2">hour</Partition>
         </Database>
      </Param>
      ```

      However, in order to preserve compatibility with a RDBMS (SQL) database, it is advised to still define a column of type DATETIME that specifies the partitions to keep.

    The logger table defined in the steps above will result in the creation of a table with name elementdata_[DMA ID]_[element ID]_[table parameter ID].

    In MySQL, in addition to the table, a stored procedure is generated for performing a so-called "upsert" operation: this routine first performs an UPDATE to update the specified row and then checks the number or updated rows. If this equals zero, this means the row did not yet exist. In that case, an INSERT statement is executed.

    ```sql
    CREATE DEFINER=`[user]`@`[host]` PROCEDURE `UPSERT_ELEMENTDATA_[DMA ID]_[Element ID]_[Table ID]`(IN in[Name column 1] [datatype column 1], ..., IN in[Name column N] [datatype column N])
    
    BEGIN DECLARE isExist int default -1;
    
    UPDATE ELEMENTDATA_[DMA ID]_[Element ID]_[Table ID] SET  [Name column 1] = in[Name column 1], ..., [Name column N] = in[Name column N] WHERE [Name PK column] = in[Name PK column];
    
    SELECT ROW_COUNT() INTO isExist;
    
    IF  isExist = 0 THEN INSERT INTO ELEMENTDATA_[DMA ID]_[Element ID]_[Table ID]([Name PK column], [Name column 1], ..., [Name column N]) VALUES(in[Name PK column], in[Name column 1], ..., in[Name column N]); END IF; END$$
    ```

    This stored procedure is executed whenever an AddRow (SLProtocol) method call is performed.

    Also note that in the stored procedure, the names of the input parameters are defined as the column names prefixed with "in". Therefore, it is not allowed to define a column with name "t", as this would result in the reserved keyword "int".

> [!NOTE]
> In regular tables, performing an AddRow specifying a key that already exists does not change the row data. This is not the case for logger tables, which will update the row.

## Indexed logger tables

From DataMiner 9.6.4 (RN 13552) onwards, it is possible to store a logger table in the indexing database instead of Cassandra.

To indicate that a logger table should be stored in the indexing database instead of Cassandra, set the [IndexingOptions@enabled](xref:Protocol.Params.Param.Database.IndexingOptions-enabled) attribute to true:

```xml
<Database>
   <IndexingOptions enabled="true" />
</Database>
```

When logger tables are stored the indexing database, the following restrictions apply:

- The columnName must not start with `-`, `_`, or `+`.
- The columnName must not include `\`, `/`, `*`, `?`, `"`, `<`, `>`, " " (space character), `,`, `#`, `.`, or `:`.

> [!NOTE]
>
> - The indexing database has a background process that will check for all expired documents and add them to a bulk delete request. This means records may stay longer (but never shorter) than the specified TTL time.
> - Updating rows is an expensive operation in the indexing database.

### Infinite TTL

From DataMiner 9.6.4 (RN 19993) onwards, in order to prevent indices from rolling over in the indexing database, it is possible to specify an infinite TTL.

```xml
<Database>
   <ColumnDefinition>DATETIME</ColumnDefinition>
   <Partition>infinite</Partition>
</Database>
```

> [!NOTE]
>
> - The partitionsToKeep attribute value is ignored when Partition is set to “infinite”.
> - The column does not need to be a datetime column. Any column type is supported.
> - The value "infinite" only works on tables with IndexingOptions@enabled = true (i.e. logger tables stored in the indexing database).

## Designing logger tables

With Cassandra, the design of a logger table is very important. Think about what queries will be performed on the table and then design the table accordingly, as this will determine what the partitioning key should be and whether clustering columns are required.

For more information on the Cassandra data model, refer to [DataMiner general database – NoSQL Database – Cassandra](xref:AdvancedDataMinerDataPersistenceNoSqlCassandra).

## Best practices

In order to make a protocol compatible with both RDBMS (SQL) and Cassandra, and maintain decent performance for insertion and lookups, there are a few things to take into account:

- The parameter names cannot contain spaces or capital letters.
- Keep parameter names as short as possible, preferably 1 or 2 characters. However do not use 't' as a parameter name, as this will fail with MySQL.
- Avoid specifying a foreign key option on a parameter, unless this is on the partitioning key, because it would mean that a secondary index is created in Cassandra, which has a negative impact on performance.
- If the rows in the logger table should only be added and never overwritten, use an auto-increment PK for the parameter table. If you do so, DataMiner does not need to scan the entire table first to check if a row already exists, which allows a higher insertion rate.
- Do not choose the auto-increment PK in DataMiner as partition key. This would lead to a very high cardinality and would mean that you would have to know beforehand what this value is before being able to query the row.
- AddRow calls are blocking calls, meaning there is no advantage to add rows multi-threaded. It will even have the downside that threads will start to block each other and new threads are created to try to compensate. Therefore, it is better to have one thread running that gets items to be added from a ConcurrentQueue.
- DateTime values should be inserted in UTC.

## See also

- [Protocol.Params.Param.ArrayOptions-options](xref:Protocol.Params.Param.ArrayOptions-options)
  - [database](xref:Protocol.Params.Param.ArrayOptions-options#database) option
  - [databaseName](xref:Protocol.Params.Param.ArrayOptions-options#databasename) option
  - [databaseNameProtocol](xref:Protocol.Params.Param.ArrayOptions-options#databasenameprotocol) option
  - [customDatabaseName](xref:Protocol.Params.Param.ArrayOptions-options#customdatabasename) option
- [Protocol.Params.Param.Database.CQLOptions.Clustering](xref:Protocol.Params.Param.Database.CQLOptions.Clustering)
- [Protocol.Params.Param.Database.ColumnDefinition](xref:Protocol.Params.Param.Database.ColumnDefinition)
- [Protocol.Params.Param.Database.IndexingOptions@enabled](xref:Protocol.Params.Param.Database.IndexingOptions-enabled)
