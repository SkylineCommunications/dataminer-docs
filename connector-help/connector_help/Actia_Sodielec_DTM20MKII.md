---
uid: Connector_help_Actia_Sodielec_DTM20MKII
---

# Actia Sodielec DTM20MKII

This connector can be used to monitor and configure the Actia Sodielec DTM20MKII IO contact device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | V0.1                   |

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

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device. *Default: 1*.

## How to Use

The **General** page displays information about the version and the configuration of the device.

The **Inputs** page displays the **Inputs** and **Analog Inputs** tables. The **Outputs** page displays the **Outputs** table.
