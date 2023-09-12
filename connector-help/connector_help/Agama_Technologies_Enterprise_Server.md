---
uid: Connector_help_Agama_Technologies_Enterprise_Server
---

# Agama Technologies Enterprise Server

This connector is used to monitor the Agama Technologies Enterprise Server application. The Agama Enterprise Server collects and presents quality assurance information from connected analyzers.

The Enterprise Server can send SNMP traps to an element using this connector. Other communication goes through SOAP and SSH commands.

Alarms cannot be retrieved on the analyzer devices themselves, but the Agama Enterprise Server element can forward that information to analyzer elements.

## About

### Version Info

| **Range**            | **Key Features**                   | **Based On** | **System Impact**                                                                                                 |
|----------------------|------------------------------------|--------------|-------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version.                   | \-           | \-                                                                                                                |
| 2.0.0.x              | Added SSH and SOAP.                | \-           | \-                                                                                                                |
| 2.0.1.x              | Fixed OS release version.          | \-           | Custom reports and alarm templates need to be adjusted, because of a parameter type change from double to string. |
| 2.1.0.x \[SLC Main\] | Added support for firmware v7.0.4. | 7.0.4        | Updated URL on HTTP Sessions; older firmware versions will not work with this range.                              |

### System Info

| **Range**            | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|----------------------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x              | No                  | Yes                     | \-                    | \-                      |
| 2.0.0.x              | No                  | Yes                     | \-                    | \-                      |
| 2.0.1.x              | No                  | Yes                     | \-                    | \-                      |
| 2.1.0.x \[SLC Main\] | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection in order to receive traps, and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port number of the connected device, by default *161.*
- **Get community string**: The community string used when reading values from the device, by default *public.*
- **Set community string**: the community string used when setting values on the device, by default *private.*

#### HTTP (SOAP) connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination, by default *8008.*
- **Bus address**: If the proxy server has to be bypassed, specify *byPassProxy.*

#### Serial (SSH) connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination, by default *22.*

### Initialization

To make sure there is communication with the device, you must fill in the SSH username and password on the **Configuration** page of the element.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

### General page

This page displays the **Version Number**, **CPU Usage** and **Memory Usage** of the Enterprise Server.

The Enterprise Server and Aksusbd Linux service status are also displayed, and you can start, stop, and restart the services.

### Overview page

This page displays a tree view with all locations and associated channels.

### Analyzers page

This page lists the connected analyzers on this Enterprise Server. Click the **Sync** button to map DataMiner elements to the analyzers.

The analyzer elements themselves do not feature active alarms polling. However, this element can forward active alarms to the analyzer elements if this is enabled on this page.

### Locations page

This page displays tables with the location groups and locations available on the Enterprise Server.

### Channels page

This page displays tables with the channel groups and channels available on the Enterprise Server.

### Current Status page

This page displays the current status of each channel for each location. The most severe status column contains the most severe channel quality status from the last hour.

### Active Alarms page

This page shows a table with all active alarms as available on the SOAP interface. Cleared alarms are automatically removed from the table.

If this is enabled on the **Analyzers** page, this information is forwarded to the connected analyzer elements.

### Traps page

This page displays a table with all the traps received from the device. Cleared traps can automatically be removed.

With the buttons, you can clear the table and send a request to the device to resend active alarms.

### Configuration page

On this page, you must enter the username and password to log on to the SSH session. Root access is not necessary (see "Notes" section below).

To automatically log in to the web interface page, fill in the username and password of a user with web interface access.

The **Default Agama Path** parameter must contain the path where the Enterprise Server software is installed. By default, this is "*/usr/local/ria/enterprise/bin/*".

The **QoE Polling** toggle button enables the automatic polling of the QoE Table. The polling mode can be configured with the **QoE Polling Mode** parameter.

### Web Interface page

This page allows access to the web interface of the device. The web interface credentials on the Configuration page are used to log in automatically.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

In order to execute some SSH commands used by this connector, root privileges are required, but it is not necessary to log on as root.

To allow the execution of those commands as a normal user, configure the device to allow sudo without password for the following commands:

- /etc/init.d/enterprised status
- service enterprised
- service aksusbd

From version 5.0 onward, the following command should be added before the sudo command:

- /usr/local/ria/enterprise/bin/cli version
