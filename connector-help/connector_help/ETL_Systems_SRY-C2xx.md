---
uid: Connector_help_ETL_Systems_SRY-C2xx
---

# ETL Systems SRY-C2xx

The StringRay 200 Series RF over Fibre indoor and outdoor chassis feature dual redundant, hot-swap power supplies and hot-swap modules and fan tray.

The ETL Systems SRY-C2xx connector provides chassis and module status information for these devices. The information is polled via SNMP.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                                                                                                                                                                                                                                                                                                                                                                                           |
|-----------|---------------------|-------------------------|-----------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | - ETL Systems SRY-C2xx<br>- SRY-TX-L1-205 <br>- ETL Systems SRY-C2xx <br>- SRY-RX-L1-206 <br>- ETL Systems SRY-C2xx - SRY-TX-Y-281 <br>- ETL Systems SRY-C2xx - SRY-DIV-Y-219 <br>- ETL Systems SRY-C2xx <br>- SRY-RX-Y-282 <br>- [ETL Systems SRY-C2xx - SRY-SW-Y-220](xref:Connector_help_ETL_Systems_SRY-C2xx_-_SRT-SW-Y-220) |

## Configuration

### Connections

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The element consists of the data pages detailed below.

### General

This page displays the general status of the device, such as the **Summary Alarm**. The **Temperature** and **Humidity** are also shown and displayed above the software version information.

On the right, the **Ethernet Configuration** table shows the configuration for Auto Negotiate Mode, Duplex, and Speed.

### Chassis

The status of the chassis is displayed on this page. This includes the **Power Status,** **Fan Status** and **Door** state.

### Modules

The **Modules Settings** table and **Module Readings** table are displayed on this page. These show status information for the chassis modules and allow chassis module configuration.

At the end of the table, you can **enable or disable the generated DVE** for each module. If a DVE no longer has valid data because it has been removed, you can use the **Remove** button to delete the DVE.

Via the **DVEs** page button, you can see the currently generated DVEs. The **Automatic Removal** toggle button will automatically remove outdated DVEs, and **Remove All** will delete all DVEs.

### IP Settings

The **IP Settings** table on this page allows you to configure the device **DHCP** and **IP**.

### Trap Receivers

The trap receivers of the device are displayed and configurable in the **Trap Receivers** table on this page.
