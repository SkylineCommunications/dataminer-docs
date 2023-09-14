---
uid: Connector_help_CEFD_CDM-625_SNMP
---

# CEFD CDM-625 SNMP

The CDM-625 is an advanced satellite modem that provides the combination of advanced Forward Error Correction (FEC), such as VersaFEC and Low Density Parity Check (LDPC) codes, with DoubleTalk Carrier-in-Carrier bandwidth compression.

## About

This connector uses SNMP to display information from the device and to set device settings. More detailed information can be found on the following website:
<http://www.comtechefdata.com/support/docs/satellitemodemdocs>

### Version Info

| **Range** | **Key Features**                                                                                                   | **Based on** | **System Impact**                                 |
|-----------|--------------------------------------------------------------------------------------------------------------------|--------------|---------------------------------------------------|
| 1.0.0.x   | Initial version                                                                                                    | \-           | \-                                                |
| 1.0.1.x   | \-                                                                                                                 | \-           | \-                                                |
| 1.0.2.x   | Multiple tables now use naming instead of displayColumn to make the database for these tables Cassandra-compliant. | 1.0.1.33     | **Old trend data will be lost for these tables.** |
| 2.0.0.x   | \-                                                                                                                 | \-           | \-                                                |
| 3.0.0.x   | \-                                                                                                                 | \-           | \-                                                |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General

This page provides an overview of the most important parameters of the device, divided in two sections.

The **System Information** section contains the following parameters:

- **Model Number**
- **Hardware Revision**: The modem hardware revision, in the format is "*xx.y",* where *xx* indicates the main (bottom) card, and *y* indicates the top (modem) card.
- **Software Revision**
- **Serial Number**
- **System Up Time**: The time that the device has been operating.

The **Device Overall Status** section contains the following parameters:

- **Unit Alarm**: Modem unit faults.
- **Tx Traffic Alarm**: Modem TX traffic faults.
- **Rx Traffic Alarm**: Modem RX traffic faults.
- **Offline Unit Status**: Provides access to the fault status information of the offline modem. This is the only way to interrogate the status of an offline modem at the distant end of a link.
- **Unit Test Mode**: Allows you to select the type of unit test mode.
- **EDMAC Framing Mode**
- **Temperature**: The internal temperature of the modem.
- **Toggle Polling Speed**: Allows you to toggle between *Normal Polling* and *Fast Polling* of the parameters of the device.

### Admin - Access / SNMP

On this page, you can configure the host's IP addresses, as required to enable communication with the CDM-625 web server interface and to set administration information for the CDM-625 Simple Network Management Protocol (SNMP) feature.

These options are only available when the device is working in *Local* mode (see "Config - Utilities" section below).

- Host Access List:

- **Access List**: Allows you to grant access via HTTP and SNMP to a defined list of client machines.
  - **Access List Overview**: Allows you to define which remote clients can connect when Access List is *Enabled*. Each entry allows you to specify an **IP Address** and a **Subnet Mask** to define a unique class of machines that are allowed access.

- SNMP:

- **Trap IP 1 / Trap IP 2:** Allow you to assign up to two SNMP trap IP addresses.
  - **Trap Version:** Allows you to set the trap version to *SNMPv1* or *SNMPv2* using the drop-down list.
  - **Trap Community String:** Allows you to assign the SNMP trap community string. The community string must consist of a minimum of 0 to a maximum of 20 alphanumeric characters.

### Admin - FAST

The CDM-625 has a number of optional features that can be activated after the unit's purchase. Fully Accessible System Topology (FAST) Access Codes are register-specific, unique authorization codes that can be purchased from Comtech EF Data.

- **Equipment ID:** This **read-only** section displays the operational status for a number of FAST-enabled features.
- **Hardware:** The list displays the **installed** and presently operational FAST-enabled features as well as the **non-installed** FAST-enabled features that are available for purchase and activation from Comtech EF Data.

### Config - Modem

Use this page to configure modem operating (Tx/Rx) parameters:

- Tx/Rx Interfaces and Framing: The **Tx**/**Rx** **Interface Types** and **Framing Modes** have **higher priority** over the other parameters. They should be configured before other parameters are set.
- Tx/Rx operating parameters: Remaining parameters for configuration.
- Carrier-in-Carrier (CnC) parameters: Click the **CnC** page button to access CnC configurable parameters.
- ACM parameters: Click the **ACM** page button to access ACM configurable parameters.

### Config - LAN - IP

Use this page to configure LAN IP-related parameters. Some options are only available when the device is working in *Local* mode (see "Config - Utilities" section below).

The **Network Configuration** section consists of the following parameters:

- **IP Gateway**: The IP address of the default gateway. Applicable only if Working Mode is set to *Managed Switch*.
- **Traffic/Mgmt IP Address** (and subnet mask): Can be used to configure the modem's IP addresses.
- **MAC Address:** The MAC address of the Ethernet port. This parameter is read-only and cannot be changed.
- **MAC Learning:** Applicable only if Working Mode is set to *Managed Switch*. Use the drop-down menu to set MAC Learning to *On* or *Off*.
- **WAN Buffer Length:** Enter a value between *20 ms* and *400 ms*, in *20 ms* increments.
- **L2 QoS** (Layer 2 QoS): Use the drop-down menu to set this feature to *Off*, *VLAN Only*, *Port Only*, or *VLAN & Port*.
- **L3 QoS** (Layer 3 QoS): This feature is only operational when the optional IP Packet Processor card is installed and enabled. Use the drop-down menu to set the L3 (Advanced) QoS to *Off*, *Max/Priority*, *Min Max*, or *DiffServ*.
- **Dedicated Management Port**: This feature is available if Working Modes is set to *Managed Switch*, but it is unavailable when VLAN Mode is *Enabled* or when the optional IP Packet Processor is *Enabled*. Use the drop-down menu to select *Port 1*, *Port 2*, *Port 3* or *Port 4* as the dedicated management port. If *Port 1 (2, 3, 4) - Local Only* is selected, management is restricted to LAN only. Note that when the optional IP Packet Processor is *Enabled*, the drop-down menu displays *Disabled*. When VLAN Mode is *Enabled*, the drop-down menu displays all previously described options, but it will not be possible to select any of them.
- **2048 Ethernet Frame Size:** This feature is only supported on modems with hardware revision 2.X or higher. Set this feature to *Disabled* or *Enabled*.
- **Working Mode:** Use the drop-down menu to select one of the following working modes: *Managed Switch*, *Router Point-to-Point*, *Router Multipoint Hub* or *Router Multipoint Remote*.

In the **Per Port Configuration Table**, you can set parameters for each port (**Port 1** to **Port 4**):

- **Port Speed:** Use the drop-down menu to select the speed for each selected port: *Auto*, *100 Full-Duplex*, *100 Half-Duplex*, *10 Full-Duplex* or *10 Half-Duplex*.
- **Pause Flow Control:** Set Pause Flow Control for the port to *Off* or *On*.
- **Native Mode:** Set Native Mode for the port to *Disabled* or *Enabled*.
- **PVID:** When Native Mode is *Enabled*, a PVID (Native VLAN ID) may be assigned to the selected port using a value range of *0001-4095*.
- **Priority:** Use the drop-down menu to set the operational priority of the selected port, in the order of preference (from *1* to *4*).
- **Actual Negotiated Port Speed:** This is the status of the current actual operating speed and duplex. If the port is not connected, "*Link Down*" is displayed.

VLAN Mode: This mode is supported if Working Mode is set to *Managed Switch*, with or without the optional IP Packet Processor enabled. The **VLAN Mode** section contains the following parameters:

- **VLAN Mode:** Set the mode to *Disabled* or *Enabled*.
- **Management VLAN ID:** A management VLAN ID can be assigned to the selected port using a value range of *0001-4095*.

Below this, you can find the **VLAN Table**, which contains the following parameters:

- **VLAN ID:** This parameter is read-only and reflects the ID value assigned in de PVID column of the Per Port Configuration Table (i.e. any ID has a value range of 0001-4095).
- **Port 1** through **Port 4:** Use the drop-down menu to set the port to *Untagged*, *Tagged* or *Filtered***.**
- **VLAN Row Status:** You can use the button to **Delete** the VLAN ID.
- **Create VLAN:** Allows you to create a new VLAN ID.

### Config - Overhead

The use of this page depends on whether **Carrier-in-Carrier Automatic Power Control** (CnC-APC) Mode is selected. Use this page to configure the following overhead interfaces:

- ESC section: Includes **Tx/Rx IDR ESC Type**, **Audio Volume** and **High Rate ESC**.
- AUPC
- EDMAC Framing Mode and Slave Address
- CnC-APC (page button): Carrier-in-Carrier Automatic Power Control - when *enabled*/*activated.*
- IDR Backward Alarms (page button): For **Tx 1-4** and **Rx 1-4** alarms.

### Config - Utilities

Use this page to configure a number of the utility functions of the device.

- **Redundancy**: If the unit is part of a 1:1 redundant pair of modems and this unit is currently online, click **Force 1:1 Switch** to cause the unit to switch to standby.

- **Re-Center Buffer**: Click **Re-Center Buffer** to force the re-centering of the Plesiochronous/Doppler buffer.

- **Unit**: Use the drop-down menus provided in this section to configure the **Unit** **Test Mode**, **RTS/CTS Control**, **HSSI Handshake Control** and **Local/Distant** mode. Reboot the device using the **Soft Reboot** button.

- **Clocks**: Use the drop-down menus provided in this section to configure **Tx / Rx Clock Sources**, **Rx Buffer Size**, **External Clock**, **External Frequency Reference** and **G.703 Clock Extended Mode / Interface**.

- **Circuit ID String**: Enter a Circuit ID string of up to 40 characters. The Circuit ID, as created here, appears in the title bar of compatible web browsers for easy unit identification.

- **BERT Config**: Use this section to configure the **Tx** and **Rx** **Bit Error Rate Test** as *On* or *Off,* to configure the pattern for **Tx** and **Rx**, and to set **Error Insertion** to either *Off* or *10E-3*.

- Date and Time:

- **RTC Date:** Enter a date using MM/DD/YY format (where MM = month \[01 to 12\], DD = day \[01 to 31\], and YY = year \[00 to 99\]).
  - **RTC Time:** Enter a time using HH:MM:SS format (where HH = hour \[00 to 23\], MM = minutes \[00 to 59\], and SS = seconds \[00 to 59\]).
  - **Time Sync** page button: Time sync-related parameters.

- Warm-Up:

- **Warm Up Delay**: Warm-up delay for internal frequency reference (OCXO). Can be set to *Disabled* (instant on - no delay for OCXO to reach temperature) or *Enabled* (unit waits until OCXO reaches correct temperature).
  - **Warm Up Countdown**: The remaining warm-up delay countdown in seconds.
  - **Truncate Delay**: Used to truncate the warm-up delay period to *zero*, forcing the unit into "*instant-on*" mode.

- **BERT Monitor**: This read-only section displays the ongoing BERT. Click **Restart** to restart the BERT Monitor.

- **Save** / **Load** (save takes precedence over load):

- **Configuration Save / Configuration Load:** Use the drop-down menus to save or load up to 10 different modem configurations - *0* through *9*.

### Config - Drop and Insert

Use this page to configure the Drop and Insert functionality. The appropriate parameters should be set according to the framing mode selected on the **Config - Modem** Page.

### Config - BUC / LNB

When a Block Up Converter (BUC) and a Low Noise Block Down Converter (LNB) are installed, use this page to configure the operating parameters and to view their status for L-band operation.

In the **BUC Configuration** section, you can configure the following parameters:

- **BUC Power Enable, 10 MHz Ref Enable**, and **Output Power Enable**: Use the toggle buttons to turn these functions *On* or *Off*.
- **BUC Low** and **High Current Limit**: Assign a value (in mA) ranging from *0* to *4000*.
- **Tx LO (Low Oscillator) Frequency**: Assign a value (in MHz) to the Tx LO frequency, and then use the toggle button to designate the value as a *HIGH (+)* or *LOW (-)* limit.
- **BUC Address**: Assign a value for the BUC Address from *1* to *15*.

Below this, the **BUC Status** parameter shows the status of the BUC. Some status values are only available when the device is working in *Local* mode (see "Config - Utilities" section above).

In the **LNB Control** section, you can configure the following parameters:

- **LNB DC Power**: Use the drop-down menu to set to *Off* or to choose the appropriate voltage.
- **LNB Reference Enable**: Use the toggle button to turn the function *On* or *Off*.
- **LNB Low** and **High Current Threshold**: Assign a value (in mA) ranging from *0* to *500*.
- **Rx LO (Low Oscillator) Frequency**: Assign a value (in MHz) to the Rx LO frequency, and then use the drop-down menu to designate the value as a *HIGH (+)* or *LOW (-)* limit.

Below this, the **LNB Status** parameter shows the status of the LNB.

### Config - PTP

Use this page to configure PTP operating parameters and to view PTP operating statistics. These options are only available when the device is working in *Local* mode (see "Config - Utilities" section above).

- PTP:

- **PTP Feature**: Set PTP operation to *Enabled* or *Disabled*.
  - **PTP Grandmaster**: Use the drop-down menu to assign to which side (either the *LAN* port or the *WAN* port) the PTP Grandmaster is connected.

- PTP Status:

- **PTP Engine Status**: Shows whether PTP is actively attempting to synchronize time.
  - **PTP Port**: The PTP Port is always Ethernet Port 2 on the modem. This displays whether the Ethernet link is detected.
  - **PTP Date/Time**: Displays the time that has been synchronized with the master device and is being propagated to the slave devices.
  - **PTP** **RTC Date/Time**: Displays the presumed time for the modem. While the PTP time depends on the Grandmaster device, the RTC Time changes only when it is set by the user.
  - **PTP Offset**: Information about the PTP Offset.
  - **PTP WAN State**: Information about the PTP WAN State.
  - **PTP LAN State**: Information about the PTP LAN State.

### Status - Modem Status

Use this page to view read-only status information pertaining to **Alarms**, **Rx Parameters**, **AUPC**, **CnC**, **ACM**, **General Status** and **Fractional CnC Counters**.

### Status - Modem Logs

Use this page to control how the faults, statistics, and alarm masking parameters are processed by the unit.

The **Events Log** section contains the following parameters:

- **Poll Event Table:** Set the polling of the events table to *Enabled* or *Disabled*.
- **Events Overview:** Table showing events.

The **Statistics Log** section contains the following parameters:

- **Poll Statistics Table:** Set the polling of the statistics table to *Enabled* or *Disabled*.
- **Statistics Overview:** The table showing the statistics.
- **Statistics Interval:** Define the interval at which the statistics are measured.

Finally, the **Alarm Masking** page button opens a subpage where you can use the available option buttons to define an alarm as *Masked* or *Active*.

### Status - Traffic Statistics

Use this page to get information about the statistics provided by the device.

- **Interfaces** table: Information about status and speed rates provided by the device's interfaces.
- **Ethernet Statistics** table: Ethernet ingress/egress statistics for each port.
- **WAN Statistics** page button: Opens a page with cumulative WAN traffic information. These status values are only available when the device is working in *Local* mode (see "Config - Utilities" section above).
- **PTP Statistics** page button: Opens a page with data intended to troubleshoot PTP operational issues. These status values are only available when the device is working in *Local* mode (see "Config - Utilities" section above).

### ODU / Redundancy

Use this page to enable or disable communication with CSAT/KST ODUs for 70/140 MHz operation or LPOD BUCs for L-band operation, and to set up redundancy.

In the ODU section, you can use the **ODU Comms** parameter to set the ODU operation to *Disabled* or *Enabled*.

In the **Redundancy** section, you can configure the following parameters:

- **Redundancy Traffic IP Address** and **Network Prefix**: Enter the IP address and subnet mask in the format XXX.XXX.XXX.XXX and YY.
- **Redundancy 1:N mode (use with caution)**: Set 1:N Redundancy mode to *Disabled* or *Enabled*.
- **Packet Processor Redundancy**: When the optional IP Packet Processor card is installed and enabled in a 1:1 redundancy configuration, this toggle button does not have to be used, as Packet Processor Redundancy is enabled automatically.

When redundant modems are used and the selected unit is currently the online unit, click **Force 1:1 Switch** to force a switchover so the unit will then be in offline (standby) mode. This command is only valid for the online unit in a 1:1 pair.

Finally, the **Redundancy State and Offline Unit Status** allow you to monitor the redundancy setup - both the status of the active modem (i.e. *Online* or *Offline*) and the detected presence of a redundancy switch.

### FTP

Use this page to access the FTP functionality, which will allow you to upgrade the firmware of the device.

In the **FTP Table**, you can find information and change the required parameters to upload and download firmware files to and from the device.

### FSK

Use this page to access the FSK functionality, which is used in the creation of virtual elements.

- **FSK Enabled:** Set the FSK functionality to *Enabled* or D*isabled*.
- **FSK Element Name:** The name used to represent the element.

### Save / Load Configuration

On this page, you can save all parameter values to a .csv file. Afterwards, that same file can also be loaded, so that the parameters are set to the saved values.

- By default, the file will be stored in this folder: *C:\Skyline DataMiner\Documents\DMA_COMMON_DOCUMENTS\\PROTOCOLNAME\]*
- The default file name is: *backup_ELEMENTNAME_datetime*

### Web Interface

Use this page to have access to the web interface provided by the device's web server. Note that the client machine has to be able to access the device, as otherwise it will not be possible to display the web interface.
