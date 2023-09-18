---
uid: Connector_help_Viaccess_CAS
---

# Viaccess CAS

This connector can be used to monitor the Viaccess CAS, a conditional access system that can be used in digital video broadcasting.

## About

This connector can only be used for monitoring purposes. It only performs SNMP Gets and receives and processes traps.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page shows general information about the **ECMG**, **EMMI**, **EXMC** and **SIM**.

With the **Polling Time** parameter, you can configure the polling time of the parameters.

The page also contains page buttons that provide access to additional information:

- **ECMG-SCH**: This subpage displays **general** **information** and **errors**.
- **ECMG-SCS**: This subpage displays **general** **information** and **errors.**
- **ECMG-CS**: This subpage displays **general** **information** and **errors.**
- **SIM ECMG**: This subpage contains a table with **general** **information** and **errors**.
- **SIM ECMG-C**: This subpage contains a table with **general** **information** and the **errors** and **delays** for each **channel**.
- **SIM ECMG-S**: This subpage contains a table with **general** **information** and the **errors** for each **stream.**
