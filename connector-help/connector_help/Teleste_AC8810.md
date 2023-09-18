---
uid: Connector_help_Teleste_AC8810
---

# Teleste AC8810

The AC8810 is a dual active output node with optical upstream segmentation. It offers a high output level (Umax 112 QAM/113.0 dBæV) and supports 1.2 GHz downstream and up to 204 MHz upstream frequencies.

This connector can be used to manually set up elements, or, when deployed with the [Teleste HDM100](xref:Connector_help_Teleste_HDM100) connector, it can be used by automatically created elements for AC8810 nodes connected to the controller.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 4.8.13                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                  | **Exported Components** |
|-----------|---------------------|-------------------------|--------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | [Teleste HDM100](xref:Connector_help_Teleste_HDM100) | \-                      |

## Configuration

### Connections

#### Serial Connection - Main

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device. Default value is 2500.

## How to Use

The connector uses **serial** commands to request and push information to and from the node. This communication can be seen in the **Stream Viewer**.

The **Alarm Limits**, **Status**, and **Alarms** pages contain the most important parameters for monitoring.

The **Spectrum** and **Ingress** pages can be used to monitor and import real-time spectrum and ingress measurements that are being performed on the node.

Note: **Changing the** **communication settings** **or device groups** **on the** **Transponder** **page** may cause the element to go into **timeout** for a couple of seconds.
