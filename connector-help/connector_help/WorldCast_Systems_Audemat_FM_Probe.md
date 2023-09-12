---
uid: Connector_help_WorldCast_Systems_Audemat_FM_Probe
---

# WorldCast Systems Audemat FM Probe

The Audemat FM Probe is an FM monitoring solution to perform signal analysis, on site or in the coverage area. It can monitor up to 50 channels sequentially and up to 8 channels continuously.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

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

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string is used when reading values from the device (default: *public*).
- **Set community string**: The community string is used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

SNMP calls are used to retrieve the device information. SNMP traps can be retrieved when this is enabled on the device.

On the **General** page, you can find all the information you need about the WorldCast Systems Audemat FM Probe.

The **Channels** page contains basic information about the existing instances with all their readings values.

The **Alarms** page displays information about the status of the properties of the channels.

The **settings** pages like **Channel**, **RF**, **MPX**, **AF**, **AUX,** and **Pilot** allow you to set the monitoring information required for the channels.
