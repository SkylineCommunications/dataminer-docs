---
uid: Connector_help_VideoFlow_DVP1000
---

# VideoFlow DVP1000

The DVP1000 is a video stream-aware network device capable of protecting live video streams from the impact of network impairments. It ensures no packets are lost when content is delivered over the internet and nullifies the jitter caused by transiting the internet. Each DVP can be configured as "Protector", "Sentinel" or "Fortress".

This connector allows you to access various information on the device. There are different possibilities available for alarm monitoring and trending.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                                                                                                                                                              | **Based on** | **System Impact**                                                                                            |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|--------------------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version.                                                                                                                                                                                                                                                                              | \-           | \-                                                                                                           |
| 1.0.1.x              | \- Improved table display keys.- New streams and interfaces commands added.                                                                                                                                                                                                                   | \-           | Moving from the 1.0.0.x to the 1.0.1.x range will cause a **loss of trend data**, since indexes are updated. |
| 1.0.2.x \[SLC Main\] | \- Many different kinds of things can now be created in the device, such as new inputs and outputs for streams or new codec presets.- Syslog and traps polling and logging is now possible.- More data can be polled from the device, such as transport stream services, codecs, and demuxes. | \-           | \-                                                                                                           |

### Product Info

| **Range** | **Device Firmware Version**      |
|-----------|----------------------------------|
| 1.0.0.x   | 1.80.1.4(R) Oct 20 2016 04:17:40 |
| 1.0.1.x   | 1.80.1.4(R) Oct 20 2016 04:17:40 |
| 1.0.2.x   | 3.80.2.1(R) Jul 16 2020 11:10:10 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Device address**: The device address, by default *ByPassProxy*.

IP CONNECTION:

- **IP address/host**: The polling IP for this connection.

SNMP CONNECTION:

- **SNMP version**: The version of the SNMP protocol that will be used for polling.
- **IP address/host**: The IP device to use for the SNMP connection polling.

HTTP CONNECTION - SECONDARY:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Device address**: The device address, by default *ByPassProxy*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage - Range 1.0.0.x

### General

This page allows you to switch to the two main **Resources** (*Operational/Running*) and polls all information according to the specified resource. The page also displays general information about the device.

On the **Log In** subpage, you can enter the credentials to access the device.

### Ports

This page displays the state of all ports according to the specified resource, as well as **IP Addresses**, **Gateways,** **Speed,** **MAC Address**, and more. Via the right-click menu of the table, you can add or remove ports. To add a port, select **Add port** in the right-click menu and specify the necessary information in the pop-up page.

### Streams

This page displays the **Input** and **Output IP** and **Port** numbers. It also contains information on the packets that are running in the system.

The right-click menu of the table allows you to add a stream or delete a selected stream.

### UDP VPN

On this page, you can find the **UDP VPN Server table** and the **UDP VPN Client table**, where you can see the different interfaces. In the **UDP VPN Client Table**, you can add a new VPN or remove it. With the **Connect Now** option, you can connect the VPN.

## Usage - Range 1.0.1.x

### General

This page displays general information on the device, such as the **Unit Name**, **System Type** and **Version**.

To make sure the connector can poll data from the device, you need to first fill in the **Username** and **Password** and then click the **Log in** button. This step is **mandatory** in order to poll data from the device.

You can also execute some **System Actions** (e.g. **Reset**, **Shutdown**, **Database Load**) on this page, by first selecting the action with the **System Actions** parameter and then clicking the **Execute Action** button.

### Firewall

This page displays the **Firewall Status** (*enabled* or *disabled*), as well as the **Allowed List Interfaces**, **Rules** and **User Defined Rules** tables.

To create a new allowed list interface, right-click the **Allowed List Interface** table, select **Add Allowed Interface**and specify an **Interface Name**.

To create a new user-defined rule, right-click the **User Defined Rules** table, select **Add Rules** and specify an **Interface Name**, **Rule Name**, **Rule Status**, **Source IP** and **Destination IP**.

### Interfaces

This page contains the following interface tables: **Port**, **UDP VPN Server**, **UPD VPN Client**, **Virtual**, **VLAN**, **Tunnel** and **Static Route**. In each table, you can **Delete** or **Create** a new interface via the right-click menu.

For each **UDP VPN Client**, the **Connect** action can be executed in order to trigger the connection of this VPN.

### Streams

This page displays the current **Streams** created in the device with their respective **Statistics** and **ETR290 Events**. It is possible to **create** and **delete** streams.

To add a stream, right-click the Streams table, select **Add Stream** and specify a **Stream Name**, **Operational Mode** (*Protector*, *Sentinel* or *Fortress*) and **Status** (*enabled/disabled*).

### Inputs

This page contains the **Primary Inputs** and **Additional Inputs** table for each stream. It is possible to enable/disable the existing **Additional Inputs**.

It is also possible to create a new **Additional Input**. To do so, right-click the table, select the **Add Input** option and specify a**Name**, **Stream**, **Interface**, **Listen IP** and **Listen** **Port**.

### Outputs

This page contains the **Primary Outputs** and **Additional Outputs** table for each stream. It is possible to enable/disable the existing **Additional Outputs**.

It is also possible to create a new **Additional Output**. To do so, right-click the table, select the **Add Output**option and specify a **Name**, **Stream** and **Interface.**

### Web interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage - Range 1.0.2.x

### General

This page displays general information on the device, such as the **Unit Name**, **System Type**,**Version Information**,the unit's **Date and Time**, information regarding **DNS** and **NTP**, and **ports used for HTTP and HTTPS**.

To make sure the connector can poll data from the device, you need to first fill in the **Username** and **Password** and then click the **Log in** button. This step is **mandatory** in order to poll data from the device. After entering or changing the required credentials, please restart the DataMiner element.

You can also execute some **System Actions** (e.g. **Reset**, **Shutdown**, **Database Load**), by first selecting the action on the **System Actions** subpage and then clicking the relevant button.

### Firewall

This page displays the **Firewall Status** (*enabled* or *disabled*), as well as the **Allowed List Interfaces**, **Rules** and **User Defined Rules** tables. You can enable or disable **Interfaces** by clicking the toggle button, and you can also modify **User Defined Rule** parameters.

To create a new allowed list interface, right-click the **Allowed List Interface** table, select **Add Allowed Interface**and specify an **Interface Name**.

To create a new user-defined rule, click the **Add** **User Defined Rule** button and specify the values for this new rule in the creation window.

### Interfaces

This page contains the following interface tables: **Port**, **UDP VPN Server**, **UPD VPN Client**, **Virtual**, **VLAN**, **Tunnel** and **Static Route**. In each table, you can **Delete** or **Create** a new interface via the right-click menu.

For each **UDP VPN Client**, the **Connect** action can be executed in order to trigger the connection of this VPN.

### Streams

This page displays the current streams created in the device with their respective **Statistics** and **ETR290 Events**. It is possible to **create** and **delete** streams.

To add a stream, right-click the Streams table, select **Add Stream** and specify a **Stream Name**, **Operational Mode** (*Protector*, *Sentinel* or *Fortress*) and **Status** (*enabled/disabled*).

This page features several tables and subpages with subordinate information about streams, such as their **Alarms**, **Statistics**, **Peer Statistics**, and **Transport Stream Services**.

### Inputs

This page contains the **Primary Inputs** and **Additional Inputs** table for each stream. It is possible to enable/disable the existing **Additional Inputs**. You can also create new **Additional Inputs** or **Codec Inputs**.

### Outputs

This page contains the **Primary Outputs** and **Additional Outputs** table for each stream. It is possible to enable/disable the existing **Additional Outputs**. You can also create new **Additional Outputs** or **Codec Outputs**.

### User

This page contains information regarding the different **Users** that are configured for the DVP device.

### License

This page shows information regarding the **Floating License** and the various **Permissions** of the device.

### Syslog

This page contains information regarding the **Event Logger** and **Remote Syslog** of the device, and also allows you to configure these. A list of polled **Syslog Messages** is also displayed.

### Codec

This page contains information regarding the configured **Codec Presets**. You can also create a new **Codec Preset** according to your preference.

### Redundancy

This page allows you to monitor the **Redundancy Nodes** and **Redundancy Status** of the device.

### Alarms

This page can be used to monitor **Active Alarms** and to view the **Alarm History** of the device. On the subpages, you can view information about **SNMP Traps** and change the **Alarm Configuration**.

### Mail

This page displays all information related to the **Mail** settings of the device, such as **Recipients**, **Groups**, and **Mail** **Alarms**. On the subpages, you can create new **Groups** or add new **Recipients**.

### Demux

This page contains information about the **Demuxes** of the device and their **Outputs**. On the subpages, you can create a new **Demux**, **Demux** **Output**, or **Demux** **Output** **PID**.

### Tree Control

This displays a tree view of the stream data. Data from several stream-related tables is compiled so that you can easily view all information related to a particular stream.

### Web interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
