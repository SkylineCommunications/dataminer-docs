---
uid: Connector_help_Marlink_Geofence
---

# Marlink Geofence

This connector can be used to subscribe to two parameters of any element in the DMS and view their current value. Furthermore, with KML processing you can check whether these values are inside or outside of a particular area.

## About

The connector allows the user to create entries in a **Remote Elements Configuration Table**. For the creation of an entry, the user can choose one of the available protocols in the DMS, a protocol version and an element using that protocol. Lastly, the user can select two parameters from this element of which the current values are to be monitored. For each entry in the **Remote Elements Configuration Table**, one or more rows can be created in the **Remote Status Table**.

An entry in the **Remote Status Table** shows the current values of the two parameters, but also allows the user to select a KML file. If the two parameter values represent latitude and longitude values, the KML file can be used to check whether the current latitude/longitude combination is inside or outside of the boundaries defined in the KML file. Based on the Inside/Outside setting in the table, an alarm is generated if the values are not inside or outside of the boundaries.

## Ranges of the connector

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration of remote elements

#### Remote Elements Configuration Table

In order to add a new row to this table:

1. Click the **Provisioning** button. A pop-up page will open.
1. Select the protocol and protocol version
1. Select the element.
1. Select the first and second parameter.
1. Select the KML file to use.
1. Click the **Add Elements** button.

You can add multiple elements at once using "\*" and "?" wildcards. Except for the description, the rows can no longer be modified after creation. If changes have to be done to a particular row, that row has to be deleted and recreated.

#### Remote Elements Status Table

For each element in the configuration table, one row is automatically created in this table.
In order to create a new row in this table, right-click a row in the table and select **Duplicate** in the context menu.

If changes need to be made to the rows after creation, this can also be done in this table.

For KML processing, a KML file can be selected in the row; however, make sure that the KML files are added to the **KML Browser Table** (see **KML Browser** page button underneath the **Status table**). KML processing requires that **Value Param 1** and **Value Param 2** represent respectively latitude and longitude values. When **Inside/Outside** is set to *Inside*, **KML Status** will display *Geofence OK* if the coordinate is inside at least one of the boundaries defined in the KML. If not, **KML Status** will indicate *Geofence Alarm*. When **Inside/Outside** is set to *Outside*, the coordinate has to be outside all boundaries, otherwise **KML Status** will display *Geofence Alarm*.

#### KML File Browser

In order to add KML files, first set the **KML Folder Path** with the correct path where they are stored. You can then add the files one at a time, or all at once:

- In order to add one KML file at a time from the folder, choose each file separately in the **Select KML File** drop-down list, and click the **Add Selected File** button.
- In order to add all the KML files in the folder at once, click the **Add Folder** button.

## Usage

### General

This page displays the **Remote Element Status Table**. Entries in this table represent remote elements that have been created using the **Remote Element Configuration Table**. For more information on how to add a row to these tables, refer to the section "Configuration of remote elements" above.

The **Remote Description** column is used in order to assign a meaningful name to the remote element, which will also be displayed in the Alarm Console when an alarm is generated for this row. This does imply that the description has to be unique. The table also displays the current values of the parameters, as well as the chosen KML file and its status. When the **Inside/Outside** option is set to *Outside*, Geofence Alarms are shown when the coordinate is inside the boundaries defined in the selected KML file, and vice versa; however, this is only the case if **param 1** is a latitude value and **param 2** is a longitude value. These alarms will also contain the selected **Inside/Outside** option. If the KML file is unavailable, this will be indicated in the **KML Status**.

The page button at the bottom of the page links to the **KML File Browser**, which displays the **KML File Status** (*available* or *unavailable*) and allows you to add KML files. The table is automatically refreshed every 10 minutes, but can also be refreshed manually with the **Refresh button**.

### Configuration

With the **Remote Elements Configuration Table** on this page, remote elements can be created, as described in the section "Configuration of remote elements" above. In order to enable the creation of remote elements for any of the elements in the DMS, information is obtained about the available elements by means of hourly DMS polls. However, by means of the **Poll DMS button**, a DMS poll can also be forced at any time. Note that this query can take a while for large systems, so it is not advisable to do this often.

## Notes

- Only protocols that are assigned to elements can be selected in order to create a remote element in the **Configuration table**.
- The description in both the **Configuration** and the **Status table** is used in generated alarms and therefore has to be unique.
- This connector requires **DataMiner version 8** in order to work.
