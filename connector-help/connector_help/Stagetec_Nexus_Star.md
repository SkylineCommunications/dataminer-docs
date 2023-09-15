---
uid: Connector_help_Stagetec_Nexus_Star
---

# Stagetec Nexus Star

The Stagetec Nexus Star is an **audio-router system** which was designed for the most extensive routing requirements typically found, in broadcast centres, large production companies, and exhibition grounds. The Stagetec Nexus Star is a routing node serving as the core of a Nexus installation and interconnecting numerous Nexus Base Devices scattered over separate studios and apparatus areas via optical cables. It is a versatile audio-network and routing system for controlling studio or mixing-desk resources, for apparatus-area and broadcast-complex networking, for OB trucks, sound reinforcement, and for any other professional audio technology applications.
Stagetec Nexus Star can accommodate up to 16 boards each with 256 inputs and 256 outputs. This allows for routing a maximum of 4,096 inputs to 4,096 outputs, resulting in more than 16 million crosspoints.

## About

This connector retrieves data via **Smart-Serial Communication** over **UDP**.

### Version Info

| **Range**      | **Description**                                                                                       | **DCF Integration** | **Cassandra Compliant** |
|-----------------------|-------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x               | Initial version                                                                                       | No                  | Yes                     |
| 1.0.1.x               | RedundantPolling IP Address (warning, needs a new element)                                            | No                  | Yes                     |
| 1.0.2.x (RTBF)        | Permanent Connection using Keep Alive - ACK (Can be directly upgraded from elements of range 1.0.0.x) | No                  | Yes                     |
| 2.0.0.x               | Review - Customer Mecca                                                                        | No                  | Yes                     |
| 2.0.1.x (Main Branch) | Complete Review                                                                                | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Version 5, Revision 2       |
| 1.0.1.x          | Version 5, Revision 2       |
| 1.0.2.x          | Version 5, Revision 2       |
| 2.0.0.x          | Version 5, Revision 2       |
| 2.0.1.x          | Version 6, Revision 2       |

## Configuration

### Connections

#### Serial Connection - Main

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: Not required.

## Usage

The Stagetec Nexus Star connector has **5 pages**.

### General

The General page displays the **Project Information** (**Project Name**, **Version**, **Revision**, **Date** and **Time**), **Central Status (Sampling Frequency**, **Full Scale**, **Waveform Internal Generator**, **Gain Internal Generator** and **Frequency Internal Generator**), a page button with the **Board Overview Table**, and buttons to **Refresh All Data**, **Clear Blocked Writes** and **Reset Alarm**.

This page also displays information related with the connector itself, such as: **Driver Initialization**, **Get-Set Time-Out**, **Get-set Time-Out Count** and a **Driver Monitor** page button, which contains: **Counter MaxRetries**, **FLAG Reading Allowed** and a button in order to **Process the Buffer**.

### Switchpoints

The Switchpoints contains the **Switchpoints Overview Table**, displays the number of **Available DSP-Cards**, **Link Input Gain to Output** and two buttons in order to **Clean Tables** and **Refresh Distribution**.

It also contains the following page buttons:

- **View All Points** - Contains the **SwitchPoints Overview Table** with all of the switchpoints.
- **Filter** - **Switchpoint Filter Table**.

### Input Overview

Input Overview page shows the **Input Overview Table**.

### DSP Cards

This page displays the **DSP Cards Table**, a parameter in order to On/off the **Half-Hourly Hanging DSP Check**, the number of **All DSP Cards**, and 4 buttons: **Refresh DSP Data**, **Refresh Distribution**, **Clean Hanging DSP** and **Reset Alarm**.

### Monitoring Table

This page contains the **Monitoring Input-Output Table**.
