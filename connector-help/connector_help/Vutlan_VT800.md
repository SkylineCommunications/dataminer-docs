---
uid: Connector_help_Vutlan_VT800
---

# Vutlan VT800

The Vutlan VT800 unit is used to control temperature, humidity, voltage, leakage, smoke, airflow, and doors in server rooms, and to monitor facilities. It can connect up to 100 elements, one GSM modem, USB-Cam and 16 dry contacts.

## About

The device has built-in servers and agents like HTTP, HTTPS, SNMP v1, 2c, 3, SMTP, Radius, Syslog, FTP, DHCP, and Watchdog.

This connector uses an **SNMP** connection to monitor the device.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.3.6.1.4.1.8072.3.2.10     |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, *172.16.26.10*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

The connector consists of a number of pages, divided into groups.

### Information page

This page displays general information about the device.

### Unit pages

This group consists of four pages:

- **Unit Modules**: Information regarding the modules contained in the device.
- **Unit Groups**: Information regarding unit groups.
- **Unit Elements**: More detailed information about individual elements.
- **Unit Logics**: Information about the logic of certain elements.

### Notifiers pages

This group consist of three pages:

- **Notifiers Mailers**: Information about the mailers list.
- **Notifiers Traps**: Information about the trap table.
- **Notifiers SMS**: Information about the SMS list.

### Virtual Device pages

This group consists of four pages:

- **Virtual Device Timers**: Contains a table listing virtual timers.
- **Virtual Device Pings**: Contains a table listing virtual device pings.
- **Virtual Device Triggers**: Contains a table listing virtual device triggers.
- **Virtual Device SNMP Gets**: Contains a table listing virtual SNMP Gets.

### Hardware Devices Cameras page

This page displays information about the cameras detected in the system.

### Internal Sensors pages

This group consists of three pages:

- **Internal Sensors Discretes**: Information about the internal sensor discretes.
- **Internal Sensors Analogs**: Information about the internal sensor analogs.
- **Internal Sensors Outlets**: Information about the internal sensor outlets.

### CAN Sensors pages

This group consists of three pages:

- **CAN Sensors Discretes**: Information about the CAN sensor discretes.
- **CAN Sensors Analogs**: Information about the CAN sensor analogs.
- **CAN Sensors Outlets**: Information about the CAN sensor outlets.

### Rs Sensors pages

This group consists of three pages:

- **Rs Sensors Discretes**: Information about the Rs sensor discretes.
- **Rs Sensors Analogs**: Information about the Rs sensor analogs.
- **Rs Sensors Outlets**: Information about the Rs sensor outlets.

### Web Interface page

This page displays the webpage of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
