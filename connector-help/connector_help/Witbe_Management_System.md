---
uid: Connector_help_Witbe_Management_System
---

# Witbe Management System

This connector displays the traps of the Witbe Management System.

## About

This connector is able to receive all traps of the Witbe Management System and display them in a table.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection to receive traps and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

### General

This page displays the received traps in the **measurement table.**

Measurements with a duration of 0 can be removed with the **Remove Unused Meas.** button.
