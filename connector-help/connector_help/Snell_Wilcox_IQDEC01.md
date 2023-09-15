---
uid: Connector_help_Snell_Wilcox_IQDEC01
---

# Snell Wilcox IQDEC01

The IQDEC01 provides a complete analog front-end with 12-bit composite decoding, synchronization and analog audio ingest in one compact module. Advanced adaptive 2-D decoding technology makes the IQDEC01 usefull for most analog to digital or, when paired with an upconverter, analog to HD applications. The IQDEC01 handles most composite analog signal formats including PAL, NTSC and SECAM. The full frame synchronizer with horizontal and vertical phasing controls allows the output to be timed to your house or studio reference. The IQDEC01 can digitize up to 4 channels of analog audio for both embedding into the SDI stream and outputting as two AES streams. Proc. amp controls and a built-in noise reducer complete the speci? cation.

## About

The IQDEC01 card can be inserted in a Snell & Wilcox IQ-Modular framework. Fitting up to 16 modules (3RU) with full redundancy in a hot swappable flexible architecture. This framework also allows to monitor all its cards by SNMP or the vendor specific RollCall protocol. Which is used by this connector for all communications. To do this the cards address will have to be provided when creating a new element.

Device features include:

- 12-bit multi-standard decoder with frame synchronizer and analog audio embedder
- Adaptive line comb decoding
- Input standards - PAL\*, NTSC\*, NTSC-J, N4.43, PAL60, PALN\*, PALM\* or SECAM\*
- \*Auto detection of input standards
- Minimal delay through the unit - \<7 lines (lock to input, decoder and noise reducer in minimum delay mode)
- Motion adaptive recursive noise reducer with automatic noise ?oor measurement
- Horizontal and vertical enhancer
- VHS mode: Rugged sync and clock recovery ensures reliable operation for VHS playback and other noisy or unstable inputs
- Y/C and composite inputs available
- SECAM adaptive notch and chroma median ?lters
- Selectable default output on loss of input - Frame freeze, pattern or input pass
- Selectable VBI pass through (pass ? at or blank for each VITS line)
- Adjustment of video gain, black level, chroma gain, NTSC hue, horizontal Y/C timing and picture position
- 4 x assignable 8 channel audio mixers
- Flexible audio delay features including tracking delay to keep audio and video in perfect sync
- Full audio proc. amp including - gain, mute, polarity invert, and channel routing

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

In the left column of the general page are some key parameters for Video, Audio and device Setup + page buttons to more detailed settings. Examples are: **Select**ed video input, **Calibrate Adio** button, **Default Output**, **Pattern Type**, ... .

On the right side there are some general information fields, including **Software Version** & **Serial Number**, but also the content on the front screen of the device and buttons to **Restart** and restore **Factory Defaults**.

### Setup

On this page are the parameters related to the Pattern, Caption and HANC.
There are also page buttons to parameters related to the RollTrack protocol, Log settings and GPIO settings.

### Video

On this page it is possible to select the active video input, disable or enable several protocols (PAL, NTSC, ...) set the number of lines for the SDI signal and configure the Pro Camp settings.

### Audio

On this page it is possible to configure the Reducer, Tone, Calibration, Monitoring & Setup parameters.
There are also **Channel Status** parameters and page buttons to more detailed information about internal Busses (A & B), Output, Delay, Mixers and Pairs.

### Audio Mixer 1 .. 4

On these pages are the different Gains (1 to 8) for the specified mixer + page buttons to pages where these gains and sources can be configured.

### Decoder

Contains parameters to configure the decoder, such as **Color Killer, Minimum Delay, Notch & Luma Bandwidth.**

### GenLock

Contains parameters to configure the locking settings, such as **Freerun Frequency, Frame Delay** & **Reference Source.**

### Memory

On this page it is possible to **Recal**, **Save** & **Clear** the 8 available memory slots in the device.

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
