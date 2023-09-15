---
uid: Connector_help_Snell_Wilcox_Alchemist_Ph.C_-_HD3G
---

# Snell Wilcox Alchemist Ph.C - HD3G

This connector can be used to monitor and configure the Snell Wilcox Alchemist Ph.C - HD3G device.

This device converts high-definition video signals with a PH.C motion measurement technology.

## About

This connector uses the SNMP protocol to request data from the device.

### Version Info

| **Range** | **Description**                                                                                                                                   | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                                                                                                   | No                  | Yes                     |
| 1.0.1.x          | Review of 1.0.0.x connector range. Note: It may be necessary to **update Visio drawings and Automation scripts** to match the changes in this range. | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.1.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when reading values from the device. The default value is *private.*

## Usage

### General Page

This page displays general parameters related to the device, as well as the **System Object Reference Table.**

### System Page

This page displays parameters related to the system.

Page buttons provide access to the following subpages:

- **System SNMP**: Allows you to set parameters related to sending traps.
- **System Log Items**: Allows you to configure parameters related to the device logging.
- **System Setup**: Allows you to configure parameters in order to initialize a particular setup on the device.
- **System Gain**: Displays information on the system gain levels, such as **Gain Black Level**, **Luma Gain** and **Chroma Gain**.

### Display Page

The parameters on this page are divided in three sections, **Output A**, **Output B** and **Memory**. Each section allows you to configure the **Size**, **ASP**, **Pan** and **Tilt**.

The page has page buttons to the following subpages:

- **Display Input**: Allows you to configure the **Input Aspect**.
- **Display Transition**: Allows you to configure the **Transition Slew**.
- **Display Control**: Allows you to configure the displays.

### Input Page

This page displays a number of parameters for **Blanking** (**Left**, **Right**, **Top** and **Bottom**) and other input parameters.

The **Input Standard** page button displays a subpage where you can configure the **Input Filmtools Standard**. You can enable auto assignment or configure a custom setting for particular frequencies.

### Output Page

On this page, you can configure the name for output A and B and set the corresponding output 1080P configuration.

The page contains page buttons to the following subpages:

- **Output Standard Page**: Allows you to configure the **Input Filmtools Standard**. You can enable auto assignment or configure a custom setting for particular frequencies.
- **Output A** and **Output** **B**: These pages contain settings such as **Blanking**, **Colorimetry**, **Border**, **VANC**, **Close Caption**, etc.

### Audio Control Page

This page contains a large number of page buttons as well as basic settings for headphones, such as **Headphone Level**, **Headphone Source** and **Global Audio Delay**.

The following subpages are available:

- **Audio Control Emb x 1-8**: These pages allow you to control channel one and channel two for the Audio Output A of the device. Below each of the channel sections, a **Delay Preset** and **Preset** button are available, which can be used to set the channel with preset values.
- **Audio Control Output B Emb 1-8**: These pages allow you to control channel one and channel two for the Audio Output B of the device. Below each of the channel sections, a **Delay Preset** and **Preset** button are available, which can be used to set the channel with preset values.
- **Audio Control AES Output 1-8**: These pages allow you to control channel one and channel two for the Audio AES Output of the device. Below each of the channel sections, a **Delay Preset** and **Preset** button are available, which can be used to set the channel with preset values.

### Audio Output Page

This page contains three sections with buttons and page buttons. The page buttons open the following subpages:

- **Audio Output Emb A AES Out**: Displays the **AES Follows Emba** and **Embb Follows Emba** toggle buttons, which can be used to enable/disable the corresponding functionality.
- **Audio Output Emb A Audio Pair 1-8**: These pages are used to select an input for output A. With the **Audio Pair : Output A Emb Ch 1**and **Audio Pair : Output A Emb Ch 2** parameters, the correct audio pair can be selected. The **Emb Input Pair Data Mode** toggle buttons can be used to enable/disable the corresponding functionality.
- **Audio Output Emb B Audio Pair 1-8**: These pages are used to select an input for output B. With the **Audio Pair : Output B Emb Ch 1**and **Audio Pair : Output B Emb Ch 2** parameters, the correct audio pair can be selected. The **AES Input Pair Data Mode** toggle buttons can be used to enable/disable the corresponding functionality.
- **Audio Output AES Audio Pair 1-8**: These pages are used to select an input for the output AES. With the **Audio Pair : Output AES Ch 1** and **Audio Pair : Output AES Ch 2** parameters, the correct audio pair can be selected.

### Audio Source Select Page

This page contains two sections with page buttons for encoder 1 and encoder 2, respectively:

- **Encoder 1 Output 1-8**: On these pages, you can configure the following parameters for encoder 1: **Encoder Source Selection**, **Encoder Source Selection AES**, **Encoder Source Selection Emb**, **Encoder Source Selection Dlb Dec 1**, **Encoder Source Selection Dlb Dec 2** and **Encoder Source Selection Channel**.
- Encoder 2 Output 1-8: On these pages, you can configure the following parameters for encoder 2: **Encoder Source Selection**, **Encoder Source Selection AES**, **Encoder Source Selection Emb**, **Encoder Source Selection Dlb Dec 1**, **Encoder Source Selection Dlb Dec 2** and **Encoder Source Selection Channel**.

### Dolby Encoder Page

This page allows you to configure parameters related to the two Dolby encoders. For each of the encoders, page buttons are available to the following subpages:

- **Dolby Encoder Channels**: These pages display parameters related to channel sources. There are eight channels available.
- **Dolby Encoder Presets**: These pages contain a **Preset** and a **Delay Preset** button for each of the eight channels.
- **Dolby Encoder Gain**: For each channel, these pages contain the **Dolby Encoder Channel Audio Gain** and **Dolby Encoder Channel Gain Track** settings.
- **Dolby Encoder Map**: These pages contain six buttons to set a specific mapping to the respective encoder.
- **Dolby Encoder Metadata**: These pages display parameters related to the metadata for each encoder. At the bottom of the pages, the **Internal Preset**, **Load Snapshot**, **Store Snapshot** and **Decoded Snapshot** buttons are available.
- **Dolby Encoder Delay**: These pages contain a **Delay** and **Delay Track** button for each of the eight channels.

### Dolby Decoder Page

This page allows you to configure parameters related to the two Dolby decoders.

Two page buttons at the bottom of the page open the **Dolby Decoder Metadata** pages, which display parameters related to the metadata for each decoder.

### Filmtools Page

This page contains parameters related to the input and the output of the filmtools. There are two offset buttons, **Increase Offset** and **Decrease Offset**.

Two page buttons at the bottom of the page open the following subpages:

- **Filmtools Control**: Allows you to configure several settings related to the filmtools.
- **Filmtools Detection**: Allows you to configure parameters related to the detection of the filmtools.

### VANC Page

On this page, you can enable or disable the display status of a range of VANCs (1 to 8 or 9 to 16).

Sixteen page buttons open subpages where you can configure parameters for each of the 16 VANCs. On these pages, you can among others enable/disable the **Follow Input** setting. At the bottom of the pages, you can set the **DID** and **SDID** for the relevant VANC.

### Utils Page

This page contains a separate section for channel 1 and for channel 2. In each of the sections, you can enable/disable **Channel Mono** and open subpages related to that specific channel:

- **Utils Chan x Legalizer**: Allows you to configure parameters related to the legalization of the channel.
- **Utils Chan x Input Loss**: Allows you to configure parameters related to the input loss of the channel.
- **Utils Chan x Pattern**: Allows you to configure parameters related to the pattern selection for the channel.

### Enhancements Page

This page allows you to configure settings related to the **Enhancer** and the **Alias Suppression.**

### Convert Page

This page allows you to configure conversion-related parameters. with a toggle button, you can set the filmtools on or off. Page buttons provide access to the following pages:

- **Active Area Control**
- **Active Area 1-5**: These pages allow you to configure settings related to the active area, including the **Left**, **Right**, **Top** and **Bottom** of the area.

### Memory Page

This page allows you to configure parameters related to the memory and snapshots of the device.

### Noise Reduction Page

This page allows you to configure parameters that affect the noise reduction.

### Timecode Page

This page contains information on the timecodes and allows you to enable or disable the timecode overlay on the **Input**, on **Output A** and on **Output B.**

The **Input**, **Output** and **Conversion** page buttons provide access to subpages with parameters related to the conversion of the timecode. The **Timecode Conversion** subpage also contains buttons that allow you to perform quick actions related to the conversion.

### Headphones Page

This page allows you to configure settings related to the headphones for inputs and outputs of the device.

### Closed Captions Page

This page displays parameters related to the closed captions of the device.

### Reference Page

This page allows you to configure horizontal and vertical references.

## DataMiner Connectivity Framework

The 1.0.1.x connector range of the **Snell Wilcox Alchemist Ph.C - HD3G** protocol supports the usage of DCF and can only be used on a DMA with **8.5.14** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- **SDI A Input**: Physical SDI interface with type **in**.
- **SDI B Input**: Physical SDI interface with type **in.**
- **A Output**: Physical SDI interface with type **out**.
- **B Output**: Physical SDI interface with type **out.**

### Connections

#### Internal Connections

- Depending on the **Source** parameter of the **Input** Page (**SDI A** or **SDI B**), the selected input will have always a connection to the **A Output**.
- Depending on the **Output B Lock to A** parameter of the **Display** page, the selected input (**SDI** **A** or **SDI** **B**) will have a connection to the **B Output**.

## Notes

When upgrading from connector version 1.0.0.5 to 1.0.1.1, check if all Visio drawings and Automation scripts still function correctly, as the changes to the connector may cause errors to appear. Some descriptions and values have been changed (from a numeric value to a string value).
