---
uid: Connector_help_Imagine_Communications_MDP6801+D
---

# Imagine Communications MDP6801+D

The **Imagine Communications MDP6801+D** connector combines a **serial** and **smart-serial** connection to monitor and configure the Automatic Changeover card in an Imagine Communications frame. Alarm monitoring can be activated on all important parameters.

## About

With this connector, you can monitor and configure the Imagine Communications converter card.

This converter card can be used in two ways. it can be used as an **Inserter module** or as an **Extractor module**. Based on the module configuration, certain parameters will become available and others will get the exception state "*N/A*".

The write parameter ranges and discreet values are retrieved from the device and dynamically updated in the element card.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

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

### Alarms Page

On this page, all alarm parameters are displayed. The state of the alarms can be *Alarm Inactive* or *Alarm Active*. Alarm monitoring is available for these parameters. With the buttons *Enable* and *Disable* you can change the monitoring state on the device card.

### General Page

On this page, all general parameters are available. Some parameters can be configured, such as **License Key**, **Working Mode** and **Factory Recall**. Other parameters are not configurable, such as **Serial Number** and **Installed Options**.

Based on the configuration of the **Working Mode**, the card will work in a different way. It can be set to *Inserter* or *Extractor*. Based on the selection, certain parameters will be available and others will get the state "*N/A*".

### Data Input Page

On this page, you can find the configuration, states and settings to control and monitor the Input parameters. There are page buttons available to navigate to other Data Input settings.

### Data Output Page

On this page, you can find the configuration, states and settings to control and monitor the Output parameters. There are page buttons available to navigate to other Data Output settings.

### General Purpose Interface Page

The General Purpose Interface or GPI is divided over two pop-up pages, **Outputs-** and **Inputs GPI Settings**.

Based on the **Working Mode**, different parameters will be polled. If the mode is set to *Extractor*, then the Output GPI settings will be available and the Input GPI settings (*Inserter* Mode) will be disabled. If the mode is switched, the other parameters will become available.

### SDI Page

This page contains all the SDI Settings and a few error counters such as the **Y CRC**, **C CRC**, **CRC** and **EDH Error Counter**. There is also a setting to clear the counter values.

### SQM Page

This page contains two page buttons that can be used to navigate to the **SQM Status Page** and the **SQM Settings Page.** On the status page, you can monitor the **Payload ID** and **Audio** parameters. On the settings page, you can configure the SQM settings.

### Web Interface Page

On this page, you can access the web interface of the Imagine Communications frame. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

A **serial** connector with **smart-serial** connection means that there has to be a connection to a real device. If there is a change on the device, a response will be pushed to the DMA even if no poll request is sent.
