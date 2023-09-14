---
uid: Connector_help_Rohde_Schwarz_NetCCU800_FM
---

# Rohde Schwarz NetCCU800 FM

This connector is developed for devices such as the **Rohde Schwarz NetCCU800 FM**. It polls several SNMP parameters and displays them on different pages. It also allows the user to configure certain settings. Traps are intercepted to update program and status information.

## About

With three timers, all the SNMP parameters are polled and displayed on several pages. **Traps** are used to update parameters on the **Program** and **Switch Over Unit** pages. For each transmitter, a DVE is created with transmitter-specific parameters.

## Installation and configuration

### Creation

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.17.83.71*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

The main element has five pages:

- **General**: General device information, as well as settings for traps, NTP server and software updates.
- **Switch Over Unit**: Status parameters and settings for the switchover unit.
- **Program**: The Program Table.
- **Transmiter Overview**: A table with an entry for each connected transmitter.
- **Web Interface**: The web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

Each DVE has the following pages:

- **Transmitter Status**: Status information of the transmitter.
- **Exciter Input**: Exciter input status and measurement information.
- **Exciter Modulation**: Modulation data.
- **Input Analog Status**: The Input Analog Status Table.
