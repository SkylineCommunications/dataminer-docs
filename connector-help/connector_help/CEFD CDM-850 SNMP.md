---
uid: Connector_help_CEFD_CDM-850_SNMP
---

# CEFD CDM-850 SNMP

The Comtech CEFD CDM-850 provides high-performance satellite-based communication solutions for a diverse range of applications.

## About

The CEFD CDM-850 driver is used to monitor and control a CEFD CDM-850 device. This driver uses SNMP communication to retrieve and configure the data of the device. The CDM-850 can send out SNMP traps when certain events occur in the modem. A trap is sent both when a fault occurs and when a fault is cleared.

### Version Info

| **Range**            | **Key Features**                                                                                                   | **Based on** | **System Impact**                                        |
|----------------------|--------------------------------------------------------------------------------------------------------------------|--------------|----------------------------------------------------------|
| 1.0.0.x              | Initial version                                                                                                    | \-           | \-                                                       |
| 1.0.1.x \[SLC Main\] | Multiple tables now use naming instead of displayColumn to make the database for these tables Cassandra-compliant. | 1.0.0.12     | **Old trend data will be lost for the modified tables.** |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | CEFD CDM-850 SNMP (FSK) |
| 1.0.1.x   | No                  | Yes                     | \-                    | CEFD CDM-850 SNMP (FSK) |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (**SNMP**) connection and needs following user information:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*
- **Device address**: Not used.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created using this driver consists of the data pages detailed below.

### General page

Thispage displays the **System** and **Service Contact Information** and the **Overall Status** of the device.

### Admin page

This page displays the selected configuration and options. It allows you to set the **SNMP Trap Destination IP Address** and the **Auto Logout Time**.

Via page buttons, you can access **Firmware** and **VMS** information.

### Configuration - Interface

This page displays the **Interface** and the **Port Configuration Tables**.

### Configuration - WAN - Demod

On this page, you can view the Demodulator table. Below this, several groups of settings are available:

- **Automatic Demod Configuration Switch:** Settings for the switch.
- **Receive WAN Labels**: Each label can be set to a value between 1 and 2047. If an incoming packet matches the value of the label, the packet is processed; otherwise it is filtered out.

The **Rx ACM** page button at the bottom of the page opens a subpage where **Rx** **ACM** can be configured and its status can be checked.

### Configuration - WAN - Mod

On this page, you can configure the settings for the **Modulator** and **RTI**. The page also displays status information of the VMS.

The **Tx ACM** page button opens a subpage where the **Tx ACM** can be configured and the status can be checked. The subpage also contains the **DPC** configuration and status.

### Configuration - WAN - QoS

On this page, you can configure settings related to QoS.

### Configuration - WAN - BUC / LNB

On this page, you can view the status for the **BUC** and **LNB** control and configure the corresponding settings.

### Configuration - WAN

This page allows you to set parameters related to the compression functionality.

It also contains settings related to encryption.

### Configuration - Network

This page displays the **Routing** and **ARP** **tables**. Via page buttons, you can access the **IGMP** and **DHCP** settings.

You can add new entries in the **ARP** **table** by clicking the **Add Static ARP** page button and filling in the required fields on the pop-up page. To clean up the table, click the **Flush Dynamic ARP** button.

The page also allows you to configure the **Working Mode**, **DNS**, **PTP** and **Wan** **Op** **Enable**.

### Configuration - ECM / dSCPC / MEO

On these three pages, you can view the status of and configure settings for the **ECM**, **dSCPC** and **MEO**, respectively.

### Status - Stats - Interface / Traffic / Demod / Network / Compression / QoS

These pages display status information relevant to the page title.

### Status - Monitor

This page displays information about the **Unit Temperature** and the **Alarms** on the device.

### Status - Monitor - Events

This page allows you to check the events generated by the device.

### Status - Monitor - Alarms

This page allows you to view detailed alarm information and to configure alarm masks.

### Utility

This page allows you to view and configure settings for the **Modem**, **Save/Load Configuration** and **Geographical Log Information**.

You can add **Geographical Log Information** by filling in the four parameters and then clicking the **Add** button. If these four parameters are not filled in when you click the button, a pop-up page will open asking to fill them in.

To clear the GPS log, click the **Clear GPS Log** button.

To check the status of the memory usage, click the **Diagnostic** page button.

### Utility - BERT / Redundancy

On this page, you can configure the settings for the **BERT**, **Console** and the **Satellite**. You can also check the **Redundancy** status and the **BERT** monitor.

### Traps

This page displays the incoming traps in the **Traps** **table**.

### FTP

This page contains settings for FTP file transfer in the **FTP** **table**.

### External Request

This page allows you to consult the external request.

### Web Interface

This page provides access to the embedded web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

### FSK

This page allows you to configure the FSK functionality. It will generate a virtual element that contains all BUC/LNB parameters. A unique **FSK Element Name** must be set for the virtual element.
