---
uid: Connector_help_Axon_ACP_GED130
---

# Axon ACP GED130

The **GED130** is an embedded-domain Dolby E to Dolby Digital or Dolby Digital Plus transcoder with fully routable audio description processor.

The **Axon ACP GED130** connector is used to monitor and control the GED130 cards.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3229                   |

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
  - **IP port**: The IP port of the destination. Fixed value: *2071*.
  - **Bus address**: The bus address of the device.

#### IP Connection - Broadcast

This connector uses a smart-serial connection and requires the following input during element creation:

SMART SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: Set the string "any" in this field.
  - **IP port**: The IP port of the destination. Fixed value: *2071.*
  - **Bus address**: The bus address of the device.

## How to use

The **General** page contains general information about the card such as hardware and firmware information and compatibility.

The other pages contain status and control parameters. Each control parameter both displays the current state of the parameter and allows you to change or adjust it.

## DataMiner Connectivity Framework

The **1.0.0.x** range of the Axon ACP GED130 connector supports the usage of DCF and can only be used on a DMA with DataMiner version **8.5.4** or higher.

DCF can also be implemented through the DataMiner DCF user interface and through third-party DataMiner connectors (e.g. a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- **SDI Input 1:** a single fixed interface of type **input**.
- **SDI Input 2:** a single fixed interface of type **input**.
- **SDI Output 1:** a single fixed interface of type **output**.
- **SDI Output 2:** a single fixed interface of type **output**.

### Connections

#### Internal Connections

Depending on the value of **Active Output 1** parameter, the following connections can be established:

- **SDI Input 1** -\> **SDI Output 1**.
- **SDI Input 2** -\> **SDI Output 1**.

Depending on the value of **Active Output 2** parameter, the following connections can be established:

- **SDI Input 1** -\> **SDI Output 2**.
- **SDI Input 2** -\> **SDI Output 2**.
