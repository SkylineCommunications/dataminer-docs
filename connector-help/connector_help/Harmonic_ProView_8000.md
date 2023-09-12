---
uid: Connector_help_Harmonic_ProView_8000
---

# Harmonic ProView 8000

The Harmonic ProView 8000 is an integrated receiver-decoder (IRD). This connector can be used to manage this device using the HTTP protocol.

## About

### Version Info

| **Range** | **Description**                           |
|-----------|-------------------------------------------|
| 1.0.0.x   | Initial version                           |
| 1.1.0.x   | Version supporting FW version 1.3.0.0.25. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.0.0.0.35             |
| 1.1.0.x   | 1.3.0.0.25             |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

### Inputs Page

The Inputs page gives an overview of the physical inputs of the Harmonic ProView 8000 device. The Harmonic ProView 8000 supports three input types: DVB-S/S2, GbE and ASI. For each input type, a table is included containing monitored parameters (e.g. the DVB-S/S2 Input Table contains parameters such as Symbol Rate, Attenuation, C/N, Eb/N0, BER, PER, Carrier Frequency, etc.).

#### Inputs \> LNB

The LNB page button allows you to switch between the DVB-S/S2 ports. LNB can only be enabled for one RF input. The default is RF-1.

#### Inputs \> DVB-S/S2 Properties

The Properties page button below the DVB-S/S2 Inputs Table allows you to configure a DVB-S/S2 port. In order to set a parameter for a given DVB-S/S2 port, first select the port using the **DVB-S/S2 Port** parameter.

The following properties can be set for a DVB-S/S2 port:

- **Modulation Standard**: Allows you to select the L-band modulation standard. Available options are *Automatic*, *DVB-S* and *DVB-S2*.

- **Symbol Rate**: Sets the L-band symbol rate. Range: 01. - 45. Msym/s.

- **Spectral Inversion**: Allows you to select the mode of operation for the spectral inversion function.

- **Modulation & FEC**: Allows you to select the modulation type and coding rate, according to the selected modulation standard.
  For DVB-S, one of the following must be selected: *QPSK 1/2*, *QPSK 2/3*, *QPSK 3/4*, *QPSK 5/6* or *QPSK 7/8*.
  When DVB-S2 is used, one of the following must be selected: *QPSK 1/2, QPSK 2/3, QPSK 3/4, QPSK 5/6, QPSK 3/5, QPSK 4/5, QPSK 8/9, QPSK 9/10, 8PSK 3/5, QPSK 2/3, 8PSK 3/4, 8PSK 5/6, 8PSK 8/9* or *8PSK 9/10*.

- **Pilots**: The Pilot feature should only be activated when the signal has Pilot symbols, otherwise the demodulator will not lock onto the signal. DVB-S2 only.

- **Physical Layer Scrambling Seed**: Sets the value for the physical layer scrambling seed. DVB-S2 only. Range: 0 - 262141. Default: 0 (no scrambling).

- **Roll-off**: DVB-S2 only. Allows you to select the roll factor.

- **ISI**: Input Stream Identifier

- **Frequency Drift Compensation**: On/Off

- **Drop Erroneous Packets**: Use this parameter to instruct the demodulator not to pass any transport stream packets with errors. The default is to pass all TS packets.

- **Mute Upon Reception Errors**: On/Off

- **In L-Band**: Sets the L-band frequency. Range: 0.950 - 2.150 GHz. Default: 1.0 GHz.

- **Carrier Frequency**: Sets the receiving frequency according to the satellite LNB transmitting frequency.

- **LNB Polarization**: Allows you to select the polarization of the antenna in the satellite LNB.

- **LNB Type**: Allows you to select the receiver frequency band according to the satellite Low Noise Block (LNB) transmitting frequency band.

- **Local Oscillator Frequency**: This parameter depends on the **LNB Type parameter** (and the **22 kHz Tone parameter**):

- When the LNB Type is *Ku*, the configurable value ranges from 8.500 to 13.000. The resolution is GHz. The step is 125 kHz. Default: 9.750.

  - When the LNB Type is *C*, the configurable value ranges from 5.000 to 6.000. The resolution is GHz. The step is 125 kHz. Default: 5.150.

  - When the LNB Type is *Universal*

  - - and 22 kHz Tone is *Low Band (Off)*, the value is 9.750
    - and 22 kHz Tone is *High Band (On)*, the value is 10.600

  - When the LNB Type is *Universal Wide*

  - - and 22 kHz Tone is *Low Band (Off)*, the value is 9.750
    - and 22 kHz Tone is *High Band (On)*, the value is 10.750

- **22 kHz Tone**: The receiver controls the LNB band by sending a 22 kHz signal. When the signal is sent, the LNB uses its High Band Local Oscillator (L.O.). When the signal is not sent, the LNB uses its Low Band L.O. Range: 10.700 - 11.900 GHz. Possible values: *High Band - (On)* and *Low Band - (Off)* (default value).

- **Attenuation Level:** Internal attenuation for saturated signals. Range: 00.0 - 30.0 dB. Step: 0.5 dB. Default: 2 dB.

- **18 dBm Gain**: Internal gain to improve signal strength. The possible values are *On* (default) and *Off*.

- **Alarms Thresholds BER**: Bit Error Rate. Range: 0.1 - 0.00000001. Default: 0.0001.

- **Alarms Thresholds PER**: Packet Error Rate. Range: 0.1 - 0.00001. Default: 0.01.

In order to apply the changes, click the **Apply** button. This will write the parameters displayed on this subpage to the device.

Note:

- Once you start to change parameter settings, the polling of platform parameters will be postponed until you have clicked **Apply**. Then the parameters will be written to the device and information will be polled again.
- In case you have started to modify parameters and **5 minutes** go by without any further parameter configuration changes, the connector will start to the platform data again. Consequently, any **parameter configuration changes will be lost**.
- Applying changes can take some time, so it is possible that changes will only be visible after some time.

#### Inputs \> GbE Port Properties

The Properties page button below the GbE Input Ports Table allows you to configure a GbE port. To set a parameter for a given GbE port, first select the port using the **GbE Input** **Port** parameter.

The following properties can be set for a GbE port:

- **GbE Port Enable**: You can enable either or both GbE ports. This parameter only works when the redundancy mode is manual. If both ports are enabled, then only one port is active while the other one is in standby mode. By default port 1 is active and port 2 is on standby. The port on standby does not pass data. When the port is enabled and no link is detected, the device reports a Link Down alarm. Disable the port to mask this alarm. (Default is *Disabled*.)

- **GbE Port IP Address**: Each port must have a different IP address. Default: *127.127.X.X*, where X is the port number +1.

- **GbE Port Subnet Mask**: The IP mask. Default: *255.255.255.0*.

- **GbE Port MAC Address**: Each port has its own MAC Address. They are factory set and cannot be changed.

- **Input Redundancy** **Mode**: Display only.

- **Output Redundancy Mode**: Display only.

- **Redundancy Scheme**: The following options are available:

- *Manual*: You can manually switch between the primary port and the backup port regardless of their link status.
  - *Manual Revert*: The device switches from the primary port to the backup port when the primary port fails on the redundancy trigger and the backup port has no active alarms. You can revert from the backup port to the primary port manually.
  - *Automatic*: The device switches to the standby port whenever the active port fails on one of the redundancy triggers and the standby port has no active alarms.
  - *Automatic Revert*: The device switches from the primary port to the backup port when the primary port fails on one of the redundancy triggers and the backup port has no active alarms. The device reverts to the primary as soon as the primary port has no active alarms.

- **Active Port**: Options when Redundancy Scheme is *Manual* only: *Primary (GbE-1)* or *Backup (GbE-2)*.

- **Override Source IP:** Can be enabled or disabled.

- **Virtual IP Address**: You can define a virtual IP address on the GbE port for redundancy purposes. The virtual IP address overrides the source IP address on the IP header.

- **Autonegotiation**: Auto-negotiation allows devices to perform automatic configuration for best modes of operation over links and provide automatic speed matching for multi-speed devices.

- **GbE Port Speed**: You can configure the PHY speed when auto-negotiation is disabled. Default: *1000*.

- **Duplex Mode**: Display only.

In order to apply the changes, click the **Apply** button. This will write the parameters displayed on this page to the device.

Note: Changes to the GbE port properties are reflected in the Physical Inputs and Physical Output panels.

### Logical Inputs Page

The **Logical Inputs** page shows the input stream. The stream on the Logical Inputs page can be passed to the logical outputs, or selected programs can be added to the logical output stream. The device has only one input TS, with a supported rate of up to 200 Mbps. Only a CBR TS is supported.

The page contains three tables:

- **Logical Inputs Table**: This table will only contain one entry, as the Harmonic ProView 8000 device only supports one logical input. The table displays the **Total Bitrate**, the number of **TS Errors** and **TS CC Errors** of the transport stream.
- **Services Table**: This table gives an overview of the services (or programs) included in the logical input transport stream. In addition to the **Program Number**, the table also displays the **Program Name**, the **PMT PID**, the Service **PCR PID** and the **Service Bitrate** for each service.
- **PIDs Table**: This table gives an overview of the elementary streams (ES) included in the transport stream. Each row represents an elementary stream and indicates the PID value (**PID ID)**, the program(s) that reference this ES (**Ref by Service**), the type of ES (**Type**) (note that the type can only be determined if the ES is referenced by a service or the PID is a PSI/SI-specific PID), the bitrate (**Bitrate**) and the **CC Errors**.

#### Logical Inputs \> Properties

The Properties page button below the Logical Inputs Table allows you to configure the following parameters of the logical input transport stream:

- **Enable**: Allows you to enable or disable the transport stream.
- **TS ID**: The incoming transport stream ID from the PAT table.
- **TS** **Description**: You can provide a description for the transport stream of up to 39 characters long.
- **Bitrate**: The incoming transport stream bitrate in Mbps. Display only.
- **Transport Errors**: The transport error count. Display only.
- **CC Errors**: The CC error count. Display only.
- **Primary Source Port**: The primary source port.
- **MPEG Sync Loss Alarm Event Duration**: Raises an alarm if MPEG Sync Loss lasts for the specified duration.
- **CC Errors Alarm Number of Errors** and **CC Errors Alarm Within**: Raises an alarm if the specified number of errors appeared within the specified time interval.
- **PID Missing Alarm PID** and **PID Missing Alarm Missing for**: Raises an alarm if the specified PID has been missing for the specified duration.
- **T2-MI Processing Mode**.

In order to apply the changes, click the **Apply** button. This will write the parameters displayed on this page to the device.

#### Logical Inputs: Other Subpages

The Logical Inputs page also contains page buttons to display information related to the following Program Specific Information (PSI) tables:

- **PAT**: On this page, information related to the Program Association Table (PAT) is displayed. It shows the version of the table (**PAT Version**) and its number of sections (**PAT Number of Sections**). The **Logical Inputs PAT Table** gives an overview of all the programs/services that are available for this input transport stream. For each program/service, the program number is displayed (**Program Number**), as well as the version of the Program Map Table (PMT) for this program (**Version**) and the PID of the corresponding PMT (**PMT PID**).
- **CAT**: On this page, information related to the Conditional Access Table (CAT) is displayed. It shows the version of the table (**CAT Version**) and its number of sections (**CAT Number of Sections**). The **Logical Inputs CAT Table** gives an overview of the **EMM ID**s and the corresponding **CAS ID**.
- **NIT**: On this page, information related to the Network Information Table (NIT) is displayed. It shows the version of the table (**NIT** **Version**), its number of sections (**NIT** **Number of Sections**) and the network ID (**NIT Network ID**).
- **SDT**: On this page, information related to the Service Description Table (SDT) is displayed. It shows the version of the table (**SDT** **Version**), its number of sections (**SDT** **Number of Sections**) and the original network ID (**SD**T** Original Network ID**).

### Decoder Page

The **Decoder** page shows the status of the decoder and allows you to configure it.

This page contains the following parameters:

- **Service Mode**: The following options are available:

- *No Decoding*: Use this mode to disable decoding. When the Service Mode is set to *No Decoding*, the remaining decoder options are not applicable.
  - *Program*: Use this mode to set the decoder to manual program selection.
  - *Fixed PID*: Use this mode to set the decoder to manual PID selection.
  - *Automatic*: Use this mode for the device to automatically decode the first program in the TS (first in PAT).

- **Input** **Program**: You can only configure the input program when Service Mode is *Program*. When Service Mode is *Automatic*, this parameter displays the input program number.

- **Selected Program Name**: The name of the selected program.

- **Selected PCR PID:** The selected PCR PID.

- **Selected DPI PID**: The selected DPI PID.

- **VBI PID**: The VBI PID.

- **Selected Video PID**: The selected video PID.

- **Input Coding Format**: The input video coding format.

- **Input Format**: The input video format.

- **Input Aspect Ratio**: The input video aspect ratio.

- **Chroma Sampling**: The input video chroma sampling.

- **Audio#1/Audio#2 Input PID**: The audio input PID.

- **Audio#1/Audio#2 Input Coding Format**: The audio input coding format.

- **Audio#1/Audio#2 Input Language**: The audio input language.

- **Audio#1/Audio#2 Input Channel Mode**: The audio input channel mode.

- **Audio#1/Audio#2 Input Decoding Type**: The audio input decoding type.

In order to change the service mode (and/or the input program), click the **Apply** button.

Several page buttons are present that allow you to monitor/configure specific parts of the decoder. In order to change a decoder configuration parameter, click the **Apply** button on the corresponding page.

#### Decoder \> Descrambling

This subpage contains decoder setting related to descrambling. The following parameters are present:

- **CA Device**: Allows you to select a CA device for descrambling. Available options are *None*, *CAM-1*, *CAM-2* and *BISS*. Default: *CAM-1*.
- **BISS Key:** Only applicable when CA Device is set to *BISS*.

#### Decoder \> Video

This subpage contains parameters related to the video decoder. The following parameters are present:

- **Video PID Selection Mode:** Allows you to select the PID selection mode. Available options are:

- *None*: No PID selected. (When Service Mode is *Fixed PID*, the PID Selection Mode default is *None*.)
  - *Fixed PID*: Allows you to select a video PID by its number (1-8190).
  - *Automatic*: Selects the video PID with the lowest number in the PMT. PID selection occurs whenever there is any change in the PMT. (When Service mode is *Automatic*, the PID Selection Mode default is *Automatic*.)

- **Video PID:** The video PID value**.**

- **Video Codec**: Determines the video decoding codec (*MPEG-2*, *AVC* or *Automatic* (default)).

- **Display Format**: Determines the display format (*Automatic*, *HD* or *SD*).

- **HD Format**: Only applicable when **Display Format** is set to *HD*.

- **Scaling to 16:9**: Only applicable when **Display Format** is set to *HD*. Can be set to *Center-Cut*, *Pillarbox* (default), *Full Screen* or *AFD*.

- **Aspect Ratio**: Can be set to *4:3*, *16:9* or *Automatic* (default)

- **SD Scaling to 4:3**: Can be set to *Center-cut* (default), *Letterbox*, *Full Screen* or *AFD*.

- **SD Scaling to 16:9**: Can be set to *Center-cut*, *Pillarbox* (default), *Full Screen* or *AFD*.

- **Format for 625 Line Systems**: Can be set to *PAL B/G* (default), *PAL I*, *PAL D*, *PAL N* or *French SECAM*.

- **Format for 525 Line Systems**: Can be set to *NTSC* (default) or *PAL M*.

- **Blanking Mode**: Allows you to select the option to output when there is no video: *Black Frame* (default), *Mute*, *Bar*, *Last Frame* or *Last Field*.

- **Error recovery Mode**: Can be set to *Full* (default), *Partial*, *None* or *High*.

#### Decoder \> PCR

The following parameters are present on this subpage:

- **PCR PID Selection Mode**: Can be *Fixed PID* or *Automatic*. If set to *Automatic*, the PCR PID in the PMT is selected as the PCR for the decoded program.
- **PCR PID**: The PCR PID value.
- **Clock Source**: Can be *Original PCR* or *Decoder Clock* (default).
- **A/V Sync**: Can be *Frame* (default) or *Off*.
- **Video Buffer Delay:** Range: 1 to 300 ms. (Default: *100*.)

#### Decoder \> Audio#1/Audio#2

These subpages contain parameters related to the audio decoders:

- **Audio \#1/#2 PID Selection Mode**: Can be set to *None*, *Fixed PID*, *Preferred Language* or *Automatic*.
- **Audio \#1/#2 PID**: The PID value.
- **Audio \#1/#2 Preferred Language**: Only applicable when Audio \#1/#2 PID Selection Mode is set to *Preferred Language*. A three-letter code as defined in ISO 639 should be used.
- **Audio \#1/#2 Codec:** Can be set to *Automatic* (default), *MPEG-2*, *AC-3*, *E-AC-3*, *AAC ADTS*, *AAC LATM* or *MPEG-1*.
- **Audio \#1/#2 Processing Type**: Can be set to *Passthrough*, *Downmix/2.0 Decode* or *5.1 Decode* (Audio 2 only).
- **Audio \#1/#2 AC3 Downmix Mode**: Can be set to *LoRo* (default) or *LtRt*.
- **Audio \#1/#2 Dynamic Range Control**: Can be set to *Line Out* (default) or *RF Remote*.
- **Audio \#1/#2 Delay**: To overcome audio/video sync problems, you can adjust the audio delay. Only on PVR-8130 model. Range: 128 to 128 ms. Default: 0.
- **Audio \#1/#2 Channel Mode**: Can be set to *Stereo* (default), *Mono*, *Both Left* or *Both Right*.
- **Audio \#1/#2 Digital Channel Status**: Only on PVR-8130 model. Can be set to *Professional* (default) or *Consumer*.
- **Audio \#1/#2 Volume**: Sets the audio volume. Range: -63 to 0 dB. Default: 0.

#### Decoder \> Embedded Audio

Use embedded audio to embed the audio channels into the SDI out ports.

#### Decoder \> DPI

- **DPI Selection Mode:** PID Selection can only be done on the PVR-8130 and the **Service Mode** must be set to *Program* or *Automatic*. Available options: *None*, *Fixed PID* (only when Service Mode is set to *Program*), *Automatic* (default when Service Mode is set to *Automatic* or *No Decoding*).
- **DPI PID**: The DPI PID value.
- **Pre-Roll:** Range: -10 to 10, with steps of 1. Default: 0.
- **Relay for Out of Network**: Can be set to *None* (default), *GPI-1*, *GPI-2* or *GPI-3*.
- **Relay for Return to Network**: Can be set to *None* (default), *GPI-1*, *GPI-2* or *GPI-3*.
- **AS Index**: Range: 0 to 255, with steps of 1. Default: 0.
- **DPI PID Index:** Range: 0 to 65535, with steps of 1. Default: 0.
- **Insert to SD VANC**: Can be set to *Yes* or *No*.
- **Line in SD Outputs**
- **Insert to HD VANC**: Can be set to *Yes* or *No*.
- **Line in HD Outputs**

#### Decoder \> VBI/VANC

- **VBI VANC PID Selection Mode:** Can be set to *Automatic* or *None*. If set to *None*, the decoder can extract information from the incoming stream and re-insert it into the output (VBI or VANC). No decoding occurs.
- **VBI/VANC PID**: The VBI/VANC PID value.

#### Decoder \> OSD

- **Subtitling Type**: Only displayed when Service Mode is *Program* or *Automatic*. Can be set to *None* (default), *DVB Subtitling* or *VBI Teletext*.
- **DVB PID Selection Mode**
- **DVB PID**: The DVB PID value.
- **DVB Preferred Language**
- **VBI Teletext Page Selection Mode**: Only applicable when Subtitling Type is set to *VBI Teletext*.
- **VBI Teletext Page**
- **VBI Teletext Language**
- **SD Output Subs Enable**: Enabled by default.
- **SD Zoom Ratio**: Default: 1. Only available in certain modes.
- **SD X Position Offset**: Range: -100 to 100. Default: 0.
- **SD Y Position Offset**: Range: -100 to 100. Default: 0.
- **HD Output Subs** **Enable**: Enabled by default.
- **HD Zoom Ratio**: Default: 1. Only available in certain modes.
- **HD X Position Offset**: Range: -100 to 100. Default: 0.
- **HD Y Position Offset**: Range: -100 to 100. Default: 0.

### Logical Outputs Page

This page gives an overview of the logical output transport stream. The layout is similar to the Logical Inputs Page.

The page contains three tables:

- **Logical Outputs Table**: This table will only contain one entry as the Harmonic ProView 8000 device only supports one logical output. The table displays the **Total Bitrate** and the number of **TS Errors** and **TS CC Errors** of the transport stream. As the logical output can be either a copy of the logical input (in "Transparent" mode) or a custom selection of programs/PIDs (in "Multiplex" mode) the **TS Type** parameter indicates the type.
- **Output Services Table**: This table gives an overview of the services (or programs) included in the logical input transport stream. In addition to the **Program Number**, the table also displays the **Program Name**, the **PMT PID**, the Service **PCR PID** and the **Service Bitrate** for each service.
- **Output PIDs Table**: This table gives an overview of the elementary streams (ES) included in the transport stream. Each row represents an elementary stream and indicates the **PID ID**, the programs that reference this ES (**Ref by Service**), the **Type** of ES (note that the type can only be determined if the ES is referenced by a service or the PID is a PSI/SI-specific PID), the **Bitrate** and the **CC Errors**. In addition, it contains the PID value of the elementary stream of the logical input (**Input PID**) that corresponds with this elementary stream of the logical output, as well as the **Scramble State**.

#### Logical Outputs \> Properties

The **Properties** page button below the **Logical Inputs Table** displays the following parameters for the logical input transport stream:

- **Output Enable**: Enables or disables the output transport stream.
- **TS Type**: Can be set to *Multiplex* or *Transparent*.
- **Output TS ID**: Displays the transport stream ID. Configurable in Multiplex Mode.
- **TS** **Description**: In Multiplex mode, a description can be provided for the transport stream of up to 39 characters long. In Transparent mode, the description is taken from the logical input.
- **Source TS**: Displays the source transport stream. Only applicable when TS Type is *Transparent*.
- **Output Bitrate**: When the TS Mode is *Multiplex*, the bitrate of the TS can be configured.
- **Actual Output Bitrate**: The actual bitrate of the logical output transport stream.
- **Output Transport Errors**: The transport error count.
- **Output CC Errors**: The CC error count.

In order to apply the changes, click the **Apply** button.

#### Logical Outputs: Other Subpages

The logical outputs page also contains page buttons that display information related to the following Program Specific Information (PSI) tables:

- **PAT**: On this page, information related to the Program Association Table (PAT) is displayed.

- **Logical Output PAT TS ID**: The ID of the TS that carries the PAT. In *Generate* mode, the TS ID in the PAT is configured by the user.
  - **Logical Output PAT Number of Sections**: The number of sections the PAT table consists of.
  - **Logical Output PAT Mode**: If set to *None*, the device does not generate or pass the PAT. If set to *Generate*, the device generates the PAT (default). If set to *Pass*, the device passes the PAT without any changes.
  - **Logical Output PAT Repetition Rate**: Range: 50-1000 ms, in steps of 10 ms. Default: 300.
  - **Logical Output PAT Input TS**: The current logical input TS.
  - **Logical Output PAT Input PID**: In *Pass* mode, the Input PID is required. Range: 0-8190. Default: 0.

- **CAT**: on this page, information related to the Conditional Access Table (CAT) is displayed.

- **Logical Output CAT Version**: The version number of the CAT.
  - **Logical Output CAT Number of Sections**: The number of sections the CAT table consists of.
  - **Logical Output CAT Mode**: If set to *None*, the device does not generate or pass the CAT. If set to *Generate*, the device generates the CAT (default). If set to *Pass*, the device passes the CAT without any changes.
  - **Logical Output CAT Repetition Rate**: Range: 50-1000 ms, in steps of 10 ms. Default: 500.
  - **Logical Output CAT Input TS**: The current logical input TS.
  - **Logical Output CAT Input PID**: In *Pass* mode, the Input PID is required. Range: 1-8190. Default: 1.

- **NIT**: On this page, information related to the Network Information Table (NIT) is displayed.

- **Logical Output NIT Mode**: If set to *None*, the device does not pass the NIT. If set to *Pass*, the device passes the NIT without any changes (default).
  - **Logical Output NIT Input TS**: The current logical input TS.
  - **Logical Output NIT Input PID**: In *Pass* mode, the Input PID is required. Range 1-8190. Default: 16.

- **SDT**: On this page, information related to the Service Description Table (SDT) is displayed.

- **Logical Output SDT TS ID**: The TS ID that carries the SDT.
  - **Logical Output SDT Version**: The version number of the SDT.
  - **Logical Output SDT Number of Sections**: The number of sections the SDT table consists of.
  - **Logical Output SDT Mode**: If set to *None*, the device does not generate or pass the SDT. If set to *Generate*, the device generates the SDT (default). If set to *Pass*, the device passes the SDT without any changes.
  - **Logical Output SDT Original Network ID**: The ID of the originating delivery system. In *Generate* mode, you can configure the Original Network ID. Range 0-65535, in steps of 10 ms. Default: 1.
  - **Logical Output SDT Repetition Rate**: Range: 50-2000 ms, in steps of 10 ms. Default: 500.
  - **Logical Output SDT Input TS**: The current logical input TS.
  - **Logical Output SDT Input PID**: In *Pass* mode, the Input PID is required. Range 1-8190. Default: 17.

### Outputs Page

The Outputs page gives an overview of the physical outputs of the Harmonic ProView 8000 device. The Harmonic ProView 8000 supports two output types: GbE and ASI. For each output type, a table is included.

### Overview TsIn Page

This page gives a graphical overview of the logical input displaying the services and PIDs that are part of the logical input transport stream.

### Overview TsOut Page

This page gives a graphical overview of the logical output displaying the services and PIDs that are part of the logical output transport stream.

### Alarms Page

This page contains an overview of the active alarms in the **Active Alarms Table** and also displays a log of previous alarms in the **Alarm Log Table**.

For each alarm in the **Active Alarms Table**, a **Description** is given, as well as the **Fault Object** that caused the alarm, the **Asserted Time**, and a **Recovery Tip**.

For each logged alarm, the **Alarm Log Table** contains a **Description**, the **Fault Object**, the **Asserted Time**, the **State of the Alarm**, and the **Severity** of the alarm.

### Platform Page

This page displays general parameters of the device such as the **Device Model**, **Firmware Version** and **Device Name**.

The **IP Address**, **Subnet Mask** and **Default Gateway** of the Ethernet port for remote management are also displayed.

### Connect Page

On this page, you can provide a **Username** and **Password**.
