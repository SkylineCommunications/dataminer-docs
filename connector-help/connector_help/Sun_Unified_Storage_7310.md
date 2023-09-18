---
uid: Connector_help_Sun_Unified_Storage_7310
---

# Sun Unified Storage 7310

The **Sun Unified Storage 7310** connector can be used to display and configure information of the device.

## About

This protocol can be used to monitor and control the Sun Unified Storage 7310 device. An **SNMP** connection is used in order to successfully retrieve and configure the device's information.

## Installation and configuration

### Creation

**SNMP Connection:**

- **IP Address/host:** The polling IP of the device.

**SNMP Settings:**

- **Port Number:** The port of the connection device (by default *161*).
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

## Usage

The Sun Unified Storage 7310 protocol contains the following pages:

- **General:** System Information (for instance: *Contact*, *Name*, *Location*, etc.). There's also a page button referring to the *Interface*, *IP Address* and *IP Route* tables.
- **FM - Problem and Fault:** *Problem Overview* and *Fault Overview* tables.
- **FM - Module and Resource:** *Module Overview* and *Resource Overview* tables.
- **AK:** Appliance information (for instance: *Type*, *Version*, etc.), *Share Overview* table and *Ak Alert Table*.
