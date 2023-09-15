---
uid: Connector_help_Axon_SIM11
---

# Axon SIM11

The Axon SIM11 is a **Signal Integrity Monitor**.

## About

This is an **SNMP**-based connector for the Axon SIM11 device.

### Version Info

| **Range** | **Description** |
|------------------|-----------------|
| 1.0.0.x          | Initial version |

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host:** The polling IP of the device.
- **Device address:** Required address: *10*.

**SNMP Settings:**

- **Port number:** The port of the connected device, by default *161.*
- **Get community string:** The community string in order to read from the device. The default value is *public*.
- **Set community string:** The community string in order to set to the device. The default value is *private*.

## Usage

This connector only has one page: **SIM11**.

### SIM11

This page displays information regarding the device itself, as well as the **Software** and **Hardware** **Revision**, **Serial Number** and **ID**. It shows information about the **SDI Input**, **Freeze** and **Block Status**, **Format Detection**, **Meters**, **ANC Status**, **WSS**, **VI Detection**, **EDH Status** and **GPI-in-Local**.

The page contains two page buttons: **Events** and **Settings**.

- The **Events** page button contains configuration settings regarding **Priorities**.

- The **Settings** page button contains configuration settings for **SDI-Format**, **OSD-label**, **OSD-Chan-Pres**, **Safe Area**, **Safe Area Control**, **WSS**, **VI-Det** and **EDH-Det**. It displays information regarding **Text-Background**, **Subtitles**, **Slice CPhase**, **Slice Level**, **Scales** and **Scale-Levels**.

  It also contains five additional page buttons with the following configuration settings:

  - **Silence Detection**
  - **Black Detection**
  - **Freeze Detection**
  - **VU-Bar Properties**
  - **Meter Selection**

## Notes

DCF Implementation in version 1.0.0.6.
