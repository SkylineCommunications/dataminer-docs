---
uid: Connector_help_CEFD_CDM-570A_SNMP
---

# CEFD CDM-570A SNMP

The **CDM-570** is a Comtech EF Data's entry-level satellite modems and operates at L-band and includes support for externally connected Block Upconverters (BUCs) and Low-Noise Block Downcoverters (LNBs).

This connector implements the available parameters present in the device's MIB. The connector layout is implemented as much as possible like the device's web interface. There are some menus that are not present because they are not available in the MIB and there are some functions that are present in the MIB but not in the web interface.

## About

# Version Info

| **Range** | **Description**     | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version     | No                  | No                      |
| 1.0.1.x          | Cassandra compliant | No                  | Yes                     |

## Configuration

### Connections

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device eg *10.11.12.13*

**SNMP Settings**:

- **Port number**: The port of the connected device, default *161*

- **Get community string**: The community string in order to read from the device. The default value is *public*.

- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### Admin - Summary

This page contains the available information for the admin: Ethernet information, SNMP information and the **Host Acces List.**

### Modem

Use this page to configure the modem operating (Tx/Rx) parameters, including the Tx/Rx Interfaces and Framing. Enter a preferred value into a text box, select a predefined parameter from a drop-down menu or, for the Alarm Mask section, use the option button provided to define a designated alarm as *Masked* or *Active*.

With AUPC, a local modem is permitted to adjust its own output power level in order to attempt to maintain the Eb/N0 at the remote modem.

- **AUPC:** Use the toggle button to select AUPC operation as either *Off* or *On*.
- **Rem Demod Target Eb/N0:** Type in a value, in dB, from *0.0* to *14.9*.
- **Tx Power Max Increase:** Use the drop-down menu to select a value, in dB, from *0* to *9*.
- **Max Pwr Reached Action:** Use the drop-down menu to set the action as *No Action* or *Generate Tx Alarm*.
- **Rem Demod Unlock Action:** Use the drop-down menu to set the action as *Go to Nominal Power* or *Go to Maximum Power*.

### Modem - Utilities

Use this page to set utilities such as Date and Time and Circuit ID, and to Load or Store Configuration presets.

- **Re-Center Buffer**: To force the re-centering of the Plesiochronous/Doppler buffer.
- **Force 1:1 Switch:** to toggle the Unit Fail relay to the "fail" state for approx. 500ms. If the unit is one in a 1:1 redundant pair and it is currently the *online* unit, this forces a switchover so the unit is then placed in *standby* mode. The command is always executed by the unit, regardless of whether it is standalone, in a 1:1 pair, or part of a 1:N system.
- Load/Store Configuration: To **Load** (recall) and/or **Store** up to 10 configuration sets numbered *0* through *9*.
- Date and Time: Use the format *MM/DD/YY* to enter the **date** (where *MM = month \[01 to 12\]*, *DD = day \[01 to 31\]* and *YY = year \[00 to 99\]*).

Use the international format *HH:MM:SS* to enter the **time** (where *HH = hour \[00 to 23\]*, *MM = minutes \[00 to 59\]*, and *SS = seconds \[00 to 59\]*).

Use **Time Sync** page button to set the Time Synchronization related parameters.

- Circuit ID Configuration: Create a **Circuit ID** string of up to *24 alphanumeric characters*.

- Clocks: Configure **Tx Clock Sources**, **Rx Buffer Size**, **Modem Frequency Reference**, **G.703 Clock Extended Mode**, and **G.703 Clock Extend Interface**.

- Internal Reference:

  - **Warm Up Delay**: For internal frequency reference (OCXO). *Disabled* (instant on - no delay for OCXO to reach temperature) or *Enabled* (unit waits until OCXO reaches correct temperature)
  - **Warm Up Countdown**: Used to truncate the Warm-up delay period to zero, forcing the unit into '*instant-on*' mode. As a query, returns the Warm-up Delay countdown, in seconds remaining. Range is from 000 to 200 seconds.

### Modem - Status

Use this read-only page to view information about the modem's general operating status and configuration parameters.
**Installed Options:** This read-only section provides information for additional installed options.

### Modem - Logs

Use this read-only page to view Faults and Alarms (i.e., Modem Events) as logged by the unit, and to view modem operating statistics.

- **Clear Events**: To delete all existing log entries from the Modem Events Log. The log is then reset to one (1) entry: "Info: Log Cleared".
- **Clear Statistics**: To delete all existing entries from the Modem Statistics Log.

### Modem - BUC/LNB

Use this page to configure Block Up Converter parameters, and to display the BUC status for L-Band operation and to configure Low-Noise Block Down Converter parameters, and to display the LNB status for L-Band operation.

**BUC Configuration**:

- Use the provided toggle buttons to turn **BUC DC Power Control**, **10 MHz Reference**, **RF** **Output** and **Communication** *Enabled* or *Disabled*.
- **BUC Low** and **High Current Limit** value ranging from *0* to *4000* mA.
- **BUC Lockout Frequency** from *3000* to *65000* MHz and designate the value as a *HIGH (+)* or *LOW (-)* limit.
- **BUC Address** from *0* to *15*.

**BUC Status**: The values displayed in this section are read-only  and cannot be changed.

**LNB Control**:

- **DC Supply Voltage:***Off* or On with *13*, *18* or *24* V
- **LNB 10MHz Reference:** Enable operations *Disabled* or *Enabled*.
- Assign **LNB Current Lower** and **Current Upper Alarm Limit** values ranging from *10* to *600* mA.
- Assign an **Rx Lockout Frequency** and designate the value as a **HIGH (+)** or **LOW (**-**)** limit.

**LNB Status**: The **LNB Current** and **LNB Voltage** values displayed in this section are read-only and cannot be changed.

### IP - Interface

Use this page to view the MAC address, set the IP address and mask of the IP Module.

**Interfaces Table**

Resume and detail about the device's interfaces.

**Ethernet (LAN)**

- **MAC Address (*read-only*)** - This is set at the factory to a guaranteed unique address that cannot be modified.
- **Mode & Speed** - Use the drop-down menu to select Auto, 10 Mbps Half Duplex, 100Mbps Half Duplex, 10 Mbps Full Duplex, or 100 Mbps Full Duplex.
- **IP Address/Mask** - Enter the IP Address/Mask for the IP Module Ethernet Interface.

**Managed Switch Mode**

- The **Gateway IP Address** may be entered when *Managed Switch Mode* is *active*.

**Terrestrial Interface**

- Use the **Interface Type** drop-down menu to select the operating terrestrial interface: *EIA-422/EIA530 DEC*, *V.35 DCE*, *EIA-232 (sync)*, *G.703 T1 AMI*, *G.703 T1 B8ZS*, *G.703 E1 Unbal AMI*, *G.703 E1 Unbal HDB3*, *G.703 E1 Bal AMI* and *G.703 E1 Bal HDB3*

### Dynamic Threshold

There are two parameters in the **Start Page** - **Rx Eb/No Status** and **Rx Remote Eb/No Status** - that will trigger an alarm when the values of **Rx Eb/No** and **Rx Remote Eb/No** go beyond certain values. These values are described in the **Dynamic Thresholds** Table. So, if **Rx Eb/No** and **Rx Remote Eb/No** have values under **EbNo_min** and above **EbNo_High** a *Critical Low* or *Critical High* Alarm, respectively, will be triggered. Inside the limits, **Rx Eb/No Status** and **Rx Remote Eb/No Status** will be set as *Normal*.

To define these values you need to create a file under the path "C:\Skyline DataMiner\Documents\DMA_COMMON_DOCUMENTS\Lineuplevels\\ with .csv extension. After that, in the **DMAElement**, press the **Refresh File List** button. The **Channels CSV-File Path** will show the name of the file. Then press **Load File**.

If device parameters **Rx Coded**, **RxModulation** and **RxFEC** are the same as the ones described in the file then a row will be shown in the table and the alarms will be set.

### Version 1.0.0.6

All the below pages starting with PaP are only available if the **Packet Processor** is installed.

### PaP - Admin - Working Mode

Use this page to specify how the modem/Packet Processor is to function in Vipersat or non-Vipersat working modes. Once the role of a particular modem in the network is determined, this single point of configuration is intended to simplify deployment.

- **Working Mode -** Use the drop-down menu to select one of the following **Working Modes:** *Router - Small Network Mode; Router - Large Network Mode; Router - Point to Point; Router - Vipersat Mode; Managed Switch.*

### PaP - Admin - Features

**Features - Standard**

- **Telnet/Ping Reply -** Use the toggle button to **Enabled** or **Disabled** **Telnet** or **Ping** **Reply** functionality.
- **Managed Switch Multicast Option -** Use the toggle button to **Enable** or **Disable** **Managed Switch Multicast Option**.
- **L2 Tx/Rx Header Compression -** Use the toggle button to **Enabled** or **Disabled** **L2Tx/Rx** **Header** **Compression**.
- **Downlink Route All Available Multicast -** Use the toggle button to **Enabled** or **Disabled** **Downlink** **Route** **Multicast**.

**Features - Optional**

- **IGMP -** Use the toggle button to **Enabled** or **Disabled** **IGMP** option.
- **Vipersat Auto Switching -** Use the toggle button to **Enabled** or **Disabled** **Vipersat** **AutoS witching** feature.
- **L3/L4/L5 Rx Header Compression -** Use the toggle button to **Enabled** or **Disabled** **L3/L4/L5 Rx Header Compression** option.
- **Vipersat STDMA -** Use the toggle button to **Enabled** or **Disabled** **Vipersat** **STDMA** feature.
- **Vipersat File Streamer -** Use the toggle button to **Enabled** or **Disabled** **Vipersat** **File** **Streamer** feature.

### PaP - Admin - Firmware

PaP - Admin - Firmware page displays the information about the optional Packet Processor's Bootrom and two operational firmware images, and allows the user to configure the unit's handling of firmware upon bootup.

**Firmware**

- **Boot From-** Determines which firmware version will be loaded upon bootup. Use the drop-down list to select:

  - **Latest -** Boots the newest firmware load based upon date.
  - **Image1 -** Boots the firmware loaded into the first slot in permanent storage.
  - **Image2 -** Boots the firmware loaded into the second slot in permanent storage.

- **Upgrade To -** Determines which installed firmware will be use to overwrite when upgrading with a new firmware download. Use the drop-down list to select:

  - **Oldest -** Overwrites the oldest firmware based upon date.
  - **Image1 -** Overwrites the firmware loaded into the first slot in permanent storage
  - **Image2 -** Overwrites the firmware loaded into the second slot in permanent storage.

**Save Packet Processor parameters to flash**

- **Save PaP Parameters -** Causes all configuration changes made during this operational session to the unit to be save to permanent storage. These updates are permanent until the user either initiates and saves a new round of settings updates, or restores all settings to the original factory defaults.

### PaP - Config - LAN

Use this page to configure LAN IP related parameters.

**Network Configuration**

- **IP Address/Mask -** Use this field to configure the modem's Management IP Address.
- **Managed Switch Gateway IP -** Use this field to configure this IP Address.
- **Traffic IP Address/Mask** (not applicable in Managed Switch Mode) - Use this field to configure the modem's **Traffic IP Address**. Note that this address is assigned automatically when the modem is running in **Managed Switch Mode**.
- **MAC Address -** This parameter is read-only and cannot be changed.
- **Dedicated Management Port -** This feature will be supported in future releases.

**Port Configuration**

- **Traffic Port Mode & Speed** - Use the drop-down menu to select the speed port: *Auto*, *10 Mbps Half-Duplex, 100 Mbps Half-Duplex, 10 Mbps Full-Duplex, 100 Mbps Full-Duplex*.

**VLAN Brouter Configuration**

- **VLAN Brouter Mode -** Use the toggle button to **Enabled** or **Disabled** **VLAN** **Brouter** **Mode**.
- **VLAN** **Brouter** **Tx** **Payload** **Compression-** Use the toggle button to **Enabled** or **Disabled** **VLAN** **Brouter** **Tx** **Payload** **Compression**.
- **VLAN** **Brouter** **Next** **Hop** **MAC** **Address -** Enter the desired **Next** **HopMAC** **Address**.
- **VLAN** **Remote** **Mode -** Use the toggle button to **Enabled** or **Disabled** **VLAN** **Remote** **Mode**.
- **VLAN** **Filtering** **-** Use the toggle button to **Enabled** or **Disabled** **VLAN** **Filtering**

This page also contains the page button **VLAN IDs ...**, which opens a page where you can assign up to *10* **VLAN** **ID** addresses within the range from *1* to *4095*. On this page, it is also possible to find a **VLAN table**. For the **VLAN table**, you can create new entries by clicking on the **Create New Entry...** page button and filling in the required fields on the pop-up page. It is also possible to delete a VLAN entry from **VLAN table** by pressing the button **Delete**.

## PaP - Config - ARP

**The PaP - Config - ARP** page displays an **ARP** **table**. For the **ARP** **table** the user can create new entries by clicking on the **Create New Entry.** page button and fill in the required fields on the pop-up page. If it's needed to clean all the dynamic entries than the user can click on the **Flush Dynamic ARP**.

### PaP - Config - Routing

**Route configuration**

The PaP - Config - Routes page displays the **Routing** **table**. For the **Route** **table** the user can create new entries by clicking on the **Route Table Entry.** page button and fill in the required fields on the pop-up page. It's also possible to delete a route entry from the **Route table** by pressing the button **Delete**.

**IGMP - CDM-570A as Client**

- **Recognize IGMP Queries -** Use the toggle button to **Enabled** or **Disabled** **IGMP** Queries.
- **IGMP Version for Unsolicited Reports -** Use the drop-down list to select **V1** or **V2**.
- **Unsolicited Report Interval -** This is the maximum response time inserted into group-specific queries that are set in response to Leave Group messages, and it is also the amount of time between group-specific query messages. This value may be tuned to modify the "leave latency" of the network; a reduced value results in reduced time to detect the loss of the last member of a group - values from *1* to *25*.
- **Force Router Alert Option Sending V1 Reports -** Use the toggle button to **Enabled** or **Disabled** **ForceRouter Alert Option Sending V1 Reports**.

**IGMP - CDM-570A as Server**

- **Enable IGMP -** Use the toggle-button to select **Enabled** or **Disabled**. If enabled, the IP Module responds to IGMP queries for the configured multicast routes on the transmit side and generates IGMP queries on the receive side.
- **IGMP Query Period -** This is the interval between general queries sent by the modem - values from *1* to *600 seconds*.
- **IGMP Maximum Response Time -** This is the maximum response time inserted into the periodic general queries - values from *1* to *600 seconds*.
- **Missed Responses Before Leaving IGMP Group -** Enter the number of desired missed responses - values from *1* to *30*.

**IGMP Table**

This *read-only* table lists the IGMP Groups that are active on the unit. This includes the **TTL** (*Time to Live*) for the entry; the **Client State** (*Idle, Active*, or *Closing*); and the **SRC** and **Group Entries**. Click **Refresh** button to update **IGMP Table** with its latest available information.

**DHCP Relay**

- **DHCP Server IP Address -** Enter the IP Address to be used for the **DHCP** server at the hub in the form XXX.XXX.XXX.XXX. Enter 0.0.0.0 to **disable** this feature.

### PaP - Config - Managed Switch

- **3xDES -** Use the drop-down list to select an operation such as **Disabled;** **Enabled** or **Per** **Route**.
- **Tx Payload Compression -** Use the drop-down list to select an operation such as **Disabled;** **Enabled** or **Per Route**.
- **L3/L4/L5 Tx Header Compression Opt -** Use the drop-down list to select an operation such as **Disabled;** **Enabled** or **Per Route**.

### PaP - Config - WAN

**QoS Configuration**

- **QoS Feature -** Use the toggle button to Enabled or Disabled QoS feature.
- **QoS Mode -** Use the drop-down list to set the **QoS Mode as** *Rule - Max Priority Mode; Rule - Min/Max Mode; Diff Serv Mode*, or *VLAN - Priority Max Mode*.
- **QoS Typical System Latency** - Enter a value, in milliseconds, from *200* to *5000*.
- **WAN Segmentation and Reassembly (SAR) Feature** - Use the toggle button to **Enabled** or **Disabled** **WAN** **SAR** feature.

**Compression Configuration**

- **Header Comp. Refresh Rate UDP/RTP1 -** Enter the number of packets, from *1* to *600*, required to trigger the Header Compression's User Datagram Protocol/Real Time Protocol refresh rate.
- **Header Comp. Refresh Rate for UDP -** Enter the number of packets, from *1* to *600*, required to trigger the Header Compression's User Datagram Protocol refresh rate.
- **Header Comp. Refresh Rate for all Others -** Enter the number of packets, from *1* to *600*, required to trigger the Header Compression's Default Protocol refresh rate.
- **Payload Comp. Refresh Rate -** Enter the number of packets, from *1* to *600*, required to trigger the Payload Compression's refresh rate.

### PaP - Status - Stats - x Ethernet / Router / WAN / Compression / QoS

Each of these PaP - Status - Stats - x pages will display the status for the subject in the page name.

In the top of each page, there are two buttons available, **Refresh** and **Clear** that will to update the page with the latest polled data or to erase all existing information and reset the statistics counters, respectively.

### PaP - Status - Stats - Clear Counters

Click on **Clear** to erase all existing information and reset the statistics compilation buffers from all **Traffic Statistics** pages (*Ethernet, Router, WAN, Compression,* and *QoS*).

### PaP - Status - Performance

In this page you can see the **CPU Usage**.

### Version 3.0.0.8

### Admin - Summary

Use this read-only page to obtain information for the assigned **MAC** and **IP Addresses** and the currently available standard and optional operational features.

- **MAC Address (read-only)** - This is set at the factory to a guaranteed unique address that cannot be modified. The MAC address for the Ethernet interface.
- **IP Address/Mask**: The IP Address/Mask for the IP Module Ethernet Interface.
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

**BUC Configuration**

- Use the provided toggle buttons to turn **BUC DC Power Control**, **10 MHz Reference**, **RF** **Output** and **Communication** to *Enabled* or *Disabled*.
- **BUC Low** and **High Current Limit** value ranging from *0* to *4000* mA.
- **BUC Lockout Frequency** from *3000* to *65000* MHz and designate the value as a *HIGH (+)* or *LOW (-)* limit.
- **BUC Address** from *0* to *15*.

**BUC Status**: The values displayed in this section are read-only and cannot be changed.

**LNB Control**

- **DC Supply Voltage:***Off* or On with *13*, *18* or *24* V.
- **LNB 10MHz Reference:** Enable operations *Disabled* or *Enabled*.
- Assign **LNB Current Lower** and **Current Upper Alarm Limit** values ranging from *10* to *600* mA.
- Assign an **Rx Lockout Frequency** and designate the value as a *HIGH (+)* or *LOW (-)* limit.

**LNB Status**: The **LNB Current** and **LNB Voltage** values displayed in this section are read-only and cannot be changed.

### FTP

Use this page to access the FTP functionality. It will allow upgrading the device's firmware.

- **FTP Table** - Gives information and allows changing the required parameters necessary to upload and download firmware files to and from the device.

### FSK

Use this page to have access to FSK functionality. It will be used in the creation of virtual elements.

- **FSK Enabled** - Set to *Enabled* or *disabled* FSK functionality.
- **FSK Element Name** - The *name* used to represent the element.
