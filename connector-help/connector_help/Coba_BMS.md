---
uid: Connector_help_Coba_BMS
---

# Coba BMS

Coba BMS is a fully integrated Building Management System.

## About

This connector uses SNMP communication to retrieve information on the Coba BMS.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
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

- **IP port**: The IP port of the device, by default *161*.

## Usage

### General

This page displays the **Room Temperature** in degrees Celsius and the **PCU Status** from 1 to 4. Two possible states are possible for the PCU status, i.e. *On* or *Off*.
