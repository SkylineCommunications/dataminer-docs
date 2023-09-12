---
uid: Connector_help_Nokia_NetAct_NMS_3GPP_Manager
---

# Nokia NetAct NMS 3GPP Manager

This driver reads performance data from files provided on an SFTP server.

Alarm information received through SNMP traps will also be processed and mapped by the driver.

## About

### Version Info

| **Range**            | **Key Features**                      | **Based on** | **System Impact**                                                                                                                                                                                                                                                 |
|----------------------|---------------------------------------|--------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version                       | \-           | \-                                                                                                                                                                                                                                                                |
| 1.0.1.x \[SLC Main\] | DVE removal timer is now configurable | 1.0.0.8      | Parameter ID 116 is now configurable: - The displayed value can be used in Automation scripts to perform sets. DMS filters can be used with wildcards on the display value. - Layout changes have been implemented. - The alarm template may need to be adjusted. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection to receive SNMP traps and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: 161 by default.
- **Get community string**: The community string used when reading values from the device (default value: *public*).
- **Set community string**: The community string used when setting values on the device (default value: *private*).

#### SFTP Connection

This driver also uses an **SFTP** connection to retrieve performance files from the Nokia NetAct System. This connection needs to be configured in the element.
More details can be found in the Initialization section of this help page.

### Initialization

#### Element Configuration page

In order to retrieve performance files, go to the **Element Configuration** page and configure the **SFTP** details (**IP**, **Username**, **Password** and **Server Folder**).
Optionally provide a regex and format for the data processed from the SFTP server. This will parse the measObjLdn field from the measurement files, allowing you to convert it to a more readable name in DataMiner.

A similar configuration can be done for the SNMP traps.

The regex and format can be tested on the **Test Regex** page.

The configuration page also allows an administrator to configure how to import the **Provisioned Devices**.
When **Import Provision Devices** is enabled, the driver will read the latest provisioning file from the **Devices Provisioning Folder**.

On the **Devices** page, you can add devices by right-clicking the **Discovered Devices** table.
For these provisioned devices, the driver will retrieve the **Performance Measurements** from within the performance files.

#### Whitelist page

On the **Whitelist** page, you need to configure which performance files should be read.
To do so, use the right-click menu of the **Whitelist** table. This will open a pop-up page where you can specify the **Data Type** and **MOC** folder. Using these Data Type and MOC filters, you can reduce the number of files DataMiner needs to process.
These filters also allow multiple Nokia NetAct elements to be spread over different DataMiner Agents in order to balance load and avoid a single point of failure.

With the **Device Filter**, the amount of data that is returned from the performance files can be limited to particular devices. Using the **Counter Filter** you can further reduce the amount of data that is returned to specific counters.
Both the device filter and counter filter can contain one or multiple wildcards (\* and ?).

Multiple Whitelist entries can be created for a certain MOC folder, as long as the filters are different.

## How to use

### General

This page allows you to monitor the availability of the **SFTP** server. It also provides information about the status and progress of the performance file processing.

### Element Configuration

In addition to the configuration described in the "Installation and configuration" section above, the following configuration parameters are available:

- **SFTP Element Regex** and **SFTP Element Format**: Allow you to configure how to obtain a device name from the performance files.
- **Traps Element Regex** and **Traps Element Format**: Allow you to configure how to obtain a device name from the traps.
- **Automatically Remove Old Devices Delay**: Allows you to configure after how many days a device should be deleted in case it is not provisioned or no longer discovered when reading performance files.

### Measurement Types

This page allows you to configure a user-friendly display name for measurements names received via the performance files.

### Devices

This page contains two tables:

- The **Provisioned Devices** table, which lists the devices that are provisioned via the provisioning JSON files or that were manually provisioned for the discovered devices table.
  Only for those devices, **DVEs** will be created.
- The **Discovered Devices** table, which lists the devices that were found in the performance files.
  The **Provisioned** column of this table allows you to configure alarm monitoring on discovered devices that have not been provisioned (and as such will not result in DataMiner processing the measurements).
  When you right-click a table entry, you can add the device to the provisioned devices.

In both tables, the **Row State** column allows you to configure alarm monitoring on devices that are no longer provisioned/discovered.

### Alarms

This page displays a table listing the alarm information received via SNMP traps.

As soon as an "alarm cleared" trap is received, the corresponding entry will be removed from the table.

The **Device Provisioned** column allows you to configure alarm monitoring on entries that correspond to devices that were not provisioned.

The **Perceived Severity** can be used to raise an alarm for every entry.
