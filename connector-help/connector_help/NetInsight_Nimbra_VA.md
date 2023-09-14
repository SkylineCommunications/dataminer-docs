---
uid: Connector_help_NetInsight_Nimbra_VA
---

# NetInsight Nimbra VA

The **NetInsight Nimbra VA** is used to encode, decode and transport live video using the internet.

## About

The connector uses an SNMP connection to monitor **NetInsight Nimbra VA** devices. In the connector it is possible to observe tables that contain information about encoding, decoding, transportation, statistics and alarms.

### Version Info

| **Range** | **Description**                                                                             | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                                             | No                  | Yes                     |
| 1.1.0.x          | Initial version                                                                             | No                  | Yes                     |
| 1.2.0.x          | New firmware version (NOTE: version 1.2.0.3 is considered obsolete, and should not be used) | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | \-                          |
| 1.1.0.x          | FX-VA200.10                 |
| 1.2.0.x          | VA-12.1.0.0                 |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

## Version 1.0.0.x

### General Page

This page displays general information, such as:

- **System Name**
- **System Uptime**
- **System Description**

### Input Page

This page displays a table with the input information, such as:

- **Push information**
- **Pull Information**
- **Jitter**
- **Latency**
- **Uptime**

### Output Page

This page displays a table with the Output information, such as:

- **Push informartion**
- **Jitter**
- **Latency**
- **Bitrate**

## Usage

## Version 1.1.0.x

### General Page

This page displays general information about the device, such as:

- **System Name**

- **System Description**

- **System Location**

- **System Uptime**

### Interfaces Page

This page displays the **Interface Table** that contains information such as:

- **Display key**: contains the **Index**, **Name**, **Port** **Mode** and **Filter** fields of this table separated by points

- **Filter**: allows users to adjust the trending and alarm level

- **Topology fields**: Topology configuration
  - Interface
  - Decoder
  - UDP Sink
  - Pull Sink
  - Push Sink

- **Alarm fields**: Alarms from the Active Alarm Table

- Configuration Error

  - Timing Problem

### Encoder/decoder Page

This page displays the **Encoder Table** and the **Decoder Table**. Both tables contain information such as:

- **Display key**: contains the **Index**, **Name** and **Filter** fields of the tables separated by points

- **Filter**: allows users to adjust the trending and alarm level

- **Alarm fields**: Alarms from the Active Alarm Table

- Configuration Error

  - Subsystem Failure

  - Protocol Error

### UDP Transport Page

This page displays the **UDP Source Table** and **UDP Sink Table.**

The **UDP Source** Table contains information such as:

- **Display key**: contains the **Index**, **Name** and **Filter** fields of this table separated by points

- **Filter**: allows users to adjust the trending and alarm level

- **Topology fields**: Topology configuration
  - Interface
  - Encoder
  - UDP Sink
  - Pull Sink
  - Push Sink

- **Alarm fields**: Alarms from the Active Alarm Table

- Configuration Error

  - Call Establishment Error (Connection Not Established)

The **UDP Sink Table** contains information such as:

- **Display key**: contains the **Index**, **Name** and **Filter** fields of this table separated by points

- **Filter**: allows users to adjust the trending and alarm level

- **Alarm fields**: Alarms from the Alarm Table

- Configuration Error

  - Call Establishment Error (Connection Not Established)

  - Call Establishment Error (No Connection Initiated By Remote Host)

### Pull Transport Page

This page displays the **Pull Source Table**, **MPU Source Table** and the **Pull Sink Table**.

The **Pull Source Table** and the **MPU Source Table** contain information such as:

- **Display key**: contains the **Index**, **Name** and **Filter** fields of the tables separated by points

- **Filter**: allows users to adjust the trending and alarm level

- **Topology fields**: Topology configuration
  - Interface
  - Encoder
  - UDP Sink
  - Pull Sink
  - Push Sink

- **Alarm fields**: Alarms from the Active Alarm Table

- Configuration Error

  - Call Establishment Error (Connection Not Established)

  - Call Establishment Error (No Connection Initiated By Remote Host)

The **Pull Sink Table** contains information such as:

- **Display key**: contains the **Index**, **Name** and **Filter** fields of this table separated by points

- **Filter**: allows users to adjust the trending and alarm level

- **Topology fields**: Topology configuration
  - Interface
  - Encoder
  - UDP Sink
  - Pull Sink
  - Push Sink

- **Alarm fields**: Alarms from the Active Alarm Table

- Configuration Error

  - Call Establishment Error (Connection Not Established)

  - Call Establishment Error (Secondary Remote Host)

### Push Transport Page

This page displays the **Push Source Table**, **Ls Table** and the **Push Sink Table**.

The **Push Source Table** contains information such as:

- **Display key**: contains the **Index**, **Name** and **Filter** fields of this table separated by points

- **Filter**: allows users to adjust the trending and alarm level

- **Topology fields**: Topology configuration
  - Interface
  - Encoder
  - UDP Sink
  - Pull Sink
  - Push Sink

- **Alarm fields**: Alarms from the Active Alarm Table

- Configuration Error

  - Call Establishment Error (Connection Not Established)

  - Call Establishment Error (Secondary Remote Host)

The **Ls Table** contains information such as:

- **Display key**: contains the **Index** and **Filter** fields of this table separated by points

- **Filter**: allows users to adjust the trending and alarm level

- **Alarm fields**: Alarms from the Active Alarm Table

- Configuration Error

The **Push Sink Table** contains information such as:

- **Display key**: contains the **Index**, **Name** and **Filter** fields of this table separated by points

- **Filter**: allows users to adjust the trending and alarm level

- **Alarm fields**: Alarms from the Active Alarm Table

- Configuration Error

  - Call Establishment Error (Connection Not Established)

  - Call Establishment Error (No Connection Initiated By Remote Host)

### Statistics Page

This page displays the **UDP Statistics** **Table**, **Transport Statistics** **Table** and the **Test Summary Table**. The tables have in common the following information:

- **Display key**: contains the **Index**, **Reference Table Name**, **Reference Table Row**, **Reference Stream Name** and **Filter** fields of this table separated by points

### Alarms Page

This page displays the **Active Alarm Table** contain information such as:

- **Display key**: contains the Index of the table
- **Object**: object in wich the alarm is active
- **Alarm Type**
- **Cause**
- **Severety**
- **Text**
- **Last Changed Time**
- **Acknowledged**
- **Created Time**

### Web Page

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.



## Usage

## Version 1.2.0.x

### General Page

This page displays general information about the device, such as:

- **System Name**

- **System Description**

- **System Uptime**

### Input Page

This page displays tables containing information of various input types, such as:

- **Push Sink Information**
- **UDP Sink Information**
- **Pull Sink Information**
- **Source Route Transport Sink Information**
- **Reliable Internet Stream Transport Sink Information**

By right clicking the configuration tables, the user is able to create their own inputs through DataMiner.

### Output Page

This page displays tables containing information of various output types, such as:

- **Push Source Information**
- **UDP Source Information**
- **Pull Source Information**
- **Source Route Transport Source Information**
- **Reliable Internet Stream Transport Source Information**

By right clicking the configuration tables, the user is able to create their own outputs through DataMiner.

### Tunnel Page

This page displays the Reliable Internet Stream Transport Tunnel table, where users can monitor and configure tunnel settings in the device.

### Notifications Page

This page displays the events and alarms captured by the device. The user may configure whether DataMiner polls for this information or not.

### Interfaces Page

This page displays the following information:

- **Value Added Service Interface Information**
- **Interface Information**
- **Ip Routing**

### Encoder Page

This page displays the following information:

- **Encoder Pipe Information**
- **Encoder Audio Stream Information**

The user is able to create their own encoder pipeline objects and their audio streams through the table context menus.

### Decoder Page

This page displays the following information:

- **Decoder Pipe Information**
- **Decoder Audio Configuration**
- **Decoder Audio Stream**

The user is able to create their own decoder pipeline objects and their decoder audio configurations through the table context menus.

### Statistics Page

This page and its subpages display the following kinds of statistics:

- **UDP Statistics**
- **Transport Statistics**
- **Transport Stream Test Statistics**
- **Source Route Transport Statistics**
- **Reliable Internet Stream Transport Statistics**

### Switching Page

This page displays the following information:

- Switch Table
- Switch Source Table

### Web Page

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

### Note

When the user want to do a set in the Input From, it could change the Input **Number** or the Select Input, anyone who chooses the other one can't be on "N/A", in case it changes the **Select Input** and the **Input Number** is on "N/A" it would display a message saying "Input Number can't be N/A, please change it" and if it changes the **Input Number** and the **Select Input** is on "N/A" it would display a message saying "Select Input can't be N/A, please change it". In this way until both parts have a valid value it wont be complete the set on the **Input From**.


