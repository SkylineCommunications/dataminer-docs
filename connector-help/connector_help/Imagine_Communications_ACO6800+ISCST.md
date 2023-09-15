---
uid: Connector_help_Imagine_Communications_ACO6800+ISCST
---

# Imagine Communications ACO6800+ISCST

The ACO6800+ switchover module is designed for the 6800+T core processing platform and provides both the primary and backup paths critical to maintaining uninterrupted video and audio signal flow.

## About

The Clean/Quiet ACO6800+ISCST module enures that there are no abrupt relays or interruptions of video and audio signals (e.g., in the event of a cable or fiber cut) and no audible "pops" or noises when the automatic changeover takes place, restoring the integrity of the signal.

Switches signals between redundant signals at the point of ingest and ingest timing into a satellite DTH, mobile TV, or IPTV facility

### Version Info

| **Range** | **Description**                                                                                                     | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version. Full support for all feature of this specific card. Support for both ASI mode and SDI mode. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.2                         |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **Bus Address:** X.Y, where X = Frame Number and Y = slot number

#### Serial PortDev Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: any, meaning the device will reply in broadcast mode.

## Usage

### General

The general page contains generic information about the device displaying the device serial number, license key and other general information.

### System

The system page provides information regarding Sync, Genlock, Operation Frame and Operation Standards.

Subpages where designed in order to make available the configuration of the General Purpose Interface and the Switch Settings.

Note: This page display may vary based on the device Operation Mode.

### Video

The video page provides the configurations interface over the device's video features.

Note: This page is only available when the device is configured with the SDI mode.

### Audio

The Audio page provides the configurations interface over the device's audio features

Note: This page is only available when the device is configured with the SDI mode.

### Line Sync

The Line Sync page provides all the configuration parameters related with the Line Synchronization.

Note: This page is only available when the device is configured with the SDI mode.

### Frozen Detection Sensitivity

This page provides configuration related with screen frozen detection sensitivity.

Note: This page is only available when the device is configured with the SDI mode.

### Alarms

The alarms page provides all alarming configuration related with SRC Bypass, Demux, Tones, Output, processing and audio states.

Note: This page display may vary based on the device Operation Mode.

### Inputs

In the inputs page the user will find available all the data related with SQM settings SQM status, input status and alarming status.

Note: This page display may vary based on the device Operation Mode.

### Web Interface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
