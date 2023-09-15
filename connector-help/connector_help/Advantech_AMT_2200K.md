---
uid: Connector_help_Advantech_AMT_2200K
---

# Advantech AMT 2200K

The AMT 2200K is an Advantech Solid State Power Amplifier (SSPAs), from the range from UHF to Ka Bands.

## About

This connector is intended to get information from and set information to the device through an element in a DataMiner System, using SNMP commands.

To get more detailed information on the device, consult the website [http://www.advantechwireless.com/](http://www.advantechwireless.com/amt-division-rf-products/)

## Installation and configuration

### Creation

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not used.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General

On this page, you can find information about:

- the device, with the **Product Information** page button.
- the interfaces of the device, in the **Interface Type** and **Interface** **Tables.**

There is also an option to **Reset Device**, choosing one of the options available in the dropbox.

Control Panel

On this page, you can find all relevant Control Panel Configurations and Statuses:

- **Control Panel Identification Table**
- **Control Panel Configuration Table**
- **Control Panel Status Table**
- **Control Panel Alarms Table**

### Transceiver

On this page, you can find all relevant Transceiver Configurations and Statuses:

- **Transceiver Identification Table**
- **Transceiver Configuration Table**
- **Transceiver Status Table**
- **Transceiver Alarms Table**

### SSPA Ident / Conf

On this page, you can find the **SSPA Identification** and **SSPA Config Tables**. Use the **SSPA Config Table** to set the configurations.

### SSPA Status / Alarms

Use this page to have access to the **SSPA Status** and **Alarm Tables**.

### Alarm Configuration

On this page, you can set the alarm configurations using the **Alarm Config Table**. The **Alarms Group Config** and **Combined Alarm Module View Tables** cannot be edited.

### Traps

On this page, traps sent from the device are shown, if the option is enabled in the **Alarm Config Table**.

### Web Interface

This page provides access the device's web interface.
