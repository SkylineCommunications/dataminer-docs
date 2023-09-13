---
uid: Connector_help_Grass_Valley_IQUCP25
---

# Grass Valley IQUCP25

This driver is used to monitor and configure the Grass Valley IQUCP25. The IQUCP25 is a user-configurable multi-channel video-over-IP transceiver developed for use within low-latency and high-bandwidth Ethernet IP networks. It can encapsulate or decapsulate up to 16 SDI signals (depending on the format) using either SMPTE ST 2110 or SMPTE ST 2022-6 encapsulation standards and transport them over 2 x 25 GbE links (SMPTE ST 2022-7) providing "hitless" redundancy switching.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

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

#### Serial Main Connection

This driver uses a smart-serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device, e.g. *192.168.56.201*.
  - **IP port**: The IP port of the device, e.g. *161*.
  - **Bus address**: The bus address of the device, e.g. *0000.10.01.*

### Initialization

While no additional configuration is needed during initialization, on the **General** page, you can find a **progress bar** that shows how long the driver is taking to request all the information from the device during the initial polling.

## How to use

A vendor-specific communication protocol (RollCall) is used to retrieve and send data to the device over TCP. As RollCall is a binary protocol, you will not be able to easily trace the communication via Stream Viewer. However, when you enable the **Debug** toggle button on the **General** page, a human-readable version of all messages that are sent and received will be added in the **element log**. Note that enabling this option will put additional strain on the DataMiner Agent. It is recommended to turn it off when it is no longer needed.

To save bandwidth, this driver does not rely on polling to retrieve data from the device. Instead, it relies on unsolicited update messages that the device sends. Only at the creation of the RollCall session will the driver poll all parameters. Because there is a huge number of parameters, it can take around 15 minutes before all parameters are polled. A progress bar on the general page will indicate the progress.

Most pages and parameters of the driver deal with device configuration. Health/status monitoring information can be found on the **Logging** pages. Bitrates can be found on the **Ethernet** pages and the **Spigot** page.
