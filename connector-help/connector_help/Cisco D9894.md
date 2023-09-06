---
uid: Connector_help_Cisco_D9894
---

# Cisco D9894

This driver can be used to control and monitor the Cisco D9894 HD/SD AVC low-delay contribution decoder via SNMP

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | V04L132C01             |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

SNMP main connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Web interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The element consists of the data pages detailed below.

### General

This page displays general parameters related to the device, such as the Device Name, Hardware Location, System Contact, Device Date and Time, System Uptime and Software Information.

It also contains information regarding the system status such as the Data Port Status, Time Server Synchronization Status, Intercom Status, etc.

### Decoder

This page displays information about the decoder, including the decoder status, decoder statistics and decoder control parameters.

There are also page buttons that lead to the following subpages:

- **Outputs:**Contains information about decoder video/audio output, such as Initial Output Format, Concealment Time, etc.
- **DVB-ASI:** Displays DVB-ASI information, such asInput TS Packets, Received TS Packets, Video Decode Errors, etc.
- **Port Settings:** Displays information regarding decoder ports, such as Stream Local Port, Unicast Request Local Port, etc.
- **IP Settings:** Allows you to configure IP settings, such as Streaming Mode, Unicast ID, etc.
- **Audio:** Displays a table with specific audio information, such as codecs, rate, etc.
- **PID:** Displays information regarding PID settings, such as Mode, Service ID, PMT PID, Video PID, etc.
- **BISS:** Displays information regarding BISS settings, such as the BISS Encryption Method, Encryption Mode, etc.
- **Decoding:** Allows you to configure settings regarding the decoding mechanism, such as Error Concealment, Audio Passthru Adjustments, etc.

### System

This page displays system information, such as general settings, the **Log** table and the **Alarms** table.

There are also page buttons that lead to the following subpages:

- **Intercom**: Contains intercom information and settings, such as Received Packets, Discarded Packets and Destroyed Packets.
- **Console:** Contains console settings, such as Console IP Address, Subnet Mask, Gateway, Media Type and MTU Maximum Size.
- **NTP:** Contains time information regarding NTP Service. You can among others configure Automatic Synchronization mode, Interval, IP Address, etc.
- **SNMP:** Allows you to configure SNMP parameters for each SNMP manager, such as the IP Address, Community String, Network and Version.
- **PPPoE:** Allows you to configure the **PPPoE User** and **Password** credentials.
- **Data Port:** Displays data port information such as the received and sent packets. You can also configure several data port parameters.
- **HTTP:** Allows you to configure HTTP settings such as HTTP Confirmation, Authentication User, Authentication Password and HTTP Title.
- **LAN:** Allows you to configure LAN settings such as IP Address Mode, IP Address, Subnet Mask, etc.
