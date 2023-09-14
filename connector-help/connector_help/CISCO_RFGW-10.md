---
uid: Connector_help_CISCO_RFGW-10
---

# CISCO RFGW-10

With this connector, you can monitor the **Cisco RF Gateway 10**. The gateway allows concurrent support for standard and high-definition digital broadcast television, switched digital video (SDV), video-on-demand (VoD), and DOCSIS modular cable modem termination system (M-CMTS) services.

## About

This **SNMP**-based connector is used to monitor and configure the **Cisco RF Gateway 10**.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General

This page displays general information regarding the CISCO gateway, such as **System Info** and **System Contact Info**.

### Interfaces

This page displays all interfaces and data rates.

### Up/Downstream

This page displays information related to the interfaces specific to the **Upstream Channels** and **Downstream Channels**. It also allows you to change configuration parameters for the channels.

### Environmental Monitor

This page displays the **Voltage** and **Fan Status**.

### QAM

This page displays all the information pertaining to the **QAM** channels.
