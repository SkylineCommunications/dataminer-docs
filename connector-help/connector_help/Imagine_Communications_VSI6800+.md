---
uid: Connector_help_Imagine_Communications_VSI6800+
---

# Imagine Communications VSI6800+

The **Imagine Communications VSI6800+** connector combines a **serial** and **smart-serial** connection. This connector is used to monitor and configure the VSI6800+ amplifier card in an Imagine Communications frame. It is possible to activate alarm monitoring and trending on all important parameters.

## About

Serial commands are used to set parameters on the device and information is retrieved through smart serial responses.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**      |
|------------------|----------------------------------|
| 1.0.0.x          | HW version 1.00, SW version 1.03 |

## Installation and configuration

### Creation

The **Imagine Communications VSI6800+** connector combines **serial** and **smart-serial** communication. During the creation of the element, the port settings need to be filled in correctly. These communication settings will be used to send and receive commands and responses to and from the device.

SERIAL CONNECTION:

- **IP address/host**: The polling IP address of the device, e.g. *192.168.2.17.*
- **IP port**: The IP port of the device, by default *4050.*
- **Bus address**: This is a combination of the frame number and slot number/ID: \<frameNumber **.** slotID\>. E.g. frame 1 & slot 12 corresponds to the following bus address: *1.12*.

SMART-SERIAL CONNECTION:

- **IP address/host**: The local DataMiner IP address to receive responses (e.g. *192.168.2.1*)
- **IP port**: The IP port of the DMA, by default *4000.*

## Usage

### General Page

This page displays the device parameters: **Signal Present**, **Locked Data Rate** and **Re-Clocking Mode**.

### Alarms Page

This page displays the alarm parameters: **Loss of Input Locked** and **Loss of SDI**. The state of the alarms can be "*Alarm Inactive*" or "*Alarm Active*". Alarms can be **Enabled** or **Disabled** using interface buttons.

### Web Interface Page

On this page, you can access the web interface of the Imagine Communications frame.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

A **serial** connector with **smart-serial** connection requires a connection to a real device. If there is a change on the device, then a response will be pushed to the DMA even though no poll request is sent.
