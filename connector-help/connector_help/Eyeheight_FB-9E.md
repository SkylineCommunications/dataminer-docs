---
uid: Connector_help_Eyeheight_FB-9E
---

# Eyeheight FB-9E

With the **Eyeheight FB-9E** connector you can monitor and control the settings of multiple processing cards that fit into the six slots of the eyeheight etherbox (FB-9E).

## About

This connector provides an overview of the setup of each card in the slots of the chassis. The **Slot Configuration** page displays the different occupied slots, and the **RGB/YCC** and **Composite** page contain the setup values. All settings can be modified.

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION:**

- **IP address/host:** The polling IP of the device, e.g. *10.11.12.13.*
- **IP port:** The IP port of the device, 4757.
- **Bus address:** The bus address of the device, not required.

## Usage

### Slot Configuration page (main element)

This page contains the **Configured Slot Table** and a page button 'Configure Slots...' that opens a pop-up page displaying the **Slot Table**.

Both tables have the following four columns: **Slot idx**, **Slot Name**, **Slot Type** and **Network ID**. You can set the slot type and the NID of the six rows, which each represent a slot, in the Slot Table. The slot type can either be '*No Slot*' or '*LE-2 legaliser*'. The NID has a range from *0* to *255*.

The slots with slot type '*LE-2 legaliser*' will be displayed in the Configured Slot Table together with a fifth column, **Export DVE**. This column contains the virtual element IDs.

### RGB/YCC page (virtual element)

This page contains the **RGB setup**, the **YCC luma** and the **YCC chroma** **setup**. Each of these three setups has four parameters: **High and Low Clip** and **High and Low Knee**.

You can set all twelve parameters. All the parameters on this page are displayed as a percentage and are polled every minute.

### Composite page (virtual element)

This page displays the **Legaliser Mode** and **Domain**, the **Ring Suppression setup** and the **Composite setup**. All parameters can be modified by the user. The Ring Suppression Status, Legaliser Mode and Legaliser Domain are polled every 10 seconds and the other parameters on the page every minute.

The **Legaliser Mode** can have the following values: *off*, *RGB*, *YCC*, *comp* or *comp and RGB*. The **Legaliser Domain** can be *Auto*, *PAL*, *NTSC* or *NTSC with 7.5 IRE offset*.

The *Ring Suppression setup* has three parameters: the **Ring Suppression Status** (*off*, *on* or *auto*), the **Ring Suppression High Clip** and the **Ring Suppression Low Clip**. The High and Low Clip are displayed as percentages.

There are eight parameters for the **Composite Setup**. The four parameters for both composite Luma and Chroma are **High and Low Clip** and **High and Low Knee**. These eight parameters are displayed in mV.
