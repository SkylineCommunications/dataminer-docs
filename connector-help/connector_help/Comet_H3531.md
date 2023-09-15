---
uid: Connector_help_Comet_H3531
---

# Comet H3531

This connector is used to communicate with the **Comet H3531** device, which measures temperature and relative humidity. The device has two relay outputs to control other devices and three binary inputs to detect two-state signals.

## About

The device is able to measure temperature values between -30 øC and 105 øC. It also measures the relative humidity, which varies between 0 and 100%. Based on these values, it calculates the dew point value, which varies between 0 and 100%.

### Version Info

| **Range** | **Description** |
|------------------|-----------------|
| 1.0.0.x          | Initial version |

### Product Info

| **Range** | **Description** |
|------------------|-----------------|
| 1.0.0.x          | 04.1904.21      |

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host:** Required. The polling IP of the device.
- **Device addres:** Not required.

**SNMP Settings:**

- **Port number:** Required. The port of the connected device, by default *161*.
- **Get community string:** The community string used when reading values from the device. The default value is *public.*
- **Set communicty string:** The community string used when reading values from the device. The default value is *private*.

## Usage

### Status

On this page, you can find the two measured values and the computed value, i.e. the dew point. They are also shown by means of a LED bar that displays the measurable range. For **Temperature**, this is between -30 øC and 105 øC. For **Relative Humidity** and **Dew Point**, this is between 0% and 100%.

The **Relay Output** status of both relays is also displayed here, and can be *0* or *1*, depending on whether the relay status is open or closed. The settings determining when the relay output should be open or closed can be configured with the device keyboard, but not via DataMiner (see below).

### Settings

On this page, 21 settings are displayed:

- The 12 settings at the top of the page apply to the acoustic alarm, which can be configured with the device, and have nothing to do with the DataMiner alarm configuration. It is for example possible to set the higher limit of the temperature to 50 øC, with a temperature alarm delay of 30 seconds and a hysteresis of 2 øC. Then, if it is enabled with the device keyboard, the acoustic alarm will be triggered 30 seconds after the temperature exceeds 50 øC and it will stop when the temperature drops below 48 øC (i.e. higher limit - hysteresis). This is explained in detail on the parameter card of every setting, which you can access by double-clicking the setting. To configure these settings, click the page button **Change the Settings...** in the lower right corner.
- The 6 settings in the lower left corner of the page cannot be set with DataMiner, but only with the device keyboard. With these settings, you can configure that the relay output becomes 1 if the temperature drops below a certain point.
- The 3 settings in the lower right corner are related to the binary input. With these settings you can configure the alarm delay of every binary input. If, for example, binary input 1 is configured to send an email when input changes from high to low, and the alarm delay is set to 20 seconds, then the email will be sent 20 seconds after the change from high to low. If it changes from low to high again before this time, e.g. after 15 seconds, no email is sent. You can configure these settings with the page button **Change the Settings...** in the lower right corner.

### Web Interface

This page displays the webpage of the SNMP device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
