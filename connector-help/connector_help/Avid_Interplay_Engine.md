---
uid: Connector_help_Avid_Interplay_Engine
---

# Avid Interplay Engine

This SNMP connector allows you to monitor and set up the **Avid Interplay Engine**.

## About

This is an SNMP connector of the Avid Interplay Engine, which also contains additional parameters of the **Avid Monitoring System**.

The connector uses SNMP Get calls to extract the relevant information used to monitor and manage Avid ISIS events.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 3.0.5.38325                 |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP Address/host**: The polling IP of the device, e.g. *10.237.4.31*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default: *public*.
- **Set community string**: The community string used when setting values on the device, by default: *private*.

## Usage

### General Page

This page displays general information about the device, such as the **System Description**, **Up Time** and **Location**.

### Product

This page displays a table with information regarding the device, such as the **Device name**, **Version**, **Database Name** and **Active Node**.

### Interface Page

This page displays a table with information on the interfaces of the device, such as the **Interface Description**, **Interface Type** and **Interface Status**.

### Health

This page contains information related to the health of the device, such as **Status**, **Share Avail.** and **Dump Files**.

### Client and Backup

This page displays whether a **Backup** is running, and shows the number of established **Connections** and **Used Licenses**.

### Web Interface Page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
