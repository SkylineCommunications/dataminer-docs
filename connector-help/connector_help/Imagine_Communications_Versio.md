---
uid: Connector_help_Imagine_Communications_Versio
---

# Imagine Communications Versio

The **Imagine Communications Versio** is an integrated playout.

## About

This connector uses **SNMP** polling to obtain data from the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 6.1.7601.17514              |

## Intallation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *Private*.

## Usage

### General

On this page, general information related to the device is displayed (e.g. **Server Product Name**, **Server System Up Time**, ...) together with some monitoring data (e.g. **Available Physical Memory**, **Available Virtual Memory**, ...).

### Network

This page displays the **Network Table**, which contains an entry for every network adapter used.

### Alarms

On this page, you can configure alarm thresholds together with SNMP traps.
