---
uid: Connector_help_CRE_Technology_GENSYS_2.0
---

# CRE Technology GENSYS 2.0

The **CRE Technology GENSYS 2.0** is a control unit designed for generator electrical panels.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: *502*
  - **Bus address**: *1*

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this connector consists of the data pages detailed below.

## General

On this page, you can **upload** the following **CSV files**:

- **Modbus List**: File with the register address, description, multiplier and units of the parameters. This file must be created manually based on information from the manual.
- Three files that can be exported from the device, containing the address and description of the parameters.

### Modbus Data Table

This page displays information about the Modbus CSV file.

### Data

On this page, you can view information from the device according to the parameters uploaded from the CSV file.
