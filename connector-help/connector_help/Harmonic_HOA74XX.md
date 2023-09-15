---
uid: Connector_help_Harmonic_HOA74XX
---

# Harmonic HOA74XX

The HOA74XX **optical amplifiers** are optimized for single wavelength operation and are suitable as multi-purpose optical amplifiers.

## About

This connector is used to monitor the major parameters of the device (inputs and outputs) and makes it possible to configure these.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.50                        |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains basic information about the device, including the **Hardware**, **Software** and **Firmware** version.

### Controls

This page displays information related to the **Unit**, **Laser Unit** and **Fan Status**, as well as information on the **Output Power Supply**.

### Optics

On this page, you can find the **Input** and **Output Power**. It is also possible to configure the **Output Gain Type** here.

### Alarms

This page contains two tables that allow you to configure the **Alarms** of the device. The **Property Table** contains the configuration of numeric parameters, while the **Discrete Property Table** is used for the configuration of discrete parameters.

### Logs

This page contains **Log** activity information regarding the alarms that have been activated.
