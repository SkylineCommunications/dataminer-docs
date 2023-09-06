---
uid: Connector_help_Evertz_7881TSM-IP
---

# Evertz 7881TSM-IP

This connector displays general information about the Evertz 7881TSM-IP device and allows you to monitor the input and output ports. It also allows you to keep track of TS syntax errors.

## About

### Version Info

| **Range**            | **Key Features**                                                    | **Based on** | **System Impact**                                                                               |
|----------------------|---------------------------------------------------------------------|--------------|-------------------------------------------------------------------------------------------------|
| 1.0.0.x              | \- Input and output port monitoring- Monitoring of TS syntax errors | \-           | \-                                                                                              |
| 1.0.1.x \[SLC Main\] | \- Tree control for transport stream- Bit rate unit selector        | 1.0.0.10     | Alarm monitoring and trending of bit rate uses different parameters than in the previous range. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.2 build 13           |
| 1.0.1.x   | 1.2 build 13           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

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

#### SNMP "SNMP Connection" Connection

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

The element created with this connector has the following data pages:

- **General**: Displays general information about the device such as the **Firmware** and **Serial Number**. Also contains the **System Control** table, which allows you to **Reboot** the system or perform a **Factory Reset**.
- **Port Monitor**: Displays statistics regarding the input and output ports, such as **Good Frames**, **Dropped Packets**, **Discarded Packets**, etc.
- **TSM**: Displays the **Input Control** table, where you can configure parameters such as the **IP Address** from which to receive the stream and the **UDP Port** number to receive the stream. The **Monitor** status allows you to enable or disable the stream monitoring.
- **Input Monitor**: Contains multiple tables that display relevant information about the inputs, such as **average bitrate**, **number of programs**, and **known PIDs** detected in the input stream.
- **TS Syntax Errors**: Displays multiple tables that allow you to monitor possible errors as well as configure the error test for each variable.
- **PID Monitor**: Contains multiple PID-related tables, namely **PID Table**, **PID Template Control**, and **PID Monitor Control.**
- **Transport Stream:** Contains a tree control with transport stream information. The tree control uses the following relationship order: **Input Table** \> **Program Name** \> **PID Table**.
