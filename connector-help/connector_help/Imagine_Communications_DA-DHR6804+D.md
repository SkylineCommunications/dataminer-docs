---
uid: Connector_help_Imagine_Communications_DA-DHR6804+D
---

# Imagine Communications DA-DHR6804+D

The **Imagine Communications DA-DHR6804+D** connector uses both **serial** and **smart-serial** communication to monitor and configure the Amplifier card in an Imagine Communications frame. On all important parameters, alarm monitoring can be activated.

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

On this page, several alarm parameters are displayed: **Ch.1 Loss of Input, Ch.2 Loss of Input**, **Ch.1 Loss of Lock** and **Ch.2 Loss of Lock**. The state of the alarms can be: '*Alarm Inactive'* or '*Alarm Active'*. Alarm monitoring is available for these parameters.

For each alarm parameter, there are also two write buttons to **Enable** or **Disable** the alarm on the device.

### Other Page

On this page, you can configure the following parameters: **Output Config.**, **Ch.x Re-Clocking Mode**, **Ch.x Loss of Input Alarm**, **Ch.\<x\> Loss of Lock**, **Ch.\<x\> Loss of Lock Alarm**, **Ch.\<x\> Signal Present**, **Current Input**, **Ch.x Slew Rate**, **Out\<x.y\> Cable Fault** (x=1 or 2, y = A, B, C or D), **Ch.x Data Rate**, **Green Mode**, **Parameter Hysteresis**.

### Processing Page

Two parameters are available on this page:

- **License Key:** a read-write parameter.
- **Serial Number:** a read-only parameter.

### Web Interface Page

On this page, you can access the web interface of the Imagine Communications frame. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

A **serial** connector with **smart-serial** connection requires a connection to a real device.

If there is a change on the device, a response will be pushed to the DMA, even if no poll request was sent.
