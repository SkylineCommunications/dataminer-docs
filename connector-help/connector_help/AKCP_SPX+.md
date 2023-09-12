---
uid: Connector_help_AKCP_SPX+
---

# AKCP SPX+

The AKCP SPX+ is an **SNMP** probe that can have several sensors attached to it. This connector allows you to monitor this device.

Multiple sensors of different types can be attached to the unit. The value of the sensors will by default be retrieved every minute. However, note that this can be adapted using the **Timer Base** parameter.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | SPX+ F7 1.0.5489       |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.* While this is currently not yet used in the connector, we recommend adding the correct value, so that it is already configured for possible future updates.

## How to Use

The connector contains several pages showing sensor values for:

- Temperature
- Humidity
- Dry Contact
- Current
- DC Voltage
- Air Flow
- Motion
- Power
- Fuel
- Water Sensor
