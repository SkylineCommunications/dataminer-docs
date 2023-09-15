---
uid: Connector_help_Evertz_Xenon_Switch
---

# Evertz Xenon Switch

The **Evertz Xenon Switch** offers both the flexibility of multiformat operation and the ability to add signal processing technology. To avoid single points of failure, active assemblies are hot-swappable from the front of the frame, and power, control, cooling and reference generation are available in redundant configurations.

## About

The **Evertz Xenon Switch** connector uses both SNMP and serial communication to monitor the Evertz switch. The device contains two controllers, but only one can be in control at a time. The controller in control will be interrogated using SNMP queries and Ethernet queries.

To avoid issues because of excessive polling, the device is polled at startup and whenever a message of type .UVxxx,xxx is received. In addition, in case the device is configured using a different tool so that such messages are not received, it is also polled daily.

Between requests, there is a pause of 0.5 seconds. This prevents the loop from going too fast and keeps the device from going into error state. Note, however, that this does mean that it will take a while for the element to load the entire matrix (since version 1.0.0.7).

### Version Info

| **Range** | **Description**                                                                | **DCF Integration** | **Cassandra Compliant** |
|------------------|--------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                                | No                  | Yes                     |
| 2.0.0.x          | Initial version (connector review)                                                | No                  | Yes                     |
| 2.0.2.x          | Updates pushed from the device for the crosspoints (smart-serial) - to be used | Yes                 | Yes                     |
| 2.1.0.x          | Hardware update SNMP v1                                                        | No                  | Yes                     |
| 2.1.1.x          | DCF updated from matrix to tables                                              | Yes                 | Yes                     |
| 2.1.2.x          | Improved tables for Router Control and Visio (smart-serial) - to be used       | Yes                 | Yes                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

#### Serial SerialPort Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION (**TCP/IP**):

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device.
  - **Databits**: Databits specified in the manual of the device.
  - **Stopbits**: Stopbits specified in the manual of the device.
  - **Parity**: Parity specified in the manual of the device.
  - **FlowControl**: FlowControl specified in the manual of the device.

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device (port *23*).
  - **Bus address**: The bus address of the device (range: *16 - 1*). The bus address is used as the **Matrix Level**:

    | Bus Address number | Matrix Level |
    |--------------------|--------------|
    | 1                  | V            |
    | 2                  | A            |
    | 3                  | B            |
    | 4                  | C            |
    | 5                  | D            |
    | 6                  | E            |
    | 7                  | F            |
    | 8                  | G            |
    | 9                  | H            |
    | 10                 | I            |
    | 11                 | J            |
    | 12                 | K            |
    | 13                 | L            |
    | 14                 | M            |
    | 15                 | N            |
    | 16                 | O            |

#### Serial SerialPortBackup Connection (2.0.2.x and 2.1.2.x)

This connector uses a second serial connection to configure the redundant controller and requires the following input during element creation:

SERIAL CONNECTION (**TCP/IP**):

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device.
  - **Databits**: Databits specified in the manual of the device.
  - **Stopbits**: Stopbits specified in the manual of the device.
  - **Parity**: Parity specified in the manual of the device.
  - **FlowControl**: FlowControl specified in the manual of the device.

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device (port *23*).

## Usage

### General Page

This page contains general information on the device. In addition, it allows you to set the **System Destination**, and to **lock** or **unlock** the device.

However, note that locking and unlocking is not possible in version 2.0.2.x, as there locking is done on software level.

### Matrix Page

This page displays the **connection matrix** of the device.

### Matrix Details Page

On this page, you can view the connection from the **Destination table**, **Source table** and the **Level**.

### Card Status Page

On this page, all the cards and their data are displayed.

### Fan Page (not available in v 2.1.x.x)

This page contains the **Fan Status Table**, which displays the speed of the fans.

### Power Supply Status Page (not available in v 2.1.x.x)

This page contains the **Power Supply Status Table**, which displays data concerning the power of the device.

### Setting Page

This page contains several settings that can be used to configure the device, including a **reset** option.
