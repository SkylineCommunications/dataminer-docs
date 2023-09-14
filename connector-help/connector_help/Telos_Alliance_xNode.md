---
uid: Connector_help_Telos_Alliance_xNode
---

# Telos Alliance xNode

The Telos Alliance xNode is an audio converter. This connector can be used to monitor and control this device.

## About

Since the device can be either AES or GPIO, the connector uses SNMP and serial communication to retrieve information from the device.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

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

#### Serial GPIO Serial Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: Baudrate specified in the manual of the device.
  - **Databits**: Databits specified in the manual of the device.
  - **Stopbits**: Stopbits specified in the manual of the device.
  - **Parity**: Parity specified in the manual of the device.
  - **FlowControl**: FlowControl specified in the manual of the device.
- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.

## Usage

### General

This page contains general information on the **Telos Alliance xNode**.

At the top of the page, the **Device Type** option allows you to select the type of device. Note that the **correct type must be selected** in order for the connector to poll the related information.

If the type of device is **GPIO**, the login password must be entered in order to be able to make changes in the GPO ports.

### IP Configuration

This page contains the **IP Addresses Table** and **IP Routes Table**. In the **IP Addresses Table**, several settings can be configured, such as **Mask**, **Next Hop** and **Type**.

### AES

This page displays the **Sources Table** and **Destinations Table.** **Label** values are retrieved using the GPIO protocol.

### Meter Data

This page displays the **PEEK** and **RMS** values for the input and output channels, in the **Inputs MTR Table** and **Outputs MTR Table**.

### Input Detection

This page allows you to configure either the clip or the silence levels and the time for alarming in the **Inputs Configuration** **Table**.

Alarm information is displayed in the **Inputs Alarms** **Table**.

### Output Detection

This page allows you to configure either the clip or the silence levels and the time for alarming in the **Outputs** **Configuration** **Table**.

Alarm information is displayed in the **Outputs Alarms Table**.

### GPIO

This page displays information related to **GPI** and **GPO** ports.

Note that you must first press the **Login** button before **GPIO** information is changed. In case you notice data does not update correctly, check the password on the **General** page.

### Web Page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
