---
uid: Connector_help_Evertz_7700_General_Platform
---

# Evertz 7700 General Platform

The **Evertz 7700 General Platform** connector is used to monitor and control an Evertz chassis containing different Evertz 7700 series cards.

## About

The chassis must include an **Evertz 7700-FC** card to be functional. Data about the location of other cards is polled from this card. Evertz 7700-FC is placed in slot 1, other cards are inserted in slots 2 to 15. A DVE will be created for each (supported) card. Data is polled via **SNMP**. Traps are supported to reduce the amount of polling. When a trap is received, the corresponding parameter is polled again to update its value.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

The connector should be compatible with all firmware versions. It has been tested with the following firmware versions (the version number is the value of the SNMP parameter 'Software Build'):

| **Range** | **Device Firmware Version**               |
|------------------|-------------------------------------------|
| 1.0.0.x          | v3.07 Build 2 v4.02 Build 9 v4.02 Build15 |

### Exported connectors

Details about the supported cards can be found at the end of this document.

| **Exported Connector**                 | **Description**                                                                                                                                                               |
|---------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Evertz General Platform 7700R2X2-HD   | Used for the 7700R2X2-HD module.                                                                                                                                              |
| Evertz 7700DA7                        | Used for the 7700DA7-HD and 7700DA7 types.                                                                                                                                    |
| Evertz SWPBRF7700                     | Used for the SWRF87703, SWRF167703, SWRF16A7703, SWRF16B7703, SWRF8B7703 and SWRF47703 types.                                                                                 |
| Evertz 7880IPASIIP                    | Used for the 7880IPASIIP module.                                                                                                                                              |
| Evertz 7703DA-RFA                     | Used for the 7703DA4A-RF, 7703DA4A-RF-LNB, 7703DA8A-RF, 7703DA8A-RF-LNB, 7703DA16-RF, and 7703DA16-RF-LNB types.                                                              |
| Evertz 7880IRD-H264                   | Used for the 7780IRD-H264-HD-LB module.                                                                                                                                       |
| Evertz 7700DA6                        | Used for the 7700DA6-HD-L and 7700DA6-L types.                                                                                                                                |
| Evertz 7780DMIPLB                     | Used for the 7780DM2-IP-LB, 7780DM2-IP-LB2, 7780DM-IP-LB2, 7780DM4-IP-LB, 7780DM2-IP-CA and 7780DM4-IP-CA types.                                                              |
| Evertz 7707VT8                        | Used for the 7707VT8 module.                                                                                                                                                  |
| Evertz 7707VT8-HS                     | Used for the 7707VT-8-HS module.                                                                                                                                              |
| Evertz 7707VR8-HS                     | Used for the 7707VR-8-HS module.                                                                                                                                              |
| Evertz General Platform BPXRF         | Used for the 7703BPX-LB, 7703BPXA-LB, 7703BPX50-LB, 7703BPXA-LB-50, 7703BPX-IF, 7703BPXA-IF, and 7703BPX50-IF types (where LB and IF denote the L-Band or IF Frequency type). |
| Evertz 7708LR                         | Used for the 7708LRA and 7708LR-H types.                                                                                                                                      |
| Evertz 7708LT                         | Used for the 7708LT, 7708LT-LNB, 7708LT-DWDM and 7708LT-DWDM-LNB types.                                                                                                       |
| Evertz 7707OE                         | Used for the 7707EO-3G, 7707OE-3G, 7707OE-3G-H, 7707OE-3G-1 and 7707OE-3G-H-1 types.                                                                                          |
| Evertz 7780ASI-B2-DS3                 | Used for the 780ASIB2-DS3/E3 module.                                                                                                                                          |
| Evertz General Platform 7703PA        | Used for the 7703PA, 7703PA-LNB, 7703PA-2, 7703PA-2-LNB and 7803PA-2-LNB2 types.                                                                                              |
| Evertz General Platform 7881DEC2MP2HD | Used for the 7881DEC2-MP2 module.                                                                                                                                             |
| Evertz General Platform 7700ACO2HD    | Used for the 7700ACO2HD module.                                                                                                                                               |
| Evertz 7812DCDA2Q                     | Used for the 7812DCDA2Q module.                                                                                                                                               |
| Evertz 7814UDX                        | Used for the 7814UDX module.                                                                                                                                                  |
| Evertz 7736CEM                        | Used for the 7736CEM, 7736CEM-A4 and 7736CEM-AES types.                                                                                                                       |
| Evertz 7700ACOHD                      | Used for the 7700ACO-HD module.                                                                                                                                               |

## Installation and Configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP address/host:** The polling IP of the device, e.g. *10.11.12.13*.

**SNMP Settings:**

- **Port number:** The port of the connected device, by default *161*.
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

## Usage

This connector displays information about the Frame Controller (**Evertz 7700-FC**) and the list of inserted cards. The element has three pages:

### Input Cards

This page lists all the modules embedded in the chassis and their corresponding slots.

### Frame Parameters

This page displays general parameters for the **Evertz 7700-FC** controller, such as the **temperature**, **power supply**, etc.

### SNMP Config

On this page, you can configure the **SNMP** agent: the **trap** destination, the communities, etc.

## Supported cards

### Evertz 7700R2X2-HD

The 7700R2X2-HD module has two SD/HD compatible input signals (program and backup) that support different input video formats. This module also provides three reclocked primary outputs, and one reclocked backup output.

- Supported types: 7700R2x2-HD.

### Evertz 7700DA7

The 7700DA7 series distribution amplifier features an auto-equalized input with seven reclocked outputs.

- Supported types: 7700DA7-HD or 7700DA7.

### Evertz SWPBRF7700

The Evertz SWBRF is a switch router for RF streams.

- Supported types: SWRF87703, SWRF167703, SWRF16A7703, SWRF16B7703, SWRF8B7703, SWRF47703.

### Evertz 7880IPASIIP

The 7880IP-ASI-IP is a complete hardware-based solution to transform ASI to IP, and IP to ASI. The 7880IP-ASI-IP can also regenerate IP from IP input with different settings and add FEC.

### Evertz 7703DA-RFA

The 7703DA-RF active splitters provide amplification and distribution of RF signals. They handle any RF input modulation format and provide 8 or 16 isolated outputs for further signal distribution.

- Supported types: 7703DA4A-RF, 7703DA4A-RF-LNB, 7703DA8A-RF, 7703DA8A-RF-LNB, 7703DA16-RF, 7703DA16-RF-LNB.

### Evertz 7880IRD-H264

The 7780IRD-H264-HD-LB is a hardware-based solution for demodulating digital DVB-S/S2 satellite signals and decoding these signals to SD or HD-SDI.

### Evertz 7700DA6

The 7700DA6 is a 1x6 SD-SDI distribution amplifier. The 7700DA6 series features an auto-equalized input with six reclocked outputs.

- Supported types: 7700DA6-HD-L or 7700DA6-L.

### Evertz 7780DMIPLB

The 7780DM-LB series is a hardware-based solution for demodulating digital DVB-S/S2 satellite signals. The 7780DM-LB series provides ASI output and an optional IP output.

- Supported types: 7780DM2-IP-LB, 7780DM2-IP-LB2, 7780DM-IP-LB2, 7780DM4-IP-LB, 7780DM2-IP-CA, 7780DM4-IP-CA.

### Evertz 7707VT8

The Evertz 7707VT8 is an 8-Channel SDI Fiber Transmitter.

- Supported types: 7707VT8.

### Evertz 7707VT8-HS

The Evertz 7707VT8-HS is an 8x 3G/HD/SDI/DVB-ASI Fiber Transmitter.

- Supported types: 7707VT-8-HS.

### Evertz 7707VR8-HS

The Evertz 7707VR8-HS is an 8x 3G/HD/SDI/DVB-ASI Fiber Receiver.

- Supported types: 7707VR-8-HS.

### Evertz BPXRF

The Evertz BPXRF protection switches provide automatic changeover functionality to provide bypass protection for RF signals.

- Supported types: 7703BPX-LB, 7703BPXA-LB, 7703BPX50-LB, 7703BPXA-LB-50, 7703BPX-IF, 7703BPXA-IF, or 7703BPX50-IF, where LB and IF denote the L-Band or IF Frequency type.

### Evertz 7708LR

The Evertz 7708LR cards accept a fiber optic input from a companion transmitter and provide an electrical output signal.

- Supported types: 7708LRA, 7708LR-H.

### Evertz 7708LT

The 7708LT card is a fiber optic transmitter for RF signals in the extended L-Band or wider frequency range. It accepts a single RF input on coaxial cable and provides a single output for optical transmission.

- Supported types: 7708LT, 7708LT-LNB, 7708LT-DWDM, 7708LT-DWDM-LNB.

### Evertz 7707OE

The Evertz 7707OE cards are optical-to-electrical and electrical-to-optical converters.

- Supported types: 7707EO-3G, 7707OE-3G, 7707OE-3G-H, 7707OE-3G-1, 7707OE-3G-H-1.

### Evertz 7780ASI-B2-DS3

The Evertz 7780ASI-B2-DS3 can transport up to 2 DVB-ASI signals, bi-directionally on a DS3/E3 circuit.

- Supported types: 780ASIB2-DS3/E3.

### Evertz 7703PA

The 7703PA series provide amplification of RF signals in the satellite extended L-Band range.

- Supported types: 7703PA, 7703PA-LNB, 7703PA-2, 7703PA-2-LNB, 7803PA-2-LNB2.

### Evertz 7881DEC2MP2HD

The 7881DEC2-MP2 is an MPEG-2 SD upgradable HD decoder card.

### Evertz 7700ACO2HD

The Evertz 7700ACO2HD is a dual HD/SD-SDI smart automatic changeover.

### Evertz 7812DCDA2Q

The Evertz 7812DCDA2Q is a dual-channel 3G/HD down-converting distribution amplifier.

### Evertz 7814UDX

The 7814UDX series are dual path broadcast-quality up/down/cross converters that convert between common SD/SMPTE 259M and HD/SMPTE 292M video signals.

### Evertz 7736CEM

The 7736CEM card is a serial digital-to-composite analog video converter.

- Supported cards: 7736CEM, 7736CEM-A4, 7736CEM-AES.

### Evertz 7700ACOHD

The 7700ACOHD card is an HD/SD SDI, 8-channel AES & RS-232/RS-422 automatic changeover.
