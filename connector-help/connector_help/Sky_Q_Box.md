---
uid: Connector_help_Sky_Q_Box
---

# Sky Q box

This is an API with web services exposed by the set-top box middleware.

## About

The application service provides access to all features of the middleware used not only by external client set-top boxes, but also by the application running on the gateway set-top box itself.

### Version Info

| **Range** | **Description**               | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version               | No                  | No                      |
| 1.0.1.x          | Added serial and new features | No                  | No                      |
| 1.0.2.x          | DCF integration               | Yes                 | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.0.1.x          | Unknown                     |
| 1.0.2.x          | Unknown                     |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Device address**: The device address, by default *ByPassProxy*.

## Usage

### General Information

This page displays general information about the device, such as **System Information, Model Number, Version Number, Serial Number, IP Address** and **Manufacturer**.

### Services

This page displays the available services for the current box.

### Configuration

On this page, you can change the channel, set the TV to sleep and log in on the device.

### Remote Controller

This page has a table in each row, representing a button from the remote controller.

## DataMiner Connectivity Framework

The **1.0.1.x** connector range of the **Sky Q Box** protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

Connectivity for all exported protocols is managed by this protocol.

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- **Output**: **out**.

### Connections

There are no connections.
