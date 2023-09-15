---
uid: Connector_help_Ruckus_Wireless_vSCG
---

# Ruckus Wireless vSCG

The **Ruckus Wireless Virtualized SmartCell Gateway** (vSCG) is an NFV-based and cloud-ready WLAN controller for service providers and enterprises that require a high flexibility and resiliency in their WLAN deployment. This is an **SNMP- and HTTP**-based protocol for the Ruckus Wireless vSCG.

This connector was designed to monitor and receive numerous statistics for the vSCG, the access points (APs) connected to it and the client stations (STAs) connected to these APs. In other words, the entire WLAN controlled by the vSCG can be monitored using this connector.

The different parameters from the device are displayed on multiple pages grouped by function. SNMPv2 **Get** commands are used to read information from the device. SNMPv2 **Set** commands are used to write information to the device. The connector also receives unsolicited messages from the device via SNMP **traps**. In addition, some JSON commands have been implemented to retrieve information from the RESTful API.

## About

### Version Info

| **Range**            | **Description**                                                                                                | **DCF Integration** | **Cassandra Compliant** |
|----------------------|----------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version.                                                                                               | No                  | Yes                     |
| 1.0.1.x              | New range that adds new HTTP connection and creation of DVEs. Supports node redundancy. Supports new firmware. | No                  | Yes                     |
| 1.0.2.x \[SLC Main\] | DCF integration implemented.                                                                                   | Yes                 | Yes                     |

### Product Info

| **Range** | **Supported Firmware**             |
|-----------|------------------------------------|
| 1.0.0.x   | 3.0.3.0.628                        |
| 1.0.1.x   | 3.4.1.0.329 (backwards compatible) |
| 1.0.2.x   | 3.4.1.0.329 (backwards compatible) |

### Exported Connectors

| **Exported Connectors**     | **Description**                                                                                                                                                                        |
|-----------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Ruckus Wireless vSCG - AP   | Separate connector that represents each individual access point. Shows its general parameters and statistics.                                                                          |
| Ruckus Wireless vSCG - Zone | Separate connector that represents each individual zone. Shows the general parameters, the access points, and WLANs that belong to that zone along with the data for each one of them. |

## Configuration

### Connections - range 1.0.0.x

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string.**: The community string used when setting values on the device. The default value is *private*.

### Connections - range 1.0.1.x/1.0.2.x

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

This connector also uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP Address/host**: Since this connector uses **HTTPS** with a custom port instead of 443, it should be configured as follows: *https://\[pollingIP\]*.
- **IP Port**: By default, this port is *7443*, but this can be adapted.
- **Bus Address**: *bypassproxy*

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use - Range 1.0.0.x

Once created, the element can be used immediately. There are 8 pages available, as well as a page with the web interface.

### System Statistics

This page displays general statistical information about the device, e.g. **Number AP**, **Number STA**, **WLAN Total Rx Pkts**, etc.

### Interfaces

This page contains information about the different interfaces of the device. For each interface, information is available such as the **If Speed**, **If Physical Address**, **If Operational Status**, and statistics of the **inbound**/**outbound** **packets**.

### WLAN

This page contains information organized by **Service Set Identifier (SSID)**. For each SSID, the **Number STA** connected to that SSID is displayed, along with the **total received bytes** and **total transmitted bytes**.

### SCG WLAN

The information on this page is also organized by SSID and is similar to the information on the WLAN page, with a number of additional details, e.g. **Zone**, **Domain**, and **Authentication Type**.

### WLAN AP

This page displays information about the access points (APs). All APs connected to the WLAN are listed in the table, organized by MAC address.

Other available information about each AP is the **Uptime**, **Sw version**, **IP Address**, and the number of **connected stations (STA)**.

### SCG AP

This page displays more detailed information about the APs. In addition to the values from the page WLAN AP, here each AP is identified by a **Name**, **Group**, **Zone**, and **Domain**. The page also displays the **model** of the AP, the **connection status**, and other parameters.

### SoftGRE Tunnels

This page displays different statistics of the AP tunnels that are configured in the SCG. It also displays whether they are active or not.

### Events

This page offers a consolidated view of all the traps sent by the vSCG. Each trap informs of a particular event that occurred on the vSCG itself, on one of the APs, or on one of the clients.

With the **Auto Clear** page button, you can configure under which circumstances the traps are going to be deleted automatically. You can define the maximum number of traps per table and the maximum duration that the traps can stay in the tables.

The **System Events Table** receives all traps of type **ruckusSCGSystemMiscEventTrap.**

The **AP Events Table** receives all traps of type **ruckusSCGAPMiscEventTrap**.

The **Client Events Table** receives all traps of type **ruckusSCGClientMiscEventTrap**.

All other traps sent by the device are received by the **Other Events Table.**

Note: In order to receive traps from a real device, make sure the **Test Mode** is disabled.

## How to Use - Range 1.0.1.x/1.0.2.x

Once created, the element can be used immediately. There are 12 pages available, as well as a page with the web interface. In addition, there are also 4 subpages that can be reached via page buttons.

### Controller

This page displays the **Controller Version**, current **Active Node IP Address**, **HTTP Status Code**, **Login Error Message**, **Ruckus Error Code**, and **System Summary Table**.

The **Login page button** can be used to configure the **username** and **password** in order to access the API.

In addition, the page also contains the following parameters:

1. **Automatic Follow Leader:** By default, this parameter is *Enabled*. This means that as soon as the element receives the response from the API related to the **System Summary**, it will start polling from the node with the **Cluster Role** equal to **Leader**. If this parameter is *Disabled,* it will use the IP address configured during element creation. If there is a **Timeout**, the element will try to find an IP address that replies correctly. As soon as such an IP address is detected, the element will start using it as the Active Node IP Address.

1. **Polling Node IP Address:** The current IP address that it is being polled. This parameter displays a dropdown box containing all IP addresses in the System Summary Table.

### Polling Node Summary

This page displays all the values for the **Polling Node IP Address**, using different standalone parameters: **Cluster Role**, **Hostname**, **MAC Address**, **Model**, **Description**, **Node Name**, etc.

### System Statistics

This page displays the following parameters: **Number of AP** (access points), **WLAN Total Tx Pkts**, **WLAN Total Rx Pkts**, **WLAN Total Rx KBytes**, **WLAN Total Tx KBytes**, **WLAN Total Rx Multicast**, **WLAN Total Tx Multicast**, **WLAN Total Tx Retry**, **WLAN Total Tx Fail**, **Serial Number**, and **SCG Zones**.

### Interfaces

This page contains information about the different interfaces of the device. For each interface, information is available such as the **If Speed**, **If Physical Address**, **If Operational Status**, and statistics of the **inbound**/**outbound** **packets**.

### Events

This page offers a consolidated view of all the traps sent by the vSCG. Each trap informs of a particular event that occurred on the vSCG, on one of the APs, or on one of the clients.

The **Trap IP Sources** are the IP addresses that will be used to process the events. The following formats can be used to set this parameter:

1. 10.1.2.2
2. 10.1.2.\*
3. \*
4. 10.1.2.2,10.1.2.3,10.1.2.4

With the **Auto Clear** page button, you can configure under which circumstances the traps are going to be deleted automatically. You can define the maximum number of traps per table and the maximum duration the traps can stay in the tables.

The **System Events Table** receives all traps of type **ruckusSCGSystemMiscEventTrap.**

The **AP Events Table** receives all traps of type **ruckusSCGAPMiscEventTrap**.

The **Client Events Table** receives all traps of type **ruckusSCGClientMiscEventTrap**.

All other traps sent by the device are received by the **Other Events Table**

Note: In order to receive traps from a real device, make sure the **Test Mode** is *Disabled*. In addition, each **Event Table** has a **Polling** parameter that **enables/disables** receiving/processing the traps for that table. By default, all polling parameters are **disabled**.

### SCG Zones

This page displays detailed information about the zones in the **Zones Details Table**. In this table, the **DVE Status** column allows you to create or disable **zones dynamic virtual elements** individually.

In addition, the page also contains the following two parameters:

- **Automatic Remove All Deleted DVEs**: This parameter is *Disabled* by default. It keeps the zones DVEs from being deleted when they have been removed from the Zones Details Table after a polling cycle.
- **Zones Virtual Elements**: If the **Enable All** button is clicked, all **zones DVEs** will be created. If the **Disable All** button is clicked, all **zones DVEs** will be deleted, which will completely remove those elements from DataMiner.

Finally, the **SCG Zones DVEs** page button can be used to save the actual virtual element name.

### SCG Access Points

This page displays the **SCG AP Table**, with detailed information about the APs, such as **Name**, **Group**, **Zone**, and **Domain**. The table also displays the **model** of the AP, the **Connection Status**, **Registration Status**, **Configuration Status**, **Received Bytes**, **Transmitted Bytes**, etc.

The table also allows you to create or remove **dynamic virtual elements** that represent each access point individually. However, as there can be a high number of APs in use, we do **NOT recommend creating** **AP DVEs** **on a large scale**.

The **Smart Cell Gateway Access Points Table** allows you to create or delete **SCG access point virtual elements** individually, via the column **SCG AP Status (Enabled/Disabled)**. By default, all the rows are *Disabled*. This table offers more detailed information about the APs. In addition to the values from the page WLAN AP, here each AP is identified by a **Name**, **Group**, **Zone**, and **Domain**. The page also displays the **model** of the AP, the **connection status**, and other parameters.

The page also includes the following parameters:

- **Automatic Remove All Deleted DVEs**: This parameter is *Disabled* by default. It keeps the **AP DVEs** from being deleted when they have been removed from the **SCG AP Table** after a polling cycle.
- **Access Points Virtual Elements**: If the **Disable All** button is clicked, all **AP DVEs** will be deleted. This will completely remove those elements from DataMiner.
- **Last Month Update**: This parameter displays the date when the Current Month Bandwidth values are copied to the Last Month Bandwidth. This always happens on the first day of each month.

Finally, the page also contains a page button, **SCG AP DVEs**, which displays the **AP Name**, **MAC Address**, and **Element ID** of all currently created AP DVEs.

### SCG WLAN

The information on this page is also organized by SSID and is similar to the information on the WLAN page, with a number of additional details, e.g. **Zone**, **Domain**, and **Authentication Type**.

### SCG SoftGRE Tunnels

This page displays different statistics regarding the AP tunnels configured in the SCG. It also displays whether they are active or not.

### WLAN

This page contains information organized by **Service Set Identifier (SSID)**. For each SSID, the **Number STA** connected to that SSID is displayed, along with the **total received bytes** and **total transmitted bytes**.

As the content of this table is already available on the page **SCG WLAN**, the **WLAN Table** is by default disabled to reduce unnecessary polling. However, polling can be activated if required.

### WLAN Access Points

This page displays information about the access points (APs). All APs connected to the WLAN are displayed in the table, organized by MAC address.

As the content of this table is already available on the page **SCG Access Points**, the **WLAN AP Table** is by default disabled to reduce unnecessary polling. However, polling can be activated if required.

### Note

If you click the **Enable All** button on the SCG Zones page, it may take some time before all the zones virtual elements are displayed.
