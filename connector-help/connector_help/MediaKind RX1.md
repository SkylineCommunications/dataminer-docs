---
uid: Connector_help_MediaKind_RX1
---

# MediaKind RX1

The MK RX1 is a multi-codec multi-service professional decoder.

The MediaKind RX1 connector focuses on monitoring the configuration found in the device. It gives an overview of the inputs, decryption settings, demodulation settings, and outputs.

## About

### Version Info

| **Range**            | **Key Features**                                          | **Based on** | **System Impact**                                                       |
|----------------------|-----------------------------------------------------------|--------------|-------------------------------------------------------------------------|
| 1.0.0.x              | Initial version (monitoring of configuration parameters). | \-           | \-                                                                      |
| 1.0.1.x \[SLC Main\] | Configurable display key on Active Alarms.                | 1.0.0.3      | May affect visual overviews, Automation scripts, trending, alarms, etc. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 11.0.4.0               |
| 1.0.1.x   | 11.0.4.0               |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).

### Initialization

No extra configuration is needed. The device does not require authentication.

### Redundancy

There is no redundancy defined.

## How to use

The connector is only used for monitoring, so no special settings are required.

## Notes

Currently, the API provided by the vendor is still in its infancy. This connector has been developed using the information available in version 3.0 of the API. However, this means that only the configuration on the device can be monitored, not the status of the signals and processes.
