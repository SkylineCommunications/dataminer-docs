---
uid: Connector_help_SatService_sat-nms_MNC
---

# SatService sat-nms MNC

With this connector, you can gather and view information from the device **SatService sat-nms MNC** and from the devices connected to it.

## About

This connector is used to gather information from the **SatService sat-nms MNC** device, as well as any connected devices.

The connector displays several tables with general information for each device type.

### Version Info

| **Range**     | **Description**        | **DCF Integration** | **Cassandra Compliant** |
|----------------------|------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version        | No                  | Yes                     |
| 1.0.1.x \[SLC Main\] | New range without DVEs | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.0.1.x          | Unknown                     |

### Exported connectors (only for range 1.0.0.x)

| **Exported Connector**                           | **Description**               |
|-------------------------------------------------|-------------------------------|
| SatService sat-nms MNC - Antenna Controllers    | Antenna controller devices    |
| SatService sat-nms MNC - Tracking Receiver      | Tracking receiver devices     |
| SatService sat-nms MNC - Power Amplifiers       | Power amplifier devices       |
| SatService sat-nms MNC - EIRP Controllers       | EIRP controller devices       |
| SatService sat-nms MNC - Block Up Converters    | Block up-converter devices    |
| SatService sat-nms MNC - Up Converters          | Up-converter devices          |
| SatService sat-nms MNC - Down Converters        | Down-converter devices        |
| SatService sat-nms MNC - Test Loop Translators  | Test loop translator devices  |
| SatService sat-nms MNC - Uplink Power Controls  | Uplink power control devices  |
| SatService sat-nms MNC - Deicing Controllers    | Deicing controller devices    |
| SatService sat-nms MNC - Dehydrators            | Dehydrator devices            |
| SatService sat-nms MNC - Weather Monitors       | Weather monitor devices       |
| SatService sat-nms MNC - Wave Guide Switches    | Wave guide switch devices     |
| SatService sat-nms MNC - General Switches       | General switch devices        |
| SatService sat-nms MNC - Protection Switches 11 | 1-1 protection switch devices |
| SatService sat-nms MNC - Protection Switches 1N | 1-N protection switch devices |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays general information about the main device, such as the **System Description**, **System Name**, **System Uptime**, **System Location**, etc.

### Devices

This page displays a table with all the devices attached to the main device.

### Antenna Controllers

This page displays a table with all the antenna controllers.

### Tracking Receivers

This page displays a table with all the tracing receivers.

### Power Amplifiers

This page displays a table with all the power amplifiers.

### EIRP Controllers

This page displays a table with all the EIRP controllers.

### Block Up Converters

This page displays a table with all the block up-converters.

### Up Converters

This page displays a table with all the up-converters.

### Down Converters

This page displays a table with all the down-converters.

### Test Loop Translators

This page displays a table with all the test loop translators.

### Uplink Power Controls

This page displays a table with all the uplink power controls.

### Deicing Controllers

This page displays a table with all the deicing controllers.

### Dehydrators

This page displays a table with all the dehydrators.

### Weather Monitors

This page displays a table with all the weather monitors.

### Waveguide Switches

This page displays a table with all the waveguide switches.

### General Switches

This page displays a table with all the general switches.

### 1-1 Protection Switches

This page displays a table with all the 1-1 protection switches.

### 1-N Protection Switches

This page displays a table with all the 1-N protection switches.

### Fiber Optic Links

This page displays a table with all the fiber-optic links.

### Power Supply Units

This page displays a table with all the power supply units.

## Notes

### Note on 1.0.0.x

Exercise caution when using the 1.0.0.x range, as it can occur that elements with duplicated names are created, which can cause major issues in DataMiner.

### Note on 1.0.1.x

For the 1.0.1.x range, you must either apply alarm monitoring on the **Devices** table or on the remaining tables, in order to prevent double alarms.
