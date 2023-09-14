---
uid: Connector_help_Technetix_FAM-124
---

# Technetix FAM-124

The Technetix FAM-124 is a forward amplifier and monitoring unit with one input and four outputs.

This is an SNMP-based connector for the Technetix FAM-124. SNMP traps can be retrieved if this is enabled on the device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | FM Version 0.3         |

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
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this connector consists of the data pages detailed below.

### General

This page displays general device information. It also allows you to enable or disable the **Poll Functionality**, set a **Poll Delay**, and restore the device to the **Factory Default** settings.

Via page buttons, you can go to the following subpages:

- **Devices**: Displays the Devices table.
- **Timeout Connections**: Displays the timeout status of the connections of sub-rack 1 to 4. A button allows you to **clear the timeout status** for each sub-rack.

### Main UAU

This page displays information on the main UAU, including its name, firmware version, gain, attenuation and various status information. A button allows you to execute a **Hard Reset**.

Via page buttons, you can go to the following subpages:

- **Normalize**: Allows you to set the Normalized Attenuation and Gain. A button allows you to retrieve the normal values.
- **Raw ADC Values**: Displays the Amplifier Alarm, Backup Temp/Current Alarm, and Main Temp/Current Alarm.

### SUB UAU 1 to 4 pages

These pages display information about the different sub-racks, including their name, firmware version, gain, attenuation and various status information. Like the Main UAU page, each page has a **Hard Reset** button and **Normalize** and **Raw ADC Values** page buttons.
