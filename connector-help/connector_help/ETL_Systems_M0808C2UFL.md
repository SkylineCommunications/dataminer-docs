---
uid: Connector_help_ETL_Systems_M0808C2UFL
---

# ETL Systems M0808C2UFL

The **ETL Systems M0808C2UFL** is an 8x8 L-band matrix with dual redundant PSUs, a CPU and local control panel. Remote control is possible via a serial or Ethernet connection.

## About

With this connector, it is possible to manage general information about the device, and to modify the networking configuration and the matrix configuration itself. The connector also supports traps to detect alarms.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection**

- **IP address/host**: The polling IP of the device.

**SNMP Settings**

- **Port number:** The port of the connected device, by default *161*.
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

## Usage

Once created, the element can be used immediately. There are 5 pages available.

### Matrix

On this page, the device matrix can be configured, i.e. the wiring of inputs and outputs.

### General

This page contains the relevant information coming from the standard MIB-2, such as the location, system description, etc.

### Alarms

This page displays the alarms of the power supply units, alarms of the matrix itself and VTR-10 alarms. These alarms are detected through standard polling or receiving traps. The device sends traps every 5 seconds when one of the components is in alarm state, and stops when the component gets back to normal. The connector sets the alarm state when a trap arrives and checks 5 seconds later if the alarm status was cleared.

### Settings

On this page, you can configure the networking options and set who receives the traps issued by the device.

### Web Interface

This page displays the web interface of the device.
