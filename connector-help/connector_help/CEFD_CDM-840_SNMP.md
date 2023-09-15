---
uid: Connector_help_CEFD_CDM-840_SNMP
---

# CEFD CDM-840 SNMP

The Comtech EF Data CDM-840 provides high-performance satellite-based communication solutions for a diverse range of applications.

## About

The CEFD CDM-840 connector is used to monitor and control a CEFD CDM-840 device. The information is displayed in different pages regarding a certain category and there is the possibility to modify the settings. This connector uses SNMP to retrieve and configure the device's data.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (**SNMP**) connection and needs following user information:

**SNMP CONNECTION**:

- **IP address/host**: the polling IP of the device, e.g. *10.11.12.13*
- **Device address**: not used

**SNMP Settings**:

- **Port number**: the port of the connected device, default *161*
- **Get community string**: the community string in order to read from the device. The default value is *public*.
- **Set community string**: the community string in order to set to the device. The default value is *private.*

## Usage

### General page

The **General** page displays the **System Information**, **Service Contact** information and the **Overall Status** of the device.

## Admin page

The **Admin** page displays the selected configuration and options. There is the possibility to set the **SNMP Trap Destination IP Address** and the **Auto Logout Time**.

Also there are two page buttons available that each will open a pop-up page which displays additional information regarding the subject stated on the page button.

### Configuration - Interface Page

This page displays the **Interface Table** and underneath there are two page buttons :

- **E1 Config**: Allows the user to configure the settings for E1,
- **E1 Time Slots**: Displays a table with the all the available time slots.

### Configuration - WAN - Demod Page

First of all the Demodulator table is viewable on this page. Underneath there are two groups of settings available:

- **Automatic Demod Configuration Switch:** settings for the switch can be set,
- **Receive WAN Labels**: the user can set each label to a value between 1 and 2047, if an arriving packet matches the value of the label, then the packet is processed, otherwise it is filtered.

The **Rx ACM.** page button at the bottom of the page will open up a pop-up page where **Rx ACM** can be configured and its status can be viewed.

### Configuration - WAN - Demod Page

On this page the settings for the **Modulator** and **RTI** can be set. There is also a block where status of the VMS is displayed. The **Tx ACM.** page button opens a pop-up page where the **Tx ACM** can be configured and the status can be viewed.

### Configuration - WAN - BUC/LNB Page

On this page the settings and the status for the **BUC** and **LNB** Control can be viewed/set.

### Configuration - WAN Page

There are five blocks available:

- **QoS Control**: the mode and the SAR can be set, there are two page buttons that each will open a pop-up page where additional parameters can be viewed/set,
- **Receive WAN Labels**: the user can set each label to a value between 1 and 2047, if an arriving packet matches the value of the label, then the packet is processed, otherwise it is filtered,
- **Refresh Rates**: the refresh rate can be set between 1 and 600 packets,
- **Managed Switch Mode Configuration**: the compression state for the payload and the header can be set,
- **Encryption Feature**: the settings for the encryption can be set.

The **Wan Op Enable** can also be set on this page, this will enable/disable the Wan optimization.

### Configuration - Network Page

The Configuration - Network page displays the **Routing** and **ARP table**. For the **ARP table** the user can create new entries by clicking on the **Create New Entry** page button and on fill in the required field on the pop-up page. If the table needs to be cleaned than the user can click on the **Flush** button and the table will be cleared.

### Configuration - ECM and Configuration - dSCPC Page - Configuration - MEO

On these three pages the configurations can be set and the status can be viewed for respectably the ECM, dSCPC and the MEO.

### Status - Status pages

Each of these **Status - Status - x** pages will display the status for the subject in the page name.

### Status-Monitor pages

The **Status - Monitor** pages are used to monitor the system, Alarms and the Events.

On the **Status - Monitor - Alarms** page there is the possibility to mask the alarms by going to the pop-up pages of this page and setting the **Mask** parameters for each one to *Enabled*.

### Utility Page

On the **Utility** page the settings for the **Modem**, **Save/Load Configuration** and **Geographical Log Information** can be set/viewed. **Geographical Log Information** can be added by filling in the four parameters and then clicking on the **Add** button. If these four parameters were not filled in a pop-up page will open asking to fill in these four parameters. The GPS Log can be cleared by clicking the **Clear GPS Log** button.

The status of the Memory Usage can be viewed by clicking on the **Diagnostic** page button.

### Utility - BERT/Redundancy Page

This page the settings for the **BERT**, **Console** and the **Satellite** can be set.

The status of the **Redundancy** and the Monitoring of the **BERT** can also be viewed.

### Traps page

On the **Traps** page the incoming traps can be viewed in the **Traps table**.

### FTP page

On the **FTP** page the **FTP table** can be viewed.

### Web Interface page

Here the web interface of the device can be viewed.
