---
uid: Connector_help_Axon_Neuron_NPG3200
---

# Axon Neuron NPG3200

The NPG3200 is the main Neuron processing board. It is a multi-channel A/V-over-IP transceiver developed for use within low-latency and high-bandwidth Ethernet IP networks. It uses all modern encapsulation standards like ST2022-6 and ST2110, enabling the NPG3200 to process up to 32 3Gb/s SDI signals and transport them over redundant dual 25GbE and 100GbE links. In addition, audio processing is also part of the Neuron package with standards like Dante, AES67, and many more.

## About

### Version Info

| **Range**            | **Key Features**                                | **Based on** | **System Impact** |
|----------------------|-------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                                | \-           | \-                |
| 1.0.1.x \[SLC Main\] | \- DCF Integration. - Support for firmware 5.x. | 1.0.0.3      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.8.27                 |
| 1.0.1.x   | 2.8.27 - 5.x           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: 2072

## How to Use

The connector does not have a polling timer. It only polls the data at element startup; however, there is also a button available that allows you to trigger the polling manually.

After element startup, the connector can also receive events (unsolicited messages).
