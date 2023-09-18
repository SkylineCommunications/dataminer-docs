---
uid: Connector_help_Tandberg_E5710
---

# Tandberg E5710

The **Tandberg E5710** is an MPEG2 SD Encoder that can be upgraded to MPEG4 AVC SD (EN8030) and HD encoding (EN8090).

This is an **SNMP** connector that is used to display the status of the different parameters of a **Tandberg E5710 Encoder**.

## About

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|--|--|--|--|
| 1.1.0.x | Release version. Added embedded web page. Enabled backup on all parameters. | No | Yes |
| 1.1.1.x | Dynamic table used for the audio params. New MIBs implemented. **DCF** form version 1.1.1.20 implemented. | Yes | Yes |

## Configuration

### Connections

This connector uses a Simple Network Management Protocol (SNMP) connection, as well as an HTTP connection to retrieve the system uptime, and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not needed.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### Main View Page

This page contains general status information, such as the **Model Number**, **Summary Alarm** and **Video Bit Rate**.

### General Page

This page contains more general status information, such as the **Model Number**, **Time**, **Date**, **Temperature** and **Fan Status.**

The page contains the following buttons:

- **Reset:** Allows you to reset the device.
- **Get Serial ID**: Allows you to retrieve the unique serial number of this device.

In addition, the following page buttons are available:

- **Remote Settings**: Allows you to fill in the **IP Address**, **MAC Address**, **Subnet Mask**, **MIB Version** and **Bus settings** of the device.
- **Build:** Allows you to get extra hardware and software information such as the **Build Version**, **Model Number**, **Board Reference**, etc.
- **License Info:** Allows you to poll the list of licenses of the device.
- **Port Info:** Allows you to view the configuration of the ports in the system.
- **Board Info:** Displays information about the system's hardware, such as the **Slot Number**, **Type**, **Channel**, **Hardware Version**, etc.

### Alarms Page

This page contains a list of alarm indicators, such as **LCD Not Found** and **Over Voltage (5V)**.

The following page buttons are available:

- **Audio Alarms**: Displays a list of all Audio Alarm statuses, such as **PCR Error**, **Audio B Silence Timeout Left**, etc.
- **Video Alarms**: Displays a list of all Video Alarm statuses, such as **Video Line Standard**, **Video Duplicate VBI PID**, etc.
- **Mux Alarms**: Displays a list of all Mux Alarm statuses, such as **Mux Invalid PCR PID**, **Mux Comms Error**, etc.
- **IPStreamer Alarms**: Displays a list of all IPStreamer Alarm statuses, such as **IPStreamer No Response**, **IPStreamer Out of Sync**, etc.
- **Data Alarms**: Displays a list of all RS232 Data Alarm statuses, such as **Data RS232 Comms Error**, **Data RS32 Duplicate PID**, etc.
- **MMI Alarms**: Displays a list of all MMI Alarm statuses, such as **MMI Display**, **MMI Interface**, etc.
- **Normalize Alarms**: Allows you to normalize the **Mux PCR PID** and **Video PID** values.

### Audio Page

This page contains the **Audio Table**, which contains parameters such as the **Coding Standard**, **Bit Rate**, etc.

The following page buttons are available:

- **AC3 Settings**: Displays the **Audio AC3 Table**, which contains parameters such as **Low Frequency**, **Dialogue Norm**, **Compression**, etc.
- **More Settings**: Displays the **More Settings Table**, which contains extra parameters, such as **Language**, **Clip Level**, **Copyright**, **Silence Timeout**, etc.

### Video Page

This page contains parameters such as **Video Input**, **Video Delay**, **Video Text Colour**, etc.

The following page buttons are available:

- **TTx/VBI Settings**: Opens the **Teletext and VBI Settings** subpage, which contains parameters such as the **Teletext PID**, the **Video Index Field 1**, the **Blank Line23**, etc.
- **VBI Lines**: Allows you to define the function of the **VBI Lines**.
- **More Settings**: Opens the **More Video Encoder Settings** subpage, where you can define settings such as the **Video GOP Length**, the **Video Adaptive GOP** and the **Video Deinterlacer** settings.

### SDI Page

This page contains parameters related to **SDI Options**, such as **Video Default Output**, **RAS Mode**, **DSNG Key**, etc.

### Service Page

This page contains parameters related to **Service Types and Descriptions**, such as **Network Name**, **Service Network ID**, **Service PMT PID**, etc.

### Data Page

This page contains parameters related to **RS232** and **RS422** data communication, such as **RS232 Baud Rate, RS232 Delay, RS422 Bit Rate, RS422 Dmode**, etc.

### IPStreamer Page

This page contains 2 tables:

- The **IP Transport Stream Table** contains parameters related to IPStreamer parameters, such as **TS Slot Number**, **IP Output**, etc.
- The **IP Destination Table** contains parameters such as **Destination IP Output**, **Time To Live**, etc.

There is also a page button that links to the **IPStreamer General** subpage, which contains parameters such as **IPStreamer Protocol/FEC**, **IPStreamer Type of Service**, etc.

### MUX Page

This page contains parameters related to the MUX settings, such as **Mux Packet Length**, **Mux Utilised BitRate**, etc.

There are several subpages:

- The **Mux Stream** subpage contains parameters such as **Mux Stream Index, Mux Stream Type, Mux Stream Priority**, etc.

- The **Input Info** subpage contains the **Remux Input Information Table**, which displays the **Remux Input Data Rate**, the **Remux Input Peak Data Rate**, the **Remux PAT Filter Version**, the **Remux SDT Filter Version** and the **Remux Input MGT Filter Version**.

- The **BISS** subpage contains parameters such as the **Mux BISS Session Word**, the **Mux Biss E Injected ID** and the **Mux BISS2 Key Escrow**.

- The **Remux** subpage contains parameters such as **Remux Software Release**, **Remux Mode** and **Remux HostBitrate 188**. It also contains the following three tables:

  - The **Remux Service Information PID Table** contains parameters such as the **Remux PID Entry Index**, the **Remux Service Type**, and the **Remux Original PID**.
  - The **Remux Service Information Table** contains parameters such as the **Remux SI PAT Filter Version**, the **Remux SI SDT Filter Version**, and the **Remux SI PMT Filter Version**.
  - The **Remux Service Information Audio Table** contains parameters such as the **Remux Audio Entry Index** and the **Remux Audio Language Left**.

### Modulator Page

This page contains parameters that refer to the modulator settings, such as the **MOD Format**, **MOD IF Output**, etc.

It also contains the **Modulator Table**, which contains parameters such as the **MOD Modulation**, the **MOD Symbol Rate** and the **MOD FEC Rate**.

The following subpages are available:

- The **Change Next Time Date** subpage contains parameters such as the **Year**, the **Second**, and the **UTC Sign.**
- The **Version Info** subpage displays the **MOD Hardware Release**, **MOD Software Release**, and **MOD Firmware Release** **Versions**.

### Configurations

On this page, you can save and restore the configuration of the device, using the **Upload (conf file --\> device)** and **Download (device --\> conf file)** button.

The page contains parameters such as the **Remote Location**, **Upload Status**, **Download Status**, etc.

### Web Interface

This page allows you to view the original web interface of the device itself. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

The **1.1.1.x** connector range of the Tandberg E5710 protocol supports the usage of DCF and can only be used on a DMA with **9.0.0 \[CU5\]** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Dynamic Interfaces

Virtual dynamic interfaces:

- In/Out: Every row added to Remote DCF Interface Table will automatically add an in/out interface.

Physical dynamic interfaces:

- Inputs: Every input from the Port Table will create an input.
- Outputs: Every output from the Port Table will create an output.

### Connections

#### Internal Connections

- Video:

  - Serial Digital: connection between \[Serial Video Input\] and the \[DVB ASI Outputs\].
  - Analogue/Parallel 656: connection between \[Composite Video Input\] and the \[DVB ASI Outputs\].

- Audio:

  - Connection between \[Serial Video Input\] and the \[DVB ASI Outputs\].
  - Connection between \[Composite Audio Input\] and the \[DVB ASI Outputs\].

- Data:

  - RS 232: connection between \[Data Input with PortDataType = RS 232\] and the \[DVB ASI Outputs\].
  - RS 422: connection between \[Data Input with PortDataType = RS 422\] and the \[DVB ASI Outputs\].
