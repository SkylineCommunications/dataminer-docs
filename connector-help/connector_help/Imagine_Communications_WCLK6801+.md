---
uid: Connector_help_Imagine_Communications_WCLK6801+
---

# Imagine Communications WCLK6801+

The **Imagine Communications WCLK6801+** connector uses both **serial** and **smart-serial** communication to monitor and configure the Clock Distribution card in an Imagine Communications frame. On all important parameters, alarm monitoring can be activated.

## About

With this connector, it is possible to both monitor and set parameters of the Imagine Communications card.

Current Version: 1.0.0.1

## Installation and configuration

### Creation

This a serial connector combined with smart-serial communication. During the creation of the element, the port settings need to be filled in correctly. These communication settings will be used to send and receive commands and responses to and from the device.

#### SERIAL MAIN CONNECTION

- **IP address/host**: The polling IP of the device, e.g. *172.32.65.38.*
- **IP port**: The IP port of the device, fixed value: *4050.*
- **Bus address**: This is a combination of the frame number and slot number/ID: \<frameNumber\>**.**\<slotID\>. E.g. frame 1 and slot 12 = bus address *1.12.*

#### SMART-SERIAL PORTDEV CONNECTION

- **IP address/host**: The local DataMiner IP used to receive responses, e.g. *172.0.0.50* or keyword "*any".*
- **IP port**: The IP port of the DMA, fixed value: *4000.*

## Usage

### Alarms Page

On this page, several alarm parameters are displayed, e.g. **Loss of Signal**. The state of the alarms can be: '*Alarm Inactive'* or '*Alarm Active'*. Alarm monitoring is available on these parameters.

For each alarm parameter, there are also two write buttons to **Enable** or **Disable** the alarm on the device.

### Parameters Page

On this page, four parameters are available: **Serial Number** and **Signal Presence** (*Yes*/*No*) are read-only. **Input Type** and **Gain (dB)** are read-write parameters and can be configured.

### Web Interface Page

On this page, you can access the web interface of the Imagine Communications frame. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

A **serial** connector with **smart-serial** connection requires a connection to a real device.

If there is a change on the device, a response will be pushed to the DMA, even if no poll request was sent.
