---
uid: Connector_help_Edge-Core_Networks_Data_Center_Switch
---

# Edge-Core Networks Data Center Switch

With this connector, information can be gathered and viewed from the device **Edge-Core Networks Data Center Switch**, and certain parameters can be configured.

## About

This device uses the **SNMP** protocol for the communication with the device.

### Version Info

| **Range**     | **Description**  | **DCF Integration** | **Cassandra Compliant** |
|----------------------|------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version  | No                  | Yes                     |
| 1.1.0.x \[SLC Main\] | Firmware changes | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.1.0.x          | 1.0.2.2                     |

## Installation and configuration

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Connection:

- **IP Address/host**: The polling IP of the device, e.g. *10.64.7.62*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

This page displays general information about the device, such as the **System Description**, **Up Time** and **Name**.

### Interface Page

This page displays a table with the status and statistics of the interfaces (ports) of the device.

### Host Status

This page displays ordinary status information about the device, such as **CPU Usage** and **Memory** information.

### Switch Configuration Page

This page can be used to set up configuration files of a TFTP service heading to configure the switch itself or to execute a batch file.
