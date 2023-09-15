---
uid: Connector_help_Cisco_D9828
---

# Cisco D9828

The Cisco 2.0.0.1 version is an SNMP connector intended to communicate with Cisco D9828 devices.

## About

This Cisco device is a multiple decryption receiver. Parameters are polled with SNMP, and from version 2.0.X.X onwards, extra alarm parameters are retrieved by HTTP.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) and an HTTP connection, which need the following user information:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

**HTTP CONNECTION:**

- **IP address/host**: The polling IP or URL of the destination, e.g. *10.11.12.13.*

**HTTP Settings**:

- **IP port**: The port of the destination, by default *80.*
- **Bus address**: This field can be used to bypass the proxy. For this purpose, *bypassproxy* is filled in by default.

### Configuration

When the element is created, the web interface login information is required for the device alarms. Click the page button on the **General** page and set the username and password.

## Usage

### General

This page includes the main status parameters of the device.

On the bottom right of the page, you can find the page button to go to the **UserLogin** page. To retrieve the system alarms, enter the web interface authentication here.

### Main PE

Here you can find 2 tables regarding the PE and PE Map.

### Alarms

The alarm history is loaded in the table on this page.

### Warnings

The warning history is loaded in the table on this page.

### System Alarms

The system alarms that can be found in the web interface are scraped through the HTTP interface and displayed in the text boxes.

### Web Page

The web interface will be loaded here if the user is on the same network as the device.
