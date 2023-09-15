---
uid: Connector_help_Cox_LLDP_Manager
---

# Cox LLDP Manager

This connector gathers data from elements with LLDP data and generates DCF connections between those elements.

## About

### Version Info

| **Range**            | **Key Features**     | **Based on** | **System Impact** |
|----------------------|----------------------|--------------|-------------------|
| 1.0.0.x              | Initial version      | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Remote file handling | 1.0.0.x      | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

## How to use

To use this connector, you need to configure the elements from which you want to poll LLDP data. On the **LLDP Protocols** subpage, you can use the right-click menu to add rows for these elements.

When the elements and provisioning configuration is complete, you can poll the local DMA for LLDP tables. Based on this, the LLDP Manager will make sure the DCF connections are provisioned.

The **LLDP Manager** also exports an RPD topology CSV file for the **Cisco CBR-8** connector to ingest and fill the RPD Topology table.
