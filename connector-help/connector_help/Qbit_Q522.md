---
uid: Connector_help_Qbit_Q522
---

# Qbit Q552

The Q552 UECP processor addresses cable network providers who have to generate valid and complete RDS data sets for their local stations.

## About

The connector uses SNMP to poll the Qbit Q552.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### Channels

On this page, all monitored channels are displayed in a table.

Each channel can have 4 errors:

- **Mec Rt**
- **Mec Pty**
- **Mec Pi**
- **Mec Ps**

### Traps

On this page, all trap destination entries are displayed.

For each entry, you can change the **IP address**, the **UDP port** and the **Community** settings. Each entry can also be **enabled** separately.

### Web Interface

The web interface of the device.

The client machine has to be able to access the device. If not, it will not be possible to open the web interface.
