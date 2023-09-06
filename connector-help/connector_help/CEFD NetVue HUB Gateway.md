---
uid: Connector_help_CEFD_NetVue_HUB_Gateway
---

# CEFD NetVue HUB Gateway

The CEFD NetVue HUB Gateway connector is used to poll information about the remote devices from the NetVue system.

In the NetVue system, the information is located in an element using the **CEFD HTO SNMP** connector. The information is then forwarded to the **CEFD NetVue Remote Gateway** elements.

The hub gateway elements are automatically created by the **CEFD NetVue Manager** element and must not be created manually.

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

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                        | **Exported Components** |
|-----------|---------------------|-------------------------|--------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | CEFD NetVue Manager CEFD NetVue Remote Gateway CEFD HTO SNMP | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

## How to Use

To be able to retrieve data, the parameters displayed on the **General** page must be filled with correct values:

- **User Name**: The user name needed to access the NetVue system.
- **Password**: The password needed to access the NetVue system.
- **DMS Element ID**: The ID of the element in the NetVue system from which the data will be polled. The element uses the **CEFD HTO SNMP** connector.

These parameters are filled in automatically by the manager when the hub is created.

The **Remotes** page list all the remote devices detected in the NetVue system by this hub.
