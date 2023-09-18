---
uid: Connector_help_Digidia_Tunell
---

# Digidia Tunell

This **SNMP** connector polls and sets parameters for devices such as the **Digidia Tunell**, designed for digital radio. It also retrieves traps in order to update alarm parameters.

## About

This connector polls parameters using three different timers, depending on the importance of the parameter. It also allows you to configure certain settings. Received traps update the alarm parameters and the trap notification table.

## Installation and configuration

### Creation

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.18.28.83*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *snmpuser.*
- **Set community string**: The community string used when setting values on the device, by default *private.*

### Configuration of the LITE functionality

To enable lite functionality, on the **Poll Settings** page:

- Enable the **Poll Site Monitor Parameters**.
- Enable the **LITE Protocol** parameter.

To revert to normal functioning:

- Disable the **LITE Protocol** parameter.

## Usage

The connector consists of 7 pages:

- **General:** This is the default page, which displays general system information.
- **Users:** Displays a table with the user accounts.
- **Ethernet and Trap Settings:** Allows you to view and configure the settings for Ethernet, SNMP and traps.
- **Trap Notifications:** Displays a table with the received traps, updated via SNMP.
- **Alarm Settings:** Contains two tables that allow you to set alarm thresholds and other values.
- **Alarm Status:** Displays several specific alarm parameters, updated via SNMP and traps.
- **Application Notification:** Displays an application notification table.
