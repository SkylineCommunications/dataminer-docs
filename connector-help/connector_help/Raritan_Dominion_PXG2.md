---
uid: Connector_help_Raritan_Dominion_PXG2
---

# Raritan Dominion PXG2

The Raritan Dominion PXG2 connector facilitates the monitoring of this line of Power Distribituion Units (PDU).

## About

This connector uses **SNMP** to extract all relevant information concerning the configuration and operating configuration of Raritan's PDU.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | True                    |

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

- **IP port**: 161
- **Get community string**: public
- **Set community string**: private

## Usage

### Unit

In this page can be found information regarding the hardware configuration and the state of operation of the sensors of the connected PDU(s) unit(s).

### Inlets

In this page can be found the specifications of each inlet. It also shows the current operating configuration and the options allowing changes to said configuration of each inlet sensor.

### Over Current Protector

In this page can be found the specifications of each Over Current Protecto. It also shows the current operating configuration and the options allowing changes to said configuration of each sensor.

### Outlets

In this page can be found the specifications of all the outlets of the device. It also shows the current operating configuration and the options allowing changes to said configuration.

### External Sensors

In this page can be found the specifications of external sensors. It also shows the current operating configuration and the options allowing changes to said configuration of each sensor.

### Server Reachability

In this page are listed the servers connected to the device, their respective IPs and whether or not they are reachable.

### Wires

In this page can be found the specifications of all the wires connected to the device. It also shows the current operating configuration and the options allowing changes to said configuration.

### Transfer Switch

In this page are identified the transfers switches of the device. It also shows the current operating configuration and the options allowing changes to said configuration.

### Control

The Control Page presents the options allowing to control the operation of the conected elements of this device.

### Measurements Unit

This page shows the availability of and the values of each Unit sensor.

### Measurements Inlet

This page shows the availability of and the values of each Inlet sensor.

### Measurements Over Current Protector

This page shows the availability of and the values of each Over Current Protector sensor.

### Measurements Outlet

This page shows the availability of and the values of each Outlet sensors.

### Measurements External Sensor

This page shows the availability of and the values of each External sensor.

### Measurements Wire

This page shows the availability of and the values of each Wire sensor.

### Measurements Transfer Switch

This page shows the availability of and the values of each Transfer Switch sensor.

### Log Unit

This page logs the Unit sensor information in a span of 2 hours. One enty is added to the table corresponding to each minute, therefore there will be 120 entries per sensor.

For each sensor it is logged the state, maximum, minimun and average value. There is also an indication whether the logged information is available.

### Log Inlet

This page logs the Inlet sensor information in a span of 2 hours. One enty is added to the table corresponding to each minute, therefore there will be 120 entries per sensor.

For each sensor it is logged the state, maximum, minimun and average value. There is also an indication whether the logged information is available.

### Log Over Current Protector

This page logs the Over Current Protector sensor information in a span of 2 hours. One enty is added to the table corresponding to each minute, therefore there will be 120 entries per sensor.

For each sensor it is logged the state, maximum, minimun and average value. There is also an indication whether the logged information is available.

### Log Outlet

This page logs the Outlet sensor information in a span of 2 hours. One enty is added to the table corresponding to each minute, therefore there will be 120 entries per sensor.

For each sensor it is logged the state, maximum, minimun and average value. There is also an indication whether the logged information is available.

### Log External Sensor

This page logs the External sensor information in a span of 2 hours. One enty is added to the table corresponding to each minute, therefore there will be 120 entries per sensor.

For each sensor it is logged the state, maximum, minimun and average value. There is also an indication whether the logged information is available.

### Log Wire

This page logs the Wire sensor information in a span of 2 hours. One enty is added to the table corresponding to each minute, therefore there will be 120 entries per sensor.

For each sensor it is logged the state, maximum, minimun and average value. There is also an indication whether the logged information is available.

### Log Transfer Switch

This page logs the Transfer Switch sensor information in a span of 2 hours. One enty is added to the table corresponding to each minute, therefore there will be 120 entries per sensor.

For each sensor it is logged the state, maximum, minimun and average value. There is also an indication whether the logged information is available.

### Reliability Data

This page contains a list of PDU reliability data entries.

### Reliability Error Log

This page contains a list of PDU reliability ErrorLog entries.
