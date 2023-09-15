---
uid: Connector_help_Systembase_C500_Series
---

# Systembase C500 Series

The Systembase C500 Series connector is compatible with the following Systembase models: **C510 XR** and **C510 IP**. The Systembase C500 series audio codecs have been designed and manufactured to deliver real-time audio applications over IP, ISDN, ADSL and satellite.

## About

This connector periodically polls the target device using an SNMP connection. It polls informative data every 5 minutes and more sensitive data every 10 seconds. It can also set writable parameters using the SNMP SET command.

### Version Info

| **Range** | **Description**                                              | **DCF Integration** | **Cassandra Compliant** |
|------------------|--------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version. Compatible with C510 XR and C510 IP models. | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | C510 IP: 306                |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device e.g. *10.10.250.150.*

## Usage

### General

This page consists of three sections:

- **General Options**: Name, PCM Source, Head Room, Mixing, Alarm Relay, AUX Data and Function
- **Status:** Synchronization, Alarm Status, Audio Mode, AES3 and Active Patch
- **Backup Options**: Backup Threshold, Restore Time and ISDN Reserve Dial.

The **ISDN Options** page button displays the parameters **ISDN Audio Mode**, **Priority**, **Auto Hunt**, **ISDN G711 Receive**, **X21 Audio Mode** and **ISDN Available Channels**.

### Control

This page displays the **Select Patch**, **Loop Back**, **Backup Errors** and **ISDN State Number**.

There are two buttons, **Dial** and **Hang**, that control the dialing and disconnecting of the ISDN calls.

### Global Options

This page displays the **Number**, **Country ID** and **Country Table** with the columns **Index**, **Country SPID** and **SPID Status** for each entry.

### ISDN

This page displays the following tables:

- **ISDN Settings**: Shows the **Index**, **Remote Address**, **Remote Sub Address** and **Local Sub Address** for each entry.
- **ISDN Control**: Shows the **Index**, **String**, **CLI String** and **Cause String** for each entry.

### IP Config

This page displays the following parameters:

- **IP Local Settings**: IP Local DHCP, IP Local Address, IP Local Mask, IP Local Gateway, IP Local Name, IP Local Auto Buffer, IP Local Buffer Length, IP Local Packet Size and IP Local Queue Length.
- **Systembase Audio over IP settings**: Local Port and Group ID.
- The **Local Ethernet Mode Status**
- **SIP Server Registration**: Allows you to enable SIP server registration and verify the server and credentials settings.
- **SIP Settings**: Allows you to verify and update the SIP IP port and public address settings.

### IP Audio Control

This page displays the number of active connections and lists these connections in the **Active Connections** table, with the columns **Index**, **Name**, **IP Address**, **Owner**, **State**, **Mode**, **Audio**, **Queue** and **Disconnect**.

It also displays the number of remote connections and lists these in the **Remote Connections** table, with the columns **IP Index**, **IP Address**, **Algorithm**, **Audio Format**, **FS**, **Audio Mode**, **FEC**, **State**, **Auto** and **Connect**.

### IP Audio Statistics

This page contains remote and local audio statistics. The following information is available: **Codec Name, Address, RTP Loss, FEC Invoke, Audio Loss, Jitter, Queue**.

A **Reset** button is available to reset the statistics on the device.

### System Information

This page displays the following parameters: **Product Type**, **Serial Number**, **Release**, **PCB Revision**, **Main Revision**, **DSP Revision**, **PLD Version**, **Web MAC**, **IP MAC** and **IP VER**.

### Web Interface

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

The **1.0.0.x** connector range of the **Systembase C500 Series** protocol supports the usage of DCF and can only be used on a DMA with **8.5.8.5** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- **I/O Channel 1**: Physical SDI interface with type **inout**.
- **I/O Channel 2**: Physical SDI interface with type **inout**.
