---
uid: Connector_help_Andrew_APC100
---

# Andrew APC100

With this connector, it is possible to monitor and control the positioning of the **Andrew APC100** device. In addition, the positioning of the satellites can be configured in a memory and loaded to the device at any desired time.

Alarms on the current position can be normalized.

## About

The **Andrew APC100** makes it possible to monitor the current status of the device and its current position. When the device is positioned at a known satellite, the name of the matching satellite will appear.

The list of satellites can be configured one by one or in bulk using the memory.

In order to control the positioning of the **APC100**, it is possible to set small steps with fixed values, e.g. 0.1 degrees.

## Installation and configuration

### Creation

The **Andrew APC100** is a serial connector. The following device details need to be set:

- **IP address**
- **IP port**
- **Bus address**

The bus address range is by default from 80 until 95.

### Polling

The polling speed of the positioning depends on the **General Movement Status**. When the device is busy moving, this data is polled every second. When it is not moving, the polling is done every minute by default. It is possible to disable this polling in order to reduce the amount of communication to the device. This is done by setting **Angle Polling** to *Movement*. This setting can found on the **General** or **Position** page.

### Positioning Settings

Some device settings can be found on the **Position** page with the relevant page buttons and need to be configured to prevent errors or malfunctioning of the device itself.

Azimuth and Elevation:

- **Slow Coefficient:** The distance that the antenna coasts after turning off the slow motor.
- **Fast Coefficient:** Allows the antenna to slow down before the slow coefficient is required.
- **Calibration Factor**: This factor is added to un-calibrate resolver units.
- **High Speed Time Out Value**: The time before the power is turned off when running too fast.
- **Low Speed Time Out Value**: The time before the power is turned off when running too slow.
- **Low Limit**: The low limit of the azimuth or elevation can be set by degrees or units.
- **High Limit:** The high limit of the azimuth or elevation can be set by degrees or units.

Polarization:

- **Coefficient**: The value that allows the antenna to slow down to turn off the motors.
- **Calibration Factor**: The calibration factor used for the polarization.
- **Time Out Value**: The time before power is turned off when the motor is running slow or not at all.
- **Low Limit**: The low limit of the polarization can be set by degrees or units.
- **High Limit**: The high limit of the polarization can be set by degrees or units.

### Satellite Memory

In order to automatically calculate the position in the **Satellite Memory** **Table**, the **North Latitude** and the **West Longitude** of the **Site** have to be configured.

## Usage

### Main View Page

This page provides an overview of the main parameters on the **APC100** device. These are a few status alarms, current position and the **Mode**.

Here the **Angle Polling** can be set to *Movement* in order to poll only during movement, or to *Auto* to poll during movement and otherwise each minute.

### Position Page

On this page, the position can be monitored and changed.

The position can be set to a known satellite using the name, with **Position Name (Requested)**, or using the number, with **Position Number (Requested)**. It is also possible to set it through the **Requested Azimuth**, **Requested Elevation** or **Requested Polarization** both in degrees and in units or with the fixed step buttons, e.g. -5.0 deg, -1.0 deg, etc.

The **Angle Polling** can be set to *Movement* in order to poll only during movement, or to *Auto* to poll during movement and otherwise each minute.

The **General Movement Status** indicates if the device is already moving or if a movement has been requested but not yet executed.

The positioning settings can be found under the following page buttons: **Azimuth Settings..**, **Elevation Settings.** and **Polarization Settings.** These settings can be saved in a file or retrieved from a file and set on the device. The **Download Settings** button will retrieve the device settings and save them in a CSV file. The **Upload Settings** button will read the settings from a CSV file and set them on the device.

The **Normalize Alarms.** page button makes it possible to normalize the current position through degrees or units.

It is also possible to **Reset** the **Unit** or **Abort** the **Move**.

**The Satellite List.** page button directs to a list of known satellites loaded from the device. This list is automatically loaded, but can also be manually forced with the **Load** button. It is possible to change the position of a specific satellite with the **Edit Satellite List** attributes. These changes will be sent to the device with the **Save** button.

In order to change multiple satellites at once, it is possible to load the current situation in a memory table using the **Sat Memory.** page button. With the **Sync** button, the current data is loaded into the **Sat Memory Table**, and with the **Upload** button this entire table is sent to the device. An abort of this upload can be done using the **Abort Upload** button.

When changing a value in the **Sat Memory Table**, the position is calculated automatically. There is also a button to **Recalculate** all the items in the table. In order to do these calculations, the **Site North Latitude** and **Site West Longitude** have to be configured.

The Sat Memory Table can be imported from or exported to a file. The file name is set in **Import/Export** **FileName** and will be saved in the **documents** of the element.

### Status Page

This page provides an overview of all the statuses retrieved from the device, including device alarms and information.

The information can be manually refreshed with the **Refresh** button.
