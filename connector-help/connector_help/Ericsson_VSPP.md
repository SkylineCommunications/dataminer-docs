---
uid: Connector_help_Ericsson_VSPP
---

# Ericsson VSPP

The Ericsson VSPP is a **Management System**.

## About

### Version Info

| **Range** | **Key Features**      | **Based on** | **System Impact** |
|-----------|-----------------------|--------------|-------------------|
| 1.0.0.x   | Initial version       | \-           | \-                |
| 1.0.1.x   | HTTP connection added | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host:** The polling IP of the device

SNMP Settings:

- **Port number:** The port of the connected device (default value: *161).*
- **Get community string:** The community string used when reading values from the device (default value: *public*).
- **Set community string:** The community string used when setting values on the device (default value: *private*).

#### HTTP connection

This connector also uses a HyperText Transfer Protocol (HTTP) connection to the management node:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.

HTTP Settings:

- **Port number**: The port of the connected device (default value: *5929*).

### Initialization

Any system requesting data from the management node must be authorized through the management Web UI, otherwise this will return an HTTP 403 (access forbidden).

You can configure this by adding the DataMiner IP to the "Manager authorized list" via Navigation \> Administration \> Security.

## Usage

The element created using this connector has the following data pages:

- **General**: Displays information regarding the device itself, such as the System Description, Uptime, Contact, Name and Location.

- **Manager**: Contain the **Fabrix Manager**, **Fabrix Manager Proxy** and **Fabrix Scheduler** tables.

- **Nodes**: Contains the **Nodes table**, which displays information on the CPU, Memory, Uptime, OS Core Counter and App Core Counter. The information in this table is **exported to the DVEs** as standalone parameters.

- **Nodes Disks**: Displays a table with parameters such as Capacity, Service Time, Throughput Write and Throughput Read Average Request Time, IOPS and Await. This table is **linked** to the **Nodes** tables.

- **Nodes NICs**: Contains the following tables:

- **Nodes NICs** **table**: Displays the Link State, Bytes Sent, Bytes Received, Packets Sent, Packets Received, Errors In, Errors Out, Drop In, Drop Out and Primary NIC. This table is **linked** to the **Nodes** table.
  - **Nodes NICs Pingable** **table**: Shows whether a host **is** **pingable** or not. This table is **linked** to the **Nodes** table.
  - **Nodes NICs TCP** **table**: Displays the Out Segments and Retransmitted Segments. This table is **linked** to the **Nodes** table.

- **Nodes Processes**: Contains the **Nodes Processes table**, with information such as PID, Process Memory Usage, Process CPU Usage, Process Open Sockets, Process Bytes Read and Process Bytes Write. This table is **linked** to the **Nodes** table.

- **Server Logs**: Contains the **Log table**, which is filled in when a log (SNMP trap) is received. There are two parameters that allow you to control the **log table size** and **how many entries (logs) will be removed** when the table is full.

- **Solid DB**: Contains the **Fabrix Solid DB** table, with information such as DB Size, DB Free Size, DB Configuration Size, Response Time and Last Checkpoint.

- **Storage**: Contains a table with information such as Read Throughput, Write Throughput, Wait Latency, Service Latency and Read IOPS (Input/Output Operations per Second).

- **Video Server**: Contains the **Video Server Regions Performance Counters**, **Video Server Pods Performance Counters** and **Video Server Node Performance Counters** tables.

- **Channel List**: Contains the **Size** parameter, which displays the total number of channels, as well as the **Channel Overview Table** and the **list of errors**.

- **ABR Profiles**: Contains the **ABR Encoding Profiles** table, which displays all ABR profiles, and the **ABR Storage/Playout Table**, which lists all storage and playout profiles of a channel.

- **CBR Profiles**: Contains the **CBR Encoding Profiles** table, which displays all CBR sources of a channel.
