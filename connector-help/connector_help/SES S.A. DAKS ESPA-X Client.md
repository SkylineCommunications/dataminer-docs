---
uid: Connector_help_SES_S.A._DAKS_ESPA-X_Client
---

# SES S.A. DAKS ESPA-X Client

This driver is designed to make a connection with an espa-x client, and behave as a server. It can process login, heartbeat and P-Start messages.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | V1.00                  |

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

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

To use the element created with this driver, specify the DMA ID and element ID of the main Tetronik DAKS element on the General page. The messages will then be forwarded to that element.
