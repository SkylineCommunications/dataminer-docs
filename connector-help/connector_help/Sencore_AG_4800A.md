---
uid: Connector_help_Sencore_AG_4800A
---

# Sencore AG 4800A

Sencore AG 4800A is a high-density modular frame designed to accommodate up to 20 cards of the openGear Multi-Definition product family.

## About

This connector contains information about the frame and the installed cards. However, because of the way the MIB is constructed and the way Sencore handles each of the cards, it is not possible to control them from within this connector. Instead, individual elements representing the cards can be created if the appropriate protocols are available.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays general information about the frame, such as the **Version**, **Location**, **Contact**, etc.

### Cards

This page displays the active cards available in the frame. The **Slots** table displays the position of each card that is connected. Note that some cards will use two slots.

### Status

This page displays the **Status** and the **Information** of the frame. You will also find **Fan** and **Data Safe** information here.

### Power Supply

This page displays the **Power Supply** information of the frame.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
