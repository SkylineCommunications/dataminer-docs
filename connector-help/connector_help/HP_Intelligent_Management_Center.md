---
uid: Connector_help_HP_Intelligent_Management_Center
---

# HP Intelligent Management Center

The **HP Intelligent Management Center** (iMC) is a next-generation intelligent service management platform. It can be used to manage, control and monitor a network, using a unified management interface. With its open and modular architecture, this platform enables distributed, hierarchical and interactive management of the services running on it.

## About

This connector can be used to get a list of the devices and alarms.

## Installation and configuration

This connector uses both an HTTP and a serial connection. The serial connection is used to set up the authentication, and should have the same values as the HTTP connection.

The following information must be provided during element creation:

**HTTP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Port number**: The port of the connected device, by default *8080.*
- **Bus Address:** This field can be used to bypass the proxy. To do so, fill in the value *bypassproxy.*

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Port number**: The port of the connected device, by default *8080.*
- **Bus Address:** This field can be used to bypass the proxy. To do so, fill in the value *bypassproxy.*

## Usage

### Alarms

On this page, you can configure the logon credentials.

The page contains a list of all the alarms. You can select whether only the root alarms should be displayed or the others as well.

### Devices

This page provides an overview of the different available devices.

With the **Max Element per View** parameter, you can define how many elements are to be retrieved for each view.

### Views

On this page, you can **enable or disable views**. Only when a view is enabled, the devices associated with this view will be retrieved and displayed on the devices page.

The **Max Element per View** parameter is also available here, like on the Devices page.

### Responses

This page displays the responses for the alarms and devices query.

### Web Interface

This page links to the interface of the device. The IP address that is used is the one specified when the element was created.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
