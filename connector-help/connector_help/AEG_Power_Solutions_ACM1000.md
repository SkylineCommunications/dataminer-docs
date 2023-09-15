---
uid: Connector_help_AEG_Power_Solutions_ACM1000
---

# AEG Power Solutions ACM1000

This protocol allows you to monitor the AEG Power Solutions ACM1000, which is a hot-pluggable, modular, flexible power system controller for DC power systems.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC MAIN\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.12 (ACM version)     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Initialization

No additional configuration is necessary.

### Redundancy

The connector does not include any redundancy options.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The connector uses **SNMP** calls to communicate with the device.

On the **Configuration** page, thresholds and limits can be defined.

## Notes

To prevent improper use, some of the settings require a **group security level of 4**. If a user with a lower security level accesses the element, they will only be able to read the values, but they will not be able to make any changes.
This applies to the following parameters: **Battery Capacity**, **Discharge Test Mode**, **Discharge Test Current**, **Battery Low Voltage Alarm Threshold**, **Battery Low Voltage Disconnect Threshold**, **Load LVDNE 1 Disconnect Threshold** and **Load LVDNE 2 Disconnect Threshold.**
