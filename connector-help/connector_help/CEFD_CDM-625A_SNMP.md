---
uid: Connector_help_CEFD_CDM-625A_SNMP
---

# CEFD CDM-625A SNMP

The CEFD CDM-625A SNMP is intended to communicate with CDM-625A Comtech devices. The connector is based on the CDM 625 SNMP MIB.

## About

The connector layout is designed to look similar to the web interface of the device.

### Version Info

| **Range**     | **Description**      | **DCF Integration** | **Cassandra Compliant** |
|----------------------|----------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version.     | No                  | No                      |
| 1.0.1.x \[SLC Main\] | Cassandra compliant. | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                                                    |
|------------------|--------------------------------------------------------------------------------|
| 1.0.0.x 1.0.0.8  | Firmware version 1.2.4 (based on manuals of the device) Firmware version 1.4.2 |
| 1.0.1.x          | Firmware version 1.2.4 (based on manuals of the device) Firmware version 1.4.2 |

### Exported connectors

| **Exported Connector**    | **Description**          |
|--------------------------|--------------------------|
| CEFD CDM-625A SNMP (FSK) | FSK Functionality Module |

## Installation and configuration

### Creation

SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays the main device parameters. It is divided in two main sections:

- System Information:

  - **Model Number**: The model number of the modem.
  - **Hardware Revision**: The hardware revision of the modem, in the format *xx.y*, where *xx* indicates the main (bottom) card and *y* indicates the top (modem) card.
  - **Software Revision**
  - **Serial Number**
  - **System Up Time**
  - **KST System Information:** The equipment type and the M&C, upconverter, downconverter, and HPA serial, assembly and firmware numbers.

- Device Overall Status:

  - **Unit Alarm**: Shows whether modem unit faults are present.
  - **Tx Traffic Alarm**: Shows whether modem TX traffic faults are present.
  - **Rx Traffic Alarm**: Shows whether modem RX traffic faults are present.
  - **Offline Unit Status**: Displays the fault status information of the offline modem.
  - **Unit Test Mode**
  - **EDMAC Framing Mode**
  - **Temperature**: The internal temperature of the modem.
  - **Remote control:** Determines whether the unit is being controlled locally, remotely or via IP.

With the **Save Configuration** button, you can save the current configuration. The **Factory Reset** button allows you to reset the device to the factory defaults.

For systems with packet processor KST or CSAT modules, you can toggle polling of the relevant information with the **Poll Packet Processor Module Information,** **Poll KST Module Information** and **Poll CSAT Module Information** toggle buttons.

### Admin - Access / SNMP

On this page, you can configure the IP addresses of the host, which is necessary to enable communication with the CDM-625A web server interface and to set administration information for the CDM-625A SNMP feature.

The page is divided in two main sections:

- Host Access List:

  - **Access List**: Allows you to grant access via HTTP and SNMP to a defined list of client machines.
  - **Access List Overview**: Allows you to define which remote clients can connect when the access list is enabled. For each entry, you can specify an **IP Address** and a **Subnet Mask** to define a unique class of machines that are allowed access.
  - **Authentication Check:** Allows you to test if a username/password combination is correct. The combination must be as follows: *1S:&lt;NONCE&gt;:&lt;USERNAME&gt;:&lt;PASSWORD&gt;)*.
  - **Remote Control:** Allows you to indicate whether the device should work in local or remote mode, and also the type of remote mode.

- SNMP:

  - **Trap IP 1 / Trap IP 2:** Allows you to assign up to two SNMP trap IP addresses.
  - **Trap Version:** Allows you to set the trap version to *SNMPv1* or *SNMPv2*, using the drop-down box.
  - **Trap Community String:** Allows you to assign the SNMP trap community string. The community string should consist of at least 0 and at most 20 alphanumeric characters.

These options (with the exception of Remote Control) are only available when the device is working in *Local* mode (See "Config - Utilities" section below).

### Admin - Firmware

This page displays the firmware booting information, such as the **Bootrom**, **Image 1** and **Image 2**. You can also configure the **Running Image** using the **Boot From** parameter.

### Admin - FAST

A number of optional features can be activated on the unit. Fully Accessible System Topology (FAST) access codes are register-specific, unique authorization codes that can be purchased from Comtech EF Data.

- **Equipment ID**: This read-only section displays the operational status for a number of FAST-enabled features.
- **Hardware**: This section lists the installed and currently operational FAST-enabled features, as well as uninstalled FAST-enabled features that are available for purchase and activation from Comtech EF Data. Slot 1 and 2 have been replaced by future expansions and slot 5 (RAN Optimizer card) is no longer in the MIB. Three extra options are also displayed: Carrier ID, Audio Chips and CnC Activation.
- **Demo**: Displays the available demo time and indicates whether demo mode is activated.

### Config - Modem

This page allows you to configure modem operating (Tx/Rx) parameters:

- **Tx/Rx Interface/Framing**: The Tx/Rx Interface Types and Framing Modes have higher priority than other parameters, and should be configured before other parameters are set.
- **Tx/Rx operating parameters**: In version 625A, the **Tx Filter Rolloff Factor** contains extra values, and the Rx Alpha value can be set.

### Config - LAN - IP

This page allows you to configure parameters related to LAN IP. It consists of four main sections:

- Network Configuration

  - **IP Gateway**: Allow you to configure the IP address of the default gateway. Only applicable in *Managed Switch Mode*.
  - **Traffic/Mgmt IP Address** (and subnet mask): Allows you to configure the modem's IP addresses.
  - **MAC Address**: Displays the Ethernet port MAC address.
  - **MAC Learning**: Allows you to set MAC Learning to *On* or *Off*. Only applicable in *Managed Switch Mode*.
  - **WAN Buffer Length**: Enter a value between *20 ms* and *400 ms*, in *20 ms* increments.
  - **L2 QoS** (Layer 2 QoS): Can be set to *Off*, *VLANonly*, *Port only*, or *VLAN & Port*.
  - **L3 QoS** (Layer 3 QoS): This feature is only operational when the optional IP Packet Processor card is installed and enabled. Allows you to set the L3 (Advanced) QoS to *Off*, *Max/Priority*, *Min Max*, or *DiffServ*.
  - **Dedicated Management Port**: This feature is available in *Managed Switch Mode*, but it is unavailable when **VLAN Mode** is enabled or when the optional IP Packet Processor is enabled. Allows you to set *Port 1*, *Port 2*, *Port 3* or *Port 4* as the **Dedicated Management Port**. If *Port 1 (2, 3, 4) - Local Only* is selected, management is restricted to LAN only. Note that when the optional IP Packet Processor is enabled, the drop-down menu displays *Disabled*. When VLAN is enabled, the drop-down menu displays all the previously described options, but these cannot be selected.
  - **2048 Ethernet Frame Size**: This feature is only supported on modems with hardware revision 2.X or higher. Use the toggle-button to set this feature to *Disabled* or *Enabled*.
  - **Working Mode**: Allows you to set the working mode to *Managed Switch*, *Router Point-to-Point*, *Router Multipoint Hub* or *Router Multipoint Remote*.

- Per Port Configuration: This section contains a table where you can set the parameters for each port (1 to 4):

  - **Port Speed**: Allows you to set the speed for the port to *Auto*, *100 Full-Duplex*, *100 Half-Duplex*, *10 Full-Duplex*, or *10 Half-Duplex*.
  - **Pause Flow Control**: Allows you to set pause flow control for the port to *Off* or *On*.
  - **Port Mode**: Allows you to set the native mode for the port to *Trunk* or *Access*.
  - **PVID**: When **Native Mode** is enabled, a PVID (Native VLAN ID) can be assigned to the selected port using a value range of *0001-4095*.
  - **Priority**: Allows you to set the operational priority of the selected port, in the order of preference (from *1* to *4*).
  - **Actual Negotiated Port Speed**: Displays the status of the current operating actual speed and duplex. If the port is not connected, *Link Down* is displayed.

- VLAN Mode: This mode is supported in *Managed Switch Mode*, with or without the optional **IP Packet Processor** enabled.

  - **VLAN Mode**: Allows you to set the mode to *Disabled* or *Enabled*.
  - **Management VLAN ID**: Allows you to assign a management VLAN ID to the selected port using a value range of *0001-4095*.

- VLAN Table

  - **VLAN ID**: This parameter is read-only and reflects the ID value assigned in the "Per Port Configuration" section of this page (any ID has a value range of 0001-4095).
  - **Port 1** through **Port 4**: Use the drop-down menu to set the port to *Untagged*, *Tagged*, or *Filtered***.**
  - **VLAN Row Status**: Contains a button that can be used to delete this active ID.
  - **Create VLAN**: This button is displayed below the table and allows you to create a new VLAN ID.

A page button provides access to the **ARP Table**. You can add or delete rows in this table using the **Delete** and **Add Row** buttons.

### Config - Routing

This page displays the Route Info table. You can add and delete rows in this table using the **Delete** and **Add Row** buttons.

Via page buttons, you can access the following subpages:

- **IGMP**: Displays IGMP information such as the version and intervals. This subpage also contains the **IGMP Joined Groups** and **IGMP Multicast Traffic** tables.
- **DHCP**: Allows you to configure the **DHCP Relay Feature** and the **Relay IP Address**.
- **DNS**: Allows you to configure the **DNS Caching Feature**. With the **Flush DNS** button, you can flush the DNS cache.

### Config - Managed Switch

On this page, you can enable or disable the **Header Compression Feature**, **Payload Compression Feature** and **Encryption Feature**. You can also select the **Encryption Key**.

### Config - WAN

This page allows you to configure several WAN features, specifically the **QoS SAR Feature** and **QoS Rules**. You can add and delete rows in the QoS Rules table using the **Delete** and **Add Row** buttons.

Via page buttons, you can access the following subpages:

- **Compression**: Allows you to configure the **Header Compression RTP Refresh Rate**, **UDP Refresh Rate** and **Default Refresh Rate** using parameter sliders. You can also configure the **Payload Compression Refresh Rate.**
- **Encryption**: Allows you to configure the encryption and decryption keys, as well as the **Allow Unencrypted Rx** functionality.

### Config - Overhead

The use of the options on this page depends on whether **Carrier-in-Carrier Automatic Power Control** (CnC-APC) mode is selected. Use this page to configure the following overhead interfaces:

- **ESC**: Including Tx/Rx IDR Esc Type, Audio Volume and High Rate ESC.
- **AUPC**: Allows you among others to configure **AUPC Rem Demod Unlock Action**, **AUPC ACM Tx Power Max Increase** and **AUPC ACM Mode**. These parameters can only be used when the **transmitter is in IP-ACM mode**!
- **EDMAC Framing Mode** and **Slave Address**.

Via page buttons, you can access the following subpages:

- **CnC-APC**: Carrier-in-Carrier Automatic Power Control settings - when enabled/activated.
- **IDR Backward Alarms**: Allows the configuration of **Tx 1-4** and **Rx 1-4** alarms.

### Config - Utilities

This page allows you to configure a number of the CDM-625A's utility functions.

- **Redundancy**: If the unit is part of a 1:1 redundant pair of modems and this unit is currently online, click the **Force 1:1 Switch** button to make the unit switch to standby.

- **Re-Center Buffer**: Click this button to force the re-centering of the plesiochronous/doppler buffer.

- **Unit**: This section allows you to configure Unit Test Mode, RTS/CTS Control, HSSI Handshake Control and Local/Distant mode. The **Soft Reboot** button can be used to reboot the device.

- **Clocks**: This section allows you to configure Tx/Rx Clock Sources, Rx Buffer Size, External Clock, External Frequency Reference and G.703 Clock Extended Mode/Interface. In the serial version of this connector, some parameters are unavailable, such as Rx Clock External and Rx External Clock Type.

- **Circuit ID**: Enter a Circuit ID string of up to 40 characters. The Circuit ID you specify here will be displayed in the title bar of compatible web browsers for easy unit identification. A carrier ID can also be enabled or disabled in this section.

- **BERT Config**: This section allows you to set **Bit Error Rate Test** for **Tx** or **Rx** to *On* or *Off*, to configure the pattern for **Tx** or **Rx**, and to set **Error Insertion** to either *Off* or *10E-3*.

- Date & Time:

  - **RTC Date**: Specify a date in MM/DD/YY format (where MM = month \[01 to 12\], DD = day \[01 to 31\] and YY = year \[00 to 99\]).
  - **RTC Time**: Specify a time in HH:MM:SS format (where HH = hour \[00 to 23\], MM = minutes \[00 to 59\] and SS = seconds \[00 to 59\]).
  - **Time Sync** page button: Displays parameters related to time sync.

- Warm-Up:

  - **Warm Up Delay**: Allows you to enable or disable the warm-up delay for internal frequency reference (OCXO). If it is disabled, there is no delay for OCXO to reach temperature. If it is enabled, the unit waits until OCXO reaches the correct temperature.
  - **Warm Up Countdown**: Displays the number of seconds remaining in the warm-up delay countdown.
  - **Truncate Delay**: This button allows you to truncate the warm-up delay period to zero, forcing the unit into "instant-on" mode.

- BERT Monitor: This read-only section displays the ongoing BERT. With the **Restart button**, you can restart the BERT Monitor.

- Save / Load: Saving takes precedence over loading.

  - **Configuration Save / Configuration Load**: These drop-down boxes allow you to save or load up to 10 different modem configurations (numbered *0* to *9)*.
  - **Configuration Slots** page button: Displays the available configuration slots.

### Config - Drop and Insert

This page allows you to configure the drop and insert functionality. The appropriate parameters should be set according to the framing mode selected on the "Config - Modem" page.

### Config - BUC / LNB

When a Block Up Converter (BUC) and a Low Noise Block Down Converter (LNB) are installed, this page can be used to configure the relevant operating parameters and to view the BUC and LNB status for L-band operation.

The page consists of the following sections:

- BUC Configuration:

  - **BUC Power Enable**, **10 MHz Ref Enable** and **Output Power Enable**: These parameters allow you to turn these functions *On* or *Off*.
  - **BUC Low** and **High Current Limit**: Assign a value (in mA) ranging from *0* to *4000*.
  - **Tx LO (Low Oscillator) Frequency**: Assign a value (in MHz) to the Tx LO Frequency, and then use the toggle button to set the value as a *HIGH (+)* or *LOW (-)* limit.
  - **BUC Address**: Assign a value for the BUC address from *1* to *15*.

- BUC Status: Provides information about the BUC status.

- LNB Control:

  - **LNB DC Power**: Use the drop-down box to either set this to *Off* or to choose the appropriate voltage.
  - **LNB Reference Enable**: Use the toggle button to turn this function *On* or *Off*.
  - **LNB Low** and **High Current Threshold**: Assign a value (in mA) ranging from *0* to *500* for either function.
  - **Rx LO (Low Oscillator) Frequency**: Assign a value (in MHz) to the Rx LO Frequency, and then use the drop-down menu to set the value as a *HIGH (+)* or *LOW (-)* limit.

- LNB Status: Provides information about the LNB status.

### Config - ANT

Use this page to configure PTP and SNTP operating parameters. This page consists of the following sections:

- PTP

  - **PTP Feature**: Allows you to enable or disable PTP operation.
  - **PTP Grandmaster**: Use the drop-down box to specify to which side (*LAN* port or *WAN* port) the PTP grandmaster is connected.

- SNTP

  - **Primary Server**: Allows you to set IP address of the primary server.
  - **Backup Server**: Allows you to set the IP address of the backup SNTP server.
  - **Enable SNTP**: Allows you to enable or disable the SNTP feature.

### Config - MEO

This page allows you to view and configure different MEO parameters and to configure the Antenna Handover.

### Status - Modem Status

This page displays read-only status parameters related to Alarms, Rx Parameters, AUPC, CnC (Carrier in Carrier), ACM, General Status and Fractional CnC Counters.

### Status - Modem Logs

On this page, you can configure how faults, statistics and alarm masking parameters are processed by the unit.

The page consists of the following sections:

- Events Log

  - **Poll Event Table**: Allows you to enable or disable polling for the events table.
  - **Events Overview**: Displays the events that have occurred.

- Statistics Log

  - **Statistics Interval**: Allows you to specify the interval at which the statistics are taken.
  - **Statistics Overview**: Displays the statistics.

Via page buttons, you can access the following subpages:

- **Alarm Masking**: Contains toggle buttons that allow you to set specific alarms to *Masked* or *Active***.**
- **Packet Processor**: Allows you to set the level of logging of the packet processor elements of the device. The **Packet Event Logs** table displays the log events.

### Status - Traffic Statistics

The page displays statistics regarding the network interfaces and the Ethernet ports. With the **Clear IP Statistics button**, you can clear the information on this page

Via page buttons, you can access the following subpages:

- **Router**: Displays the number of **Router, Management** and **LAN Received and Transmitted Packets**, as well as the number of counted **IP Header, IP Destination, No Router** and **Buffer Full Errors**. You can clear the counters with the **Clear** button.
- **Managed Switch**: Displays the counters for the **Managed Switch Received** and **Transmitted Packets** for each interface, as well as the **WAN Tx Utilization**, **Tx Data Rate** and **Rx** and **Tx Errors**. You can clear the counters with the **Clear** button.
- **WAN Statistics**: Displays the statistics related to the WAN interface, including the **Satellite Tx** and **Rx Frames** and various errors. You can clear the counters with the **Clear** button.
- **Compression Status**: Displays the **Header Compression Statistics** table, as well as the **Pre-Compression Bytes, Post-Compression Bytes**, **Compression Savings** and **Compression Ratio**.
- **QoS**: Displays the **QoS Mode** and the **QoS Statistics** table. You can clear the counters with the **Clear** button.
- **PTP Statistics**: Displays the PTP statistics on the LAN and WAN interfaces. You can clear the counters with the **Clear** button.
- **MAC Table**: Displays the **MAC Table**, with each **MAC Address, DB Num, CPU Port, Port 1-4, WAN Port** and **MAC Type**.
- **Clear Counters**: Contains the **Clear All Counters** button, which clears all the statistical counters on the device.

### Status - Performance

This page displays device performance information: **CPU Kernel**, **Applications** and **Total Usage** percentages.

### ODU / Redundancy

This page allows you to enable or disable communication with CSAT/KST ODUs for 70/140 MHz operation or LPOD BUCs for L-band operation, and to set up redundancy.

The page consists of the following sections:

- ODU:

  - **ODU Comms**: Allows you to enable or disable ODU operation.

  - If the **CSAT** and **KST** modules are enabled, generic system information such as firmware and software versions can be found below the ODU.

  - Via page buttons, you can access the configuration and status parameters for the **KST** and **CSAT** modules:

    - **KST Config**: Allows you to configure the KST information, such as Circuit ID, AGC State and the Reference Oscillator Adjust.
    - **KST Status**: Displays the KST status information for the Unit, Common Equipment, Reference, AGC, Up and Down Converters, HPA and LNA.
    - **CSAT Config**: Allows you to configure the CSAT modules, including the Circuit ID, Mute Mode and Tx and Rx Frequencies.
    - **CSAT Status**: Displays the CSAT status information for the **Power Supplies**, **Tx and Rx**, and other systems.

- Redundancy:

  - **Redundancy Traffic IP Address and Network Prefix**: Enter the IP address and subnet mask in the format XXX.XXX.XXX.XXX and YY.
  - **Redundancy 1:N mode**: Allows you enable or disable set 1:N redundancy mode. **Use with** **caution**.
  - **Packet Processor Redundancy**: When the optional IP Packet Processor card is installed and enabled in a 1:1 redundancy configuration, there is no need to use this toggle button, as packet processor redundancy is enabled automatically in that case.
  - **Force 1:1 Switch**: When redundant modems are used and the selected unit is currently the online unit, click the **Force 1:1 Switch** button to force a switchover, so the unit will then be in offline (standby) mode. This command is only valid for the online unit in a 1:1 pair.

- Redundancy Monitor:

  - **Redundancy State and Offline Unit Status**: These parameters allow you to monitor the redundancy setup, both the status of the active modem (*Online* or *Offline*) and the detected presence of a redundancy switch.
  - **Redundancy status**: This parameter provides more detailed information than the Redundancy State parameter.

### FSK

This page provides access to FSK functionality. It will be used in the creation of virtual elements.

- **FSK Enabled**: Allows you to enable or disable FSK functionality.
- **FSK Element Name**: The name used to represent the element.

### Web Interface

This page provides access to the web interface provided by the web server of the device. This is only available if the LAN where the element is accessed has access to the IP of the device.
