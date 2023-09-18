---
uid: Connector_help_Aperi_Ethernet_Pass_Through
---

# Aperi Ethernet Pass Through

This is an **HTTP** connector that is used to monitor and configure the **Aperi Ethernet Pass Through** equipment.

## About

The information on tables and parameters is retrieved via **HTTP** communication.

### Version Info

| **Range**     | **Description**                | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version.               | No                  | Yes                     |
| 1.0.1.x \[SLC Main\] | Streamlined all Aperi connectors. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.0.3                       |
| 1.0.1.x          | 1.0.3                       |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: The Microserver slot ID. (Range: 1 - 5)

### Configuration

Before any of the element's functions become available, a valid username and password first need to be specified in order to connect to the device.

To do so, on the **Security** page, fill in the correct **username** and **password**.

## Usage

### General

This page displays the **System Information**, **Main Board Info**, **System Configuration**, **Resources Info** and **System Utilization**. You can find information about **System Time**, **System Description**, **System Location**, **System Contact**, **System Up Time** and other general parameters.

The page contains the following page buttons:

- **Security Settings**: On this page, you can define the **Username** and **Password** to connect to the device. The page also displays the status of the connection.
- **Messanine Board Info**: This page displays information about all the Messanine board-related parameters.

### SFPs \[1.0.1.x\]

This page contains the SFPS table.

### Ethernet

This page displays the **Ethernet Network Ports** and **SFPS** tables, with statistics regarding the **Network Interfaces** (Received and Transmitted number of frames, etc.) and information related to the **Card Video Physical Interfaces**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
