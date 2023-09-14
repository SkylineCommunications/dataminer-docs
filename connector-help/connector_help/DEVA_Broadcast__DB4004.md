---
uid: Connector_help_DEVA_Broadcast__DB4004
---

# DEVA Broadcast DB4004

The **DB4004** is a second-generation digital FM Radio Modulation Analyzer.

## About

The device is able to check FM channels. It contains a round-robin system that does not keep track of the status parameters. The time each channel should be measured by the round-robin engine is actively checked and adjusted on the device in order to know which channel is being monitored. Once the channel is known, the status parameters are polled and a table is built with status data for the channels.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.9.123 (2014/09/08)        |

## Installation and configuration

### Creation

#### Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.150.3.3*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *public*.

## Usage

### Front Panel

This page contains two page buttons:

- The **Product Info** page button displays the firmware revision and the serial number of the device.
- The **Security Panel** page button displays a block of access/administration parameters.

The page also contains a number of parameters, among others the **Tuner Settings**, which provide control over tuner and audio processing and the two RF antenna input settings.

### Output Settings

This page displays two blocks of parameters: **GPO settings** and **Audio/MPX Output.** The general purpose output settings are applied through this page. In the Audio/MPX output section you can configure the Audio and MPX outputs. Function, type and pulse time for each of the GPOs can be set individually.

### Communication Settings

This page contains 12 page buttons with configuration options, namely **GSM Modem**, **UECP UDP**, **UECP TCP**, **Syslog**, **Streamer**, **Email**, **SNTP**, **FTP**, **HTTP**, **Application**, **SNMP** and **Ethernet**. It also displays a block with a parameter corresponding to each of the page buttons, with the enable/disable option for each of them.

### Alarms Settings

This page displays several **Alarms Triggers** for the following parameters: **RF**, **MPX**, **MPX Power**, **Left/Right Audio**, **RDS Group**, **Pilot**, **RDS Levels**, **Temperature** and **Fan**. In case a parameter exceeds the limits, the device will initiate the sending of an alarm notification via the selected communication path, which can be via **Email**, **SMS**, **SNMP Trap** or **GPO**.

### Status Page

This page shows the **alarm status** of each parameter of the preset frequencies. A **Channel Status Table** is displayed, in which each entry matches with a channel that is being monitored.

### Logger Interface

On this page, you can select and monitor up to 50 radio frequencies by applying the necessary settings. When adjustments are made, the device will monitor all of the selected frequencies at regular intervals. Every channel consists of group settings, which are used when monitoring and alerting. Measurement windows can be set for each of the alarms, including trigger and alarm release times.

### Monitoring

This page displays a table that contains the current channel that is being monitored. The following parameters are evaluated: **Frequency**, **RF** (level, average and peak maximum), **Multipath** (level, average and peak maximum), **MPX** (level, average and peak maximum), **MPX Power** (level, average and peak maximum), **Pilot** (level, average and peak maximum), **RDS** (level, average and peak maximum), **Left/Right** (level, average and peak maximum), **LPR** (level, average and peak maximum), **LMR, Temperature** (level, average and peak maximum), **Fan** (level, average and peak maximum), **RDS Group**, **RDS Lock**, **RDS PI**, **RDS PS**, **RDS RT**, **RDS TA**, **RDS Music speech**, **RDS TP**, **RDS PTY**, **RDS BER** and **Audio Stereo**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Revision History

DATE VERSION AUTHOR COMMENTS

09/10/2015 1.0.0.1 TPI, Skyline Initial version
17/12/2015 1.0.0.2 TPI, Skyline Extra parameters added.
14/04/2016 1.0.0.3 TPI, Skyline Active and Inactive channels fixed on Status table.
16/09/2016 1.0.0.4 TPI, Skyline Alarm RDS Group A and Alarm RDS Group B in the Channel Status Table are now numeric values.
24/07/2017 1.0.0.5 BSM, Skyline Fixed an inconsistency in the round-robin logger channel measurements
12/09/2017 1.0.0.6 BSM, Skyline Removed QAction 2, which forced the acquisition time to 60s. Removed polling of some of the
monitoring parameters to improve logger quality. Added Web Interface page.
01/15/2018 1.0.0.7 RRE, Skyline Average Measurements, RDS Lock, and RDS BER parameters added to monitoring table.
Drop-down display key option added to monitoring table with same \[IDX\] format as channel table.
11/06/2018 1.0.0.8 RBL, Skyline Added avg parameters to Monitoring Table. Exceptions described in task handled.
