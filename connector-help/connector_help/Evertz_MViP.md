---
uid: Connector_help_Evertz_MViP
---

# Evertz MViP

The **MViP** is an IP-based multi-image display and monitoring solution used as a tool for digital headends, IPTV networks, and sites using IP distribution.

## About

All data is retrieved using a single **SNMP** connection. SNMP traps can also be retrieved when this is enabled on the device.

### Version Info

| **Range** | **Description**                                                                                                                   | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                                                                                   | No                  | Yes                     |
| 1.0.1.x          | Changed table ID 500 naming and descriptions from "Alerts" to "Faults" for compatibility with Evertz MVIPII. Added trap receiver. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.0.1.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*
- **Set community string**: The community string used when setting values on the device, by default *private*

## Usage (Range 1.0.0.x)

### General

This page contains the following parameters: **System Description**, **System Up Time**, **System Contact**, **System Name** and **System Location**.

### Source

This page displays the **Source Definition** table**.**

### Video

This page displays the **Video Stream Definition** table.

### Audio

This page displays two tables: **Audio Stream Definition** and **Audio Stream Channel Definition**.

### Traps Notification

This page contains the **Alerts Table**, which displays the current status of each possible fault retrieved via SNMP traps. The indexes of this table are obtained from the **Source Definition** table and represent the sources monitored by this device. Each column of this table represents a specific fault. For example, the column Video Black represents the traps *faultVideoBlackFalse* (1.3.6.1.4.1.6827.50.297.5.0.1000) and *faultVideoBlackTrue* (1.3.6.1.4.1.6827.50.297.5.0.1001). To avoid sticky alarms in this table, every time the element is restarted, the columns representing the faults will be set to 'N/A'.

### Device Web Interface

This page provide access to the unit web interface page.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage (Range 1.0.1.x)

### General

This page contains the following parameters: **System Description**, **System Up Time**, **System Contact**, **System Name** and **System Location**.

### Source

This page displays the **Source Definition** table**.**

### Video

This page displays the **Video Stream Definition** table.

### Audio

This page displays two tables: **Audio Stream Definition** and **Audio Stream Channel Definition**.

### Traps Notification

This page displays two tables: **Alerts Table** and **Source Changes Table**. The tables display the received traps. The second table contains the traps related to source changes.

This page has a page button that allows you to configure the **Auto Clear** options **Traps Max Duration** and **Traps Max Number**. It is also possible to manually clear the traps.

### Faults

This page contains the **Faults Table**, which displays the current status of each possible fault retrieved via SNMP traps. The indexes of this table are obtained from the **Source Definition** table and represent the sources monitored by this device. Each column of this table represents a specific fault. For example, the column Video Black represents the traps *faultVideoBlackFalse* (1.3.6.1.4.1.6827.50.297.5.0.1000) and *faultVideoBlackTrue* (1.3.6.1.4.1.6827.50.297.5.0.1001). To avoid sticky alarms in this table, every time the element is restarted, the columns representing the faults will be set to 'N/A'.

### Device Web Interface

This page provide access to the unit web interface page.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
