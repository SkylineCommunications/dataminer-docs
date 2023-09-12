---
uid: Connector_help_ETL_Systems_HUR-10
---

# ETL Systems HUR-10

The Hurricane L-band matrix is used to provide flexibility in the routing of antennas to receivers or modems, to allow remote routing of satellite signals to receivers or modems, and to help optimize the use of receiving capacity.

## About

This driver uses an SNMP connection to poll data from an ETL Systems HUR-10 device.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |
| 1.0.1.x              | DCF support.     | 1.0.0.4      | DCF               |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 6.22                   |
| 1.0.1.x   | 6.22                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *161*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

## How to use

The element created with this driver consists of the data pages detailed below.

### General

On this page, you can find the general **matrix overview** of the device, which allows you to set connections and lock or unlock input/output lines/columns.

### System

This page contains general **system information** and a list of buttons used to perform **global system operations** such as a reboot or initialization.

### Matrix Configuration

This page allows you to perform changes to the **matrix configuration settings**, such as defining the number of matrix inputs and outputs.

To submit configuration changes, use the **Set Configuration** button at the top of the page. However, note that this is not necessary for the Set Mode and Re-Route State parameters, as these settings are applied immediately.

### I/O Settings

This page contains two tables (one for the matrix inputs and one for the outputs), which allow you to perform changes to the matrix system, such as changing the input/output labels or defining I/O connection route blocking.

NOTE: The "Output Allowed" setting is the only blocked setting that will be synchronized with the device (route blocking). The "Input Allowed" setting will only affect DataMiner and will not be synced with the device, as this functionality is not supported by the device.

### Web Interface

This page can be used to access the device web user interface. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
