---
uid: Connector_help_Grass_Valley_IQUCP
---

# Grass Valley IQUCP

The Grass Valley IQUCP is a 3G/HD/SD-SDI multi-channel IP transceiver.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 17.0a.122_v0.36.14     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *2050*).
  - **Bus address**: The bus address of the device, in the format *UU.PP* or NNNN.UU.PP, where UU is the unit address and PP is the unit port and NNNN is the net address. For example: *01.01 or 0300.00.00*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

A vendor-specific communication protocol (RollCall) is used to retrieve and send data to the device over TCP. As RollCall is a binary protocol, you will not be able to easily trace the communication via Stream Viewer. However, you can use the **Debug toggle button** on the **General** page instead. When this button is enabled, a human-readable version of all messages that are sent and received is added to the element log. Note that enabling this option will put **additional strain** on the DataMiner Agent. It is therefore recommended to turn it off when it is no longer needed.

To save bandwidth, this connector does not rely on polling to retrieve data from the device. Instead, it relies on unsolicited update messages that the device sends. Only at the creation of the RollCall session will the connector poll all parameters. Because there is a huge amount of parameters, it can take around 10 minutes before all parameters are polled. A progress bar is available on the General page that gives an indication of the progress.

Most pages and parameters of the connector deal with device configuration. For health/status monitoring, those are located on the **Logging** pages. Bitrates can be found on the **Ethernet** pages and the **Spigot** page.
