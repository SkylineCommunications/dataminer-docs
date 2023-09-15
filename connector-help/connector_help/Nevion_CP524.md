---
uid: Connector_help_Nevion_CP524
---

# Nevion CP524

The CP524 TS adapter is designed to meet the requirements of operators and service providers for flexible repacking and delivery of content for multiple end points.

Its multi-stream (any input to any output) filtering/remultiplexing features enable operators and service providers to save valuable bandwidth in their networks.

## About

This connector displays information that is polled from the device with **SNMP**. The 2.0.0.x range instead uses **HTTP** to retrieve the data, and uses **SNMP** for traps.

### Version Info

| **Range**     | **Description**                                                                                                    | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.1.x              | Added soft switches and updated DCF accordingly. Updated all display keys, fixed some issues and cleaned protocol. | Yes                 | Yes                     |
| \[SLC Main\] 2.0.0.x | Initial version using HTTP communication Added outgoing services and PIDs                                          | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.1.x          | 2.0.16 2.4.6                |
| 2.0.0.x          | 2.4.6                       |

## Installation and configuration

### Creation (1.0.1.x)

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Creation (2.0.0.x)

#### HTTP Main Connection

This connector uses an HTTP connection to the CP524 device and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the Nevion CP524 device.
- **IP port**: The IP port of the destination, by default *80*.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

#### SNMP Traps Connection

This connector uses an SNMP connection for traps and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device to receive traps from.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage (1.0.1.1)

### General Page

This page displays a number of general parameters related to the device. It also contains a page button that displays the **History table**.

### Alarm Page

This page contains information about alarms on the device. The maximum number of entries in the **Alarm Table** is limited. You can customize this limit with the **Alarm Table Amount Entries** parameter.

There is also a page button that displays the **ASI1 ASI2 Alarms** subpage.

### Inputs Page

This page displays two tables with information about the inputs.

There are also two page buttons, which display the **Services** page and the **PIDs** page.

### Outputs Page

This page contains one table, which provides information about the outputs.

Below the table, two page buttons provide access to the **MIP** **Settings** page and the **OFDM** **Settings** page.

### Configuration Page

On this page, you can fill in different fields to configure the device.

There are two buttons available, which can be used to **upload** or **download** a configuration file.

### Service Components Page

This page displays two tables, the **Service** **Components Table** and the **Physical** **Ports Table**.

### IP Transport Page

This page displays five tables:

- **TS IP Input**
- **TS IP Input RX**
- **IP RX Ping**
- **TS IP Output RX**
- **IP TX Ping**

### Input Switching Page

This page displays the **soft switches** available in the device. Via a page button, you can **create/delete a soft switch** and **add/delete ASI or IP inputs** to the soft switches.

### Web Interface Page

This page displays the web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage (1.0.1.2)

### General Page

This page displays a number of general parameters related to the device. At the bottom, the **Port Configuration** table displays the available ports and formats.

There is also a page button that displays the **Alarm/Event Table**.

### Ethernet Page

This page displays the interface information in the **Interfaces** and **Unit VLAN Table**.

> **Note**: You can add and delete VLANs on an interface via the context menu of the **Unit VLAN Table**.

### Alarms Page

This page contains information about alarms on the device. The maximum number of entries in the **Alarm Table** is limited. You can customize this limit with the **Alarm Table Amount Entries** parameter.

Using the **Config Table...** page button, you can change the desired display key format of the table.

There is also a page button that displays the **Event History** subpage with the **Unit Event History Table**, and a page button that displays the **ASI1 ASI2 Alarms** subpage.

### TS Input Overview Page

This page displays a tree structure of the **Inputs**, **Services** and **PIDs**.

### Inputs Page

On this page, the **Input Table** and **TS Input Config Table** display information regarding the device inputs, such as the **Total and Effective Bitrates**.

There are also four page buttons, two of which display the **Services** page and the **PIDs** page. On each page, you can configure the display key using the drop-down box at the top of the page.

The **IP Inputs** page displays IP input information in the **TS IP Input Table, TS IP Input Rx Table, TS IP Input Rx FEC** and **TS IP Input Rx Ping Table**.

> **Note**: You can add and delete IP inputs via the context menu of the **TS IP Input Table**.

On the **Input Status** page, you can find associated alarms for all inputs in two separate tables.

### Outputs Page

This page contains one table, which provides information about the outputs.

Below the table, two page buttons provide access to the **MIP Settings** page and the **OFDM Settings** page.

Similar to the IP Inputs page, the **IP Outputs** page displays the **TS IP Output Tx Table**, **TS IP Outputs FEC, TS IP Outputs Common FEC** and **IP Tx Ping Table**, which all provide information on the IP outputs.

> **Note**: You can add and delete interfaces for an output via the context menu of the **TS IP Output Tx Table**.

On the **Outputs** **Status** page, you can find associated alarms for all the outputs in two separate tables.

### Configuration Page

On this page, you can fill in different fields to configure the device.

There are two buttons available, which can be used to **Upload** or **Download** a configuration file.

### Service Components Page

This page displays the **Service Components Table**.

### Input Switching Page

This page displays the **Soft Switches** available in the device. On the **Manage Switches** page, you can **Create/Delete** a soft switch and **Add/Delete ASI or IP inputs** to the soft switches.

### Web Interface Page

This page displays the web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage (2.0.0.x)

### General Page

This page displays a number of general parameters related to the device. At the bottom, the **Port Configuration** table displays the available ports and formats. This table also allows you to configure ports as either inputs or outputs.

There is also a page button that displays the **Alarm/Event Table**.

### Ethernet Page

This page displays the interface information in the **Interfaces** and **Unit VLAN Table**.

> **Note**: You can add and delete VLANs on an interface via the context menu of the **Unit VLAN Table**.

### Alarms Page

This page contains information about the current alarms on the device. The maximum number of entries in the **Alarm Table** is limited. You can customize this limit with the **Alarm Table Amount Entries** parameter.

Using the **Config Table...** page button, you can change the desired display key format of the **Alarm Table**.

There is also a page button that displays the **Event History** subpage with the **Unit Event History Table**.

### TS Input Overview Page

This page displays a tree structure of the **Inputs, Services** and **PIDs** both for ASI and IP inputs.

### Inputs Page

The **Input Table** contains the information regarding the device inputs, such as **Total and Effective Bitrates**.

There are also four page buttons, two of which display the **Services** page and the **PIDs** page. On each page, you can configure the display key using the drop-down box at the top of the page. In addition, there is a method to delete any missing/extra services or PIDs from the tables using the **Remove Missing Services/PIDs** drop-down list.

The **IP Inputs** page displays IP input information in the **TS IP Input Table, TS IP Input Rx Table, TS IP Input Rx FEC** and **TS IP Input Rx Ping Table**.

> **Note**: You can add and delete IP inputs via the context menu of the **TS IP Input Table**.

On the **Input Status** page, you can find associated alarms for all inputs in two separate tables.

### TS Output Overview Page

This page displays a tree structure of the **Outputs**, **Outgoing Services** and **Outgoing PIDs**.

### Outputs Page

This page contains one table, which provides information about the outputs.

Below the table, there are several page buttons that provide access to additional information, such as the **OFDM** **Settings** page.

Outgoing services and PIDs can be found on the **Outgoing Services** and **Outgoing PIDs** pages.

Similar to the IP Inputs page, the **IP Outputs** page displays the **TS IP Output Tx Table**, **TS IP Outputs FEC, TS IP Outputs Common FEC** and **IP Tx Ping Table**, which all provide information on the IP outputs.

> **Note**: You can add and delete interfaces for an output via the context menu of the **TS IP Output Tx Table**.

On the **Outputs Status** page, you can find associated alarms for all the outputs in two separate tables.

### Configuration Page

On this page, you can fill in different fields to configure the device.

It is important that you fill in the **Username** and **Password** for the device before configuring settings of the device via DataMiner.

There are two buttons available, which can be used to **Upload** or **Download** a configuration file.

### Input Switching Page

This page displays the **Virtual Switches** available in the device. On the **Manage Switches** page, you can **Add/Delete ASI or IP inputs** to the switches.

> **Note**: You can add and delete input switches via the context menu of the **Input Switches Table**.

### Web Interface Page

This page displays the web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

The **1.0.1.x** connector range of the **Nevion CP524** protocol supports the usage of DCF and can only be used on a DMA with **8.5.14** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Virtual fixed interfaces:

- **VirtMUX**: All physical interfaces that are used for input and not connected to a soft switch are connected through this interface, which is of type **inout**. All soft switches are connected through this interface as well.

Physical fixed interfaces:

- **ASI1**: Physical ASI interface with type **inout**.
- **ASI2**: Physical ASI interface with type **inout**.
- **ASI3**: Physical ASI interface with type **inout**.
- **ASI4**: Physical ASI interface with type **inout**.
- **ASI5**: Physical ASI interface with type **inout**.
- **ASI6**: Physical ASI interface with type **inout**.
- **ASI7**: Physical ASI interface with type **inout**.
- **ASI8**: Physical ASI interface with type **inout**.
- **Eth1**: Physical RJ45 interface with type **inout**.
- **Eth2**: Physical RJ45 interface with type **inout**.
- **Eth3**: Physical RJ45 interface with type **inout**.
- **RefIn**: Physical ASI interface with type **inout**.

#### Dynamic Interfaces

Virtual dynamic interfaces:

- **VirtTS**: All transport streams are represented by an interface, linked with the **Output Table**. All these interfaces are of type **inout**.
- **VirtSS**: All soft switches are represented by an interface, linked with the **Input Switches** **Table**. All these interfaces are of type **inout**.

### Connections

#### Internal Connections

- If in the **Physical Ports Table** the value for the **Output/Input Select** is **Input** (-1) and the ASI port is not connected to a **VirtSS** interface, for all ASI ports that are used as input, an internal connection is created between that **ASIx** interface and the **VirtMUX.**
- For all available **VirtSS** interfaces, an internal connection is created between the **VirtSS** interface and the **VirtMUX**.
- If, in the **TS IP Input RX** **Table**, the **Interface Name** contains **ethx**, for all Ethernet ports that are used as input, an internal connection is created between that **Ethx** interface and the **VirtMUX**.
- If the TS is in the **Output Table**, an internal connection is created between the **VirtMUX** and all the transport streams from the **VirtTS**.
- If in the **Physical Ports Table** the value for the **Output/Input Select** is TS x **Output** (9, 10, 11 or 12) and in the **TS IP Output TX** **Table** the **Interface Name** contains **ethx**, an internal connection is created between the interfaces from **VirtTS** and all the ports that are used as output for the transport stream.
