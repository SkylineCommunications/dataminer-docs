---
uid: Connector_help_Dell_iDRAC
---

# Dell iDRAC

The **Dell iDRAC** controller protocol communicates with an external card on any Dell PowerEdge device, and allows the user to remotely reboot and monitor the server in the case of a shutdown.

## About

This connector communicates using SNMP v3. It can be used to monitor and trend all status information and readings from the **Dell iDRAC**.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.30.30.30                  |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Username**: The SNMPv3 username.
- **Security level**: The SNMPv3 security level.
- **Authentication type**: The SNMPv3 authentication type.
- **Authentication password**: The SNMPv3 authentication password.
- **Privacy type**: The SNMPv3 privacy type.
- **Privacy password**: The SNMPv3 privacy password.

## Usage

### System

This page displays the **System Model Name**, **System Service Tag**, **System OS Version**, **Global System Status**, **Global Storage Status**, **System Power State** and **System Power Up Time**.

There are also three page buttons:

- **System Info**: Displays additional parameters of the Dell iDRAC.
- **System State**: Displays a table with all the statuses of the system that can be monitored.
- **RAC**: Displays additional information on the remote access card.

### Chassis Info

This page contains the chassis information. Other tables will reference to the chassis entries on this page, including the **Power Supply**, **Cooling Device**, **Temperature Probe**, **Processor Device**, **Processor Device Status**, **Memory Device**, **PCI Device**, **Network Device** and **System Slot Table**.

### PSU

On this page, the **Power Supply Table** displays all PSU slots per chassis. You can apply trending and monitoring on the readings in the table. The voltages, wattages and statuses in the table are polled frequently.

### Thermal Info

This page contains the following tables:

- **Cooling Device Table**: Displays the fan statuses and readings.
- **Temperature Probe Table**: Displays the measurements and statuses of the temperatures for multiple sections per chassis.

### Device Info

On this page, you can find all settings, readings and status information for the processors in the **Processor Device Table** and **Processor Device Status Table**.

Additional readings and status information can be found in the **Memory**, **PCI** and **Network Device Table**.

### Modular Slots

This page contains the **System Slot Table**. This table will only be polled if the Dell iDRAC is in a modular state. This state is displayed by the **Chassis Service Tag** parameter on the **Chassis Info** page.

### RAID

On this page, you can find settings, readings and status information in the **Controller Table**, **Enclosure Table**, **Physical Disk Table** and **Battery Table**.

All information on this page is available for alarm monitoring and trending

### Storage Mgmt Logical Devices

On this page, the **Virtual Disk Table** contains all settings and status information of the virtual disks of the Dell iDRAC.

### Web Interface

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

### Supported and non-supported selections

AES and DES encryption cannot be selected if the authentication method is set to *None*.

There is a special restriction related to an authentication type of *None*: if the authentication type is *None*, then the privacy type must also be *None*. Also note that no restriction applies for the reverse: if privacy type is *None*, authentication type can either be a value other than *None* or the value *None*.

The table below lists the supported and non-supported selections for authentication and privacy.

#### SNMP Authentication/Privacy matrix Table 1.

