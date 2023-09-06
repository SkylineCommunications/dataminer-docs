---
uid: Connector_help_British_Telecom_Global_Site_Load_Balancer
---

# British Telecom Global Site Load Balancer

This connector allows you to monitor and control an automatic global site load balancer managed by BT, which will determine which site is the active site.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                                                                    | **Based on** | **System Impact** |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | \- Initial version.- Load balancer table to check the active location and location status.- Control table for each server to start/stop it.- Functionality to export/import the host mapping table. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                     | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | British Telecom Unified Streaming Single Channel Failover | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: localhost
- **IP port**: 443
- **Bus address**: The proxy server has not to be bypassed, leave this field empty.

### Redundancy

There is no redundancy defined.

## How to Use

To be able to use the control table, you will need to fill in the **username** and **password** on the **Configurations** page.

In the **Host Mapping** Table, add the location name and IP address for each location. In the **Load Balancer** table, fill in the right Site URL for each location. If the location name is not filled in or if it is not filled in the Host Mapping table, the site status will become ***Not Listed***. On the **Import Host Mapping** page, you can import a **CSV file** to update the **Host Mapping** table. This is also available with the **Import Host Mapping** button just above this table.

You can enable or disable the URL checks and change the polling interval.The **Control** table gives you functionality to start and stop a server.

The **log** file is located in the **Documents** tab.
