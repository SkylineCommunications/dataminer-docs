---
uid: Connector_help_Imagine_Communications_SFP6800+D
---

# Imagine Communications SFP6800+D

The **Imagine Communications SFP6800+D** connector combines a **serial** and **smart-serial** connection to monitor and configure the simple flexible processing card in an Imagine Communications frame. Alarm monitoring can be activated on all important parameters.

It allows manual creation of DVEs for **Rx1**, **Rx2**, **Tx1** and **Tx2** cards connected to the slots of the device (only available in range 1.2.0.x).

## About

With this connector, you can monitor and configure the Imagine Communications processor card. This simple flexible processing card has six SFP cages that can be populated with SDI coax, SDI optical, HDMI, analog-to-SD-SDI decoders, or SD-SDI-to-analog encoders.

The module is composed of a 12x12 routing crosspoint and six cages to accommodate the SFP modules. Each cage can contain up to two SFP units. The module uses a credit model to enable the cages.

The credits can be assigned automatically (at boot time) or manually (configurable by the user). A signal routing (a connection between a receiver and a transmitter) is only possible if the SFP is enabled by the credit assigned to the cage.

The write parameter ranges and discreet values are retrieved from the device and dynamically updated in the element card.

### Version Info

| **Range** | **Description**                 | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                 | No                  | No                      |
| 1.1.0.x          | Includes new parameters         | No                  | No                      |
| 1.2.0.x          | Includes tables to support DVEs | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 0.1.16                      |
| 1.1.0.x          | 2.0                         |
| 1.2.0.x          | 2.1                         |

### Exported connectors (only available in range 1.2.0.x)

| **Exported Connector**                   | **Description**                                                                                              |
|-----------------------------------------|--------------------------------------------------------------------------------------------------------------|
| Imagine Communications SFP6800+D - Rx1. | Displays HDMI, CMPST, electrical, optical and alarm (signal loss of SFP) information regarding the Rx1 cage. |
| Imagine Communications SFP6800+D - Rx2. | Displays HDMI, CMPST, electrical, optical and Alarm (signal loss of SFP) information regarding the Rx2 cage. |
| Imagine Communications SFP6800+D - Tx1. | Displays HDMI, CMPST, electrical and optical information regarding the Tx1 cage.                             |
| Imagine Communications SFP6800+D - Tx2. | Displays HDMI, CMPST, electrical and optical information regarding the Tx2 cage.                             |

## Installation and configuration

### Creation

This is a serial connector combined with smart-serial communication. During the creation of the element, the port settings need to be filled in correctly. These communication settings will be used to send and receive commands and responses to and from the device.

#### SERIAL MAIN CONNECTION

- **IP address/host**: The polling IP of the device, e.g. *172.32.65.38.*
- **IP port**: The IP port of the device, set to the fixed value *4050.*
- **Bus address**: This is a combination of the frame number and slot number/ID: "\<frameNumber\>**.\<**slotID\>" (e.g. frame 1, slot 12 = bus address *1.12).*

#### SMART-SERIAL PORTDEV CONNECTION

- **IP address/host**: The local DataMiner IP to receive responses, e.g. *172.0.0.50*.
- **IP port**: The IP port of the DMA, set to the fixed value *4000.*

## Usage

### General

On this page, all general parameters are available. Some parameters can be configured, such as **License Key**, **Software Reset Mode** and **Factory Recall**. Other parameters are not configurable, such as **Serial Number** and all **SFP Type Status** parameters (**A** to **F**).

There is also a pop-up page, **DVE**, which displays the four main DVE tables (**SFP RX1**, **RX2**, **TX1** and **TX2**).

### Credit

On this page, credit can be configured. For each cage, you can configure a specific credit. In addition, there is an overview of all the **Credit Statuses** of the processor, and there are a number of general parameters, such as **Licensed Credit** and **Remaining Credit**.

### SFP A to SFP F Pages

These pages all have the same structure, and they have a number of parameters in common, such as **Temperature**, **Type - Status** and **Harris P/N**.

Aside from these parameters, there are also four (eight in range 1.1.0.x) pop-up pages: **Electrical out**, **Electrical in**, **Optical out** and **Optical in** (range 1.1.x.0 and 1.2.0.x also include **HDMI out**, **HDMI in**, **CMPST out**, and **CMPST in**). These pop-up pages provide access to more settings and status information for each SFP cage.

### Output Routing & Status (only available in range 1.0.0.x)

This page contains settings and status information for each SFP, from SFP A to SFP F. For each SFP, the **Type Status**, **Tx1** and **Tx2 Source Select**, and **Tx1** and **Tx2 Source Status** are available.

### Alarms

On this page, all alarm parameters are displayed. The state of the alarms can be *Alarm Inactive* or *Alarm Active*. Alarm monitoring is available for these parameters. With the buttons **Enable** and **Disable** you can change the monitoring state on the device card.

### Web Interface

On this page, you can access the web interface of the Imagine Communications frame. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

A **serial** connector with **smart-serial** connection means that there has to be a connection to a real device. If there is a change on the device, a response will be pushed to the DMA even if no poll request is sent.
