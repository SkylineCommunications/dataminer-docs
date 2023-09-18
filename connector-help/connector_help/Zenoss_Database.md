---
uid: Connector_help_Zenoss_Database
---

# Zenoss Database

The Zenoss Database connector polls a database using a JSON interface and provides an overview of devices and their events.

The connector will create **Zenoss Database - Element** DVEs based on the information retrieved from the database.

## About

### Version Info

| **Range**            | **Key Features**        | **Based on** | **System Impact** |
|----------------------|-------------------------|--------------|-------------------|
| 1.0.0.x              | Initial                 | \-           | \-                |
| 2.0.0.x              | HTTP JSON; DVE version. | \-           | \-                |
| 2.1.0.x \[SLC Main\] | Device components.      | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**       |
|-----------|------------------------------|
| 1.0.0.x   | \-                           |
| 2.0.0.x   | Zenoss 6.2.0 r138 Enterprise |
| 2.1.0.x   | ZenossCore 5.3.3 r419        |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                          |
|-----------|---------------------|-------------------------|-----------------------|----------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | No                      | \-                    |                                                                                  |
| 2.0.0.x   | No                  | Yes                     | \-                    |                                                                                  |
| 2.1.0.x   | No                  | Yes                     | \-                    | [Zenoss Database - Element](xref:Connector_help_Zenoss_Database_-_Element) |

## Configuration

### Connections

#### HTTP Connection - Main

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

The connector requires the **System.Web.Extensions.dll**. Rename this file to **SLSystem.Web.Extensions.dll** and place it in the *C:\Skyline DataMiner\ProtocolScripts* folder on the DMA.

In addition, on the **Security** page of the element, you need to specify the **Username** and **Password** to communicate with the database using JSON.

## How to use

- The **Devices** page shows an overview of retrieved Zenoss devices. You can create a DVE for a device using a button in the table. A button is also available that allows you to manually refresh this table.
- The **Events** page shows an overview of events that have occurred on the device.
- The **Components** page shows an overview of components available on the device.
