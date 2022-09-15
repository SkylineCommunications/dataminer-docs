---
uid: Tags_in_the_Asset_Manager_configuration_file
---

# Tags in the Asset Manager configuration file

## AssetManagerConfig

While the configuration file itself can have a random name, its root tag must be named *\<AssetManagerConfig>*.

## AssetManagerConfig.DatabaseConfig

In this mandatory tag, specify the name of the database configuration (as specified in the *DB.xml* file).

> [!TIP]
> See also:
> [DB.xml](xref:DB_xml#dbxml)

## AssetManagerConfig.Schema

In this mandatory tag, specify the name of the database.

## AssetManagerConfig.DisplayName

In this tag, specify the name of the database as you want it to appear in the *Asset Manager* user interface.

This tag is optional. If it is left empty or if it is not used, then the name of the database shown in the user interface will be the database schema name as specified in the *\<Schema>* tag.

## AssetManagerConfig.HandlingDMA

In this tag, specify the ID of the DataMiner Agent that is allowed to connect to the CMDB.

This tag is optional. If it is left empty, if it contains 0 or if it is not used, then every DMA in the DataMiner System will be allowed to connect to the CMDB.

## AssetManagerConfig.RootTable

In this mandatory tag, specify the database tables that have to appear in the root of the table tree.

If you specify more than one table, separate the table names by semicolons (”;”).

## AssetManagerConfig.Security

In this tag, you can specify Read and Write permissions on user group level for every table in the database.

This tag is optional. However, keep in mind that if it is left empty or if it is not used, then all users will have full access to the database!

For an example, refer to the *\<Security>* section in the example (see [Example of an Asset Manager configuration file](xref:Example_of_an_Asset_Manager_configuration_file)). In this example, Administrators have Read access to all tables (*\<Read base="allowAll">*) except TableX (*\<Deny>TableX\</Deny>*) and Write access to TableY (*\<Write base="denyAll">\<Allow>TableY\</Allow>\</Write>*). Operators have Read access to all tables (*\<Read base="allowAll" />*) and Write access to none of the tables (*\<Write base="denyAll" />*).

> [!NOTE]
>
> - It is also possible to configure security for the columns in each table with a \<Security> tag within the \<Table> tag.
> - Security is configured per group, not per user. When you add a security group of the domain, use the down-level logon name, i.e. the domain name followed by a backslash and the group name. For example: `DomainName\GroupName`. Local DataMiner groups can be referenced by their group name.
> - If you grant Write access to a specific table, then users will be able to add and delete rows in that table (using dedicated buttons) and edit data in existing rows (by clicking inside cells).
> - If you specify multiple table names within an Allow or a Deny tag, separate them by commas.
> - Multiple Allow tags or multiple Deny tags are not allowed within the same Read or Write tag.

## AssetManagerConfig.Tables

In this mandatory tag, you can configure how the different tables will be displayed in the *Asset Manager* user interface.

> [!NOTE]
> If you do not want to change the appearance of any tables, you should leave this tag empty. For example:
>
> *\<AssetManagerConfig>*
>
> *...*
>
> *\<Tables />*
>
> *...*
>
> *\<AssetManagerConfig>*

### Tables

If you want to change something to the appearance of a table, then add a *\<Table>* tag, and specify the following attributes:

| Attribute     | Mandatory? | Description                                                                                                                                                                                                                                                                                                                                                                                                             |
|---------------|------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| name          | Yes        | The actual name of the table.                                                                                                                                                                                                                                                                                                                                                                                           |
| displayName   | Yes        | The name of the table as it has to appear in the user interface.                                                                                                                                                                                                                                                                                                                                                        |
| displayColumn | Yes        | The name of the column of which the values have to replace the table’s primary keys.<br> It is possible to define a display name for a record that combines several columns. To do so, specify a display name containing column names, separated by a space, a dot, brackets, a backslash, a forward slash, parentheses or square brackets. E.g. *displayColumn="column1 (column2:column3)"* |
| skip          | No         | If this table has to be hidden in the *Logical View*, then set this attribute to “true”.                                                                                                                                                                                                                                                                                                 |

### Columns

If you want to change something to the appearance of a specific table column, then, inside a *\<Table>* tag, add a *\<Columns>* tag containing a *\<Column>* tag for every column of which you want to change the appearance. For each column, you can specify the following attributes:

| Attribute      | Mandatory? | Description                                                                                                                                                                           |
|----------------|------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| name           | Yes        | The actual name of the column.                                                                                                                                                        |
| displayName    | No         | The name of the column as it has to appear in the user interface.                                                                                                                     |
| dmSelect       | No         | A particular element protocol. If this attribute is used, the column will only accept IDs of elements with that protocol.                                                             |
| orderWeight    | No         | The position of the column when a fixed column order is applied.                                                                                                                      |
| width          | No         | The width of the column in the user interface (in pixels).                                                                                                                            |
| RegExValidator | No         | A regular expression. It will not be possible to specify values in the column that do not match this regular expression.<br> This attribute can be used from DataMiner 9.0.3 onwards. |

> [!NOTE]
> - To hide a column, you can set the width to 0. The columns will then not be shown when you edit or add a row, except if they contain a primary key or a foreign key or if they cannot be left empty.
> - If the order of the columns is not fixed by means of the “orderWeight” attribute, then the order of the *\<Columns>* tags will define the order in which columns are displayed.
> - If the columns have a fixed order, this order will also be applied when you fix or edit a row, except that the columns will be divided into “Required fields” and “Optional fields”.

Example:

```xml
<AssetManagerConfig>
  <Tables>
    <Table name="table1">
      <Columns>
        <Column name="col1" displayName="Column name 1" orderWeight="2" dmSelect="Microsoft Platform"/>
        <Column name="col2" displayName="Column name 2" RegExValidator="..."/>
        <Column name="col3" displayName="Column name 3" orderWeight="1" />
      </Columns>
    </Table>
  </Tables>
</AssetManagerConfig>
```

### Columnrelations

To configure advanced deletion behavior of database records, inside a *\<Table>* tag, add a *\<ColumnRelations>* tag, with the following two attributes:

- sourceColumn: the name of the column

- onDelete: defines the behavior when a user tries to delete a record. This can only be one of the following:

| Attribute                      | Description                                                                                                                             |
|--------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------|
| onDelete=”PromptLinkedRemoval” | The user will be asked for confirmation before the selected record and linked records are deleted.                                      |
| onDelete=”DenyLinkedRemoval”   | The user will be denied permission to delete the record and its linked records. It will also be impossible to delete the parent record. |
| onDelete=”AllowLinkedRemoval”  | Default behavior: only the selected record will be deleted, no linked records.                                                          |

### Filter

If you want to filter the records displayed in a table, then, inside a *\<Table>* tag, add a *\<Filter>* tag and specify the WHERE clause in a CDATA tag.

> [!NOTE]
> The value of a definition attribute has to be an ANSI-compliant WHERE clause. Do not use double quotes.

### Order

If you want to define a record sorting order for a table, inside a *\<Table>* tag, add an *\<Order>* tag, and specify what to order by with a definition attribute.

E.g. for ascending order: *definition="columnName ASC"* or for descending order: *definition="columnName DESC"*.

### Icon

To give a table a custom icon in the tree view, inside the *\<Table>* tag, add an *\<Icon>* tag. The icon can either be defined by means of XAML code in a CDATA tag, or by using a “key” attribute that refers to an icon defined in the *Icons.xml* file.

- Example of icon using XAML code:

    ```xml
    <Table name="channel" displayName="Channel" displayColumn="Name">
      <Icon>
      <![CDATA[
        <Viewbox Width="13.000" Height="12.000"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
        <Rectangle Width="13" Height="12" Fill="Red" />
        </Viewbox>
      ]]>
      </Icon>
    </Table>
    ```

- Example of icon in the *Icons.xml* file:

    ```xml
    <Table name="channel" displayName="Channel" displayColumn="Name">
      <Icon key="MYTABLEICON" />
    </Table>
    ```

### PathsToFollow

For every table, you can specify which table links you want to visualize in the table hierarchy. In some cases, you will have to restrict table linking to prevent possible endless loops.

Inside a *\<Table>* tag, add a *\<PathsToFollow>* tag containing a *\<Path>* tag for every “path” you allow.

A *\<Path>* tag can contain the following:

| Contents                                  | Description                                                                                                                                                                         |
|-------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| NONE                                      | The hierarchy stops at the given table. The table node will not have any subnodes.                                                                                                  |
| NO_OUT                                    | Only incoming links will be visualized. In other words, the table node will have a subnode for every table that has a link towards the given table.                                 |
| NO_IN                                     | Only outgoing links will be visualized. In other words, the table node will have a subnode for every table to which it links.                                                       |
| table\[.FKColumn\],table\[.FKColumn\],... | You can specify a fixed table hierarchy by entering a comma-separated series of tables. That way, when you open the table node, you will only be able to follow the specified path. |

By default, all possible table links will be visualized in the table hierarchy.

### Security

To configure the access rights of groups to the columns of a particular table, inside the *\<Table>* tag, add a *\<Security>* tag. This tag works in the same way as the global security tag. See [AssetManagerConfig.Security](#assetmanagerconfigsecurity) for more information.

Example:

```xml
<Table name="view" displayName="View">
  ...
  <Security>
    <Group name="Group1">
      <Read base="allowAll">
        <Deny>aSpecialColumn</Deny>
      </Read>
    </Group>
    <Group name="Group2">
      <Read base="allowAll">
      </Read>
    </Group>
  </Security>
  ...
</Table>
```

## AssetManagerConfig.Views

If you want views that are defined in the database to be displayed in the tree view, add this optional tag, containing a *\<View>* tag for every view you want to add.

This tag can have the following attributes:

| Attribute     | Mandatory? | Description                                                                          |
|---------------|------------|--------------------------------------------------------------------------------------|
| name          | Yes        | The actual name of the view.                                                         |
| displayName   | No         | The name of the view as it has to appear in the user interface.                      |
| displayColumn | No         | The name of the column of which the values have to replace the table’s primary keys. |

Example:

```xml
<Views>
  <View name="name_of_the_view" displayName="View"/>
</Views>
```

> [!NOTE]
> In the Asset Manager tree view, these will be displayed as tables. If you select such a table, you will be able to view it, but not edit it.

## AssetManagerConfig.AllLinkedDataOrder

If you want the different database tables to appear in a fixed order in the *All Linked Items View*, then, in this optional tag, specify the tables in the desired order using *\<Table>* tags.

You do not have to specify all tables. If, for example, you would like the three most important tables to appear at the top of the *All Linked Items View*, followed by all other tables in their default order, then just specify those three tables in the *\<AllLinkedDataOrder>* tag.
