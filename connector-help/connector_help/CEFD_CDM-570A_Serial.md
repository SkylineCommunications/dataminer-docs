---
uid: Connector_help_CEFD_CDM-570A_Serial
---

# CEFD CDM-570A Serial

The **CDM-570** is a Comtech EF Data's entry-level satellite modems and operates at L-band and includes support for externally connected Block Upconverters (BUCs) and Low-Noise Block Downconverters (LNBs).

## About

This connector implements the parameters like in the previous **CEFD CDM-570 Serial** connector which was based on the previous web interface.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|--|--|--|--|
| 1.0.0.x \[obsolete\] | Initial version | \- | \- |
| 1.0.1.x \[obsolete\] | Added the Bus to the connector | 1.0.0.5 | Communication via Bus enabled. |
| 1.0.2.x \[obsolete\] | Table FSK now uses naming instead of displayColumn to make the database for this table Cassandra-compliant. | 1.0.0.6 | Old trend data will be lost for this table. |
| 1.0.3.x \[SLC Main\] | Serial single + Table FSK now uses naming instead of displayColumn to make the database for this table Cassandra-compliant. | 1.0.1.5 | Change type of communication + Old trend data will be lost for this table. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unknown                |
| 1.0.1.x   | 1.5.4                  |
| 1.0.2.x   | Unknown                |
| 1.0.3.x   | 1.5.4                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                            |
|-----------|---------------------|-------------------------|-----------------------|------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | [CEFD CDM-570A Serial (FSK)](xref:Connector_help_CEFD_CDM-570A_Serial_(FSK)) |
| 1.0.1.x   | No                  | No                      | \-                    | [CEFD CDM-570A Serial (FSK)](xref:Connector_help_CEFD_CDM-570A_Serial_(FSK)) |
| 1.0.2.x   | No                  | Yes                     | \-                    | [CEFD CDM-570A Serial (FSK)](xref:Connector_help_CEFD_CDM-570A_Serial_(FSK)) |
| 1.0.3.x   | No                  | Yes                     | \-                    | [CEFD CDM-570A Serial (FSK)](xref:Connector_help_CEFD_CDM-570A_Serial_(FSK)) |

## Configuration

### Connections

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

**SNMP Settings**:

- **Port number**: The port of the connected device, default *161*.
- **Bus address**: The bus address. This is the address that will be used for the serial communication.

## How to Use

### Admin - Summary

This page contains the available information for the admin, it contains the ethernet settings.

### Modem

Use this page to configure the modem operating (Tx/Rx) parameters, including the Tx/Rx Interfaces and Framing. Enter a preferred value into a text box, select a predefined parameter from a drop-down menu or, for the Alarm Mask section, use the provided button to define a designated alarm as *Masked* or *Active*.

With AUPC, a local modem is permitted to adjust its own output power level in order to attempt to maintain the Eb/N0 at the remote modem

- **Framing:** Use the drop-down menu to select a value: *Unframed, EDMAC* and *EDMAC 2.*
- **AUPC:** Use the toggle button to select AUPC operation as either *Off* or *On*.
- **Rem Demod Target Eb/N0:** Type in a value, in dB, from *0.0* to *14.9*.
- **Tx Power Max Increase:** Use the drop-down menu to select a value, in dB, from *0* to *9*.
- **Max Pwr Reached Action:** Use the drop-down menu to set the action as *No Action* or *Generate Tx Alarm*.
- **Rem Demod Unlock Action:** Use the drop-down menu to set the action as *Go to Nominal Power* or *Go to Maximum Power*.

### Modem - Utilities

Use this page to set utilities such as Date and Time and Circuit ID, and to Load or Store Configuration presets.

- **Re-Center Buffer**: To force the re-centering of the Plesiochronous/Doppler buffer.
- **Force 1:1 Switch:** To toggle the Unit Fail relay to "fail" state for approx. 500ms. If the unit is one in a 1:1 redundant pair and it is currently the *online* unit, this forces a switchover so the unit is then placed in *standby* mode. The command is always executed by the unit, regardless of whether it is standalone, in a 1:1 pair, or part of a 1:N system.
- **Load/Store Configuration:** To **Load** (recall) and/or **Store** up to 10 configuration sets numbered *0* through *9*.
- Date & Time: Use the format *MM/DD/YYYY* to enter the **date** (where *MM = month \[01 to 12\]*, *DD = day \[01 to 31\]* and *YYYY = year).*

Use the international format *HH:MM:SS* to enter the **time** (where *HH = hour \[00 to 23\]*, *MM = minutes \[00 to 59\]*, and *SS = seconds \[00 to 59\]*).

- Circuit ID Configuration: Create a **Circuit ID** string of up to *24 alphanumeric characters*.

- Clocks: Configure **Tx Clock Source**, **Rx Buffer Size**, **Modem Frequency Reference**, **G.703 Clock Extended Mode**, and **G.703 Clock Extend Interface**.

- Internal Reference:

  - **Warm Up Delay**: For internal frequency reference (OCXO). *Disabled* (instant on - no delay for OCXO to reach temperature) or *Enabled* (unit waits until OCXO reaches correct temperature)
  - **Warm Up Countdown**: Used to truncate the Warm-up delay period to zero, forcing the unit into '*instant-on*' mode. As a query, returns the Warm-up Delay countdown, in seconds remaining. Range is from 000 to 200 seconds.

- **Terrestrial Interface:**

  - Interface Type: Used to define which electrical interface type is active at the data connectors. If *RS422*, *V.35*, or *RS232* is selected, the menu also indicates the operation of RTS/CTS.
  - RTS: Defines how RTS/CTS will operate at the main data interface
  - Line Build Out: Valid only for T1 interface.

### Modem - Status

Use this read-only page to view information about the modem's general operating status and configuration parameters.
**Installed Options:** This read-only section provides information for additional installed options.

### Modem - Logs

Use this read-only page to view Faults and Alarms (i.e., Modem Events) as logged by the unit, and to view modem operating statistics.

- **Clear Events**: To delete all existing log entries from the Modem Events Log. The log is then reset to one (1) entry: "*Info: Log Cleared*".
- **Initialize Events Pointer**: To Initialize the Events Pointer of the Modem Events Log.
- **Clear Statistics**: To delete all existing entries from the Modem Statistics Log.
- **Initialize Stats Pointer**: To Initialize the Stats Pointer of the Modem Statistics Log.

### Modem - BUC/LNB

Use this page to configure Block Up Converter parameters and to display the BUC status for L-Band operation and to configure Low-Noise Block Down Converter parameters and to display the LNB status for L-Band operation. In version 1.0.1.4, it's possible to enable and disable polling of these parameters.

- **Poll BUC/LNB Parameters -** *Enable* or *Disable* the BUC and LNB polling.

**BUC Configuration**:

- Use the provided toggle buttons to turn **BUC DC Power Control**, **10 MHz Reference**, **RF** **Output** and **Communication** *Enabled* or *Disabled*.
- **BUC Low** and **High Current Limit** value ranging from *0* to *4000* mA.
- **BUC Lockout Frequency** from *3000* to *65000* MHz and designate the value as a *HIGH (+)* or *LOW (-)* limit.
- **BUC Address** from *0* to *15*.

**BUC Status**: The values displayed in this section are read-only and cannot be changed.

**LNB Control**:

- **DC Supply Voltage:***Off* or On with *13*, *18* or *24* V.
- **LNB 10MHz Reference:** Enable operations *Disabled* or *Enabled*.
- Assign **LNB Current Lower** and **Current Upper Alarm Limit** values ranging from *10* to *600* mA.
- Assign an **Rx Lockout Frequency** and designate the value as a *HIGH (+)* or *LOW (-)* limit.

**LNB Status**: The **LNB Current** and **LNB Voltage** values displayed in this section are read-only and cannot be changed.

### Maint - Unit Info

This page contains the information of the device.

- **Unit Information**: In this section it is possible to find the **Serial Number** and the **Software Revision**.
- **Firmware**: The **Active Firmware Image** and the **Next Reboot Image** are available.

### FSK

Use this page to have access to FSK functionality. It will be used in the creation of virtual elements.

- **FSK Enabled** - Set to *Enabled* or *disabled* FSK functionality.
- **FSK Element Name** - The *name* used to represent the element.
