---
uid: Connector_help_EVS_XS
---

# EVS XS

With this connector, you can monitor **EVS XS** devices with SNMP.

## About

The **EVS XS** will monitor the EVS XS device.

## Installation and configuration

### Creation

The **EVS XS** is an SNMP connector. The IP needs to be configured during creation of the element.

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public.*
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### EVS Product Page

This page displays some general info regarding the device:

- System Name
- System Location
- Status

### EVS Product Agent Page

On this page, you can find tables with information regarding the modules.

### EVS Product Management Page

On this page, you can find the **Event Log** table.

### EVS XS Server - Administration Page

On this page, you can find the values referring to the **Forward Path**.

### EVS XS Server - Configuration Page

On this page, you can find the values referring to the **Return Path**.

### EVS Server Pages

There are 4 of these pages, on which the **Level Detector Table** is displayed:

- Hardware Page
- Connections Page
- Audio/Video Page
- EVS Server Page

### Web Interface Page

On this page, you can find the web interface of the device.
