---
uid: Connector_help_Vertex_7200
---

# Vertex 7200

The **Vertex 7200** is an antenna pointing system that positions the antenna to receive the peak signal from one or more communication satellites.

## About

The **Vertex 7200** connector will update its monitoring and configuration parameters by sending serial commands to the device.

### Version Info

| **Range** | **Description**                                                                            | **DCF Integration** | **Cassandra Compliant** |
|------------------|--------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                                            | No                  | Yes                     |
| 1.1.0.x          | Release version, requires CRC                                                              | Yes                 | Yes                     |
| 1.2.0.x          | Release version, based on 1.1.0.16, disabled CRC                                           | No                  | No                      |
| 2.0.0.x          | Release version. Layout based on 1.1.0.18. Requires MT M&C protocol to be the serial mode. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |
| 1.1.0.x          | N/A                         |
| 1.2.0.x          | N/A                         |
| 2.0.0.x          | N/A                         |

### Exported connectors

| **Exported Connector** | **Description** |
|-----------------------|-----------------|
| ACU Vertex 7200 DTR   | DTR Info        |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host:** The polling IP of the device.
- **IP port:** The IP port of the device.

### Configuration of the device

Depending on the connector version, the following settings need to be configured on the device for successful communication with the connector.

For all versions before 2.0.0.1:

- **Protocol:** RC M&C
- **Newline:** CRLF
- **Echo:** Off
- **Checksum:** enabled

For version 2.0.0.x:

- **Protocol:** MT M&C
- **Newline:** CR
- **Echo:** Disabled
- **Checksum:** Disabled

## Usage

### Main View

This page displays a summary of the information on the General page, including the status of **Drive Cabinet Faults**, **Motion Fault**, **Tracking Fault** and **System Error**.

It also contains the **Security Level** configuration, the **Front Panel Security Level**, the **Tracking Signal Level** and the **Azimuth**, **Elevation** and **Polarization** of the **Antenna Position**.

### General

This page contains the parameters mentioned above, as well as parameters for the configuration of the **Date/Time** (**Timezone Offset** and **Timezone Abbreviation**) and **Tracking Status** **(Tracking Mode**, **Tracking Target**, **Tracking Name** and **Reset OPT Target**).

Further configuration is possible with the **Clear Alarm**, **Stop Antenna**, **Resume Tracking**, **Stop Tracking** and **Auto Continue** buttons, as well as a number of buttons that control the **Azimuth**, **Elevation** and **Polarization** **Positions**.

In version 2.0.0.x of the connector, the following additional parameters are available: **OPT Tracking Status**, **Track/Target Scheduler Status** and **Steptrack Cycle.**

The page contains the following page buttons:

- **Set Date/Time**: Allows you to set the **Date/Time**.
- **Set Position**: Allows you to set a new position for the **Azimuth**, **Elevation** and **Polarization**.
- **Drive Cabinet Faults**: Displays fault parameters for the **Drive Cabinet**.
- **Motion Faults**: Displays fault parameters regarding **Motion**.
- **Tracking Faults**: Displays fault parameters regarding **Tracking**.
- **System Faults**: Displays fault parameters regarding the **System**.
- **Reference Value**: Allows you to configure the **Tracking Signal Level** and **Tracking Signal Level Ref**.
- **Satellite Table**: Displays the **Satellite Table**.
- **Clear Target**: Allows you to clear a target **By Number** or **By Name**.

In version 2.0.0.x the following additional page buttons are available:

- **Receiver Status**: Displays the **Receiver Frequency**, **Receiver Attenuation**, **RF Input Source** and **Control**.
- **Set Cycle Time**: Allows you to configure the cycle time using **Cycle Hour**, **Cycle Minute** and **Cycle Second** parameters. Use the **Set** button to apply the configuration.
- **Satellite**: Displays the **Satellite Table**, where you can create a new target and configure its Tracking Mode and Look Angles. You can also delete targets with the **Clear Target** button in each row.

### Settings

This page contains parameters related to the **Steptrack Peaks** and allows you to configure the **Slew Track** (Azimuth, Elevation and Polarization), **Site** (Longitude, Latitude and Altitude) and **Runaway** **Error Tolerances** (Azimuth, Elevation and Polarization). It also includes the **Soft Limit Status**, **Polarization Status** and **Antenna Name** configuration parameters.

The page contains the following page buttons:

- **Set Soft Limit**: Shows the **Lower CCW** and **Upper CW** **Soft Limits** for Azimuth, Elevation and Polarization. Two additional page buttons on this subpage (**Set Lower Soft Limit** and **Set Upper Soft Limit**) allow you to set these parameters.
- **Immobile/Reversed**: Allows you to set the **Timeout** and **Tolerance** (Azimuth, Elevation and Polarization).
- **Encoder Settings**: Contains encoder settings regarding **Counting Direction** and **Offset** (Azimuth, Elevation and Polarization).
- **Port Settings**: **Baudrate**, **Parity**, **Databits**, **Stopbits**, **Checksum**, **Security** **Level** and **Password**. In version 2.0.0.x of the connector, the **Port Number** and **High Security Port Number** are also available here.
- **More Settings**: **Position Loop Deadband** and **Inching on Time**.

### DTR

This page contains the **DVE Table**, which exports the **DTR info**.

## Notes

For the 1.1.0.x branch, CRC is required. However, for the 1.2.0.x branch, CRC is not supported.

#### Security level

The device contains two ports from which set commands can be done: the front panel and remote. A remote (e.g. DataMiner element) cannot execute any successful set commands while the remote security level is set to "Monitor". You first need to update the Security Level to Operator or Supervisor to make the appropriate sets (this set action can be done remotely).

- Note: Only one of the ports can have the Supervisor state at a time. This means that if the front panel is configured as Supervisor, the remote connection will not be able to take on the role of Supervisor and make the necessary sets.
  For security reasons, the remote will not be able to change the Security Level of the front panel.

#### Passwords

On the device, there is a setting to disable passwords. The device documentation details the following information: "*Passwords are a one to nine digit number. Setting a password to 0 disables protection for that security level. To completely disable passwords, set both Operator and Supervisor passwords to 0.*"
In case passwords are disabled, in the connector, the password should be set to "0" instead of "" (empty string). Otherwise, the connector would still try to calculate CRC on the password, but it would not find any value and take the following byte, resulting in a bad CRC. This would result in not being able to change the security level from "Monitor" to "Operator" or "Supervisor".
Version range 1.1.0.x, version 1.1.0.22 and up will have the functionality to work with this implemented.
