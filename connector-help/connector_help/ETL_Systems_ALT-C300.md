---
uid: Connector_help_ETL_Systems_ALT-C300
---

# ETL Systems ALT-C300

The **ETL Systems ALT-C300** is a dual redundant variable gain L-band amplifier.

## About

The model **ALT-C300** is a redundant ALTO amplifier chassis with auto switch before and after the amplifiers. The 1RU chassis holds 2 modules.

Ranges of the connector

| **Range**     | **Description**                                                                                   | **DCF Integration** | **Cassandra Compliant** |
|----------------------|---------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version.                                                                                  | Yes                 | Yes                     |
| 1.0.1.x \[SLC main\] | Based on 1.0.0.3. Fixed validator error regarding table index using discreet as measurement type. | Yes                 | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                         |
|------------------|-----------------------------------------------------|
| 1.0.1.x          | ETL Systems Ltd, ALTO Amplifier, e333 Version 04.31 |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The IP address of the device, e.g. *10.11.12.13*.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

### General

This page displays general parameters such as **System Description**, **Contact** and **Name**, as well as a **Summary Alarm.**

The page also contains the following three buttons:

- **Init Nr Modules:** Allows you to initialize the number of modules in the device.
- **Factory Reset:** Resets the device to the factory defaults.
- **Reboot**: Reboots the device.

### System

This page displays parameters related to the system as a whole, in particular the **Path** and **Module Configuration**. You can set parameters such as **Path Gain**, **Standby Mode** and **Check Cold Standby**.

### Modules

This page displays information about the modules of the amplifiers. You can view parameters such as the **Voltage** and **Status** of the amplifiers, and set parameters such as the **Gain** and **Power** of the modules.

### Chassis

This page displays information about the chassis. You can view parameters such as the **Voltage** and **Status** of the power units and fans.

### Trap Configuration

On this page, you can **enable trap sending**, configure the destination **IP Address** and configure the **Trap Community** string.

### Network Configuration

This page displays the **IP Settings** and **Ethernet Config** table. You can set the **IP Address** of the device, as well as its **Subnet**, **DHCP** **IP** address, **Gateway** and **Ethernet** configuration parameters.

### System Configuration

This page displays information about the block configuration. You can view parameters such as the **Block Config Number**, **Main Module Block Number**, **Redundant Module Block Number** and **Tracking Block**.

### Webpage

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

The ETL Systems ALT-C300 supports the usage of DCF from version 1.0.0.2 onwards and can only be used on a DMA with **8.5.8.5** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Virtual fixed interfaces:

- Amp 1 In Virtual (inout)
- Amp 1 Out Virtual (inout)
- Amp 2 In Virtual (inout)
- Amp 2 Out Virtual (inout)
- Amp 3 In Virtual (inout)
- Amp 3 Out Virtual (inout)

Physical fixed interfaces:

- Device inputs:

  - In 1 (in)
  - In 2 (in)

- Device outputs:

  - Out 1(out)
  - Out 2(out)

### Connections

#### Internal Connections

- Fixed: Amp 1 In Virtual (inout) - Amp 1 Out Virtual (inout)
- Fixed: Amp 2 In Virtual (inout) - Amp 2 Out Virtual (inout)
- Amp 3 In Virtual (inout) - Amp 3 Out Virtual (inout)

- In 1 (in) - Amp 1, 2, 3 In Virtual (inout)
- In 2 (in) - Amp 1, 2, 3 In Virtual (inout)
- Out 1 (out) - Amp 1, 2, 3 Out Virtual (inout)
- Out 2 (out) - Amp 1, 2, 3 Out Virtual (inout)

## Revision History

DATE VERSION AUTHOR COMMENTS

13/01/2015 1.0.0.1 ALO, Skyline Initial version

28/04/2016 1.0.0.2 LVC, Skyline Added DCF connections

27/06/2016 1.0.0.3 WWI, Skyline Added DCF connections for Amp 4,5,6

19/03/2018 1.0.1.1 RBL, Skyline Added new parameters based in additional MIBs
