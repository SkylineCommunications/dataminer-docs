---
uid: Connector_help_Snell_Wilcox_KudosPro_MC500
---

# Snell Wilcox KudosPro MC500

The **Snell Wilcox KudosPro MC500** is a Single-channel entry level motion compensated standards converter for a range of applications including: International program distribution; Content re purposing for Internet and TV distribution; International TV and video production.

## About

This connector is intended to gather information from the device making it available through several pages. A serial connection is used for that purpose.

Important: Each device provides a *Menu Set*. It contains the commands ids used to get the value from each parameter. Each device provides a different *Menu Set*. For each device the commands that are sent need to be adapted.

More information related to the device can be found here: [http://handbooks.snellgroup.com/manuals/conversion_restoration/KudosPro_MC500_Operator's_Manual.pdf](http://handbooks.snellgroup.com/manuals/conversion_restoration/KudosPro_MC500_Operator%27s_Manual.pdf)

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION**:

- **Type of Port**: IP
- **IP address/host**: The polling IP of the device
- **IP port**: 2050

## Usage

### MC500

This page shows all parameters related to the RollCall device. General information about the main board is shown here and for each funcionality there's a page button.

They are:

- **Genlock** - The Genlock page provides controls that lock the output video clock to the genlock source (input or reference) regardless of the video standard.
- **Dolby** - The Dolby page enables you to set up the how the unit handles Dolby audio. The MC500 unit supports Dolby D and E decoding as well as Dolby E transcoding when frame rate converting. Dolby E encoding from a PCM input is not supported.
- **Network** - The Network menu provides access to the unit's network details and setup.
- **Front Panel** - The Front Panel page enables you to customize some front panel features for ease of use.
- **Memories** - The Memories menu enables you to save up to eight system-level memory setups and recall them when required.
- **Logging** - Logging defines what parameter information is made available to a logging device attached to the RollCall network.
- **Status** - The Status menu shows the status of the unit's hardware and software.

### Channel 1

This device has attached a board that relates to the **Channel 1**. This page follows the same layout as the **MC500** page. General information is shown on the page itself and for each funcionality a page button is provided:

- **Input** - The Input menu enables you to specify a video input source.

- **Output** - The Output menu enables you to apply various settings and adjustments to the video output signal.

- **Video** - The Video menu enables you to apply various types of signal processing to the signal being converted, and includes Proc Amp and Enhance controls.

- **Convert** - The Convert menu enables control of motion processing to improve the conversion performance of stationary content.

- **ARC** - The Aspect Ratio Control (ARC) menu enables you to determine the aspect ratio of a picture from a range of options, or to adjust the size and position of the picture manually.

- **Timecode** - The Timecode menu enables you to set up and control the unit's timecode options for VITC (Vertical Interval Timecode), LTC (Linear Timecode), and ATC (Ancillary Timecode).

- **Metadata** - The Metadata menu enables you to control a set of closed captions and teletext subtitle information.

- **Audio** - The Audio menu enables you to control the routing of the unit's audio options.

- **Routing** - The Routing control enables you to route the incoming audio to an embedded audio output.
  - **Control** - The Control menu enables you to adjust the gain of the audio channels
  - **Shuffle** - The Shuffle menu contains the output information from the audio processors, as defined on the Routing screen.

- **Ch1 Memories** - The Memory menu enables you to save up to eight memory setups and recall them when required.

- **Ch1 RollCall** - The RollCall menu enables you to name the unit for use remotely with the RollCall Control Panel.

- **Ch1 Logging** - Logging defines what parameter information is made available to a logging device attached to the RollCall network.

### Web Interface

The client machine has to be able to access the device. If not, it won't be possible to open the webinterface.
