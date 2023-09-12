---
uid: Connector_help_SSIMWAVE_Central_API
---

# SSIMWAVE Central API

This connector allows you to check information provided by a SSIMWAVE device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Device address**: If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

To view information with this connector, on the **General** page, specify the **Client ID** and **Client Secret** and click **Authenticate**. Below the Authenticate button, the authentication status will be indicated: *OK* if the authentication succeeded, or *Fail* otherwise. The connector includes a 1-hour timer to authenticate automatically, as the device only gives a 1-hour authorization for an authenticated user.

### Redundancy

There is no redundancy defined.

## How to use

Once the authentication is done (see "Initialization" section above), this connector displays the retrieved information in three tables: **Video**, **Audio** and **Alerts**. Each table shows the real-time available services assigned to a specific operator.

Trending and alarm monitoring can be configured on the numeric information in the Video and Audio tables. For the Alerts table, alarm monitoring can be configured on the severity and type columns.

To receive the table data, the driver uses a 30-second timer.
