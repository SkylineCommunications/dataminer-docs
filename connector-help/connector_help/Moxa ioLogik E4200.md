---
uid: Connector_help_Moxa_ioLogik_E4200
---

# Moxa ioLogik E4200

The Moxa ioLogik E4200 protocol sets and configures the modules the Moxa ioLogik E4200 I/O contact interface device.

## About

The driver displays each individual module of the device in a list. Its inputs are visible, as well as its outputs, should there be any. There is also an overview table for all inputs and outputs.
The driver uses SNMP to get this data.

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | V1.5 Build 14011615         |

## Installation and configuration

### Creation

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not used.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General

The General page contains general information about the device, such as **Server Model**, **System Live Time, Firmware Version, Total Number Of Modules.**

### Config

The config page is used to **import descriptions.**

### Module 1-15

The Modules pages contains the **Input Table** and **Output Table** of a single module. It also contains several configuration parameters for each module.

### Module Overview

This page contains an overview of all the Input and Output values. These tables can be enabled by enabling a togglebutton.

### Web Interface

The Web Interface page links the protocol with the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
