---
uid: Connector_help_Vizrt_Viz_Engine
---

# Vizrt Viz Engine

Viz Engine is a rendering engine at the core of Vizrt's real-time graphics solutions. 2D and 3D animated scenes designed in Viz Artist can be rendered in real time as high-end animations, and the output can be SD or HD video.

The 1.0.0.x range of this connector uses SNMP to poll information from the Viz Engine. The 1.1.0.x range uses only HTTP and polls the layers and GFX configuration.

## About

### Version Info

| **Range**            | **Key Features**                            | **Based on** | **System Impact**                                                                  |
|----------------------|---------------------------------------------|--------------|------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version (SNMP)                      | \-           | \-                                                                                 |
| 1.1.0.x \[SLC Main\] | \- Removed SNMP support- Added HTTP support | \-           | The data shown in this branch is not the same as the data shown in branch 1.0.0.x. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3.14.5.104390          |
| 1.1.0.x   | 4.3.0.60026            |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection - range 1.0.0.x

The connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

#### HTTP Main Connection - range 1.1.0.x

The connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination. (default: *61000*)

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

Both branches of this connector only serve monitoring purposes.

### Version 1.0.0.X - SNMP Only

System parameters are displayed on the **General** page.

There is also a page for each **channel**, which displays information likethe Connection State, Database Connection, Video Input Status, Clip Status, Frame Rate, Texture Memory Free, Texture Memory Total, Texture Memory Used, etc.

This connector handles traps regarding each channel and updates the parameter values accordingly.

### Version 1.1.0.X - HTTP Only

As SNMP is decommissioned in the upcoming device firmware versions, SNMP info has been removed in this range and HTTP support has been added. We recommend that you use this range, since any new features are expected to be implemented in this main range.

On the **General** page in this range, you can find the **firmware version** of the device and the **On-Air Status** of the renderer.

The **Layers Overview** page shows a tree control overview of the configuration of each layer. For each layer, you can see its **currently loaded scene**.
