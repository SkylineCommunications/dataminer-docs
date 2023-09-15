---
uid: Connector_help_WISI_Tangram
---

# WISI Tangram

The **WISI Tangram** connector is used to display and configure information of the attached modules as well as the main board. The WISI TANGRAM video platform is a high-density digital TV headend for contribution of digital TV via IP networks and end-to-end IPTV solutions such as video on demand, connected TV and OTT (Over The Top) or Web TV.

## About

The WISI Tangram connector works using SNMP commands and is also configured to receive traps. In addition, a UDP connection needs to be set up in order to receive syslog messages.

More information is provided on the following website: <http://wisi.de/en/business/products/tangram/>

This connector will export different connectors based on the retrieved data. A list can be found in the section "Exported Connectors".

### Version Info

| **Range**     | **Description**                                                | **DCF Integration** | **Cassandra Compliant** |
|----------------------|----------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version.                                               | No                  | No                      |
| 1.0.1.x              | Added support for software version 2.3 (Module GT11).          | No                  | No                      |
| 1.1.0.x \[SLC Main\] | Added HTTP connection for retrieving QAM outputs and services. | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.4.1                       |
| 1.0.1.x          | 2.3 3.0.1                   |

### Exported connectors

| **Exported Connector** | **Description** |
|-----------------------|-----------------|
| WISI Tangram GT21     | GT21 table      |
| WISI Tangram GT22     | GT22 table      |
| WISI Tangram GT23     | GT23 table      |
| WISI Tangram GT31     | GT31 table      |
| WISI Tangram GT41     | GT41 table      |

### Module Types

The connector supports the following types:

- **GT21**
- **GT22**
- **GT23**
- **GT11**
- **GT31**
- **GT41**

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the WISI Tangram Chassis, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

#### UDP/IP Syslog connection

This connector uses a Syslog connection and requires the following input during element creation:

UDP/IP CONNECTION:

- **Type of port**: The type of port (UDP).
- **IP address/host**: The polling IP or URL of the destination.
- **IP Port:** The port of the connected device, by default *514*.

#### HTTP HTTP Connection Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination, by default *80*.
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Configuration

On the **Modules page** of the main element, the IP addresses of the modules are automatically retrieved (from SW-Version 1.4cr4).

The IPs can also be configured manually, but then the value will be overwritten if the controller returns another IP address. If a module does not contain an IP, no specific information is retrieved for this module.

## Usage

The WISI Tangram connector creates a main element, which provides information on the chassis status and a module overview, and dynamic virtual elements for each supported module. The name of these DVEs consists of the **Main Element Name** followed by the relevant **Module Number** and **Type**, for instance *TG01 M3 (GT22)*.

### General

On this page, you can find general information about the basic unit as well as measurements from the power supply and fan. The page also contains the **SFP Port extension table**.

### Modules

This page displays the **Modules** table, which contains a list of all SFM/MFM modules within the GT01/GN50 rack unit.

For each entry of type GT21, GT22, GT23 and GT41, the **IP Address** and the **DVE Name** can be configured.

### Switch

On this page, you can find an overview of the switch settings. This includes the **VLAN** settings used to route IP traffic correctly to and from the TANGRAM modules installed in the GT01W.

In the **VLAN Ports** table of the switch, the multicast flooding is managed. **Multicast flooding** is used to override Multicast filtering on a port when IGMP snooping is enabled.

The **Ports** table provides information about the received and transmitted bit rates for the embedded GT11 switch.

Finally, the **IGMP** page button displays settings for IGMP Snooping and for the IGMP Querier.

### Settings

On this page, you can find settings for the management of the GT11 module. The following page buttons are available:

- **Networking:** Displays the settings for the management interfaces of the GT11. All IP traffic for GT11 management occurs via the Management port.
- **SNMP:** Allows you to manage the **SNMP** settings.
- **HMS:** Allows you to manage groups of modules. Modules included in the same group can share PSI/SI information to be able to create correct DVB network-wide PSI/SI structure.
- **Date and Time:** Allows you to connect to time reference sources for GT11.
- **Services:** Allows you to enable or disable the user interface authentication and HTTPS.
- **Module Backup/Update:** With the **Backup** and **Upload** functionality on these pages, you can save the complete configuration of a GT11 to your computer and then load it again later.

### Logging

This page contains information about rebooting and failures/exceptions. It also allows you to enable **Syslog** in order to log more information. If the GT01W has access to a time reference, the log entries are timestamped.

### Syslog Messages

This page contains the **Syslog Message table**. The **Syslog Server Settings** page button allows you to set the **State** and **IP** of the server.

### Debug

This page displays every **Input** and **Output** for every card on slots 1 to 6.

### Supported Card Types

This page contains several tables, one for each card type **GT21**, **GT22,** **GT23,** **GT31** and **GT41**. Each row will generate a DVE.

### Webpage

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
