---
uid: Connector_help_Leitch_Panacea_16x16_SNMP
---

# Leitch Panacea 16x16 SNMP

This connector monitors and controls the **Leitch Panacea 16x16 SNMP** equipment. With this connector, you can monitor the existing matrix connections and the status of each input/output, and also alter the existing connections, lock the outputs and label the inputs/outputs.

For short-term monitoring, the protocol polls the status of the inputs and the outputs every 10 seconds; for medium to long-term monitoring, the protocol polls every hour.

## About

The protocol uses **SNMP** to poll and control the current matrix connections, the physical state of the inputs/outputs, the labels assigned to the inputs/outputs, and the lock status of the outputs.

### Version Info

| **Range** | **Description**         | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version, SNMPv1 | No                  | Yes                     |
| 1.0.1.x          | SNMPv2                  | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                                                                |
|------------------|--------------------------------------------------------------------------------------------|
| 1.0.0.x/2.0.0.x  | Unknown. The protocol conforms to the initial MIB version of the device (date 2005/02/23). |

## Installation and Configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### Matrix Page

On this page, the following items can be monitored:

- The status of the input and output signals, in the **Physical Input & Output Matrix** tables.

- The PSU statuses, in the **PSU Table.**

- The existing connections in the **Matrix 16x16:**

- Connections can also be configured.
  - The labels of the inputs/outputs can be changed.
  - The lock status of the outputs can be changed.

### Ethernet Page

On this page, you can alter the **Device IP Address** and its **IP Mask.**
