---
uid: Connector_help_Apica_Synthetic_Monitoring_API
---

# Apica Synthetic Monitoring API

The Apica Synthetic Monitoring API connector displays the available checks of the corresponding system and allows you to configure how often the information for a particular check should be visualized.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1 x SLC-DMS-DRV-DEV-II |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host:** The Apica monitoring API requires the URL <https://api-wpm2.apicasystem.com/v3/Checks>.
- **IP port**: The default port is 443.

### Initialization

When you have created the element, specify the **username and password** on the **General** page.

## How to Use

The General page contains the **Available Checks** table, where you can enable or disable the polling for each check. You can also define the **Polling Speed** (range: 10 seconds to 1 day). If the Polling Speed has the value **N/A**, the check will **not be polled**.

## Notes

DataMiner stores the checks in the tables. This means that some checks on the Checks Results page will remain there even before the polling is set.
