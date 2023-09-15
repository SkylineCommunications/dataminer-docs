---
uid: Connector_help_Imagine_Communications_Selenio_FS1
---

# Imagine Communications Selenio FS1

The **Imagine Communications Selenio FS1** is a type of card that can be slotted into a Selenio chassis. This connector contains a full overview of all the data available in such a card. Specifically, it contains information regarding audio, video and data processing and filtering.

## About

This connector displays information on different pages, described in the **Usage** section of this document.

The **versioning** for the connector is specifically engineered to tie in with the firmware version of the card the connector supports. It uses the following format: X.X.X.Y, with X.X.X being the firmware version of the card and .Y the specific connector iteration for this firmware. For example, *5.0.28.2* means the connector is the second iteration for firmware *5.0.28.*

### Version Info

| **Range** | **Description**                                                                                                                               | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| \<10.0.0.x       | **\[Main\]** The **versioning** of the connector is specifically engineered to tie in with the firmware version of the card the connector supports. | No                  | Yes                     |
| 10.0.0.x         | Replaced the "dynamic snmp get" with "dynamicSnmpGet="true"" under parameter type tag.                                                        | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                                                                                                                   |
|------------------|-----------------------------------------------------------------------------------------------------------------------------------------------|
| \<10.0.0.x       | **\[Main\]** The **versioning** of the connector is specifically engineered to tie in with the firmware version of the card the connector supports. |
| 10.0.0.x         | Requires controller firmware "S/W=7.0-38, H/W= rev 02" or higher and will not work with older firmware.                                       |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Slot number where the card is plugged in. Range *1-14.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string needed to read from the device. The default value is *public*.
- **Set community string**: The community string needed to set to the device. The default value is *public.*

### Timing

All data gets retrieved from the device in two ways.

1. **Timers**

   - Slow timer that triggers every hour and retrieves non-essential and configurable parameters.
   - Medium timer that triggers every 15 minutes and retrieves status parameters.
   - Fast timer that triggers every 3 seconds and retrieves slot information (state, temperature, protection).

1. **Dirty changes**

   - Every 3 seconds, a check is done for any changed configurable values. If such a change is detected, the new value is retrieved and instantly updated in the element. If the change is the cell of a table, the complete table is refreshed. After a change is detected, the check is boosted and performed every 0.5 seconds, until no more changes are detected.

## Usage

The connector contains different pages divided into several sections using separators.

### General section

This section contains the following pages:

- **General**: Contains information such as the slot number, state, temperature, protection status and chassis IP.
- **Alarming**: Contains a table with all the possible alarms that the card can generate and its current state (*Active priority 0-\>10* or *Inactive*).

### Video section

This section contains the following pages:

- **Video Input**: General video parameters, including **Status**, **EDH-CRC-SQM 1**, **EDH-CRC-SQM 2**, **Input Routing**, **Auto Routing** and **VEX EDH-CRC.**
- **Processing Channel 1 and 2:** Includes **Video TSG-OSD**, **AFD-VI-WSS Processing**, **Video Proc Amp and Color Corrector** and **Logo.**
- **Reference**: Information concerning **Reference Standard, Locks** and **DARS Status**.
- **Video Output and Routing**: General information. Also contains a subpage with VEX parameters and multiple pages to define the VBI setup.
- **Composite Input Control**: Additional decoding options such as **3D Comb Decoding**.

### Misc Section

This section contains miscellaneous parameters such as **Preset data**, **Reset Parameters**, **versioning**, **licensing** and **power save** parameters.

### Control section

This section contains the following pages:

- **Serial:** Control information concerning Serial 1 and Serial 2.
- **GPI:** GPI Out 1-\>4 statuses.

### Data section

This section contains the following pages:

- **Data DMB 1 & 2:** DMB parameters concerning **VITC**, **WSS**, **Brandnet**, **RP196**, **LTC**, **CC/TT Present** and **ARC Codes.**
- **Data EMB 1 & 2:** EMB parameters concerning **ATC**, **RP196**, **ARC**, **AFD**, **VI**, **WSS**, **Brandnet** and **ARIB.**
- **VBI 1 and 2:** Deletion of VBI Lines.

### Audio Section

This section contains the following pages:

- **Audio IO Assignment:** Data concerning **AES** and **Exp Analog Control.**
- **ProcAmp:** Contains subpages concerning data for the **AES**, **Exp** and **EMB Gain**, **Invert**, **Mute** and **Word Length.**
- **Input Control and Status:** Lists data for the **DMB**, **AES**, **Exp Status** and **Bit.**
- **De-embedding:** De-embedding data for groups 1 to 4 on both DMBs.
- **Input Delay and Sync: DMB**, **AES**, **Exp** and **AAP** information.
- **Audio TSG:** Test tone configuration.
- **Embedding**: Embedder 1 and 2 control and status.
- **Output Routing and Delay:** Format, EMB 1 routing, AES routing, Exp routing and delay.
- **Advanced Audio Processing:** Shows **AAP Routing**, **Gain** and **Invert** data.
- **AAP 1-\>4 Configuration:** Configuration for the **DTS Neural Upmix**, **Downmix**, **Multimerge** and **Loudness (Ctrl 1-\>4)** and for the **Dolby E** and **Dolby Digital Encoders/Decoders**. Also contains **AAP Internal Metadata**.
- **Audio MetaData:** Settings such as **Bitstream modes**, **Program Select**, **Ameta Configuration**, **Coding Modes**, **Mix Levels** and different **filters** (lowpass, highpass, etc.).
