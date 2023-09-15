---
uid: Connector_help_Crystal_Vision_Synner-E_3G
---

# Crystal Vision Synner-E 3G

The **Crystal Vision Synner-E 3G** connector monitors the Synner-E 3G Video Synchroniser. This connector can also be used to control the features available in the **Crystal Vision Statesman** application.

## About

The information and controls available in the connector are separated in multiple pages. Most of the pages and naming are similar to the interface of the **Crystal Vision Statesman PC control software**. All of the information and settings available via the CV Statesman software are also available in the connector.

## Configuration and installation

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Slot number (where the card is located in the frame).

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General

This page displays the **board information** (**card slot**, **type**, **name**, **issue** and **serial number**). The **presets** and **resets** (available on the Presets&Resets page in the control software) are also available on this page.

### Status

This page contains the same parameters as the status page in the control software. Most of these parameters are **LED values**, which can be either *on* or *off* (*yes* or *no*).

### Video Control

This page has the same information as the **video control** page in the control software.

### Audio Control

This page is similar to the **audio control** page in the control software.

### Audio Input

This page only displays page buttons, with which you can access all the audio input information that is displayed in the control software.

### Audio Delay

This page is similar to the **audio delay** page in the control software, but page buttons were added that are used for the audio delay. Total delay (which is available in the control software) is not implemented on this page.

### Embedder Router

This page has the same functionality as the **embedder router** page in the control software. The **input** can be selected for each output. When the inputs have been changed, press the **Take** button in order for the changes to be saved. There are also two page buttons to either **mute the outputs** or to see which **outputs** **are** **present**.

### AES Router

This page is similar to the **embedder** **router** page.

### Video Gain

On this page, all the **video gain settings** can be changed.

### De-embedded Gain

On this page, all **de-embedded input gains** can be set. In the control software, these inputs where separated in multiple pages.

### AES Gain

This page is similar to the **De-embedded gain** page, but here the **AES gain** can be set.

### Alarm

This page has the same information as the **Alarm** page in the control software. The various settings can be accessed through page buttons.

### Webpage

This page is a link to the **webpage** of the frame where the card is located. Note that the web interface of the device must be accessible from the client PC.
