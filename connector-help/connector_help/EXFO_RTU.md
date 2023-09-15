---
uid: Connector_help_EXFO_RTU
---

# EXFO RTU

The **EXFO RTU** is an IP services test head that enables carriers to ensure the reliability and performance of their Ethernet-based services. Its wide range of test functionalities provides all the necessary measurement tools for service turn-up testing and troubleshooting, and allows verification of service-level agreements (SLAs) between service providers and their customers.

## About

This connector uses **HTTP communication** and **traps** in order to monitor the fiber ports on an EXFO RTU (Remote Testing Unit).

### Version Info

| **Range**       | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x *\[SLC Main\]* | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses a HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Bus Address:** By default *ByPassProxy*.

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection (for receiving traps only) and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

## Usage

### General

This page contains basic information such as the **System Name**, **System Version**, **Current Datetime**, **Hardware ID**, **CPU Usage** and **Memory Usage.**

Via a page button, you can also access the **Security** subpage, where you can specify the following values:

- **Username:** *Admin*
- **Password:** *Admin*
- **SOAP Username:** *EMS*
- **SOAP Password:** *Namste2008*

### Sensors

This page contains sensor data, i.e. **LED sensors, Temperature sensors, Relays and Voltage sensors.**

### Network

This page contains information about the network cards currently attached to the device.

### Fiber

This page contains **trap-based** information coming from the fiber guardian. It shows the status of each port on the device as well as event logs of past events.

It also allows you to set how many fiber ports are currently attached to the device.

The **Automatically Remove Routes** parameter is *disabled* by default. When it is disabled, all the **routes** that were deleted in the device will be available for **manual deletion** via a button in the **Fiber Fault Table**. If the parameter is set to *Enabled*, the connector will look for all the keys (routes) that are not present in the device and those routes will be deleted, via an update of the fiber table during the polling cycle.

### Traps

This page contains all traps received from the device. It also allows you to clear all traps.

### Web-Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

### Map-Interface

This page displays the map interface. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the map interface.
