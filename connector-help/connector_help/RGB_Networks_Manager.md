---
uid: Connector_help_RGB_Networks_Manager
---

# RGB Networks Manager

The **RGB Networks Manager** is an application connector that is used to automatically detect RGB Networks devices on the network, and create elements and views.

## About

The RGB Networks Manager uses the **Skyline IP Network Discovery** to detect the devices on the network. Detection is supported for the RGB Networks VMG2 and RGB Networks TransAct Packager devices. The detection is done through SNMP requests.

## Installation and configuration

### Creation

Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

The application can be opened from the main navigation pane in Cube, in the "Applications" section.

It has a wizard-like interface that can be used to complete configuration, detection and creation of the elements and views.

### Devices

This page shows an overview of the devices in a rack overview drawing.

### Reports

Currently 4 reports are available to obtain an overview of the licenses and firmware per device type.

### Software Update

This page allows you to perform a software update on the devices. This can be done in bulk or one by one.

### License Update

This page allows you to perform a license update on the devices. This can be done in bulk or one by one.

### Discovery

In 6 steps, the discovery process of RGB Networks is obtained in a wizard interface:

1. The **Settings** page allows you to configure the discovery settings, like for example on which IP range to scan or the default SNMP community string.
2. The **Default credentials** page allows you to configure the default credentials of the devices to guarantee communication of the element and the devices.
3. The **Racks** page allows you to configure "Racks" that will be created as views in DataMiner and the elements can be organized in them.
4. The **Discover** page allows you to start the discovery.
5. The **Synchronize** page allows you to synchronize existing configured elements in the DMS to be synchronized in the results table.
6. The **Result** page provides an overview of all discovered devices. You can assign them to racks and create the elements in bulk or one by one.
