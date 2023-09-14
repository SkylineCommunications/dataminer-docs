---
uid: Connector_help_Crystal_Vision_ViViD_3GS
---

# Crystal Vision ViViD 3GS

The **Crystal Vision ViViD 3GS** is a 3G/HD/SD variable video delay with framestore synchronizer.

## About

The Crystal Vision ViViD 3GS connector makes it possible to monitor and control a specific Crystal Vision ViViD 3GS card. In addition, this connector is able to control the main features of this device: RGB/YUV gains, full vertical and horizontal timing and cross-locking.

All data is retrieved using an SNMP connection. The bus address of an element is used to indicate the card number to poll.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device.
- **Device address**: Required. Indicates the position of the card in the chassis to poll.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public.*
- **Set community string**: The community string used when setting values on the device. The default value is *private.*

### Configuration

No additional configuration is needed in the element.

## Usage

### General

This page displays general status information of the device.

The **Input Standard** and **Reference Standard** status provide information related to the video standards of the incoming video and the external reference respectively.

### Control

This page contains various controls associated with the board mode.

### Synchroniser

This page contains parameters related to the synchroniser feature of the card. The synchroniser can be timed to an external Black and Burst or tri-level syncs analogue reference. This means that you can use one board to apply a long delay to a video path and lock the signal to a station reference at the same time.

### Delay

On this page, you can configure the input to output video delay. There are parameters to configure the delay in seconds, frames, lines and pixels.

### YUV

This page contains YUV lift and gain controls used for image adjustments in the YUV domain.

### RGB

This page contains RGB lift and gain controls used for image adjustments in the RGB domain.

### Alarms

This page contains the settings for the GPO alarms. The GPO 5 and GPO 6 output is reserved for alarm indication and can have any of the video alarms listed in this page assigned (**Input missing,** **Reference missing,** **Video black** and **Video Frozen**).

The **Alarm Delays** parameters allow you to specify a delay before the alarms will be raised.

### Presets & Resets

This page contains controls to store and recall up to 16 user-defined configurations. To save the current settings, select the preset number and click **Store**. If the selected preset number contains a previously saved configuration, it will be overwritten. To recall previously stored setting information, select the preset number and click **Recall**. The recalling of previously stored presets can also be implemented externally via the GPI port. In this case, choose between *level* or *pulse* in the **GPI Enable** control.

The device can also be reset to factory defaults. There are two possibilities: **Factory Reset Excl Presets**, to reset without changing the presets, or **Factory Reset Incl Presets**, to reset and clear all presets.

### Web Interface

Displays the web interface of the device. The client machine has to be able to access the device. If not, it will not be possible to open the web interface.
