---
uid: Connector_help_Evertz_5600ACO2
---

# Evertz 5600ACO2

The Evertz 5600ACO2 is a dual automatic changeover system with 2 power supplies. This connector communicates with that system via SNMP requests.

## About

### Version Info

| **Range**            | **Key Features**                                                     | **Based on** | **System Impact**                    |
|----------------------|----------------------------------------------------------------------|--------------|--------------------------------------|
| 1.0.0.x \[Obsolete\] | Initial range.                                                       | \-           | \-                                   |
| 1.0.1.x \[SLC Main\] | Improvements to the keys to correctly display which PSU failed, etc. | 1.0.0.1      | Loss of trend and alarm information. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.1.x   | 2.2 build 2            |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection - Events

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: 161).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

## How to use

The connector communicates with the device via SNMP calls.

It shows general parameters on the **General** page, such as the **Firmware Version**. Any alarms or issues will be shown in tables on the various pages, which are ordered per type: **GPIO**, **Analog Faults**, **Source Signal Faults**, **Output Faults**, and **Power Faults**.

For example, a fault in the power supply will be shown on the **Power Faults** page in the **Fault Power Supply** table.

## Notes

The device cannot handle sending many results simultaneously, so do not use multipleGetBulk or multipleGetNext, as this will lead to issues.
