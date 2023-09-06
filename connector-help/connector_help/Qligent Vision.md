---
uid: Connector_help_Qligent_Vision
---

# Qligent Vision

This connector is solely used to switch and monitor the Qligent Vision Linux servers. Monitoring only happens on the processes related to the redundancy switching.

## About

### Version Info

| **Range**            | **Key Features**       | **Based on** | **System Impact**    |
|----------------------|------------------------|--------------|----------------------|
| 1.0.0.x              | Initial version.       | \-           | \-                   |
| 1.0.1.x \[SLC Main\] | SNMP connection added. | 1.0.0.2      | New SNMP connection. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3.10.2                 |
| 1.0.1.x   | 3.10.2                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a SNMP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default:161).

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *80*).
  - **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

#### SERIAL Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

- **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600*.
  - **Databits**: Databits specified in the manual of the device, e.g. *7*.
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1*.
  - **Parity**: Parity specified in the manual of the device, e.g. *No*.
  - **FlowControl**: FlowControl specified in the manual of the device, e.g. *No*.

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.
  - **Bus address**: The bus address of the device.

### Initialization

To make sure the connector can set and retrieve data, on the **General** page, you need to specify the **SSH** and **HTTP** credentials.

## How to use

For redundancy purposes, two elements are always needed. On the **General** page, you can set the configuration for these elements. One element will operate as the main server and the other as the backup server. You can configure this by selecting the corresponding **Server Role**.

The **SSH** and **HTTP** **credentials** must be filled in on both the main and the backup element. The configuration parameters (Server Role, Backup Element), only need to be set on the main element.

When one element is set as the main server, you can select the backup element in the dropdown box. When you apply this setting, the correct settings will automatically be set on the backup element.

Based on the **Server Role**, different switching commands will be executed.
