---
uid: Connector_help_TDF_ALLISS_Transmitter
---

# TDF ALLISS Transmitter

The TDF ALLISS Transmitter driver is a virtual driver that maps the parameters of the transmitter system via the TDF Jbus PLC driver.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

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

This driver uses a virtual connection and does not require any input during element creation.

## How to use

- **General**: Allows you to configure which TDF Jbus PLC element to connect to.
- **Emetteur**: Displays the Emetteur table information.
- **Annexe**: Displays the Annexe table information.
- **Discordance**: Displays the status of the Discordance parameters.
- **Frequence**: Displays the frequency values.
- **Matrix**: Displays the device matrix.

## Notes

The names and descriptions of the parameters are in French, since this driver is intended only for TDF.
