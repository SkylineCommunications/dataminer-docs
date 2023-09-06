---
uid: Connector_help_CPI_Codan_7000_Series_RBUC
---

# CPI Codan 7000 Series RBUC

CPI Codan 700 Series RBUC is Block-Up Converter ideally suited to rapid deploy or offshore applications. Driver is build based on Web UI.

## About

Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3.22                   |

System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection - \[SNMP Connection\]

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: \[he community string used when reading values from the device(default value if not overridden in the connector: *public*).
- **Set community string**: The community string used when setting values on the device
- (default value if not overridden in the connector: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

On the **General** page of the connector, user can see Device data (e.g Model number, Serial number and Firmware version). On General page use can fnd Status data.

The **Main Settings** page contains configuration parameters.

**Auxillary Settings** page shows Network interface data.

On the **Faults** page, user can see faults status (current and latched).

## Notes

This is driver based on SNMP connection.
