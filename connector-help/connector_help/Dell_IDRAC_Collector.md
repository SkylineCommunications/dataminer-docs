---
uid: Connector_help_Dell_IDRAC_Collector
---

# Dell iDRAC Collector

The **Dell iDRAC Collector** Protocol communicates with multiple external **Dell Poweredge** devices and collect basic device indicators.

## About

This connector communicates using SNMP Protocol version 3. It allows the monitor and trend of all statuses and readings from remote **Dell iDRAC** devices. It can optionally export each Dell iDRAC device as a virtual element.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.30.30.30                  |

## Exported connectors

| **Exported Connector** | **Description**          |
|-----------------------|--------------------------|
| Dell IDRAC Remote     | Dell IDRAC remote device |

## Installation and configuration

### Creation

SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection, however it does not require any input during element creation, because the connection parameters and credentials of the remote devices are imported from a .csv file.

## Usage

### General

This page displays the following parameters: **System Model Name, System Service Tag, System OS Version, Global System Status, Global Storage Status, System Power State and System Power Up Time, etc**

There are also two page buttons, **DVEs...** where you can find the exported Dell iDRAC virtual elements, and **Threads...** containing statistics about the multi-threading polling performance.

### Chassis Info

This page contains the chassis information. Other tables will reference to these chassis entries such as **Power Supply**, **Cooling Device**, **Temperature Probe**, **Processor Device**, **Processor Device Status**, **Memory Device**, **PCI Device**, **Network Device** and **System Slot Tables**.

### PSU

The **Power Supply Table** contains all PSU slots per chassis. Readings can be trended and monitored.

### Thermal Info

There are two tables on this page, the **Cooling Device Table** contains all the Fan statuses and readings, while the **Temperature Probe Table** contains all the measurements and statuses of the temperatures for multiple sections per chassis.

### Device Info

All settings and readings and statuses about the processors can be found in the **Processor Device Table** and **Processor Device Status Table**. Next to the processor tables there are also tables containing the readings and states for **Memory**, **PCI** and **Network Device Tables**.

### Modular Slots

On this page the **System Slot Table** can be found. This table will only be polled if the **Dell iDRAC** is in a modular **State**. This state can be found in the **Chassis Service Tag** parameter that can be found on the **Chassis Info** page.

### RAID

Settings, readings and statuses can be monitored and trended for the **Controller Table**, **Enclosure Table**, **Physical Disk Table** and **Battery Table**.

### Logical Devices

The **Virtual Disk Table** contains all settings and statuses of the virtual disks on the **Dell iDRAC**.

### Logical Devices

The **Configuration** page contains all the settings parameters like the provisioning **File Path** and the master **Polling Status.**
