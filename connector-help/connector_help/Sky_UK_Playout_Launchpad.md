---
uid: Connector_help_Sky_UK_Playout_Launchpad
---

# Sky UK Playout Launchpad

This connector can be used to communicate with a DAL station and a Helm to activate a scenario.

The connector uses WCF communication, with SOAP requests to a maximum of two IPs at the same time.

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
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device (default: *4003*).
- **Device address**: The device address (default: *ByPassProxy*).

#### HTTP SecondIP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device (*default*: 4003).
- **Device address**: The device address.

## How to Use

On the **Control** page of the element, you can **Launch**, **Stop** or **Retrieve** the current active scenario for each system. You need to specify a scenario name to be launched on the DAL station or on the Helm, and only then the scenario can be stopped.

Clicking the **Query** button will retrieve the current scenario for both systems. In case there is no scenario for a system, *NA* will be displayed.

You can disable the connection with the Helm by toggling from *Enabled* to *Disabled*.
