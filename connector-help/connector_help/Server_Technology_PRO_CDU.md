---
uid: Connector_help_Server_Technology_PRO_CDU
---

# Server Technology PRO CDU

The Server Technology Sentry family CDU is a cabinet power distribution unit that enables network access for remote power management in data centers. It can be used to monitor and control cabinet power remotely. It can also monitor the input current and the environment.

The Server Technology PRO CDU connector is used to monitor and control the power, current and voltage of Sentry Switched PDUs. It also monitors the environment.

## About

The connector (periodically) collects information from the device and sets changes on the device via SNMP. The connector implements and processes traps. When traps are received from the device, the changed parameters are updated with the new values from the traps.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[Obsolete\] | Initial version | No                  | Yes                     |
| 1.0.1.x \[SLC Main\] | Naming applied  | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 8.0i                        |
| 1.0.1.x          | 8.0i                        |

## Installation and configuration

### Creation

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains general device information such as the name, IP address, location, firmware version, etc.

### Units

This page contains the configuration, status and event notification method information of power distribution units.

### Input Cords

This page contains configuration, monitoring and event configuration information of the input cords. It also contains information on active power, apparent power and power factor hysteresis, and allows you to apply changes to these parameters.

### Lines

This page contains configuration, monitoring and event configuration information of the line current.

### Phases

This page displays information on the phase current, voltage, power and energy.

### Over-Current Protectors

This page contains the over-current protection methods and current specifications for each branch circuit.

### Branches

This page contains configuration, monitoring and event configuration information of the branch circuits.

### Outlets

This page contains configuration, monitoring and event configuration information of the outlets.

### Temperature Sensors

This page contains configuration, monitoring and event configuration information of the temperature sensors.

### Humidity Sensors

This page contains configuration, monitoring and event configuration information of the humidity sensors.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
