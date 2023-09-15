---
uid: Connector_help_Digigram_Iqoya_Link
---

# Digigram Iqoya Link

The Digigram Iqoya Link is a two-channel IP audio codec for STL (Studio to Transmitter Links) or SSL (Studio to Studio) applications.

### Version Info

| **Range** | **Description**                                                                                                                                                           | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                                                                                                                           | No                  | Yes                     |
| 1.1.0.x \[Main\] | New firmware (v03.08) based on v1.0.0.5; changed display key of the following tables: Receive Source Table, Receive Source Metrics Table and Send Destination URLs Table. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | v02.40                      |
| 1.1.0.x          | v03.08                      |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: *161*
- **Get community string**: *public*
- **Set community string**: *private*
- **Timeout of a single command (ms)**: *2000*

## Usage

### General

This page contains general parameters, firmware update data, etc.

Via the **Service** page button, you can access the Service table, which contains a summary overview of the services.

### Encoder

This page contains the **Send** table. Source and Destination tables are available via page buttons.

### Decoder

This page contains the **Receive** table. Source tables are available via page buttons.

### Web interface

This page displays the web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

Traps are implemented in the connector. When a trap enters, the corresponding parameter will be updated immediately (single parameter or table parameter).

In order to get the best performance with this connector, we recommend to set the **Timeout of a single command** to 2000 (ms) in the element configuration.
