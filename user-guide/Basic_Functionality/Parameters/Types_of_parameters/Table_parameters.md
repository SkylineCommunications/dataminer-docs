---
uid: Table_parameters
---

# Table parameters

Different types of table parameters exist in DataMiner Cube, detailed in the sections below. Regardless of the type of table parameter, the following applies:

- In most tables, the leftmost column will show a **key icon** in the header. This indicates that this column contains the display key for each row, a unique identifier for the row. The display key is the human-readable counterpart of the row’s primary key.

- To the right of a table parameter, a bar with a \< icon is displayed. Click this bar to view a pane with details of the row selected in the table.

- To quickly **copy a table parameter** to a different application, e.g. Microsoft Outlook or Excel, right-click the table and select *Copy table*. If the table contains any hidden columns, a dialog box will appear where you can select whether these should be included as well.

- Columns with a **width of 0 are not displayed** by default. To display such a column, right-click the table header, and select the column in the context menu. This context menu also allows you to hide columns in the same manner.

- From DataMiner 10.0.6 onwards, the right-click menu of a table header allows you to **save a custom column layout**, which includes the width, position and visibility of the columns. The layout will be saved in your personal settings and applied to all elements using this same protocol. The right-click menu also allows you to reset the current column layout to the default layout.

- You can **export a table** by selecting the *Export table* option in the right-click menu. From DataMiner 10.1.5/10.2.0 onwards, a dialog box is then displayed that can have the following options, depending on the table configuration:

  - *Export location*: The file path where the export should be placed.

  - *Export options*: For partial tables, this allows you to select whether only the current page should be exported, or all pages.

  - *Include hidden columns*: Determines if hidden columns are included in the export.

  - *Include header names*: Determines if the names of the column headers are included in the export.

  > [!NOTE]
  > From DataMiner 10.2.0/10.2.1 onwards, if you apply a filter to a table before you export it, only the displayed rows will be included in the export.

## Text tables

A text table is a special type of read parameter that shows a data table in text format. It is also capable of displaying any block of text received from a device.

Users can select the tab-delimited text, copy it to the Windows clipboard, and paste it in email messages, documents, spreadsheets, etc.

## Dynamic tables

A dynamic table is a special type of parameter that is used to visualize and manage large data tables (e.g. SNMP tables).

Every column in a dynamic table is a parameter in itself. Cells in a column can be referenced by index.

> [!NOTE]
> The size of icons used in dynamic tables can be adapted in the file *Icons.xml*, with a maximum height of 20 pixels.

## Partial tables

A partial table is a large table that is split up into different pages, usually with 1000 rows per page (though different configurations are possible). Only one page is shown at a time, and you can navigate between the pages.

> [!NOTE]
> In a protocol, a partial table is configured with the [partial attribute](xref:Protocol.Params.Param.ArrayOptions-partial) of the Params.Param.ArrayOptions element.

## Direct view tables

A direct view table is a special kind of table that is used to aggregate data from different source elements. More information about direct view tables, see [View tables](xref:AdvancedViewTables).
