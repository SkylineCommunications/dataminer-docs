---
uid: Connector_help_Tandberg_nCompass
---

# Tandberg nCompass

Tandberg nCompass is an open systems network monitoring solution that supervises and monitors devices and systems throughout the network.

The top-level network monitoring function allows early visibility and identification of network and MPEG service issues.

The 4.0.1.x version is compatible with nCompass versions 5.x, 6.x and 8.x

The Tandberg nCompass uses SNMP and serial communication to get information about devices and alarms. It uses SOAP to display the profiles and streams. The schedule of these transport streams and system streams is displayed in a table. The connector allows the user to clear the schedule starting from a desired time, or to activate profiles. Events are retrieved from the device and an action is automatically executed if an event has occurred.

## About

### Version Info

| **Range**            | **Key Features**                            | **Based on** | **System Impact** |
|----------------------|---------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version                             | \-           | \-                |
| 1.1.0.x              | Assign severity to SNMP traps               | 1.0.0.2      | \-                |
| 2.0.0.x              | SNMP and serial connections                 | \-           | \-                |
| 2.1.0.x              | Creates DVEs                                | 1.1.0.2      | \-                |
| 3.1.0.x              | nCompass SNMP and SOAP API                  | 2.1.0.8      | \-                |
| 4.0.0.x              | Fixed problems with SOAP requests/responses | 3.1.0.6      | \-                |
| 4.0.1.x \[SLC Main\] | Driver review                               | 4.0.0.14     | \-                |
| **4.0.2.x**          | **Do not use this range!**                  | 4.0.1.20     | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.1.0.x   | \-                     |
| 2.0.0.x   | \-                     |
| 2.1.0.x   | \-                     |
| 3.1.0.x   | \-                     |
| 4.0.0.x   | \-                     |
| 4.0.1.x   | 5.x, 6.x and 8.x       |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**  |
|-----------|---------------------|-------------------------|-----------------------|--------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                       |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                       |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                       |
| 2.1.0.x   | No                  | Yes                     | \-                    | Tandberg nCompass Device |
| 3.1.0.x   | No                  | Yes                     | \-                    | Tandberg nCompass Device |
| 4.0.0.x   | No                  | Yes                     | \-                    | Tandberg nCompass Device |
| 4.0.1.x   | No                  | Yes                     | \-                    | Tandberg nCompass Device |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not needed.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

#### Serial Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **IP port**: The port of the connected device, by default *80*.
- **Bus address**: Not used.

### Initialization

From version **3.1.0.6** onwards, the **serial connection** is not polled from the IP set during element creation (protocol parameter ID 420001 overrules that setting). The IP address that will be used to send serial commands is displayed on the **Redundancy** page. It is the **Active Device IP** and the port is set to port 80 by default. The logic to get that result is based on the following:

- The values on **Active Device IP** and **Active Server** are based on the results of polling 2 SNMP parameters (**Server 1 State** and **Server 2 State**).
- **Server 1 State** is polled from the IP address defined for the SNMP connection during element creation.
- **Server 2 State** is polled from the IP defined in the **IP Second Device** field. In case that field is not filled in with a valid IP address, Server 1 will automatically be the **active server**.
- After both IPs are polled, logic is implemented to define which is the active server. To check this logic in detail, refer to QAction 10000 in the connector.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The element created with this connector consists of the data pages detailed below.

### Main View page

This page contains an overview of all the devices and an alarm table. For every row in the **Device** **Table**, a DVE is created. For each DVE, an element can be viewed with just one available page, **Main** **View**. On this page, general information is displayed on the left-hand side, and an **Alarm Table** is shown on the right-hand side.

Above the Device Table, two parameters are available. The first, **Enable** **Device** **Type**, will enable all the devices with the selected types, after which their DVE will be created. The second, **Disable** **Device** **Type**, will delete all DVEs with the selected device type.

You can also manually enable or disable the **DVE** **State** of each entry in the **Device Table**.

Finally, from **version 4.0.1.24** of the connector onwards, the **Take Over From** column in the Device Table allows you to perform a manual failover operation for a particular device.

### Stream Overview page

This page displays a tree structure containing all the basic streams.

### Schedule page

This page displays the schedule of the system and transport streams.

The **Profile** **Bypass** parameter can have the values *No* *Bypass* or *Bypass*. If one or more of the active profiles is in *Bypass,* then this parameter will be set to *Bypass*.

The profile name has to be constructed as follows: "\<HEADEND\>-\<PROFILECONTENT\>-\<PROFILE TYPE\>-{\<PROFILE DESCRIPTION\> -}YYYYMMDD" or "\<HEADEND\>-\<PROFILE TYPE\>-{\<PROFILE DESCRIPTION\> -}YYYYMMDD ". The different parts of this name will be displayed as "Profile" parameters in the **Profiles** **In** **Schedule** table (**Profile** **Headend**, **Profile** **Type**, **Profile** **Description**, and **Profile** **Comments**) if the profile is *active*.

- The \<HEADEND\> tag is one of the following: *METRO*, *STATE*, *VAST*, *AUSNET* or *FOXTEL*.

- The \<PROFILECONTENT\> tag is a brief identifier for the content associated with the device profile. In a BYPASS profile, this field should ONLY contain the content being bypassed. Content that runs in its normal mode should be described in the \<PROFILE DESCRIPTION\> field.

- The \<PROFILE TYPE\> can be:

- *LIVE*: Deemed to be a regular running profile. DataMiner will not flag the activation of a profile containing these keywords.
  - *BYPASS*: A profile used to bypass a system or location. DataMiner will flag the activation of a profile containing these keywords as a bypass profile.

- The \<PROFILE DESCRIPTION\> value can be:

- *OnAir*: A regular running profile.
  - In case of a bypass mode, a description of the system/location being bypassed (e.g. *RADIONT*, *MHA*, *MHADST*, *ULTIMO*).

There are also two page buttons available that allow you to activate certain profiles for a chosen period of time, and to clear the schedule from a certain point in time. In addition, there is also a refresh button available that will refresh the profile table.

### Stream page

This page displays six different tables that contain information about the streams.

### Redundancy page

This page displays information on the state of the used servers. You can also set the IP address of the second device here.

### Failover page (available from version 4.0.1.24 onwards)

This page allows you to define a list of devices for which a particular device will serve as a failover device.
