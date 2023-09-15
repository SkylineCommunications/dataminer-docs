---
uid: Connector_help_Riedel_Communications_ConnectTrio
---

# Riedel Communications ConnectTrio

ConnectTrio combines the following in one half-rack/1RU device: two independent analog POTS telephone hybrids, an ISDN S0 interface with two independent ISDN B-channels, and two independent VoIP audio codecs. Connect Trio enables dialing, making and receiving calls to and from any PSTN, VoIP, ISDN or mobile phone as well as G.722 reporter codecs.

## About

This connector uses a **serial** connection in order to retrieve information from the device and configure settings on the device.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Type of port**: UDP/IP.

## Usage

### General

On this page, you can find **call, redial and disconnect** functionality for POTS, ISDN and VoIP.

There are also LED bars indicating the outgoing and incoming audio level for both channels. These bars are updated twice per second, in order to provide a real-time view of the volume changes.

Finally, the **Last Called** parameter is updated with the redial number as soon as the current call is disconnected.

### System Monitor

This page displays general hardware status parameters, including the **processor load** and **system temperature**, general hardware alarms and the **Ethernet status**.

### Configuration

This page contains parameters that allow you to configure the system, such as audio volume, analog-to-digital and audio switching.

The page consists of two main sections and two subpages that are available via page buttons.

**General** section:

- **System Name:** User-defined system name for unit identification (does not have any impact on the system).
- **PC Control Via RS232/Keypad 1 Interface:** Serial port settings. (This parameter name was based on the ConnectTrio software.)
- **External Pretalk phones:** Enables/disables external phones as pretalk interface (only available in POTS mode).

**Line Settings** section:

- **Line Mode:** Enables the choice between POTS, ISDN and VoIP interfaces. (Note that currently only POTS is available, because of missing licenses for the other 2 modes.)
- **Output Level** **Attenuation:** Line level output offset ranging from -16 to 0 dBs.

**AGC** and **Audio Settings** subpages:

- These pages allow you to further tweak tweak **advanced configuration** parameters regarding input and output audio volume, as well as commute between digital and analog communication.
  Since these are more advanced settings, a **Default Settings** button is available in order to reset these parameters to their original values.
