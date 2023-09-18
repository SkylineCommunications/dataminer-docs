---
uid: Connector_help_Imagine_Communications_AES6800+
---

# Imagine Communications AES6800+

The **Imagine Communications AES6800+** connector combines a **serial** and **smart-serial** connection to monitor and configure the Amplifier card in an Imagine Communications frame. Alarm monitoring can be activated on all important parameters.

## About

With this connector, you can monitor and configure the Imagine Communications card.

Current Version: 1.0.0.1

## Installation and configuration

### Creation

This is a serial connector combined with smart-serial communication. During the creation of the element, the port settings need to be filled in correctly. These communication settings will be used to send and receive commands and responses to and from the device.

#### SERIAL MAIN CONNECTION

- **IP address/host**: The polling IP of the device, e.g. *172.32.65.38.*
- **IP port**: The IP port of the device, set to the fixed value *4050.*
- **Bus address**: This is a combination of the frame number and slot number/ID: "\<frameNumber\>**.**\<slotID\>" (e.g. frame 1 and slot 12 = bus address *1.12).*

#### SMART-SERIAL PORTDEV CONNECTION

- **IP address/host**: The local DataMiner IP to receive responses, e.g. *172.0.0.50 or keyword "any".*
- **IP port**: The IP port of the DMA, set to the fixed value *4000.*

## Usage

### Alarms Page

On this page, several alarm parameters are displayed (**Channel Status CRC Error, Loss of Input Locked**, **Aes Input Not Valid**, **Confidence-**, **Aes Phase-** and **Parity- Error**). The state of the alarms can be *Alarm Inactive* or *Alarm Active*. Alarm monitoring is available on these parameters. For each alarm parameter, there are also two write buttons to *Enable* or *Disable* the alarm on the device.

### Parameters Page

The following parameters are available on this page:

- **Receiver Mode:** a read-write parameter with possible values *AES* and *Bypass*.
- **Signal Present**: a read-only parameter with possible values *Yes* and *No*.

### Web Interface Page

On this page you can access the web interface of the Imagine Communications frame. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

A **serial** connector with **smart-serial** connection means that there has to be a connection to a real device.
If there is a change on the device, a response will be pushed to the DMA even if no poll request is sent.
