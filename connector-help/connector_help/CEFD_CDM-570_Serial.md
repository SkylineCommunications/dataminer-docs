---
uid: Connector_help_CEFD_CDM-570_Serial
---

# CEFD CDM-570 Serial

The **CDM-570 Serial** is a Comtech EF Data's entry-level satellite modems and operates at L-band and includes support for externally connected Block Upconverters (BUCs) and Low-Noise Block Downconverters (LNBs).

## About

This connector is intended to communicate with CDM-570 Serial devices using serial commands as described in the device manual.

Note: This connector will export a different connector based on button **FSK Enabled**. A list can be found in the section 'Exported Connectors'.

### Version Info

| **Range**     | **Description**                                                                             | **DCF Integration** | **Cassandra Compliant** |
|----------------------|---------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version                                                                             | No                  | No                      |
| 2.0.0.x              | Customer Specific                                                                           | No                  | No                      |
| 3.0.0.x              | Customer Specific                                                                           | No                  | No                      |
| 3.0.1.x \[Obsolete\] | Cassandra compliant                                                                         | No                  | Yes                     |
| 3.0.2.x              | IP address was split up into a separate IP Address parameter and a Subnet Mask parameter | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**          |
|------------------|--------------------------------------|
| 1.0.0.x          | Boot:1.1.1 Bulk1:1.6.16 Bulk2:1.6.16 |
| 2.0.0.x          | Boot:1.1.1 Bulk1:1.6.16 Bulk2:1.6.16 |
| 3.0.0.x          | Boot:1.1.1 Bulk1:1.6.16 Bulk2:1.6.16 |
| 3.0.1.x          | Boot:1.1.1 Bulk1:1.6.16 Bulk2:1.6.16 |
| 3.0.2.x          | Boot:1.1.1 Bulk1:1.6.16 Bulk2:1.6.16 |

### Exported Connectors

| **Exported Connector**     | **Description**                 |
|---------------------------|---------------------------------|
| CEFD CDM-570 Serial (FSK) | BUC and LNB parameters exported |

## Configuration

### Connections

#### Serial Connection - Main

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - IP address/host: The polling IP of the device.
  - IP port: The IP port of the device.
  - Bus address: The bus address of the device.

## Usage

### Version 2.0.0.14

### Start Page

On the Start page, you can access some of the device's parameters. Some of them can be set and others are of type read-only.

- **Equipment ID .** - Shows available hardware and functionality options installed on the device.
- **Alarm Mask .** - Alarm mask conditions.
- **Interface Settings .** - **RTS** and **Line Build Out** configuration.
- **Utilities .** - Some others options.
- **Normalized Value .** - Set a value to normalize **Rx Eb/No**.

### Configuration

Use this page to configure the modem operating **Modulator** and **Demodulator** parameters.

After setting the desired values you must enter the **Send Configuration** page button. If the values are correct press the **Send Config** button. Back to the **Configuration** page if you want to see again the values present in the device, press the **Refresh** button.

### Modem Lineup

In this page press the **Refresh** **Values** button if it's necessary to read the latest values from device. This is useful when you don't want to wait for the next update performed by the timers.

It is also possible, in this page, to analyze the response of a command sent to the device. The code of each command is defined in the manual (*Appendix* *D.* *Serial Remote Control*). For example, to know the temperature in the device write "*TMP?*". To set the date 17-12-2013 write "*DAY=171213*".

### Modulator/Demodulator

Use this read-only page to view information about the modem operating **Modulator** and **Demodulator** parameters.

### Frame

Use this page to view and set **EDMAC** and **AUPC** related parameters.

### Stored Statistics / Events

Use this page to configure the **Statistics Sample Interval** and to analyze statistical information.

It's also possible to see information about device Events under the **Stored Events .** page button.

### Dynamic Threshold

There are two parameters in the **Start Page** - **Rx Eb/No Status** and **Rx Remote Eb/No Status** - that will trigger an alarm when the values of **Rx Eb/No** and **Rx Remote Eb/No** go beyond certain values. These values are described in the **Dynamic Thresholds** Table. So, if **Rx Eb/No** and **Rx Remote Eb/No** have values under **EbNo_min** and above **EbNo_High** a *Critical Low* or *Critical High* Alarm, respectively, will be triggered. Inside the limits, **Rx Eb/No Status** and **Rx Remote Eb/No Status** will be set as *Normal*.

To define these values you need to create a file under the path "C:\Skyline DataMiner\Documents\DMA_COMMON_DOCUMENTS\Lineuplevels\\ with .csv extension. After that, in the **DMA** **Element**, press the **Refresh File List** button. The **Channels CSV-File Path** will show the name of the file. Then press **Load File**.

If device parameters **Rx Coded**, **Rx** **Modulation** and **Rx** **FEC** are the same as the ones described in the file then a row will be shown in the table and the alarms will be set.

### Version 3.0.0.8

### Admin - Summary

Use this read-only page to obtain information for the assigned **MAC** and **IP Addresses** and the currently available standard and optional operational features.

- **MAC Address (read-only)**: This is set at the factory to a guaranteed unique address that cannot be modified. The MAC address for the Ethernet interface.

- **IP Address/Mask**: The IP address/mask for the IP Module Ethernet Interface.

- Toggle Polling Speed: Switch between *Fast Polling* and *Normal Polling* of the parameters.

### Modem

Use this page to configure the modem operating (Tx/Rx) parameters. Enter a preferred value into a text box, select a predefined parameter from a drop-down menu or, for the **Alarm Mask** section, use the provided button to define a designated alarm as *Masked* or *Active*.

With AUPC, a local modem is permitted to adjust its own output power level in order to attempt to maintain the Eb/N0 at the remote modem.

- **Framing:** Use the drop-down menu to select a value: *Unframed, EDMAC* and *EDMAC 2.*
- **AUPC:** Use the toggle button to select AUPC operation as either *Off* or *On*.
- **Rem Demod Target Eb/N0:** Type in a value, in dB, from *0.0* to *14.9*.
- **Tx Power Max Increase:** Use the drop-down menu to select a value, in dB, from *0* to *9*.
- **Max Pwr Reached Action:** Use the drop-down menu to set the action as *No Action* or *Generate Tx Alarm*.
- **Rem Demod Unlock Action:** Use the drop-down menu to set the action as *Go to Nominal Power* or *Go to Maximum Power*.

### Modem - Utilities

Use this page to set utilities such as **Date** and **Time** and **Circuit ID**, and to **Load** or **Store Configuration** presets.

- **Re-Center Buffer**: To force the re-centering of the Plesiochronous/Doppler buffer.

- **Force 1:1 Switch:** To toggle the Unit Fail relay to "fail" state for approx. 500ms. If the unit is one in a 1:1 redundant pair and it is currently the *online* unit, this forces a switchover so the unit is then placed in *standby* mode. The command is always executed by the unit, regardless of whether it is standalone, in a 1:1 pair, or part of a 1:N system.

- **Load/Store Configuration:** To **Load** (recall) and/or **Store** up to 10 configuration sets numbered *0* through *9*.

- Date & Time: Use the format *MM/DD/YY* to enter the **Date** (where *MM = month \[01 to 12\]*, *DD = day \[01 to 31\]* and *YY = year \[00 to 99\]*). Use the international format *HH:MM:SS* to enter the **Time** (where *HH = hour \[00 to 23\]*, *MM = minutes \[00 to 59\]*, and *SS = seconds \[00 to 59\]*).

  Use **Time Sync** page button to set the Time Synchronization related parameters.

- Circuit ID Configuration: Create a **Circuit ID** string of up to *24 alphanumeric characters*.

- Clocks: Configure **Tx Clock Source**, **Rx Buffer Size**, **Modem Frequency Reference**, **G.703 Clock Extended Mode**, and **G.703 Clock Extend Interface**.

- Internal Reference:

  - **Warm Up Delay**: For internal frequency reference (OCXO). *Disabled* (instant on - no delay for OCXO to reach temperature) or *Enabled* (unit waits until OCXO reaches correct temperature)

  - **Warm Up Countdown**: Used to truncate the Warm-up delay period to zero, forcing the unit into '*instant-on*' mode. As a query, returns the Warm-up Delay countdown, in seconds remaining. Range is from *000* to *200* seconds.

- Terrestrial Interface:

  - **Interface Type**: Used to define which electrical interface type is active at the data connectors. If *RS422*, *V.35*, or *RS232* is selected, the menu also indicates the operation of RTS/CTS.

  - **RTS**: Defines how RTS/CTS will operate at the main data interface.

  - **Line Build Out**: Valid only for T1 interface.

### Modem - Status

Use this read-only page to view information about the modem's general operating status and configuration parameters.

- **Installed Options**: This read-only section provides information for additional installed options.

### Modem - Logs

Use this page to view Faults and Alarms (i.e., Modem Events) as logged by the unit, and to view modem operating statistics.

- **Clear Events**: To delete all existing log entries from the Modem's Events Log. The log is then reset to one (1) entry: "*Info: Log Cleared*".
- **Initialize Events Pointer**: To Initialize the Events Pointer of the Modem's Events Log.
- **Clear Statistics**: To delete all existing entries from the Modem's Statistics Log.
- **Initialize Stats Pointer**: To Initialize the Stats Pointer of the Modem's Statistics Log.

### Modem - BUC / LNB

Use this page to configure Block Up Converter/Low-Noise Block Down Converter parameters and to display the BUC/LNB status for L-Band operation.

- **BUC/LNB Enabled** used to *Enabled* or *Disabled* polling the BUC and LNB values.

**BUC Configuration**:

- Use the provided toggle buttons to turn **BUC DC Power Control**, **10 MHz Reference**, **RF** **Output** and **Communication** to *Enabled* or *Disabled*.
- **BUC Low** and **High Current Limit** value ranging from *0* to *4000* mA.
- **BUC Lockout Frequency** from *3000* to *65000* MHz and designate the value as a *HIGH (+)* or *LOW (-)* limit.
- **BUC Address** from *0* to *15*.

**BUC Status**: The values displayed in this section are read-only and cannot be changed.

**LNB Control**:

- **DC Supply Voltage:** *Off* or On with *13*, *18* or *24* V.
- **LNB 10MHz Reference:** Enable operations *Disabled* or *Enabled*.
- Assign **LNB Current Lower** and **Current Upper Alarm Limit** values ranging from *10* to *600* mA.
- Assign an **Rx Lockout Frequency** and designate the value as a *HIGH (+)* or *LOW (-)* limit.

**LNB Status**: The **LNB Current** and **LNB Voltage** values displayed in this section are read-only and cannot be changed.

### Maint - Unit Info

**Unit Information**: In this section it is possible to find the **Serial Number** and the **Software Revision**.

**Firmware**: The **Active Firmware Image** and the **Next Reboot Image** are available here for configuration.

### FTP

Use this page to access the FTP functionality. It will allow upgrading the device's firmware.

- **FTP Table** - Gives information and allows changing the required parameters necessary to upload and download firmware files to and from the device.

### FSK

Use this page to have access to FSK functionality. It will be used in the creation of virtual elements.

- **FSK Enabled** - Set to *Enabled* or *disabled* FSK functionality.
- **FSK Element Name** - The *name* used to represent the element.
