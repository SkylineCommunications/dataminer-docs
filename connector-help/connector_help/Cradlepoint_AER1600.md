---
uid: Connector_help_Cradlepoint_AER1600
---

# Cradlepoint AER1600

The Cradlepoint AER1600 router manages converged wired and wireless connectivity. This Advanced Edge Routing solution combines cloud management, advanced security (UTM), WAN Diversity, industry-leading 4G LTE failover, high-performance WiFi, and dual-modem capabilities.

## About

This connector uses **SNMP** to monitor and control the Cradlepoint AER1600.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 6.2.2                       |

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

### Device Information

This page displays general information about the device, such as the **Description**, **Up time** and **Firmware**.

### Interfaces

This page contains a table listing the available **Interfaces** of the device, including their **Description** and **Alias**.

### Network

This page displays the **IP Address**, **IP Routing** and **IP Net To Media** tables. The page also contains information regarding **TCP**, **UDP** and **ICMP**.

### Available Connections

On this page, the **GPIO** **Input** and **Output** can be configured. The page also displays the **Modem Entries Table**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
