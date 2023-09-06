---
uid: Connector_help_Ruckus_Wireless_ZoneDirector
---

# Ruckus Wireless ZoneDirector

The Ruckus Wireless ZoneDirector is a **wireless LAN controller** to configure and administrate the entire WLAN.

## About

The Ruckus Wireless ZoneDirector **SNMP** driver controls and monitors the WLAN controller.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 10.1.1.0 build 35      |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.

SNMP Settings:

- **Port Number**: The port of the connected device (default: *161*).
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

### General

This page displays information about the system, such as the Description, Up Time, Name, etc.

The General page also has the following subpages:

- **System IP Table**: Displays the IP-related settings of the Ruckus Wireless ZD device.
- **System Services**: Displays parameters related to **NTP**, **SMTP** and **Logging**.
- **System Settings**: Allows you to configure **Access Point Servers**, **IDS**, **Heart Beat** and **System Valve**.
- **System Statistics**: Displays parameters related to **CPU Utilization**, **Memory Utilization**, **LAN Rx/Tx** and **WLAN Rx/Tx**.
- **SNMPv2 Settings**: Allows you to configure the SNMPv2 traffic of the device.
- **SNMPv3 Settings**: Allows you to configure the SNMPv3 traffic of the device.

### Interface

This page displays two tables:

- **Ethernet Table**: Table containing all ethernet interfaces.
- **Interface Table**: Overview of all available interfaces.

### Access Points

This page contains the **Access Point Table**, which displays an overview of all access points with their current statuses, such as **Status**, **Rx Byte Rate**, **Tx Byte Rate**, **CPU Utilization** and **Total Users**.

The Access Points page also has the following subpages:

- **Access Point Config**: Displays a table containing all configuration parameters for each access point.
- **AP** **Radio Table**: Displays a table containing all radio statistics per access point.
- **AP WLAN Table**: Displays a table listing all access points with information about the receiver and transceiver.
- **AP Interface Table**: Displays a table with all interfaces per access point.
- **AP Ethernet Table**: Displays a table with all Ethernet interfaces per access point.

### Access Point Tree Control

This page contains a tree control that displays a list of parent access points. When you click an access point, parameters related to that specific access point are displayed together with a table containing different tabs. These tabs contain the filtered tables of **Child Access Points**, the **Access Point Config Table**, the **AP Radio Table**, the **AP Interface Table** and the **AP Ethernet Table**.

This page makes it easier to navigate to the subtables, because here they only contain entries related to the parent access point.

### Wireless LAN

This page contains the **WLAN Table**, which displays a list of all WLANs with more detailed information such as **Authentication**, **Rx/Tx Byte Rate** and **Uplink/Downlink Frames**.

### Clients

This page contains the **Clients** or **Stations Table**, which displays a list of all connected stations with more information on the WLAN they are connected to, the **Radio Type**, **Rx/Tx Statistics** and **Signal Strength**.

### Rogue Devices

This page contains the **Rogues Table**, which displays a list of all connected rogues with more information on the WLAN they are connected to, the **Radio Type**, **Encryption** and **Signal Strength**.

### Events

This page contains the **Event or Trap Table**. This table contains a list of all received events with their corresponding values.

To prevent a continuously growing Event Table, a **Refresh/Clean Up** method is available to remove old or redundant entries based on the **Event Table Config** parameters. This method runs every 15 minutes, but you can also manually run it earlier by clicking the **Refresh/Clean Up Table** button.

This page also provides access to two subpages:

- **Event Table Config**: Allows you to configure the Event Table Clean Up method. Based on the selected method, events will get removed if they exceed the number of **Max Traps** or if are older than the **Max Age Traps**.
- **Trap Config**: Allows you to enable or disable device-specific traps. These are the SNMP traps that the device will send if this is enabled.

## Notes

For the Event Table to show device events, SNMP traps have to be configured via the web interface of the device.
