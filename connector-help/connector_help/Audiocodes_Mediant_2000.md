---
uid: Connector_help_Audiocodes_Mediant_2000
---

# Audiocodes Mediant 2000

The AudioCodes Mediant 2000 Media Gateway is designed to provide connectivity between small-to-medium-sized enterprises and service providers' networks. Supporting up to 480 voice channels in a 1U platform, the Mediant 2000 offers performance in connecting legacy telephone and PBX systems to IP networks, as well as seamless connection of IP-PBXs to the PSTN.

## About

With this connector, it is possible to monitor the state of the interfaces and to monitor the performance KPIs related to the IP-to-PSTN and PSTN-to-IP conversion. The structure of the connector pages mirrors that of the web interface of the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | True                    |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Connection:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number:** The port of the connected device, by default *161.*
- **Get community string:** The community string used when reading values from the device, default value *public*.
- **Set community string:** The community string used when setting values on the device, default value *private*.

## Usage

### Alarms

This page displays a list of the active alarms on the device.

### General

This page contains general information from the standard MIB-2 (location, system description, etc).

### Interfaces

This page displays basic information related to every interface in the device, and allows you to manage the administrative status of the interfaces.

You can also assign labels to the interfaces to use them as keys in alarm templates.

### Trunk Settings

This page contains two tables:

- The **trunk settings table**, with the E1's framing method, administrative status, line code, etc.
- The **trunk status table**, a read-only table showing the LED color and status on the device panel.

### Trunk Utilization

This page contains a table that displays how the trunks are being used. The table shows the total and average values of channels used in a particular trunk.

### Performance IP2Tel

This page displays the main KPIs in the IP-to-PSTN conversion (busy calls, attempted calls, etc).

Note that polling of performance variables **must** be enabled in the device, as otherwise all parameters will appear as not initialized.

### Performance Tel2IP

This page displays the KPIs in the PSTN-to-IP conversion (busy calls, attempted calls, etc).

Note that polling of performance variables **must** be enabled in the device, as otherwise all parameters will appear as not initialized.

### Web Interface

This page displays the web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the client interface.
