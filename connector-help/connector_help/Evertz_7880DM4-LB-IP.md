---
uid: Connector_help_Evertz_7880DM4-LB-IP
---

# Evertz 7880DM4-LB-IP

The **Evertz 7880DM4-LB-IP** connector is used to monitor and control an Evertz chassis containing different Evertz 7700/7800 series cards.

## About

The chassis must include an **Evertz 7800-FC** card in order to be functional. Data about the location of other cards is polled from this card. The **Evertz 7800-FC** is placed in slot 1; other cards are inserted into slots 2 to 15. A DVE will be created for each (supported) card. Data is polled via **SNMP** and **HTTP**. Traps are supported to reduce the amount of polling. When a trap is received, the corresponding parameter is polled again to update its value.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.0.109                     |

### Exported connectors

| **Exported Connector**                | **Description**                   |
|--------------------------------------|-----------------------------------|
| Evertz 7880DM4-LB-IP - 7880DM4-LB-IP | Used for the 7880DM4-LB-IP module |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

#### HTTP Web API Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Device address**: The device address (default: *ByPassProxy*).

## Usage

This connector displays information about the Frame Controller (**Evertz 7800-FC**) and the inserted cards.

### General

This page displays general parameters for the **Evertz 7800-FC** controller, such as the **Temperature**, **Power Supply**, etc.

### Input Cards

This page lists all the modules embedded in the chassis and their corresponding slots. If cards have been changed, press the **Refresh Cards** button to see the changes immediately. If you activate the **Automatically Delete Offline Rows** toggle button, cards that get removed from the frame will not be moved to the **Input Cards table**.

### SNMP Config

On this page, you can configure the **SNMP** agent: the **trap** destination, the **community strings**, etc.

## Revision History

DATE VERSION AUTHOR COMMENTS

17/09/2018 1.0.0.1 RBL, Skyline Initial version
