---
uid: Connector_help_Emcore_Medallion_2100
---

# Emcore Medallion 2100

This connector retrieves information from the Emcore Medallion 2100 via SNMP. This device is an optical switch that provides an automatic or manual fiber switching function to protect a network from inadvertent service outages due to upstream optical signal degradation.

## About

The **Emcore Medallion 2100** connector displays the general information, alarm status, network configuration and power supply information of the device. All information is retrieved using SNMP.

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

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private.*

## Usage

### General

This page displays general information about the device. In addition, it contains some reset options provided by the device.

### Network Configuration

On this page, you can view information related to the network configuration and adjust this configuration.

### Input

This page displays the input devices at the optical switch.

### Output

This page displays the output devices at the optical switch.

### Switches

This page displays a table with the switch information and the threshold of the input's alarms.

### Power Supply

This page displays the power supply information of the device.

### Unit Status Alarm

This page displays the major and minor status of the alarms per unit status input. In addition, the page allows you to enable or disable alarms by means of the **Enable/Disable Alarms** button at the top.

### Miscellaneous Status Alarm

This page displays the major and minor status of the alarms per miscellaneous status input. In addition, the page allows you to enable or disable alarms by means of the **Enable/Disable Alarms** button at the top.
