---
uid: Connector_help_CEFD_CDD-S2_SNMP
---

# CEFD CDD-S2 SNMP

The Comtech EF Data CDD-S2 provides high-performance satellite-based communication solutions for a diverse range of applications.

## About

The CEFD CDD-S2 driver is used to monitor and control a CEFD CDD-S2 device. The information is displayed in different pages regarding a certain category and there is the possibility to modify the settings. This driver uses SNMP to retrieve and configure the device's data.

### Version Info

| **Range**            | **Key Features**                                                                                                    | **Based on** | **System Impact**                                 |
|----------------------|---------------------------------------------------------------------------------------------------------------------|--------------|---------------------------------------------------|
| 1.0.0.x              | Initial version                                                                                                     | \-           | \-                                                |
| 1.0.1.x \[SLC Main\] | Multiple tables now uses naming instead of displayColumn to make the database for these tables Cassandra-compliant. | 1.0.0.9      | **Old trend data will be lost for these tables.** |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unknown                |
| 1.0.1.x   | Unknown                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Installation and configuration

### Creation

***SNMP connection***This driver uses a Simple Network Management Protocol (SNMP) connection and needs the following user information:

SNMP CONNECTION:

- IP address/host: the polling IP of the device, e.g. *10.11.12.13*
- Device address: not used

SNMP Settings:

- Port number: The port of the connected device, default: 161
- Get community string: The community string used when reading values from the device. The default value is *public*.
- Set community string: The community string used when setting values on the device. The default value is *private.*

## Usage

### General page

The **General** page displays the **System** **Information**, **Service** **Contact** information and the **Overall** **Status** of the device.

### Admin page

The **Admin** page displays the selected configuration and options. There is the possibility to set the **SNMP Trap Destination IP Address** and the **Auto Logout Time**.

Also there is a pagebutton available that will open a pop-up page which displays additional information regarding the subject stated on the pagebutton.

### Configuration - Interface Page

This page displays the **Interface Table**.

### Configuration - WAN - Demod Page

First of all the Demodulator table is viewable on this page. Underneath there are two groups of settings available:

- **Automatic Demod Configuration Switch:** settings for the switch can be set,
- **Receive WAN Labels**: the user can set each label to a value between 1 and 2047, if an arriving packet matches the value of the label, then the packet is processed, otherwise it is filtered.

### Configuration - WAN - LNB Page

On this page the settings and the status for the **LNB** Control can be viewed/set.

### Configuration - WAN Page

The user can set each Receive WANlabel on this page, to a value between 1 and 2047, if an arriving packet matches the value of the label, then the packet is processed, otherwise it is filtered.

### Configuration - Network Page

The Configuration - Network page displays the **Routing** and **ARP** **table**. The user can create new entries by clicking on the **Create New Entry** pagebutton and fill in the required field on the pop-up page. The IGMP can be viewed and set when the user clickes the **IGMP** pagebutton.

### Status - Status pages

Each of these **Status** **- Status - x** pages will display the status for the subject in the page name.

### Status-Monitor pages

The **Status** **-** **Monitor** pages are used to monitor the system, Alarms and the Events.

On the **Status - Monitor - Alarms** page there is the possibility to mask the alarms by going to the pop-up pages of this page and setting the **Mask** parameters for each one to *Enabled*.

### Utility Page

On the **Utility** page the settings for the **Modem** and **Save/Load Configuration** can be set/viewed.

The status of the Memory Usage can be viewed by clicking on the **Diagnostic** pagebutton.

### Utility - BERT/Redundancy Page

This page the settings for the **BERT**, **Console** and the **Satellite** can be set.

The status of the **Redundancy** and the Monitoring of the **BERT** can also be viewed.

### FKS page

In this page it is possible to set the FSK functionality. This functionality will generate a vitrual element that contains all LNB parameters. A unique FSK Element Name can be set for the virtual element.

### Traps page

On the **Traps** page the incoming traps can be viewed in the **Traps** **table**.

### FTP page

On the **FTP** page the **FTP** **table** can be viewed.

### Webinterface page

Here the webinterface of the device can be viewed. The client machine has to be able to access the device. If not, it won't be possible to open the webinterface.

## Notes

N/A
