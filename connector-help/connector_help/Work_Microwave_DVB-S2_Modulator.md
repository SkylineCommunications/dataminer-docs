---
uid: Connector_help_Work_Microwave_DVB-S2_Modulator
---

# Work Microwave DVB-S2 Modulator

This connector polls status parameters and allows you to edit the configuration of older **Work Microwave Modulator DVB-S2** devices, similar to the connector **Work Microwave Modulator DVBCID/DVB2SX**.

The device is a DVB satellite modulator and includes a DVB-S/S2/S2X modulator with VHF-band (50 to 180 MHz) and/or L-band (950 to 2150 MHz) output. The unit consists of four main parts, a modulator module (DVB data in input and L-band modulated signal in output), an IF converter module (clock at VHF-band), a power supply and a front panel controller.

## About

The device is accessed via **SNMP**. The agent within the device is fully SNMPv1-compatible and responds to GET, GETNEXT and SET commands. If SNMPv2 is used, the device will also respond using SNMPv2. Traps are always v1. Control over the device will depend on the access type of SNMP parameters available in the Management Information Base (MIB).

This connector is compatible with "FMB" software units (front panel firmware starts with FMB).

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | Yes                 | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**    |
|------------------|--------------------------------|
| 1.0.0.x          | Front Panel Firmware: FMB0x.yz |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### Modulator Configuration

This page contains the parameters for the configuration of the modulator signal: **Signal** **Output**, **TX Frequency**, **TX Level**, **Symbol Rate**, **Data Rate**, **MODCOD**, **Roll**-**off**, **Slope** **Compensation** and **Spectrum** **Inversion**.

The **Automatic Disabled Polling** toggle button is also available on this page. If this button is set to enabled, the polling of the modulator configuration parameters will be automatically disabled when a "NO SUCH NAME" error is received.

In addition, the **Video Stream Configuration** page button provides access to the **DVB-S2 FEC Frame Length**, **Short BCH Code**, **Pilots**, **VCM/BB Frame Mode**, **PL Scrambling**, **TX Test Mode**, **Data Input**, **SPI Synchronization**, **Frame Type**, **TX Clock Synchronization**, **MPEG2-TS Packet Stuffing**, **Null Packet Deletion** and **Still Picture** settings. The still picture configuration is only effective when the picture is stored on the device. The TX frequency configuration depends on the frequency offset and the RF Min and Max limits. The configuration of the data rate will affect the symbol rate and vice versa.

The transport stream is MPEG. Between symbol rate and data rate, a strict relation exists, which depends on the type of MODCOD, pilots insertion mode and input frame length. The device automatically provides the required cross calculations by enabling and disabling forbidden configuration. Null packet insertion is always enabled if the transmit clock is set to *Internal*. In this configuration, the symbol rate is only referenced to the internal reference clock.

**DVB-S2 FEC Frame Length** is only relevant if one of the DVB-S2 modulation types is selected. *SHORT* is not allowed if the selected modulation is of type DVB-S2 and the FEC rate is 9/10. **Short BCH Code** is only relevant if one of the DVB-S2 modulation types is selected and the DVB-S2 FEC length is selected as *SHORT*. **Pilots** and **PL Scrambling** are only relevant if one of the DVB-S2 modulation types is selected.

### Monitor

This page allows you to monitor the **Temperature** (Front Panel, Modulator, Chip and Converter), the **Modulator** (Level IF Signal, Tune Voltage), the **Carrier** (Bandwidth, FIFO Fill Level) and the **PSU DC Voltages**.

### System Configuration

This page allows you to configure the system. The **State** of the device can be loaded or saved and **Autosave**, **Alarm Relay**, **External Mute Input** and **User Still Picture** can be toggled. **Banner** and **RF Min** and **Max** frequencies can be set. System Info is also available, displaying the **Name**, **Description**, **Date** and **Up Date.** Firmware info about **Front Panel**, **Main Module** and **FPGA** is also displayed.

The following page buttons are available on this page:

- **SNMP**: Displays the **Trap Sink Server** table, with up to 4 rows (one for each server), and information regarding the **TCP/UDP** ports and **Read**/**Write** **Community**.
- **Device States**: Displays a table with information related to the stored devices.
- **M&C Interface Settings**: Allows you to set up the M&C interface, with parameters such as **Multipoint Address**, **Interface Type**, **RS485 TX** and **RX Termination**, **Packet Delay**, **Baud Rate**, **IP Address**, **Subnet Mask** and **Gateway**. The page also displays the status of the **ASI**-**A** and **ASI**-**B** signals, **SPI interface** and **auto** **mode**.

With the **Factory** **Reset** button, you can reset the device to its factory status.

### Status

This page displays the **alarms** and **warnings** of the device, listing up to 32 parameters related to the status of the device.

The following page buttons provide access to additional information:

- **Stored Events**: Displays the history of events (up to 10 entries).
- **Stored Alarms**: Displays the history of alarms (up to 20 entries).

### Traps (from version 1.0.0.3 onwards)

Traps received from the device are displayed on this page in the **Traps** table. At the top of the page, you can choose whether traps are displayed in the table (*Add to Table*) or directly displayed in the Alarm Console (*Create Alarm*).

On the **Auto Clear** page, you can set up methods to automatically set limits on the number of rows in the Traps table.

### Web Interface

This page allows you to access to the web UI of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

From version **1.0.0.4** onwards, this connector supports the usage of DCF and can only be used on a DMA with **8.5.8.5** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).
