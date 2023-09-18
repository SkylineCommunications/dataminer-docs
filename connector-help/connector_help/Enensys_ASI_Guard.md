---
uid: Connector_help_Enensys_ASI_Guard
---

# Enensys ASI Guard

This connector uses SNMP to monitor the **Enensys ASI II Guard** switch. It also enables the configuration of the two muxes of the switch in a way similar to the device's web interface.

## About

This is an **SNMP** connector that enables the user to configure and monitor the device.

It contains a table with info about all the current alarms, which can be monitored by DataMiner. It also displays information about the device, which can be monitored and trended.

The connector enables the user to configure the errors for which the device will generate alarms. Other device settings can also be configured, in a way similar to the device's web interface.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public.*
- **Set community string**: The community string used when setting values on the device. the default value is *private*.

### Configuration

In order to enable alarm monitoring in DataMiner's Alarm Console, the parameter **Severity Current Alarm** must be monitored in the alarm template (the default values are recommended).

The severity of the generated alarms for the various types of errors can be configured in the **Alarm Configuration Table**, which can be accessed by clicking the page button **Alarm Configurations.** on the **Alarms** page of the element.

## Usage

### General Page

On this page, standard parameters are displayed, as well as the device temperature.

Several buttons are available, with which you can make the **LED blink**, **Reboot** the device, and reset the device to factory settings (**Factory Reset)**. However, note that for the reboot and factory reset functionality, the user must have a security level of at least 1.

The following page buttons are available:

- **Options**: Opens a list of the activated options.
- **Network interface**: Configuration of the network interface.
- **Date and Time:** Allows the user to change the date and time.
- **Trap receiver**: Allows the user to configure the trap settings.

### Alarms Page

This page displays the **Current Active Alarms** and **Status** of the device, including a list of the active alarms in the **Current Alarms** table. Extra buttons: **Clear Log** and **Refresh Log.**

Since version 1.0.0.7 the **Alarm Current** table as available a functionality that allows you to remove from the table the alarms with severity "No Log". You can do this changing the **No Log Entries Displayed** toggle button to No.

The following page buttons are available:

- **Alarm Configurations**: Provides access to a table that enables the user to configure the severity of the alarms generated when certain errors occur on the device.
- **Log Table:** Displays the logging of the alarm activity and other log information for the device.

### Configuration Page

This page enables the user to configure MUX 1 and MUX 2.

The following page button is available:

- **Mux 1 (or 2) Switch Conditions:** Displays a page where the user can enable/disable error cases for which a switch will occur.

### Monitoring Page

This page enables monitoring of parameters specific for this device, such as the basic **Statistics**, **Input** and **Transmission** parameters. The **Clock Reference** displays the **Source** of the device's clock and also displays the **GPS Status.**

The following page button is available:

- **TS Display:** Displays information about the services on the MUX.

### Web Interface

This page displays the web interface of the device.
