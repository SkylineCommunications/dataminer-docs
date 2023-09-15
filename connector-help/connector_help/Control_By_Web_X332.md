---
uid: Connector_help_Control_By_Web_X332
---

# Control By Web X332

## About

X332 is multi-function web-enabled module for control and monitoring.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | False                   |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.

SNMP Manager

The user must access the web interface setup of the device, and enable the SNMP.

## Usage

### General

This is the default page that contains several Standard parameters including "Description", "Object ID", "Up Time" and "Name".

### Inputs

The "Inputs"page presents all the eighteen Inputs (read-only) available in the device.

### Sensors

The "Sensors"page presents the four Sensors (read-only) available in the device.

### Relays

The "Relays" page presents all the sixteen Relay parameters (read/write) available in the device.

### Analogs

The "Analogs" page presents the four Analog parameters (read-only) available in the device.

### Counters

The "Counters" page presents the two Counters (read-only) available in the device.

### Web Interface

The device's Web Interface page is available on the protocol, and the user has to fill the credentials in order to access it.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
