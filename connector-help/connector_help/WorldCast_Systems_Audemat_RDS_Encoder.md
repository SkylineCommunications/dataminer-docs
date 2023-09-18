---
uid: Connector_help_WorldCast_Systems_Audemat_RDS_Encoder
---

# WorldCast Systems Audemat RDS Encoder

This is an SNMP connector that can be used to monitor a WorldCast Systems Audemat RDS Encoder. This device is a radio data system encoder with 1 RF input, 3 analog MPX inputs/outputs and 3 MPX through AES inputs/outputs.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.1.8                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

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

The element created with this connector consists of the following data pages:

- **General**: Displays system information such as the **Name**, **Description**, **Serial** **Number** and **Software** **Version**. Also displays **Date & Time** information and **Network** information.

- **Status**: Displays the Current RDS State along with the Current **PI**, **PS**, **TA State** and **TP State**. Also contains the **UECP Timeouts Table**.

- **Settings**: Allows you to configure multiple settings, including **Current DSN, PI, PS, TA, TP, PTY, PTYn, Long PS** and **Group Sequence** for a specific **DSN**. Also contains the **Radio Text Table** and **PSN AF Table**, as well as page buttons to the subpages **FM** and **EON**.

- **FM**: Allows you to configure FM settings such as **Frequency, Receiver State, RF Level** and **MPX Deviation**.
  - **EON**: Allows you to **Create** and **Delete EON** in the current DSN, as well as check the available configurations in the **EON Table.**

- **Traps**: Contains the trap configuration, as well as information about traps such as the trap timestamps.
