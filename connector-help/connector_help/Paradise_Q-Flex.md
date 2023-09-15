---
uid: Connector_help_Paradise_Q-Flex
---

# Paradise Q-Flex

Paradise Q-Flex is a satellite modem. This connector uses SNMP to communicate with this device.

## About

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|-----------|-----------------|---------------------|-------------------------|
| 1.0.0.x   | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | RC_0.0.60              |
| 1.1.0.x   | RC_0.1.31              |
| 1.1.1.x   | RC_0.1.31              |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device (default: public).
- **Set community string**: The community string used when setting values on the device (default: private).

## Usage

### General Information

This section has two pages: **General** and **Status**.

The **General** page provides general information like the firmware version, model number, serial number, etc.

Multiple subpages are available:

- **M and C**: Allows you to monitor and configure Radius server and remote M and C interface settings.
- **Alarms**: Allows you to monitor and configure the thresholds for the alarms and enable or disable them.
- **Station Clock**: Allows you to monitor and configure station clock settings.
- **SAF**: Allows you to enable or disable the software-activated features.
- **NTP**: Allows you to configure NTP settings.

The **Status** page contains information retrieved from the transmitter and receiver, with some configurable parameters that can also be found on the Tx/Rx Configuration page.

### Alarm Information

This page contains alarms from the device received via SNMP traps. To configure the traps, go to the SNMP page.

### Configuration

This section contains the following pages:

- **Tx Configuration**: Contains configurable parameters for the transmitters. On the subpages, you can configure automatic uplink power control (AUPC), bit rate error test (BERT), bit rate, dropped packets, errored packets, etc.
- **Rx configuration**: Contains configurable parameters for the receiver. On the subpages, you can configure framing, bit rate, dropped packets, errored packets, LinkGuard, etc.
- **ACM**: Contains settings to configure Adaptive Coding Modulation.
- **PCMA**: Contains configurable parameters for Paired Carrier Multiple Access.

### Networking Settings

This section contains the following pages:

- **IP**: Contains configurable network parameters. There are multiple subpages, to configure Receiver, Static IPv4 routes, etc.
- **Email**: Contains the email configuration for email notifications sent from device.
- **SNMP**: Allows you to configure the SNMP setup, including traps. This determines how the device will communicate with SNMP.

### Miscellaneous Information and Configuration

The section contains the following pages:

- **Redundancy**: Contains configurable one-to-one (1-1) and one-to-many (1-N) redundancy settings.
- **Test**: Contains settings that allow you to enable testing, e.g. simulating a delay, etc.
- **Other**: Contains a parameter to run a PUP command and additional configuration parameters.
