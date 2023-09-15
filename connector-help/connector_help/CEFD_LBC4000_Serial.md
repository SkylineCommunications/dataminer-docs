---
uid: Connector_help_CEFD_LBC4000_Serial
---

# CEFD LBC-4000 Serial

Comtech EF Data's LBC-4000 L-band up-/down-converter system is designed to interface legacy 70 MHz or 140 MHz equipment with tri-band or quadband block converters.

## About

With this connector, it is possible to monitor and configure **CEFD MBT-5000** devices with a **serial** connection.

The different parameters of the device are displayed on multiple pages, similar to the web interface of the device.

### Version Info

| **Range** | **Description**      | **DCF Integration** | **Cassandra Compliant** |
|------------------|----------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version      | Yes                 | Yes                     |
| 2.0.0.x          | Protocol name change | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |
| 2.2.0.x          | N/A                         |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The IP address of the device.
- **IP port**: The IP port of the device.
- **Bus address**: By default: *1*. Range: *0000 - 1111*.

## Usage

### Main View

This page displays information on the device, such as the **Equipment Type**. In the Device Information section, you can also set the **Application ID 1st Line**, **Application ID 2nd Line**, **Time** and **Date** of the device.

In the Redundancy Settings section, you can set the **Redundancy Mode** and **Auto/Manual Redundancy Mode**. This section also displays the **Online Unit**, and allows you to trigger a switch using the **Switchover** button.

Via the Device Status page button, you can view the **12V Supply \#1, 8V Supply \#1, 5V Supply \#1, 12V Supply \#12, 8V Supply \#12, 5V Supply \#1 Reference Oscillator**.

### Configuration

This page allows you to configure the device. It also displays information, such as **Remote Interface**, **External Reference** and **Auto Fault Recovery**.

The **Remote Mode** parameter allows you to define whether the unit is being controlled locally or remotely. Via the **Remote Settings** page button, you can set the **Remote Baud Rate** and the **Remote Address.**

With the **Reference Oscillator Adjust** parameter, you can change the reference oscillator frequency.

You can also configure the **Fault Recovery Logic**, **VFD Brightness Adjust** and **Firmware Image Selection.**

Finally, a button allows you to **Clear Stored Alarms**.

### Converter A

On this page, you can find and adjust the **Attenuation, Attenuation Offset, Operating Frequency, Slope Adjust, Inversion, Mute Mode** and **Mute State.**

The page also displays the **Serial Number**, **Type**, **Status**, **IFLO**, **RFLO** and **Temperature**.

### Converter B

On this page, you can find and adjust the **Attenuation, Operating Frequency, Slope Adjust, Inversion, Mute Mode** and **Mute State.**

The page also displays the **Serial Number**, **Type**, **Status**, **IFLO**, **RFLO** and **Temperature**.
