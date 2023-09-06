---
uid: Connector_help_Columbia_Weather_Systems_Weather_MicroServer
---

# Columbia Weather Systems Weather MicroServer

The Columbia Weather Systems Weather MicroServer driver allows you to monitor a weather station that can be connected to different sensors.

The driver uses SNMPV2 to communicate with the device and uses history sets.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### SNMPv2 connection

This driver uses a Simple Network Management Protocol version 2 connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*

### Web interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this driver has the following data pages:

- **General**: Displays general system information, GPS data such as latitude and longitude, and SNMP information such as packets information.
- **Temperature**: Displays temperature information received from the different sensors (if connected).
- **Pressure**: Displays the pressure and density information received from the different sensors (if connected).
- **Humidity**: Displays the humidity information received from the sensor (if connected).
- **Precipitation**: Displays the precipitation information received from the sensor (if connected), including information on rain, hail, snow and evapotranspiration.
- **Wind**: Displays the wind information received from the sensor (if connected), including wind speed, direction, etc.
- **Radiation**: Displays the radiation information received from the sensor (if connected), including solar radiation, Lux, UV radiation, PAR, etc.
- **Air Quality**: Displays the air quality information received from the sensor (if connected), including CO2 concentration and particle concentration.
- **Web Interface**: This page displays the web interfaceof the device. Note that the client machine has to be able to access to the device, as otherwise it will not be possible to open the web interface.
