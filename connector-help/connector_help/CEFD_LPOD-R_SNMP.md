---
uid: Connector_help_CEFD_LPOD-R_SNMP
---

# CEFD LPOD-R SNMP

This connector is used to control and monitor CEFD LPOD-R amplifiers.

## About

With this protocol, an LPOD-R amplifier can be monitored and configured as described below. Events and statistics are also loaded from the device and displayed in close resemblance to the device's webpage. This webpage is also accessible when opened within the same network as the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.2.3                       |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: \[The community string used when reading values from the device, by default *public*.\]
- **Set community string**: \[The community string used when setting values on the device, by default *private*.\]

## Usage

### General

Use this page to get a general perspective on some of the most important device parameters and device identification.

- System Information

- Device Overall Status

- **Toggle polling speed:** Toggle between *Normal Polling* and *Fast Polling* when the card is open. This includes status and configuration parameters, but excludes tables and variables which are unlikely to change.

### Admin

The administrator must use this page to manage the LPOD-R network and trap settings.

- Enter the **IP Gateway** and **Address** in the form of *XXX.XXX.XXX.XXX* (leading zeros can be omitted). The **IP Subnet Mask** has a range of 8 to 30 inclusive.
- Enter the **Trap IP 1** and **Trap IP 2** addresses, in the same form as the IP address above, for the computer that is to receive the generated traps.
- Use the **Trap Version** toggle button to select *SNMPv1* or *SNMPv2*.
- Enter a **Trap Community String**. This string can be any combination of characters and can have a length of 0 to 20 characters. The factory default SNMP Write Community string is *comtech*.

### Config - Amplifier

These settings can be used to change the settings of the signal that is being amplified.

- **Amplifier:** The settings concerning the amplifier's power and enabled options.
- **Reference:** Settings concerning the reference signal.
- **BUC LO Frequency:** Settings concerning the local oscillator.

### Config - Utility

Use this page to configure a number of the LPOD-R utility functions.

- **Date** and **Time:** These can be entered manually, or synced from the system clock. Use the page button **Time Sync.** to open the time synchronization settings.
- **Circuit ID String:** Enter a Circuit ID string with a maximum length of 24 characters.
- **Firmware Image:** The active Bulk Image is displayed, and the image for the next reboot can be chosen.
- **Firmware Info:** View the firmware loaded in the device.
- **Soft Reboot:** Instantly soft reboots the device.

### Status

This page contains the readouts and status of the power supplies, as well as the status of other components and a readout for the fan speed and amplifier temperature.

### Status - Events

All events stored in the memory are displayed here and can be cleared with the **Clear** button. In addition, the **Alarm Mask** can be set at the bottom of the page.

### Status - Statistics

You can view unread stored statistics on this page. It also has two buttons: **Clear**, which clears the table, and **Initialize pointer**. Further down the page you can find parameters to change the statistics options.

### FTP

The table containing all the FTP rules that can be individually edited.

### Web Interface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
