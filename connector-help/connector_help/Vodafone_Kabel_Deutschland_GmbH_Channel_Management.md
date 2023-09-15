---
uid: Connector_help_Vodafone_Kabel_Deutschland_GmbH_Channel_Management
---

# Vodafone Kabel Deutschland GmbH Channel Management

This connector will retrieve data from the Channels and Services tables in a DOM database and display them accordingly. If the database has not been created yet, the connector will create it.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

No connections need to be configured for this connector during element creation.

### Initialization

To use this connector, make sure the following Automation scripts are installed on the DataMiner Agent:

- InitializeVodafoneChannelManagementDomDatabase
- RefreshVodafoneChannelManagementDomTables

### Redundancy

There is no redundancy defined.

## How to use

Once the element has been created, the Channels and Services tables should be automatically refreshed with the most recent data.

While this data is periodically refreshed, you can also force a refresh with the "Refresh \[Table Name\] Table" button, which is located above each table.
