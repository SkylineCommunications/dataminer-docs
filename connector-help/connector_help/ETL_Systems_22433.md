---
uid: Connector_help_ETL_Systems_22433
---

# ETL Systems 22433

The ETL Systems 22433 is an L-band hybrid splitter and combiner shelf designed to power and reference VSAT terminals, as well as facilitate the use of multiple modems.

This connector can be used to monitor and control the device via SNMP. The connector layout is designed to be as similar as possible to the web interface of the device.

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
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default value: *public*).
- **Set community string**: The community string used when setting values on the device (default value: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product

## How to use

The element created with this connector consists of the following data pages:

- **General**: This page displays information on the Module Status, Supply Voltages and Currents. It contains for example the **LNB Status**, **24V BUC Status**, **TX/RX Amplifier** and **18V PSU1 Status**.
- **Configurations**: On this page, you can configure settings such as the **Polling time**, **RF Power Limits** and **Traps IP Destination** address, as well as **enable or disable traps** on the device.
- **Web Interface**: This page provides access to the web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
