---
uid: Connector_help_Mikrotik_Wise_wireless_router
---

# Mikrotik WISE wireless router

## About

This connector can be used to display and monitor information about the Mikrotik WISE wireless router

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | False                   |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 4.17                        |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol version 2 (SNMPv2) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device, by default 161.
- **Get community string**: The community string in order to read from the device. The default value is public.
- **Set community string**: The community string in order to set to the device. The default value is private.

## Usage

### General

This page displays general information about the system, such as the System Name, System Description, Temperature, Processor Load, etc.

The Software page button displays a page with information about Software licence and version running on the router.

The System Health page button displays system power supply, fan status and CPU temperature.

The storage page button displays the storage table.

### Users

This page displays the Active User Table, which contains information about the users that are currently active.

### Interfaces

This page displays information about the router interfaces.

### Queue

This page displays the Queue Table, which contains information about the configured incoming/outgoing traffic queues.
