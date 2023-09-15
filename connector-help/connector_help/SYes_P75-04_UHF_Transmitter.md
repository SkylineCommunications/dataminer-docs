---
uid: Connector_help_SYes_P75-04_UHF_Transmitter
---

# SYes P75-04 UHF Transmitter

The SYes P75-04 UHF Transmitter is a high power, liquid-cooled transmitter system.

## About

The **SYes P75-04 UHF Transmitter SNMP** connector controls and monitors the transmitter rack.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 469180171-20                |

## Installation and configuration

### Creation

#### SNMPv1 main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMPv2 Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays information about the system such as **Description**, **Up Time**, **Name**, etc.

Buttons are available that allows you to **clear the cache**, **update the configuration** or **restart the agent**.

Finally, this page also contains 2 page buttons that will navigate to the CPU **Load Average Table** and the available **Memory Parameters**.

### Status

This page contains a list of all system status parameters as well as general information, such as **System Alarm Status**, **System SNMP Mode**, **System Working State**, etc.

### TX

This page contains the TX status parameters, such as **Tx Status**, **Tx Low Power Alarm**, **Tx Interlock State**, etc. It also contains Tx value parameters such as **Nominal Power**, **Channel Frequency**, **Forward Power**, etc.

There are also 2 page buttons that navigate to the **Tx A Amplifier Table** and the **Tx Command** **Table**.

### Driver

This page contains the connector-specific tables: **Driver General Info Table**, **Driver Status Table** and the **Driver Measure Table**.

There are also 3 page buttons that navigate to the **Driver Output Table**, **ASI Input Table** and **Driver Configuration Table**.

### Amplifiers

This page contains the amplifier-related tables: **Amplifier Overview Table**, **Amplifier Status Table** and the **Amplifier Measure Table**.

There is also a page button available that navigates to the **Amplifier Command Table**.

### GPS

This page contains the GPS-related tables: **GPS Info Table**, **GPS Status Table** and the **GPS Alarm Table**.

### SNMP Traps

This page contains all the possible settings to configure traps.

### Web Interface Page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
