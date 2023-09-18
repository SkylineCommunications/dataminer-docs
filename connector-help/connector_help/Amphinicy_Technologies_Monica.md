---
uid: Connector_help_Amphinicy_Technologies_Monica
---

# Amphinicy Technologies Monica

The Amphinicy Monica connector integrates a monitoring and control software suite with the same name. This integration provides a monitoring and control solution for different types of instruments (e.g. BUC and switches).

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                       | **Based on** | **System Impact** |
|----------------------|----------------------------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[Obsolete\] | Initial version: - Instruments and parameter values - Active alarms                                                                    | \-           | \-                |
| 1.0.1.x \[Obsolete\] | \- Update of the API request messages - Implementation of DVEs                                                                         | 1.0.0.x      | \-                |
| 1.0.2.x \[SLC Main\] | \- Moved the Generic Instruments Details table to the Instruments Generic Details page. - Updated instrument parameter values parsing. | 1.0.0.x      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | v6.0.0                 |
| 1.0.1.x   | v6.0.0                 |
| 1.0.2.x   | v6.0.0                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                                                              |
|-----------|---------------------|-------------------------|-----------------------|----------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                                                                                                                   |
| 1.0.1.x   | No                  | Yes                     | \-                    | [Amphinicy Technologies Monica - Instrument](xref:Connector_help_Amphinicy_Technologies_Monica_-_Instrument) |
| 1.0.2.x   | No                  | Yes                     | \-                    | [Amphinicy Technologies Monica - Instrument](xref:Connector_help_Amphinicy_Technologies_Monica_-_Instrument) |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

When the element has been created, specify user credentials (**username** and **password**) with the necessary privileges to access the product's API.

Optionally, go to the **Poll Settings** subpage and reconfigure the preferred poll cycles for each identified session.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The connector implements the instruments and parameter monitoring, as well as the active alarms. The element has the following data pages:

- **General** page and **Poll Settings** subpage: Specify the user credential and click login to start communication with the product.
- **Instruments Manager** page: A table overview with the instruments available in the product, with their overall state and connection status.
- **Instruments Generic Details** page: Detailed information about instruments, such as parameter names and current values.
- Active alarms can be monitored from the **Alarms** page, where you can acknowledge and purge alarms.
- **DVE Management** page: A table specifying the instruments available to create DVEs and another table with the created DVEs.

This connector can export a different connector based on the retrieved data and user input. The exported connector name can be found under "Exported Components".
