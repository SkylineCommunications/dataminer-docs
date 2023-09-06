---
uid: Connector_help_Nevion_Aggregator
---

# Nevion Aggregator

This driver will display the TSoIP SIPS and Buffer Summary rows from all Nevion NX4600 drivers in the DMS.

## About

With this driver, you can select which Nevions you want to include, and then build a consolidated TSoIP SIPS and Buffer Summary table for the selected elements.

### Ranges of the driver

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection

This driver uses a virtual connection and does not require any input during element creation.

## How to use

This driver only contains one page, the General page, which displays the **TSoIP SIPS and Buffer Summary**, **Element Configuration**, and **Elements** tables.

The **Element Configuration** table displays all Nevion NX4600 elements, with an **Add Element** button that can be used to add the current row's EID/DMAID to the **Elements** table. After you click the **Add Element Keys** button, that element will be included in the SIPS table.

There is also a **Refresh Elements** button, for elements that have been added since the driver started up. A restart of the element also will cause a refresh.

To add an element:

- Click **Add Element** for the element you want to add in the **Element Configuration** table.
- Click **Add Element Keys** for the newly added element in the **Elements** table.
