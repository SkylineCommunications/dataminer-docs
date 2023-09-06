---
uid: Connector_help_Prodys_Quantum
---

# Prodys Quantum

Prodys Quantum is an IP audio codec that inherits IP technology from the Prodys Ikusnet Video Codec Family and the ProntoNet Audio Codec Family.

The Prodys Quantum main application is designed to receive, decode, and store audio streams from remote Quantum Portable units. It is also capable of encoding two stereo audio channels back to the remote portable Quantum codec.

## About

### Version

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | w2.3.3                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** |
|-----------|---------------------|-------------------------|-----------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    |

## Configuration

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) version 2 connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

On the **General** page, you can find system information. A page button is also available to the **System OR** subpage, which contains System OR information.

The **Configuration** page contains information related to the configuration.

On the **Program** page, you can find information related to the program, including the Program Encoders table and Program Decoders table.

The **Talkback** page displays the Talkback Line table and algorithm (encoder and decoder) parameters.

The **Ethernet** page contains the Ethernet table.
