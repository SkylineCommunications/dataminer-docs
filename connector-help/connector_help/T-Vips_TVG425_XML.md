---
uid: Connector_help_T-Vips_TVG425_XML
---

# T-Vips TVG425 XML

The T-Vips TVG425 connector is an **HTTP** based connector used to monitor and configure the T-Vips TVG425.

## About

The TVG425 provides gateway functionality to encapsulate MPEG-2 transport streams for IP networks, and to extract MPEG-2 streams from IP encapsulation. The device includes Gigabit ports, as well as ASI ports, all functioning as in- or output connections. Other features include: redirection such streams from an input to multiple outputs, or combined from multiple inputs as individual transport streams on one or more of the ASI ports or IP interfaces.

## Installation and configuration

### Creation

This connector uses a **HTTP** connection and needs following user information:

**HTTP Connection:**

- **Type of Port:** \[*TCP/IP\]*
- **IP Address/host:** \[*The polling IP of the device.*\]
- **IP Port:** \[*The port used for the TCP/IP connection (for instance: 80).*\]

### Configuration

In the element itself fill in the username and password on the Device Info \> Login page.

## Usage

### Device Info Page

This page contains the general information of the device. There's also an extra **Login** page provided to configure the correct **Username** and **Password** in order to communicate with the device.

### Inputs Page

Contains a table with information about all inputs of the device. The Regulator Status for each input is displayed on the Regulator table.

### Outputs Page

Contains a table with information about all outputs of the device.

IP Inputs Rx Page

Configuration and status of the IP Inputs

### TS Outputs - IP Destinations Page

This page contains a table with configuration of the IP outputs. A second table is showing the status of the IP outputs.

### ASI Inputs Services Page

Information about the ASI Input services.

### Interfaces Page

This page contains a table with the configuration and a table with the status of the interfaces.

### Web Interface Page

Contains the webinterface of the device.
