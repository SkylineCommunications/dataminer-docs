---
uid: Connector_help_APC_Netbotz_570
---

# APC Netbotz 570

APC NetBotz is an active monitoring solution designed to protect against physical threats, environmental or human, that can cause disruption or downtime in IT infrastructure.

## About

**SNMP polling** is used to retrieve sensor information. **SNMP traps** for enclosures and all sensors will be processed when this is enabled on the device.

This is a read-only connector, so it is not possible to configure the device with it.

### Version Info

| **Range**     | **Description**                   | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-----------------------------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version.                  | No                  | Yes                     |
| 1.0.1.x              | Display keys added to the tables. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 4.5.0                       |
| 1.0.1.x          | 4.5.0                       |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.

## Usage

### Enclosures & Ports

These pages display all attached **enclosures** and **ports** of the system with their name, status and error status.

### Numeric Sensors

This page contains multiple tables that display a specific type of numeric sensors:

- **Temperature**
- **Humidity**
- **Dew point**
- **Audio**
- **Air Flow**
- **Amp Detection**

Numeric sensors that do not fit in one of these specific type tables will be in the **Other Numeric Sensor Table**.

### State Sensors

This page contains multiple tables that display a specific type of state sensors:

- **Dry Contact**
- **Door Switch**
- **Camera Motion**

State sensors that do not fit in one of these specific type tables will be in the **Other State Sensor Table**.

### Web Interface

This page displays the web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

The polling of each section can be disabled or enabled.
