---
uid: Connector_help_Emcore_Optiva_NMS
---

# Emcore Optiva NMS

The Emcore Optiva NMS connector is a DVE manager for the **Emcore Optiva NMS (Monitoring & Control) solution**, designed to retrieve information from Optiva enclosures and modules and to control these.

## About

This connector uses **SNMP** polling to retrieve data from the device and set data on the device.

This connector also exports several other connectors based on the information retrieved from the hardware. The list of exported connectors can be found in the "Exported Connectors" section of this page.

### Version Info

| **Range** | **Description**                                                                                    | **DCF Integration** | **Cassandra Compliant** |
|------------------|----------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version.                                                                                   | No                  | Yes                     |
| 1.0.1.x          | Support added for new card type (EDFA). DVE protocol names adjusted and logic and layout improved. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.1                         |
| 1.0.1.x          | 1.1                         |

### Exported connectors

| **Exported Connector**                                                                          | **Description**   |
|------------------------------------------------------------------------------------------------|-------------------|
| [Emcore Optiva NMS - Transmitter](xref:Connector_help_Emcore_Optiva_NMS_-_Transmitter) | Transmission card |
| [Emcore Optiva NMS - Receiver](xref:Connector_help_Emcore_Optiva_NMS_-_Receiver)       | Receiver card     |
| [Emcore Optiva NMS - EDFA](xref:Connector_help_Emcore_Optiva_NMS_-_EDFA)               | EDFA card         |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public.*
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

### System Overview

On this page, general information is displayed, such as the **Chassis Type**, the **Chassis Status** and the **NMS Card Status**.

In addition to these parameters, there are two toggle buttons to enable or disable an **Audible Alarm Control** and a **Fault/Missing Card Detection Alarm.**

A **Reset Baseline** button is also available, which allows you to reset the transmission cards and power supplies in the chassis to their baseline configuration.

### Transmitters

This page displays the **Optiva Transmitters** table, with information regarding the transmitters in the chassis.

In this table, you can set the **TX Gain Control Mode** to *Manual* or *Smart* and adjust the **RF Gain** with *+0.5 dB* or *-1 dB*.

This table also contains the **Overview Config** page button, which opens a subpage where you can enable or disable the **Automatic Removal** of DVE children. The subpage also contains a button to **Remove All** transmitter DVEs.

### Receivers

This page displays the **Optiva Receivers** table, with information regarding the receivers in the chassis.

Like in the table on the Transmitters page, you can adjust the **RF Gain** with *+1dB* or *-1dB*.

This table also contains the **Overview Config** page button, which opens a subpage where you can enable or disable the **Automatic Removal** of DVE children. The subpage also contains a button to **Remove All** receiver DVEs.

### Amplifiers

This page displays the **Optiva EDFA** table, with information regarding the amplifiers in the chassis.

In this table, you can set the **EDFA Laser Mode**, **EDFA Laser Temperature**, **EDFA Laser Power Set Point** and **EDFA Laser Current set Point**.

This table also contains the **Overview Config** page button, which opens a subpage where you can enable or disable the **Automatic Removal** of DVE children. The subpage also contains a button to **Remove All** amplifier DVEs.
