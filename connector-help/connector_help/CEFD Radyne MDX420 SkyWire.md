---
uid: Connector_help_CEFD_Radyne_MDX420_SkyWire
---

# CEFD Radyne MDX420 SkyWire

The **CEFD Radyne MDX420 SkyWire** driver can be used to display information and configure settings for the **CEFD Radyne MDX420 SkyWire** satellite network gateway.

## About

This protocol can be used to monitor and control the **CEFD Radyne MDX420 SkyWire** modem. An SNMP connection is used to retrieve and set the modem's information and configuration data.

## Installation and configuration

### Creation

For protocol version range 1.0.0.x, this driver uses a Simple Network Management Protocol (SNMP) connection. For protocol version range 2.0.0.x, this driver uses a Simple Network Management Protocol version 3 (SNMPv3) connection. The following user information is required for either version:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General

The **General** page displays general information about the modem, for example: **System Name**, **Firmware Version**.

The page also displays some buttons and page buttons. The **Load Config**, **Save Config** and **Load Defaults** buttons can be used to load or save the configuration. The page buttons all display different pages with extra information about the MDX420. The **Installed Features...** button displays a separate page with information about the features that are installed for this modem. The **Events...** button displays information about the events that are occurring and the last events that have occurred in the system. The **Voltages...** button displays a page with the voltages.

### Modulator

The **Modulator** page displays the transceiver configuration settings.

### Modulator Alarms

The **Modulator** **Alarms** page displays all alarms related to the transceiver. There are 2 groups of alarms: **Alarms** and **Latched Alarms**.

The **Clear Latched Alarms** button can be used to clear the latched alarms. However, note that this button will clear all latched alarms, and not just the modulator latched alarms.

### Demodulator

The **Demodulator** page displays information about the receiver settings and data.

This page displays 2 tables: **Rx NV Status Table** and **Rx Status Table**. The first table displays non-volatile status information, while the second one displays volatile status information. The **Rx NV Status Table** can be used to configure the Demodulator settings.

This page is similar to the **Modulator** page, except that here the settings are displayed in a table, because there can be up to 4 receivers for this device.

### Demodulator Alarms

The **Demodulator Alarms** page displays all receiver alarms.

This page is similar to the **Modulator Alarms** page, except that the alarms are displayed in tables, because there can be up to 4 demodulators.

Note that the **Clear Latched Alarms** button will clear all latched alarms, so not only those related to the demodulator.

### Configuration

The **Configuration** page displays extra modulator and demodulator configuration settings. These settings are divided into 3 groups: **BUC, LNB** and **AUPC Controls**.

### Terrestrial Interfaces

The **Terrestrial Interfaces** page displays extra information and configurations for the terrestrial interfaces. The left side of this page displays M&C (Monitor & Control) parameters, while the right side displays ethernet information.

### Common Alarms

The **Com**mon Alarms**** is another alarms page that displays the common alarms. These are system alarms rather than alarms linked to the modulator or demodulator.

There is also a **Clear Latched Alarms** button, which will clear all the latched alarms. However, note that this button will clear all latched alarms, and not just the common latched alarms.

### Remotes

The **Remotes** page displays remote configuration and information data. This data is displayed in 2 tables: **Remote NV Status Table** (non-volatile) and **Remote Status Table** (volatile). You can also start or reboot the network on this page.

### TCP/IP Settings

The **TCP/IP Settings** page can be used to access the TCP/IP settings. The **FTP** **controls** are also displayed on this page. The **Advanced...** page button displays a separate page that can be used to change the **Terminal Logon Password**.
