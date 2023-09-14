---
uid: Connector_help_Rohde_Schwarz_OSP_120
---

# Rohde and Schwarz OSP 120

The Rohde Schwarz OSP 120 is a modular switch and control platform that enables users to perform RF switch and control tasks quickly. The flexibility of the Rohde Schwarz OSP 120 permits a broad scope of applications ranging from simple RF switch functions to the RF wiring of complex systems such as EMC systems.

The connector for the Rohde Schwarz OSP 120 uses serial communication to poll and control the equipment, allowing the user to enable (switch) a given path and have an overview of the modules at hand.

Two timers are used to poll the information from the device: one that polls every ten seconds for fast-varying information and another that polls every hour for semi-static information.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.51                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600*.
  - **Databits**: Databits specified in the manual of the device, e.g. *7*.
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1*.
  - **Parity**: Parity specified in the manual of the device, e.g. *No.*
  - **FlowControl**: FlowControl specified in the manual of the device, e.g. *No*.

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this connector consists of the data pages detailed below.

### General

This page displays the following information from the device:

- System version
- Vendor
- Model
- Instrument Serial Number
- Firmware Version
- Option Identification
- Internal Test

It also displays a table with **Hardware Information**.

### Active Path

This page displays the list of paths supported by the device in the **Path List table.** It also allows you to select which file to load with the path list using the **Load File Name** parameter, and to select a path with the **Activate Path** parameter.

### Modules

This page displays an overview of the equipment modules in the **Modules Overview** table, with each relay's name, switch properties, and channels (input and output).

### Polling

This page displays the polling commands used for the relay channels in the **Relays (Channels) Polling** table and the respective results of the listed commands.
