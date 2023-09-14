---
uid: Connector_help_EVERTZ_500DA2Q-3G
---

# EVERTZ 500DA2Q-3G

The **Evertz 500DA2Q-3G** is a Dual 3G Reclocking Distribution Amplifier. This module provides distribution of SMPTE ST 424 (3Gb/s), SMPTE ST 292-1 (1.5Gb/s), SMPTE ST 259 (270Mb/s), DVB-ASI or SMPTE ST 310 (19.4Mb/s) or any other SDI signal within the 143Mb/s to 1.5Gb/s range. The 500DA2Q-3G features two auto-equalized inputs and can be individually set via jumpers for either reclocking or non-reclocking.

## About

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *10.145.1.12*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

## Usage

### General Page

This page contains the **Channel Monitor Table** that allows the user to monitor **Input Video Rates** for channels 1 and 2, their **Lock Status** and **Bypass** selected.

### Faults Page

This page displays the **Faults Table** which provides monitoring of **Module Not Ok** type faults. It allows trap configuration for each instance and displays the current **Fault Status**.
