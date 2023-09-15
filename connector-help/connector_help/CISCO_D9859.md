---
uid: Connector_help_CISCO_D9859
---

# CISCO D9859

This connector has *control/monitoring* purposes. The **Cisco D9859** device is an *Advanced Receiver Transcoder* that allows to deliver MPEG-4 HD services to MPEG-2 CATV headends.

## About

This is an SNMPv2 connector. Traps can be retrieved if they are enabled on the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.11                        |

## Installation and configuration

### Creation

SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device (e.g. *172.16.8.123*).
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device (e.g. *161*).
- **Get community string**: The community string used when reading values from the device (e.g. *public*).
- **Set community string**: The community string used when setting values on the device (e.g. *private*).

## Usage

### Summary

On this page, you can find the: **Audio Status Table, Video Status Table, Program Entry Status Table** and the **Program Entry PID Table.**

The **About ...** page button gives access to product parameters such as the **About Current Version, About Safe Version, About Product ID, About App Table, ...**

In the **DSG About ...** page button, the **SW Table** and **Firmware Table** can be found.

The **Messages ...** page button contains the **Message Table**.

### Input

On this page you can find the following parameters: **Active Tuning Input, Signal Lock Time, Verify Timer, Active Tuner Table, Satellite Signal Table, ...**

In the **SI Receive Setup** page button, you can find the following tables: **Input Status Table, SI RCV Option Table** and **SI RCV Option Status Table.**

The **Muting Thresholds ...** page button contains the **Muting Thresholds Table**, and the **Backupt Transport Table** can be found in the **Disaster Recovery Status ...** page button.

The **Channel Status ...** page button contains the **Program Entry Status Table** and the **Conditional Access ...** page button, the **CA ADP Table.**

In the **BISS ...** page button the available parameters are; **BISS Mode, BISS Mode 1 Session Word, BISS Mode-E Session Word, BISS Mode-E Injected ID**.

In the **Stream Details** **...** page button are the following tables displayed: **SI Info RX Table, SI Info TS Table, SI Info VC Info Table, Program Entry PID Table.**

### Audio - Video

In the Video Decoding section, you can find the **Video Control Table** and the **Video Status Table**.

In the **Subtitles ...** page button of this section, subtitles related parameters are shown: **Subtitles OP Mode, Subtitles Foreground, Subtitles Manual Entry, ...**

In the same section, the **VBI ...** page button shows, among others: **VBI VITS Flag 17, VBI VITS Flag 18, VBI VITS Flag 330, VBI VITS Flag 331**, etc.

In the Audio Decoding section, you can find 2 tables: **Audio CTRL Table** and **Audio Status Table.**

2 page buttons are also available: **Cueing ... and Decode Enables ...**

In the **Cueing ...** page button, you can find the **Cueing Tone, Cueing Relay Mode, Cueing Tone Sequence Table**, etc.

The **Decode Enables ...** page button displays the **Decode Table.**

### Transport Stream

This page contains the **TS Out Table** and the **TS Out Status Table**.

In the **Digital Program Mapping ...** page button, you can configure the device through the **DPM Regenerate,** **DPM Configuration Table** and **DPM PID Map Table.**

The **Transport Stream ...** page button contains the **DPM Aligned PMT Table.**

In the **MoIP Streams ...** page button, parameters such as the **MoIP IP Output Stats HW Global Error** or the **MoIP IP Output Stats Stream Error** are available. You can also find the **MoIP IP Output Configuration Table** and the **MoIP IP Output Stream Status Table.**

The **Transcoder Setup ...** page button contains the following information: **Transcoder LOI Action, Transcoder Configuration Table, Transcoder Status Table** and **Transcoder Subtitle Table.**

### System Settings

On this page, you can find the **Backup Set Table** and a series of page buttons for specific settings.

In the **Identification ...** page button, you can find among others the **MAC Info Table** and the **Feature Licence Table.**

In the **IP Settings ...** page button, you can find parameters such as the **IP Configuration Table, Protocols CTRL SSH, ETH Backup Status Table** or **Unicast Routes Table**.

The **Time/Clock ...** page button contains the **Time Format** and **Time GMT Offset**.

In the **Alarm Status ...** page button, you have access to the **AW Fault Active List Table.**

The **Alarm Setup ...** page button contains the **AW Fault Status Table** and the **AW Fault Setting Table.**

The **Alarms History ...** page button shows the **AW Fault History Table.**

The **Versions ...** page button gives detailed information about the installed softwares through several tables (**Firmware Version Table, ...**).

This page button contains also a section were you can configure the App/License/FPGA downloads; it contains, among others, the **Download TFTP Server IP, Download Code Version** and **Download TFTP Filename** parameters.

The **Settings File ...** page button contains status/configuration parameters related to the settings file transfer via FTP. You can find here the **Backup Restore Type,** **Backup Restore** **File Name, Backup Restore Last Restore Time** and the **Backup Restore Percentage Completed** parameters, among others.

The **Security/Accounts ...** page button contains 2 sections: the **Lock Level Settings** and the **Front Panel**. In the **Lock Level Settings** section, you can edit the following parameters: **Lock Level, Lock Level PWD,** **Lock Level Current PWD,** **Lock Level New PWD** and **Lock Level Confirm PWD.** In the **Front Panel** section, the following parameters can be altered: **FP UI KB Lock, FP UI KB Lock Timeout, FP UI LCD Contrast** and **FP UI AW Reminder**.

### Support

This page shows the **Diagnostic CTRL History Table**.

The **Usage Counters ...** page button contains the following information: **Power On Creation Date, Power On Total Hours, Power On Factory Reset Count, ...**

The **Fans/Temperatures ...** page button splits fans and temperatures measurements into 3 tables: **Diagnostic Health Monitor Table, Diagnostic FAN RPM Table** and **Diagnostics ECC Readings Table.**

The **Alarm History ...** page button contains the **AW Fault History Table**.

### Miscellaneous

This page contains the **Program Entry Table,** the **MPE Configuration Table** or whether the **DPM PE Mapping Table**.

The **CI ...** page button contains inter alia, the **CI Configuration Table** and **CI** **Program Decrypt Table.**

In the **SDI ...** page button, you have access to, among others, the **VANC Global Status Frames,** **VANC Global Status** **Words, VANC Configuration Table** and **SDI Audio Slot Table**.

### Web Interface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
