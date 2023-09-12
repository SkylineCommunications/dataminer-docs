---
uid: Connector_help_Advantech_AMT_VSAT_BUC_Redundancy_Controller
---

# Advantech AMT VSAT BUC Redundancy Controller

This driver can be used to monitor and control the Advantech AMT VSAT uplink (standalone or in redundancy) and downlink system. The controller must be connected to the uplink and downlink serial M&C port to provide all monitoring and control functions.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | BUC 216142-005 R7.0    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this driver consists of the following data pages:

- **General:** Displays the default information of the device.
- **Unit A-C**: Three pages to monitor and control each unit.
- **Uplink 1:1-1:2**: Two pages to monitor and control the type of **uplink** for the **BUC**.
- **Logs**: A page with the device logs.
- A **web interface** page.
