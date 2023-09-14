---
uid: Connector_help_Harris_Spacetrack_4000E
---

# Harris Spacetrack 4000E

Building on the SpaceTrack 4000 platform, the SpaceTrack 4000E continues to serve offshore platforms, FPSOs, semi-submersibles, commercial maritime, cruise, survey and seismic vessels. The SpaceTrack 4000E series of antennas are fully IP-enabled and include a range of new features to enhance performance and lower cost of ownership.

## About

The **Harris Spacetrack 4000E** connector is intended to communicate with this device using the SNMP protocol.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**            |
|------------------|----------------------------------------|
| 1.0.0.x          | Harris CapRock One Aug 1 2015 20:06:24 |

## Installation and configuration

### Creation

SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Configuration of MIB

On the **General** page, there are two parameters that must be set in order to poll the correct OIDs: **Firmware Type** and **Version Type**. The following options are available:

- **Firmware Type**: *Old* + **Version Type**: *Old:* HCC-Spacetrack-4000e (these are the default values)
- **Firmware Type**: *Old* + **Version Type**: *New:* HCC-ST4000E-MIB
- **Firmware Type**: *Old* + **Version Type**: *Old:* 6-8-13 - HCC-ST4000E-MIB
- **Firmware Type**: *Old* + **Version Type**: *Old:* 3-3-17 - HCC-ST4000E-MIB
- **Firmware Type**: *Old* + **Version Type**: *Special:* Unknown MIB file

## Usage

### General

This is the default page of the connector. It displays general information about the device.

### Monitor Control

On this page, you can control the **Monitor settings**.

### ACU Status

This page contains a table with several **important Antenna Control Unit measurements**. Rows are added to the table every hour.

### Configuration

This page contains several settings similar to those available on the web interface of the device.

Via page buttons, settings and information related to the following aspects are available: **Antenna blocked zones**, **navigation**, **system errors**, **network topology**, **LNB** (Low-Noise Bock Converter), **AGC** (Automatic Gain Control), **Modem**, etc.

### Tracking

This page provides access to the **system tracking settings**. The tracking settings are generally best left to the control system to determine, and should therefore only be modified in exceptional circumstances.

### Acquisition

This page provides access to the **system acquisition settings**. The acquisition settings are used by the system to locate and lock onto the desired satellite.

### Satellite

On this page, you can set the target **satellite parameters** for a geosynchronous satellite.

### Host Platform

This page allows you to alter the vessel's position and heading. The vessel position and heading are used in the acquisition calculation. Vessel average speed is calculated based on the vessel's last positions.

### Servo

This page provides access to the **servo loop tuning variables**.

### System Mode

On this page, you can **control** the modes of **operation**.

### Status

This page displays several **real-time measurements**.

### Status Monitor ADT

This page displays several **real-time monitor** status measurements related to the **ADT Sensors**.

### Status Monitor ARS

This page displays several **real-time monitor** status measurements related to the **ARS Sensors**.

### Status Monitor

This page displays the remaining **real-time monitor status** measurements.

### Export GPS Trace

On this page, you can enable or disable the **GPS data export feature** (storing GPS locations in the database) and configure the corresponding settings.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
