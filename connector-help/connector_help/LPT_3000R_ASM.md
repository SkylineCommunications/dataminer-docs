---
uid: Connector_help_LPT_3000R_ASM
---

# LPT 3000R ASM

The **LPT 3000R** device is a fully synthesized RF spectrum analyzer unit. It provides a powerful RF test and measurement tool for CDMA and WCDMA RF systems, broadcast RF systems and EMI/EMC.

## About

The **LPT 3000R ASM** connector is a solution designed for RF Spectrum Analyzer Units that receives **SNMP** traps with information about alarms.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

Supported firmware versions

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | v2.2.5 Beta 2               |

## Installation and configuration

### Creation

**SNMP Main connection**
This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.

## Usage

### Trap Info Page

The Trap Info Page contains trap's information about the alarms raised by the monitoring Spectrum Analyzers. This information is displayed in a table called **Trap Table** with the following columns:

- **Instance:** The value for the Trap ID;
- **Alarm Status:** It can be Alarm or OK;
- **Spectrum Analyzer** Name: The device that raised the alarm;
- **Spectrum Analyzer IP**, The IP Address of the device that raised the alarm;
- **Alarm Type**: It can be Threshold Monitor Alarm, Marker Delta Alarm or Spectral Shape Alarm;
- **Start date** of the alarm: The specific date of the first occurrence of the alarm;
- **End date** of the alarm: The specific date when the alarm was cleared;
- **Last Timestamp:** The timestamp of the last trap received;
- **Alarm Count:** The number of traps received for a specific alarm**;**
- **Delete Row**, with a delete row button.

It also contains a counter with the number of different traps received and a page button called **Configuration** that will open a pop-up page with the following parameters:

- **Trap IP Sources**: The IP Address of the device that will send SNMP traps.
- **Time to Clear**: The chosen value of time to change the status alarm to OK when no trap is received.
- **Alarm Filter Status**: A configurable parameter to enable/disable a filter for displayed alarms.
- **Alarms Max Number**: The maximum number of alarms that can be displayed. This value will only be used if the Alarm Filter is enable.
- **Alarm Clean Up Method**: There is three possible ways to clean up the Alarms Table:

  - Based on the amount of rows (option Row Count)
  - Based on the amount of time the alarm exists (option Alarm Age)
  - Based on a combination of the both. In this case the check on the 'Row Count' is done first (option Combo)

- **Alarms Clean Up Amount**: The amount of oldest alarms removed from the Alarms Table when the maximum has been reached.
- **Max Age Alarms**: The maximum age of a alarm allowed in the Alarms Table.
