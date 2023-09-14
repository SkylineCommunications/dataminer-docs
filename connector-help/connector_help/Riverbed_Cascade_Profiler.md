---
uid: Connector_help_Riverbed_Cascade_Profiler
---

# Riverbed Cascade Profiler

The **Riverbed Cascade Profiler** reports data collected by other Cascade devices like Gateway, Sensor and Shark. It can be used to monitor applications and for network troubleshooting.

## About

This connector uses SNMP to collect resources, consumption information and sensor data.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host:** The polling IP of the device.
- **Device address:** Not required.

**SNMP Settings:**

- **Port number:** The port of the connected device (e.g. *161*).
- **Get community string:** The community string used when reading values from the device (e.g. *public*).
- **Set community string:** The community string used when setting values on the device (e.g. *private*).
- **Security level and protocol:** The security level and privacy settings (e.g. *authNoPriv* \[Authentification/No privacy\]).
- **Username:** The SNMPv3 user name (e.g. *DataMiner*).
- **Authentification password:** Passphrase to connect to the SNMPv3 agent (e.g. *password*).
- **Authentification algorithm:** The encryption algorithm used for authentification (e.g. *HMAC-MD5*).

## Usage

### General

On this page, general information is displayed, such as **System Name, System Up Time, System Location**, etc.

In addition, the **MBlade** **Table** provides information on the running services **(Analyzer, Event Manager, Database)** and their status.

### Profiler Status

This page displays the **CPU Resource Table** and **Memory Resource Table**, which provide information about the consumed resources.

### Profiler System Information

On this page, a **Sensor Table** shows the sensor devices that collect data for the profiler, displaying the **Sensor Name**, **Sensor IP Address** and **Sensor Status**.

### Profiler Disk Allocation

This page provides information about the usage of the disk resources.

### Profiler Interfaces

This page displays the **Interfaces Table**, which contains traffic statistics for all the network interfaces of the device **(RX/TX Octets, RX/TX Unicast Packets, RX Packets in Error, ...)**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
