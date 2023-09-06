---
uid: Connector_help_Harris_Intraplex_IP_Link_100
---

# Harris Intraplex IP Link 100

The Intraplex IP Link offers an array of audio coding options along with IPConnect technology for data tunneling,the IP Link codecs are suitable for use in Studio-to-Transmitter Links (STLs) as well as audio contribution and distribution networks.

Support for IP multicast and multiple unicast streams enables one encoder to feed multiple decoders.

Incorporates three IP Interfaces that can be used for streaming and management.

### Version Info

| **Range**          | **Key Features**                      | **Based on** | **System Impact**                             |
|--------------------|---------------------------------------|--------------|-----------------------------------------------|
| 1.0.0.x            | Initial version                       | \-           | \-                                            |
| 1.1.0 \[SLC Main\] | Implemented support for new firmware. | \-           | New implementation based on updated SNMP MIBs |

### Product Info

| **Range** | **Supported Firmware**       |
|-----------|------------------------------|
| 1.0.0.x   | \-                           |
| 1.1.0.x   | Software V3.2.0Firmware V2.6 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection- Main

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**:

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

This connector uses SNMP to communicate with the device.

It contains the following pages with functionality described on the parameters.

**General**

**Revision**

**Alarm Log**

**System**

**Network**

**Channel**

**RTP Streams**

**HTTP Streams**

**Redundancy**

**SIP**

**Traps**
