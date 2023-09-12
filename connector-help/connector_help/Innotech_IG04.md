---
uid: Connector_help_Innotech_IG04
---

# Innotech IG04

This connector can be used to communicate with an Innotech IG04 weather station device. The BACnet/IP protocol is used to communicate with the device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.6.75                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

The **Device Address** parameter on the **General** page must be filled with the IP address and UDP port of the device, in the format \<IP address\>:\<port\> (e.g. *192.168.1.10:47808*).

Once this parameter has been filled in correctly, the element will start polling the device.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The **General** page displays configuration parameters like the **Device Address**, **Voltage**, etc.

The **Status** page displays the weather parameters, such as **Temperature**, **Wind**, **Pressure**, etc.
