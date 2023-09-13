---
uid: Connector_help_SAF_Tehnika_Integra-W
---

# SAF Tehnika Integra-W

The Integra-W is a radio system designed specifically for wideband applications. Integra-W enables high Tx power, wide bandwidth and high modulation radio links.

The SAF Tehnika Integra-W SNMPv2/v3 driver controls and monitors this radio system.

## About

### Version Info

| **Range**            | **Key Features**            | **Based on** | **System Impact** |
|----------------------|-----------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version             | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Added serial/SSH connection | 1.0.0.6      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3.10.12-mux            |
| 1.0.1.x   | 3.10.12-mux            |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMPv2 main connection

This driver uses a Simple Network Management Protocol (SNMP) v2 connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMPv2 settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

#### SNMPv3 main connection

This driver uses a Simple Network Management Protocol (SNMP) v3 connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMPv3 Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Security Level and Protocol:** The security level used by the protocol, by default *authPriv*.
- **User Name**: The user name used to connect to the device. Make sure this user has **write access**, as otherwise no sets will be possible.
- **Authentication password**: The password of the given user.
- **Encryption password**: The encryption password used for the given user.
- **Authentication algorithm**: The type of algorithm used during authentication, by default *HMAC-SHA*.
- **Encryption algorithm**: The type of algorithm used for encryption, by default *AES128*.

#### Serial IP Connection

This driver also uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the data pages detailed below.

### General

This page displays information about the system and host, such as **System Description**, **System Up Time**, **System Name**, **Host System Uptime**, etc.

For the 1.0.1.x range, the **SSH** credentials need to be set on this page for the modem bandwidth and modulation sets and the loop back tests to work.

The **System Reboot** button on this page allows you to restart the system.

### Integra-W Pages

This section contains the following pages:

- **System**: This page displays information about the system, such as **CPU Temperature**, **PSU Voltage**, etc.
- **Radio**: This page contains information about the radio receiver and transmitter as well as the **Radio Ranges Table**.
- **Modem**: This page contains all modem-related parameters, such as **Modem Bandwidth**, **Signal Quality**, etc.
- **Ethernet**: This page contains the **Interface Status Table** and the **Interface Statistics Table**.
- **Configuration**: This page allows you to **execute** or **store** a new **configuration** and contains the **Net CFG IP** parameters.
- **Alarm**: This page displays the last time an alarm was changed and contains the **Alarm Table**.
- **Loop Back Test**: This page contains the buttons for the **Modem Loop Back** and **RF Loop Back** self tests. Before you run the loop back self tests, you need to fill in the corresponding **Time** parameters.

### Management Pages

This section contains the following pages:

- **Interfaces**: Displays the Number of Interfaces, Interface Table and Interface X Table.
- **IP Status**: This page contains the **IP Address Table**, **IP Address Prefix** and **Address Translation Table**. The page also contains page buttons that provide access to the **IP Route Tables**, **IP Net Tables** and **IP System Tables**.
- **ICMP**: This page contains the **ICMP Status Table** and **ICMP Message Status Table**.
- **TCP**: This page contains general TCP parameters, as well as the **TCP Connection Table** and **TCP Listener Table**.
- **UDP**: This page contains general UDP parameters, as well as the **UDP Table** and **UDP Endpoint Table**.
- **SNMP**: This page contains information about the **incoming** and **outgoing** **packets**.
- **SNMPv2**: This page contains information about the **security** and **user levels**.
- **Ethernet**: This page contains the **Ethernet Statistics Table** and the **Ethernet Statistics High Capacity Table**.
- **Media**: This page contains the **Media Independent Table**.
- **Memory/System**: This page contains statistics for both memory and system.
- **User**: This page contains the **User Security Model Table**.
- **View Based ACM**: This page contains the **View Based ACM Security To Group Table**, **View Based ACM Access Table** and **View Based ACM View Tree Family Table**.
