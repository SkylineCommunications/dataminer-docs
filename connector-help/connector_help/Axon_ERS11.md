---
uid: Connector_help_Axon_ERS11
---

# Axon ERS11

The **Axon ERS11** connector can be used to display and configure informaton of the Axon ERS11 central controller and the attached card types located in its different slots.

## About

This protocol can be used to monitor and control the Axon ERS11 main controller and the card types attached to the Axon frame. An **SNMP** connection is used in order to successfully retrieve and configure the device's information.

## Installation and configuration

### Creation

**SNMP Connection:**

- **IP Address/host:** The polling IP of the device.

**SNMP Settings:**

- **Port Number:** The port of the connection device (by default: *161*).
- **Get community string:** The community string needed to read from the device. The default value is *public.*
- **Set community string:** The community string needed to set to the device. The default value is *private.*

## Usage

### Main Element

There are different pages for the **Main Element**:

- **General** page: displays general information about the device, as well as settings, some of which can be modified (*System Name*, *System Location*, etc.). This page also contains the following page buttons:

- **TCP**: displays information about **TCP**, as well as settings, none of which can be modified.
  - **Interfaces**: displays information about **Interfaces**, as well as settings, some of which can be modified (*If Admin Status*).
  - **UDP**: displays information about **UDP**, as well as settings, none of which can be modified.
  - **Address Translation**: displays information about **Address Translation**, as well as settings, none of which can be modified.
  - **SNMP**: displays information about **SNMP**, as well as settings, some of which can be modified (*SNMP Enable Authen Traps*).
  - **IP**: displays information about **IP**, as well as settings, some of which can be modified (*IP Forwarding*, *IP Default TTL*, etc.).
  - **ICMP**: displays information about **ICMP**, as well as settings, none of which can be modified.

- **ERS11** page: displays information about **ERS11 Controller**, as well as settings, some of which can be modified (*ERS11 Card Name*, *ERS11 User Label*, etc.).

- **Cards** page: displays information about the different card types, as well as settings, some of which can be modified (*HAF900*, *SDR08*, *SDR09*).

### Virtual Elements

The connector contains different virtual elements (*ERS11*, *HAF90*, *SDR08*, *SDR09*) which contain specific information and settings related to the virtual element type:

- **ERS11**: the **ERS11** virtual element contains information and settings that are **ERS11** related. The virtual element contains the following pages:

- **General** page: displays general information about **ERS11**, as well as settings, some of which can be modified (*ERS11 User Label*).
  - **Control** page: displays information and settings that are **ERS11 Control** related. Most of these can be modified.
  - **Monitoring** page: displays information and settings that are **ERS11 Monitoring** related. None of these can be modified.

- **SDR08**: the **SDR08** virtual element contains information and settings that are **SDR08 Card** related. The virtual element contains the following pages:

- **General** page: displays general information about the **SDR08 Card**, as well as settings, some of which can be modified (*SDR08 User Label*).
  - **Amplifier** page: displays information and settings that are **SDR08 Amplifier** related. Some of these can be modified (*SDR08 Bitrate*).
  - **Alarming** page: displays information and settings that are **SDR08 Alarming** related. All of these can be modified.

- **SDR09**: the **SDR09** virtual element contains information and settings that are **SDR09 Card** related. The virtual element contains the following pages:

- **General** page: displays general information about the **SDR09 Card**, as well as settings, some of which can be modified (*SDR09 User Label*).
  - **Amplifier** page: displays information and settings that are **SDR09 Amplifier** related. Some of these can be modified (*SDR09 Bitrate*).
  - **Alarming** page: displays information and settings that are **SDR09 Alarming** related. All of these can be modified.

- **HAF90**: the **HAF90** virtual element contains information and settings that are **HAF90 Card** related. The virtual element contains the following pages:

- **General** page
  - **DMA info** page
  - **Delay** page
  - **Gain** page

## Notes

The **Axon ERS11** device is sensitive towards data polling.
