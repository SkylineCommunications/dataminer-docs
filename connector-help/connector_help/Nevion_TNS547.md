---
uid: Connector_help_Nevion_TNS547
---

# Nevion TNS547

The TNS546 is part of the Nevion nSure product line, which provides 24/7 monitoring and advanced analysis of high-quality video content delivery. It can simultaneously monitor up to 24 MPEG-2 transport streams, although with an overall limit to the aggregate bit rate of the streams. It strongly resembles the CP545 with respect to monitoring functions, but features up to eight separate ASI inputs. In addition, it provides Ethernet inputs that will allow the monitoring of up to 16 IP-encapsulated MPEG transport streams.

## About

### Version Info

| **Range**            | **Key Features**                     | **Based on** | **System Impact** |
|----------------------|--------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Serial and SNMP connection for traps | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.8.0                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Connection - Main

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600*.
  - **Databits**: Databits specified in the manual of the device, e.g. *7*.
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1*.
  - **Parity**: Parity specified in the manual of the device, e.g. *No*.
  - **FlowControl**: FlowControl specified in the manual of the device, e.g. *No*.

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *80*).

#### SNMP Connection - 2

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *161*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

When you have created the element, set up the device **credentials** on the General page.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

On the **Polling** page, you can define which parameter groups to poll and at what frequency.
