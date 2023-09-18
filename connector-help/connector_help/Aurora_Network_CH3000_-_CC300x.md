---
uid: Connector_help_Aurora_Network_CH3000_-_CC300x
---

# Aurora Network CH3000 - CC300x

## About

CC300x is a communication controller module.

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
- **Device address**: The device address.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device. (default: public)
- **Set community string**: The community string used when setting values on the device. (default: private)

## Usage

### General

Contains general info and settings.

### Alarms

Contains alarm info and settings.

### Alarms Configuration

Contains configuration parameters used to determine alarming conditions.

### States

Provides status information about the comuntication controller module.


