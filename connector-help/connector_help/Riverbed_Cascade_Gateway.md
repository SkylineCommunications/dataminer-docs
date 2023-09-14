---
uid: Connector_help_Riverbed_Cascade_Gateway
---

# Riverbed Cascade Gateway

The **Riverbed Cascade Gateway** collects traffic information from different network devices such as routers or switches. It transmits its processed flow data through MNMP to Riverbed Cascade Profiler devices.

This connector monitors the device status regarding CPU, memory and disk usage, and monitors its network interfaces.

## About

This connector polls SNMP tables and parameters.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required.

**SNMP Settings:**

- **Port number**: The port of the connected device (e.g. *161*).
- **Get community string**: The community string used when reading values from the device (e.g. *public*).
- **Set community string**: The community string used when setting values on the device (e.g. *private*).
- **Security level and protocol**: The security level and privacy settings (e.g. *authNoPriv* \[Authentification/No privacy\]).
- **Username**: The SNMPv3 user name (e.g. *DataMiner*).
- **Authentification password**: Passphrase to connect to the SNMPv3 agent (e.g. *password*).
- **Authentification algorithm**: The encryption algorithm used for authentification (e.g. *HMAC-MD5*).

## Usage

### Riverbed System Information

On this page, general information is displayed, such as the **System Name, System Location** and **System Up Time**.

### Status

This page displays the **load averages** and the **memory and swap usages**.

### Disk Usage

This page displays a table containing information on the **disk space** usage.

### Network Interfaces

On this page, two tables are displayed. The **IP Adresses Table** shows the IP addresses associated to the device interfaces. The **Interfaces Table** displays traffic statistics for all the network interfaces of the device (**RX/TX Octets, RX/TX Unicast Packets, RX Packets in Error**, ...).

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
