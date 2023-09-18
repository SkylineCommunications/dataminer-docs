---
uid: Connector_help_Sky_UK_STB_DRX-595
---

# Sky UK STB DRX-595

This connector can be used as a remote control for the Sky DRX-595 set-top box.

## About

This connector uses the RFB protocol for **serial** communication and the UPnP interface for **HTTP** communication. After the serial communication has been established, only commands can be sent to the device, as there is no response.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version | No                  | Yes                     |
| 1.0.1.x \[SLC_Main\] | DCF integration | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | SKY 000.001                 |
| 1.0.1.x          | SKY 000.001                 |

## Installation and configuration

### Creation

#### Serial connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device, e.g. *10.80.121.55.*
  - **IP port**: The IP port of the device, e.g. *4050.* Required.
  - **Bus address**: The bus address of the device, e.g. *50*. Not required.

#### HTTP connection

This connector also uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

## Usage

### General Page

This page displays general information parameters of the set-top box, such as the **Model name**, **number** and **description**, **Manufacturer**, **URL Base**, etc.

It also displays the **Current** **Transport** **Status** and **State**, the **CA** **Condition** and the **Current** **URI**.

With the **Tuning to Channel** button, the **Service Key** can be set to the device. You can also send a PIN code to the device using **Send User PIN**.

Finally, you can also modify the **Default PIN**, which will be stored on the Default PIN Code pop-up page.

### Remote Controller Page

On this page, you can send **Key Codes** to the device by means of the corresponding **Execute** buttons in the **Remote Control Table**. The corresponding **User Key** action will then be performed on the device.

### Communication Stream Page

This page can be used to debug the HTTP communication. It displays the requests that are sent and the responses that are retrieved.

## DataMiner Connectivity Framework

The **1.0.1.x** connector range of the **Sky UK STB DRX-595** protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

Connectivity for all exported protocols is managed by this protocol.

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- **Output**: **out**.

### Connections

There are no connections.
