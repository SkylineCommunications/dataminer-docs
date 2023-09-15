---
uid: Connector_help_Nagra_Merlin
---

# Nagra Merlin

The **Nagra Merlin** is a conditional access system.

## About

This connector uses SNMP to monitor the Nagra Merlin device. The retrieved information is displayed on different pages.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device.

**SNMP Settings**:

- **Port number**: The port number of the device, by default *161.*
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

You can find more information on the Main Page and General Page below. The connector contains a number of other pages, on which you can find a large number of individual alarm parameters. All parameters can be monitored and trended.

### Main Page

This page contains overall important alarms such as **Application Failure, Disk Full, Low Free Disk Space**, etc.

### General Page

On this page, you can view the **Alarm Table** of the device. However, you must load the table manually using the **Load** button.
