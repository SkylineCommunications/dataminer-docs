---
uid: Connector_help_Ateme_Titan_Mux_(Lite)
---

# Ateme Titan Mux (Lite)

This connector allows you to check output information and also to configure some parameters of the programs, such as BISS Mode and Session Word.

## About

### Version Info

| **Range**            | **Key Features**                                   | **Based on** | **System Impact** |
|----------------------|----------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Allows configuration of BISS Mode and Session Word | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.5.7.3-0              |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

On the **Security** page, you must specify the correct **Username** and **Password** to be able to poll information.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

On the **General** page of the element, you can check various output information. In addition, in the Programs table, you can configure the **BISS Mode** and **BISS Session Word**.

On the **Security** page, the **Username** and **Password** to poll information from the device must be specified.
