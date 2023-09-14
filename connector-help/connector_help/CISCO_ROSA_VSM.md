---
uid: Connector_help_CISCO_ROSA_VSM
---

# CISCO ROSA VSM

The **CISCO ROSA VSM** (Video Service Manager) system provides a complete solution for end-to-end management of digital video and audio service platforms. The system monitors, manages, and controls services throughout a network. **ROSA VSM** is server software that runs on standard form factor Intel HW.

## About

The connector uses an HTTP connection to retrieve lineups, configurations and events. SNMP traps are used to obtain active alarm information.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 5.02.05                     |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Device address**: The device address. (Default: *ByPassProxy*)

#### SNMP Trap Connection Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device. (Default: *public*)
- **Set community string**: The community string used when setting values on the device. (Default: *private*)

## Usage

### General

On this page, **REST** polling can be enabled. Note that the **CISCO ROSA VSM license** must be "Enterprise", as otherwise only **SNMP** data will be displayed by the element. Also, the user must fill in the **Username** and **Password** in order to retrieve **Lineups**, **Configurations** and **Events**.

### Alarms

This page contains the **Alarm Table** and its configuration. To retrieve all pending alarms, use the **Check** button.

### Lineups

This page displays the **Configuration** and the **Event Table**. It is possible to **create new events** if there are existing **Lineups** and **Configurations**.

Note that it is not possible to create a new event if there already is one for the given **Lineup**.

### Overview

This page contains a tree control with all the information related to **Lineups**, **Configurations** and **Events**.
