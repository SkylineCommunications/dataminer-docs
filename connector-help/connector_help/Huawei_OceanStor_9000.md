---
uid: Connector_help_Huawei_OceanStor_9000
---

# Huawei OceanStor 9000

The Huawei OceanStor 9000 features a symmetric distributed architecture that delivers superior performance, extensive scale-out capabilities, and a super-large single file system providing shared storage for unstructured data. The OceanStor 9000 is ideal for Big Data service scenarios, such as film and TV, satellite mapping, gene sequencing, energy exploration, and scientific research, education and provider services. With advanced processing features and data lifecycle management, the OceanStor 9000 helps customers build the industry's most efficient Big Data storage capabilities.

## About

OceanStor 9000 is a scale-out storage system specifically designed for massive unstructured data storage. It allows SNMP communication.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not required.

SNMP Settings:

- **IP port**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General

This is the default page of the connector. It contains several standard parameters, including the **Description**, **Object ID**, **Up Time** and **Name**.

The page also includes **Services** parameters, which identify the active OSI layers, as well as the **System Performance Table**.

### Status

This page contains several tables, such as the **Disk**, **Memory** and **CPU** tables.

### System

This page contains several tables, such as the **Node** and **Cluster** tables.

### Services

This page contains several tables, such as the **CIFS Share** and **File System Service** tables.

### Users

This page contains several tables, such as the **Local User** and **Local Group** tables.

### Device Counters

This page displays several counters related to input and output parameters.

### Configuration

On this page, several settings can be configured, such as the **Performance Switch** and **Performance Interval**.
