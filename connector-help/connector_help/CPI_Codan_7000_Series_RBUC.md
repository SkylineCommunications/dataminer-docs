---
uid: Connector_help_CPI_Codan_7000_Series_RBUC
---

# CPI Codan 7000 Series RBUC

CPI Codan 700 Series RBUC is block upconverter that is typically used for rapid deployments or offshore applications. This connector is built based on the native web UI.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3.22                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection - Main

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

On the **General** page of the connector, you can find device data such as the Model Number, Serial Number, and Firmware Version. This page also contains status data.

The **Main Settings** page contains configuration parameters.

The **Auxiliary Settings** page contains network interface data.

On the **Faults** page, you can see the status of (current and latched) faults.
