---
uid: Connector_help_MediaKind_T1_Series
---

# MediaKind T1 Series

The T1 platform is a 2RU chassis that significantly reduces the rack and power consumption, processing more channels with a lower cost of ownership. It is equipped with 9 independent slots, dual fans, 2 hot swappable power supply modules and 2 hot swappable network switches. Each of the 9 slots can be fitted with high-performance Intel Xeon E3 processors designed to support advanced video processing, like Ericsson MediaFirst Video Processing Encoding Live.

## About

This driver displays the available chassis information. It uses an SNMP and HTTP API connection to get information about nodes, servers, power supplies, fans and the general chassis status.

### Version Info

| **Range**            | **Key Features**                     | **Based on** | **System Impact** |
|----------------------|--------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | SNMPv2 connectionHTTP API connection | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *161*).
- **Bus address**: The bus address of the device (default: *ByPassProxy*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

#### HTTP httpConnection Connection

This driver uses a serial connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

On the **API** **Setting** page, specify the username and password to connect to the API.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created using this driver has the following data pages:

- **Switch General**: Provides general information about switch parameters, such as System Description, System Name, Location and Contact.

- **Switch Interfaces**: Contains the Switch Interfaces Table, which includes parameters such as Description, Type, Bitrate, Operational Status, Speed and Mtu.

- **Nodes And Payloads**: Contains the Payloads table, which displays information regarding all Payloads, Nodes and the Nodes Network. Contains page buttons to the following subpages:

- **Monitored Sensors**: Displays information on sensors by node, such as Monitored, Unit, Aggregation and more.
  - **Nodes Alarms**: Displays a table with detailed information on alarms present on each node.
  - **Nodes**: Displays a table with detailed information on each node, such as the Node Type, Netmask, IP Address and Netmask.

- **Platform**: Displays a table with information on the platform alarms.

- **Power Supply**: Displays the status of the power supplies. Also contains the **Execute Power Command** button, which can be used to enable or disable power supplies.

- **Fan**: Contains the Fans Alarms Table, which contains information on the alarms per fan.

- **API Settings**: Allows you to specify the API login credentials and displays the status of the API connection.
