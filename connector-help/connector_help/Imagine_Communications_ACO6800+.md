---
uid: Connector_help_Imagine_Communications_ACO6800+
---

# Imagine Communications ACO6800+

The **Imagine Communications ACO6800+** connector combines a **serial** and **smart-serial** connection to monitor and configure the Automatic Change Over card in an Imagine Communications frame. Alarm monitoring can be activated on all important parameters.

## About

With this connector, you can monitor and configure the Imagine Communications card.

The write parameter ranges and discreet values are retrieved from the device and dynamically updated in the element card.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

## Installation and configuration

### Creation

This is a serial connector combined with smart-serial communication. During the creation of the element, the port settings need to be filled in correctly. These communication settings will be used to send and receive commands and responses to and from the device.

#### SERIAL MAIN CONNECTION

- **IP address/host**: The polling IP of the device, e.g. *172.32.65.38.*
- **IP port**: The IP port of the device, set to the fixed value *4050.*
- **Bus address**: This is a combination of the frame number and slot number/ID: "\<frameNumber\>**.**\<slotID\>" (e.g. frame 1, slot 12 = bus address *1.12).*

#### SMART-SERIAL PORTDEV CONNECTION

- **IP address/host**: The local DataMiner IP to receive responses, e.g. *172.0.0.50*.
- **IP port**: The IP port of the DMA, set to the fixed value *4000.*

## Usage

### ACO Group A Page

This page contains three page buttons: **Switch Settings**, **General Purpose Interface** and **MISC Settings.** These open pages where you can configure the **ACO Group A** parameters.

### ACO Group B Page

This page also contains three page buttons: **Switch Settings**, **General Purpose Interface** and **MISC Settings.** These open pages where you can configure the **ACO Group B** parameters.

### Alarms Page

On this page, alarm parameters are displayed: **Grp A Relay Bypass On** and **Grp B Relay Bypass On**. The state of the alarms can be *Alarm Inactive* or *Alarm Active*. Alarm monitoring is available for these parameters.

### Frozen Detection Sensitivity Page

On this page, there are two configuration parameters: **Level Sensitivity** and **Pixel Sensitivity**. The range of these parameters is from *0 to 10*. Trending is available on both parameters.

### General Page

On this page, all general parameters are available. Some parameters can be configured, such as **License Key**, **Operation Mode**, **Thumbnail Source**, **Soft Reboot** and **Factory Recall**. Other parameters are not configurable, such as **Serial Number**, **Enabled Options**, **Submodule Available** and **Backmodule Type**.

### Inputs Page

On this page, you can navigate to the **Input 1** or **Input 2** pop-up pages. On these pages you can find the subpages **Status**, **SQM Setting** and **SQM**, where you can view and control the input parameters.

### Web Interface Page

On this page, you can access the web interface of the Imagine Communications frame. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

A **serial** connector with **smart-serial** connection means that there has to be a connection to a real device.
If there is a change on the device, a response will be pushed to the DMA even if no poll request is sent.
