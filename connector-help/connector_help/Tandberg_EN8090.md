---
uid: Connector_help_Tandberg_EN8090
---

# Tandberg EN8090

This is an SNMP connector that will show the status of the different parameters of a **Tandberg EN8090 receiver**.

## About

The **Tandberg EN8090** is a High Definition MPEG-4 AVC Encoder. This connector uses both an SNMP and an HTTP connection to communicate with the device. Note that there is also DCF functionality integrated in the connector. For more information, refer to the "General Settings" section below.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | Yes                 | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | v4.4                        |

## Installation and Configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection, as well as an HTTP connection to retrieve the system uptime.

#### SNMP Connection

For the SNMP connection, the following input from the user is necessary:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not needed.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public.*
- **Set community string**: The community string in order to set to the device. The default value is *private.*

#### Serial Connection

The connector also uses a hardcoded **serial** connection on the configured IP address on port *1820* to retrieve the **Unique Serial Number**. This connection requires no additional user information.

## Usage

### Main View Page

This page contains general status information such as the **Model Number, Unit Alarm, Remote Control Mode, Encoder Up Time** and **Device Serial ID**.

### General Page

This page contains more general status information, such as the **Model Number**, **Time**, **Date**, **Temperature**, **Fan Status**.

The following page buttons are available:

- **Credentials**: Allows you to fill in the credentials for retrieving the **Current System Uptime**.
- **Configurations**: Provides the option of exporting and importing configurations for your device.
- **Remote Settings**: Opens the **Remote Communication Settings** page, where you can fill in the **IP Address, MAC Address, Subnet Mask, MIB settings**, and **Bus settings** of the device.
- **Build**: Opens the build page, where you can get extra hardware and software information, such as the **Build Version, Model Number, Board Revision**, etc. The page also contains a number of additional page buttons, which display information about **Licenses**, **Ports** and **Hardware Boards**.
- **Normalize Alarms**: Allows you to normalize **Bitrates, Video and Audio PIDs,** and **RS322 PIDs**.

The **Reset button** allows you to reset the device, and the **Get Sys Up Time** button allows you to get the **current System Uptime**.

Finally, the **Features** page button opens a table listing all the features and their **license state**.

### General Settings Page

This page contains general DataMiner settings, as well as the **DCF** settings.

To configure the DCF settings, in the **DataMiner Connectivity Framework** section, click the **Configure...** button.

The DCF tables that are used are **Interfaces, Connections**, and **Connection Properties**.

- The **Interfaces** table lists the Input and Output interfaces that are present in the system, and is created at the startup of the element, or when the board type changes. The input interfaces consist of an **SDI** and an **HD-SDI** interface, and the output interfaces consist of three **ASI** interfaces, and, depending on the model of the board, two **Gigabit** **interfaces** as well.
- The **Connections** table lists the connections that exist for the protocol. These depend on the status of the **Mux on Air** parameter, the **Video Input** parameter, and the **IP Destination** table. If **Mux On Air** is set to *Off*, no connections are defined. Otherwise, a connection is made between the **Video Input** parameter and the three **ASI** interfaces. The selected **Video Input** parameter will also be connected to the **Gigabit IP** interfaces, but this depends on the **IP Destination** table, which will contain 0 or more entries for the **IP connections**. Each entry can be set to *Port 1, Port 2, Both*, or Auto.
- The **Connection properties** table lists the properties for the **IP Connections**. These consist of the *IP address:Port* for the output stream.

### Alarms Page

This page contains a list of alarm indicators, such as **LCD Not Found, Over Voltage (5V)** and a table with the alarms that are currently active.

The page also contains the following page buttons:

- **Audio Alarms:** Displays a list of all **Audio Alarm** statuses, such as **Audio A Level Clipping Right**, **Audio B Silence Timeout Left**, etc.
- **Video Alarms:** Displays a list of all **Video** **Alarm** statuses, such as **Video Line Standard**, **Video Duplicate VBI PID**, etc.
- **Mux** **Alarms:** Displays a list of all **Mux** **Alarm** statuses, such as **Mux Invalid PCR PID**, **Mux Comms Error**, etc.
- **IPStreamer** **Alarms:** Displays a list of all **IPStreamer** **Alarm** statuses, such as **IPStreamer No Response**, **IPStreamer Out of Sync**, etc.
- **Data** **Alarms:** Displays a list of all **RS232 Data Alarm** statuses, such as **Data RS232 Comms Error**, **Data RS32 Duplicate PID**, etc.
- **MMI Alarms:** Displays a list of all **MMI Alarm** statuses, such as **MMI Display**, **MMI Interface**, etc.

### Service Page

This page contains parameters that are related to **Service Types and Descriptions**, such as the **Video Input, Video Frame Rate, Video Noise Reduction,** etc.

The page also includes the following page buttons:

- **TTx/VBI Settings:** Displays parameters related to **Teletext** and the **VBI**, such as **Teletext PID, Teletext Initial Page, VBI PID, Blank Line23**, etc.
- **More Settings:** Leads to additional video settings, such as **Video Encode, Video Scene Cut Detection, Video CC Format, Video VBR Mode**, etc.
- **AFD/Process Settings:** Leads to settings about video processing, such as **Video AFD GPI User Mode, Video Despeckle Filter**, etc.
- **GOP Settings:** Leads to settings about GOP, such as **Video GOP Structure, Video GOP Length,** etc.

### Audio Page

This page contains the following three tables:

- **Audio Table**: Contains parameters such as **Audio Channel, Audio Clip Level, Audio Sample Frequency,** etc.
- **Audio Table Extra**: Contains extra parameters such as **Audio DTS Framesize, Audio HD Source, Audio VPS Word 5**, etc.
- **Audio Input Level Measurements Table**: Contains parameters such as **Audio Firmware Release, Audio Hardware Release,** etc.

### Data Page

This page contains parameters that relate to **RS232** and **RS422** Data communication, such as **RS232 Baud Rate, RS232 Delay, RS422 Bit Rate, RS422 Dmode**, etc.

### IPStreamer Page

This page contains the following two tables:

- **IP Transport Stream Table**: Contains parameters related to IPStreamer parameters, such as **TS Slot Number, IP Output**, etc.
- **IP Destination Table:** Contains parameters such as **Destination IP Address, Time To Live**, etc.

There are also page buttons that lead to the following subpages:

- **IP Address**: Contains a table with parameters such as **Port IP Number, Port IP Address**, etc.
- **IP Common Setup**: Contains a table with parameters such as **TS Packets, Multicasting**, etc.
- **IP Settings**: Contains a table with parameters such as **IP Address of Board, Board Subnet Mask**, etc.
- **Output Channels**: Contains a table with parameters such as **Channel Number, Destination IP**, etc.
- **Input Channels**: Contains a table with parameters such as **Destination Input UDP Port, RTP Input**, etc.
- **IP Port:** This page contains parameters that refer to the **IP Port settings**, such as **IP Slot Number, IP Software Version**, etc.

### MUX Page

This page contains parameters that refer to the **MUX** settings, such as **Mux Packet Length, Mux Bit Rate**, etc.

### Switching Vlan Page

This page contains **VLAN** configuration parameters, such as **Rx Bitrate Port 1, Tx Packet Rate Port 2**, etc.

### Debug Page

This page contains **Debug** parameters, such as **Failure on Port1, Same Values on Port 1**, etc.
