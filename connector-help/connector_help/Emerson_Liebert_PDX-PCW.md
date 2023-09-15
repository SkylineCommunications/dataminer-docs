---
uid: Connector_help_Emerson_Liebert_PDX-PCW
---

# Emerson Liebert PDX-PCW

With this connector, you can gather and view information from the device **Emerson Liebert PDX-PCW**, as well as configure the device.

## About

This connector uses SNMP to monitor the **Emerson Liebert PDX-PCW** device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 5.280.2                     |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General

This page displays general information about the device, such as the **System Description**, **Up Time** and **Firmware Version**.

### Interfaces

This page displays a table with the status and statistics of the device's **interfaces**.

### Events

This page displays a table with the events present on the device and the time when they were generated.

### Environmental Settings

On this page, you can configure the **temperature** and **humidity** settings of the device.

### System Status

This page display the status of the device, with parameters such as **System State**, **Cooling/Heating State** and **Cooling/Heating Capacity**.

### Configuration

On this page, you can configure the device, with parameters such as **Restart Delay**, **Humidity Control** and **Fan Speed mode**.

### Statistics

This page displays the run times of different modules, such as the **Fan**, **Reheat elements** and **Compressors**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
