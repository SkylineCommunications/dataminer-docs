---
uid: Connector_help_Astro_U194_IP_Descrambler
---

# Astro U194 IP Descrambler

With this connector, you can gather and view information from the device **Astro U194**, as well as configure the device.

## About

This connector uses HTTP to monitor the **Astro U194** device. The connector also has an SNMP interface to receive traps from the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 5044                        |

## Installation and configuration

### Creation

This connector uses two interfaces: an HTTP interface to retrieve the data and an SNMP interface to collect the traps. Depending on the setup, the **HTTP** configuration differs: this connector can communicate directly with the **U194**, but it can also be configured to send requests to the **Astro U100 Controller**, which will then serve as a proxy. In either case, the **SNMP** interface collects the traps emitted by the device, so the SNMP IP address must be the IP address of the **U194** (not the controller).

#### 1. Direct Communication

HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

- **IP address/host**: The IP address of the U194.
- **IP port**: The port of the destination e.g. *80*.
- **Bus address**: This field can be used to bypass the proxy. To do so, fill in the value *ByPassProxy*.

SNMP Trap Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP Address/host**: The polling IP of the U194, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

#### 2. Communication with U100C as Proxy

HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The IP address of the Astro U100 Controller.
- **IP port**: The port of the destination e.g. *80*.
- **Bus address:** The IP address of the U194. In addition, "*ByPassProxy*" must be filled in to bypass any possible proxy that could block the HTTP communication. The two fields must be separated by a semicolon, e.g. *ByPassProxy;10.11.12.13.*

SNMP Trap Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP Address/host**: The polling IP of the U194, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

This page displays general information about the device, such as the **Device Manufacturer**, **Uptime** and **Physical Location.**

### Status Page

This page displays the status of the device, with parameters such as **Temperature**, **Power Supply** and **CPU Load**.

### Main Page

On this page, the main configuration of the device can be updated, e.g. **DNS**, **Time Source**, **Interfaces**.

### Test Gen Page

On this page, you can configure the test gen parameters, e.g. **Data Rate**, **Packet ID.**

### IP TX

This page displays information about the output IP channels.

### IP RX

This page displays information about the input IP channels.

### CAM RX

On this page, you can route an IP signal to one, or several, CAM modules by clicking on the corresponding crosspoint in the matrix. In addition, you can route the output of each CAM into the three other CAM modules. If an input signal has not become available, you can also use the signal from the test generator.

### CAM TX

On this page, you can reroute the relevant output signal from a CAM module to an IP output by clicking on the corresponding crosspoint. In addition, you can also loop the IP input signals directly through to the IP outputs by activating the corresponding crosspoint. If an input signal has not become available, you can also reroute the signal from the test generator.

### CAM Settings

This page displays miscellaneous information about the four CAM modules. In the **CAM Decryption Settings** table, you can set which services must be decrypted by the CAM. You can access more specific filtering via the **CAM Elements** page button.

### System Log

On this page, you can configure the system log settings.

### Update/Config

This page contains the FTP settings for the device's firmware update.

### Alarm Severities

This page shows the severities of the possible alarms.

### Active Alarms

This page displays a table with the current alarms of the device.

### Web Interface Page

This page displays the native web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
