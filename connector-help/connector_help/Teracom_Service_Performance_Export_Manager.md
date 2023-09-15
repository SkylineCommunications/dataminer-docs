---
uid: Connector_help_Teracom_Service_Performance_Export_Manager
---

# Teracom Service Performance Export Manager

This is a virtual connector that exports information from cleared alarms to .csv files.

## About

This connector collects information from cleared alarms of the desired elements, and exports this information to .csv files.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

Not applicable. This is a virtual connector, which does not interact with an actual device.

### Linked connectors

| **Name**                  | **Range** |
|----------------------------------|-----------|
| Teracom Service Overview Manager | 1.0.0.x   |
| Bridge Technologies VB220        | 3.2.0.x   |
| Miranda Kaleido X                | 2.0.0.x   |
| Miranda Kaleido IP X310          | 1.0.0.x   |

## Installation and configuration

### Creation

This connector uses a **virtual** connection and does not require any input during element creation.

### Configuration of Service Overview Manager Element

After you have created the element, select the **Service Overview Manager element** to interact with. On the general page, there is a drop-down list with the available elements. Until this configuration is done, the element cannot process anything.

## Usage

### General

This page contains most of the settings and information of the connector.

This first parameter, **Last Sync Time**, contains the date when the alarms were last gathered.

Next, there are two parameters that can be used to configure the export settings:

- With **Export Files Folder**, you can select the folder where the export files will be stored. The default value is: *C:\Skyline DataMiner\Documents\Teracom Service Performance Export Manager*.
- With **Export Period**, you can select the period of time when the exports are done. If you select a large period, the export files will be larger, but there will be fewer export files in total. If a shorter period is selected, the export files will be smaller, but there will be more of them. You can select a value between 1 and 48 hours (default value: 48 hours). You can also disable the export by clicking the **Disabled** check box for the **Export Period** parameter.

If alarms are being processed, the parameters **Processing Task** and **Processing Alarms Percentage** indicate what is being processed and the actual status of the processing task. This operation can take some time (minutes) depending on the number of alarms present in the system.

Finally, this page also displays a table with all elements that cleared alarms are gathered from. This list is gathered from the element configured in the parameter **Selected Service Overview Manager Element**.

### Cleared Alarms

This page displays a table with the cleared alarms that have not yet been exported. Alarms are exported depending on the value of the parameter **Export Period**. When alarms are exported, they are removed from the table, and new alarms are fetched from the date on the parameter **Last Sync Time** until the current date. After this, the parameter **Last Sync Time** is updated with the current date.

On this page, there are two buttons:

- **Manual Export:** Clicking this button generates an export file with the current table content (if any exists). This button does not affect the normal export period. If, for example, the last export is done at 10:00 and the **Export Period** is set to 1 hour, if you click the button at 10:30, an export file is generated, but at 11:00 another export file will be generated.
- **Refresh Alarms:** Clicking this button will gather all cleared alarms since the **Last Sync Time** until the current date, but it will not export them.
