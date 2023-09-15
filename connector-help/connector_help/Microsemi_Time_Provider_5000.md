---
uid: Connector_help_Microsemi_Time_Provider_5000
---

# Microsemi TimeProvider 5000

The Microsemi TimeProvider 5000 is a carrier grade IEEE 1588 Precision Time Protocol (PTP) Grandmaster with additional capabilities, including NTP and SyncE, that provide a flexible technology suite to match the synchronization needs of evolving networks.

## About

The TimeProvider 5000 is an independent timing reference that enables telecommunication providers to build a more stable, robust and reliable network infrastructure, combining hardware-based time stamping with the highest level of timing and frequency accuracy for a broad range of wireline and wireless applications.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

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

This page displays general parameters related to the device, such as the **System Model**, **Chassis Type**, **I/O Module Type**, **Asset Number** and **IMC** **and** **IOC Date Time.**

### Inventory

This page displays information on **Inventory** and **Compatibility** for each IMC, IOC1 and IOC2.

### Alarm Events

This page displays the list of current **Active Alarms** and **Active Events** of the TP5000 device.

### Network

This page displays information regarding the **IP Status** of each port in IMC and IOC modules, as well as regarding the **Ethernet Link** of the TP5000 device.

### GPS

This page presents information regarding the **GPS Position** and **Satellite Vehicles (SV)** being tracked. It also displays the **GPS Mode**, **Elevation Mask** and **Cable Delay**.

### Status

This page displays information about the **System** and the **Craft** parameters. Additionally, it also has four subpages with **LED** information, the **status of Hardware**, the **PTP** **(Precision Time Protocol)** status and the **I/O** status**.**
