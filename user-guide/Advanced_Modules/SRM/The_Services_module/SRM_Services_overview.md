---
uid: SRM_Services_overview
---

# Using the overview tab

The *overview* tab (from DataMiner 10.0.8 onwards) or *services* tab (prior to DataMiner 10.0.8) of the Services module lists all services in a dynamic, filterable list view with a default set of columns. The list can be customized as follows:

- To sort the items in the list by a particular column, click the header of that column. Click the header again to reverse the sort order.

- To filter which services are displayed in the list, click the filter icon for the column you want to apply a filter to and enter a filter in the box below the column header.

- To apply a custom column configuration, see [Creating a new column configuration](#creating-a-new-column-configuration).

## Creating a new column configuration

1. Right-click in the list header, and apply the following configuration as you see fit:

   - Select *Add/Remove column* and indicate which columns should be added or removed.

   - Select *Alignment* and then choose a different text alignment for the columns.

   - Select *Change column name* and specify a new column name.

   - Select *Manage column configuration* (from DataMiner 10.0.4 onwards) or *Add/Remove column* \> *More* (up to DataMiner 10.0.3) to open a window where you can do the following:

     - Show or hide a column by selecting or clearing its checkbox, or by selecting it and clicking *Show* or *Hide*.

     - Move a column up or down by selecting it and clicking *Move up* or *Move down*.

     - Up to DataMiner 9.6.13, a number of additional checkboxes are available for each possible column:

       - Select the *Icon* checkbox of a particular column to have its contents replaced by icons. From DataMiner 9.6.12 onwards, this option is supported for ID columns.

       - Select the *Color* checkbox of a particular column to visualize the cells in that column as colored blocks.

     - From DataMiner 10.0.0/10.0.2 onwards, for columns based on custom properties, you can instead select a different type (e.g. *Custom icon*, *Color*) in the *Column type* drop-down lists. For the default columns, the column type cannot be changed, except for the *Alarm count* column. The latter can be set to *Color* to display the count in a circle with the color of the highest severity.

     - In the *Filter by type* section, indicate which type of columns you want to choose from (services, properties and/or service profiles). This allows you to add additional service profile columns.

1. Right-click in the list header (or click the list’s hamburger menu) and select *Save current column configuration*.

    When the module is opened again, this column configuration will be displayed. If you do not apply this last step, the column configuration will be reset when the module is closed.

## Loading the default column configuration

- Right-click in the list header (or click the list’s hamburger menu), select *Load default column configuration*, and select the configuration you want to load.
