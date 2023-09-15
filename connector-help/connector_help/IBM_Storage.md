---
uid: Connector_help_IBM_Storage
---

# IBM Storage

The **IBM Storage** protocol is used to monitor and control the associated device using **SSH** communication.

## About

This protocol can be used to monitor and control any IBM Storage device. A TCP/IP connection is used in order to successfully retrieve and configure the device's settings.

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL Connection:**

- **Type of port:** The type of port of the connection, by default *TCP/IP*.
- **IP Address/host:** The polling IP of the device, e.g. *10.1.48.70*.
- **IP Port:** The IP port of the connection device, by default *22*.

## Usage

### Security

On this page, you can enter the SSH **Login** and **Password** in order to communicate with the device.

### Enclosure

This page displays an overview of the device's **Enclosures**.

In addition, the following page buttons are available:

- **Batteries**: Overview of the batteries in the enclosure power supply units.
- **Canisters**: Details for each canister in an enclosure.
- **PSU**: Information about each power supply unit in the enclosure.
- **Slots**: Information about each drive slot in the enclosure.

### Port FC

This page displays an overview of the enclosure's **Port FC**.

### Managed Disks

This page displays an overview of the **Managed Disks**.

### Statistics

This page displays an overview of the enclosure's **Power** and **Temperature**.

### Event Log

This page displays an overview of the **log events**.
