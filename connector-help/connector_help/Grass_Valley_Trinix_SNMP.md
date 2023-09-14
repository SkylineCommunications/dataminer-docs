---
uid: Connector_help_Grass_Valley_Trinix_SNMP
---

# Grass Valley Trinix SNMP

The Trinix device offers standard and high-quality routing of digital video services.

## About

This connector uses an SNMP connection to monitor the power, fan, and signal status of the Trinix device.

Traps can be received by the connector for asynchronous status updates from the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |
| 1.0.1.x          | Added DCF       | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x 1.0.1.x  | 07                          |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection to communicate with the Trinix device, and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The IP of the Trinix device.
- **IP port:** The IP port of the destination, by default *161*.

## Usage

### General

This page displays system information such as the **System Name**, **Description** and **Frame Type**, and network information such as the **IP Address.** You can also see the immediate status of the **Input Signal, Output Signal,** **Board,** **Frame Temperature** and **Controller**.

### PSU

This page displays information for the **PSUs,** providing an overall status overview of the power supplies.

### Fans

On this page, you can see the status for individual fans.

### Reference Signals

This page displays the status of the various reference signals in the **Reference Signals** table.

### Web Interface

This page displays the web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

The **1.0.1.x** connector range of the **Grass Valley Trinix** protocol supports the usage of DCF and can only be used on a DMA with **8.5.8.5** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).
