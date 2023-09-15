---
uid: Connector_help_Harmonic_HLP4800
---

# Harmonic HLP4800

The **HLP 4800** is Harmonic's flexible platform for mounting broadband communication over hybrid fiber coaxial (HFC) networks. The 3-RU chassis accommodates primary and backup power supplies and up to 10 of Harmonic's standard plug-in application modules or 20 high-density transmitter modules.

The HLP 4800 is configured with the Harmonic HNC 4801 network controller, a module that controls the communication bus of the HLP 4800 platform and provides local and remote communication for system monitoring and control. The HNC 4801 combines a display, five-button user interface and software-license enabled WEB/SNMP interface. For enhanced system reliability and uptime, the HNC 4801 is hot-swappable and can be removed, replaced or upgraded without interrupting module operation.

The HLP 4800 is powered by the CPS 4801 hot-swappable power supply, installed in a dedicated slot in the chassis. A second CPS 4801 module may be installed, allowing the platform to operate in "hot" redundancy mode. A connector on the back of the HLP 4800 chassis is provided for an additional +24V DC backup.

## About

This connector retrieves data from the device(s) through SNMP and shows the modules that exist on each device address.

The data specific for each module is organized on the **Devices** page.

For each module, a **DVE** is created that includes the following pages:

- **General page** (with all general data related to the module).
- Specific pages for parameters specific to the device type of the generated DVE. Where possible, these parameters can also be set.

### Version Info

| **Range** | **Description**                                                                                                                      | **DCF Integration** | **Cassandra Compliant** |
|------------------|--------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version.                                                                                                                     | No                  | Yes                     |
| 1.0.1.x          | Added support for new module PWL4207C (HD PowerLink). New export rules for DVE descriptions were created. New naming format for DVE. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 4.1.0.24                    |
| 1.0.1.x          | 4.1.0.24                    |

### Exported connectors

| **Exported Connector**                                                                | **Description**                          |
|--------------------------------------------------------------------------------------|------------------------------------------|
| [Harmonic HLP4800 - HOA70xx](xref:Connector_help_Harmonic_HLP4800_-_HOA70xx)   | Transmitter and optical amplifier        |
| [Harmonic HLP4800 - RDT4049](xref:Connector_help_Harmonic_HLP4800_-_RDT4049)   | DWDM digital return path transmitter     |
| [Harmonic HLP4800 - SPL7x10](xref:Connector_help_Harmonic_HLP4800_-_SPL7x10)   | Universal replacement transmitter        |
| [Harmonic HLP4800 - RDR4002](xref:Connector_help_Harmonic_HLP4800_-_RDR4002)   | Digital receiver                         |
| [Harmonic HLP4800 - HRR](xref:Connector_help_Harmonic_HLP4800_-_HRR)           | Quad optical return path receiver        |
| [Harmonic HLP4800 - HOS7010](xref:Connector_help_Harmonic_HLP4800_-_HOS7010)   | Optical switch                           |
| [Harmonic HLP4800 - PWL4xxx](xref:Connector_help_Harmonic_HLP4800_-_PWL4xxx)   | DFB laser transmitter                    |
| [Harmonic HLP4800 - HLD7105T](xref:Connector_help_Harmonic_HLP4800_-_HLD7105T) | DFB laser transmitter                    |
| [Harmonic HLP4800 - HRM381x](xref:Connector_help_Harmonic_HLP4800_-_HRM381x)   | Optical receivers                        |
| [Harmonic HLP4800 - NDT3xxx](xref:Connector_help_Harmonic_HLP4800_-_NDT3xxx)   | Digital return path transmitters         |
| [Harmonic HLP4800 - NPS3xxx](xref:Connector_help_Harmonic_HLP4800_-_NPS3xxx)   | PWRBlazer scalable optical node          |
| [Harmonic HLP4800 - NRM3xxx](xref:Connector_help_Harmonic_HLP4800_-_NRM3xxx)   | PWRBlazer scalable optical node receiver |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

NOTE: When you install version 1.0.1.1, keep in mind that any protocol version older than that version should be removed before you proceed.

### Resources

The protocol automatically queries the device for module discovery and parameter polling. This means that the user does not have to do any action to initialize the device and retrieve its data.

## Usage

### General Page

This page displays information on modules currently connected to the device, such as the **firmware version**, **slot number** and **manufacturer**.

It is possible to remove a device from this table by setting the value of the relevant remove column to *yes*.

Via the page button **Polling/DVE Creation**, you can enable/disable polling for each module.

### Alarms Page

This page shows a table with the **current active alarms**. This table is polled from the device and as such, it is a list of active alarms at the time of the polling. Available information includes the **alarm OID**, the **alarm text** (description), **alarm timestamp**, **severity** and the **value** that caused the alarm to be triggered.

### Active Nodes Page

This page shows a table with information about the external nodes connected to the chassis.

Via the page button **NMD**, you can access more specific information.

### HNC 4800 Page

This page displays information on the **HNC4800 Control Module**. This includes information such as the firmware version and serial number.

This page also allows operators to set certain parameters, such as **Slot Contact**, **Slot Location**, **Slot Phone Number**, **Slot Name**, etc.

It is also possible to enable or disable the use of an external SNTP server, as well as to configure the address of such a server. In addition, the **Clear Event Log** button can also be used to clear the device event log.

### Devices Page

This page displays all the modules connected to the device. Additional and more specific information is available here for each type of module that is connected. Where possible, parameters can be set. Changes made to the data in the **DVE** element are reflected on the **Devices page** and vice versa.

### Web Interface Page

This page allows the operator to access the web interface of the device within DataMiner.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
