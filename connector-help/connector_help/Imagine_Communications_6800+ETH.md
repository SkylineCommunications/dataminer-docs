---
uid: Connector_help_Imagine_Communications_6800+ETH
---

# Imagine Communications 6800+ETH

The **Image Communications 6800+ETH** connector uses both **serial** and **smart-serial** communication to monitor and configure the Basic Chassis from an Imagine Communications frame.

## About

With this connector, it is possible to both monitor and set parameters of the Imagine Communications card. There is a retry mechanism that repolls the parameters if the frame is busy and unable to handle the requests.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

## Installation and configuration

### Creation

This a serial connector combined with smart-serial communication. During the creation of the element, the port settings need to be filled in correctly. These communication settings will be used to send and receive commands and responses to and from the device.

#### SERIAL MAIN CONNECTION

- **IP address/host**: The polling IP of the device, e.g. *172.32.65.38.*
- **IP port**: IP port of the device, fixed value: *4050.*
- **Bus address**: This is a combination of the frame number and slot number/ID: \<frameNumber\>**.**\<slotID\>. E.g. frame 1 and slot 21 = bus address *1.21*. The ETH Module is always on slot 21.

#### SMART-SERIAL PORTDEV CONNECTION

- **IP address/host**: The local DataMiner IP used to receive responses, e.g. *172.0.0.50.*
- **IP port**: The IP port of the DMA, fixed value: *4000.*

## Usage

### System Page

On this page, you can see the **IP Address** and **Thumbnail Rate**.

### Web Interface Page

On this page, you can access the web interface of the Imagine Communications frame. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

A **serial** connector with **smart-serial** connection requires a connection to a real device.

If there is a change on the device, a response will be pushed to the DMA, even if no poll request was sent.
