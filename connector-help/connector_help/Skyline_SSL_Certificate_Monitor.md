---
uid: Connector_help_Skyline_SSL_Certificate_Monitor
---

# Skyline SSL Certificate Monitor

This connector allows you to monitor the status of SSL certificates of websites. You can add, update, and delete sites, and you can specify how often the status of the certificates should be updated.

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                                             |
|-----------|------------------------------------------------------------------------------------|
| 1.0.0.x   | Virtual Driver System.Security.Cryptography.X509Certificates .Net Framework v4.6.2 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

## How to Use

Use the **Add Site** button to add a new site to the table. This will create a row for a site with the URL specified in **New Site URL**.

Use the **Refresh** button on a site row to update the site information.

Use the **Delete** button for a site to remove it from the table.

Use the **Sites Refresh Interval** to determine how often the table information should be updated.
