---
uid: Connector_help_NBCU_Merlin_Collector
---

# NBCU Merlin Collector

This connector collects asset information, including program data. This information is then sent to the NBCU VOD Manager.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | 1.0.0.1      | \-                |

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

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

#### HTTP HTTP Connection - Merlin Token Request Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

#### HTTP HTTP Connection - Merlin Info Request Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

#### HTTP HTTP Connection - Media Token Request Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

Some initial configuration is required on the **General** page:

- In order to get the token for the Merlin and Media connection, specify the **Merlin Client ID** and **Merlin Client Secret** (for the Merlin token) and the **Merlin Username** and **Merlin Password** (for the Media token).
- To filter environment results such as production or staging, the **Account Number** must be filled in.
- To be able to send data to the VOD Manager app, specify the DataMiner ID, element ID and parameter ID, separated by slashes ("/"), in the **VOD Manager APP ID** parameter.

### Redundancy

There is no redundancy defined.

## How to use

Before you use the element, make sure everything is correctly configured on the General page (see "Initialization").

On the **Mapping** page, you can configure the mapping of the Merlin information so it can be translated to Witbe by the VOD Manager.

When everything has been correctly configured, the table on the **VOD GUID** page will be filled in with the collected information.
