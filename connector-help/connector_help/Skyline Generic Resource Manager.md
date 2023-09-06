---
uid: Connector_help_Skyline_Generic_Resource_Manager
---

# Skyline Generic Resource Manager

This is a generic driver with four tables that can be used to create four types of resources in the DataMiner Service & Resource Management Solution.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.1 \[SLC Main\] | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this driver consists of the following data pages:

- **General**: Allows you to define the number of rows that will be created when the "Add function" button is clicked (on the relevant function page).
- **Function**: These pages are used to link rows and resources.
- **IF**: These pages contain interface tables with information about transmitter and receiver parameters.

## DataMiner Connectivity Framework

The **1.0.0.x** driver range of the Skyline Generic Resource Manager protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner Third Party protocols (for instance a manager).

## Notes

No Visio files are needed.
