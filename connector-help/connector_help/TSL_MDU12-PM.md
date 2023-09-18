---
uid: Connector_help_TSL_MDU12-PM
---

# TSL MDU12-PM

With this connector, you can monitor information on the **TSL MDU12-PM** device, a power management system.

## About

The TSL MDU12-PM connector is used to monitor and control a TSL MDU12-PM device. It displays both general information and specific information on inputs and outputs. In addition, it allows you to configure certain settings on the device.

### Version Info

| **Range** | **Description**                                     | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version, based on "SA DCM 2.0.0.36" connector. | No                  | Yes                     |
| 1.0.1.x          | Connector review.                                      | No                  | Yes                     |

### Supported Firmware Versions

Features in this connector are added by request. As it is possible to disable features in the poll manager so that they are not available, the connector is backwards compatible with older firmware. Very few features are no longer supported in newer firmware versions, so the connector is generally also forwards compatible.

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0x           | 5.10                        |
| 1.0.1.x          | 5.10                        |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private.*

## Usage

### General page

This page displays the **Unit Identification** and **Location**, the **Total Number of Alarms**, the **Equipment Temperature**, the **Power-on Output Sequence**, the **Sequential Mode Delay between Outputs** and the **Status of Power Inlets**.
In addition, on the right side of the page you can find the **Voltage Floor**, the **Voltage Limit**, the **Voltage Calibration** and the **Voltage**. Below this, the **Total Current** and the **Current Limit** are shown.

It is possible to set the **Location**, the **Sequential Mode Delay between Outputs**, the **Voltage** and **Current** parameters, and the **Power-on Output Sequence**.
For the latter, three possible values are available: *Immediate*, *Sequential* and *Delay*.

### I/O page

This page displays the following tables:

- **Input Table:** Contains information about the **Input Name**, the **Input Alarm** and the **Active Polarity**. Both the **Input Name** and the **Active Polarity** can be edited.
- **Output Table**: Displays the **Output Name**, the **Fuse**, the **Output Status**, the **Locked** status, the **Delay**, the **Lower and Over Current**, the **VA**, the **Watts**, the **Current**, the **Power Factor** and the **Output Calibration**.
  It is possible to set the **Output Name**, the **Delay**, the **Lower and Over Current** and the **Output Calibration**, as well as the **Output Status.**

### Web Interface page

On this page, you can view the web interface of the device. However, the client machine has to be able to access the device. Otherwise, it will not be possible to open the web interface.

## Notes

Both the **Input Table** and the **Output Table** are updated every 15 seconds.
