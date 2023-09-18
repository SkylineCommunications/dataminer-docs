---
uid: Connector_help_CEFD_CRS-500_SNMP
---

# CEFD CRS-500 SNMP

The CRS-500 is Comtech EF Data's next generation 1:N Redundancy System. It is compatible for use with the CEFD CDM-625 and CEFD CDM 750 Modem.

## About

The CEFD CRS-500 SNMP connector is designed to monitor and control a CEFD CRS -500 device via SNMP. The different parameters of this device are available on different pages. The layout is based on the webinterface of the device.

### Version Info

| **Range**            | **Key Features**                                                                                                    | **Based on** | **System Impact** |
|----------------------|---------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version                                                                                                     | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Multiple tables now uses naming instead of displayColumn to make the database for these tables Cassandra-compliant. | 1.0.0.1      | \-                |



### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |



## Installation and configuration

### Creation

**SNMP CONNECTION**:

\- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*

\- **Device address**: n/a

**SNMP Settings**:

\- **Port number**: the port of the connected device, default *161*

\- **Get community string**: the community string in order to read from the device. The default value is *public*.

\- **Set community string**: the community string in order to set to the device. The default value is *private.*

## Usage

### Config - Redundancy page

On this page there are multiple parameters available that are divided in groups. The value of these parameters can be set to the preferred value.

### Config - Modem page

On the **Config- Modem** page there are two tables available:

- **Traffic Modem Configuration Table**: gives information on the different modems, the user can also modify the values.
- **Redundant Modem Configuration Table**: gives information on the redundant modem. The user can set the values to a preferred value.

### Config - Remote Management page

On this page the **Network Settings** and the **SNMP** **Configuration** can be viewed/set.

### Status - Monitor page

On the **Status - Monitor** page the **Redundancy** **System** statuses can be viewed. Underneath the **Slot** **Status** **Table** can be viewed.

### Status - Event Log page

Here the **Event** **Log** **Table** can be viewed.

The user can clear this table by pressing the **Clear** button.

### Utility - Info page

On the **Utility - Info** page the **General** **Configuration**, **Time** **and** **Data** and the **Bulk** **Information** can be viewed. Some of these parameters can also be modified.

### Utility - Boot Slot

On this page the user can select a firmware image to boot from.

The device can also be rebooted by clicking on the **Reboot** button.

### Webpage

Here the web interface of the device can be viewed.
