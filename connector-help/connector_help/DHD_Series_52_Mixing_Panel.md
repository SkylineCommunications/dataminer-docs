---
uid: Connector_help_DHD_Series_52_Mixing_Panel
---

# DHD Series 52 Mixing Panel

The DHD Series 52 Mixing Panel is an audio router and a mixing console.

This driver uses a serial connection to get the current audio routing configuration and to allow the user to configure the audio routing.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact**                                                   |
|----------------------|------------------|--------------|---------------------------------------------------------------------|
| 1.0.0.x \[Obsolete\] | Initial version. | \-           | \-                                                                  |
| 1.0.1.x \[Obsolete\] | New branch.      | 1.0.0.1      | Different layout; changed DK to I/O labels.                         |
| 1.0.2.x \[Main\]     | New branch.      | \-           | Different layout; changed I/O tables PK. Matrix and router control. |
| 2.0.0.x              | HTTP version.    | \-           | Different layout; different connection type.                        |

### Product Info

| **Range**            | **Supported Firmware**                        |
|----------------------|-----------------------------------------------|
| 1.0.0.x \[Obsolete\] | 7.4.35.1                                      |
| 1.0.1.x \[Obsolete\] | 7.4.35.1                                      |
| 1.0.2.x \[Main\]     | 7.4.35.1                                      |
| 2.0.0.x              | DHD Series51 imx6 Version : 1.1.9.0 - 01/2019 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.

#### HTTP Main Connection\[2.0.0.x\]

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

For the element to function properly, the current router configuration must be retrieved from the Toolbox 5. To do so, go to **File** \> **Export** and click **Export AudioIDs/LogicsIDs**. This will open a new page, where you should select the file **Ext. DHD AudioID/LogicID Export (.\*dpx)**.

The element must then be configured with this configuration in DataMiner. To do so, on the **General** page, specify the **Path** where the configuration file is stored. Then click the **Load Configuration** button to make the driver parse the configuration file and start retrieving the routing information.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

On the **Matrix** page of the element, you can route the audio. This can also be done on the **Audio** **I/O** page, using the **Output Audio** table.

In **range 2.0.0.x** of the driver, the pages have been organized to be as similar as possible to the device web interface.
