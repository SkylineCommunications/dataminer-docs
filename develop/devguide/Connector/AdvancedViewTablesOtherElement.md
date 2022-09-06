---
uid: AdvancedViewTablesOtherElement
---

# View tables from other elements

Direct view tables can be used to aggregate data from different source elements in an aggregator element.

To implement a direct view table, create a custom table that contains a column holding the DMA ID/Element IDs of the source elements for which a direct view should be created. Each row in this column represents a source element. Next, define a table that will hold the aggregated data (i.e. the direct view). Some possible implementations of direct views are described next.

1. Creating a view table containing only data from the source element(s).

   In the options attribute of the ArrayOptions tag, specify for "view" the ID of the table from which data should be obtained. Note that in case this table contains foreign keys to another table, data from this linked table can also be obtained. (In case the linked table also refers to another table using foreign keys, data from that other table can also be obtained.) For "directView", the ID of the column parameter (not the table ID) containing the element IDs of the source elements.

   > [!NOTE]
   > By default, it is assumed that the source elements and the aggregator element run the same protocol. However, since DataMiner version 8.0.7, it is possible that the aggregator element does not run the same protocol as the source elements. When this is the case, this must be indicated with the remoteId option (e.g. view=1000,remoteId;).

   To add parameters of the referred table, use the "view" option in the options attribute of the ColumnOption tag. For example:

   ```xml
   <ArrayOptions index="0" options=";volatile;view=1000;directView=2802;onlyFilteredDirectView">
   <ColumnOption idx="0" pid="1601" type="custom" value="" options=";view=1001" />
   <ColumnOption idx="1" pid="1631" type="custom" value="" options=";view=1031" />
   ```

   This example looks at the DMA ID/element IDs specified in the column with parameter ID 2802 and then builds a view from table 1000 of the source elements and displays columns of the source element with parameter ID 1001 and 1031.

   Direct view tables are used to aggregate data from different source elements. In large setups, however, this can result in very large amounts of data in the direct view to be displayed, which has a big impact on the SLElement process (e.g. when opening the card, this results in requesting the entire direct view). For this reason, the "onlyFilteredDirectView" option was introduced, indicating that data from this direct view can only be retrieved through the use of filters. Consequently, when the "onlyFilteredDirectView" option is specified, the displayed directView table will be empty when opening the data page. However, when filters are used (e.g. EPM element, Visio, tree control children), the table displays the filtered result.

1. Create a view using data and keys from the aggregator element and data from the source elements.

   - Example 1: Use all element IDs specified in 2802 (possible since DataMiner version 7.5):

     ```xml
     <ArrayOptions index="0" options=";volatile;view=1200">
        <ColumnOption idx="0" pid="24101" type="custom" value="" options=";view=1201"/>
        <ColumnOption idx="1" pid="24102" type="custom" value="" options=";view=:2802:1000:1"/>
        <ColumnOption idx="2" pid="24103" type="custom" value="" options=";view=:2802:1000:31"/>
        <ColumnOption idx="3" pid="24104" type="custom" value="" options=";view=1204:2004"/>
        <ColumnOption idx="4" pid="24105" type="custom" value="" options=";view=1204:2202"/>
     ```

     In example 1 above, there is a table (ID 1200) in the aggregator element that contains primary keys (parameter ID 1201) and a foreign key (parameter ID 1204) to a parent table (ID 2000) (which contains a column with parameter ID 2004). Table 2000 in turn contains a foreign key to table 2200 (which contains a column with parameter ID 2202).

     Column 2802 contains the DMA ID/element IDs of the child elements.

     The view column 24101 will contain all the values of the column with parameter ID 1201 of the aggregator element itself.

     The view columns 24102 and 24103 will contain the values of the columns with index 1 and 31 of table 1000 of the source element where the primary key matches the value in parameter 1201 in the aggregator element.

     In other words, rows in table 1000 of the element will not be displayed if the primary key does not exist in the aggregator element.

     The view columns 24104 and 24105 will contain the value of the columns with parameter ID 2004 and 2202 respectively. This is possible because table 1200 contains foreign keys to table 2000 and table 2000 contains foreign keys to table 2200.

   - Example 2: Use a couple of element IDs specified in 2802:

     ```xml
     <ArrayOptions index="0" options=";volatile;view=1200">
       <ColumnOption idx="0" pid="24101" type="custom" value="" options=";view=1201"/>
       <ColumnOption idx="1" pid="24102" type="custom" value="" options=";view=:2802:1000:1"/>
       <ColumnOption idx="2" pid="24103" type="custom" value="" options=";view=:2802:1000:31"/>
       <ColumnOption idx="3" pid="24104" type="custom" value="" options=";view=1204:2004"/>
       <ColumnOption idx="4" pid="24105" type="custom" value="" options=";view=1204:2202"/>
     ```

     In example 2 above, there is a foreign key relation between one of the upper tables that 1204 is referring to and the table that contains the column with parameter ID 2802.

     Note that in the aggregator element where the parameters of the columns still need to be created, the duplicateAs option cannot be used because there is no base parameter.

     The table in the source element that the view is based on does not have to be a real table, a child element view table is also possible.

     The element ID of the aggregator element can also be in the table with the element IDs, this way it is possible to build a system consisting of equal peers without having one vulnerable master element.

     In the second scenario where the data is based on foreign key relations, the aggregator element needs to know the primary keys of the child element and the foreign key link to be able to build the view and use this relation in e.g. a tree view, EPM interface, etc.

     It is not possible to have a column in the table of the child element that refers to a table in the aggregator element without the aggregator element being aware of primary keys and foreign keys.

     In order to be able to perform settings on a direct view table, the “SetOnTable” option is needed in the ColumnOption tag.

> [!NOTE]
>
> - In case the tables of the source elements can have conflicting primary keys (i.e. it is possible that at least two source elements each have a row with the same primary key), use a column of type "viewTableKey" (see viewTableKey). This will prefix the primary key with [DMA ID]_[Element ID]_.
> - For direct view tables, it is not possible to include a column without the preceding columns being included.
> - Prior to DataMiner 9.5.7, direct view tables were not automatically refreshed in Cube. However, in DataMiner 9.5.7 (RN 16999), an update mechanism has been added to refresh these tables. When the update mechanism is used, this will be indicated below the table, together with the time when the table was last updated and a button that allows you to update the table manually.

## Updating direct views showing data from elements on remote agents

From DataMiner 10.0.12 (RN 27547) onwards, DirectView updates are supported in the following scenarios:

- DirectView based on a view of the same protocol.

  Example:

  ```Protocol: view=200;directView=905 table config;view=201 column config or view=211:305```

- DirectView based on a view of the same protocol with a single element source.

  Example:

  ```
  directView=6298

  Pointing to a standalone parameter rather than a column parameter
  ```

- onlyFilteredDirectView based on a view of the same protocol

  > [!NOTE]
  > onlyFilteredDirectView will only return data when a filtered subscription is made on the DirectView.

- DirectView based on a different protocol

  Example:

    ```filterChange=DirectViewColumnID A-RemoteDataColumnID A, DirectViewColumnID BRemoteDataColumnID B, ...```

- DirectView based on a different protocol with a filter specifying the element sources to be included.

  Example:

    ```directView=6505 => FILTER: value=6501 == REMOTE-DATA-1```

> [!NOTE]
> From DataMiner 10.0.13 (RN 27785) onwards, updates are also sent to subscribers for direct views when cell alarm levels in the source data tables change because of updates that do not change the cell value (e.g. when a cell in a source table gets masked).
>
> Note that this functionality does not work yet for foreign key linked tables where certain columns are also exported.

## Allowing different remote element sources in view table columns

From DataMiner 10.2.4 onwards (RN 32579), it is possible to have multiple sets of elements referenced by different columns within the same view table.

In the following example, parameters 201 and 301 each contain a list of remote elements, and both can be used within the same view table (in different ColumnOption tags).

```xml
<ColumnOption idx="3" pid="2004" type="retrieved" options=";view=:201:1000:3"/>
<ColumnOption idx="4" pid="2005" type="retrieved" options=";view=:301:1000:4"/>
```

## Creating a direct view table with table columns of different protocols

From DataMiner 10.2.9 onwards (RN 33253), it is possible to a create a direct view table with table columns of different protocols. For more information, refer to [CrossDriverOptions](xref:Protocol.Params.Param.CrossDriverOptions).
