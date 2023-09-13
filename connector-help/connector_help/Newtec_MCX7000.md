---
uid: Connector_help_Newtec_MCX7000
---

# Newtec MCX7000

The Newtec MCX7000 is a DVB-S2X multi-carrier satellite gateway. This driver allows you to monitor and configure this device via SNMP.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.0.0.66822            |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

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

### Configuration

This driver has QActions that use System.Net.WebUtility.htmlDecode(), which requires **.NET framework 4 or higher**. Make sure this is installed before you use the driver.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this driver consists of the following data pages:

- **Management/Data Interfaces**: These pages contain multiple tables that allow you to monitor and configure parameters related to the management/data interfaces. This includes alarm information.
- **TS Over IP Input/Output**: These pages contain multiple tables that allow you to configure and monitor TS over IP input/output parameters. There is also a Counter Reset button, which resets the packet counters.
- **TS Connectivity**: Contains a table that allows you to configure TS connectivity.
- **Multistream TS Input/TS Rate Adapter**: Both of these pages contain three tables, related to configuration, monitoring and alarms, respectively. The Multistream TS Input table also has a Counter Reset button, which resets the packet counters.
- **TS NIT Carrier ID**: Contains a table that allows you to configure the TS NIT carrier ID.
- **TS Signaling**: Contains two tables, related to configuration and alarms, respectively.
- **TS PRBS Probe**: Contains two tables, related to configuration and monitoring, respectively. There is also a Counter Reset button, which resets the packet counters.
- **TS Analyzer**: Contains multiple tables that allow you to monitor and configure the TS analyzer. This includes alarm status information, and a Counter Reset button.
- **TS Redundancy**: Contains configuration, monitoring and alarm tables related to TS redundancy. Polling for these parameters can be enabled or disabled.
- **Modulator/Demodulator**: These pages contain multiple configuration, monitoring and alarm tables.
- **Alarm**: Contains multiple tables where you can monitor and configure alarm parameters. A Reset Counters button is also available.
- **ASI Input**: Contains configuration, monitoring and alarm tables related to ASI input.
- **MPE Encapsulation/Decapsulation**: These pages contain multiple configuration, monitoring and alarm tables related to MPE encapsulation/decapsulation.
- **Reference Clock**: Allows you to monitor several parameters related to the reference clock, including signal and lock alarm parameters.
- **Device**: Contains numerous parameters for the identification of the device, its location, operator identification, front panel, etc. You can also enable or disable automatic saving of the configuration and monitor several status parameters such as the temperature and CPU load. Via page buttons, more detailed information and additional settings are available.

## DataMiner Connectivity Framework

The **1.0.0.x** driver range of the Newtec MCX7000 protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- L-Band Output: interface type **out**.
- IF-Band Output: interface type **out**.

#### Dynamic interfaces

Physical dynamic interfaces:

- ASI Input: interface type **in.**
- IP: interface type **inout**.
