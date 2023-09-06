---
uid: Connector_help_Schneider_Electric_StruxureWare
---

# Schneider Electric StruxureWare

The **Schneider Electric StruxureWare DCIM** (Data Center Infrastructure Management) platform is a management software suite designed to collect and manage data about a data center's assets, resource use and operation status throughout the data center lifecycle. This information is then distributed, integrated and applied in ways that help to manage and optimize the data center's performance. The **Schneider Electric StruxureWare** driver is the solution designed to monitor this platform.

## About

This driver was designed to interact with a SOAP interface. An **HTTP** connection is used to successfully retrieve the API information. This driver is also a **DVE manager**, containing a DVE table that is used to export other drivers, each of them representing a device. The list of exported drivers can be found in the "Exported Drivers" section of this page.

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version**          |
|------------------|--------------------------------------|
| 1.0.0.x          | StruxureWare Data Center Expert v7.2 |

### Exported drivers

| **Exported Protocol**                                                                                            | **Description** |
|------------------------------------------------------------------------------------------------------------------|-----------------|
| [Schneider Electric StruxureWare - Device](xref:Connector_help_Schneider_Electric_StruxureWare_-_Device) | Device          |

## Installation and configuration

### Creation

#### HTTP main connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host:** The polling IP or URL of the destination.
- **IP port:** The IP port of the destination.
- **Bus address:** If the proxy server has to be bypassed, specify "*bypassproxy".*

## Usage

The driver consists of six pages.

### General

This page contains the following parameters:

- **Username/Password**: The authentication credentials must be filled in in order to successfully retrieve system information
- **Devices DVE Table**: This table displays all monitored devices and a toggle button to create a dynamic virtual element for each specific device.
- **Exported Devices button**: Thispage button opens a pop-up page displaying a table with all exported devices.

### System Overview

This page provides an overview of the monitored system, using the following structure: Device Groups \> Devices \> Sensors.

### Alarms Info

This page displays the **Active Alarms table**. This table displays all active alarms that are currently in the system.

### Devices Info

This page displays the **Devices table**. This table displays all device information for all monitored devices.

### Sensors Info

This page displays the **Sensors table**. This table contains all information regarding sensors.

### Web Interface.

This page can be used to access the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
