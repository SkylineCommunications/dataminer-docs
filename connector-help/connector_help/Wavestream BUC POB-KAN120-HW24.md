---
uid: Connector_help_Wavestream_BUC_POB-KAN120-HW24
---

# Wavestream BUC POB-KAN120-HW2

The Wavestream BUC POB-KAN120-HW24 connector can be used to monitor the following information via SNMP:

- Heartbeat control
- Status and fault information, statistics, and inventory management
- Alarms
- Mode and state control
- Power control
- Warning, non-latching, and latching fault thresholds

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | V1.16                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

This driver uses two Simple Network Management Protocol (SNMPv3) connections, one for SNMP GET and SET operations and one for traps.

#### SNMP Connection - Main

This SNMP connection is used for traps.

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device. e.g. 10.11.12.123.
- **Port:** 162.

#### SNMP Connection - Device

This connection is used to poll device parameters.

SNMP CONNECTION - DEVICE:

- **IP address/host**: The polling IP of the device. e.g. 10.11.12.123.
- **Port:** 161.

NOTE: For the connector to be able to poll information from the device, you will also need to fill in the **security level and protocol, user name, authentication password and algorithm, and encryption password and algorithm** in the **More SNMP Settings** section during element creation.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element displays information about the Wavestream BUC equipment such as inventory data, equipment status information, sensors data, configuration information, trap thresholds, and the history of the received traps.

On the **Configuration**, **Stream** **Control**, **NTP & Trap Configuration**,and **Traps Thresholds** pages, you can configure parameters to set up the device.

To activate alarm monitoring and trending, you will need to create and assign and alarm and trend templates.
