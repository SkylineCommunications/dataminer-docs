---
uid: Connector_help_Imagine_Communications_ACO6800+ASID
---

# Imagine Communications ACO6800+ASID

The ACO6800+ switchover module is designed for the 6800+T core processing platform and provides both the primary and backup paths critical to maintaining uninterrupted video and audio signal flow.

## About

The ACO6800+ is available as a single- or dual-channel module that provides switchover capabilities from the primary to the backup path in the event of a signal failure. In addition to the basic switchover module, the ACO6800+ is also available as an intelligent Q-SEET-compliant module that monitors video, audio and metadata at ingest, checks levels for consistency and scans for errors.

ACO6800+ASID switches the signal between redundant signals at the point of ingest into a satellite DTH, mobile TV, or IPTV facility as well as switches the signal on redundant paths within a facility.

### Version Info

| **Range** | **Description**                                                                                                    | **DCF Integration** | **Cassandra Compliant** |
|------------------|--------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version. Full support for all feature of this specific card. Support for both ASI mode and SDI mode | No                  | Yes                     |

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

The general page contains generic information about the device displaying the device serial number, the Soft Reboot and Factory Recall option.

### Inputs

In the Inputs Page the user will find available all the data related with CRC Change, CRC Error, PAT, PMT, and all the Alarms (Priority 1 Alarm, Priority 2 Alarm, General Alarms and Alarms).

### System

In the System page contains the Switch Settings, Out B Settings and the General Puropose Interface.

### Alarms

The Alarms Page provides the alarming configuration related with Relay Bypass On.

### Web Interface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
