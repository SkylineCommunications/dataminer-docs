---
uid: Connector_help_WISI_LX35
---

# WISI LX35

LX3x is a family of optical amplifiers based on EYDFA technology for use in HFC and FTTx networks. The system is available with different output power and various numbers of outputs. The system can be used in any network such as HFC, RF over Glass or RF Overlay in FTTX applications. Among others, the system provides very high optical power with 38 dBm internally, standalone operation or integration in a WISI Optopus system, extensive management via SNMP, HTTP or custom options, and carrier grade functions with hot pluggable and redundant power and fans.

## About

With this connector, it is possible to monitor parameters of the optical amplifier and to configure the device.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains general parameters related to the device, such as its **Name**, **Location**, **Description**, **Logical ID**, **Article Number**, **Year of Manufacture**, **Serial Number**, **Hardware Revision** and **SAP Number**. The page also displays **System Information** and the **System Status**, and allows you to execute a **System Reboot.**

### Interface

This page displays the list of interface entries, with the management information for each interface.

### Device

This page displays a table with information about the devices for each slot number. The **Devices Table Polling** toggle button determines whether polling for this table is activated.

The page also contains buttons to perform a **Device Scan** and a **Broadcast Reset.**

### Network

This page displays general network parameters such as the **Supported SNMP Versions**, **Update with TFTP**, **Update with HTTP**, **SSH Authentication Methods**, **Webserver Access** and **Webserver Password**.

It also contains page buttons that provide access to **IP Settings**, the **Access Control List** and the **TFTP** options. The **Trap Configuration** subpage displays the **Traps** table, which contains the list of hosts (identified by their network address) to which the headend controller has to send the traps. The **Firmware Images** subpage allows you to check the status of the firmware images on the device. The **Firmware** subpage allows you to upgrade/downgrade an SW image to the device.

Note: In order for the password authentication method to work, there should be no RSA key files in the **KnownHosts + Keys Folder** directory.

### EDFA Control

This page displays the **LX35 YEDFA 32 x 17.0 dBm** general information, as well the **EDFA Status and EDFA Reset**.

It also contains page buttons to the following subpages:

- **Optical**: Displays the **Optical Gain** and the **Optical Input/Output Power**.
- **Lasers**: Displays a table with **Laser 1 and 2** information.

### Alarms

This page displays the **Current Alarms** table, which contains information about the parameter properties that currently have active alarms. It also displays the **Alarms Log**, which shows a list of the alarms that have been logged.

A page button provides access to the **Alarm Configuration** subpage, where you can find tables with information on the **Alarm Properties** and **Discrete Properties.**

### Fans

This page displays the **Fans** table, which shows the **Current Speed** and **Operation Time** of each fan. The page also allows you to perform a **Reset.**

### Web Interface

On this page, you can access the web interface of the WISI LX35 Optical Amplifier. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
