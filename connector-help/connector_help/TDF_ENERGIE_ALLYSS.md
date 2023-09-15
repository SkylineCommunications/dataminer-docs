---
uid: Connector_help_TDF_ENERGIE_ALLYSS
---

# TDF ENERGIE ALLYSS

The TDF Energie Allyss connector is a virtual connector that maps the parameters of the Energy system via the TDF Jbus PLC driver.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## How to use

The element has the following data pages:

- **General**: Allows you to configure which TDF Jbus PLC element to connect to.
- **Systeme**: Displays the device system information.
- **Alarmes**: Displays the device alarm information.

## Notes

The names and descriptions of the parameters are in French, since this connector is intended only for TDF.
