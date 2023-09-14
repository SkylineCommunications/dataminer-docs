---
uid: Connector_help_L-3_Communications_MPM-1000
---

# L-3 Communications MPM-1000

The MPM-1000 modem provides WIN-T and other users with the specialized IP SATCOM to keep highly mobile, dispersed, and remote users connected. Its Network Centric Waveform (NCW) reduces operational cost and supports the maximum number of IP users by providing efficient use of satellite bandwidth over military or commercial transponder satellites. It achieves this efficiency over satellites by using power-efficient turbo codec on all links with interleaved block lengths to accommodate IP encapsulation. Other features are low jitter, MAC Layer ARQ for assured delivery, a broad range of operating parameters with fine control resolution for EIRP, data rates, modulation, coding, and Direct Sequence Spreading (DSSS) on a burst-by-burst basis.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 4.95                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMPv2) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this connector has two sets of data pages. The first set allows you to configure parameters for the satellite, while the second allows you to configure waveform parameters. you can find more information about these pages below.

- **General**: Displays general system parameters for the MPM equipment. Several page buttons are available, which display information regarding the **Ethernet Switch**, **Serial Hub**, **Network Members**, and (if present) **Multiple MPM**.

- **System Alarms**: Displays the Current System Alarms Table and Alarm Configuration Table. A page button displays the IP address of the different **Trap Receivers**.

- **System Events**: Displays a table listing all system events on the equipment.

- **Converters**: Contains parameters for different types of converters (up and down). Page buttons provide access to parameters for **UpRF**, **DownRF**, **UpIMPCS** and **DownIMPCS** converters. This page also displays the different parameters for the Solid State Power Amplifier and the Frequency Standard.

- **Fan & Power Supply**: Displays the status of the fans and the power supply, along with the usage of RAM, Flash memory and CPU.

- **Antenna**: Allows you to configure antenna parameters. Page buttons are available to **Antenna Status**, **EIRP Density**, **Beacon**, and **Kiv-19 Module** subpages

- **Satellite**: Contains three tables that allow you to configure the different satellite parameters, i.e. the Satellite Configuration, Satellite Network, and Satellite Network Bandwidth Segment tables. Page buttons are available to the **Ku Satellite** and **GPS** subpages

- **Enhanced Tactical Satellite Processing Specification** (ETSSP) pages:

- **NSM Configuration**: Contains the Local Over Wire configuration and the RMUX1 Over Wire configuration. Page buttons provide access to the **Call**, **Timing Reference** and **Preliminary Setup** configuration.
  - **NSM Setup**: Allows you to configure port parameters. Also contains the **Port 3**, **Mux Setup**, **Mux Channels**, **DEMUX1 Setup** and **DEMUX1** **Channels** page buttons, which all provide access to configuration parameters.
  - **NSM Status**: Displays the status of the different NSM parameters. Two page buttons provide access to the **Configuration Transmission** and **Measurements** parameters.
  - **NSM Panel & Alarms**: Displays the status of the panel and alarm parameters.

- **165a (FDMA)**: Allows you to configure different parameters for the Modulation (Tx) and Demodulation (Rx).

- **Configuration**: Contains the Differentiated Services, Modulators, and Demodulators tables, as well as a page button to a **Settings** subpage that allows you to configure parameters such as DSSS, Transmit Level EIRP, Retransmission Requests, Automatic Network Control, etc.

- **Status & Commands**: Displays the Commands parameters that can be configured. A page button displays **Bit Status** parameters.

- **Notifications**: Contains a table for the following trap alarms:

- Login Request
  - Handover Request
  - Handover Assignment
  - Logout Request
  - Terminal Zeroide
  - Message Reception
  - Configuration Acknowledge
  - Protocol Status
  - Change over
  - Error Notification
  - Persistent Error.

- **Transec and SVOW**: Displays the parameters for the transit section of the Waveform branch, and the parameters for the Secure Voice Orderwire function. A page button displays the **I/F Extras** parameters such as Multiplex + 12 V (Input) and Multiplex +12 V (Output).

- **Slots**: Displays the Persistent Slot Table.

- **Statistics**: Displays statistics parameters. Contains page buttons to **Broadcast** and **Link Query** statistics parameters.
