---
uid: Connector_help_T-Vips_TVG425
---

# T-Vips TVG425

The T-Vips TVG425 connector is an **SNMP**-based connector used to monitor and configure the **T-Vips TVG425**.

## About

The TVG425 provides gateway functionality to encapsulate MPEG-2 transport streams for IP networks, and to extract MPEG-2 streams from IP encapsulation. The device includes Gigabit ports as well as ASI ports, all functioning as input or output connections. Other features include redirecting such streams from an input to multiple outputs, or combined from multiple inputs as individual transport streams on one or more of the ASI ports or IP interfaces.

### Version Info

| **Range** | **Description**                       | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                       | No                  | No                      |
| 1.0.1.x          | No                                    | No                  |                         |
| 2.0.0.x          | Yes                                   | No                  |                         |
| 2.0.1.x          | Major version to support Norway Chars | Yes                 | Yes                     |
| 2.0.2.x          | Layout changes                        | Yes                 | Yes                     |

### Product Info

| **Range**        | **Device Firmware Version** |
|-------------------------|-----------------------------|
| 1.0.0.x                 | 1.4.x to 2.6.x              |
| 1.0.1.x                 |                             |
| 2.0.0.x 2.0.1.x 2.0.2.x | 3.4.x                       |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General

This page displays the device identification, the **Up Time** and the **Temperature** in the column on the left. On the right, the main alarm statuses are displayed, along with a table listing all the **Current Alarms**.

### Transport Stream

This page contains the transceiver parameters. This includes alarm statuses and bitrate values. In the final column, a descriptive label can be entered.

At the bottom of the page, three page buttons provide access to the following pages:

- **Services**: Displays the **Services** and **Service components** tables.
- **PIDs**: Displays the **PIDs** table.
- **Alarms**: Displays the Alarms table, which lists all the possible alarm IDs with their **State**, **Current Status**, **Configured Severity**, **On Count**, and **Error Count**.

### Switch Inputs

This page contains the list of **Switch Inputs**. It is possible to add or delete entries in the list.

### IP Inputs

This page is similar to the **Switch Inputs** page, but handles IP input streams.

### IP Rx

This page contains the **IP Rx Configuration** table, which is used to configure the IP Rx settings to receive streams as configured in the **IP Inputs**, and another table for their statuses (**IP RX Status**). The last table displays the **FEC** measurements.

A page button allows access to the **IP Rx Ping Table** page, where pings can be performed and their results can be checked.

### IP Tx

This page is similar to the **IP Rx** page, but handles the transmitting streams.

### Outputs

On this page, you can manage the **Streams** and **ASI Ports** for outgoing streams.

### Trap Destinations

This page shows a **Traps table**. It also has a page button that opens a page where you can **create and configure SNMP traps**.

### Events

This page contains the **Trap Events Table**, which is filled in whenever a **trap of type Event** is received. The page contains a button in order to **Clear Events** and a parameter that sets the **Traps Max Number** to show in the table.

At the bottom of this page, the **History Table** page button provides access to a table with detailed information about the last 20 event traps. (Only available in range 2.0.0.x.)

### Interfaces (Range 1.0.1.x)

This page contains the **Interface Table**, which contains information about every interface of the device. This includes the **Bandwidth**, **Type of Interface**, **Number of Packets** sent and received, **Bitrates**, etc.

### Web Interface

This page can be used to access the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage (2.0.2.x)

### General

This page displays the device identification, the **Up Time** and the **Temperature** in the column on the left. On the right, the main alarm statuses are displayed.

### Ethernet

The **Interfaces** and **Unit VLAN** **Table** are displayed on this page. It is also possible to configure the display key of the VLAN table.

> **Note**: using the right-click context menu on the **Unit VLAN Table**, you can add and delete VLANs on an interface.

### Alarms

Displays the **Current Alarms** table. There is also a page button that displays the **Unit Event History Table.**

### Transport Stream

This page contains the transceiver parameters. This includes alarm statuses and bitrate values. There is some configuration in the **TS Config** table.

At the bottom of the page, there are several page buttons that provide access to the following pages:

- **IP Inputs:** This page displays the IP inputs of the device, in the **IP Inputs, IP Rx Configuration, IP Rx Status, IP Rx FEC,** and **IP Rx Ping** tables. There are also parameters available to add or delete IP inputs.
- **Services**: Displays the **Services** and **Service components** tables.
- **PIDs**: Displays the **PIDs** table.
- **Input Status**: Displays the Input Alarms in separate tables with separate alarms per column. Displays the Alarms table, which lists all the possible alarm IDs with their **State**, **Current Status**, **Configured Severity**, **On Count**, and **Error Count**.

There are also page buttons for **TS Out SFN Tx Table, TS Out Config Table, TS Out SFN Table, TS Out Mute Table, TS PCR Status Table, TS IS Inputs Stat Table.**

### Switch Inputs

This page contains the list of **Switch Inputs** and **Switch Ports**. It is possible to add or delete entries in the list.

Using the **Manage Switches** for the options to manage soft switches and add inputs to the switches.

### Events

This page contains the **Trap Events Table**, which is filled in whenever a **trap of type Event** is received. The page contains a button in order to **Clear Events** and a parameter that sets the **Traps Max Number** to show in the table.

### Output Streams

On this page, you can manage the **Streams** and **ASI Ports** for outgoing streams.

At the bottom of the page, there are several page buttons that provide access to the following pages:

- **IP Outputs:** This page displays the **IP Tx Configuration**, **IP Tx Status, IP Tx FEC, IP Tx Ping** tables to configure the IP Outputs.

- **Note**: using the right-click context menu on the **IP Tx Configuration**, you can add and delete interfaces on a stream.

- **Stream ASI Outputs**: Using this page, you can select a stream and then add ASI Outputs to the stream, or delete using the **Stream ASI Outputs**

- **Stream Status:** Similar to the Input Status, the alarms for the streams are displayed in the **Stream Status** table.

### Trap Destinations

This page shows a **Traps table**. It also has a page button that opens a page where you can **create and configure SNMP traps**.

### Web Interface

This page can be used to access the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DCF Implementation (Range 2.0.0.x, 2.0.1.x, 2.0.2.x)

On the **Output Page**:

- The **Streams Table** allows you to select which inputs (**ASI Ports** or **IP**) should connect to each available **Stream**, by the input ID. **ASI Ports** and **IP** IDs can be found in the **ASI Ports Table** and the **IP Inputs Table**, respectively, on the pages **Output** and **IP Input**.
- The **ASI Ports Table** allows connections to be created between **Streams** (as Inputs) and **ASI Ports** (as Outputs).

On the **IP Tx Page**:

- The **IP Tx Configuration Table** allows connections to be created from **Streams** to **IP**, more specifically to the associated **Ethernet** **Interface**.

## Notes

### DCF Implementation

**ASI Ports** and **IP** IDs can be found in the **ASI Ports Table** and in the **IP Inputs Table**, respectively, on the pages **Output** and **IP Input**.

All the connections with **IP** use the **Ethernet Interface**. The Ethernet Interface for the **Input IP** can be found on the **Table IP Rx Configuration** on the **IP Rx page**.

### Traps

The connector can receive traps under the subtree OID **1.3.6.1.4.1.22909.1.1.0 (unitNotifications)** and process 3 different kinds of traps: Alarm Status, Alarm and Event:

- **Alarm Status**: Updates the **General Alarm Status** parameter value, shown on the General page.
- **Alarm**: If an alarm with the same Reference Number already exists in the **Current Alarms Table**, its values will be updated. However, if the new alarm does not exist yet, the table will be polled via SNMP.
- **Event**: The new event is added to the **Trap Event Table** with the values sent in trap bindings.
