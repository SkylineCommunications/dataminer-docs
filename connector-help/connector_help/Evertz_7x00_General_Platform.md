---
uid: Connector_help_Evertz_7x00_General_Platform
---

# Evertz 7x00 General Platform

The **Evertz 7x00 General Platform** connector is used to monitor and control an Evertz chassis containing different Evertz 7700/7800 series cards.

## About

The chassis must include an **Evertz 7700-FC, Evertz 7800-FC, or Evertz 7801-FC** card in order to be functional. Data about the location of other cards is polled from this card. The Evertz 7700-FC/7800-FC/7801-FC is placed in slot 1; other cards are inserted into slots 2 to 15. A DVE will be created for each (supported) card. Data is polled via **SNMP**. Traps are supported to reduce the amount of polling. When a trap is received, the corresponding parameter is polled again to update its value.

### Version Info

| **Range**            | **Description**                                                                                                                                                                                                                               | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version.                                                                                                                                                                                                                              | No                  | Yes                     |
| 1.0.1.x              | Refactored version.                                                                                                                                                                                                                           | No                  | Yes                     |
| 1.0.2.x              | Based on 1.0.1.11. Output Stream Column in Output Stream Table and Send Trap Column in Demod Fault Table have been updated to display the correct information for 7780DM-LB card. **Old trend and alarm data will be lost for these tables.** | No                  | Yes                     |
| 1.0.4.x              | Based on 1.0.3.1.                                                                                                                                                                                                                             | No                  | Yes                     |
| 1.0.5.x \[SLC Main\] | Based on 1.0.4.12.                                                                                                                                                                                                                            | No                  | Yes                     |

### Product Info

| **Range** | **Supported Firmware**       |
|-----------|------------------------------|
| 1.0.0.x   | Unknown                      |
| 1.0.1.x   | Unknown                      |
| 1.0.2.x   | 7700FC \| 7800FC \| 7801FC   |
| 1.0.4.x   | Software Build: 2.7 Build 18 |
| 1.0.5.x   | Software Build: 2.7 Build 18 |

### Exported connectors

Details about the supported cards can be found at the end of this document.

| **Exported Connector**                                                                                                     | **Description**                                                                                                                                                               |
|---------------------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Evertz 7x00 General Platform - 7700R2X2-HD                                                                                | Used for the 7700R2X2-HD module.                                                                                                                                              |
| Evertz 7x00 General Platform - 7700DA7                                                                                    | Used for the 7700DA7-HD and 7700DA7 types.                                                                                                                                    |
| Evertz 7x00 General Platform - SWPBRF7700                                                                                 | Used for the SWRF87703, SWRF167703, SWRF16A7703, SWRF16B7703, SWRF8B7703 and SWRF47703 types.                                                                                 |
| Evertz 7x00 General Platform - 7880IPASIIP                                                                                | Used for the 7880IPASIIP module.                                                                                                                                              |
| Evertz 7x00 General Platform - 7703DA-RFA                                                                                 | Used for the 7703DA4A-RF, 7703DA4A-RF-LNB, 7703DA8A-RF, 7703DA8A-RF-LNB, 7703DA16-RF, and 7703DA16-RF-LNB types.                                                              |
| Evertz 7x00 General Platform - 7880IRD-H264                                                                               | Used for the 7780IRD-H264-HD-LB module.                                                                                                                                       |
| Evertz 7x00 General Platform - 7700DA6                                                                                    | Used for the 7700DA6-HD-L and 7700DA6-L types.                                                                                                                                |
| Evertz 7x00 General Platform - 7780DMIPLB                                                                                 | Used for the 7780DM2-IP-LB, 7780DM2-IP-LB2, 7780DM-IP-LB2, 7780DM2-IP-CA and 7780DM4-IP-CA types.                                                                             |
| Evertz 7x00 General Platform - 7707VT8                                                                                    | Used for the 7707VT8 module.                                                                                                                                                  |
| Evertz 7x00 General Platform - 7707VT8-HS                                                                                 | Used for the 7707VT-8-HS module.                                                                                                                                              |
| Evertz 7x00 General Platform - 7707VR8-HS                                                                                 | Used for the 7707VR-8-HS module.                                                                                                                                              |
| Evertz 7x00 General Platform - BPXRF                                                                                      | Used for the 7703BPX-LB, 7703BPXA-LB, 7703BPX50-LB, 7703BPXA-LB-50, 7703BPX-IF, 7703BPXA-IF, and 7703BPX50-IF types (where LB and IF denote the L-band or IF frequency type). |
| Evertz 7x00 General Platform - 7708LR                                                                                     | Used for the 7708LRA and 7708LR-H types.                                                                                                                                      |
| Evertz 7x00 General Platform - 7708LT                                                                                     | Used for the 7708LT, 7708LT-LNB, 7708LT-DWDM and 7708LT-DWDM-LNB types.                                                                                                       |
| Evertz 7x00 General Platform - 7707OE                                                                                     | Used for the 7707EO-3G, 7707OE-3G, 7707OE-3G-H, 7707OE-3G-1 and 7707OE-3G-H-1 types.                                                                                          |
| Evertz 7x00 General Platform - 7780ASI-B2-DS3                                                                             | Used for the 780ASIB2-DS3/E3 module.                                                                                                                                          |
| Evertz 7x00 General Platform - 7703PA                                                                                     | Used for the 7703PA, 7703PA-LNB, 7703PA-2, 7703PA-2-LNB and 7803PA-2-LNB2 types.                                                                                              |
| Evertz 7x00 General Platform - 7881DEC2MP2HD                                                                              | Used for the 7881DEC2-MP2 module.                                                                                                                                             |
| Evertz 7x00 General Platform - 7700ACO2HD                                                                                 | Used for the 7700ACO2HD module.                                                                                                                                               |
| Evertz 7x00 General Platform - 7812DCDA2Q                                                                                 | Used for the 7812DCDA2Q module.                                                                                                                                               |
| Evertz 7x00 General Platform - 7814UDX                                                                                    | Used for the 7814UDX module.                                                                                                                                                  |
| Evertz 7x00 General Platform - 7736CDM                                                                                    | Used for the 7736CDM-A4 and 7736CDM-AES types.                                                                                                                                |
| Evertz 7x00 General Platform - 7736CEM                                                                                    | Used for the 7736CEM, 7736CEM-A4 and 7736CEM-AES types.                                                                                                                       |
| Evertz 7x00 General Platform - 7700ACOHD                                                                                  | Used for the 7700ACO-HD module.                                                                                                                                               |
| Evertz 7x00 General Platform - 7807LR2                                                                                    | Used for the 7807LR-2 and 7807LR-2-H module.                                                                                                                                  |
| Evertz 7x00 General Platform - 7707ET                                                                                     | Used for the 7707ET module.                                                                                                                                                   |
| Evertz 7x00 General Platform - 7712UCHD                                                                                   | Used for the 7712UCHD module.                                                                                                                                                 |
| Evertz 7x00 General Platform - 7700DA7-3G                                                                                 | Used for the 7700DA7-3G module.                                                                                                                                               |
| Evertz 7x00 General Platform - 7807LT2                                                                                    | Used for the 7807LT2 module.                                                                                                                                                  |
| Evertz 7x00 General Platform - 7707EO (DA2EOSD)                                                                           | Used for the 7707EO module a.k.a. DA2EOSD (product name).                                                                                                                     |
| Evertz 7x00 General Platform - 7707OE (DA2OESD)                                                                           | Used for the 7707OE module a.k.a. DA2OESD (product name).                                                                                                                     |
| Evertz 7x00 General Platform - 7746FSHD                                                                                   | User for the 7746FSxxxx modules.                                                                                                                                              |
| Evertz 7x00 General Platform - 7781DEC2MP2HD                                                                              | Used for 7781DEC2MP2HD module.                                                                                                                                                |
| Evertz 7x00 General Platform - 7707VR8                                                                                    | Used for 7707VR8 module.                                                                                                                                                      |
| Evertz 7x00 General Platform - 7782DECH264                                                                                | Used for 7782DECH264 module.                                                                                                                                                  |
| Evertz 7x00 General Platform - 7890MG                                                                                     | Used for 7890MG module.                                                                                                                                                       |
| Evertz 7x00 General Platform - 7707VT4HS                                                                                  | User for 7707VT4HS module.                                                                                                                                                    |
| Evertz 7x00 General Platform - 7707VT4                                                                                    | Used for 7707VT4 module.                                                                                                                                                      |
| Evertz 7x00 General Platform - 7707VR4HS                                                                                  | Used for 7707VR4HS module.                                                                                                                                                    |
| Evertz 7x00 General Platform - ENC7882H264HDFC                                                                            | Used for ENC7882H264HDFC module.                                                                                                                                              |
| [Evertz 7x00 General Platform - 7800R4X23G](xref:Connector_help_Evertz_7x00_General_Platform_-_7800R4X23G)      | Used for 7800R4X23G module.                                                                                                                                                   |
| [Evertz 7x00 General Platform - 7812UDXD](xref:Connector_help_Evertz_7x00_General_Platform_-_7812UDXD)          | Used for the 7812UDXD module.                                                                                                                                                 |
| [Evertz 7x00 General Platform - 746FSEAES8HD](xref:Connector_help_Evertz_7x00_General_Platform_-_7746FSEAES8HD) | Used for the 746FS-EAES8-HD module.                                                                                                                                           |
| [Evertz 7x00 General platform - 7882DM-SAT](xref:Connector_help_Evertz_7x00_General_platform_-_7882DM-SAT)      | Used for the 7882DM-SAT module.                                                                                                                                               |
| [Evertz 7x00 General Platform - 7707IFTA](xref:Connector_help_Evertz_7x00_General_Platform_-_7707IFTA)          | Used for the 7707IFTA module - 7707LT card family.                                                                                                                            |
| [Evertz 7x00 General Platform - 7707IFRA](xref:Connector_help_Evertz_7x00_General_Platform_-_7707IFRA)          | Used for the 7707IFRA module - 7707RT card family.                                                                                                                            |

## Configuration

### Connections

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Connection:

- **IP address/host:** The polling IP of the device, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number:** The port of the connected device, by default *161*.
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

## Usage

This connector displays information about the Frame Controller (**Evertz 7700-FC/Evertz 7800-FC**) and the inserted cards.

### Input Cards

This page lists all the modules embedded in the chassis and their corresponding slots. If cards have been changed, press the **Refresh Cards** button to see the changes immediately. If you activate the **Automatically Delete Offline Rows** toggle button, cards that get removed from the frame will not be moved to the Input Cards \[DEL\] page.

### Traps Logging

The connector can log traps directly into the database for all cards that have the **Log Traps** column set to enabled in the **Input Cards** table. These rows will **expire after one year**.

### General

This page displays general parameters for the **Evertz 7700-FC/Evertz 7800-FC** controller, such as the **Temperature**, **Power Supply**, etc.

### SNMP Config

On this page, you can configure the **SNMP** agent: the **trap** destination, the communities, etc.

### License (range 1.0.2.x only)

This page displays information and settings related to the licensing for the different supported cards.

In the **Card License Table**, the main parameters influencing the license status of a card are displayed:

- **Card Name:** The names of the supported cards.
- **Status:** The status of the license for each specific card (*Unknown* (default), *Installed* or *Not Installed*).
- **Polling State:** The polling state of each card (*Enabled* (default) or *Disabled*).

The **Card License Table** is provisioned based on data stored in a **CSV file** in the following location: *C:\Skyline DataMiner\Documents\DMA_COMMON_DOCUMENTS\Protocols\Evertz 7x00 General Platform\License\ProductLicenseStatus.csv*.

This file contains the following headers:

- **Product Name**: The name of the card.
- **License Status**: Either *Installed* or *Not Installed*.

Below the header, the data for the targeted cards should be entered.

If this file is not found or if information regarding a specific card is not present, the default values will be applied to the parameters in the table.

The **License** page also contains the **Enforce License Check button**, which enables/disables the enforcement of license checks throughout the connector:

- **Disabled:** All card types will be polled.
- **Enabled:** Only card types of which the Status is *Installed* or *Unknown* and the Polling State is *Enabled* will be polled.

Finally, the **Refresh button** can be used to update the contents of the Card License Table with the contents from the source file.

## Supported cards

### Evertz 7700R2X2-HD

The 7700R2X2-HD module has two SD/HD-compatible input signals (program and backup) that support different input video formats. This module also provides three reclocked primary outputs, and one reclocked backup output.

- Supported types: 7700R2x2-HD.

### Evertz 7700DA7

The 7700DA7 series distribution amplifier features an auto-equalized input with seven reclocked outputs.

- Supported types: 7700DA7-HD or 7700DA7.

### Evertz SWPBRF7700

The Evertz SWBRF is a switch router for RF streams.

- Supported types: SWRF87703, SWRF167703, SWRF16A7703, SWRF16B7703, SWRF8B7703, SWRF47703.

### Evertz 7880IPASIIP

The 7880IP-ASI-IP is a complete hardware-based solution to transform ASI to IP and IP to ASI. The 7880IP-ASI-IP can also regenerate IP from IP input with different settings and add FEC.

### Evertz 7703DA-RFA

The 7703DA-RF active splitters provide amplification and distribution of RF signals. They handle any RF input modulation format and provide 8 or 16 isolated outputs for further signal distribution.

- Supported types: 7703DA4A-RF, 7703DA4A-RF-LNB, 7703DA8A-RF, 7703DA8A-RF-LNB, 7703DA16-RF, 7703DA16-RF-LNB.

### Evertz 7880IRD-H264

The 7780IRD-H264-HD-LB is a hardware-based solution for the demodulating of digital DVB-S/S2 satellite signals and the decoding of these signals to SD or HD-SDI.

### Evertz 7700DA6

The 7700DA6 is a 1x6 SD-SDI distribution amplifier. The 7700DA6 series features an auto-equalized input with six reclocked outputs.

- Supported types: 7700DA6-HD-L or 7700DA6-L.

### Evertz 7780DMIPLB

The 7780DM-LB series is a hardware-based solution for demodulating digital DVB-S/S2 satellite signals. The 7780DM-LB series provides ASI output and an optional IP output.

- Supported types: 7780DM2-IP-LB, 7780DM2-IP-LB2, 7780DM-IP-LB2, 7780DM2-IP-CA, 7780DM4-IP-CA.

### Evertz 7707VT8

The Evertz 7707VT8 is an 8-channel SDI fiber transmitter.

- Supported types: 7707VT8.

### Evertz 7707VT8-HS

The Evertz 7707VT8-HS is an 8x 3G/HD/SDI/DVB-ASI fiber transmitter.

- Supported types: 7707VT-8-HS.

### Evertz 7707VR8-HS

The Evertz 7707VR8-HS is an 8x 3G/HD/SDI/DVB-ASI fiber receiver.

- Supported types: 7707VR-8-HS.

### Evertz BPXRF

The Evertz BPXRF protection switches provide automatic changeover functionality to provide bypass protection for RF signals.

- Supported types: 7703BPX-LB, 7703BPXA-LB, 7703BPX50-LB, 7703BPXA-LB-50, 7703BPX-IF, 7703BPXA-IF, or 7703BPX50-IF, where LB and IF denote the L-band or IF frequency type.

### Evertz 7708LR

The Evertz 7708LR cards accept a fiber-optic input from a companion transmitter and provide an electrical output signal.

- Supported types: 7708LRA, 7708LR-H.

### Evertz 7708LT

The 7708LT card is a fiber-optic transmitter for RF signals in the extended L-band or wider frequency range. It accepts a single RF input on coaxial cable and provides a single output for optical transmission.

- Supported types: 7708LT, 7708LT-LNB, 7708LT-DWDM, 7708LT-DWDM-LNB.

### Evertz 7707OE

The Evertz 7707OE cards are optical-to-electrical and electrical-to-optical converters.

- Supported types: 7707EO-3G, 7707OE-3G, 7707OE-3G-H, 7707OE-3G-1, 7707OE-3G-H-1.

### Evertz 7780ASI-B2-DS3

The Evertz 7780ASI-B2-DS3 can transport up to 2 DVB-ASI signals, bi-directionally on a DS3/E3 circuit.

- Supported types: 780ASIB2-DS3/E3.

### Evertz 7703PA

The 7703PA series provides amplification of RF signals in the satellite-extended L-band range.

- Supported types: 7703PA, 7703PA-LNB, 7703PA-2, 7703PA-2-LNB, 7803PA-2-LNB2.

### Evertz 7881DEC2MP2HD

The 7881DEC2-MP2 is an MPEG-2 SD upgradable HD decoder card.

### Evertz 7781DEC2MP2HD

The 7781DEC2-MP2 is an MPEG-2 decoder card.

### Evertz 7700ACO2HD

The Evertz 7700ACO2HD is a dual HD/SD-SDI smart automatic changeover.

### Evertz 7812DCDA2Q

The Evertz 7812DCDA2Q is a dual-channel 3G/HD down-converting distribution amplifier.

### Evertz 7814UDX

The 7814UDX series are dual-path broadcast-quality up-/down-/cross-converters that convert between common SD/SMPTE 259M and HD/SMPTE 292M video signals.

### Evertz 7736CDM

The 7736CDM card is a composite analog video to serial digital video converter.

- Supported cards: 7736CDM-A4 and 7736CDM-AES.

### Evertz 7736CEM

The 7736CEM card is a serial digital to composite analog video converter.

- Supported cards: 7736CEM, 7736CEM-A4, 7736CEM-AES.

### Evertz 7700ACOHD

The 7700ACOHD card is an HD/SD SDI, 8-channel AES & RS-232/RS-422 automatic changeover.

### Evertz 7807LR2

The Evertz 7807LR2 cards are dual fiber-optic receivers for RF signals in the extended L-band or wider frequency range.

- Supported types: 7807LR-2 & 7807LR-2-H.

### Evertz 7707ET

The Evertz 7707ET card is a VistaLINKr-capable Ethernet fiber transceiver that provides an economical method of transmitting two 10BaseT Ethernet channels or one 100Base-TX Ethernet channel over optical fiber.

### Evertz 7712UCHD

The 7712UCHD (7712UDX-AES8-HD) card is a broadcast-quality up-/down-/cross-converter that converts between common SD/SMPTE ST 259 and HD/SMPTE ST 292-1 video signals.

### Evertz 7700DA7-3G

The Evertz 7700DA7-3G reclocking distribution amplifiers provide inexpensive distribution of SMPTE ST 424, ST 292-1 and SMPTE ST 259-1 serial digital video signals at rates of 3 GB/s, 1.5 GB/s and 270 MB/s. The DA supports all other SMPTE ST 344-1, SMPTE ST 259-1, SMPTE ST310-1 and DVB-ASI data rates in a non-reclocked mode (540 MB/s, 360 MB/s, 143 MB/s, and 19.4 MB/s).

### Evertz 7707EO (DA2EOSD)

The Evertz 7707EO is an electrical-optical converter. Its product name inside the General Platform is DA2EOSD and the VistaLink document refers to it as FIBEREO.

### Evertz 7707OE (DA2OESD)

The Evertz 7707OE is an optical-electrical converter. Its product name inside the General Platform is DA2OESD and the VistaLink document refers to it as FIBEROE.

### Evertz 7746FSHD

The Evertz 7746FSHD is a frame synchronizer. Its product name inside the General Platform is 7746FSHD.

### Evertz 7807LT2

The 7807LT-2 is a dual fiber-optic transmitter for RF signals in the extended L-band or wider frequency range. It accepts two RF inputs from coaxial cable and provides two outputs for optical transmission. An RF monitor output is provided for each input, which offers a convenient means of obtaining peak satellite signal strength, or additional signal distribution, with two optical transmitters per single-slot card.

Individual monitoring and control is provided for each signal path. Gain may be adjusted manually or managed automatically via AGC. Incoming RF signal strength, LNB current and other data are relayed over the fiber outputs for monitoring at the receiver side through SNMP. 13/18 V DC selectable LNB power with 22 kHz tone is also provided on each RF input.

### Evertz 7707VR8

The 7707VR8 is an 8x SDI/ASI fiber receiver.

### Evertz 7782DECH264

The 7782DEC-H264HD-IPASI is a professional high-quality 3G/HD/SD-SDI H.264/MPEG-2 decoder platform. It offers high-end decoding support for both MPEG-2 and H.264/AVC, optionally up to 4:2:2 10-bit.

### Evertz 7890MG

The 7890MG-10GE2 is part of the Evertz family of IP Gateway products, which use GE and 10GE networks for video and data transport. 7890MG-10GE2 provides up to 10x bi-directional access interfaces, 8x auto-sensed ASI/SD/HD/3G/GE and 2x GE/10GE data ports. To meet SLA requirements, each video interface port can also provide automatic, hitless switching between the dual links. In the event of failure or errors of one link, continuity of service remains uninterrupted.

### Evertz 7707VT4HS

Single-card TDM multiplexer for two HD-SDI signals, or one HD-SDI signal and three SDI/DVB-ASI signals, or four SDI/DVB-ASI signals.

### Evertz 7707VT4

Single-card TDM multiplexer for four synchronous or asynchronous 270 Mb/s SDI, SDTi or DVB-ASI video signals.

### Evertz ENC7882H264HDFC

The 7882DEC-H264HD-IPASI is a professional high-quality 2x HD/SD-SDI 1x H.264/MPEG-2 encoder platform. It offers MPEG-2 and H.264 (MPEG-4 Part 10) user-configurable video compression at up to 10-bit 4:2:2 resolution.

### Evertz 7800R4X23G

The 7800R4X23G is a Smart By-Pass protection router.

### Evertz 7812UDXD

The 7812UDXD is a broadcast-quality up-/down-/cross-converter that converts between SD/SMPTE ST 259 and HD/SMPTE ST 292-1 video signals.

### Evertz 7707IFTA

The 7707IFTA is a VistaLink Pro capable fiber-optic transmitter for 70/140 MHz IF signals. The 7707IFTA accepts one 70/140 MHz coaxial input and provides a fiber-optic output signal at 1310 nm, 1550 nm, CWDM, or DWDM wavelengths. An additional electrical output is also provided for monitoring or further signal distribution. Monitoring and control of card status and parameters is provided locally at the card edge and remotely via VistaLink Pro.

### Evertz 7707IFRA

The 7707IFRA is a VistaLink Pro capable fiber-optic receiver for 70/140 MHz IF signals. The 7707IFRA accepts a fiber-optic input from the companion 7707IFTA and provides two 70/140 MHz IF output signals. Monitoring and control of card status and parameters is provided locally at the card edge and remotely via VistaLink Pro capability.
