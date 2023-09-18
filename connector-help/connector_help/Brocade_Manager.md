---
uid: Connector_help_Brocade_Manager
---

# Brocade Manager

The Brocade Manager connector is used to monitor and control Brocade switches and routers.

The connector has already been tested for the VDX6740.

## About

This connector uses **SNMP** to communicate with the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 6.0.1a.                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host:** The polling IP of the device.

SNMP Settings:

- **IP port:** The port of the connected device, by default 161.
- **Get community string**: The community string used when reading values from the device, by default *public.*
- **Set community string**: The community string used when setting values on the device, by default *private.*

## Usage

### General

This page displays the **System Description**, **Contacts** and **Locations**.

### Chassis

This page displays the **Serial Number**, **Temperature** and **CPU Utilization** of the chassis. Below this, you can find information on the **Chassis Power Supplies** and **Chassis Fans**.

### Interface

This page displays the **Interface Table**.

### TCP

This page displays the **Transmission Control Algorithm**, **Minimum Retransmission Timeout**, **Maximum Retransmission Timeout**, **Attempt Fails**, etc. The page also includes a page button that displays the **Connection Table**.

### UDP

This page displays several parameters related to the **User Datagram Protocol**. The page also includes a page button that displays the **UDP Table**.

### IP

This page displays several IP-related parameters. The page also includes a number of page buttons: **V6 Router Table**, **Addressing Table**, **Network to Media Table**, **Route Table**, and **Addressing Table**.

### FRU

This page displays the **Field Replaceable Unit Table** and contains a page button that displays the **FRU** **History**.

### VLAN Ports

This page contains the **VLAN Ports Table**. Polling of the table can be enabled or disabled. If it is disabled, the current data in the table will be cleared.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
