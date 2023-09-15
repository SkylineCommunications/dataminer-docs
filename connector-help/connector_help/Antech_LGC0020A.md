---
uid: Connector_help_Antech_LGC0020A
---

# Antech LGC0020A

The Antech LGC0020A is an RF detector that can be used to provide redundancy for multiple RF amplifiers or RF sources.

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

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION (via Serial Gateway):

- Interface connection:

  - **IP address/host**: The polling IP of the device, e.g. *127.0.0.1*.
  - **IP port**: The IP port of the device, e.g. *4006.* Required.
  - **Bus address**: The bus address of the device, e.g. 64. Required.

### Initialization

No extra configuration is needed.

### Redundancy

No redundancy is defined in the connector.

## How to Use

You can find all the information you need to monitor the device on the General data page.
