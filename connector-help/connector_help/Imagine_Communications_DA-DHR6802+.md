---
uid: Connector_help_Imagine_Communications_DA-DHR6802+
---

# Imagine Communications DA-DHR6802+

The **Imagine Communications DA-DHR6802+** connector combines a **serial** and **smart-serial** connection to monitor and configure the Amplifier card in an Imagine Communications frame. Alarm monitoring can be activated on all important parameters.

## About

With this connector, you can monitor and configure the Imagine Communications card.

Current Version: 1.0.0.3

## Installation and configuration

### Creation

This is a serial connector combined with smart-serial communication. During the creation of the element, the port settings need to be filled in correctly. These communication settings will be used to send and receive commands and responses to and from the device.

#### SERIAL MAIN CONNECTION

- **IP address/host**: The polling IP of the device, e.g. *172.32.65.38.*
- **IP port**: The IP port of the device, set to the fixed value *4050.*
- **Bus address**: This is a combination of the frame number and slot number/ID: "\<frameNumber\>**.**\<slotID\>" (e.g. frame 1 and slot 12 = bus address *1.12).*

#### SMART-SERIAL PORTDEV CONNECTION

- **IP address/host**: The local DataMiner IP to receive responses, e.g. *172.0.0.50.*
- **IP port**: The IP port of the DMA, set to the fixed value *4000.*

## Usage

### Alarms Page

On this page, several alarm parameters are displayed (**Ch.1 Loss of Input, Ch.2 Loss of Input**, **Ch.1 Input Not Locked** and **Ch.1 Input Not Locked**). The state of the alarms can be *Alarm Inactive* or *Alarm Active*. Alarm monitoring is available on these parameters.

### Input Page

This page contains one page button, **Other**. On this page you can see the **Ch.1 Signal Presence, Ch.2 Signal Presence** and **Current Input**.

**Ch.1 Cable Length** and **Ch.2 Cable Length** can be configured (*Maximum*, *Medium* or *Low*).

### Output Page

This page contains one page button, **Other**. On this page you can see the **Ch.1 Data Rate** and **Ch.2 Data Rate**.

**Ch.1 Slew Rate** and **Ch.2 Slew Rate** can be configured (*HD*, *SD* or *Auto*).

### Processing Page

This page contains one page button, **Other**. On this page you can configure the following parameters: **Output Config.**, **Ch.1 Re-Clocking Mode**, **Ch.2 Re-Clocking Mode**, **Ch.1 Loss of Input Alarm**, **Ch.2 Loss of Input Alarm**, **Ch.1 Loss of Lock Alarm**, **Ch.2 Loss of Lock Alarm** and **Backup Mode** (*Enabled* or *Disabled*).

### Web Interface Page

On this page you can access the web interface of the Imagine Communications frame. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

A **serial** connector with **smart-serial** connection means that there has to be a connection to a real device.
If there is a change on the device, a response will be pushed to the DMA even if no poll request is sent.
