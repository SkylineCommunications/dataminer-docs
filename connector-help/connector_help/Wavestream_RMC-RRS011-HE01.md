---
uid: Connector_help_Wavestream_RMC-RRS011-HE01
---

# Wavestream RMC-RRS011-HE01

This is a serial protocol for the **Wavestream Redundancy Controller**. It can be used to monitor and configure the device.

## About

The connector uses a **serial** connection to retrieve information from and send information to the device.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | V1.5                        |

### Exported connectors

| **Exported Connector**             | **Description** |
|-----------------------------------|-----------------|
| Wavestream RMC-RRS011-HE01 - SSPA | SSPA            |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device, by default *4001*.
  - **Bus address**: The bus address of the device, by default *0*.

## Usage

### General

This page displays all the parameters of the device. This includes general information like **Model Number**, **Serial Number** and **Version**, and more specific parameters, such as **Redundancy Setting**, **BaseBass Switch States**, etc.

### SSPA

This page contains a table with the connected SSPA devices.
