---
uid: Connector_help_Ericsson_CE-xH40
---

# Ericsson CE-xH40

The **Ericsson CE-xH40** connector has a **serial** connection to monitor and configure the Ericsson encoder device over HTTP. Alarm monitoring and trending can be activated on all important parameters.

## About

With this connector, you can monitor and configure the Ericsson encoder. This module's MPEG-4 AVC Fidelity Range Extensions (FRExt) enable the operator to capture, archive and distribute content in the best possible quality HDTV. The encoder supports multi-channel and multi-codec.

### Version Info

| **Range** | **Description**                   | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                   | No                  | No                      |
| 2.0.0.x          | Support for firmware version 9.0  | No                  | No                      |
| 3.0.0.x          | Support for firmware version 9.15 | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Before 9.0                  |
| 2.0.0.x          | 9.0                         |
| 3.0.0.x          | 9.15.0                      |

## Installation and configuration

### Creation

#### Serial main connection

This is a serial connector that will send HTTP commands (default HTTP on port 80). During the creation of the element, the port settings need to be filled in correctly. These communication settings will be used to send and receive commands and responses to and from the device.

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *172.32.65.38.*
- **IP port**: The IP port of the device, set to default value port *80.*

## Usage

### Overview

On this page, a tree control is available that displays the relations between the outputs, Transport Streams, Services and Components tables. Navigation is very easy in this tree control.

Note that the tree control is set to read only, so it is not possible to perform sets on this page.

### General

This page displays general information, such as **UTC Time**, **UTC Date**, **SNTP Server**, **Model Type**, **Build Version** and **Serial Number**.

There is also a **Slot Table** that contains all the installed slots with their information (**Slot** **Number**, **Description**, **Serial Nr.** and **Hardware**).

There is also a **Reboot** button available. If you click this button, the confirmation message will always be displayed as a pop-up in order to prevent a wrong user action.

### Alarms

On this page, there is one **Alarm Table**, containing all the alarms with their properties (**Alarm** **Name**, **Description**, **Time**, **Severity**, **Source** and **Slot**). Alarm monitoring is enabled on the columns **Alarm** **Severity** and **Alarm Description**.

### Streams

On this page, the four tables can be found that are used in the tree control on the **Overview page**. These tables contain the editable configuration parameters. You can monitor the bitrate or update the settings for these streams.

### Stream Config

On this page, you can add or delete a **Transport Stream** to/from an output, add or delete a **Service** to/from a transport stream, and add or delete a **Component** to/from a service.

### CE-xH4x VideoInput

On this page, you can configure the **Pre-Processor VideoInput** table per slot. Settings such as **Source**, **Format**, **Bandwidth** and **Output On Video Loss** are available.

### CE-xH4x Video Encoder

On this page, you can configure the **Pre-Processor Stream Output** table and **Pre-Processor Video Encoder** table per slot. Settings such as **Resolution**, **Bitrate**, **Aspect Ratio**, etc. are available.

### CE-xH4x VBI and VANC Data

On this page, you can configure the **Pre-Processor VBI and VANC Data** table, **Aspect Ratio** table, **Lines 625** table and **Lines 525** table per slot.

### CE-xH4x Audio

On this page, you can find 16 page buttons: **CE-xH4x Audio 1** to **CE-xH4x** **Audio 16**. These open subpages where you can configure the **Audio Inputs** and **Encoders** for all slots.

### CE-xH4x Dolby

On this page, there are eight **Metadata Preset** tables (1 to 8). You can configure these eight Dolby preset profiles.

### Reflex

On this page, all reflex parameters are available: **Version**, **Port**, **Command Port**, **Status Port**, **PCR Exchange Timeout Period**, **TTL** and **Set Rate Timeout Period**.

### Control Network

On this page, the network settings are available. In addition to basic settings, **IP** and **MAC Address**, **Subnet Mask**, and **Gateway**, there are also network redundancy settings available. The page button **Control Network Ports...** displays a subpage with the physical connected ports.

### Data Network 1-2

This page is similar to the **Control Network Page**, but contains the **Network 1** parameters.

### Data Network 3-4

This page is similar to the **Control Network Page**, but contains the **Network 2** parameters.

### Web Interface Page

On this page, you can access the web interface of the Ericsson CE-xH40 Encoder. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
