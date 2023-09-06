---
uid: Connector_help_Generic_Dialog_Integration_Manager
---

# Generic Dialog Integration Manager

This driver is intended to collect the parameter IDs from the different protocols and versions in the Dialog DMS.

## About

### Version Info

| **Range**            | **Key Features**                                 | **Based on** | **System Impact** |
|----------------------|--------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | DWS Calls: GetProtocolParameterInfoInterpolation | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.1.1                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

Fill in the **Username**, **Password** and **IP Address for Sessions.** If any of these parameters are empty or not valid, the connect request will not be executed and nothing will happen.

The **Debug Parameter** is disabled by default, so that debug pages are hidden. To view these pages, enable the parameter.

## How to use

The driver executes the logic daily or on demand when the **Update** button on the Elements page is pressed. When a valid Username, Password and IP Address have been specified, the driver executes the Connect App Request (via DWS). With a valid token, the next step is the GetElementInfo request.

The response is processed in order to fill in the **Elements Table**. The index of the Elements Table is used to compose a buffer to request the protocol info, which includes the protocol name, version and all its parameters. **NOTE**: Not all protocols are processed because more than 1 element uses the same protocol name and version.

The tables **Dialog Protocols Overview** and **Unsupported Dialog Protocols Overview** are filled in after the buffer logic finishes.
