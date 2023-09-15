---
uid: Connector_help_Aurora_Network_CX3001_-_AT3554
---

# Aurora Network CX3001 - AT3554

The Aurora Network AT3554 is used by DVEs created by the Aurora Network CX3001 connector. A DVE is created for each available AT3554 analog transmitter.

## About

The Dynamic Virtual Element has four pages:

- The **General** page contains general information about the specific AT3554 slot.
- The **Alarms** page contains alarm information.
- The **Alarms Configuration** page contains an alarm configuration table.
- The **Configuration** page contains a configuration table specific to the AT3554 slot.

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 2.0.1.x          | Unknown                     |

## Installation and configuration

### Creation

This connector is used by DVE child elements that are **automatically created** by the parent connector [Aurora Network CX3001](xref:Connector_help_Aurora_Network_CX3001), from version 2.0.1.x onwards. For each AT3554 transmitter found in the system, a virtual element will be created.

## Usage

### General

This page contains general information about the specific AT3554 transmitter, along with important information like the temperature, fan speed, etc.

### Alarms

This page displays the status of each configured alarm.

### Alarms Configuration

On this page, you can modify the alarm configuration in the alarm configuration table.

### Configuration

This page contains a configuration table for the DVE.
