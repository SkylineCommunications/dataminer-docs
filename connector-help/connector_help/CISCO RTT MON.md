---
uid: Connector_help_CISCO_RTT_MON
---

# Cisco RTT Mon

The Cisco RTT Mon is used for measuring delay, jitter, and packet loss on the data network.

## About

This driver uses **SNMP** polling to communicate with the device.

### Ranges of the driver

| **Driver Range**    | **Description** | **DCF Integration** | **Cassandra Compliant** |
|---------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x\[SLC Main\] | Initial Version | No                  | False                   |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and Configuration

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device. By default 161.
- **Get community string**: The community string used when reading values from the device. (default: public)
- **Set community string**: The community string used when setting values on the device. (default: private)

## Usage

### General

This page displays a table of **IP SLA Entries** and a table with the **Latest RTT Operations**. This information is read-only.

### Jitter Statistics

This page presents a table with **Jitter Statistics**.

### ICMP Jitter Statistics

This page presents a table with **ICMP** **Jitter Statistics**.
