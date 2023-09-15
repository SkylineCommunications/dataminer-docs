---
uid: Connector_help_Network_Technologies_Inc_Enviromux-16D
---

# Network Technologies Inc Enviromux-16D

The **Network Technologies Inc Enviromux-16D** connector can be used to monitor critical environmental conditions, such as temperature, humidity, liquid water presence, power, intrusion and smoke. The connector can also be used to configure the network settings.

The system includes three internal sensors: temperature, humidity and power. It also supports 16 external configurable sensors, 8 digital input sensors, and 4 output relays for the control of external devices.

## About

This connector provides an overview of the internal, external and auxiliary sensors, the digital inputs and the statuses of the output relays, power supplies, etc.

An **SNMP** connection is used in order to successfully retrieve and configure the information of the device.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.56                        |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays the **System** parameters and the **Firmware Version**. Via page buttons, you can view additional information on the **Smoke Detectors**, **Remote Inputs/Relays**, etc.

### Sensors

This page displays information on the **Internal Sensors**, the **Auxiliary Sensors** and the **External Sensors**.
Page buttons provide access to information on the **External Sensors ACLM**, **TAC Sensors** and **Auxiliary 2 Sensors**.

### Digital Inputs

This page displays data related to the digital inputs

### IP Devices

This page displays data related to the IP devices.

### IP Sensors

This page displays data related to the IP sensors.

### Output Relays

This page displays the statuses of the output relays.

### Power Supplies

This page displays the statuses of the power supplies.

### Smart Alerts

This page displays the **Events** and **Smart Alerts** tables.

### Network Configuration

On this page, you can configure the settings for **IPv4**, **IPv6** and **VLAN**.

### Web Interface

This page displays the web interface of the device. The web interface is only accessible when the client machine has network access to the product.
