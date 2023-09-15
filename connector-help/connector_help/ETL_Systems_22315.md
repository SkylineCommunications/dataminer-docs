---
uid: Connector_help_ETL_Systems_22315
---

# ETL Systems 22315

This connector is used to monitor the **ETL Systems 22315** Splitter/Combiner.

## About

This device contains a combiner and a splitter, which both feature a redundant amplifier system (a main amplifier and a backup amplifier). The device is powered by two redundant Power Supply Units (PSU).

The device can be monitored by **SNMP** and via a native web interface. If the device is in failure (because a PSU failed or an amplifier failed), a **trap** is sent to the DataMiner element. When the trap is received, DataMiner will immediately poll the data from the device to update the status. No alarms are shown when a trap is received.

Information from this connector is displayed on 2 main pages (see "Usage" section below).

## Installation and Configuration

### Creation

SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Connection:

- **IP Address/host**: The polling IP of the device.

SNMP Settings:

- **Port Number:** The port of the connection device, by default *161*.
- **Get community string:** The community string used when reading values from the device, by default *public*.
- **Set community string:** The community string used when setting values on the device, by default *private*.

## Usage

### General Page

This page contains all the standard **SNMP** data related to the system (name, contact, location, etc.).

It also contains four page buttons that open the following subpages:

- **Unit Status**: This page contains a table with a row for each Power Supply Unit in the system (main and backup).
- **Amp Status**: This page contains a table with two rows: a row for the splitter amplifier system and a row for the combiner amplifier system. The amplifier status is displayed in the column **Amp Mon Status** (*OK*/*main path failed*/*both paths failed*/*Not Powered* Or *Monitored*). **Amp Mon Report** allows you to enable/disable trap reports.
- **Trap Settings**: This page allows you to change the **trap** settings. You can enable/disable the trap reports, specify to which **IP address** traps must be sent and choose the **community string**. When a trap is received by the element, DataMiner will immediately poll the data from the device to update the status. No alarms are shown when a trap is received.
- **IP Settings**: This page allows you to change the network parameters of the monitoring unit.
  Note: Each change to the parameters requires a reset of the unit.

### Web Interface

This page displays the native web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
