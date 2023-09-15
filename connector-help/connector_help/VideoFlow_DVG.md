---
uid: Connector_help_VideoFlow_DVG
---

# VideoFlow DVG

The DVG is a video stream-aware network device capable of protecting live video streams from the impact of network impairments. It ensures no packets are lost when delivering content over the internet, and nullifies the jitter caused by transiting the internet. Each DVG can be configured as "Protector", "Sentinel" or "Fortress".

This connector allows you to monitor this device via an HTTP connection.

## About

### Version Info

| **Range** | **Key Features**                                                                                                                              | **Based on** | **System Impact**                                                                                              |
|-----------|-----------------------------------------------------------------------------------------------------------------------------------------------|--------------|----------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | Initial version that has feature-parity with the DVP1000 connector. Supports different stream inputs and outputs, such as SRT, Zixi, and SDI. | \-           |                                                                                                                |
| 1.0.1.x   | Updated indexes.                                                                                                                              | 1.0.0.x      | Moving **from the 1.0.0.x to the 1.0.1.x range** will cause **loss of trend data**, since indexes are updated. |

### Product Info

| **Range** | **Supported Firmware**           |
|-----------|----------------------------------|
| 1.0.0.x   | 1.40.1.1(R) Oct 17 2021 12:27:59 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection - Main

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Device address**: The device address, by default *ByPassProxy*.

IP CONNECTION:

- **IP address/host**: The polling IP for this connection.

#### SNMP Connection

This connector uses an SNMP connection and requires the following input during element creation:

SNMP CONNECTION:

- **SNMP Version**: The version of the SNMP protocol that will be used for polling.
- **IP address/host**: The IP device to use for the SNMP connection polling.

HTTP Connection - Secondary

This connector uses a secondary HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Device address**: The device address, by default *ByPassProxy*.

### Initialization

To make sure the connector can poll data from the device:

1. On the **General** page of the element, fill in the **Username** and **Password.**
2. Click the **Log in** button.
3. Restart the DataMiner element.

Data will only be polled from the device when these steps have been done. If you change the credentials, also restart the DataMiner element.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use - Range 1.0.0.x

The element created with this connector consists of the data pages detailed below.

### General

This page displays general information about the device, such as the unit name, system type, version information, the unit's date and time, information regarding DNS and NTP, and ports used for HTTP and HTTPS.

This page is also where you can specify the credentials to poll data from the device (see "Initialization"). In addition, it allows you to execute system actions: **reset**, **shut down** or **database load**. To do so, first select the action on the **System Actions** subpage and then click the button corresponding with that action.

### Firewall

This page displays the **Firewall Status** (*enabled* or *disabled*), as well as the **Allowed List Interfaces**, **Rules** and **User Defined Rules** tables. You can enable or disable **interfaces** by clicking a toggle button. **User-defined rule** parameters can be modified as well.

To create a new allowed list interface, right-click the **Allowed List Interface** table, select **Add Allowed Interface** and specify an interface name.

To create a new user-defined rule, click the **Add** **User Defined Rule** button and specify the values for this new rule in the creation window.

### Interfaces

This page contains several interface tables. In each table, you can **delete** or **create** an interface via the right-click menu.

For each **UDP VPN Client**, the **Connect** action can be executed in order to trigger the connection of this VPN.

### Streams

This page displays the current streams created in the device with their respective **statistics** and **ETR290 events**. It is possible to **create** and **delete** streams.

To add a stream, right-click the Streams table, select **Add Stream**, and specify a **Stream Name**, **Operational Mode** (*Protector*, *Sentinel* or *Fortress*) and **Status** (*enabled/disabled*).

This page features several tables and subpages with additional information about streams, such as their **Alarms**, **Statistics**, **Peer Statistics**, and **Transport Stream Services**.

### Inputs

This page contains the **Primary Inputs** and **Additional Inputs** table for each stream. Existing **additional inputs** can be enabled or disabled, and it is possible to create **additional inputs** or **codec inputs**.

This page also contains tables to view and edit information from the stream's **SRT inputs**, **Zixi receivers**, and **MPEs**. You can add a new entry to any of these inputs.

### Outputs

This page contains the **Primary Outputs** and **Additional Outputs** table for each stream. Existing **additional outputs** can be enabled or disabled, and it is possible to create **additional outputs** or **codec outputs**.

This page also contains tables to view and edit information from the stream's **SRT outputs**, **Zixi feeders**, **SDI outputs**, and **ASI outputs**. You can add a new entry to any of these inputs.

### User

This page contains information regarding the different users that are configured for the DVG device.

### License

This page can be used to view information regarding the DVG device's **floating license** and the various **permissions** of the device.

### Syslog

This page contains all information regarding the DVG device's **Event Logger** and **Remote Syslog**, and allows you to configure them as you wish. You can also view the list of polled **Syslog Messages**.

### Codec

This page contains information regarding the configured **codec presets**. You can also create a new **codec preset** with your chosen specifications.

### Redundancy

This page can be used to monitor the DVG device's **redundancy nodes** and **redundancy status**.

### Alarms

This page can be used to monitor **active alarms** as well as to view the **alarm history** of the device. It features subpages where you can view information about **SNMP traps** or change the **alarm configuration**.

### Mail

This page displays all information related to the device's mail settings, such as **recipients**, **groups**, and **mail** **alarms**. It features subpages where you can create **new** **groups** or add **new** **recipients**.

### Demux

This page contains information about the device's demuxes and their **outputs**. Via the subpages, you can create a new **demux**, **demux** **output**, or **demux** **output** **PID**.

### Tree Control

This page contains a tree-structure representation of the stream data. Data from several stream-related tables is compiled, so that you can view all information related to a particular stream.
