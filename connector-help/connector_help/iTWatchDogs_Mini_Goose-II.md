---
uid: Connector_help_iTWatchDogs_Mini_Goose-II
---

# ITWatchDogs MiniGoose-II

ITWatchDogs MiniGoose-II is a climate monitor that supports up to 16 remote sensors (plus an internal temperature sensor). The main purpose of this climate monitor is to measure temperature and humidity.

## About

The driver uses an **SNMP** connection to retrieve measurements from the remote sensors.

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | v3.12.7                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Connection:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays general information related to the climate monitor (**Name**, **Version**, **Hardware**, etc.).

### Sensors

This page displays temperature, humidity and air flow measurements in the **Temperature Sensor Table** and **Air Flow Sensor Table**. Each row represents the measurements from a remote sensor.

### Webinterface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
