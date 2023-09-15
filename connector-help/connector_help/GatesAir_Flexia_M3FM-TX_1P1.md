---
uid: Connector_help_GatesAir_Flexia_M3FM-TX_1P1
---

# GatesAir Flexiva M3FM-TX 1P1

The GatesAir Flexiva M3M-TX 1P1 is a **solid-state transmitter** that provides a single transmission platform capable of analog and digital operation.

## About

This is an **SNMP**-based connector for the GatesAir Flexiva M3M-TX 1P1.

### Version Info

| **Range** | **Description**        |
|------------------|------------------------|
| 1.0.0.x          | Initial version        |
| 1.0.1.x          | Added support for DVEs |

### Product Info

| **Range** | **Device Firmware Version**                    |
|------------------|------------------------------------------------|
| 1.0.0.x          | 02.03.0139 / 861-1151-162 S (software version) |
| 1.0.1.x          | 02.03.0139 / 861-1151-162 S (software version) |

### Exported connectors

| **Exported Connector**                           | **Description**    |
|-------------------------------------------------|--------------------|
| GatesAir Flexiva M3FM-TX 1P1 Main Transmitter   | Main transmitter   |
| GatesAir Flexiva M3FM-TX 1P1 Backup Transmitter | Backup transmitter |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

This connector monitors basic parameters. It can also receive traps from the device, so that values can be displayed immediately.

The connector contains 4 pages and a page with the device web interface.

### General Page

This page displays information regarding the device itself, such as **System Description**, **Uptime**, **Contact Name** and **Location**.

### System Page

This page displays information concerning the status of the **Controller** and the **Switch**. It is also possible to configure the **System Name**, **System Power Control**, **Monitor Mode**, **Mode Control**, **Switch** and **Event** settings.

### Transmitter A and Transmitter B Pages

These pages contain the **transmitter status** and **configuration** for the corresponding transmitter.

They display the **Communication**, **Frequency**, **Summary Faults**, **Remote Control**, **Drive**, **PA**, **Out** and **Aural Out status**.

Both pages have two page buttons:

- **Transmitter Config**: Transmitter settings of **Trip Level**, **Warning** **Level** and **Trip Time**.
- **Transmitter Events**: Transmitter **Event settings**.

### Web Interface

This page displays the web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
