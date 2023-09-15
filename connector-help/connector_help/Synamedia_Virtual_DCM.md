---
uid: Connector_help_Synamedia_Virtual_DCM
---

# Synamedia Virtual DCM

The Synamedia Virtual DCM is a device that represents virtualized and software-based video processing, providing advanced video, audio, and metadata processing for live multiformat video delivery. It enables broadcasters, content providers, and service providers to deliver viewing experiences that meet their service requirements for picture quality, bandwidth efficiency, and multiscreen transcoding.

## About

### Version Info

| **Range**            | **Key Features**                                | **Based on** | **System Impact** |
|----------------------|-------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version: SRT and Zixi reads and writes. | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Changed layout. Added Alarms Table.             | 1.0.0.3      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | V21_00_01              |
| 1.0.1.x   | V21_00_01              |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTPS connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination. Start with *https://IP*.
- **IP port**: The IP port of the destination (default: *8443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

#### HTTP Connection - Prometheus

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *9123*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

On the HTTP page, you need to provide the credentials to log in to the device.

If you want to make use of the performance data in Prometheus, you may need to enable this on the device. To do so, in the device GUI, go to Status \> Diagnostics. For example, to enable Zixi performance data, set the value for "diag.zixi.log_to_prometheus" to "true".

## How to use

When the correct credentials have been specified on the HTTP page, the connector can retrieve information from the device. You can speed up or slow down **polling** in the poll manager table. You can also disable polling to reduce the load on the device and on DataMiner.

All the calls except those related to Prometheus data are REST calls. The Prometheus data is retrieved with a GET request to the correct IP and port.

To be able to change parameters on the device, the polling mode must be set to **Edit Mode**. You can do this in the main table of each section. For example, on the Source SRT Settings page, the first table contains the generic information regarding the SRT source. In this table you can enable the Edit Mode. This will highlight the rows related to that source in all the tables and enable edit controls. When you are done configuring the source, click **Save Changes** to push the data to the device.

While **Edit Mode** is active, **no updates** will be shown from the device. In addition, after a specific amount of time, Edit Mode will **automatically switch back to Polling Mode**. You can configure this amount of time on the **Configuration** page.
