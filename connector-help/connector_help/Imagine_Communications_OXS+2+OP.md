---
uid: Connector_help_Imagine_Communications_OXS+2+OP
---

# Imagine Communications OXS+2+OP

The **Imagine Communications OXS+2+OP** connector combines a **serial** and **smart-serial** connection to monitor and configure the Receiver card in an Imagine Communications frame. Alarm monitoring can be activated on all important parameters.

## About

With this connector, you can monitor and configure the Imagine Communications card.

Current Version: 1.0.0.1

## Installation and configuration

### Creation

This is a serial connector combined with smart-serial communication. During the creation of the element, the port settings need to be filled in correctly. These communication settings will be used to send and receive commands and responses to and from the device.

#### SERIAL MAIN CONNECTION

- **IP address/host**: **UDP/IP**: The polling IP of the device, e.g. *172.32.65.38.*
- **IP port**: The IP port of the device, set to the fixed value *4050.*
- **Bus address**: This is a combination of the frame number and slot number/ID: "\<frameNumber\>**.**\<slotID\>" (e.g. frame 1 and slot 12 = bus address *1.12).*

#### SMART-SERIAL PORTDEV CONNECTION

- **IP address/host**: **UDP/IP**: The local DataMiner IP to receive responses, e.g. *172.0.0.50.*
- **IP port**: The IP port of the DMA, set to the fixed value *4000.*

## Usage

### Alarms Page

On this page, several alarm parameters are displayed for the two channels (**Loss of Signal, Cannot Lock**, **Signal Alarm** and **Unsupported Format**). The state of the alarms can be *Alarm Inactive* or *Alarm Active*. Alarm monitoring is available on these parameters.

### Processing Page

This page contains one page button, **Other**. On this page you can configure the **CH01 Bitrate Select** and **CH02** **Bitrate Select**. Possible values to set are *Auto*, *270Mbps*, *1.5Gbps*, *3Gbps* or *Bypass*.

### Status Page

This page contains one page button, **Other**. On this page you can see the **CH01 Signal Strength**, **CH01 Input Format**, **CH01 Signal Lock**, **CH02 Signal Strength**, **CH02 Input Format** and **CH02 Signal Lock**.
Trending is possible on the Signal Strength parameters.

### System Page

This page contains one page button, **Other**. On this page you can view the following parameters: **Module Option**, **Receiver Type** and **Serial Number**. In addition, there is also the **License Key** parameter, which can be configured.

### Web Interface Page

On this page you can access the web interface of the Imagine Communications frame. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

A **serial** connector with **smart-serial** connection means that there has to be a connection to a real device.
If there is a change on the device, a response will be pushed to the DMA even if no poll request is sent.
