---
uid: Connector_help_Double_D_Electronics_DDA89-02
---

# Double D Electronics DDA89-02

The connector monitors the activity of the Double D Electronics DDA89-02 Controller.

## About

The connector has a serial communication to the Double D Electronics DDA89-02 and allows the end user to control and monitor the switches/best route configuration, plus observe the status of the device's converters.

In addition to the previous, the connector uses three timers: 1) one polling every half second for fast varying information from the controllers; 2) one polling every five seconds that retrieves general information from the device and its switches as well; and 3) one that polls every hour for slowly varying information.

### Version Info

| **Range** | **Description** |
|------------------|-----------------|
| 1.0.0.x          | Initial Version |

## Installation and Configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

- IP address/host: The polling IP of the device
- IP port: The IP port of the device.
- Bus address: The bus address of the device.

## Usage

The connector has three pages: 1) General, 2) Switches, and 3) Converters.

### General Page

In the general page, the user can observe some general information from the device on the left such as the **Unit Type**, the **Software Version**, the **Number of Supported Paths**, the **Number of Switch Banks Fitted.**

In addition to the previous, the user can define the device's mode (**Global Device Mode**) and its respective **Control Mode**.

On the right side of the page, you can see if there are any faults regarding **Active Alarms**, **Secondary Alarms,** and faults in the PSUs (**PSU 1 Fault** and **PSU 2 Fault**).

### Switches Page

In the Switches Page, the user can configure the status of the active switches from the toggle buttons (**Switch 1-8**) - plus there is a page button that allows the user the configure/perform the route calculation for the switches themselves in the **"Route Calculation..."** page button.

### Converters Page

In the converters page a table is presented with the device's converters' status with the following information:

- **Converter Index**
- **Frequency**
- **Attenuation**
- **Fitted**
- **Mode**
- **Mute**
- **Inverted Spectrum**
- **Auto C/O Logic**
- **Input Fault**
- **Delayed Fault**
- **Comms Fault**
