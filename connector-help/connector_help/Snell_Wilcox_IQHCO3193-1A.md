---
uid: Connector_help_Snell_Wilcox_IQHCO3193-1A
---

# Snell Wilcox IQHCO3193-1A

The aim of this connector is to monitor and control the **IQHCO3193-1A** device and mainly to configure the logical conditions that are used by the device for auto-switching.

## About

This connector implements the RollCall protocol (serial protocol) for all communication with the device.

It is a smart-serial single connector, so all the updates are sent by the device asynchronously, which reduces the network load and improves performance.

The version 1.0.0.1 was built for the firmware *4668*.

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION**

- **IP address/host**: The polling IP of the device, e.g. *172.16.61.11*.
- **IP Port:** The IP port of the device, e.g. *2050*.
- **Bus address:** Used to fill in the Unit Address and the Unit Port, e.g. *26.02* is for Unit Address *0x26* and Unit Port *0x02*.

## Usage

### Outputs

This page displays the main output parameters: **Master Select**, **Monitor Select**, **Frequency**, **Channel Ident**, etc.

### Video Master

On this page, you can set the master video configuration through the **Decision, Overload Level, Manual Freeze, Carrier Decision, Valid Recover Delay**, etc.

The following page buttons are available:

- The **Timers** page button opens a page where you can set the **Type Fail Timer,** **Low Fail Timer**, etc.
- With the **Master Pair** page buttons, you can set the **Low-Level**, the **Overload** and the **Type Expected** for each of the 8 master pairs.
- With the **Valid Input Stds** page button, you can select the standards (**1080/50-B**, **1080/25i**, etc.).
- The image settings can be configured via the **Video Procamp** page button: **Black Level, Hue Adjust, Master Video Gain, Y/C Timing**, etc.
- The **Blanking** page button opens a page where default blanking rules can be selected (**Blank HANC, Blank Lines: Line 23**, etc.).

### Audio Master

On the Audio Master page, embedders can be enabled (**Enable 1, Enable 2**, ...).

The following page buttons are available:

- The **Delays** page button can be used, amongst others, to manage the track delays (**Track 14 Delay,** **Track 15 Delay**, etc.).
- The **Delay Status** page button shows the effective delays affecting the parameters configured in the previous page button.

### Video Backup

The configuration parameters on this page are similar to those present on the Video Master page, but here they apply to the Video Backup configuration.

### Audio Backup

The parameters on this page are similar to those on the Audio Master page, but here they apply to the audio backup.

### Rules Video Master

On this page, you can configure the rules that are used for auto-switching to the Video Master: **Switch to Master**, **Video Master Rules (RollTrack 103), Switch to Master GPI 1**, etc.

### Rules Video Backup

The parameters on this page are similar to those on the Rules Video Master page, but here they apply to the Video Backup.

### GPI Enable

On this page, you can decide for GPIOs 1 to 4, to **invert** them, define the **direction** or monitor their **state**.

### Rules GPI 1 Out

On this page, parameters are available for the GPI 1 Out auto-switching rules configuration: **GPI 1 Output (Master), GPI 1 Output (GPI 1), GPI 1 Output (RollTrack 104)**, etc.

### Rules GPI 2 Out

This page displays parameters for the GPI 2 Out auto-switching rules configuration, similar to those on the Rules GPI 1 Out page.

### Rules GPI 3 Out

This page displays parameters for the GPI 3 Out auto-switching rules configuration, similar to those on the Rules GPI 1 Out page.

### Rules GPI 4 Out

This page displays parameters for the GPI 4 Out auto-switching rules configuration, similar to those on the Rules GPI 1 Out page.

### RollTrack Enable

On this page, you can change the command state for RollTracks 101 to 104 and see their effective state.

### Rules RollTrack 101

On this page, you can configure the auto switching rules for RollTrack 101: **RollTrack Output 1 (Master), RollTrack Output 1 (GPI 1), RollTrack Output 1 (RollTrack 102)**, etc.

### Rules RollTrack 102

On this page, you can configure the auto switching rules for RollTrack 102, similar to the configuration on the Rules RollTrack 101 page.

### Rules RollTrack 103

On this page, you can configure the auto switching rules for RollTrack 103, similar to the configuration on the Rules RollTrack 101 page.

### Rules RollTrack 104

On this page, you can configure the auto switching rules for RollTrack 104, similar to the configuration on the Rules RollTrack 101 page.

### Presets

You can use the buttons on this page to rapidly define a configuration with presets: **Priority Master, Priority Backup, No Priority**, etc.

### Genlock

On this page, the genlock configuration is possible, with the **Freerun Frequency**, the **Genlock Save Index,** the **Default Format**, etc.

### Memories

On this page, you can amongst others select a memory (**Sel Memory**), set its name (**Set Memory Name**), and see the defined memory names (**Memory 1 Name** to **Memory 16 Name**).

### Logging

On this page, general logging information is displayed: **OS Version, Hardware Version, Firmware Version, Backup State, Licensed Options**, etc.

The following page buttons are available:

- You can use the **Input 1** page button to monitor the **Input 1 Standard**, the **Input 1 Type, Input 1 Audio 1 1, Input 1 Audio 4 2**, etc. The **Input 2** subpage is similar but applies to input 2.
- The **Output 1** page button displays logging for the **Output 1 Type, Output 1 State, Output 1 Std**, etc.
- The **GPI** page button shows the state of the GPIs 1 to 4.
- The **RollCall** page button shows the state of the RollCalls 1 to 4.
- Click the **RollTrack** page button to monitor **RollTrack Output 1** **State** to **RollTrack Output 4 State**.

### RollTracks

On this page, you can configure the **RollTrack Index, RollTrack Source, RollTrack Address,** **RollTrack Command**, etc.

### Status

On this page, you can find the **Status Display**, **Software Version**, **Serial no**, **KOS Version**, **Up Time**, etc.

### Connection Info

This page provides general information about the connection: the **Session Status**, **Assigned Session Nr, Unit Address, Unit Port**, etc.

It is also possible to force a new poll with the **Force Poll** button.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
