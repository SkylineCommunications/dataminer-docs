---
uid: Connector_help_Infinera_TNMS_-_NE
---

# Infinera TNMS - NE

The Infinera TNMS is a Transcend Network Management System (NMS) that can provide full end-to-end network and service management. This driver allows you to monitor all the ports and corresponding alarms for a specific network element.

## About

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.1.3                  |

## Configuration

### Connections

The elements using this driver are automatically created by the parent element [Infinera TNMS](xref:Connector_help_Infinera_TNMS).

## How to use

The element has several data pages:

- The **General** page displays the time which the last "keep alive" was received.
- The **Ports** page contains the Ports table.
- The **Alarms** page shows an overview of the active alarms.

**SNMP traps** are implemented in the driver to update the **Alarms table**.
