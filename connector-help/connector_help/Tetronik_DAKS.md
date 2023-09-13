---
uid: Connector_help_Tetronik_DAKS
---

# Tetronik DAKS

The Tetronik DAKS is a **fire alarm system** that sends messages and calls to a cellphone to inform people of alarms that are coming into the system.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 2.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 2.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                            |
|-----------|---------------------|-------------------------|-----------------------|------------------------------------------------------------------------------------|
| 2.0.0.x   | No                  | Yes                     | \-                    | [Tetronik DAKS - Department](xref:Connector_help_Tetronik_DAKS_-_Department) |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *2013*).

#### Serial IP Connection - Backup DAKS Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *2013*).

### Initialization

You have to fill in the credentials to log in.

### Redundancy

There is no redundancy defined.

## How to use

To use this element, import the BCID file that you can export from the Tetronik DAKS GUI. Also create the correct structure, departments, group and group types so that you can configure the BCID correctly.

If the BCID is not correctly defined, nothing will be sent to the Tetronik DAKS, so there will be no alarm warnings.
