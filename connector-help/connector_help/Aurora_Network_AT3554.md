---
uid: Connector_help_Aurora_Network_AT3554
---

# Aurora Network AT3554

The Aurora Network AT3554 is a DVE created by the Aurora Network CX3001 connector. It is created by each AT3554 analog transmitter available.

## About

The information displayed in the main element is delivered in four pages:

- The **General** page contains general information about the specific AT3554 slot.
- The **Alarms** page contains alarming information.
- The **Configuration** page contains configuration settings specific to the AT3554 slot.
- The **Alarms** **Configuration** page contains configuration settings specific to the AT3554 slot.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 2.0.0.x          | Initial Version | No                  | Yes                     |

## Installation and configuration

### Creation

This connector is automatically created by the Aurora CX3001 connector. For each AT3554 transmitter found in the system, a virtual element will be created.

### General

Contains general information about the specific AT3554 transmitter. Along with important information like temperature, fan speed, etc.

### Alarms

Contains alarming information, the status of each alarm, each alarm can modified in the parent element.

### Configuration

Contains configuration information.

### Alarms Configuration

Contains alarm configuration information
