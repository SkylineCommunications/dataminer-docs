---
uid: Connector_help_Ross_Video_Matrix
---

# Ross Video Matrix

The Ross Matrix Router is a routing, multi-viewer and signal processing platform for studios, OB vans and flypacks. It provides a compact combination of routing, multi-viewers, audio processing and control.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **Type of port:** Select UDP or TCP.
  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this driver consists of the following data pages:

- **General**: Allows you to define the matrix size using the **Number of Inputs** and **Number of Outputs** parameters. Also displays the **Last KeepAlive Timestamp**, which shows the last keep alive timestamp sent by the matrix.
- **Matrix**: Displays the **Matrix**.
- **Labels**: Displays the **Inputs** and **Outputs** tables of the matrix.
