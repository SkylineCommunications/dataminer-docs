---
uid: Browsing_the_database_with_DMS_Inventory_and_Asset_Management
---

# Browsing the database with DataMiner Inventory and Asset Management

On the left-hand side of the *Asset Manager* user interface, there is an overview pane with two tabs: *Normal view* and *Logical view*. Depending on what you select in the overview pane, additional views will become available in the data pane on the right-hand side.

The following sections provide information on each of the Asset Manager views:

- [Normal view](#normal-view)

- [Logical view](#logical-view)

- [Row view](#row-view)

- [All linked items view](#all-linked-items-view)

> [!NOTE]
> Every minute, DataMiner checks the connection with the database. If no connection can be made, a notification message will appear.

### Normal view

The *Normal view* visualizes the entire database as a tree structure in the overview pane.

One table acts as the root of the tree, and from there you can follow different paths into the database, going from one interlinked table (record) to another.

> [!NOTE]
> The root table can be specified in the configuration file. For more information, see [Configuring DataMiner Inventory and Asset Management](xref:Configuring_DMS_Inventory_and_Asset_Management).

If you click an item in the tree structure, detailed data appear in the data pane on the right:

- When you select a table, the data pane will display a table view.

- When you select a table record, the data pane will display the data in that record.

    In this case, the data pane will display three tabs: *Row view*, *All linked items* and *Logical view*.

> [!NOTE]
> To refresh the data in the data pane, click the *Refresh* button.

### Logical view

The *Logical view* in the overview pane shows the key fields of each record with all linked tables in the form of a tree structure.

The *Logical view* in the data pane shows the key field of a selected record with all its linked tables in the form of a tree structure.

IDs are automatically replaced by the values to which they refer.

If you select an item in the logical view in the overview pane, the data pane on the right will display two tabs: *Row view* and *All linked items*.

### Row view

In the *Row view*, the fields of a selected record are displayed in the data pane as a series of name/value pairs.

At the bottom of the data pane, you will find links to linked tables. Clicking one of those table links opens up a new section listing the records in that table that are linked to the currently selected record.

If you have Write access to the table that contains the selected record, you can change the values displayed in the *Value* column. To do so, just click inside a cell and change the value.

> [!NOTE]
>
> - In the configuration file, user groups can be granted or denied access to tables. For more information, see [Configuring DataMiner Inventory and Asset Management](xref:Configuring_DMS_Inventory_and_Asset_Management).
> - When a user updates, adds or deletes a row in Asset Manager, an information event is generated in the Alarm Console.

### All linked items view

In the *All linked items* view, the selected record and all records linked to it are displayed one below the other in separate sections, each representing a database table.

> [!NOTE]
> The order of the tables can be specified in the configuration file. For more information, see [Configuring DataMiner Inventory and Asset Management](xref:Configuring_DMS_Inventory_and_Asset_Management).
