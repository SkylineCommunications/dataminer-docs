---
uid: Connector_help_CEFD_CDM_750
---

# CEFD CDM 750

Advanced High-Speed Trunking Modem for network operators, enterprise users, and service providers requiring maximum throughput while using minimal satellite resources in point-to-point links. The CDM750 combines DVB-S2 modulation and coding with Comtech's DoubleTalkT Carrier-in-Carrierr and throughput maximizing Adaptive Coding and Modulation (ACM) technologies to optimize high speed satellite data links.

## About

This connector uses **SNMP** to retrieve information from the device and configure settings on the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.6.6                       |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*
- **Set community string**: The community string used when setting values on the device, by default *private*

## Usage

### General

This page displays general information about the device.

### Admin - SNMP

This page contains SNMP information, such as the **Contact**, **Name**, **Location**, **Trap IP**, etc.

### Config - Modem

This page contains modem configuration settings for **DVB-S2 Transmit/Receive frames**, DoubleTalkT **Carrier-in-Carrier** and Adaptive Coding and Modulation (**ACM**).

### Config - Utilities

This page contains the **Date & Time**, **Clock** frequency, **Redundancy Control** and **Firmware Image** settings.

### Config - Test

This page contains **Test Mode** configurations.

### Config - LNB

This page contains **Low-Noise Block Down Converter** (LNB) configurations.

### Status

On this page, you can find status information regarding **Alarms**, **ACM**, **CnC**, **Receiver** parameters and **Redundancy** switch.

### Status - Logs

This page contains an events log in the **Events Overview** table, along with the corresponding **Alarm Settings**.

### Status - Info

This page displays general status information.

### Status - IP Statistics

This page displays IP sent/received packets statistics.

### Status - BB Statistics

This page displays **Baseband** framing statistics.

### Interfaces - Ethernet/PIIC

On this page, you can find the OC3 and G.703 interfaces configurations table.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
