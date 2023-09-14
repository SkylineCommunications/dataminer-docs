---
uid: Connector_help_Axon_SIM10
---

# Axon SIM10

The **Axon SIM10** is a signal integrity monitor. The connector monitors and controls the device via **SNMP**.

## About

The connector polls the device every hour for non-varying information, every ten minutes for slow-varying information and every 30 seconds for fast-varying information .

### Creation

The connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device.
- **Device Address:** A logical index, between *0* and *18*.

**SNMP Settings:**

- **Port number**: The port number used to poll the device, by default *161.*
- **Get community** **string**: The community string in order to read from the device. The default value is *public.*
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

This connector consists of the following pages: **Main View,** **General, Settings** and **Events.**

### Main View Page

On this page, the following parameters can be found:

- The **name** of the device
- The **user label** of the device
- The **description** of the device
- The **status** of **meters A, B, C** and **D**
- The **selected** channels for **meters A, B, C** and **D**
- The **status** of the **SDI input**
- The **status** of the **channel numbers display (OSD-Chan-Pres)**
- The **SDI format**
- Several **status** indicators: **Freeze, Black, Ancilliary (ANC)** and **Error Detection Handling (EDH)**

### General Page

Some parameters on this page are the same as on the Main View page. In addition, you can also configure the **device's user label**.

In the left column, the following parameters are displayed:

- **Software Revision**
- **Hardware Revision**
- **Product Code**
- **Serial Number**
- Product **ID**

In the right column, you can find the following parameters:

- **SDI Groups in Use**
- The device's **Meters A to D**
- **WSS** (Wide Screen Signalling) **Standard/Extended/GPI Detection** statuses
- The **VI (Video Indexing) Detection**
- **GPI in-local status**
- **Meters' Phases (A to D)**

### Settings Page

On this page, you can configure several parameters related to the functioning of the device:

- **SDI Input Format**
- **OSD Label** and its respective presence status **(OSD-Chan-Pres)**
- **Report Announcement**
- **WSS Detection** type
- The type of **VI Detection**
- The methods of **EDH detection**
- The presented **safe area**
- The type of **safe-area control**
- The **types of scales** used for the existing OSD indicators
- The **text background**, which can be enabled or disabled
- The **scale values,** which can be shown or hidden

In addition, you can configure several detection/configuration metrics of the device itself with the following page buttons:

- **Silence** Detection
- **Black** Detection
- **Freeze** Detection
- **Phase** Status configuration
- **Displayed Bars' scale configuration (VU-Bar Prop.)**
- **Meter Selection**

### Events Page

On this page, you can configure the priority of the device's announced events, including:

- The **announcements**
- The **input**
- The **freeze status**
- The **black status**
- The **EDH status**
- The **ANC status**

## Notes

Version 1.0.1.1 is based on version 1.0.0.12, with additional DCF functionality.
