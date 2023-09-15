---
uid: Connector_help_DataProbe_iPIO
---

# DataProbe iPIO

The **DataProbe iPIO** is a network-attached, web-enabled digital input and output device. Multiple **iPIO** devices can communicate with each other to transport I/O information across the network. Each iPIO has controllable form-C relays and digital inputs.

## About

This connector uses **SNMP** to retrieve information from the device. The **status** in the **Input** and **Relay** tables is based on **traps and SNMP polling.**
The connector also allows you to access the **web interface** of the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.00.82                     |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: This connector has no device address.

SNMP Settings:

- **Port number**: The port of the connected device, default *161*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General

This page displays general information and settings, including the **Location ID**, the **Auto Update** interval and the **Reboot** option.

The following page buttons provide access to additional information:

- **SNMP**: Provides an overview of the SNMP control parameters, such as **Read Community**, **Write Community**, **Send Comm Status Changed Trap**, etc.
- **Users**: Allows you to set the **User Name** and **User Password**, and the **Admin Name** and **Admin Password**.
- **Network**: Provides access to network connection settings for communication between the different **iPIO** Modules. This includes parameters such as the **IP Mode**, **IP Address**, **Subnet Mask**, **Gateway**, etc.
- **Email**: Provides access to email notification settings, including **SMTP Server**, **Send Input Changed**, etc.

### Inputs

The page displays the **Input Table**, which contains information and settings related to the system's inputs, including the **Input Name**, **Input Open Name** and **Input Status**.

### Relays

This page contains information about the relays, including the **Relay Name**, **Relay Closed Name** and **Relay Status**.

### Remotes

This page displays the **Remote Table** and the **Relay Map Table**:

- The **Remote Table** contains the remote **iPIO** devices that are connected to this device. It includes parameters such as **Remote Name** and **Remote Use AES.** Via a **right-click menu**, remote devices can be added or deleted.
- The **Relay Map Table** contains the list of **Remote Relays** that will be mapped to the local LEDs. It includes parameters such as **Remote**, **Relay** and **Pulse Width**.

As it can take a while before the **Add Remote** or **Remove Remote** command is processed by the device, there is also a **Refresh** button to force an immediate update.

### Traps

This page contains the **Traps** table, as well as parameters that allow you to configure this table.

The **status** in the **Input** and **Relay** tables is also updated with status information from the **traps**.

### Web Interface

This page provides direct access to the web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
