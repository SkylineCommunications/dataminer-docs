---
uid: Connector_help_AJA_KUMO
---

# AJA KUMO

KUMO routers provide a dense routing solution for use in facilities, OB trucks, post suites, and more. KUMO is available in multiple connector densities, in 3G-SDI and 12G-SDI options. KUMO supports routing of uncompressed or raw 8K/UltraHD2/4K/UltraHD/2K/HD/SD signals with embedded audio throughout a production or post facility.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 4.7.0.104              |

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
- **IP port**: The IP port of the destination (*default: 80*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

You can find the matrix on the **Matrix** page, which is synchronized with the tables from the **Sources** and **Destinations** pages. Editing the tables affect the matrix and vice versa.

You can modify the network interface of the device on the **Network** page.

On the **Alarm** page, you can modify alarm thresholds, as well as modify, monitor, and suppress different alarms.
