---
uid: Connector_help_Newtec_AZ202
---

# Newtec AZ202

With this connector, it is possible to monitor Newtec AZ202 devices with SNMP. Traps received from the device are used to update the alarm tables.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                    | **Based on** | **System Impact**                                                                            |
|----------------------|-------------------------------------------------------------------------------------------------------------------------------------|--------------|----------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version.                                                                                                                    | \-           | \-                                                                                           |
| 1.0.1.x              | New range for Cassandra compliancy. Changed displayColumn to naming.                                                                | 1.0.0.9      | Old **trend data will be lost** for the modified table.                                      |
| 1.1.0.x              | Changed USS Status discreets and Ctl Group Operation Table Operation State discreets because of new firmware and change in the MIB. | 1.0.1.2      | **Automation scripts and alarm templates** will need to be adapted.                          |
| 1.1.1.x \[SLC Main\] | Changed the discrete display values and descriptions of some parameters.                                                            | 1.1.0.2      | DMS Automation scripts, filters, Visio drawings, reports and web API may need to be adapted. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | AZ202-2.0.4.tgz        |
| 1.0.1.x   | AZ202-2.1.8.tgz        |
| 1.1.0.x   | AZ202-3.3.8.tgz        |
| 1.1.1.x   | AZ202-3.3.8.tgz        |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.1.0.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.1.1.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This is an SNMP connector. The IP needs to be configured during creation of the element.

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## How to Use

### General Page

This page displays information about the switch:

- **Network Information**
- **Active Interfaces**

There are also page buttons that lead to the following pages:

- **Trap Parameters**
- **Screen Saver Parameters**

### Switch Control Page

This page shows the current protection group state and links to subpages with protection group data:

- **Setup Parameters**
- **Operation Parameters**
- **Setup Tables**
- **Operation Parameters**
- **Group Setup Tables**
- **Group Operation Parameters**

The availability of some of these parameters, including the tables, depends on the protection group configuration. In case there are multiple protection groups, you can access the values via the page buttons **Group Operation Parameters** and **Group Setup Parameter**.

The protocol will attempt to determine which protection group state the device is in based on the responses returned. However, as this methodology cannot be absolutely trusted, we advise to instead manually set the **Protection Group Behavior** parameter. This parameter is set to *Automatic* by default, but you can set it to a fixed state by selecting *Single* or *Multiple*. Whether a device is in single or multiple protection group state depends on the configuration uploaded through the web interface. For more information, refer to the chapters "Working with Protection Groups" and "Configuration Files" in the USS0202 User Manual.

### Alarms Page

This page displays a table with **Alarms** information.

If more than one protection group is defined, the **Alarms Table** is empty, and the information is displayed in the **Group Alarms Table** instead.

### Traps

When traps are received from the device, the alarm tables are polled.
