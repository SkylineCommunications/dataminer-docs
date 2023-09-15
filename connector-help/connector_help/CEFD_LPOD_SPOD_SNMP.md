---
uid: Connector_help_CEFD_LPOD_SPOD_SNMP
---

# CEFD LPOD SPOD SNMP

The **CEFD LPOD SPOD** **SNMP** connector is used to control and monitor CEFD LPOD and CEFD SPOD amplifiers.

## About

With this protocol, an LPOD or SPOD amplifier can be monitored and configured as described below. Events and statistics are also loaded from the device and displayed in close resemblance to the webpage of the device. This webpage is also accessible when opened within the same network as the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**        |
|------------------|------------------------------------|
| 1.0.0.x          | Boot:1.1.1 Bulk1:1.4.0 Bulk2:1.4.0 |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General

Use this page to get a general perspective on some of the most important device parameters and device identification.

- System Information

- Device Overall Status

- **Toggle polling speed:** Toggle between *Normal Polling* and *Fast Polling* when the card is open. This includes status and configuration parameters, but excludes tables and variables that are unlikely to change.

### Admin

The administrator can use this page to manage the LPOD or SPOD network and trap settings.

- Enter the **IP Gateway** and **Address** in the format *XXX.XXX.XXX.XXX* (leading zeros can be omitted). The **IP Subnet Mask** has a range of 8 to 30 inclusive.
- Enter the **Trap IP 1** and **Trap IP 2** addresses, in the same form as the IP address above, for the computer that is to receive the generated traps.
- Use the **Trap Version** toggle button to select *SNMPv1* or *SNMPv2*.
- Enter a **Trap Community String**. This string can be any combination of characters and can have a length of 0 to 20 characters. The factory default SNMP write community string is *comtech*.

### Config - Amplifier

These settings can be used to change the settings of the signal that is being amplified.

- **Amplifier:** The settings related to the amplifier's power and enabled options.
- **Serial:** The Address and Baud Rate of the serial communication.
- **Reference:** Settings related to the reference signal.

### Config - LNB

On this page, you can configure the low-noise block downconverter.

### Config - Utility

Use this page to configure a number of the CDM-750 utility functions.

- **Date** and **Time:** These can be entered manually, or synced from the system clock. Use the page button **Time Sync.** to open the time synchronization settings.
- **Circuit ID String:** Enter a Circuit ID string with a maximum length of 24 characters.
- **Firmware Image:** The active Bulk Image is displayed, and the image for the next reboot can be selected.
- **Firmware Info:** View the firmware loaded in the device.
- **Soft Reboot:** Instantly soft reboots the device.

### Status

This page contains the readouts and status of the power supplies, as well as the status of other components and a readout for the fan speed and amplifier temperature.

### Status - FETs

This page displays the current for each FET.

### Status - Events

This page displays all events stored in the memory. These can be cleared with the **Clear** button. In addition, the **Alarm Mask** can be set at the bottom of the page.

### Status - Statistics

This page displays unread stored statistics. It also has two buttons: **Clear**, which clears the table, and **Initialize pointer**. Further down the page you can find parameters to change the statistics options.

### Status - FTP

On this page, you can find the table containing all the FTP rules, which can be individually edited.

### Web interface

This page provides access to the web interface provided by the web server of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
