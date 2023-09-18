---
uid: Connector_help_Astro_U100C
---

# Astro U100C

This connector monitors the **Astro U100 Controller**, which collects data from the different Astro devices in its frame.

## About

This connector polls the controller and displays summary info about all the devices.

The connector also allows you to schedule module upgrades for all the modules in the frame.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 5667, 6010                  |

## Installation and configuration

### Creation

This connector uses two interfaces: an HTTP interface to retrieve the data and an SNMP interface to collect the traps.

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host:** The IP address of the Astro U100 Controller.
- **IP port:** The port of the destination, by default *80*.
- **Bus address:** If the proxy server has to be bypassed, specify *bypassproxy.* This is enabled by default.

#### SNMP Trap Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

This page displays general information about the controller, such as **Temperature**, **Power Supply**, etc.

The credentials (**Username** and **Password**) must be filled in via the **Login** page button.

### Status Page

This page displays the status of all the modules held by the controller.

It is possible to add a new module to the controller by means of the **Add Modules** parameter.

### IP Addresses

This page displays the network settings of all the modules held by the controller.

### Inventory Report

This page displays the general settings of all the modules held by the controller, such as the **Uptime**, **Software Version**, etc.

### Channel Overview

This page displays the RF settings of all the modules held by the controller.

### Configuration

This page contains general settings of the controller, such as **Login Timeout**, etc.

### Network

This page displays the network interfaces of the controller.

### Logfile

This page contains the **Logfile Table**, which displays the log files of the controller. **FTP**, **Replacement**, **Update** and **Email Logs** are available via the **More Log Files** page button.

### Schedule

On this page, the **Schedule Table** displays a list of all the scheduled updates.

To schedule a new update, refer to the **Update** section below.

### Update

This page allows you to update one or multiple modules.

To execute an update immediately:

1. In the **Module Update** table, for each module, select the new firmware version in the **Module Update Option** column. Either select *'Do not Update'* or leave the cell empty if you do not want to update a module.
1. Click the **Update** button. The update will start.
1. You can follow the progress in the **Update Log Table** on the **More Log Files** page.

To schedule an update:

1. In the **Module Update** table, for each module, select the new firmware version in the **Module Update Option** column. Either select '*Do not Update'* or leave the cell empty if you do not want to update a module.
1. Click the **Schedule Update** page button to open a new window.
1. In the new window, fill in the parameters as needed (double-click a parameter for more information).
1. Click **Confirm Update**.
1. Feedback is displayed in the **Update Feedback** text box. If all goes well, the schedule is registered and displayed on the **Schedule** page.

### System Config

On this page, you can save the current configuration of the controller. The configuration file is saved in the **Documents** folder and its name will be the time of the download (YYYY/MM/dd_hhmmss).

### Traps

On this page, the **Trap Table** displays a list of all the received traps.

### Web Interface

This page displays the native web interface of the controller.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
