---
uid: Connector_help_Synamedia_VSM_License_Usage_Monitor
---

# Synamedia VSM License Usage Monitor

The Synamedia VSM (Video Service Manager) connector provides a set of tools for the monitoring and management of the licenses of Synamedia's Video Processing Solutions.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                                        |
|-----------|-------------------------------------------------------------------------------|
| 1.0.0.x   | Product Version: 14.2.0 \| VSM Build Version: 20220112-142508_035e379aa1_2289 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

When the element has been created, on the **Configuration** page, specify the username and password for API access.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The Synamedia VSM connector maps all monitored appliances or software instances of for instance DCM, vDCM, etc. into the VSM topology views.

The **Resources** page contains information related to DCM resources (e.g. name, software version, model, responding, alarm and device states, etc.).

License information related to availability and usage per resource and function is available under **License Usage**, **License Function Usage**, and **License Central**.
