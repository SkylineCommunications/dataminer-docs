---
uid: Connector_help_CEFD_CDM-600_Serial
---

# CEFD CDM-600 Serial

The **CEFD CDM-600 Serial** is a serial driver intended to communicate with CDM-600/600L Comtech devices. However, because of the differences between the models, certain parameters will only be available depending on the element type.

## About

This driver uses serial communication to retrieve information from the device and to set the device configuration.
For more information, refer to the following page: <http://www.comtechefdata.com/support/docs/satellitemodemdocs>.

### Version Info

| **Range** | **Key Features**                                                                                                   | **Based on** | **System Impact**                                 |
|-----------|--------------------------------------------------------------------------------------------------------------------|--------------|---------------------------------------------------|
| 1.0.0.x   | Initial version                                                                                                    | \-           | \-                                                |
| 1.0.1.x   | \-                                                                                                                 | \-           | \-                                                |
| 1.0.2.x   | \-                                                                                                                 | \-           | \-                                                |
| 1.0.3.x   | Multiple tables now use naming instead of displayColumn to make the database for these tables Cassandra-compliant. | 1.0.0.34     | **Old trend data will be lost for these tables.** |
| 2.0.0.x   | \-                                                                                                                 | \-           | \-                                                |
| 3.0.0.x   | \-                                                                                                                 | \-           | \-                                                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.3.x   | HW 04.0, SW 1.5.7      |

## Installation and configuration

### Creation

#### Serial main connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the Ethernet-to-serial converter, e.g. *10.11.12.13*.
- **IP port**: The port addressed to connect the device, set in the Ethernet-to-serial converter, e.g. *4001*.
- **Bus address**: The BUS address set in the device, e.g. *1*. (Range: 1 to 9999.)

## Usage

### General

This page provides an overview of the most important parameters of the device.

The System Information section displays the **Model Number**, **Hardware Revision**, **Software Revision** and **Serial Number**. The **Hardware Revision** is indicated in the format "*xx.y*", where *xx* indicates the main (bottom) card, and *y* indicates the modem (top) card.

The Device Overall Status displays the **Unit Alarm**, **Tx Traffic Alarm**, **Rx Traffic Alarm**, **Unit Test Mode**, **External Module**, **Temperature** and **Operating Mode** parameters.

The **External Module** parameter indicates whether a High-Stability Reference module is installed or not. The **Temperature** parameter indicates the internal temperature of the modem.

### Admin - FAST

The CDM-600 has a number of optional features that can be activated after the unit's purchase. Fully Accessible System Topology (FAST) Access Codes are register-specific unique authorization codes that can be purchased from Comtech EF Data.

On this page, the **Equipment ID** section displays the operational status for a number of FAST-enabled features. This section is read-only.

### Config - Modem

Use this page to configure modem operating (Tx/Rx) parameters:

- **Tx/Rx Interfaces and Framing**: The **Tx**/**Rx** **Interface Types** and **Framing Modes** have higher priority than other parameters. These parameters should be configured first, before you set any other parameters.
- **Transmit/Receive**: The Tx/Rx operating parameters have lower priority and can be configured here.

### Config - Overhead

Use this page to configure the following overhead interfaces:

- **ESC**: Including **Tx/Rx IDR Esc Type**, **Audio Volume**, **High Rate ESC**.
- **AUPC**: Parameters for AUPC configuration.
- **EDMAC**: EDMAC framing mode and slave address range.
- **IDR Backward Alarms**: For **Tx 1-4** and **Rx 1-4** alarms.

### Config - Utilities

Use this page to configure a number of the CDM-600's utility functions.

- **Redundancy**: If the unit is part of a 1:1 redundant pair of modems and this unit is currently online, click **\[Force 1:1 Switch\]** to cause the unit to switch to standby.

- **Re-Center Buffer**: Click **\[Re-Center Buffer\]** to force the re-centering of the Plesiochronous/Doppler buffer.

- **Unit**: Use the drop-down menus provided in this section to configure **Unit** **Test Mode**, **Operating Mode, Unit Outdoor Communications & Rx IF Impedance**. The **Front Panel Lockout** is only functional for CDM-600L modems.

- **Clocks**: Use the drop-down menus provided in this section to configure **Tx/Rx Clock Sources**, **Rx Buffer Size**, **Rx External Clock Type & Rx External Clock**. The **Modem Reference Clock** is only functional for CDM-600L modems.

- **Circuit ID**: Enter a Circuit ID string of up to 40 characters. The Circuit ID, as created here, appears in the title bar of compatible web browsers for easy unit identification.

- Date and Time:

- **RTC Date**: Enter a date using MM/DD/YY format, where MM = month \[01 to 12\], DD = day \[01 to 31\], and YY = year \[00 to 99\].
  - **RTC Time**: Enter a time using HH:MM:SS format, where HH = hour \[00 to 23\], MM = minutes \[00 to 59\], and SS = seconds \[00 to 59\].
  - **Time Sync**: Parameters related to the time sync.

- Warm-Up:

- **Warm Up Delay:** Warm-up delay for internal frequency reference (OCXO). Set to *Disabled* (instantly on, no delay for OCXO to reach temperature) or *Enabled* (unit waits until OCXO reaches correct temperature).
  - **Warm Up Countdown**: The warm-up delay countdown in seconds remaining.
  - **Truncate Delay:** Used to truncate the warm-up delay period to *zero*, forcing the unit into "*instant-on*" mode.

- **High-Stability Reference**: This CDM-600-only section requires the installation of the optional High-Stability Frequency Reference module.

- **Save/Load** (Save takes precedence over Load)

- **Configuration Save/Configuration Load:** Use the drop-down menus to save or load up to 10 different modem configurations (*0* through *9)*.

### Config - Drop and Insert

Use this page to configure the **Drop and Insert** functionality. The appropriate parameters should be set according to the framing mode selected on the **Config - Modem** page.

### Config - BUC / LNB

These parameters are only available for CDM-600L devices.

When a Block Up Converter (BUC) and a Low Noise Block Down Converter (LNB) are installed, use this page to configure their operating parameters and to view the BUC and LNB status for L-Band operation.

### Status - Modem Status

This page displays read-only information regarding **Alarms**, **Rx Parameters**, **AUPC** and **General Status**.

### Status - Modem Logs

Use this page to control the way faults, statistics, and alarm masking parameters are processed by the unit.

- Events Log:

- **Poll Event Table**: Enable or disable polling of the events table.
  - **Events Overview**: Table listing all events that have occurred.

- Statistics Log:

- **Statistics Interval**: Define the interval at which the statistics are taken.
  - **Statistics Overview**: Table showing the statistics.

- **Alarm Masking**: Allows you to define a designated alarm as *Masked* or *Active***.**

### FSK

This page provides access to the FSK functionality. It is used for the creation of virtual elements.

- **FSK Enabled**: Enable or disable the FSK functionality.
- **FSK Element Name:** The name used to represent the element.

### Save / Load Configuration

This page allows you to **save** all parameter values to a CSV file. Afterwards, it is also possible to **load** that same file. This will set the parameters to the saved values.

- By default, the saved file is stored in the following folder: *C:\Skyline DataMiner\Documents\DMA_COMMON_DOCUMENTS\\PROTOCOLNAME\].*
- The default file name is *backup_ELEMENTNAME_datetime.*
