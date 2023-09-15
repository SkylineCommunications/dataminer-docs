---
uid: Connector_help_SPX_FLOW_Delair_Etsiline_CommPact
---

# SPX FLOW - Delair Etsiline CommPact

The Etsiline CommPact is an air dryer with compact dimensions. This connector can be used to monitor and configure operational settings of this device.

## About

All parameters are retrieved via SNMP polling or via SNMP traps.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.03.01                     |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains relevant information about the operation of the device, such as **Runtime**, **System Phase** and **Valve Y3 Duty Cycle**.

It also includes **Pressure**, **Humidity** and **Dewpoint** sensor readings, which are updated every 10 minutes or whenever a corresponding SNMP trap is received.

Finally, it also contains information about the configuration of the **Sensors**, **Alarms**, **Runtime** and **Network**.

### Configuration

This page allows you to configure several **alarm** **settings** (**Pressure** and **Humidity** thresholds and hysteresis, **Compressor Runtime Alarm** and **Alarm Delay**), as well as **Date**, **Time** and **Network** settings.

### Test Status

This page displays the current status of device I/O components, including **Valve** and **Relay** positions and **Analog Input Voltage**.

### Web Interface

This page connects to the web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
