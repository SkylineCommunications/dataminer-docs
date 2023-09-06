---
uid: Connector_help_Ericsson_Fabrix_VIDFX
---

# Ericsson Fabrix VIDFX

This is an SNMP driver for the Ericsson Fabrix VIDFX management system. It **exports DVEs** based on the **Nodes Tables**, which is then used to link data.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                   |
|-----------|---------------------|-------------------------|-----------------------|---------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | [Fabrix VIDFX Node](xref:Connector_help_Ericsson_Fabrix_VIDFX_Node) |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this driver has several data pages. You can find more information on these below.

### General

This page displays information about the device itself, such as the System Description, Uptime, Contact, Name, and Location.

### Server Logs

This page contains the **Log table**, which is filled in when a log (SNMP trap) is received. Two parameters allow you to control the **log table size** and to determine **how many entries (logs) will be removed** when the table is full.

### Video Server

This page contains the Video Server Regions Performance Counters, Video Server Pods Performance Counters and Video Server Node Performance Counters tables.

### Storage

On this page, you can find a table with information such as Read Throughput, Write Throughput, Wait for Latency, Service Latency, and Read IOPS (Input/Output Operations per Second).

### Solid DB

On this page, you can find a table with information regarding the **Fabrix Solid DB**, including the DB Size, DB Free Size, DB Configuration Size, Response Time, and Last Checkpoint.

### Manager

This page contains the Fabrix Manager, Fabrix Manager Proxy, and Fabrix Scheduler tables.

### Nodes

On this page, you can find the following tables:

- **Nodes**: Contains information regarding the CPU, Memory, Uptime, OS-Core Counter, and App Core Counter. The information in this table is exported to standalone parameters in the DVEs.
- **Nodes Disks table**: Displays parameters such as Capacity, Service Time, Throughput Write, and Throughput Read Average Request Time, IOPS, and Await. This table is linked to the **Nodes** tables.
- **Nodes Processes**: Displays information such as PID, Process Memory Usage, Process CPU Usage, Process Open Sockets, Process Bytes Read, and Process Bytes Write. This table is linked to the **Nodes** table.

### Nodes NICs

On this page, you can find the following tables:

- **Nodes NICs**: Displays the Link State, Bytes Sent, Bytes Received, Packets Sent, Packets Received, Errors In, Errors Out, Drop-In, Drop-Out, and Primary NIC. This table is linked to the **Nodes** table.
- **Nodes NICs Pingable**: Shows whether a host is pingable or not. This table is linked to the **Nodes** table.
- **Nodes NICs TCP**: Lists the Out Segments and Retransmitted Segments. This table is linked to the **Nodes** table.
