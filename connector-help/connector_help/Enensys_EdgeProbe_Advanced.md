---
uid: Connector_help_Enensys_EdgeProbe_Advanced
---

# Enensys EdgeProbe Advanced

With this connector, you can configure and monitor an **Enensys EdgeProbe Advanced** DTV Monitoring Probe.

## About

This connector can be used for multiple purposes, including the configuration of the device. You can configure overall settings like the device name or the location of the device, but also network settings, trap settings and alarm settings. It is also possible to monitor different channels on the device (e.g. DVB-T, DVB-C, ETR, Multiplex).

### Version info

| **Range** | **Key Features** | **Based on** | **System Impact**                                                                                                                  |
|-----------|------------------|--------------|------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | Initial version  | \-           | \-                                                                                                                                 |
| 1.0.1.x   | New connector based | 1.0.0.4      | New improved Display look, New features, added data from new MIBs, changed the way the snmp data is retrieved using snmpSetAndGet. |
| 1.0.2.x   | \-               | 1.0.1.14     | New MIBs are added + Data linking between several Echoes Tables                                                                    |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3.1.3.5                |
| 1.0.1.x   | 3.5.3.3                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Enensys EdgeProbe Advance connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *109.7.68.68*.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *public*.

## How to Use

### General

This page contains overall information about the device, such as the **Device Name**, **Device Type**, **Device Location**, **Device Serial Number,** **Firmware** **Version** and **Last** **Update Time**.

### Overview

This page displays a tree view showing the relationship between **Transport Stream**, **Services** and **PIDs**.

Note: This page is available from version 1.0.1.2 onwards.

### System

This page contains a number of buttons that allow you to perform certain operations on the device:

- **Reboot**: Reboots the device.
- **Reset Network**: Resets the network settings.
- **Reset All**: Resets the entire device.
- **Blink LED**: Asks the device to identify itself by blinking a LED.

The page also contains two page buttons, which open the following subpages:

- GPS Status: Displays the status of the **GPS Satellites**.
- Time Config: Allows you to change the time settings, e.g. **Date Time**, **Time Source**, **Time Zone**, etc.
  Note: The **Time Zone** can only be configured when the **Time Source** is configured as *System*.
- Network Interface: Interface table that provides an overview of **all used network interfaces**, with information about the IPv4 addresses, MAC addresses, Gateway, etc. It allows you to change the network settings of each network interface separately.
- Device Option: Table that summarizes thetypes of devices and their current status.

Note: Not every combination of settings is accepted. For example, when **DHCP** is configured, the settings to change the **IP Address** will be disabled. The **Speed** setting *Ethernet 100* cannot be combined with a full **Duplex** configuration, and the interface speed cannot be changed when **Autonegotiation** is enabled.

### Alarms and Logs

This page contains a global overview of the alarms. It displays the **Current Status** of device and the **Alarm Count.** It also allows you to change the **Maximum Temperature** of the device.

There are several page buttons, which open the following subpages:

- Trap Config: On this page, you can configure up to 10 **trap receivers**. Simply fill in the **IP Address** that the traps should be sent to and add the **community string** so all traps can be received by the destination address. The page also allows you to configure the **maximum repetitions**, the **delay** and the **type of trap** that should be sent when certain events occur. It is also possible to quickly **disable a certain trap** configuration.
- Alarm Config: On this page, you can **configure the different alarm types** and determine whether the alarm should trigger a trap or not. There is also a **Counter** indicating how many times a certain alarm has occurred, with a button to **reset this counter**.
- Logs: All log information can be found on this page. The **Log Table** can contain up to 1024 entries. Received traps will cause the current alarm table to refresh.
- Multiplex Alarm Table: Overview of all multiplex alarms.
- Echoes Alarm Table: Overview of all current echo alarms.
- Current Alarm Table: Quick overview of all current alarms.

### Configuration

On this page, you can perform the **configuration of all channels** on the device. The main page allows you to configure overall channel settings such as the **Timer Trap Alive Config**, **Adjustment of the device** and **Drift Reference Clock**.

Several subpages are available:

- Channel T Configuration: DVB-T and DVB-T2 settings, such as **Frequency**, **Signal levels**, **Mer levels**, **Pre Viterbi Ber**, **Post RS (Reed Solomon) Ber** and **DC Constellation degradation** settings. A **Profile Name** can also be changed
- Channel C Configuration: DVB-C and DVC-C2 settings, such as **Frequency**, **Signal levels**, **SNR levels, Post RSPer levels** and **Pre Viterbi Ber** settings. A **Profile Name** can also be changed.
- Channel S2 Configuration: DVB-S2 settings, such as **Frequency**, **LNB Frequency**, **Symbol Rate**, **Band**, **Polarization**, **Isi**, **Signal levels**, **CNR levels, Eb/No levels, PER** and **Link Margin** settings. A **Profile Name** and a **Profile Description** can also be changed. (Only available on 1.0.1.8 version)
- SFN T Configuration: SFN-T, SFN-T2 and T2Mi settings, such as **Drift** **levels**, **Delays** and **Status** settings.
- Channel IP Configuration: Channel IP settings, such as the **Mode**, **IP Address** and **Port**. A **Profile Name** can be changed and a **Description** can be added per IP channel.
- Channel ASI Configuration: Channel ASI settings, such as the **Name**, **Profile Name** and **Description**.
- Channel Isdb-T Configuration: Channel Isdb-T settings, such as the **Frequency**, **Signal levels**, **SNR levels**, **Post RSPer levels**, **Pre Viterbi Ber** and **Post Viterbi** settings. A **Profile Name** can also be changed.
- Mute Configuration: Channel mute settings, such as **Mode**, **Post Vit Ber** settings and **Post Ldpc Ber** settings.
- ETR Configuration: Contains three tables that allow you to configure **ETR1**, **ETR2** and **ETR3** respectively.
- ETR QOS Configuration: This page is related to the ETR Configuration page. It contains two tables, for **SAE Configuration** and **SDE Configuration** respectively. The parameters on this page are mainly of importance for error processing and to maintain the **Quality Of Service of the ETR** channels.
- Multiplex Configuration Table: This page consists of four sections. The top-left section allows you to **add and remove services and PIDs** in the table in the lower left corner and in the lower right corner respectively. The most important table, i.e. the Multiplex Configuration Table, is in the top right corner. It allows you to adapt the multiplex **channel Names**, the **Ts Id Presence** settings, and **Delays** to check if services or PIDs are missing.

Note: For the subpages that allow you to change the profile name, note that the profile has to exist on the device for this. Changing the profile name will change the profile name on the device, but it will not create a new profile.

### Statistics

This page consists of four sections. It also contains page buttons to 12 statistics pages. Each channel type has its own statistics page.

The **RF** section contains four page buttons:

- DVB-T: Information about **Frequencies**, **Lock** **Statuses**, **Signal** **Levels**, **Mer**, **Pre** **Viterbi** **Ber** and **SNR** for the DVB-T Channel and DVB-T2 Channel.
- DVB-C: Information about **Frequencies**, **Lock** **Statuses**, **Signal** **Levels**, **Post RSPer**, **Post** **Viterbi** **Ber** and **SNR** for the DVB-C Channel and DVB-C2 Channel.
- DVB-S2: Information about **Frequencies**, **Lock** **Statuses**, **Signal** **Levels**, **CNR**, **Eb/No**, **PER**, **Link Margin** for the DVB-S2 Channel. (Only available on 1.0.1.8 version)
- Isdb-T: Information about **Frequencies**, **Lock** **Statuses**, **Signal** **Levels**, **Post RSPer**, **Pre and** **Post** **Viterbi** **Ber** and **SNR** for the Isdb-T Channel.
- Echoes: Information about **Echoes level, Channel ID** and **Delays**.

In the **ETR** section, you can enable or disable a freeze of the measures. In addition, there are two page buttons:

- ETR Level 1: Information about **Ts Sync Loss**, **Ts Sync Errors**, **Ts Pat Errors**, **Ts Cont Errors**, **Pmt Errors** and **PID Errors** for the ETR Level 1, ETR Level 2 and ETR Level 3.
- QOS: Information about **SAE Ratios/Thresholds** and **SDE Ratios/Thresholds** for the **Quality of Service** of the ETR Channels.

The **SFN** section contains two page buttons:

- Drift Table: Information about **Delays**, **Measures**, **Statuses** and **Reference Dates** of the SFN channels.
- SFN T2 Mi Delay Table: Information about **Delays**, **Measures**, **Statuses** and **Reference Dates** for SFN T2 Mi channels.

The **Additional** **Statistics** section contains three page buttons:

- One Beam Alarm: Information about **Channel ID**, **PID presence** and **Statuses.**
- Carrier Frequency Offset: Information about **Channel ID**, **Drift levels** and **Statuses.**
- BTS table: Information about **Channel ID**, **Channel Name** and **TMCC alarms**.

In the **Multiplex** section, a **Multiplex Name** can be configured, the **Number of Multiplex Services** is displayed, you can **Reset Bit Rates** and you can select a **Monitored Channel**. The section contains three page buttons:

- Table: Displays the Multiplex Table, which contains an overview of all the **active multiplex services** with the relevant information for these services.
- Service PID: Displays the Service PID Table, which shows **all possible services** with their **PIDs** and **Codec** information.
- Info: Displays information about the **Bit Rates of the Multiplex Services**, and allows you to reset these bit rates.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

For several parameters, a set cannot be performed correctly because of an inconsistency between the device webpage and the device SNMP configuration (on the manufacturer side). This problem is known to occur for the following parameters: channelCConfigName, channelTConfigName, channelIPConfigName, channelIPDescription, channelAsiConfigName and channelAsiConfigDescription. Only the following characters are accepted: a-z,A-Z,0-9, "-" and ".". The manufacturer is looking to solve this problem.
