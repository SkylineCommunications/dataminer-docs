---
uid: Connector_help_SES_S.A._Monics200_DB
---

# SES S.A. Monics200 DB

This driver requests carrier data from a database and displays this data in a table.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection

This driver uses a virtual connection and does not require any input during element creation.

## How to Use

A query is executed to retrieve the carrier data from the database.

No data traffic will be seen in the **Stream Viewer**.

On the **General** page, the **Database Connection** data must be filled in.
On the **Carrier Measurements** page, the **Satellite** and **Plan Name** must be filled in. The **Carrier Polling Status** must be set to *Enabled*.

You can add presets to the **Alarm Presets** table and remove presets from this table via the **Delete** button in the Delete column.

The carrier data requested by the query is filled in in the **Carrier** table on the Carrier Measurements page. You can set an alarm preset in the **Alarm Preset** column of the Carrier table. The possible values are taken from the **Alarm Presets** table.
