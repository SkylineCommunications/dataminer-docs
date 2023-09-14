---
uid: Connector_help_Spectracom_Epsilon_Clock_EC22S
---

# Spectracom Epsilon GPS Clock EC22S

This connector is used to monitor and control a **Spectracom Epsilon GPS Clock EC22S**.

## About

Epsilon Clocks provide accurate and stable time and frequency signals for your high-performance synchronization application. The unit's architecture is well-suited to transmitter synchronization of digital broadcast signals (DVB-T/T2, T-DMB, DAB or DRM) in Single Frequency Network (SFN) modes: the high port density allows the simultaneous synchronization of many emitters on the same site.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | debian40                    |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *172.32.65.38.*

SNMP Settings:

- **Port number**: The UDP port, by default *161.*
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string:** The community string used when setting values on the device, by default *private*.

## Usage

### Base Unit

This page displays status and control parameters for the base unit.

### Clock

This page displays status parameters for the **Left Clock** and **Right Clock**. At the bottom of the page, **Clock Control** parameters can be set.
