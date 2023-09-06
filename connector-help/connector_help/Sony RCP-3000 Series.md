---
uid: Connector_help_Sony_RCP-3000_Series
---

# Sony RCP-3000 Series

The Sony RCP-3000 Series enables the monitoring of remote control panels for Sony HDC/HSC/HXC series cameras. This connector executes queries via Ember+ to retrieve this data.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.30                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### IP Connection

This connector uses a smart-serial connection and requires the following input during element creation.

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *9000*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to Use

Ember+ calls are used to retrieve the device information, which is then displayed on the General page of the element.

On the Configuration subpage, you can configure after how much time the connector should enter timeout state if no data is received from the device.
