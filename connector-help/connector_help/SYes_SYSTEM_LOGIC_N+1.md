---
uid: Connector_help_SYes_SYSTEM_LOGIC_N+1
---

# SYes SYSTEM LOGIC N+1

The **SYes SYSTEM LOGIC N+1** connector monitors a Syes SYSTEM LOGIC N+1 system unit through **Simple Network Management Protocol (SNMP)**.

## About

The **SYes SYSTEM LOGIC N+1** connector polls relevant information from the device and allows the user to change its configuration.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community** **string**: The community string used when reading values from the device. The default value is *public.*
- **Set community string**: The community string used when setting values on the device. The default value is *private.*

## Usage

This connector has eight data display pages:

### General Page

This page shows the **System, OR Table**, and **SNMP** information for the device.

### Status Page

This page shows the **Status** of the device: **System Status, Transmitter Status, Reserve Transmitter Status**, etc.

Alarms can be set on these parameters. A toggle button to **Switch Mode** from *Auto* to *Manual* is also available.

### Commands Page

This page displays all the possible commands a user can give to the device: **Switch Mode, Reset, Save Options**, choice of **Main Transmitter**, **Reserve Transmitter**, etc.

### Transmitters Page

This page displays a tree view containing all relevant information for a given **transmitter**. This can be convenient in case all parameters need to be updated for a given transmitter.

### Reserve Page

This page displays a tree view containing all relevant information for a given **reserve transmitter**.

### Functional Page

This page displays several tables and parameters regarding the **functionality** of the given controller. It allows the user to configure the **swap options**.

### Management Page

This page contains information regarding each **transmitter** and **reserve transmitter**, with all their **configurable parameters**.

### Web Interface Page

This page displays the device **web interface**.

The client machine has to be able to access the device. If not, it will not be possible to open the web interface.
