---
uid: Connector_help_TelcoBridges_Media_Gateway_3200
---

# TelcoBridges Media Gateway 3200

The **TelcoBridges Media Gateway 3200** connector can be used to display information of the related devices.

## About

The **TelcoBridges Media Gateway 3200** device is a **VoIP** gateway with uncompromising reliability, high capacity and high performance. This connector uses an SNMP connection in order to successfully retrieve and configure the device's information.

## Installation and configuration

### Creation

**SNMP Connection**

- **IP Address/host:** The polling IP of the device.

**SNMP Settings**

- **Port Number:** The port of the connection device, by default: *161*.
- **Get community string:** The community string used when reading values from the device. The default value is *public*.

## Usage

The TelcoBridges Media Gateway 3200 protocol contains the following pages.

### General page

This page displays general information about the device, such as the **System Description** and **Name**.

### Module page

This page displays the **Module Table**, which contains an overview of the different modules.

### Hardware page

This page displays information about the different hardware features, such as the **Identification**, **Power Supply**, **Fan**, **Temperature**, etc.

### Software page

This page displays information about the different software features, such as the **Version**, **Performance**, etc.

### Signalling pages

These pages contain information about the supported protocols: **CAS**, **H248**, **ISDN**, **IUA**, **M2UA**, **M3UA**, **M2PA**, **MTP2**, **SIP**.

### Calls page

This page displays legs information, such as the **Incoming Legs**, **Incoming Legs Rate**, etc.

### NAP page

This page displays NAP information, such as the **Signaling Type**, **Incoming Legs**, etc.

### High Availability page

This page provides an overview of the different types: **NP1** and **Applications**.

### Clock page

This page displays status information about the Clock.

### Leaf Line Services page

This page displays information related to the Leaf Line Services.

### Configuration page

On this page, you can enable or disable the polling for the related tables.
