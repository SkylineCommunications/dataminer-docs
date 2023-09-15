---
uid: Connector_help_Socomec_UPS
---

# Socomec UPS

The Socomec UPS version is an SNMP connector that communicate with Socomec UPS to get information from the device.

## About

A SNMP connection is used in order to successfully retrieve and configure the device's information.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |
| 1.1.0.x          | Version Update  | No                  | No                      |
| 1.2.0.x          | Version Update  | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.1.0.x          | 2.06                        |
| 1.2.0.x          | 2.08                        |

## Installation and configuration

### Creation

**SNMP Connection**

- **IP address/host**: The polling IP of the device.

**SNMP Settings**

- **Port number:** The port of the connected device, by default *161.*
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

## Usage

Once created, the element can be used immediately, There are 4 pages available.

### General

This page contains some information about the device, also some configuration and network parameters.

### Input/Output

Here you will find the voltage, current and frequency of the inputs and outputs of the device.

### Bypass/Battery

At this page you see he voltage, current and frequency of the bypass, here are also some parameters available about the battery.

### Alarm Page

This page contains all the alarms.
