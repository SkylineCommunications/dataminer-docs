---
uid: Connector_help_Snell_Wilcox_IQMUX33
---

# Snell Wilcox IQMUX33

The **Snell Wilcox IQMUX33** is a 3G/HD/SD-SDI multiplexer and frame synchronizer with AES/EBU and analog audio inputs.

## About

This protocol is used to control and monitor the **Snell Willcox IQMUX33** via **SNMP**.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Slot number of the module in the chassis, e.g. *4.*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### Video-In

On this page, you can specify the input standards that the unit will accept as valid.

The page also displays information about the current input and CRC/EDH and ANC errors.

### Video-Out

On this page, you can apply various settings and adjustments to the video output signal.

### Video-VBI

On this page, you can select the blanking standards passed through the module.

### Aud-In-AES

On this page, you can adjust the gain and polarity of the eight AES audio pairs, and configure the AES pairs as either inputs or outputs.

### Aud-In-Analog

On this page, you can adjust the gain and polarity of the two analog input pairs.

### Aud-In-Disembed

On this page, you can adjust the gain and polarity of the eight disembedded audio pairs.

### Aud-Out-Embed

On this page, you can:

- Apply gain adjustments to each channel of the eight embedded output pairs.
- Apply a mute to each channel of the eight embedded output pairs.
- Designate each embedded output pair as a stereo pair.
- Specify which of the four embedded output groups are enabled.

### Aud-Mixer

On this page, you can combine up to six input sources into a single output.

### Aud-Routing-In

On this page, you can set the input for the different buses.

### Aud-Routing-Out

On this page, you can route the available output sources.

### Aud-Setup

On this page, you can:

- Configure the PCM output monitoring levels.
- Specify the eight test tones.

### Aud-Delay

On this page, you can adjust the audio delay settings of the eight audio buses.

### Delay-Genlock

On this page, you can select the genlocking and delay functions.

### Dolby E Auto Line

On this page, you can specify a video line for Dolby E header alignment.

### Loud Monitoring

This page provides two independent monitoring blocks that enable you to monitor mono, stereo, or up to five PCM channels.

### System-Memories

On this page, you can save up to 16 memory setups and recall them when necessary.

### System-RollTracks

This page allows information to be sent through the RollCall Network to compatible units on the same network.

You can use the RollTrack settings to:

- Enable or disable the RollTrack functions.
- Configure up to 32 RollTrack outputs.
- Specify the conditions that trigger RollTrack data transmission.
- Set RollTrack destinations.
- Specify the RollTrack commands to be sent.

### System-Setup

This page displays general information (e.g. **Slot Number**, **Serial Number**, .).

On this page, you can also **Restart** the unit or to reset it to the **Default Settings**.

### Logging-...

Logging enables you to make information about several parameters available to a logging device connected to the RollCall network.

Each logging page has two columns:

- Log Enable: Use the toggle buttons to select the parameters for which log information should be collected on the left side of the page.
- Log Value: Shows the current log value on the right side of the page.

### Webpage

This page can be used to access the **web interface** of the device. Note that the interface must be accessible from the **client PC**.
