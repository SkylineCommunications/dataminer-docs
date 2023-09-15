---
uid: Connector_help_Evertz_HD201x_Video_PassPort
---

# Evertz HD201x Video PassPort

The HD201x PassPort is a 1RU Multi-Path Video Converter and Frame Synchronizer. It integrates four independent paths of video processing. All four paths can be fed from four different input signals. Each processing path includes full frame sync and up/down/cross conversion capabilities in addition to video proc and video enhancement capabilities.

## About

With this connector, you can directly manage the device. The connector displays information on several pages, described in the "Usage" section below.

This connector was intended to work with the HD2014 model. The connector uses **SNMP** to establish communication with the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.0                         |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string needed to read from the device.
- **Set community string**: The community string needed to set to the device.

## Usage

### General

This page displays general parameters, such as the **IP Address**, **Net Mask**, **IP Default Gateway**, **System Name**, **Reference Format**, **Reference Mode**, **Source Id State** and **Text**, and **Test Gen Format** and **Pattern**. The page also displays the **Test Gen 2 Table**.

There are 6 pages buttons that open corresponding subpages: **RGB Input**, **Button**, **AFD ARC Control**, **ANC Pass**, **SCTE 104 Control** and **GPIO**. These subpages display tables for which the polling can be enabled or disabled.

### Analog & Dvi

This page displays video settings. It allows you to view and configure the settings for **Analog Video and DVI**.

### Composite

This page displays video settings. It allows you to configure the **Composite Input 1** and **Composite Output** settings.

Two page buttons on this page provide access to the **Flex ADCHD** and **Composite Input 2** settings.

### Component

This page displays video settings. It contains configurable parameters for **Component Input 1** and **Component Output 1**, as well as tables for **Component Output 2**, **Component Input 2** and **Component ADCHD**.

### Audio

This page displays audio settings. It contains the **Audio Demux Table**, the **Audio AES In Table** and the **AES Out** parameters. In addition, page buttons allow you to configure parameters for **Audio Mux**, **Audio Mixer**, **Audio Delay**, **Audio ADC** and **Audio Output**.

### DAC

This page displays audio settings. It contains two tables related to the **Audio DAC**.

### Equalizer

This page displays audio settings. It contains two tables related to the **Audio Equalizer**.

### IntelliGain

This page displays audio settings. It allows the configuration of the **IntelliGain** parameters.

### Mix

This page displays **Audio Downmix** and **Audio Upmix** settings.

### Conversion

This page displays the **Routing**, **Timing** and **IO 1** tables. It has 10 page buttons that correspond to the **Conversion IO 2 and IO 3**, **Caption**, **Noise Reduction**, **Deinterlacer**, **Scaler**, **Do Not Display**, **Audio Monitor**, **Video Monitor** and **Proc** Conversion tables.

### Dolby

On this page, you can view the following tables: **Dolby Meta Data IO**, **Dolby Meta Data Authoring**, **Dolby Meta Data Adjust** and **Dolby Meta Data Encoder**. For each table, a parameter is available that can enable/disable the polling of the tables.

### Encoder 1-2

On this page, you can configure the **Encoder 1** and **Encoder 2** tables. Two parameters are available that can be used to enable/disable the polling of these tables.

### Encoder 3-4

On this page, you can configure the **Encoder 3** and **Encoder 4** tables. Two parameters are available that can be used to enable/disable the polling of these tables.

### Flex

On this page, you can configure the **Flex HNO**, **HNI** and **ADCHD** tables. There are 2 page buttons, **Left** and **Right**, which provide access to the related Flex settings.

### Device Web Page

This page displays the webpage of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
