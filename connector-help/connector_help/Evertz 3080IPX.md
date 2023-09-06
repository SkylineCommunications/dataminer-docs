---
uid: Connector_help_Evertz_3080IPX
---

# Evertz 3080IPX

This is an SNMP connector that shows the status of the different parameters of an **Evertz 3080IPX IP video switch**.

The 3080IPX series comes with 1 Gb/10 Gb ports and exists in various versions depending on the number of ports, 16, 32, or 64, for which the bandwidth is 160, 320, or 640 Gb/s, respectively.

## About

The **Evertz 3080IPX IP video switch** is a device with many optional features, such as IGMP routing. For those extra features to work, the right type of license has to be obtained.

The connector communicates via **SNMP calls**. To process alarms as quickly as possible, **SNMP traps** are also implemented. These will update the monitored parameters instantly.

### Version Info

| **Range**            | **Description**                                                                                                                                             | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version.                                                                                                                                            | No                  | Yes                     |
| 1.0.1.x              | Added HTTP connection.                                                                                                                                      | No                  | Yes                     |
| 1.0.2.x              | Added port name to display key of all port-related tables.                                                                                                  | No                  | Yes                     |
| 1.0.3.x              | Added Syslog message support.                                                                                                                               | No                  | Yes                     |
| 1.0.5.x              | Changed Timezone Offset from number to discrete.Changed Speed from number to discrete.Changed discrete display values in Auto Routing - IGMP Routing Table. | No                  | Yes                     |
| 1.1.0.x \[Obsolete\] | New discrete values for port configuration speed; usability enhancements.                                                                                   | No                  | Yes                     |
| 1.1.1.x \[Obsolete\] | Adds redundant polling.                                                                                                                                     | No                  | Yes                     |
| 1.1.3.x \[SLC Main\] | Fixed SNMP redundant polling.HTTP dynamic polling.                                                                                                          | No                  | Yes                     |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Webeasy Version 1.5    |
| 1.0.5.x   | Version 3.0 build 314  |
| 1.1.0.x   | Version 3.0 build 379  |
| 1.1.1.x   | Version 3.0 build 379  |
| 1.1.3.x   | Version 3.0 build 379  |

## Configuration

### Connections

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

#### HTTP IPX connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

#### Serial Syslog Message Connection (range 1.0.3.1 only)

In range **1.0.3.1** only, this connector uses a smart-serial connection and requires the following input during element creation:

SMART-SERIAL CONNECTION:

- **IP address/host**: Instead of the IP of the DMA where the Syslog Messages are sent, in the **1.0.3.1 range** of the connector, the keyword ***"any"*** should be specified. This is necessary for compatibility when a DMS is operating in a Failover setup. When this is the case, the device only needs to send the messages to the virtual IP and the main and backup elements will process them accordingly.
- **IP port**: 514
- **Bus address**: Not required.

### Initialization

By default, **several parameters** are **not polled.**

If the correct license is available, you can enable **IGMP polling**, **Inband Control**, **Source Mapping & Routes**, **Port Rate Control**, and **Notify options** by clicking the corresponding buttons on the relevant pages.

## Usage

### General Page

This page (illustrated below) contains general information about the video switch, such as the **Product Name**, **Product Features Table**, **MAC Address of the Interfaces**, etc.

### Port Page

On this page, you can find information and configure settings related to ports.

This includes options to see the **operational state of a port**, the **number of incoming octets**, **the bandwidth status**, etc.

### SFP Page

On this page, you can find information and configure settings related to the **SFP ports**.

Among others, this includes options to set the **High Voltage Alarm Threshold** parameter and the **High Temperature Threshold** parameters. The current status of those parameters is also displayed.

### Contributions Page

On this page, you can find status information and configure settings related to the **IGMP Routing** option.

You can among others set the **Contribution Port Global Default IP Address**, change the settings of the configuration, change the **VLAN** linked to the **contribution port**, etc.

The parameters on this page will only be polled if the right license is available and the toggle button on this page that enables polling is set to *Enabled*.

### Inband Control Page

On this page, you can find status information and configure settings related to the **Inband Control** option. This includes parameters such as **System Inband Control Operation**, **Port Type**, **Port VLAN**, **Monitor State**, etc.

The parameters on this page will only be polled if the right license is available and the toggle button on this page that enables polling is set to *Enabled*.

### Source Mapping & Routes Page

On this page, you can find status information and configure settings related to the **Source Mapping and Routes** option. The page also contains some global routing parameters, such as the **Source Contribution Port Allocated Count**.

Among the parameters included on the page are **Contribution Port**, **Contribution Filter**, **Policer Bytes dropped**, etc.

The parameters on this page will only be polled if the right license is available and the toggle button on this page that enables polling is set to *Enabled*.

### Notify Page

On this page, you can find status information and configure settings related to the **Traps**. The page contains parameters such as **IP Address**, **Trap Fault** and **Stream Fault**.

The parameters on this page will only be polled if the right license is available and the toggle button on this page that enables polling is set to *Enabled*.

### Syslog (version 1.0.3.x only)

This page displays information about the Syslog messages.

- **Max Messages**: This parameter sets the limit for the number of entries that will be kept in the **Syslog Message Table**. Once the limit has been reached, messages will be deleted in a first-in-first-out fashion, which means that new messages will replace old ones to stay within the specified limits.
- **Clear Syslog Messages**: This button will clear the **Syslog Message Table**, after which the message counter will restart from 1.

### Matrix Settings Page (from version 1.0.5.x onwards)

On this page, you can enable or disable the Routing Matrix page. Disabling this can help improve the performance of the connector.

### IPX Route Info Page

On this page, you can find a table with all the outputs, with the connected input interface for each output.

### Routing Matrix Page

This page contains the routing matrix control.

### Web Interface Page

On this page you can directly connect to the web page of the device itself. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
