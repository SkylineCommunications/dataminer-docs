---
uid: Connector_help_Newtec_HZ914
---

# Newtec HZ914

The Newtec HZ914 is a DVB-S2 satellite demodulator with up to 4 ASI outputs, designed for the primary distribution of terrestrial television and mobile television over satellite. This connector uses a serial connection to communicate with the device. It makes use of the RMCP communication protocol.

## About

### Version Info

| **Range** | **Key Features**                                                             | **Based on** | **System Impact** |
|-----------|------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x   | Initial version.                                                             | \-           | \-                |
| 1.6.63.x  | New firmware based on software version 6.63, software ID 6279.               | \-           | \-                |
| 1.1.0.x   | \- Implemented Cassandra compliancy. - Adapted to correct version numbering. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                  |
|-----------|-----------------------------------------|
| 1.0.0.x   | \-                                      |
| 1.6.63.x  | Software version 6.63, software ID 6279 |
| 1.1.0.x   | Software version 6.63, software ID 6279 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |
| 1.6.63.x  | No                  | No                      | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device. Default: *5933*.
  - **Bus address**: The bus address of the device. Default: *100*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

### General

On this page, you can find device status parameters, such as information on device modes and temperature. You can also perform a **Device Reset**, change the **Modulation Standard** and change the **Processing Mode**.

Via page buttons, you can access the following subpages:

- **Power Supply**: Displays power supply status information.
- **Display**: Contains settings that allow you to change the display of the device.
- **Test**: Allows you to perform a reset for test purposes.
- **Device Info**: Displays extra info about the device, the PPC Boot Version, the SNMP Daemon Version and information about the MC Module.
- **Security**
- **Serial Settings**: Allows you to configure the Serial Interface Type, Device Address and Serial Baudrate.
- **Ethernet Settings**: Displays the IP Address, IP Mask, Default Gateway and MAC Address of the device. You can also configure the Ethernet Interface and Output here.
- **External**: Allows you to configure the **LNB Power Supply**, the **IFL Spectrum Inversion** and **IFL LO** RF frequency.
- **HTTP**: Allows you to configure the TCP port used to consult the web interface.
- **SNMP**: Contains the SNMP trap settings.

### ASI

The information on this page and subpages is only available when the device is in ASI processing mode.

The page allows you to consult and change the **ASI ITF Redundancy**. You can also view other ASI status information: Active ASI ITF, Switchover Count, Active Inputs and the Output Rate, the PCR Rate and the Buffer Level of the four TX monitors.

For each ASI interface, a subpage is available with TX and TG settings.

### Ethernet

The information on this page and its subpages is only available when the device is in Ethernet processing mode.

The page allows you to consult and change Ethernet settings such as MTU, Interface, Unit Redundancy, VRRP, Proxy ARP, Baseband, Config and Software settings.

The following popup pages are available:

- **S2BBFoE RX**
- **MPEGoIP**
- **XPE Statistics**
- **ULE Statistics**
- **MPE Statistics**
- **Datapiping Statistics**
- **Packet Monitor**
- **Packet Generator**
- **VLAN** Statistics
- **Nt2SBBFoE Rx**: settings, **Instances** and **Current** and previous **Interval Statistics**.
- **Demod. Rx Filters**
- **IP Interface**
- **Link**
- **IP Encap - Decap**
- **IP Network**

### Demodulator

This page contains DVB-S2 demodulation settings such as Input Selection, Outdoor Power Control, Receive Frequency, Interface and Symbol Rate, RX Spectrum Inversion, Coding And Modulation, Pilot Detection, FEC Frame Type, ISI and PLS.

It also displays information and statistics related to Receive Level, Power Spectral Density, Es/No and Eb/No, CRC Errors, Carrier Frequency, Symbol Rate, FEC, Bandwidth and AGC.

### Alarms

This page contains alarm status information like the **Actual** and **Memorized** **Alarm Status**, as well as **Current Alarms Status Flags**.

### Web Interface

This page displays the web interface of the device, using the web interface port defined with the **HTTP Port** parameter on the General \> HTTP page. The client machine has to be able to access the device. If not, it will not be possible to open the web interface.
