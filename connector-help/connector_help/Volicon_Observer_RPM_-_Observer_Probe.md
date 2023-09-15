---
uid: Connector_help_Volicon_Observer_RPM_-_Observer_Probe
---

# Volicon Observer RPM - Observer Probe

This connector is developed for **Volicon Observer RPM** Video Monitor devices. It **receives traps** from the monitored device and displays them in a table. These traps contain information about the state of a specific service as reported by the probe.

## About

This is an **SNMP** connector, which processes received traps to update its parameters.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 5.0                         |

## Installation and configuration

### Creation

This connector is used by DVE child elements that are **automatically created** by the connector [Volicon Observer RPM](xref:Connector_help_Volicon_Observer_RPM), from version 2.0.0.2 onwards.

## Usage

The connector consists of two pages.

### Events

This page displays the **Events table**. All traps that are not cleared automatically will be stored in this table.

### Traps

This page displays the **Trap Overview** table, with information received in traps. Each entry in this table corresponds to a diferent **video channel.** Received traps will automatically update the state of the respective program. You can also manually set an alarm on each entry.
