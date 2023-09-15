---
uid: Connector_help_CEFD_CDM-625A_Serial
---

# CEFD CDM-625A Serial

The CEFD CDM-625A Serial is a serial connector intended to communicate with CDM-625A Comtech devices. The connector is based on the CDM 625 serial connector (version 3.0.0.3), but contains certain additions.

## About

The connector layout has been configured to look as much like the web interface of the device as possible. The layout is also very **similar to** that of the **625A SNMP** connector. However, as certain parameters cannot be retrieved using serial commands even though they are available in the MIB, these parameters are not available in this version of the connector.

This connector will export different connectors based on the retrieved data. A list can be found in the section "Exported Connectors" below.

### Ranges on the connector

| **Range**     | **Description**     | **DCF Integration** | **Cassandra Compliant** |
|----------------------|---------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version     | No                  | No                      |
| 1.0.1.x \[SLC Main\] | Cassandra compliant | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.4.1                       |
| 1.0.1.x          | 1.4.1                       |

### Exported Connectors

| **Exported Connector** | **Description**               |
|-----------------------|-------------------------------|
| CEFD 625A Serial.FSK  | BUC/LNB-specific information. |

## Installation and configuration

### Creation

During element creation, you must fill in the **device IP address** and the **port**.

The device **bus address** does not have to be filled in by default and is *0000*. However, if the device responds with "TIMEOUT" messages instead of valid responses, you may need to set the bus address to another value (between *1* and *9999*), corresponding to the bus address of the device.

## Usage

### General

This page provides an overview of the most important parameters of the device, divided into two sections.

The **System Information** section contains the following parameters:

- **Model Number**
- **Hardware Revision**: The modem hardware revision, in the format *xx.y*, where *xx* indicates the main (bottom) card, and *y* indicates the top (modem) card.
- **Software Revision**
- **Serial Number**

The **Device Overall Status** section contains the following parameters:

- **Unit Alarm**: Modem unit faults.
- **Tx Traffic Alarm**: Modem TX traffic faults.
- **Rx Traffic Alarm**: Modem RX traffic faults.
- **Offline Unit Status**: Provides access to the fault status information of the offline modem. This is the only way to interrogate the status of an offline modem at the distant end of a link.
- **Unit Test Mode**
- **EDMAC Framing Mode**
- **Temperature**: The internal temperature of the modem.
- **Remote control:** Defines whether the unit is being controlled locally, remotely or via IP, and allows you to configure the serial remote control parameters baud rate, I.O. format, and address. *(Not available in SNMP \[1.0.0.1\] version of the protocol.)*
- **Fast OGC Polling**: Toggles the polling speed for OGC commands between *normal* (15 minutes) and *fast* (30 seconds.) *(Not available in SNMP \[1.0.0.1\] version of the protocol.)*

### Admin - Firmware

This page displays information about the base modem firmware and **Packet Processor** firmware (if available). The page also allows you to select the firmware version that will be used after the next reboot of the modem.

### Admin - FAST

The CDM-625 has a number of optional features that may be activated after the unit's purchase. Fully Accessible System Topology (FAST) access codes are register-specific, unique authorization codes that can be purchased from Comtech EF Data.

This page provides three sections with parameters related to this:

- **Equipment ID**: This **read-only** section displays the operational status for a number of FAST-enabled features.
- **Hardware**: This list displays the **installed** and presently operational FAST-enabled features as well as **non-installed** FAST-enabled features that are available for purchase and activation from Comtech EF Data. Slot 1 and 2 have been replaced by future expansions and slot 5 (RAN Optimizer card) is no longer in the MIB. Three extra options are also displayed: Carrier ID, Audio Chips and CnC Activation. Note that some information about options is only available in the SNMP version of this connector.
- **Demo**: Displays whether **Demo Mode** is enabled, and the **Demo Time** remaining.

### Config - Modem

On this page, you can configure operating (Tx/Rx) parameters of the modem:

- Tx/Rx Interfaces and Framing: The **Tx**/**Rx** **Interface Types** and **Framing Modes** have **higher priority** than other parameters. You should therefore configure these before setting other parameters.
- Tx/Rx Operating Parameters: In version 625A of the connector, the **Tx Filter Rolloff Factor** has extra values, and the Rx Alpha value can be set. In the SNMP version, this can be selected via a separate parameter; however, in the serial version, this is grouped with the **Receive Equalizer** parameter.

### Config - LAN - IP

Use this page to configure LAN IP-related parameters.

The **Network Configuration** section consists of the following parameters:

- **IP Gateway**: The IP address of the default gateway. Applicable only if Working Mode is set to *Managed Switch*.
- **Traffic/Mgmt IP Address** (and subnet mask): Can be used to configure the modem's IP addresses.
- **MAC Address**: The MAC address of the Ethernet port. This parameter is read-only and cannot be changed.
- **MAC Learning**: Applicable only if Working Mode is set to *Managed Switch*. Use the drop-down menu to set MAC Learning to *On* or *Off*.
- **WAN Buffer Length**: Enter a value between *20 ms* and *400 ms*, in *20 ms* increments.
- **L2 QoS** (Layer 2 QoS): Use the drop-down menu to set this feature to *Off*, *VLAN* *only*, *Port only*, or *VLAN & Port*.
- **L3 QoS** (Layer 3 QoS): This feature is only operational when the optional IP Packet Processor card is installed and enabled. Use the drop-down menu to set the L3 (Advanced) QoS to *Off*, *Max/Priority*, *Min Max*, or *DiffServ*.
- **Dedicated Management Port:** *This feature is available if Working Modes is set to *Managed Switch*,* but it is unavailable when VLAN Mode is *Enabled* or when the optional IP Packet Processor is *Enabled*. Use the drop-down menu to set *Port 1*, *Port 2*, *Port 3*, or *Port 4* as the dedicated management port. If *Port 1 (2, 3, 4) - Local Only* is selected, management is restricted to LAN only. Note that when the optional IP Packet Processor is *Enabled*, the drop-down menu displays *Disabled*. When VLAN is *Enabled*, the drop-down menu displays all previously described options, but it will not be possible to select any of them.
- **2048 Ethernet Frame Size**: This feature is only supported on modems with hardware revision 2.X or higher. Use the toggle button menu to set this feature to *Disabled* or *Enabled*.
- **Working Mode**: Use the drop-down menu to set the Working Mode to one of the following options: *Managed Switch*, *Router Point-to-Point*, *Router Multipoint Hub* and *Router Multipoint Remote*.

In the **Per Port Configuration** section, you can set parameters for each port (**Port 1** to **Port 4**):

- **Port Speed:** Use the drop-down menu to select the speed for each selected port: *Auto*, *100 Full-Duplex*, *100 Half-Duplex*, *10 Full-Duplex*, or *10 Half-Duplex*.
- **Pause Flow Control:** Set Pause Flow Control for the port to *Off* or *On*.
- **Port Mode:** Set the Native Mode for the port to *Trunk* or *Access*.
- **PVID**: When **Native Mode** is *Enabled*, a PVID (*Native* VLAN ID) may be assigned to the selected port using a value range of *0001-4095*.
- **Priority:** Use the drop-down menu to set the operational priority of the selected port, in the order of preference (from *1* to *4*).
- **Actual Negotiated Port Speed:** This is the status of the currently operating actual speed and duplex. If the port is not connected, "*Link Down*" is displayed.

VLAN Mode: This mode is supported if Working Mode is set to *Managed Switch*, with or without the optional IP Packet Processor *enabled*. The **VLAN Mode** section contains the following parameters:

- **VLAN Mode:** Set the mode to *Disabled* or *Enabled*.
- **Management VLAN ID:** A management VLAN ID can be assigned to the selected port using a value range of *0001-4095*.

Below this, you can find the **VLAN Table**, which contains the following parameters:

- **VLAN ID:** This read-only parameter reflects the ID value assigned in the Per Port Configuration Table (i.e. any ID has a value range of *0001-4095*).
- **Port 1** to **Port 4:** Use the drop-down menu to set the port to *Untagged*, *Tagged*, or *Filtered***.**
- **VLAN Row Status:** You can use the button to **Delete** the active ID.
- **Create VLAN**: Allows you to create a new VLAN ID.

### Config - Overhead

The use of this page depends on whether **Carrier-in-Carrier Automatic Power Control** (CnC-APC) mode is selected. Use this page to configure the following overhead interfaces:

- ESC section: Includes the **Tx/Rx IDR Esc Type**, **Audio Volume** and **High Rate ESC**.
- AUPC: Includes the **AUPC Rem Demod Unlock Action**, **AUPC ACM Tx Power Max Increase** and **AUPC ACM Mode**. These parameters can only be used when the Transmitter is in **IP-ACM mode**.
- EDMAC Framing Mode and Slave Address
- CnC-APC (page button): Carrier-in-Carrier Automatic Power Control - when *enabled*/*activated.* This version of the connector contains additional parameters compared to the SNMP version.
- IDR Backward Alarms (page button): For **Tx 1-4** and **Rx 1-4** alarms.

### Config - Utilities

Use this page to configure a number of the utility functions of the device:

- **Redundancy**: If the unit is part of a 1:1 redundant pair of modems and it is currently online, click **Force 1:1 Switch** to switch the unit to standby.

- **Re-Center Buffer**: Click **Re-Center Buffer** to force the re-centering of the Plesiochronous/Doppler buffer.

- **Unit**: Use the drop-down menus provided in this section to configure the **Unit** **Test Mode**, **RTS/CTS Control**, **HSSI Handshake Control** and **Remote Control** (Local/Distant in SNMP version) mode. Reboot the device using the **Soft Reboot** button. **Modem Emulation** is a feature that can only be configured using the serial version of the connector. The emulation mode cannot be set using SNMP.

- **Clocks**: Use the drop-down menus provided in this section to configure **Tx/Rx Clock Sources**, **Rx Buffer Size**, **External Clock**, **External Frequency Reference** and **G.703 Clock Extended Mode/Interface**. Note that here the serial version does not contain some parameters that can be found in the SNMP version, such as Rx Clock External and Rx External Clock Type.

- **Circuit ID**: Enter a Circuit ID string of up to 40 characters. The Circuit ID, as created here, appears in the title bar of compatible web browsers for easy unit identification. A carrier ID can also be enabled or disabled.

- **BERT Config**: Use the drop-down menus provided in this section to set the **Bit Error Rate Test** for **Tx** or **Rx** to *On* or *Off*, configure the pattern for **Tx** or **Rx**, and set **Error Insertion** to either *Off* or *10E-3*.

- Date and Time:

- **RTC Date**: Enter a date using MM/DD/YY format (where MM = month \[01 to 12\], DD = day \[01 to 31\], and YY = year \[00 to 99\]).
  - **RTC Time**: Enter a time using HH:MM:SS format (where HH = hour \[00 to 23\], MM = minutes \[00 to 59\], and SS = seconds \[00 to 59\]).
  - **Time Sync**: Time sync-related parameters.

- Warm-Up:

- **Warm Up Delay:** Warm-up delay for internal frequency reference (OCXO). Can be set to *Disabled* (instantly on: no delay for OCXO to reach temperature) or *Enabled* (unit waits until OCXO reaches correct temperature).
  - **Warm Up Countdown**: The warm-up delay countdown remaining (in seconds).
  - **Truncate Delay**: Used to truncate the warm-up delay period to *zero*, forcing the unit into "*instant-on*" mode.

- **BERT Monitor**: This read-only section displays the ongoing BERT. Click **Restart** to restart the BERT monitor.

- **Save** / **Load** (save takes precedence over load):

- **Configuration Save / Configuration Load:** Use the drop-down menus to save or load up to 10 different modem configurations, *0* through *9*.
  - In the serial version of the connector, the page button **Configuration slots**, which shows the available configuration slots, is not available.

### Config - Drop and Insert

On this page, you can configure the Drop and Insert functionality. The appropriate parameters should be set according to the framing mode selected on the **Config - Modem** page. Note that this page is different from the equivalent page in the SNMP version of the connector.

### Config - BUC / LNB

When a Block Up Converter (BUC) and a Low Noise Block Down Converter (LNB) are installed, use this page to configure the relevant operating parameters and to view the BUC and LNB status for L-band operation.

In the **BUC Configuration** section, you can configure the following parameters:

- **BUC Power Enable**, **10 MHz Ref Enable**, and **Output Power Enable**: Use the drop-down menus to turn these functions *On* or *Off*.
- **BUC Low** and **High Current Limit:** Assign a value (in mA) ranging from *0* to *4000*.
- **Tx LO (Low Oscillator) Frequency:** Assign a value (in MHz) to the Tx LO frequency, and then use the toggle button to designate the value as a *HIGH (+)* or *LOW (-)* limit.
- **BUC Address:** Assign a value for the BUC address, from *1* to *15*.

Below this, the **BUC Status** parameter shows the status of the BUC.

In the **LNB Control** section, you can configure the following parameters:

- **LNB DC Power**: Use the drop-down menu to either set this to *Off* or choose the appropriate voltage.
- **LNB Reference Enable**: Use the toggle button to turn this function *On* or *Off*.
- **LNB Low** and **High Current Threshold**: Assign a value (in mA) ranging from *0* to *500*.
- **Rx LO (Low Oscillator) Frequency**: Assign a value (in MHz) to the Rx LO frequency, and then use the drop-down menu to designate the value as a *HIGH (+)* or *LOW (-)* limit.

Below this, the **LNB Status** parameter shows the status of the LNB.

### Config - ANT

On this page, you can configure PTP and SNTP operating parameters.

The following PTP parameters can be configured:

- **PTP Feature**: Set PTP operation to *Enabled* or *Disabled*.
- **PTP Grandmaster:** Use the drop-down menu to configure to which side (either the *LAN* port or the *WAN* port) the PTP grandmaster is connected.

The following SNTP parameters can be configured:

- **Primary Server**: Set the IP address of the primary server.
- **Backup Server**: Set the IP address of the backup SNTP server.
- **Enable SNTP**: Allows you to enable/disable the SNTP feature.

### Config - MEO

On this page, you can view and set different **MEO** (Medium Earth Orbit) parameters, as well as configure **Antenna Handover**.

### Status - Modem Status

This page displays status information pertaining to **Alarms**, **Rx Parameters**, **AUPC**, **CnC** (Carrier in Carrier), **ACM**, **General Status** and **Fractional CnC Counters**.

### Status - Modem Logs

Use this page to configure how the fault, statistics, and alarm masking parameters are processed by the unit.

The **Events Log** section contains the following parameters:

- **Poll Event Table**: *Enable* or *Disable* the polling of the events table.
- **Events Overview**: An overview of all events that have occurred.

The **Statistics Log** section contains the following parameters:

- **Statistics Interval**: The interval at which the statistics are logged.
- **Statistics Overview**: The table showing the statistics.

Finally, the **Alarm Masking** page button opens a subpage where you can use the available option buttons to define an alarm as *Masked* or *Active***.**

### ODU / Redundancy

Use this page to enable or disable communication with CSAT/KST ODUs for 70/140 MHz operation or LPOD BUCs for L-band operation, and to set up redundancy.

In the ODU section, you can use the **ODU Comms** parameter to set the ODU operation to *Disabled* or *Enabled*.

In the **Redundancy** section, you can configure the following parameters:

- **Redundancy Traffic IP Address and Network Prefix**: Enter the IP address and subnet mask in the format XXX.XXX.XXX.XXX and YY.
- **Redundancy 1:N Mode (Use with Caution)**: Use the drop-down menu to set 1:N Redundancy mode to *Disabled* or *Enabled*.
- **Packet Processor Redundancy**: When the optional IP Packet Processor card is installed and enabled in a 1:1 redundancy configuration, there is no need to use the toggle button here, as Packet Processor Redundancy is then enabled automatically.

When redundant modems are used and the selected unit is currently the online unit, click **Force 1:1 Switch** to force a switchover so the unit will then be in offline (standby) mode. This command is only valid for the online unit in a 1:1 pair.

Finally, the **Redundancy State and Offline Unit Status** allow you to monitor the redundancy setup - both the status of the active modem (i.e. *Online* or *Offline*) and the detected presence of a redundancy switch.

Note that the SNMP version also contains the **New redundancy status**, with more information than the Redundancy State parameter, but this is **not available** in the serial version of the connector.

### FSK

On this page, you can access the FSK functionality, which is used for the creation of virtual elements:

- **FSK Enabled**: *Enable* or *disable* the FSK functionality.
- **FSK Element Name:** The name used to represent the element.

### Web Interface

Use this page to access the web interface provided by the web server of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
