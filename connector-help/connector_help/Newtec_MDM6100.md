---
uid: Connector_help_Newtec_MDM6100
---

# Newtec MDM6100

This connector is used to monitor and control the **Newtec MDM6100** modem.

## About

Information from the Newtec MDM6100 modem is retrieved via **SNMPv2**.

The device can also be fully **configured** using this connector. SNMPv2 commands are also used for this.

### Version Info

| **Range** | **Description**                              | **DCF Integration** | **Cassandra Compliant** |
|------------------|----------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                              | No                  | Yes                     |
| 2.0.0.x          | Custom version for Newtec (based on 1.0.0.9) | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | MDM6100_2.1.51.53886        |
| 2.0.0.x          | MDM6100_2.8                 |
| 2.2.0.x          | 2.6.1.60930                 |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol version 2 (SNMPv2) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays general information about the modem.

### Management Interfaces

This page displays the **Ethernet Link Management, Ethernet Link Management Statistics,** **Management IP Gateway** and **IP Management Interface**.

The **IP Management Interface** table contains an entry for each management interface in the modem, with information about the interface such as its **Name**, **IP** **Address**, etc.

### Data Interfaces

This page contains the **Ethernet Link Data** table, the **Ethernet Link Data Statistics** table, the **Data IP Gateway** and the **Data Interface** table.

### ASI Input

This page contains **PRBS Monitoring** parameters and allows you to configure the **ASI Input.**

### ASI Output

This page displays the **Measured TS Bit Rate** and allows you to configure the **ASI Output.**

### TS Over IP Input

This page allows you to configure and monitor (via the **Input Monitor** page button) parameters for the **TS over IP Input** of the modem.

### TS Over IP Output

This page allows you to configure and monitor (via the **Output Monitor** page button) parameters for the **TS over IP Output** of the modem.

### TS Connectivity (Version 2.1.0.1)

This page contains the **TS Configuration Table**. This table can be used to configure the **TS connectivity** of the modem.

### TS Analyzer

This page contains the **TS Analyzer PID** and **TS Analyzer PCR PID** tables. The page also contains configurable parameters for the **TS Analyzer** of the modem.

### TS Mux

This page contains the **TS Mux Statistics**. The page also contains configurable parameters for the **TS Mux** of the modem.

### MPE Decapsulation

This page contains the **Routing Configuration** table. The page also contains configurable parameters for the **MPE Decapsulation** of the modem.

### Modulator

This page contains configuration and monitoring parameters related to the **modulator**.

### Demodulator

This page contains all tables related to the **demodulator**. These tables can be used to configure and monitor the demodulator.

### Ref Clock

This page contains parameters to configure the **reference clock**.

### Configuration

This page can be used to configure the actual device (for example to upload a configuration file). **SNMP traps** can also be configured on this page.

### Alarm

This page displays a **summary of the device's alarms**.

It is also possible to **configure** the **impact** of the alarms on the device (on the **Alarm configuration** page, accessible via **Alarms Config** page button).

### Web Interface

This page provides access to the web interface of the device. Note that client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
