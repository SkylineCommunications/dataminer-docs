---
uid: Connector_help_Snell_Wilcox_IQSDA34
---

# Snell Wilcox IQSDA34

The **Snell Wilcox IQSDA34** connector monitors and controls changes on the amplifer unit through a Rollcall smart-serial protocol.

## About

The connector periodically polls relevant information from the device for every 15 seconds for Rollcall protocol purposes and every two hours for backchannel purposes.

### Version Info

| **Range**     | **Description**                 |
|----------------------|---------------------------------|
| 1.0.0.x              | Initial Version                 |
| 1.0.1.x \[SLC Main\] | Fixed channel source discreets. |

### Product Info

| **Range**     | **Device Firmware Version**                                         |
|----------------------|---------------------------------------------------------------------|
| 1.0.0.x              | Not related to firmware, but compatible with software version 5.2.6 |
| 1.0.1.x \[SLC Main\] | Not related to firmware, but compatible with software version 5.2.6 |

## Installation and Configuration

### Creation

The connector uses a serial TCP/IP connection and requires the following input during element creation:

**Serial TCP/IP CONNECTION:**

- **IP address/host**: The polling IP of the device.

**Serial Settings:**

- **Port number**: *2050 (by default);*
- **Bus address:** *xx.yy .*

## Usage

The connector has several display pages mentioned below.

### Channels and Monitor Page

The page displays from Channels 1 to 3 the following configurable information in table **Channel Information**:

- **SDI Rate Input;**
- **Mute Output;**
- **On Input Loss;**
- **Channel Input Source** (Except for Channel 1).

In addition to the previous there is a **Monitor Display** that shows the output concerning Channels 1 and 2, or Channels 1 and 3.

Table **Channel Log** allows the user to enable/disable several logging settings from channels 1 to 3.

The available information items that the user can enable/disable in the logs are the following:

- **Channel Ident;**
- **Channel Name;**
- **Channel Type;**
- **Channel State;**
- **Channel SDI Bitrate;**
- **Channel Output State;**
- **Channel Input Source (Except for Channel 1).**

### Memory 1-16 Page

The page displays the device's configurable **User Memory** setting slots from **1 to 16**.

The user can recall the settings from any of the previous slots with the **Recall Memory** selection and visualize the last used memory setting slot in **Last User Memory.**

To save a memory setting, the user can select a user memory slot setting through **Sel Memory** (or select none) and choose whether to **Save** or **Clear the memory.**

The user has also the chance to assign a User Memory Name in the **Change Name** input - the value will be displayed on the right.

### Misc Logging Page

The page displays the options to enable/disable logging for miscellaneous settings and visualize each setting's value.

The available information items that the user can enable/disable in the logs are the following:

- **Serial Number;**
- **OS Version;**
- **Build Number;**
- **Hardware Version;**
- **Uptime;**
- **Rear ID;**
- **Licensed Options;**
- **RollTracks;**
- **Last Recall Memory.**

### Rolltrack Page

The page displays the following configurable items:

- **Disable** all rolltrack commands;
- Rolltrack **Index Selection (1-16);**
- **Source Selection;**
- **Address/Command** for each Index selection;
- Rollcall **status** and its respective **sending** status.

### Setup Page

The page displays the following information for the **product settings:**

- **Product;**
- **Release;**
- **Build;**
- **KOS;**
- **Serial Number;**
- **PCB;**
- **Rear ID.**

The user can also reset the device to its **default** or **factory settings,** and **restart the device.**

The page also displays the **Input Settings**, where the user can **assign name values for each input (from 1 to 3).**

**And finally there is the Serial ID/Board settings.**

### Connection Info Page

The Connection Info page displays the information regarding the Rollcall protocol such as:

- **Session status;**
- **Session number;**
- **Simulated Rollcall Response** (through the user's input);
- **Card's user name;**
- **Unit Address;**
- **Unit Port;**
- **Local Session Number.**
