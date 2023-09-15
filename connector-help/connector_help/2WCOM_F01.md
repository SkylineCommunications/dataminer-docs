---
uid: Connector_help_2WCOM_F01
---

# 2WCOM FM01

The 2wcom FlexMon FM01 FM monitoring receiver combines demodulation, source-switching and FM/RDS parameter measurement/monitoring functionality. Its dual inputs can receive FM signals for rebroadcasting, monitoring, backup and alarming scenarios. An internal switch matrix changes between the inputs triggered by several states.

This connector retrieves information from the device via SNMP.

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
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: This is not required.

SNMP Settings:

- **Port number**: 161
- **Get community string**: public
- **Set community string**: private

## How to use

The element consists of the following data pages:

- **General**: Displays general parameters such as the delta frequency and M/MPX signal. Also allows you to set the **Polling Mode** to either *VMA* or *FM01*.
- **Tuning**: Contain the Station Table as well as information such as the current station and frequency.
- **Alarms**: Displays the current state (*OK* or *Alarm*) of several monitored parameters.
