---
uid: Connector_help_Newtec_M6100
---

# Newtec M6100

This connector is used to monitor the M6100 broadcast satellite modulator.

The transport stream analyzer makes it possible to monitor the incoming transport stream. The purpose of this feature is to help determine if a problem seen at the output of a satellite receiver is due to a problem on the satellite link or to a problem in the headend before the modulator. Consequently, it provides the possibility to identify the root cause of service outages that happened in the video headend or on the transmission path between the video MUX and the satellite modulator. Because the analyzer is built into the modulator, inserting it does not change the behavior of the signal or the topology of the network, making troubleshooting easier. This leads to a shorter defect resolution time.

## About

### Version Info

| **Range**            | **Description**                                                     | **Based on** | **System Impact** |
|----------------------|---------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version                                                     | \-           | \-                |
| 1.0.1.x              | New range for Cassandra compliancy, changed displayColumn to naming | \-           | \-                |
| 1.1.0.x              | New firmware                                                        | \-           | \-                |
| 1.1.1.x \[SLC Main\] | Removed single parameter alarms.                                    | \-           | \-                |

### Product Info

| **Range**      | **Supported Firmware** |
|----------------|------------------------|
| 1.0.0.x1.0.1.x | \-                     |
| 1.1.0.x        | 2.5.3                  |
| 1.1.1.x        | 2.5.3                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | No                      | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.1.0.x   | Yes                 | No                      | \-                    | \-                      |
| 1.1.1.x   | Yes                 | No                      | \-                    | \-                      |

## Configuration

### Connections

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage \[1.0.0.x, 1.0.1.x\]

### General

This page contains device information, such as the CPU load, temperature, power supply voltages, memory use, uptime, and software/hardware information.

On this page, in the **Device Options Table**, you can see which options are enabled on the device. In the **Mgmt Interface Table**, you can see all management interfaces with their IP settings. In the **Data Interface Table**, you can see the DATA interfaces and their IP configuration.

### TS Over IP

On this page, you can monitor the transport stream data. It is also possible to configure the transport streams over IP.

### Protected TS Over IP

This page contains parameters such as TS Over IP Reception, Protected Input Selection, Counter Reset, Measured Input, Switch Count and Active Input. It displays the following alarm parameters: Redundancy Failure Alarm, Redundancy Degraded Alarm, No Input Data Alarm, Buffer Underflow Alarm, Buffer Overflow Alarm, and RTP No Sync Alarm.

In addition, the page contains the **Alarm Status Table**, which details information such as No Input Data, Buffer Underflow, Buffer Overflow, and Input RTP No Sync.

Via page buttons, you can also access the following subpages:

- **Configuration Table**
- **Monitoring Table**

### BISS

On this page, you can monitor the parameters **Scrambling State** and **Session Word Changed**. Other parameters that can be configured here are Scrambling, Scrambling Mode, Key Parity, Scrambling Suppression, Min Raw Unscrambled PID, and Max Raw Unscrambled PID.

Aside from this, you can also enter keys such as **Even Session Word**, **Odd Session Word**, and "encrypted" words. In addition, there is also the **Encryption Mode** with the options *Injected ID* or *Buried ID*.

At the bottom of the page, the **Clear Keys** button allows you to reset all the keys on the modulator BISS module.

### TS Analyser

On this page, several analyzer alarm parameters are displayed. There are two tables, **Analyser PID Table** and **Analyser PCR PID Table**, which provide more information for each analyzer PID and PCR PID.

### TS Mux

On this page, the multiplex data can be monitored. In addition, you can also configure the transport streams MUX. In the **Mux Statistics Table**, a more detailed overview is displayed for each type.

### DVB Modulator

On this page, you can view several DVB modulator alarm parameters and configure the DVB settings.

There are five page buttons: **DVB-S**, **DVB-S2**, **DVB-S2 ACM**, **Equalizer Linear**,and **Equalizer Non Linear**. Each of the subpages shows a more detailed overview of the DVB modulator as well as some settings.

### Input Selection

On this page, you can enable or disable the input in the **Input Selection Table**.

### ASI In

On this page, you can monitor all the ASI In data and configure the ASI In settings.

### ASI Out

This page (introduced in version 1.0.0.23) allows you to monitor and configure all ASI Out data.

### Redundancy

This page contains settings related to redundancy.

### Configurations Page

This table lists all saved configurations in the **Config Table**. You can load, save, and delete configuration files. All configuration files are saved and handled on the system itself. It is not possible to download or upload configuration files.

### Web Interface

This page can be used to access the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage \[1.1.0.x\]

### General

This page displays information about the device, such as the CPU load, temperature, power supply voltages, memory use, uptime, and software/hardware.

The page also contains the following subpages:

- **FTP**: On this page, you can enable or disable the **FTP** and **FTP anonymous account**.
- **Front Panel**: On this page, you can enable or disable the **Front Panel** and select the **Front Panel Access Level**.
- **CLI**: On this page, you can enable or disable the **CLI** and configure the **CLI Inactivity Time**.
- **SNMP**: This page displays the SNMP Notification Destination Table.
- **Device Options**: This page displays the **Device Options Table**, which contains an overview of the enabled device options. The options are specified with the license files.
- **Configuration**: This page contains the **Config Table**, which contains the names of all persistent stored configuration files. The page also allows you to load, save and delete configuration files.
- **Date and Time**: This page displays the **Date** and **Time** of the device.
- **Log**: On this page, you can configure the **Local** and **Remote Logging** of the device.

### Redundancy

On this page, you can configure and view information about the device redundancy, including the **Redundancy Initial State** and **Mgmt Switch Order.**

### ASI Input

This page displays information about the ASI Input. It also allows you to configure parameters such as the ASI Input selection, Inline Splitter, PRBS Generator PID Value, etc.

### ASI Output

This page displays the ASI Output **Measured TS Bit Rate**. It also allows you to configure the **ASI Output Selection** and **Signal Selection**.

### Management Interfaces

This page displays the following tables:

- **Mgmt Interface Table**: Contains information about the management interfaces, such asthe **Interface Name** and **State**. Also allows you to configure the **IP Address** and **Virtual IP Address** of the interfaces.
- **Ethernet Link Management Table**: Contains information about the management Ethernet interfaces, such as the **Name** and **Link State**. Also allows you to configure the MAS Address, Advertised Speeds, Forced Speed, MTU, etc.
- **Ethernet Management Statistics Table**: Contains statistics about the management Ethernet interfaces, such as **Input/Output Bytes**, **Input/Output Packets**, and **Input/Output Dropped Packets**.

### Data Interface

This page displays the following tables:

- **Data Interface Table**: Contains information about the data interfaces, such as the **Interface Name** and **State**. Also allows you to configure the **IP Address** and **Virtual IP Address** of the interfaces.
- **Ethernet Link Data Table**: Contains information about the Data Ethernet interfaces, such as the **Name** and **Link State**. Also allows you to configure the MAC Address, Advertised Speeds, Forced Speed, MTU, etc.
- **Ethernet Data Statistics Table**: Contains statistics about the Data Ethernet Interfaces, such as **Input/Output Bytes**, **Input/Output Packets**, and **Input/Output Dropped Packets**.

### TS Over IP

This page displays information about the TS over IP, such as Input Bit Rate, Buffer Delay, Source Info, and TS In/Out Count. You can also configure the Input Selection, IP Address Type, UDP Port, Traffic Profile, etc.

### Protected TS OVER IP

On this page, you can enable or disable the **Protected TS Over IP Reception** and configure the **Input selection**. The page also displays information, such as the Protected TS Over IP Measured Input, Switch Count, Active Input, and Alarm Status Table.

The following subpages are available:

- **Monitoring Table**
- **Configuration Table**

### BISS

On this page, you can monitor the **Scrambling State** and **Session Word Changed** parameters, as well as configure the Scrambling, Scrambling Mode, Key Parity, Scrambling Suppression, Min Raw Unscrambled PID, and Max Raw Unscrambled PID.

Aside from this, you can also enter keys such as **Even Session Word**, **Odd Session Word**, and "encrypted" words. In addition, there is the **Encryption Mode** with the options *Injected ID* or *Buried ID*.

With the **Clear Keys** button, you can reset all the keys on the modulator **BISS Module**.

### TS Mux

On this page, you can configure parameters such as the Mux Carrier ID, Telephone Number, Longitude, and Latitude. The page also displays the **Mux Statistics Table**.

### DVB Modulator

On this page, you can configure parameters like the Modulator Output Frequency, Roll Off, and Spectrum Polarity.

There are five subpages: **DVB-S**, **DVB-S2**, **DVB-S2 ACM**, **Equalizer Linear**, and **Equalizer Non Linear**. Each of the subpages shows a more detailed overview of the DVB modulator as well as some settings.

### TS Analyser

This page displays the **Analyser Estimated TS Rate** and two tables, the **Analyser PID Table** and the **Analyser PCR PID Table**, which provide detailed information about each analyzer PID and PCR PID. This page also allows you to **reset and enable or disable** the analyzer.

### Input Selection

On this page, you can enable or disable the input in the **Input Selection Table**.

### Ref Clock

This page allows you to configure the **Clock Reference Selection** and **External Reference Frequency**. It also displays the **Active Frequency**.

### Web Interface

This page can be used to access the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

### Alarms

This page displays all the alarm parameters of the Newtec M6100, including **General**, **ASI**, **TS Mux**,and **Modulator Alarms**.
