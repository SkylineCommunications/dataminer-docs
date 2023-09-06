---
uid: Connector_help_Adaura_Technologies_AD-USB_R3_Series
---

# Adaura Technologies AD-USB R3 Series

The Adaura Technologies USB/Ethernet RF Attenuator R3 Series is a series of high-performance digitally programmable attenuators with frequency coverage to 20 GHz with USB and Ethernet interfaces.

Multiple independent channels are housed in a single compact enclosure. Each unit is powered and controlled via a single USB connection to a PC and offers Ethernet connectivity.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3.00                   |

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
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

On the **General** page, you can view generic device and firmware information.

The **Configuration** page allows you to make changes to the Ethernet settings.

The remaining data pages serve as controls to operate the device efficiently.
