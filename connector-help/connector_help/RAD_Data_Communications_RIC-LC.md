---
uid: Connector_help_RAD_Data_Communications_RIC-LC
---

# RAD Data Communications RIC-LC

This connector can be used to monitor RAD Data Communications RIC-LC Ethernet converters.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.03.01                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *161*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

### General

The General page displays general information about the device. Two subpages are available with tables related to the **SNMP Trap** destination configuration and **NTP** servers.

### Interfaces

The Interfaces page lists the device interfaces.

### Events

The Events page contains the Alarms and Events tables. The Events table displays events with the "event" state, while the Alarms table displays all events with a "warning", "minor", "major", or "critical" state.

### SNMP Traps

This connector will receive and process SNMP traps related to interfaces and events:

- **Interfaces**: The Interfaces table will be updated upon receipt of a linkUp or linkDown trap for the specified interface.
- **Events**: The Events or Alarms table will be updated upon receipt of an event trap.
