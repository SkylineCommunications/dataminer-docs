---
uid: Connector_help_Moxa_NPort_6610
---

# Moxa Nport 6610

The NPortr 6600 series of secure device servers is the right choice for applications that use large numbers of serial devices packed into a small space.

For more information, refer to <http://www.moxa.com/product/nport_6650.htm>.

## About

This connector is intended to get and set information in the device via an element in a DataMiner System, using SNMP commands.

### Version Info

| **Range**            | **Key Features**                                                     | **Based on** | **System Impact** |
|----------------------|----------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[obsolete\] | Driver range supporting only SNMPv1.                                 | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Removed time synchronization functionality.                          | \-           | \-                |
| 2.0.0.x              | Branched from 1.0.0.x: customer-specific branch for NetVue Solution. | 1.0.0.x      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unknown                |
| 1.0.1.x   | Unknown                |
| 2.0.0.x   | Unknown                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |
| 1.0.1.x   | No                  | No                      | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.
- **Device address**: Not used.

SNMPv1 & SNMPv2 Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

SNMPv3 Settings:

- **Port number**: The port of the connected device, by default *161*.
- **User name**: The user name in order to validate operations on the device.
- **Authentication password**: The authentication password in order to validate operations on the device.
- **Encryption password**: The encryption password used in order to encrypt/decrypt the device communication.
- **Authentication algorithm**: The authentication algorithm.
- **Encryption algorithm**: The encryption algorithm.

### Web Interface

The web interface is only accessible when the client machine has network access to the product

## Usage

The element created using this connector consists of the data pages detailed below.

### Overview

This page displays general information about the device.

### Basic Settings

On this page, you can configure the **Server** and **Time Settings**.

### Network Settings - Basic

On this page, you can set the **IPv4** and **IPv6** settings as well as the **LAN1** **Speed**.

### Network Settings - Advanced

On this page, you can set the **Routing Protocol** configuration.

### Network Settings - Module Redundancy

On this page, you can set the type of **Redundancy Protocol** and its settings.

### Network Settings - Module GSM/GPRS

The settings on this page apply to NPort 6000 servers that have the **NM-GPRS/GSM** module installed.

### Network Settings - Module Modem

The settings on this page apply to NPort 6000 servers that have the **NM-Modem** module installed.

### Serial Port Settings - Operation Modes

Each serial port on the NPort 6000 can be configured independently. To configure the operation mode and settings for a port, change the protocol in the **Port Application** column and then go to the corresponding protocol page button below the table to set the related settings.

### Serial Port Settings - Communication Param

The serial parameters for each serial port on the NPort 6000 should match the parameters used by the connected serial device. You may need to refer to the user manual of your serial device to determine the appropriate serial communication parameters.

### Serial Port Settings - Data Buffering/Log

The NPort 6000 supports port buffering to prevent the loss of serial data when the Ethernet connection is down. This can be configured using the **Data Buffering Port Table**.

### Serial Port Settings - Modem Settings

On this page, you can find the modem settings that are used for the Dial In/Out modes.

### Serial Port Settings - Cipher Settings

On this page, you can select the cipher priority for **SSL** and **SSH** to build secure connections.

### Serial Port Settings - Welcome Message

This page allows you to enable and specify a **Welcome Message** to greet dial-in or terminal users.

### Sys Mgmt - Misc Network

Several settings can be configured on this page:

- **Accessible IP List**: Allows you restrict network access to the NPort 6000.
- **SNMP Agent**: Allows you to enable the SNMP Agent function.
- **DDNS**: Allows you to configure the NPort 6000 to enable a remote server to access it using its domain name instead of its IP address.
- **Host Table**: Can be used to simplify IP address entry on the NPort 6000 console by assigning a host name to a host IP address.
- **Route table**: Allows you to configure how the NPort 6000 will connect to an outside network.
- **User Table**: Can be used to authenticate users for terminal or reverse terminal access.
- **Authentication Server**: To be used if a RADIUS server is used for user authentication.
- **System Log Settings**: Allow the administrator to customize which network events are logged by the NPort 6000.
- **Remote Log Server**: Allows you to configure the remote log server.

### Sys Mgmt - Auto Warning

Several settings can be configured on this page:

- On the **Event Settings** subpage, you can configure how administrators are notified of certain system, network and configuration events.
- On the **Serial Event Settings** subpage, you can configure how administrators are notified of each serial port's **DCD** and **DSR** changes.
- The **Email Alert settings** allow you to configure how email warnings are sent for system and serial port events.
- **SNMP Trap** is used to indicate the IP address to receive SNMP traps.
- Up to four phone numbers can be specified that will receive **SMS Alerts**.

### Sys Mgmt - Maintenance

This page contains different NPort 6000 configuration console options (**HTTP**, **HTTPS**, **Telnet**, **SSH**) that can be enabled or disabled. It also contains the option **Load Factory Default**, which will reset all the settings of the device to the factory default values.

### Sys Mon - Serial Status - Connections / Cipher

This page allows you to monitor cipher usage and the connection status of each serial port.

### Sys Mon - Serial Status - Port Status

On this page, you can view the current status of each serial port.

### Sys Mon - Serial Status - Error Count

On this page, you can view the error count for each serial port.

### Sys Mon - Serial Status - Port Settings

On this page, you can view a summary of the settings for each serial port.

### Sys Mon - System Status - Dout State

"Dout State" refers to the relay output status. With the **Auto Warning** settings, you can configure this status to change when certain system events occur.

### Sys Mon - System Status - Network Mod

On this page, you can check the information and status of the Network Module inserted in the NPort 6000.

### Sys Mon - Bitrate

This page provides information about the **Rx** and **Tx Bitrate** on all NPort 6000 serial ports.

### Save Configuration / Restart

Click **Save** to save the submitted configuration changes to the NPort 6000's flash memory. Click **Restart** to restart the NPort 6000. Make sure that you save all your configuration changes before you restart the system, as otherwise the changes will be lost.

### Web Interface

This page provides access to the configuration web page of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
