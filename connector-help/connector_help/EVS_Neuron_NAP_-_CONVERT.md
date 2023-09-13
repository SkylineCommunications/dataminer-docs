---
uid: Connector_help_EVS_Neuron_NAP_-_CONVERT
---

# EVS Neuron NAP - CONVERT

This connector is designed for the monitoring of the convert function of the EVS Neuron.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### IP Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (fixed value: *2072*).

## How to use

The connector does not have a polling timer. It only polls the data at element startup; however, there is also a button available that allows you to trigger the polling manually.

After element startup, the connector can also receive events (unsolicited messages).

You can track the progress of this data retrieval through two loading bars. These bars indicate the polling status for the device's functionalities.

## DataMiner Connectivity Framework

The **1.0.0.x** range of the EVS Neuron NAP - CONVERT connector supports the usage of DCF and can only be used on a DMA with DataMiner version **8.5.4** or higher.

DCF can also be implemented through the DataMiner DCF user interface and through third-party DataMiner connectors (e.g. a manager).
