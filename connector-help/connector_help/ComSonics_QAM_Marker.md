---
uid: Connector_help_ComSonics_QAM_Marker
---

# ComSonics QAM Marker

The ComSonics QAM Marker connector is an HTTP-based connector that can be used to monitor and configure the ComSonics QAM Marker.

The ComSonics QAM Marker generates a non-interfering marker signal that is inserted into downstream cable channels.

## About

### Version Info

| **Range**            | **Key Features**                                                        | **Based on** | **System Impact** |
|----------------------|-------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version, featuring monitoring and configuration of marker data. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

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
- **IP port**: The IP port of the destination. Set to *80* by default.
- **Device address**: The bus address of the device. Set to *BypassProxy* by default.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

You can monitor and configure the marker data using the parameters on the **General** page.

The **Network Settings** page can be used to monitor the network data. This page contains a subpage **Edit Network Settings**, which allows you to edit the network configuration using local parameters, saving the values to the device in 1 request. Saving the network settings to the device will cause the device to reboot, which may take some time. This will also cause the marker settings to be lost unless the front panel reset button is pressed or the settings are manually reconfigured.
