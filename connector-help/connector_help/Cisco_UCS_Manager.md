---
uid: Connector_help_Cisco_UCS_Manager
---

# Cisco UCS Manager

The **Cisco UCS Manager** connector monitors a Cisco Systems manager unit through **SNMP** (range 1.0.0.x) or through the **CISCO UCS XML Web API** (range 2.0.0.x).

The connector polls relevant information, statistics, and active faults from the device.

## About

### Version Info

| **Range**            | **Key Features**                        | **Based on** | **System Impact** |
|----------------------|-----------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version                         | \-           | \-                |
| 2.0.0.x              | CISCO UCS XML Web API                   | \-           | \-                |
| 2.0.1.x              | New firmware version                    | \-           | \-                |
| 2.1.0.x              | New firmware version Web API connection | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.1.2a                 |
| 2.0.0.x   | 4.0(1a)                |
| 2.0.1.x   | 4.2(2a)                |
| 2.1.0.x   | 9.3(5)\|42             |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 2.1.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections (Range 1.0.0.x)

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: *161*
- **Get community** **string**: *TNUCScommunityRO*
- **Set community string**: *private*

### Connections (Range 2.0.0.x/2.0.1.x/2.1.0.x)

#### HTTP Main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination. Default value is 443.

### Initialization (Range 2.1.0.x)

On the General page, specify the credentials the connector needs to be able to retrieve information from the device.

### Web Interface

The client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage (Range 1.0.0.x)

### General

This page displays general information related to the device: **Contact, Name, Location,** **Object ID, Uptime,** and **Description.**

### Processor

This page displays the runtime processor statistics: **Load, Average Load, Maximum Load, Minimum Load,** and **Up Time.**

It also displays the **Processor Env** statistics: **Input Current** and **Temperature (Avg, Max, Min)**.

### Memory

This page displays the runtime memory statistics: **Available, Average Available, Maximum Available, Minimum Available, Cached,** etc.

It also displays the runtime **Memory** **Unit** and **Memory Unit Env** statistics.

### Equipment

This page displays the following tables:

- The **Chassis Table**, including the **Model, Vendor, Operability, Presence, Power, Thermal, Administration State**, etc.
- The **Fan Table**, including the **Model, Vendor, Operability, Presence, Performance, Power, Thermal**, etc.
- The **PSU Table**, including the **Model, Vendor, Operability, Presence, Performance, Power, Thermal, Voltage, Wattage**, etc.
- The **Equipment Fan Table**, including the **Operational State, Operability, Presence**, etc.
- The **Health LED** **Table**, including the **Color, State, Operational State**, etc.

### Storage Page

This page displays the following tables:

- The **Storage Table**, with the columns **Name, Size, Used**, and **Operability.**
- The **Local Disk Table**, including the **Model, Vendor, Operability, Presence, Power, Thermal, Size, Block Size**, etc.

On this page, there are also three page buttons:

- **Controller**: Displays the following tables:

- The **Storage Controller Table**, which includes the **Operational State, Presence, Model**, etc.
  - The **Storage Flex Flash Controller Table**, which includes the **Controller Health, Controller State, Operational State**, etc.

- **Local LUN**: Displays the **Storage Local LUN Table**, which includes the **Operability, Presence**, etc.

- **RAID Battery**: Displays the **Storage RAID Battery Table**, which includes the **Operability, Presence**, etc.

### Faults Page

This page displays a table with information on the **Faults** of the device: **Severity, Description, Probable Cause**, and **Affected Object.**

### Compute Page

This page displays the following tables:

- The **Board** **Table**, including the **CMOS Voltage, Operations Power, Presence**, etc.
  The **Mb Power Statistics Table**, including the **Consumed Power, Input Voltage, Available Memory**, etc.
  The **Rack Unit Table**, including the **Admin Power, Available Memory, Admin State**, etc.
  The **Rack Unit Mb Temperature Statistics Table**, including the **Ambient Temperature, Front Temperature**, etc.

## Usage (Range 2.0.0.x)

### General

This page displays general information related to the device: **System Name, Serial Number Model, Asset Tag,** and the **Equipment System IO Controllers** table**.**

### Equipment

This page displays the following tables:

- The **Equipment Indicator LED**, including the **ID, Name, State**, and **Color**.
- The **Equipment PSU**, including the **ID, PID, Model, Vendor, Serial Number, Voltage, Status, Power,** and **Presence.**
- The **Equipment Fan Modules**, including the **ID, Operability, Power,** and **Presence**.

### Network

This page displays the **Management Interface** table, including the **ID, Description, Type, Speed, IP Address, Extension Mask, Extension Gateway, MAC, DHCP**, and **Operation**.

### Compute Nodes

This page displays the **Compute Server Nodes**, including the **ID, Name, Model, Vendor, Serial Number, Available Cores, Threads, Memory**, and **Utilization Statistics.**

### Firmware

This page displays the following tables:

- The **Firmware Running**, including the **ID, Name, Description, Deployment, Type,** and **Version**.
- The **Firmware Updatable**, including the **ID, Name, Description, Admin State, Deployment, Operational State, Version, Protocol, Remote Server, Remote Path, User, Password, Progress, Type,** and **Secure Boot.**
- The **Firmware Boot Definition**, including the **ID, Name**, and **Type**.
- The **Firmware Management Interface**, including the **ID, Name, Description, V4 IP Address, MAC, Host Name, V6 Extension, V6 IP Address, V6 Prefix, V6 Extension Gateway, V6 Stateless Address Autoconfiguration IP, Subject,** and **V6 Link Local**.

### Faults

This page displays the **Faults** table.

This table contains the following parameters: **RN, Affected Object, Code, Creation Time, Description, Highest Severity, Last Modification Time, LC, Occurrences, Original Severity, Previous Severity, Severity, Tags, Type,** and **Server.**

### Storage

This page displays the following tables:

- The **Storage Controller**, including the **Instance, Dn, Name, Presence, RAID, Serial Number, Type, Vendor, Health, Status, Battery Status, BBU, Chip Temperature, Back End Ports, Memory Size, Cache Memory Size, Physical Drives,** and **Server.**
- The **Local Disk,** including the **Instance, Dn, RN, Status, Connection Protocol, Model, State, Health, Online, Revision, Serial, Size, Vendor, Enclosure Association, Enclosure Logical ID, Locator LED, Secured State, Link Speed, Lock State, Administrative Action,** and **Server.**

## Usage (Range 2.1.0.x)

This range currently displays the following pages, with largely the same information as in the 1.0.0.x range (see above):

- **General**: Contains the user and password required to retrieve the information from the device.

- **Equipment**

- **Fan**
  - **Health LED**
  - **PSU**

- **Compute**

- **Storage**

- **Processor**

- **Memory**
