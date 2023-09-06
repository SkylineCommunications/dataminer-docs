---
uid: Connector_help_SES_S.A._SSG_Report
---

# SES S.A. SSG Report

The SES S.A. SSG Report driver gathers data from selected elements in a DMS and displays the values in a table.

## About

### Version Info

| **Range**            | **Key Features**                                           | **Based on** | **System Impact**         |
|----------------------|------------------------------------------------------------|--------------|---------------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                                           | \-           | \-                        |
| 1.0.1.x \[SLC Main\] | Added option to include/exclude parameters in/from report. | 1.0.0.1      | Requires new SSG reports. |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this driver has only one data page, the **General** page. This page contains the **Element Monitoring** table, which must be filled in with information on the elements from which data should be gathered, primarily the **Element Name** and **Parameter ID**.

To add rows, right-click the table and select **Add item** in the context menu. You will then be able to enter a **Custom Name** for the new row, describing the data to be polled. Via the context menu, you can also **duplicate a row** or **delete a row**.

If you wish to exclude a certain parameter from the report, you can use the **Include in Report** column for this purpose. Thiscolumn indicates whether or not the value will be included in the report.

At the top of the page, the **Poll Information** button can be used to poll the data for all rows at once.

At the bottom of the **General** page, the **Import/Export** page button can be used to open a window where you can export or import a .csv file. At the top of the subpage, you can specify the path where the file can be found. Below this, the **File Name Of The CSV** drop-down box allows you to select the file. You can refresh this drop-down list manually using the **Refresh Files** button.

## Notes

In order to automatically poll the data, a Scheduler task and Automation script are required.

The frequency when data should be gathered can be set in the Scheduler task, and the Automation script only has to set the **Poll Information** button of the driver to any value.
