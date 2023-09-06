---
uid: Connector_help_Vitec_T9261
---

# Vitec T9261

The Vitec T9261 can function as either an Encoder (T9261-E) or a Decoder (T9261-D), depending on the configuration.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2021-06-10_15-56-09    |

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
- **IP port**: The IP port of the destination. (default: *80*)

### Initialization

During initialization, an HTTP **username** and **password** will need to be provided on the **HTTP Config** subpage of the **General** page. The device will not be polled without the HTTP credentials in place.

## How to use

This connector uses an HTTP webservice to retrieve system, input, output, and audio information related to the device. Based on the device's role (encoder vs decoder), only the relevant information will be populated.

The **General** page and **System** subpage show information related to the Vitec system statistics.

The **Encoder** and **Decoder** pages display information related to the encoder/decoder input, output, and audio levels.
