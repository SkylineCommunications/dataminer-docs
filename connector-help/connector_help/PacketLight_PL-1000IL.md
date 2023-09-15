---
uid: Connector_help_PacketLight_PL-1000IL
---

# PacketLight PL-1000IL

PacketLight's PL-1000IL DWDM platform is a 1U chassis designed to support a variety of optical applications such as extending the optical link power budget for building long-distance DWDM solutions.

## About

This connector is used to control and monitor the PacketLight PL-1000IL via SNMP.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | A2-A001                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *161*).

SNMP settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector consists of the data pages described below.

### General

This page displays general system parameters such as **Device IP Address**, **Admin Status**, **System Time**, **Serial Number, Firmware Version** and **Software Version.**

### Inventory

This page contains the **Inventory** table, which lists the physical components of the device.

### Time Settings

On this page, you can configure SNTP settings such as **SNTP Mode, Poll Interval, Retry Count, Time Zone, Day Light Saving** and **Fractional Time Zone**.

The page also contains the **SNTP Servers** table, which displays the **Address, Status, Version, Priority, Max Variance, Variance** and **Variance Alarm Threshold** of the servers.

### Interfaces

On this page, you can select the **Interface Naming format**. Many tables use this name in their display key, so that it is easy to see to which interface an alarm is related.

It is possible to **import or export a CSV** with the buttons at the bottom of the page. The CSV file must have a header using the format *Index;Description;Alias*.
Note that the connector only checks the key and sets the alias. The description is only there to make it more accessible for the user. When an alias is polled from the device, the device will have priority and the alias will not be set in DataMiner. Also note that the alias is only set in DataMiner and not on the device.

### Transponders

This page contains the **Transponders Configuration** table.

### Transceivers

This page contains the **Transceivers Diagnostics** table and the **Transceiver Configuration** table.

### EDFA

This page contains the **EDFA** **Configuration** table and **EDFA Port**.

### Events

This page contains the **Events, Generic Events** and **Event Inventory** tables. These tables list the traps supported by the connector that have been received.

The following traps are supported:

- eventtrap0 = "1.3.6.1.4.1.4515.1.3.22.2.0.2",
- eventtrap = "1.3.6.1.4.1.4515.1.3.22.2.2",
- geneventtrap0 = "1.3.6.1.4.1.4515.1.3.22.2.0.4",
- geneventtrap = "1.3.6.1.4.1.4515.1.3.22.2.4",
- eventinventorytrap0 = "1.3.6.1.4.1.4515.1.3.22.2.0.3",
- eventinventorytrap = "1.3.6.1.4.1.4515.1.3.22.2.3",
- alarmtrap0 = "1.3.6.1.4.1.4515.1.3.20.2.0.2",
- alarmtrap = "1.3.6.1.4.1.4515.1.3.20.2.2",
- linkup = "1.3.6.1.6.3.1.1.5.4",
- linkdown = "1.3.6.1.6.3.1.1.5.3",
- optapsswitchover0 = "1.3.6.1.4.1.4515.1.11.2.0.1",
- optapsswitchover = "1.3.6.1.4.1.4515.1.11.2.1"

### Alarms

This page contains the **Alarms Configuration** table.
