---
uid: Connector_help_SVS_Telekom_AKS250
---

# SVS Telekom AKS250

## About

With this connector it is possible to monitor and command **SVS Telekom AKS250** devices with SNMP.

The different parameters from the device are displayed on multiple pages according to the subject of the parameters.

The connector implements all the different methods to move the antenna connected to the device.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host:** The polling IP of the device, e.g. *10.11.12.13*.

**SNMP Settings:**

- **Port number:** The port of the connected device, by default *161.*
- **Get community string:** The community string in order to read from the device. The default value is *public*.
- **Set community string:** The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

This page displays some general information such as:

- Azimuth, Elevation and Polarization angles and counter values
- Signal level
- Global system error indicator

### Antenna Page

This page displays antenna information such as:

- Antenna hardware limits
- Instant power applied to the 3 motors
- Mechanics detection
- Current moving states of the antenna

### Position/Jog Page

This page alows the user to move the antenna with different methods such as:

- Point to saved satellite
- Position antenna with angle values
- Position antenna with count values
- Peak to satellite on 3 axes
- Move antenna manually on 3 axes with adjustable speed

### Alarm Overview Page

This page shows all errors and warnings the SVS Telekom AKS250 can present in one overview.
