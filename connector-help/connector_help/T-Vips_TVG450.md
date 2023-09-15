---
uid: Connector_help_T-Vips_TVG450
---

# T-VIPS TVG450

The **T-VIPS TVG450** connector is an SNMP-based connector used to monitor and configure the **T-VIPS TVG450**.

## About

The **TVG450** provides a monitoring interface to the **T-VIPS TVG450** Video Gateway device.

This connector works with firmware versions 3.4.4 and 3.8.24.

## Installation and configuration

### Creation

The **T-VIPS TVG450** is an SNMP connector. The IP needs to be configured during creation of the element.

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

The **General** page displays general information on the device, for example **Product Name**, **System** **Uptime,** .

Some of these parameters can also be changed, like for example the **Device Name**.

### Video Page

This page displays tables with information regarding **VBI** and **Audio**.

### Encoders Page

This page displays tables with information regarding **Encoders**.

### Decoders Page

This page displays tables with information regarding **Decoders**.

### SDI Ports Page

This page displays tables with information regarding **SDI Ports**.

### IP Status Page

This page displays tables with information regarding **IP Transmission** and **IP Receiving**.

### Web interface

This page can be used to access the web interface of the device.
