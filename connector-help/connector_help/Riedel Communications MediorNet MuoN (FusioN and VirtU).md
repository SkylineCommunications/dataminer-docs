---
uid: Connector_help_Riedel_Communications_MediorNet_MuoN_(FusioN_and_VirtU)
---

# Riedel Communications MediorNet MuoN (FusioN and VirtU)

The Riedel Communications ST2110 - SDI Gateway is used to encapsulate or de-encapsulate SDI data from/to IP ST2110. This connector allows you to monitor the encapsulation and de-encapsulation process. It is based on Embox3u and Embox6 device data.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                     | **Based on** | **System Impact**             |
|----------------------|----------------------------------------------------------------------------------------------------------------------|--------------|-------------------------------|
| 1.0.0.x              | Initial version.                                                                                                     | \-           | \-                            |
| 1.0.1.x \[SLC Main\] | \- Added DCF based on Interfaces Table (PID:1200).- Added support to switch polling IP between available interfaces. | 1.0.0.2      | Increased load on the system. |

### Product Info

| **Range** | **Supported Firmware**  |
|-----------|-------------------------|
| 1.0.0.x   | Embox6 - 3.6.1615393321 |
| 1.0.1.x\> | Embox6 - 3.6.1615393321 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector consists of the following data pages:

- **Overview:** Displays a tree view with the main information of the connector (devices, sources, and flows).
- **General:** Contains general information about the device.
- **Network:** Contains information about device connections and Ethernet configuration.
- **Reference Clock:** Contains information about the status and controls of the device reference clocks.
- **Flows:** Contains information related to each flow type (video, audio, or ancillary).
- **Devices:** Contains device information (label, type, node ID, etc.) and a table for each device type (sources, senders, and receivers).
- **Devices Flows:** Contains device flow communication data (engine ID, type, packet counter and sequence error counter).
- **Sources:** Contains the sources related to the devices on the Devices page.
- **Senders:** Lists the devices that are configured as a sender.
- **Receivers:** Lists the devices that are configured as a receiver.
- **Ports:** Displays the port configuration and ports telemetry (temperature, Tx power and Rx power).
- **SDI:** Displays the SDI configuration for each SDI type (input, audio, and output).
- **Web Interface:** Contains the web interface of the device.

## DataMiner Connectivity Framework

The **1.0.1.x** range of the Riedel Communications MediorNet MuoN (FusioN and VirtU) connector supports the usage of DCF and can only be used on a DMA with DataMiner version **8.5.4** or higher.

### Interfaces

#### Dynamic interfaces

Physical dynamic interfaces:

- Each entry in the Interfaces Table (PID:1200) generates a new interface of type **inout**.
