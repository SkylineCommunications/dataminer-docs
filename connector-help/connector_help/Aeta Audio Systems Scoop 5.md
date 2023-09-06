---
uid: Connector_help_Aeta_Audio_Systems_Scoop_5
---

# Aeta Audio Systems Scoop 5

The Aeta Audio Systems Scoop 5 driver can be used to display information of any related device. A serial and smart-serial connection are used to retrieve information from the device.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

- **Baudrate**: 38400
  - **Databits**: 8
  - **Stopbits**: 1
  - **Parity**: Even
  - **FlowControl**: No

- Interface connection:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
  -  **IP port**: The port of the connected device, by default *161*.
  - **Bus address**: Range 1 to 8.

#### Smart-Serial connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

- **Baudrate**: 38400
  - **Databits**: 8
  - **Stopbits**: 1
  - **Parity**: Even
  - **FlowControl**: No

- Interface connection:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
  - **IP port**: The port of the connected device, by default *161.*
  - **Bus address**: Range 1 to 8.

## Usage

### Status

This page displays status information like the **Coding, Bit Rate, Sample Rate, Levels on Tx and Rx Left and Right, IP Addressing Mode, IP** information, etc.

### Calls

This page allows you to easily **start** and **stop** **calls** for the two codecs. You can set the **Remote** **Number** and check the **Codec** **Status**.

### Connections

This page is an extension of the previous page. It allows you to make calls but also to set other parameters, e.g. to **mask events**.

On the **Local Numbers** and **Remote Numbers** subpages, up to 8 numbers can be set.

### AoIP Parameters

On this page, you can set the **Selection of Packets Replication Feature**.

### ISDN Parameters

This page displays the **ISDN Protocol, Codec Mode, 5A System** and **Local Numbers 1 and 2.**

### Ethernet Parameters

This page provides the following communication information:

- **IP Addressing Mode**
- **IP Address**
- **Subnet Mask**
- **Gateway**
- **DNS Address**
- **IP Network Quality**

### Audio

This page shows the **Input Level, Input Impedance, Output Level,** Level on Tx and Rx Left and Right, AES Sampling Rate and **AES Syncho.**

### Coding

On this page, you can set several parameters related to coding.

### Misc

The page displays miscellaneous information such the **Auto Redial Codec 1 and 2, Redial Attempts** and **Time before Dial**.

There is also a button available that can be used to enable echo. By default, the echo is enabled when a unexpected response is detected by the system.

### Reset

This page contains the **Reboot** button. There is also a page button to the **Debug** subpage, which contains additional miscellaneous parameters.

### Web Interface

On this page, you can view the web interface of the device. However, the client machine has to be able to access the device. Otherwise, it will not be possible to open the web interface.
