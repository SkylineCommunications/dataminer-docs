---
uid: Connector_help_Imagine_Communications_Selenio_Network_Processor
---

# Imagine Communications Selenio Network Processor

The Imagine Communications Selenio Network Processor is a pure-IP processor. It has four independent processing blocks for various operations (synchronization, conversion, processing). This connector can be used to monitor, trend, and control the SNP (Selenio Network Processor).

The connector uses an **HTTPS connection** and communicates with the SNP Manager via an API. There is also a smart-serial interface that receives updates directly from the network processor. From version 1.0.7.1 onwards, there is an **SMM Web Socket connection** that receives status data by subscribing to it using the web socket and that also receives configuration data automatically (without subscribing) using the web socket open connection. For information on how to configure this connection, refer to the SMM Web Socket Connection section below.

## About

### Version Info

| **Range**                | **Key Features**                                                                                                                                                                                                                                                                                | **Based on** | **System Impact**                                                                                                          |
|--------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|----------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x \[OBSOLETE\]     | Initial version.                                                                                                                                                                                                                                                                                | \-           | \-                                                                                                                         |
| 1.0.1.x \[OBSOLETE\]     | Changed description and some columns, changed description of the SDI Outputs table, and changed discrete value on Control Link Bonding parameter r/w.                                                                                                                                           | 1.0.0.15     | Possible impact on alarms, trending, and Visio files related to PIDs 506, 1905 and 2105.                                   |
| 1.0.2.x \[OBSOLETE\]     | Moved Proxy rows/items from table IP Video TX to a new table named Proxy IP Video TX. New polling architecture implemented.                                                                                                                                                                     | 1.0.1.2      | Possible impact on alarms, trending, and Visio files related to PIDs 506, 1905 and 2105.                                   |
| 1.0.3.x                  | Removed non-initialized parameters. Separated Selecting Stream and Channel parameters of table IP Audio RX into table of their own.                                                                                                                                                             | 1.0.2.8      | Possible impact on alarms, trending, and Visio files.                                                                      |
| 1.0.4.x \[OBSOLETE\]     | Packet Time (PID 2024) update on a discrete value.                                                                                                                                                                                                                                              | 1.0.3.4      | Possible impact on alarms, trending, and Visio files related to the Packet Time parameter.                                 |
| 1.0.5.x \[DISCONTINUED\] | SMM Web Socket connection.Note: This branch causes a memory leak in SLScripting.                                                                                                                                                                                                                | 1.0.4.2      | Possible impact on alarms, trending, and Visio files related to the Packet Time parameter and the element's configuration. |
| 1.0.6.x                  | Ranges and units of the Color Corrector table updated to the latest API.                                                                                                                                                                                                                        | 1.0.4.2      | Possible impact on alarms, trending and Visio files related to the Packet Time parameter and the element's configuration.  |
| 1.0.7.x                  | Web socket implementation without serial connection.                                                                                                                                                                                                                                            | 1.0.6.3      | Possible impact on alarms, trending, and Visual Overview.                                                                  |
| 1.0.8.x                  | SDI Interfaces table for Video Input and Video Output. API V2 Implementation (ACO feature).                                                                                                                                                                                                     | 1.0.7.2      | Possible impact on alarms, trending, and Visual Overview.                                                                  |
| 1.1.2.x                  | Updated current parameter names and discrete values to match the latest firmware. Old firmware is no longer supported.                                                                                                                                                                          | 1.1.0.2      | Possible impact on alarms, trending, and Visual Overview.                                                                  |
| 1.1.3.x \[SLC MAIN\]     | Updated Active Alarms table instance to show all unique alarms.                                                                                                                                                                                                                                 | \-           | \-                                                                                                                         |
| 1.1.4.x                  | Adjusted connections to be compliant with DataMiner 10.2.7. Adjusted input channel select in Output Audio Channel to display proper processor.Fixed typo in InputChannelSelect AAP dictionary that affected missing dropdown list items.Added display key to tables 4700 and 5500.              | 1.1.3.1      | Possible impact on alarms, trending.                                                                                       |
| 1.1.5.x                  | The Processing Audio and Output Audio Channel pages now only show the discrete values that apply to the relevant row.                                                                                                                                                                           | 1.1.4.2      | Possible impact on alarms, trending.                                                                                       |
| 1.1.6.x                  | Variable parameters updated to reflect the latest API                                                                                                                                                                                                                                           | 1.1.5.3      | Possible impact on alarms, trending, and Visual Overview.                                                                  |
| 1.1.7.x                  | The "Frame Sync" table has been turned into the "Processing Personalities" table, with reorganized columns and more configurable values, and it is now in the "Processing Video" section. Tables representing four personalities have been added on subpages of the "Processing Video" section. | 1.1.6.4      | Possible impact on alarms, trending, and Visual Overview                                                                   |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.1 - 1.5              |
| 1.0.1.x   | 1.1 - 1.5              |
| 1.0.2.x   | 1.5 & 1.6              |
| 1.0.3.x   | 1.5 & 1.6              |
| 1.0.4.x   | 1.5, 1.6, 1.7          |
| 1.0.5.x   | 1.5, 1.6, 1.7          |
| 1.0.6.x   | 1.5, 1.6, 1.7          |
| 1.0.7.x   | 1.6 and 1.7            |
| 1.0.8.x   | 1.6, 1.7, and 2.0      |
| 1.1.2.x   | 2.0-2.1.2.19           |
| 1.1.3.x   | 2.0-2.1.2.19           |
| 1.1.4.x   | 2.0-2.1.2.19           |
| 1.1.5.x   | 2.0-2.1.2.19           |
| 1.1.6.x   | 2.1.2.20               |
| 1.1.7.x   | 2.1.2.20               |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.2.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.3.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.4.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.5.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.6.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.7.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.8.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.1.2.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.1.3.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.1.4.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.1.5.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.1.6.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.1.7.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination. Make sure to add "https://" before the IP/host. For example, for IP "172.10.2.42", specify "https://172.10.2.42".
- **IP port**: The IP port of the destination (default: *9089*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

#### Serial IP Connection - SNP Connection \[REMOVED in 1.0.7.X\]

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (fixed value: *4517*).

#### SMM Web Socket Connection

From version 1.0.7.1 onwards, this connector uses a web socket connection and requires the following input during element creation:

WEB SOCKET CONNECTION:

- Web Socket Interface:

- **IP address/host**: wss://\[IP_ADDRESS\].
  - **IP port**: The IP port of the destination (fixed value: *443*).

### Initialization

Once the element is running, configure the **User Name** and **Password** on the **Security** page to establish the HTTP connection.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector consists of the data pages detailed below.

### Overview

This is the default page of the connector. It displays a tree control that allows you to navigate through the multiple layers of the device. The tree control starts with the processors, allowing you to configure and monitor the **Input Mode** (*SDI* or *IP*) and **Operation Mode** (*HD* or *UHD*) per section.

Programs will be displayed accordingly on the level below. For each program, four child items are available, **Input**, **Video**, **Audio**, and **Output**. Below these, you will find more items based on the configuration of the program.

This content matches the way the web interface can be navigated.

### General

This page contains general information on the SNP, such as the **control IP addresses**, **hardware info**, **firmware versions**, and, most importantly, the **SNP State**. This SNP State indicates the link with the SNP Manager. If this parameter indicates *Not Connected*, this means you are no longer viewing the most up-to-date information and also that configuring settings will fail because the SNP can no longer be reached by the SNP Manager.

This page contains a subpage with an exception counter designed to show how many exceptions or errors have occurred in the connector.

### System

This page displays information related to the device and system, such as **FPGA hardware states**, **power supply states**, **front fan states**, and **QSFP states**.

### PTP

This page contains PTP leader and follower info.

### IP WAN

Aside from an overview of the **IP WAN** primary and backup entries with their **IP addresses**, **subnet masks**, **gateway**, and **VLAN IDs**, this page also displays general information on the number of **packets** and the **rates** for **TX** and **RX** (primary and secondary).

### Gen Lock

This page contains Gen Lock information. The **Sync Out Mode** can be configured with *Loop* and *Generator* options, and the **GL Out Frame Rate** can be set to *25/50Hz* or *29/59Hz*.

### IP RX Setup

This page contains IP RX setup information, including settings such as **Playout Delay**, **IGMP Leave Delay**, **IGMP Join Delay**, and **Receiver Global Debug Mode**.

### Processor

This page contains an overview of the four processor blocks in the **Processor** table. You can set a processor's **Personality** to *Sync Mode*, *Conversion Mode*, *Remap Mode*, or *Multiviewer*. The table contains the settings for the **Operation Modes** and **Input Modes** for the sections per processor.

The **V-Bit Mute**, **V-Fade State**, **Fade Time**, and **V-Fade Mute** settings are also available on this level, as these apply to the whole processor.

In Multiviewer mode, the connector can read and set information related to this mode, such as **Multi-Viewer Mode**, **Display Layout**, **9th Receiver**, etc.

### SDI (In/Out)

This page provides an overview of all BNC input and outputs and all SFP connections.

Note that it is advised that you do **not modify** the **BNC Direction** directly in this table. A warning will pop up when you do so. Instead, use the tree control to for example set the processor input mode (SDI/IP). This will then also update the BNC directions for the corresponding BNCs.

### IP Video

This page contains the IP Video RX and TX tables. However, it is better to use the **tree control** for navigation, since not all entries are actively used (based on the mode (IP/SDI) and configured destinations, different entries will be used).

Each program has one dedicated row, with a display key in the following format: *SDNO Stream - Slot 1: Port 1: Video 1*

The **Video TX IP DSCP** and **Video IP TTL** can be configured here.

### IP Audio

This page contains the IP Audio RX and TX tables. However, it is better to use the **tree control** for navigation, since not all entries are actively used (based on the mode (IP/SDI) and configured destinations, different entries will be used).

In the **Audio Routing RX** table, you can select the **Audio Stream** and **Audio Channel**. Each program has 16 dedicated audio channel rows, with display keys in the following format: *1: SDNO Stream - Slot 1: Port 1: Audio 1*

The **Audio TX IP DSCP**, **Audio IP TTL** and **Audio IP Packet Time** can be configured here.

### IP Ancillary

This page contains the IP Ancillary RX and TX tables. However, it is better to use the **tree control** for navigation, since not all entries are actively used (based on the mode (IP/SDI) and configured destinations, different entries will be used).

Each program has four dedicated ancillary data rows, with display keys in the following format: *1: SDNO Stream - Slot 1: Port 1: Data 1*

The **Ancillary TX IP DSCP** and **Ancillary IP TTL** can be configured here.

### Input Audio

This page contains multiple tables that can be used to control the input audio: **Audio Processing Channel**, **Input Pair Source**, **Input PCM Status**, **Audio Processing**, and **DMB V-Bit**.

However, it is better to use the **tree control** for navigation, since it navigates from a program perspective in the processor, which makes it easier to view the linked information.

### Processing Video

This page displays the **Frame Sync**, **Video TSG** (Test Signal Generator) and **Color Corrector**.

However, it is better to use the **tree control** for navigation, since it navigates from a program perspective in the processor, which makes it easier to view the linked information.

The **Frame Sync** table contains **Video Input Present** and **UHD Video Input Present** columns. These display the state of the input signal based on the **Operation Mode** (*HD*/*UHD*).

As it might be useful to only activate alarm monitoring on these parameters in case of permanent stable signals, it is possible to configure this in DataMiner. On the **Video Input Present Conditional Monitoring** subpage, you can configure the persistency parameters for Video Input Present and Not Present. By default, these values are respectively 30 seconds and 10 minutes. This means that the calculated **Conditional Monitoring State** column will only update the value to *Monitored* when the video input is present without interruption for 30 seconds (this value can be customized). The state will change to *Not Monitored* again when the signal is continuously lost for 10 minutes (this value can also be customized). In the alarm template, you can use conditional monitoring in this table and take this **Conditional Monitoring State** column into account.

### Processing Audio

On this page, the **Pair Word Length** can be set in the **Output Audio Pair** table for each audio pair in a program. The **Output Audio Channel** table contains configuration parameters for the audio output.

However, it is better to use the **tree control** for navigation, since it navigates from a program perspective in the processor, which makes it easier to view the linked information.

### Presets

Here you can find the **Presets** table, with all the presets in the device.

### Users and Groups

This page contains the following tables:

- **Users**: Displays the **User Name**, **Activated** state, **Last Login** time, and **Group ID** for each user.
- **Groups**: Displays the **Name** and **Permissions** of each group.

### License

This page displays the **License Key**, **Version**, and **Serial Number**.

### Logo

On this page, you can find company information, as well as the **Product** and **Logo Version**.

### Alarm Logs

On this page, you can **Collect Logs** with a click of a button. All **Alarm Logs** will be displayed on the page.

### Security

On this page, the **Connection State** parameter will indicate if the connection with the SNP Manager is successful. Via the parameters **User Name** and **Password**,you can submit the credentials to connect the element.

The **HTTP Credential Manager** connector can manage all credentials automatically. By enabling the **Credential Manager Subscription**, you can manage usernames and passwords in more than one SNP connector.

## DataMiner Connectivity Framework

The **1.0.1.x** connector range of the Imagine Communications Selenio Network Processor connector supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through third-party DataMiner connectors (for instance a manager).

The **1.0.8.x** connector range of the Imagine Communications Selenio Network Processor connector will make DCF **internal connections** from BNC to IP and vice versa.
