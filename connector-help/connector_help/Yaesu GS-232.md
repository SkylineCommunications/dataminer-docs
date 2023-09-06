---
uid: Connector_help_Yaesu_GS-232
---

# Yaesu GS-232

The **GS-232** is a control interface that provides digital control of most models of Yaesu antenna rotators.

The **Yaesu GS-232** connector is used to monitor and control antenna rotators that use the Yaesu GS-232(A) control interface.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### IP Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.
  - **Bus address**: The bus address of the device.

## How to use

On the **General** page, you can view and set the current Azimuth Angle of the antenna. You can manage the antenna rotation direction using the Rotate CW/CCW buttons. With the Stop button, you can stop the rotation.

The **Start Stepping** button can be used to step through the full 360 degrees with steps of the configured **Rotation Step Size**. At each azimuth angle that is a multiple of this **Rotation Step Size**, the rotator stops/pauses for the number of seconds configured with the **Dwell Time** parameter and then continues the stepping.

The Start Stepping feature uses an Automation script called **RotatorControlStepping**. This script has to be set up and configured on the DMA for this feature to work. Skyline employees can find this script in the Automation Scripts tab of the repo manager, under *Automation* \> *Customers* \> *SES Networks - USA* \> *RotatorControlStepping*. If you want to use this feature and you are not a Skyline employee, contact Skyline for assistance. A copy of the script will need to be cloned for you and placed on your system.
