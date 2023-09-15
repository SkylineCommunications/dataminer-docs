---
uid: Connector_help_SES_S.A._DAKS_xLink_Client
---

# SES S.A. DAKS xLink Client

This is a smart-serial connector which receives messages from clients that are using xlink communication.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | No Firmware            |

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

  - **IP address/host**: *any*
  - **IP port**: *345*

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The connector retrieves all the serial communication and places the responses in a table on the General page. It will also send the responses to the Tetronik DAKS connector.
