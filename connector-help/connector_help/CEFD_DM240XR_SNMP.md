---
uid: Connector_help_CEFD_DM240XR_SNMP
---

# CEFD DM240XR SNMP

Radyne's DM240XR family is a High-Speed Modulator which meets the exacting standards of High Data-Rate Video, Internet and Fiber Restoral Satellite Applications.

## About

This connector is created for the CEFD DM240 XR Modulator.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | F05977AG                    |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Settings:

- **IP port**: 161
- **Get community string**: public
- **Set community string**: private

## Usage

### General

This page displays the general information about the device: **System information**, **manufacturer**, **firmware**, **IP Addresses**, ... and shows all the **alarmstates of the device.**

### Modulator

This page displays all the parameters which are related to the modulator. The **network specification** can change the other values like **Frequency, Power, Spectrum, Carrier Control, Data rate, Symbol Rate, FEC, ...**

Ranges, discreets and the possibility to set will be automatically adjusted when the network specification changes (introduced in version 1.0.0.2)

There are 2 subpages: **Phase Noise** and **Local Oscillator** with their properties.

### Interface

This page displays all the parameters regarding the Interface: **Interface Mode, Redundancy Mode, Interface Type, Clock Sources, PIIC Slots, Terrestrial Framing, and Polarity settings.**

There is a subpage called **Switch**. Properties and settings regarding the RF Switch are displayed here (**Redundancy Mode, Fault settings, Active Sides**)

### Ethernet

This page is divided in 4 groups (since version 1.0.0.2): **Settings** (**Mode and Jitter settings**); **Statistics** (**link status and packet counters**), **Primary** (Primary **IP Address**, **Data** and **FEC**) and **Backup** (same parameters as Primary)

### Test

This page displays Test parameter settings. **Carrier Type** and **Pattern** can be chosen. The **interleaver**, **FEC** and the **Scrambler** can be activated.

### Carrier

**Carrier ID** values are shown on this page: **Position, Telephone, User Data** and **Test Number**

### Monitor

All **alarm states** (the same ones as on the general page) are shown here. There is a subpage "**Mask Alarms**..." where all the alarms can be (un)masked.
