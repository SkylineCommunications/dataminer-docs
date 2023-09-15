---
uid: Connector_help_AdvancedDigital_ADV-6410
---

# AdvancedDigital ADV-6410

This connector monitors the activity of the AdvanceDigital ADV-6410 device.

## About

AdvanceDigital ADV-6410 is an integrated receiver/decoder (IRD). It provides operators with ideal solution for multi receiving, descrambling, remultiplexing and decoding operations.

### Version Info

| **Range** | **Description**                                | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version                                | No                  | Yes                     |
| 1.1.0.x          | New SNMP Tables and Layout due to new firmware | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 34PA2046                    |
| 1.1.0.x          | 34PA600A                    |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device. (default: public)
- **Set community string**: The community string used when setting values on the device. (default: private)

## Usage

### General

The General page has some **System** parameters and device parameters like **SNMP** and **MIB** version, **Inputs** and the **Outputs** . In the Configuration sub page it is possible to configure the **BISS** and the **Traps**. The Trap Events sub page displays the latest device events.

### Tuner

In this page it is possible to check the status and the configuration of the Tuner.

### Decoder (Not Available in 1.1.0.x)

In this page it is possible to check the status and the configuration of the Decoder.

### Web Interface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.


