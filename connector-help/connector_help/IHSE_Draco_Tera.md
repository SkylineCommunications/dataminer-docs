---
uid: Connector_help_IHSE_Draco_Tera
---

# IHSE Draco Tera

The IHSE Draco Tera matrix is a KVM system that allows connections to be established from consoles (CON devices) to various sources (CPU devices).

This connector uses a **serial** connection to retrieve the connection state of the matrix. It also retrieves lists of CPU devices, CON devices, and users, which it displays in the corresponding tables.

## About

### Version Info

| **Range**            | **Key Features**              | **Based on** | **System Impact** |
|----------------------|-------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version               | \-           | \-                |
| 1.0.1.x \[Obsolete\] | Redundant polling added       | \-           | \-                |
| 1.0.2.x \[SLC Main\] | Various discrete values fixed | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | \-                     |
| 1.0.2.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device, by default *115200*.
  - **Databits**: Databits specified in the manual of the device, by default *8*.
  - **Stopbits**: Stopbits specified in the manual of the device, by default *1*.
  - **Parity**: Parity specified in the manual of the device, by default *no*.
  - **FlowControl**: FlowControl specified in the manual of the device, by default *no*.

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device, by default *5555*.

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Settings:

- **IP port:** The IP port of the device.
- **Get community string:** The community string used when reading values from the device, by default *public*.
- **Set community string:** The community string used when setting values on the device, by default *private*.

## How to use

The element consists of the data pages detailed below.

### General

This page displays device info, such as the **Manufacturer**, **Family**, **Status**, **Type**, current system **date and time**, **number of CPU devices**, **number of CON devices** and **number of users**.

It also displays a section of **Recent Changes**, which allows you to quickly check the last changes made to slots, inputs, outputs, and connections.

Finally, there is also a **Hardware Status** section, where you can monitor the **Temperature**, **Fan Status**, **Fan Speed** and **Power Status**.

### CPU Devices

This page contains a table with all the connected CPU devices, listing their ID and Name.

### CON Devices

This page contains a table with all the connected CON devices, listing their ID and Name.

### Users

This page contains a table with all the users, listing their ID and Name.

### Connections

This page contains a matrix that allows you to monitor the current state of the KVM Matrix. It shows where a CON device is connected and allows you to set new connections.
