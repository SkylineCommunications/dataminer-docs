---
uid: Connector_help_Robustel_R2000
---

# Robustel R2000

The Robustel R2000 is a cellular router offering mobile connectivity for machine-to-machine (M2M) applications. This connector uses an SNMP connection to communicate with this device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.0.11                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.16.160.14*.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161* (can be changed on the **SNMP Configuration** page).
- **Get community string**: *public*
- **Set community string**: *robustel* (can be changed on the **SNMP Configuration** page).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

### General

This page displays the **Device Name** and the **User LED Type**. The **Reboot** page button opens the Periodic Reboot Settings subpage.

### Interface Page

This page displays multiple tables with settings and information. With each **Add Row** button, you can add a row with default values to the corresponding table. To delete a row, set the **Row Status** column in the table to *Destroy*.

The **Link Manager** page button opens a subpage where you can configure the primary and backup link.

### Network Page

This page displays several tables with information related to firewall rules and static routing. With each **Add Row** button, you can add a row with default values to the corresponding table. To delete a row, set the **Row Status** column in the table to *Destroy*.

Several page buttons are available:

- **IP Passthrough**: Opens a subpage where you can configure IP passthrough.
- **DMZ Config**: Opens a subpage with the DMZ configuration. Note: In order to enable DMZ, the host and source IPs must be set.
- **Firewall Config**: Opens a subpage where you can configure multiple firewall settings.

### VPN Page

This page displays multiple tables with information and settings. With each **Add Row** button, you can add a row with default values to the corresponding table. To delete a row, set the **Row Status** column in the table to *Destroy*.

The **IPSec** page button opens a subpage with the IPSec configuration.

### Services Page

This page displays the **Event Notice Info** table, which allows you to send an event notification via SMS or email. It also allows you to view and configure the **Signal Quality Threshold**.

An Add Row button is available, which adds a row with default values to the table. To delete a row, set the **Row Status** column in the table to *Destroy*.

Several page buttons are available:

- **Web Server**: Allows you to configure both the HTTP and HTTPS ports.
- **SMS:** Allows you to configure various SMS settings.
- **SSH:** Allows you to configure SSH-related settings.
- **Email:** Allows you to configure various email settings.
- **Trap:** Allows you to configure various SNMP trap settings.
- **SNMP:** Opens a subpage where you can configure various SNMP Agent Settings. Note: This is where you can edit the **read/write community strings**, as well as the **SNMP port**.
- **NTP:** Allows you to configure various NTP settings.
- **Syslog:** Allows you to configure various system log settings.
