---
uid: Connector_help_Elber_RK1000
---

# Elber RK1000

The Elber RK1000 connector can be used by broadcast operators in transmission networks for the DVB-ASi signal distribution over satellite or terrestrial networks as well in studio environments for the routing or the distribution of SDI/HD/3G-SDI/DVB-ASI signals. This connector is composed by a basic 3U 19" chassis that can host up to 10 hot-swappable modules, allowing an easy maintenance and stock management.

## About

This connector exports connectors of type CO02 and creates elements for each card in it's chassis. Data is polled via **SNMP** and traps are used.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

### Exported connectors

| **Exported Connector** | **Description**           |
|-----------------------|---------------------------|
| Elber RK1000 - CO02   | Used for the CO02 module. |

## Installation and configuration

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device. \[e.g. 10.10.15.1\]

SNMP Settings:

- **Port number**: The port of the connected device. \[default: *161*\]
- **Get community string**: The community string used when reading values from the device. \[default: public\]
- **Set community string**: The community string used when setting values on the device. \[default: private\]

## Usage

### Modules

This page contains the **Modules Info** Table. This table contains all the cards and offers the ability to display these cards or make them invisible. The page button **Modules \[DEL\]** contains a table with the cards that have been removed from the chassis. In case a card broke and has to be removed from the chassis then this card is moved to this table. When a new card of the same type is plugged in then this will move back. This ensures that trending/alarming history is not deleted. If you do not want to keep this history you can delete this card in the **Modules Info \[DEL\]** table.

### General

This page contains the general parameters: e.g. **Customer Name**, **Customer Location**, ...

### Controller

This page contains the parameters for the controller. This page is divided in the **status** parameters, the **alarm** parameters, the **configuration** parameters and the **network configuration** parameters. e.g. **Controller Status PSU 1 Voltage**, **Controller Config Date Time**, **Controller Config Network Ip Address**, etc.

### Traps

This page contains all the traps.

### Web Interface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Supported cards

### CO02

The CO02 card is a plug in board for the RK1000/A; DVB-ASI, 3G-SDI change-over, 3 inputs and 7 outputs (last-selected input loop-through), with matrix function.
