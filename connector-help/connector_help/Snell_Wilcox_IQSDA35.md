---
uid: Connector_help_Snell_Wilcox_IQSDA35
---

# Snell Wilcox IQSDA35

The **Snell Wilcox IQSDA35** is a dual 3G/HD/SD-SDI distribution amplifier with selectable outputs.

## About

This connector uses SNMP to monitor and control a **Snell Wilcox IQSDA35** device. The information and settings are displayed on different pages.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: The card number, e.g. *1.*

**SNMP Settings**:

- **Port number**: The port of the connected device, default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General page

This page displays two groups of parameters:

- **Unit Stats**: An overview of the two inputs and the four outputs.
- **Product**: General information about the product

### Input page

On this page, you can modify the settings for **input** **1** and **input 2**.

### Config page

On this page, you can choose which configuration to enable. With the **Mode** parameter, you can choose between *Config(1)*, *Config(2)* and *Use Rules*. If the Mode is set to *Use Rules*, then the configuration will be chosen by the rules that are enabled in the group box **Rules**.

With the **Swap Config 1\<\>2** button, you can toggle between the two configurations.

The two page buttons underneath open a pop-up page where the settings for each configuration can be modified as needed.

### Webpage

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
