---
uid: Connector_help_Snell_Wilcox_IQDAVM
---

# Snell Wilcox IQDAVM

The IQDAVM accepts a serial 4:2:2 input to provide a maximum of four equalized and re-clocked outputs, three monitoring composite outputs and four embedded audio analog outputs. On-screen audio \`confi dence' of four embedded audio channels are provided on the -M version.

## About

The IQDAVM card can be inserted in a Snell & Wilcox IQ-Modular framework. Fitting up to 16 modules (3RU) with full redundancy in a hot swappable flexible architecture. This framework also allows to monitor all its cards by SNMP or the vendor specific RollCall protocol. Which is used by this connector for all communications. To do this the cards address will have to be provided when creating a new element.

Device features include:

- Up to four re-clocked serial 4:2:2 outputs
- Three monitoring composite PAL/NTSC/PAL-N outputs
- Four analog audio outputs or 2 stereo pairs
- Balanced audio output level adjustable +12 dBu to +24 dBu for 0 dB FS input (-D version)
- Unbalanced audio output level adjustable 1 Volt pk-pk to 4.5 Volts pk-pk into \>50 k ohm, for 0 dB FS input (-B version)
- Audio selection from any embedded channel pair
- 20-bit digital-to-analog audio conversion, -95 dB THD+N typical (Full Scale)
- Audio polarity invert
- Embedded audio presence indication
- On screen display of audio level and status (-M versions only)
- Non-audio ancillary data presence indication
- EDH error detection and reporting
- Test signal generator (Color Bars/Black and - 20 dBFS Tone/Silence)
- Automatic 525/625 line detection and no valid signal indication
- Card edge and RollCall remote control

Ranges

- 1.0.0.X
- 2.0.0.X (Event based updates)

The ranges are not compatible with each other.

Note: when monitoring this card using range 2.0.0.X you will find a extra record "DataMiner" in the RollCall application of the vendor. (One such record will appear for each element monitoring a card.)

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- IP address/host: The polling IP of the device. (This is the IQ-Modular framework.)
- IP port: The IP port of the device. The default value is *2050*.
- Bus address: Indicates the slot and port on which the IQAVDR card can be found.
  The format of the bus address is UU.PP, where UU should be replaced by the unit address and PP should be replaced by the Port.
  Both values should be hex encoded. Example: "15.0A"

Note:
If you have installed the "RollCall Control Panel" software (, by Snell & Wilcox) and have the interface of the card open, then the full address should be visible under the tab "Connected Units". This could look like "0000:11:01". You need the "11:01" but should replace the semicolumn with a dot '.' to "11.01". (Note also that the network address should always be "0000" because the connector does not support communication over bridges.

### Configuration

The connector needs no configuration except for the card address, which needs to be configured in the **bus address** field in the element wizard.
If the value cannot be parsed as a valid slot number the connector will automatically and immideatly stop after startup. This to make sure that no commands (and espetially sets) are send to a random device.

The log file will contain a message indicating that the connector failed to parse the bus address and the expected format of the address.

## Usage

### General

In the first column are a set of parameters showing a quick view of the units status. These parameters can also be found on other pages where there will also be a setter available. (This setter is removed on the General page so all parameters are shown in a compact way, reducing the need to scroll down to see these parameters. )

On the second column there is a **Display** screen mimicing the content of the LCD screen on the device. There is also **Software Version**, **Serial No** and **Build No** info available. And two buttons to **Restart** or **Preset** the Unit. These buttons will ask for confirmation when clicked.

Finaly there is also one Read\Write parameter **Headroom** where the gain can be configured.

Outputs

On this page you can find for both analogue outputs (A and B) the settings for **Gain**, **Polarity**, **Extract**, and **Default Audio.**

### Setup

This page contains most of the configuration parameters.
Including:

- **Pattern**
- **0db FS Level**
- **Standard**
- **VBI Pass**
- **Pedestal On**
- **Chroma Bandwidth**
- **Tone Frequency**
- **Default Video**
- **Stats** (**Show** & **Reset Stats** Button)
- **Input Loss** indicator
- **Embedded Audio**
- **EDH Presence**
- **EDH Error sec**

### RollTrack And Logging

This page contains on the first column the RollTrack parameters and in the right column a parameter **Setup: Logging: Standard** which can *enable* or *disable* the logging.

### Connection Info

On this page some extra parameters can be found about the connection. Most will have no importance to the operators, unless maybe during setup of elements or for finding connection problems.
The two most important parameters are: **Session Status** and **Card User Name**. The session status should shortly after startup be set to *Connected* and never change again. If no session can be established after startup, the status will remain *Not Initialized* and if a connection had been established, but was broken by the device, the value should change to *Disconnected*.

Note:
The **Session Status** refers to the logical connection instead of the physical connection. This means that it is possible that the device will go in timeout (physical connection lost), while the **Session Status** (logical) remains *Connected*. This situation would indicate that no response was received on messages send to the device. Though usually the logical session will also get disconnected when the physical connection is interrupted. In that case the connector will detect this when the device becomes accessible again (= physical connection restored and device out of timeout state) and shortly set the **Session Status** to *Disconnected,* until a new session is established*.* (Which should take less than 15 seconds.)

A other important parameter is the **Force Poll** button.
As can be expected all parameters will be refreshed after clicking this button.
Note: that this is the only real "polling" mechanism in the connector. All other parameter updates are event driven.
(The same happens else only after a new session is established. This can be either after element startup, or when the session was disconnected by the device.)

The last important parameter is the **Card User Name**.
This parameter contains the name which is also displayed in the software from Snell & Wilcox to identify the cards.

The other parameters **Unit Address** & **Unit Port** contain respectively the unit and port parsed from the elements bus address.
The parameters **Local Session Nr** and **Assigned Session Nr** can be used to identify the traffic between the element and the card during network analysis. Any non-zero **Assigned Session Nr** indicates that the **Session Status** is *Connected*. The Local Session Nr is always the combination of the unit address and port of the monitored card.

## Notes

As mentioned in the "Configuration" section, the element will automatically stop if the bus address could not be parsed.
This should prevent sets to a random element (or broadcasted to all elements.)

If the element was stopped for this reason, the log file will contain a message to indicate this.

It is possible to monitor the same card using the vendor supplied RollCall application. In their software you will see an extra node "DataMiner" for each element that is monitoring a card.
