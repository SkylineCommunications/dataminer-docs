---
uid: Connector_help_Carel_PCO5_Free_Air
---

# Carel PCO5 Free Air

This driver allows you to monitor and configure the Carel PCO5 Free Air air conditioning system.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | /                      |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.
  - **Bus address**: The bus address of the device (range: *1* - *32*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

This driver allows you to monitor and trend the temperature and machine status parameters. In addition, you also have access to the alarm parameters that will indicate if something is wrong with certain components of the product.

On the Settings page, you can control the temperature- and fan-related settings.

The Exception Code parameters on the Communication page will indicate if something goes wrong with the API calls.
