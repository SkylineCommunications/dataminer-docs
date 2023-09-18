---
uid: Connector_help_Novotronik_GTS191x
---

# Novotronik GTS191x

This connector monitors the activity of the Novotronik GTS191x device, a redundant switchover unit.

The digital video redundancy switch is used in satellite ground stations and TV stations. Depending on different alarm signals, a switchover of the signals can be triggered.

## About

This connector polls data from the device using a serial connection. It supports the full remote command set of this device range.

On old devices, when a command is not supported, the relevant parameter will display a "Not Applicable" exception.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.1 or 2.1                  |

## Installation and configuration

### Creation

#### Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device. This can be the TCP port of a serial gateway or the TCP port on the device itself. (In case of direct IP connection: by default *9998.*)
  - **Bus address**: The bus address of the device (range *64-95*). This needs to match the bus address setting on the device itself (depending on the DIP switches).

## Usage

### General

This page displays information about the device, such as the **Device Status**, **Unit A Status** and **Unit B Status**.

The **Switching Status** parameter displays information about which unit is online. With the toggle button, you can switch between units, but only when the **Control Mode** is set to *Remote* and the **Global Device Mode** to *Manual*.

The **Device Firmware** displays the current firmware version of the device. It is possible to change the **Internal Program Mode** of the device. A drop-down list displays the available options. You can also change the **Switch-Back Delay Time**, which supports integer values from 0 to 99.

## DataMiner Connectivity Framework

The **1.0.0.x** connector range of the Novotronik GTS191x protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party protocols (for instance a manager).

### Interfaces

#### Fixed Interfaces

Physical fixed interfaces:

- **Unit A** is a fixed interface and the interface type is **in**.
- **Unit B** is a fixed interface and the interface type is **in**.
- **COM** is a fixed interface and the interface type is **out**.
- **MON** is a fixed interface and the interface type is **out**.

### Connections

#### Internal Connections

- Between **\[Unit A-\>COM\]** and **\[Unit B-\>MON\],** internal connections are created if the status of Unit A is online.
- Between **\[Unit B-\>COM\]** and **\[Unit A-\>MON\]**, internal connections are created if the status of Unit B is online.
