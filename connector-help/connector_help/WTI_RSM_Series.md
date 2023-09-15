---
uid: Connector_help_WTI_RSM_Series
---

# WTI RSM Series

The WTI RSM Series **Remote Site Manager** product line consists of devices designed to simplify the process of remotely managing network elements.

These devices provide remote access to console ports on distant network elements.

## About

This connector uses an SNMP connection to poll data from a WTI RSM device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 6.30                        |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: The device address.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

## Usage

### General

This page contains general system information.

### Port Status

This page contains a table with status information for each port, including the port name and the port buffer usage and threshold.

### Plug Status

This page contains a table with status information (current, power, etc.) for the different system plugs. The table also contains buttons that can be used to change the connection state of the plugs.

### Plug Groups

This page contains a table with status information (current, power, etc.) for the different user-defined plug groups. The table also contains buttons that can be used to change the connection state of the plug groups.

### User Configuration

This page contains a table that can be used to view and change the configuration of the different user profiles within the system.

For each user, you can configure the access level, access to ports, plugs and plug groups and the access to different communication interfaces.

After you have changed the configuration for a user, click the **Submit** button in that row to store the new information for this user in the system.

### Unit Status

This page displays the monitored status parameters for the different managed units, such as temperature, system RAM, system flash memory and the available Ethernet MAC addresses.

### Ping Function

This page can be used to configure the **ping functionality** and to retrieve metrics from the ping commands that have been sent.

### Telnet Connect

This page can be used to run Telnet commands on the device.

### Web Interface

This page can be used to access the device web user interface. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
