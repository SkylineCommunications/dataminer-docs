---
uid: Connector_help_Renkus-Heinz_Iconyx_R-II
---

# Renkus-Heinz Iconyx R-II

With this connector you can monitor the **Renkus-Heinz Iconyx R-II** loudspeaker via SNMP (based on the MIB file).

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 8.44                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Port number:** The port of the connected device, by default 161.
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element generated with this connector consists of the following data pages:

- **General**: Displays the main system information, including the **System Description**, with the full name and version identification of the system's hardware type, software operating-system, and networking software. It also displays the **System Up Time**, **System Contact**, **System Name** and **System Location**.
- **Summary Data**: Displays the status for Fault Relay, Alarm Pin, Remote Power, RS485 Mode, Mute and Slave 1, 2 and 3 Communications State.

  This page also contains the **Unit Table** page button, which displays a table with four rows, detailing status information for the Open Coil Speaker Driver, Amplifier Over Temperature, PSU Over Temperature State, D2 Amplifier State and PSU Voltages.

- **Status**: Displays status information for Remote Dial, 7-Segment Display State, connection and dots, AES/EBU Input, Ethernet Carrier Loss, Relay Default State, Signal Clipping, Polarity Inverted, AES and AES Locked, Analog One Input Pad and Alarm Pin Current State and Default State.
- **Delays**: Displays the time (in ms) of the Delay Right High, Delay Left Low, Delay Right Low, Delay Left High.
- **Individual**: Contains the Speakers and Individual tables. This first table shows the Speaker OpenCoil status for the master and 3 slaves.
- **Temperature**: Displays the Power Supply Temperature Low, Power Supply Temperature High, Amplifier Temperature Low and Amplifier Temperature High.

## Notes

During the connector implementation atypical behavior from the device was noticed. The only possible way to retrieve the SNMP values was by deleting the last .0 which is typically added in other SNMP connectors.
