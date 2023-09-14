---
uid: Connector_help_Newtec_EL470_SNMP
---

# Newtec EL470

The EL470 is a state-of-the-art satellite modem designed for the transmission and reception of IP streams over satellite in full compliance with the DVB standards. The EL470 modem connects directly to terrestrial IP network infrastructures via a dual auto-switching Gigabit Ethernet interface

## About

This SNMP-based connector is used to monitor and configure the **Newtec EL470**.

### Version Info

| **Range** | **Description**  | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version. | No                  | Yes                     |

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
- **Device address**: The device address.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays general parameters related to the device, such as **RMCP Version** and **Operating Mode**. It also contains page buttons leading to the following subpages:

- Display
- Power Supply
- Device Info
- SNMP
- Web
- External
- Misc
- Serial

### Ethernet

This page contains parameters related to the **Ethernet interface** and the **Ethernet transmitter and receiver** of the device. It also contains page buttons leading to the following subpages:

- Interface A
- Interface B
- Packet Generator
- Packet Monitor

### Modulator

This page displays among others the **Symbol Rate** and **Gain Control Mode**. The following information can also be found here:

- Demodulator Table
- DVB-S2 Streams
- Statistics
- PHY
- Frames
- Packets

### Demodulator

This page allows you to view and set the **Input Selection** and **Receive Frequency**, among other parameters. It also provides access to statistics.

### IP Encap - Decap

This page displays the **Bridge Type** and **Vlan Support**, among other parameters. The following information can also be found here:

- XPE Statistics
- Ethernet Rx Routes
- VLAN
- QOS
- Demod Rx Routes

### ACM

This page displays the **Virtual ACM Client ID** and **ACM Control**., among other parameters. It also provides access to the following tables:

- Stream Table
- Demod Monitor Table

### Redundancy

This page contains parameters such as **Ethernet ltf Redundancy** and **Ethernet ltf Follows Gateway**.

### Alarms

This page displays all **Status** parameters and contains a number of commands that can be used to mask and clear alarms.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

### Tables

This page contains all the **Table** parameters.
