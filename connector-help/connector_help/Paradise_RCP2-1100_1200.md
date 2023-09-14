---
uid: Connector_help_Paradise_RCP2-1100_1200
---

# Paradise RCP2-1100/1200

The **Paradise RCP2-1100/1200** connector is used to display and configure information of the Paradise RCP2-1100 device.

## About

This protocol can be used to monitor and control the **Paradise RCP2-1100/1200** device. The connector supports one serial connection to communicate with the device.

**Alarming** and **trending** are enabled for parameters in the protocol.

## Installation and configuration

### Creation

**SERIAL Connection:**

- **IP address/host**: The polling IP or URL of the destination, e.g. *10.245.83.193*.
- **IP port**: The port of the destination, e.g. *2104*.
- **Bus address**: The bus address of the device, e.g. *0*. Valid values range from 0 to 255.

## Usage

### General Page

This page displays general information regarding the device, such as:

- System Status
- PSU Status
- Control Mode
- Etc.

There are also two page buttons:

- **Communications**: Displays information regarding the communication settings.
- **PSU:** Displays the PSU1 and PSU2 voltage.

### Fault Status Page

This page displays the main status of the device. The page is divided in three major groups:

- **System Status**
- **LNA Status**
- **SSPA Status**

In addition, with the **Fault Setup** page button, you can configure alarms raised by the device.

### System Setup Page

On this page, you can configure the device.

### SSPA Page

This page displays information regarding the SSPA.

### Web Interface

This page displays the web interface of the device.
