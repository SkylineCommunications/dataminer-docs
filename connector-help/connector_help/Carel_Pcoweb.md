---
uid: Connector_help_Carel_Pcoweb
---

# Carel pCoweb

The **pCOWeb** is used to interface the pCO Sistema to networks that use the HVAC protocols based on the Ethernet physical standard, such as BACnet IP, Modbus TCP/IP and SNMP.

## About

A SNMP connection is used in order to successfully retrieve and configure the information of the device. There are also different possibilities available for **alarm monitoring** and **trending**.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | False                   |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x \[Main\] | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device. (default: public)
- **Set community string**: The community string used when setting values on the device. (default: private)

## Usage

### Web Info

The page contains web info such as **Release, Code and PCO ID 1 - Status**

### Digital

The page contains Digital parameters that associated with the device such as **System Fan, Compressor 1**

### Analog

The page contains Analog parameters that associated with the device such as **Room Temperature, Outdoor Temperature**

### Integer

The page contains Integer parameters that associated with the device such as **Envolope Zone, Motor Voltage**

### Web Interface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
