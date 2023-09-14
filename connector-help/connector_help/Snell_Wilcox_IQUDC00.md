---
uid: Connector_help_Snell_Wilcox_IQUDC00
---

# Snell Wilcox IQUDC00

This smart-serial protocol allows to poll configuration parameters from Snell Wilcox IQUDC00 devices and to edit them.

## About

At startup, the element establishes the connection with the device and, afterwards, waits for change notifications initiated by the device for any parameter change. For this purpose, the protocol is of type "smart-serial single".

2 connections are available. The first one will be used at startup. If the first connection is lost, the element automatically switches over the second one. And if the last one is lost, the element will try to reconnect on the first one.

The communication is based on the RollCall serial protocol.

### Version Info

| **Range** | **Description**                               | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                               | No                  | Yes                     |
| 2.0.0.x          | Smart-serial implementation instead of serial | No                  | Yes                     |
| 3.0.0.x          | RollCall version.                             | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | All                         |
| 2.0.0.x          | All                         |
| 3.0.0.x          | 2.213                       |

## Installation and configuration

### Creation

#### Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device (e.g. *127.0.0.1*).
  - **IP port**: The IP port of the device. Required (default: *2050*).
  - **Bus address**: The bus address of the device. Required (format: '\*.\*.\*'; for example: *0000.47.03*).

Serial Secondary connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device (e.g. *127.0.0.2*).
  - **IP port**: The IP port of the device. Required (default: *2050*).
  - **Bus address**: The bus address of the device. Required (format: '\*.\*.\*'; for example: *0000.47.04*).

### Configuration of element timeout time

To improve switching speed when one of the connections is lost, it is advised to set to 1 s the configuration parameter 'The element goes into timeout state when it is not responding for (sec):' in the 'Advanced element settings' section at element creation.

## Usage

### General

On the General page, are available parameters such as the **Pattern** or the **Output Standard**.

### Information

Here, you can find the **Information Window, Unit Status, Unit Ref Status** or **Unit Ref Standard**.

### Audio Delays

Following parameters can be found on this page: **Audio Delay Select-A Manuel, Audio Delay Select-A Rolltrack 16, Audio Delay Select-A Total Delay, Audio Delay Select-B Rolltrack 14,** ...

In the **Delay Selection** page button, following parameters are editable: **EMB Delay-1** to **EMB Delay-8**.

### Audio Status

Here are displayed parameters **Audio 1 Status** to **Audio 8 Status** and also **Audio 1 Type** to **Audio 8 Type**.

### Genlock And Video Delay

This page contains these parameters: **Audio Pair Selection** and **Line Number**.

### ARC Control

Here, you can access the following parameters, among others: **Recall Memory, ARC Tilt, Input Crop Right, Input Crop Top,** ...

### Picture Output

Here you can change the following parameters: **V Enhance, Colorimetry, Film/Video, Border Right, Border Top**.

In the **Adv. H Enhance** page button, these parameters are present: **AHE Status, AHE Freq Band, AHE Presets, AHE Gain, AHE Noise Rejection**.

### Input

**Select Input, Valid Standard 1080/25i, Valid Standard 625/25i** or **Valid Standard 525/29i** are some of the parameters accessible on the Input page.

In the **Input Information** page button, you can find the **Input 1 Standard, Input 1 Status, Input 2 Standard** and **Input 2 Status** parameters.

The **Define Inputs** page button allows the edition of several parameters such as the **Input 1 Valid Std, Input 1 Audio Pair 6, Input 2 Audio Pair 3,** ...

In the **Backup Rules** page button, you can find parameters **Rule 1** to **Rule 5, Rule 1 Select Input** to **Rule 5 Select Input** and **Rule 1 Time Delay** to **Rule 5 Time Delay**.

### Output

This page gives you the following parameters: **Output Standard, Master Gain, Y Gain, C Gain, Black Level, Default Output** and **Force Freeze**.

### Emb Proc Amps Groups 1-2

In this page, there are the following parameters: **Group 1 Pair 1 Stereo, Group 1 Pair 2 Right Gain, Group 2 Pair 1 Left Mute, Group 2 Left Audio Inversion, Group 2 Pair 2 Stereo,** among others.

### Embedded Routing Groups 1-2

**Group 1 Pair 1 Link L+R, Group 1 Pair 2 Embed 1-L, Group 2 Pair 1 Embed 1-R** and **Group 2 Pair 2 Link L+R** are example of parameters present on this page.

### Embed On-Off

Some of the embed parameters editable on this page are: **Group 1 Active,** **Group 2 Pair 1 Left Active, Group 3 Pair 1 Right Active** and **Group 4 Pair 2 Right Active**.

### Session Information

This page shows the **Session Status** parameter and gives the ability to force a manual polling of all the parameters through the **Refresh** button.

### Web Interface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage (3.0.0.x)

### General

This page contains various device-related parameters such as producer, serial number, PCB, release, Build number, MIO, MV, and MH. It also contains the Information Display and 2 buttons + a page button:

- Connection Info... - Opens up a pop-up page containing connection and session parameters such as the local session number, assigned session number, and more.
- Restart - restarts the device.
- Factory - sets the device back to factory defaults.

### Video Input

Contains Input and Error parameters: Input Select, various standard enables, Backup, and YC Delay. For errors, it includes the CRC and ANC errors, as well as the time since the last error or reset. Also includes 3 buttons:

- All valid - sets all of the above standard enables to "enabled".
- All invalid - sets all of the above standard enables to "disabled".
- Reset Counters - resets all of the error counters.

### Video Output

This page contains Output, ProcAmp, and Utilities controls. The Utilities controls includes Monochrome and User Caption configurable parameters.

### Picture Output

Here you can configure the Output Border, Film/Video - Scaler Delay, RGB Legalizer, Luma Clipper, and Enhancer.

### ARC Control

This page contains configurable parameters related to the ARC Display Memory, and ARC, including ARC Size, Aspect, Tilt, Pan, Origin and Input Crop settings.

### Wide Screen Signalling

Here you can configure both Output aspect ratios, Input and Output Signalling enables, and others such as the Input Wide Screen Signal, Force Input Mode, and Output Aspect.

### Ancillary Data

Here you can configure SD VBI Lines 7-23, HD VANC parameters such as enables for ATC and CC708, and SMPTE 2016 parameters.

### Emb ProcAmp Groups 1-2

This page contains the Gain, Invert, Mute, and Stereo controls for Embedder Pairs 1-4.

### Embedded ProcAmp Groups 3-4

This page contains the Gain, Invert, Mute, and Stereo controls for Embedder Pairs 5-8.

### Audio Mixers 1 and 2

This page contains the name control and all 4 Source, Invert, Gain, and Mute controls for Mixers 1 and 2.

### Audio Mixers 3 and 4

This page contains the name control and all 4 Source, Invert, Gain, and Mute controls for Mixers 3 and 4.

### Embedded Routing

This page contains the Link L + R, and source controls for all embedders.

### Embed On-Off

This page contains the Audio Control, as well as the Group/Pair enables for all groups and pairs.

### Embedded Input Setup

This page allows the user to edit the names of all disembedder pairs, and also contains the Stereo and Data controls for all disebmedders.

### Embedded Output Setup

This page allows the user to edit the names of all embedder pairs, and also contains the stereo controls for all embedders.

### Genlock and Video Delay

This page contains delay controls such as delay timing, vertical/horizontal timing, delay mode, and internal delay. It also includes Dolby E Timing controls and Sync Amplitude.

### Audio Delays

This page contains the Manual, GPI Pulse Width, RollTrack, and Total Delays for A and B. It also includes controls for all 8 EMB delays.

### GPIO

This page contains the GPIO Input 1 and input 2 controls.

### Default Input OK

This page contains the Valid Input Standard controls for both input 1 and 2, EDH/CRC is OK enable for Input 1 and Input 2, and Pairs 1-8 Present for Input 1 and Input 2.

### Backup Rules

This page contains Rules 1-4 Input, Select, and Delay controls.

### RollTrack

This page contains RollTrack Output controls: Disable all, Index, and Source. It also includes Address/Command params, the RollTrack Status, and the RollTrack Sending.

### Memory

This page includes the Recall Memory, Select Memory, Memory Name, Last Display Memory parameters and one button:

- Save Memory- saves the current memory.

### Logging Video Input

This page allows the user to include/exclude Video Input 1 and 2 parameters in logging. It also provides those parameters' values.

### Logging Audio State

This page allows the user to include/exclude Audio State Input 1 and 2 parameters in logging. It also provides those parameters' values.

### Logging Audio Type

This page allows the user to include/exclude Audio Type Input 1 and 2 parameters in logging. It also provides those parameters' values.

### Logging Miscellaneous

This page allows the user to include/exclude various system parameters (versions, build number, up time)in logging. It also provides those parameters' values.

### Logging Output Audio Level

This page allows the user to include/exclude Output Audio Level parameters in logging. It also provides those parameters' values.

### Logging Output Audio State

This page allows the user to include/exclude Output Audio State parameters in logging. It also provides those parameters' values.

### Logging Output Audio Type

This page allows the user to include/exclude Output Audio Type parameters in logging. It also provides those parameters' values.

### Logging Output Dolby E

This page allows the user to include/exclude Dolby E parameters in logging. It also provides those parameters' values.

### Logging Ref/Output

This page allows the user to include/exclude Ref/Output parameters in logging. It also provides those parameters' values.

### Logging Widescreen

This page allows the user to include/exclude Widescreen parameters in logging. It also provides those parameters' values.

### Diagnostics

This page contains various Diagnostic test controls such as Run Test (user picks the test to run), Loop Test (user picks the test to loop), the current loop count, the error counters, progress, test ID, and last error. It also includes 2 buttons:

- Run All Tests - Runs all tests, instead of just one.
- Stop Tests - Stops all running tests.

### Web Interface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
