---
uid: Connector_help_Nevion_NX4600
---

# Nevion NX4600

The **NX4600** is an H.264/AVC encoder, decoder and media gateway, which can be deployed with up to 4 codec modules per unit. Each codec module offers Baseband SDI video signals to IP and vice versa, compresses or decodes using H.264/AVC or MPEG-2, and transmits or receives the streams over IP/Ethernet.

## About

This connector is used to manage the Nevion NX4600 device using the **HTTP** protocol.

This connector will export different connectors based on the retrieved data. A list can be found in the section "Exported Connectors".

### Version Info

| **Range** | **Description**                     | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                     | Yes                 | Yes                     |
| 1.1.0.x          | New firmware version                | Yes                 | Yes                     |
| 1.1.3.x          | Added DCF to the inputs table       | Yes                 | Yes                     |
| 1.1.4.x          | Added Encoder and Decoder DVEs      | Yes                 | Yes                     |
| 2.0.0.x          | Alarm descriptions custom formatted | Yes                 | Yes                     |

Note: Upgrading **from range 1.0.0.x to range 1.1.0.x** or higher will cause the **loss of all saved data**, including trending and the alarm history.

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.8.6                       |
| 1.1.0.x          | 2.0.16                      |
| 1.1.2.x          | 2.0.16                      |
| 1.1.3.x          | 2.0.16                      |
| 1.1.4.x          | 2.0.16 2.8.3                |
| 2.0.0.x          | 1.8.6                       |

### Exported connectors

| **Exported Connector**                                                        | **Description** |
|------------------------------------------------------------------------------|-----------------|
| [Nevion NX4600 - Encoder](xref:Connector_help_Nevion_NX4600_-_Encoder) | Encoders        |
| [Nevion NX4600 - Decoder](xref:Connector_help_Nevion_NX4600_-_Decoder) | Decoders        |

## Installation and configuration

### Creation

#### HTTP connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP connection:

- **IP address**: The polling IP or URL of the destination.
- **IP Port**: The IP port of the destination, by default *80*.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection to receive traps and requires the following input during element creation:

SNMP connection:

- **IP Address/host**: The polling IP of the device.

SNMP settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

### Configuration

As this connector makes use of System.Web.dll, **.NET Framework 4.0** must be installed on the system for the connector to work.

## Usage

### Inputs Page

This page contains an overview of the inputs (ASI, SDI, SS2, Ethernet, TSoIP, TT2 and CC2).

Note: From version 1.1.2.6 onwards, the IDX for all the input tables can be changed via the **Input Display Key** drop-down list. The default option is *Name.Label*, but to include the custom description the option *Name.Label.Custom Description* can be selected instead.

### Transport Streams Page

This page contains an overview of all transport streams in the **Transport Streams** **table**. For each transport stream, this table shows the **Status**, **Mode**, **Total Rate**, **Effective Rate**, **TS ID**, and **ON ID**.

In addition, a number of columns in the table indicate whether a specific alarm is present for a particular transport stream (e.g. **Sync Byte Error**, **PAT Repetition Interval**, etc.).

### Services Page

This page provides an overview of all services in the **Services** **table**. For each service, this table shows the **Provider**, **Type**, **EIT Schedule Signaled**, **Scrambling Signaled**, **PMT PID**, **PCR PID**, and **Total Rate**.

In addition, a number of columns in the table indicate whether a specific alarm is present for a particular service (e.g. **PMT Missing**, **Too Many PIDs**, etc.).

### PIDS Page

This page contains information related to the PIDs. Two tables are displayed: the **PIDs** table and the **PCR PIDs** table.

The PIDs table displays an overview of all PIDs, showing among others which service each PID is part of (**Ref. by service**), and the **Type**, **Rate**, **Continuity Error Counter**, etc.

In addition, the table contains a number of columns indicating whether a specific alarm is present for a particular PID (e.g. **Unreferenced PID**, **PID Rate** **Too High**, etc.).

The PCR PIDs table contains information about the PCR PIDs, such as **Clock**, **Local Clock**, **Max Jitter**, etc.

### Alarms Page

This page displays an overview of the alarms that are currently active (and implemented by the protocol).

This device polls alarms via the HTTP interface. It also updates existing data based on incoming traps via the SNMP interface.

Via the **Filtered Alarms** page button, you can get an overview of the alarms that are currently present, but filtered in the **Filtered Alarms Table**. To process traps for filtered alarms, set the toggle button **Process Traps for Filtered Alarms** to *Yes*.

Via the **Auto Clear** page button, you can set configuration parameters for the automatic clearing of alarms in the **Alarms Table** and the **Filtered Alarms Table**. When **Max Duration Status** is set to *Enabled*, alarms that are older than the number of days specified in the **Notification Max Duration** parameter are automatically removed from the table.

Note that many alarms are related to a specific transport stream, service or PID. Therefore, for many alarms an additional column has been defined in the corresponding **Transport Streams**, **Services** or **PIDs** table. For example, for the alarm with ID 1101 ("TS unstable"), a column **TS Unstable** is defined in the **Transport Streams** **table** that indicates if this alarm is present for a particular transport stream.

### Transform

This page contains all information regarding the **TS** and **Video** **Input** **Switch**, allowing not only full monitoring, but also the configuration of every existing input.

Furthermore, this page also provides access to related **Routing** features and **RPC** calls as well as to all real-time information regarding **alarms**.

### Overview Page

This page displays a tree view that shows the relation between the inputs, transport streams, services and PIDs.

### General Page

This page contains general information about the device, such as the **Device Name**, **Location**, **Software Version** and **Unit Up Time**.

### System Alarms Page

This page shows the current system alarms in a table.

### Chassis Configuration Page

On this page, you can manage the interfaces available on the device. Two tables are displayed: **Main Board** and **Slot**.

The available ports are displayed in the **Main** **Board** table, while the four expansion slots for ASI or H.264/AVC codec modules are listed in the **Slot** table.

### Network Page

This page displays a (read-only) tree view that shows the relation between IP interfaces and VLANs. Note that all tables used on this page can be accessed via the **Network** page button.

### Outputs Page

This page contains information related to the output itself. Three tables are displayed:

- The **Output Overview** table displays an overview of all outputs, showing information such as the **Source Input**, **TS Name**, **Slot**, **Original Network ID**, etc.
- The **TS-IP** table displays all codec modules, as well as the DVB-ASI outputs. It shows among others the parameters **TS Packets Per Frame**, **RTP SSRC Mode** and **FEC RTP SSRC Mode**.
- The **IP Destinations** table contains information related to TS routing and distribution, such as **Destination IP/Port**, **Source Port**, **Data Payload Rate**, etc.

### Encoder Page

This page displays a (read-only) tree view related to the encoder. Note that all tables used on this page can be accessed via the **Encoder** page button.

From version **1.1.4.1 onwards**, the generation of Encoder DVEs can be enabled or disabled in the **Encoder Overview Table.**

### Decoder Page

This page displays a (read-only) tree view related to the decoder. Note that all tables used on this page can be accessed via the **Decoder** page button.

From version **1.1.4.1 onwards**, the generation of Decoder DVEs can be enabled or disabled in the **Decoder Overview Table.**

The page provides access to two ways of audio mapping, via the **Audio Table** and **Audio Mapping** page buttons.

- The **Audio Table** button will redirect to a table to map the audio.
- The **Audio Mapping** button will redirect to a matrix to map the audio.

### DVEs Page

From version **1.1.4.1 onwards**, this page allows you to view the DVE element IDs, as well toggle the **Automatic DVE Removal**.

In addition, it is possible to **Remove All DVEs** by pressing the button at the top of the page.

### Event History Page

This page contains detailed information about the last event traps (unitAlarmAsserted, unitAlarmCleared and unitEvent) sent by the unit.

### Templates Page

This page is available from version **1.1.0.3 onwards**. It contains templates that can enhance provisioning of the device.

With the **Ts Input Template** table, you can make templates for the configuration of multicast IP addresses and UDP ports that can be applied to a TS input or to all TS inputs of a TS input switch.

Via the table context menu, you can add a template with an alias of your choice. This alias will be available for selection on the **TSoIP Inputs** subpage of the **Inputs** page, in the **TS Input Summary** table (Alias Template column), and also on the **Transform** page in the **TS Input Switch Table.**

### Connect Page

On this page, you can enter the username and password for basic authentication.

The **Login Status** displays if the HTTP call succeeded or if there was an authentication error during the request.

It is advisable to verify whether the TXP settings on the web interface of the device have been enabled. Note that when no credentials are filled in in the connector, auto login has to be enabled on the device.

### Descrambler Page

This page is available from version **1.1.2.3 onwards**. It displays a tree view with information related to the descrambler. Note that all tables used on this page can be accessed via the **Descrambler Info** page button.

In the tree control, the following data is displayed for each descrambler: the **Status**, **Source** **ID**, **BISS1** key and **Destination ID**, the **BISS1 Descrambling by Service** table and the **BISS1 Descrambling by PID** table.

### Trap Destinations

This page allows you to check where traps will be sent. There is a toggle button which, when enabled at element startup, will make the connector compare the info in the table and check if the IP of the hosting DMA is there. If it is not, this row will be added to the table with the status *Missing*.

The **Trap File Size** parameter allows you to control the size of the log file. With the **Log Traps** parameter, you can enable or disable the logging of the traps.

### Web Interface Page

This page provides access to the original web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

### Interfaces

#### Dynamic Interfaces

Virtual dynamic interfaces:

- **Input**: - **Ethernet Node**
- **Input: - Transport streams**
- **Output**: - **ASI/SDI Node**

### Connections

#### External Connections

- Between **Ethernet M.x Node** and **ASI/SDI Node (Output)**
