---
uid: Connector_help_Sofia_Digital_Playout_Manager
---

# Sofia Digital Playout Manager

This connector uses an **SNMP** connection to monitor a **Sofia Digital** **Playout Manager**.

## About

The Sofia Backstage Playout Manager can be used to manage EPG information on all DVB-compliant digital networks. Service information, specifically Event Information Tables (EIT), is used to populate the EPG, which provides information about different services provided on DVB networks.

The connector supports both the **Sofia Digital EPG System** and **HBBTV plugin** servers.

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

- **IP address/host**: The polling IP of the device, e.g. *172.32.65.38.*

SNMP Settings:

- **Port number**: The UDP port, by default *161.*
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string:** The community string used when setting values on the device, by default *private*.

## Usage

### Playout Manager

This page contains a parameter called **Number of Playouts**, which displays the number of connected playouts.

In addition, the page contains the **Playout Table**, which displays more information about the connected playouts.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
