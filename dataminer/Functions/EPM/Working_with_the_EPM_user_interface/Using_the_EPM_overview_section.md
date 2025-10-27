---
uid: Using_the_EPM_overview_section
---

# Using the EPM overview section

The overview section on the right-hand side shows more information on the selected object and chain. The displayed parameter data may come from polling or eventing, from aggregation or computation, or from the database. Aggregation allows data from the smallest devices in the chain to be aggregated in order to show information that is significant to the user, as determined by the protocol.

The way this information is represented depends on the protocol, and can be quite different:

- Data may be shown in a table.

  - For some chains, a table is shown as soon as you select the chain, for others you must first select an object in the filter section.

  - You can sort the table by clicking a column header.

  - To the right of each table is an expandable details pane, which can be used to view detailed information for a row selected in the table.

  - If you right-click a cell in a table, in the right-click menu you can select to copy the cell, the row, the column or the entire table to the clipboard.

  > [!NOTE]
  > By default, the table contents are copied with tabs as separator. However, you can use the alternative option *Copy table (csv)* to copy in CSV format.

- Data may be shown in a Visual Overview based on a Visio file.

  This can be edited in Visio like a regular Visual Overview. See [Visio drawings](xref:visio#visio-drawings).

- Data may be shown in a topology diagram, which is based on the protocol, not on a separate Visio file.

  - The topology diagram displays objects in a tree structure, based on data imported during provisioning. It is possible to double-click an item in the diagram to see what objects exist lower in the tree structure.

  - If you double-click an item in a tile list or details list, the item in question will be opened in the topology diagram.

  - If you right-click a node, the context menu allows you to copy the title of the node or the values in the node.

- There may be several tabs for a particular chain, for instance containing different tables, or a different visual representation.

> [!NOTE]
> Boxes in a diagram, list items, and tiles have a shortcut menu that allows you to open the selected item in another chain, to open the linked element, or to open a link in a pop-up window.
