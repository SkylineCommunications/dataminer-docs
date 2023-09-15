---
uid: Connector_help_Rohde_Schwarz_NetCCU800
---

# Rohde & Schwarz NetCCU800

The **Rohde & Schwarz NetCCU800** is a common control unit for FM and TV transmitters.

## About

This connector allows you to access various information on the device. It is possible to **get and set** **data** on the many modules listed below. In addition, the connector also acts as an event receiver for **SNMP** **traps**.

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device e.g. *10.11.12.13*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General Page

This page displays **system information** as well as additional data on the status of the rack system.

Multiple buttons and page buttons are also available:

- **Restart** button: Restarts the software of the transmitter control unit.
- **Reset All Faults** button: Resets all faults (in all modules) of the transmitter. An equivalent action would be to press RESET at the transmitter front panel.
- **Device Info** page button: Opens a pop-up window that displays the product info table. In this table, you can find information on the software and hardware of each specific installed module.
- **NTP Server** page button: Opens a pop-up window that displays the NTP configuration settings for the device. You can change these settings from this page.
- **Software Update** page button: Opens a pop-up window that displays the software update settings for the device.
- **Polling Config** page button: Opens a pop-up window that displays the polling configuration parameters for the device. The window includes the **Select device** parameter, which is very important for the protocol functionality. It is here that you can switch between the *DVB* and *ISDBT* device type.
- **Summary Info** page button: Opens a pop-up window with a summary of the system information, including the **Forward Power** and **Summary Fault Tx**.

### DVB Receiver Page

This page provides information on the **DVB Receiver** module. It also contains a page button that displays the **DVB Product Information Table**.

If the device type is set to *ISDBT* instead of *DVB* (on the **Polling Config** page), this page (and all other DVB pages) will not display any information.

### DVB Receiver 1/2 Pages

These two pages display specific information for each DVB receiver, and allow you to configure various settings.

### Transmitter Page

This page displays information regarding the transmitter status, and separate summary information for **Exciter A** and **Exciter B**.

The **Tx Events Table** page button displays the **Tx Events Table**, which contains a list of all existing events on the device. This table is polled from the device on startup and the values are refreshed every time a trap is received. You can set the **Event Tx Mask** value for the event as well as the **Event Priority.**

### Transmitter Settings Page

This page provides information about the transmitter settings. A **Restart** button is also available, which allows you to restart the transmitter (resets all faults in all modules).

One page button is available on this page, **Transmitter Settings Table**, which displays the **Tx Commands Table**. This table contains important commands for the transmitter.

### Exciter Status Page

This page displays information regarding the available exciters. Two tables are available on this page:

- **ISDBT Exciter Input Table:** This is an **ISDBT device table**, which provides information related to the **Inputs** of each **Exciter**. Note that this table will not be polled if the device type is set to *DVB* (on the Polling Config page) .
- **Exciter Status Table:** This table provides information on the status of each individual **Exciter** (**A** and **B**). The information on this page is also used to calculate the **SFN Delay parameters**.

In addition, the **SFN Delay** page button displays the calculated SFN delay parameters. The SFN values from the **Exciter Status Table** are used to calculate the absolute difference (**delay**) between **Exciters A** and **B**.

### Exciter Settings Page

This page displays two tables, the **Exciter Pre-Correction Table** and the **ISDBT Transmission** **and** **Multiplexing Configuration Control Table**. Both tables provide useful information about the exciters and allow you to set various parameters for each exciter.

### Exciter 1/2 Status Pages

These two pages provide information on each of the **Exciters** (**A** and **B**). The available parameters can be used to evaluate the status of each individual exciter.

### Exciter 1/2 Settings Page

These pages display information on the configuration and settings of each individual **Exciter** (**A** and **B**). There are also four page buttons available:

- **RFIQ:** Displays the available **RFIQ** information.
- **SFN:** Displays the available **SFN** information.
- **TPS:** Displays the available **TPS** information.
- **Input:** Displays the available **Input** information.

### Amplifiers Page

This page provides summary information on the available amplifiers. This information can be used to monitor the status of the available amplifiers.

There are also four page buttons available:

- **Status Table:** Displays the **Amplifier Status Table**, which provides information on each individual available amplifier.
- **Alarm Table:** Displays the **Amplifier Alarms Table**, which provides information on current active and inactive amplifier alarms.
- **Rack Table:** Displays the **Rack Table**, which provides information on each available rack in the system.
- **Sx801 Amplifier:** Displays the **Sx801 Amplifiers Table**, which provides information on the available Sx801 amplifiers.

### Exciters AB Page

This page displays information on both available **Exciters** (**A** and **B**). It also allows you to control the operating modes of the exciters.

The page contains six page buttons:

- **Trap Sink:** Displays the **Trap Sink Table**. The entries in this table are used as receivers for the traps that are sent out from the device. These values can be edited by an operator. The IP address of the DMA used to monitor the device should be configured in this table.
- **Programs:** Displays the **Program Table**, which contains important values for programs.
- **Tx Commands:** Displays the **Tx Commands Table**.
- **Transmitter A**: Displays the **Transmitter A Table**, which provides information on the status of transmitter A.
- **RF Probes:** Displays the **RF Probes Table**, which provides information about available RF probes and allows you to edit the parameters related to each available RF probe.
- **GPS Events:** Displays the **GPS Events Table**, which contains the necessary information to handle **GPS Events Alarms**.

### Exciter A/B Pages

These pages provide information on the **configuration** and **status** of each individual available exciter (A and B).

### NSU Events Page

This page displays the **NSU Events Table**, which contains the necessary information to handle **NSU Event Alarms.**

### Pump Unit Page

This page displays the **Pump Unit Events Table**, which provides the necessary information to handle **Pump Unit Event Alarms.**

## Notes

This protocol uses a **parameter (67)** as a type of bus address. The value of this parameter is used to dynamically switch between the *DVB* and *ISDBT* device configuration and OIDs. Please keep this in mind and maintain this functionality when adding features to the protocol.
