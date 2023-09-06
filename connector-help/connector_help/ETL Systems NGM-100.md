---
uid: Connector_help_ETL_Systems_NGM-100
---

# ETL Systems NGM-100

This protocol monitors and controls the ETL System NGM-100 device. This NiGMa (pronounced ENIGMA) matrix is intended to operate over frequency bands IF. It can be configured as distributive (input can be connected to one or more outputs) or combining (output can be connected to one or more inputs) by the type of RF cards installed in the module.

## About

### Version Info

| **Range**           | **Key Features** | **Based on** | **System Impact** |
|---------------------|------------------|--------------|-------------------|
| 1.0.0.x\[SLC Main\] | Initial Version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | e554 Version 1.4       |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: \[The polling IP or URL of the destination.\]
- **IP port**: \[The IP port of the destination.\]

SNMP Settings:

- **Get community string**: \[The community string used when reading values from the device. (default: *public*)\]
- **Set community string**: \[The community string used when setting values on the device. (default: *private*)\]

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

### General

This General page contains default **System** parameters and commands. There are 3 sub pages: **Information**, **Monitoring** and **Configuration**.

### Matrix

This page displays the device **Matrix**.

### Status

This page contains information about the Inputs and Outputs **Card Status**.

### Alarm

Displays the Alarm information for the **Chassis,** the **Comunication** and **Summary** Alarms.

### Input Settings

This page displays the **Input Settings**.

### Output Settings

This page displays the **Output Settings**.

### Configuration

This page contains the **Matrix Configuration**.
