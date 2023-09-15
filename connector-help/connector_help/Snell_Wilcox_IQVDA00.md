---
uid: Connector_help_Snell_Wilcox_IQVDA00
---

# Snell Wilcox IQVDA00

The **Snell Wilcox IQVDA00** is an analog video distribution amplifier with RollCall control.

## About

This protocol is used to control and monitor the **Snell Willcox IQVDA00** via **SNMP**.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Slot number of the module in the chassis, e.g. *1.*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General Page

This page displays some general information (e.g. **Slot Number**, **Serial Number**, .).

On this page, you can also **Restart the Unit** or reset it to the **Default Settings**.

### Logging Page

Information about various parameters can be made available to a logging device that is attached to the RollCall network by selecting the appropriate item.

You can enable the parameters on the left side of this page. The values are shown on the right side.

### Video Page

This page allows the user to set some general **Video Settings**.

### Roll Track Page

This page allows information to be sent via the RollCall network to other compatible units connected on the same network.

### Webpage

This page can be used to access the **web interface** of the device. Note that the interface must be accessible from the **client PC**.
