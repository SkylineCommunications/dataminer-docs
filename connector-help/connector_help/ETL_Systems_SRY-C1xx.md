---
uid: Connector_help_ETL_Systems_SRY-C1xx
---

# ETL Systems SRY-C1xx

The **ETL Systems SRY-C1xx** connector can be used to monitor information regarding the chassis and the attached modules.

## About

This protocol can be used to monitor the **ETL Systems SRY-C1xx** main controller and its attached modules. An SNMP connection is used in order to successfully retrieve the device's information.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and Configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Connection:

- **IP Address/host**: The polling IP of the device.

SNMP Settings:

- **Port Number**: The port of the connection device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.

## Usage

The ETL Systems SRY-C1xx protocol contains the following pages:

- **General**: Information related to the chassis (Communication Status, Software, Temperature, etc.).
- **Chassis**: The different **Voltage** and **Fan Speed** values of the chassis.
- **Modules**: Overview of all the modules attached to the chassis with the related information (Voltage, Current, Status, etc.).
- **Alarm Status**: Alarm information for the different **Fan Speeds***.*
- **Web Interface**: The web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
