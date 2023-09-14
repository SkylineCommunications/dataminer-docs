---
uid: Connector_help_Sony_PWS-110PR1
---

# Sony PWS-110PR1

This is an SNMP connector that is used to monitor and configure the Sony PWS-110PR1 equipment.

The information on the parameters is retrieved via **SNMP** communication.

## About

### Version Info

| **Range**            | **Key Features**  | **Based on** | **System Impact** |
|----------------------|-------------------|--------------|-------------------|
| 1.0.0.x              | Initial version   | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Added DCF support | 1.0.0.9      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.10                   |
| 1.0.1.x   | 1.10                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

#### Serial PRC connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device, e.g. port *50001*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to Use

The element created with this connector consists of the data pages described below.

### General

This page displays system information, including the **System Time**, **System Description**, **System Location**, **System Contact**, **System Up Time**, and other general parameters.

### Network

This page displays the **Interfaces** table. This table displays the operational status of the interfaces available in the workstation. This operational status can also change based on incoming traps.

### Product Information

This page displays the **Product Information**, **Modules** and **Remote Maintenance** tables.

### Traps

This page displays the **Traps Destination** table.

### Alarms

This page displays the **Error Status** table. This table is both polled and updated based on traps. The table is cleared when a "Coldstart" trap is received.

### Configuration File

This page allows you to get or set configuration files (i.e. presets) of the Sony PWS-110PR1.

These configuration files are:

- Binary files that store information about settings available in the PWS-110PR1.
- Obtained through the PR1 protocol (developed by Sony).
- Stored in the following folder: *C:\Skyline DataMiner\Documents\Sony PWS-110PR1*

To create a configuration file with the current settings applied to the PWS-110PR1:

1. Set the **Configuration File Name** parameter to the name of the configuration file you want to create.

1. Click the **Get Config** button.

   When the configuration file has been created correctly, the **Get Status** parameter will be set to *Finished.* In addition, the **Last Set Status Timestamp** parameter will be updated accordingly. If the value of this parameter is set to *Error*, additional information about the error can be found in the element log file.

To apply a configuration file to the PWS-110PR1:

1. Select the configuration file in the **Configuration File Name** drop-down list. Then set the value of this parameter with the selected file name.

1. Click the **Set Config** button.

   When the configuration file has been applied correctly, the **Set Status** parameter will be set to *Finished*. In addition, the **Last Set Status Timestamp** parameter will be updated accordingly. If the value of this parameter is set to *Error*, additional information about the error can be found in the element log file.

#### Reset Timer Subpage

It could happen that the communication is interrupted when the file transfer happens, causing the Status parameters to be in the "Busy" state indefinitely. To prevent this, you can use the **Auto Status Reset Time** parameter.

For example, if a set is executed and the Auto Status Reset Time is set to 10 seconds, 10 seconds after the button is pressed, the status will automatically be set from "Busy" to "Ready" unless the device has responded that the transfer succeeded. If it has, the status will be set to "Finished".
