---
uid: Connector_help_SYes_PCM_Television
---

# SYes PCM Television

The **SYes PCM Television** is a multistandard RF transmitter.

## About

This is an **SNMP** connector for the SYes PCM Television device.

### Version Info

| **Range** | **Description**         | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version         | No                  | Yes                     |
| 1.1.0.x          | New firmware version 40 | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | version 29                  |
| 1.1.0.x          | version 40                  |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Connection:

- **IP Address/host**: The polling IP of the device, e.g. *10.145.1.12*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

## Usage

### General Page

This page displays system parameters, such as **SNMP Mode**, **Management Mode**, **Working State**, **Data Availability**, **System Alarm**, **Up Time**, **Maximum Severity**, **Firmware Bank Incoherence**, **Operating Mode** and **Trap Dispatching**.

The **Input General Status** page button displays the general status information, including the **External Reference**, **10 MHz Reference, Hitless Switch Mode, Input Module Status, GPS Absent, PPS Absent, Clock Reference, Auto Switch Ref Presence, PPS Max Difference, PPS Difference** and **PPS Compare Warning**.

The **Input Trap Mangmt** page button displays the trap configuration parameters, such as **SW Hitless Trap, Alm Trap, On-Air Trap,** **Int PPSAbsent Trap,** **Ext PPSAbsent Trap,** **Ext10 Mhz Absent Trap, Module Status Trap** and **Summary Alm Trap.**

The **System Information** page button displays the **Firmware Version** and other firmware information, including the **Firmware Code, Firmware Release** and **Firmware Build.**

### Transmitter Overview

This page displays operative configuration parameters and power measurements, such as **Nominal Power**, **Forward Power**, **Forward Power dBm**, **Reflected Power**, **Tx Forward Power** and **Tx Forward Power dBm**.

The configuration options include the **Output Channel Frequency**, **Transmitter Mode** and **System Struct Type**.

### Transmitter Configuration

On this page, you can configure transmitter settings and power settings, such as **System Equipment Type**, **Power Thresholds**, **Input Channel Frequency**, **Output Channel Frequency** and **Channel Offset**.

There are six page buttons available, which provide access to parameters related to **ISDB-T**, **SFN**, **Tx Command**, **Tx Trap Mngmt**, **Tx Precorrection** and **Tx Input General Status**.

### Transmitter GPS

This page displays all GPS-related parameters:

- **GPS Units**
- **GPS System Status**
- **GPS Info Table**
- **GPS Status Table**
- **GPS Alarms Table**
- **GPS Configuration Table**

### Repeater Configuration

This page displays parameters such as the **Repeater Mode** and **Selectivity Delay**. In the **Echo Canceller** section, you can find parameters such as the Echo Window, Echo Delay, Multipath Echo Window and Multipath Window Type.

It is also possible to configure the **Repeater Activation**, **Repeater Standby** and **Lockout Reset**.

Note: All of the parameters on this page will appear as *N/A* if the **Transmitter Mode** (on the "Transmitter Overview" page) is set to *DVBT2*.

### RBL Configuration

This page displays **DVBT2 Configuration**, **Alarm** and **Transmitter Receiver Status** parameters.

Configuration options include **DVBT2 Network Mode**, **Bandwidth**, **Transmission ID**, **MI Control Mode**, **Cell ID**, **Network ID**, **T2 System ID** and **Configuration Coherency**.

Alarms include **DVBT2 Delay Offset Alarm**, **RT Lock** and **Input Module Status**.

Other transmitter receiver status parameters include **Profile**, **L1 Post Constellation**, **IFFT, Guard Int, Pilot Pattern, MISO, T2 Frame Number, Data Number, P1 Detected, Lock L1 Pre, Lock L1 Post, Lock DMD, Offset, MER, SNR** and **BER (pre LPDC)**.

Note: All of the parameters on this page will appear as *N/A* if the **Transmitter Mode** (on the "Transmitter Overview" page) is set to *REPEATER*.

### RBL Input Management

This page includes **source selection**, **configuration** and **status** parameters related to the input of the device. These are only relevant when the device is in *RBL Mode*.

Parameters include: **Input Switch Mode**, **Input Selection**, **Input on Air**, **ASI Output Source**, **GBE Sources**, **External Reference**, **10 MHz Reference**, **Hitless Switch Mode**, **GPS Absent alarm**, **PPS Absent alarm**, **10 MHz Reference Absent alarm**.

Note: All of the parameters on this page will appear as *N/A* if the **Transmitter Mode** (on the "Transmitter Overview" page) is set to *DVBT2*.

### Gap Filler Configuration

This page includes **configuration options**, **power options** and **alarm events** that are only relevant when the device has been placed in *Gap Filler Mode*.

Options include **GF Nominal Power**, **Channel Frequency**, **Repeater Channel Offset**, **Repeater Low Power Warning Threshold**, **Repeater Reflected Power Alarm Threshold**, **Repeater Selectivity Delay**, **Gap Filler Repeater Mode** and **GF Input Channel Frequency**.

Alarm events include **Management Mode**, **Working State**, **Repeater Status**, **Low Power Warn**, **Low Power Alarm**, **Reflected Power Warn**, **Reflected Power Alarm**, **Lockout Alarm**, **Interlock Alarm**, **Squelch**, **Out Fifo Alarm**, **Echo Canceller Warn**, **Lock Warn**, **Input Over Power Alarm** and **Input Low Power Alarm**.

**Forward Power** and **Reflected Power** measurements are also included.

Finally, the page also contains the **Echo Canceller**, **Commands** and **System Information** page buttons.

Note: All of the parameters on this page will appear as *N/A* if the **Transmitter Mode** (on the "Transmitter Overview" page) is set to *DVBT2*.

### Alarms

This page displays all alarm-related parameters, such as:

- **Low Power Warning**
- **Low Power Alarm**
- **Interlock Alarm**
- **Internal PPS**
- **Hardware Status**
- Etc.

### Webpage

This page displays the webpage of the device. Note that the client computer has to be able to access the device, as otherwise it will not be possible to open the web interface.
