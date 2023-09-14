---
uid: Connector_help_Rittal_CMC_III
---

# Rittal CMC III

The Rittal CMC III is a processing unit for a network with sensors/CAN bus. This connector will allow the user to view everything the Rittal CMC III monitors.

## About

The connector gets the information from the Rittal CMC III through SNMP.

### Version Info

| **Range**     | **Description**                                            | **DCF Integration** | **Cassandra Compliant** |
|----------------------|------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version                                            | No                  | Yes                     |
| 1.0.1.x \[SLC Main\] | Discreet value for Status changed from 45 to 4 for Off 60s | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | V5.13.00_8                  |
| 1.0.1.x          | V5.1300_8                   |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device: *151.*
- **Get Community string:** *public*
- **Set Community string:** *private*

## Usage

### General

This page displays general parameters, such as **URL**, **Firmware Version**, **Serial Number**, etc.

### Setup General

This page allows you to define the **active communication** and set the **ports** that should be used.

### Setup NTP

On this page, you can set the **NTP** settings.

### Device Info

This page displays more detailed general parameters, such as **Number of Vars**, **Number of Messages**, etc.

### Message Info

This page displays several statistics related to messages, as well as the **CMC III Message Table**, which contains both information and configurable parameters.

### Power Info

This page displays information such as the **Unit Frequency**, **Unit Power Active**, **Unit Energy Active**, **Phase L1**, as well as the status of each of the sockets.

### Temperature Info

This page displays information about the temperature, such as the **Temperature Value**, **Temperature Offset**, and **Temperature Status**. It also contains a toggle button that allows you to enable or disable the polling of these parameters.

### Humidity Info

This page displays information about the humidity, such as the **Humidity Value**, **Humidity** **Offset**, and **Humidity** **Status.** It also contains a toggle button that allows you to enable or disable the polling of these parameters.

### Web Interface

This page displays the web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
