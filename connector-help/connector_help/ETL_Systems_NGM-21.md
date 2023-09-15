---
uid: Connector_help_ETL_Systems_NGM-21
---

# ETL Systems NGM-21

The **ETL Systems NGM-21** connector displays information related to the **ETL Systems NGM-21** device.

## About

This connector uses two interfaces to communicate with the NGM-21 device. The SNMP interface is used to retrieve information regarding the chassis temperature and the status of the fans, and the serial interface is used to execute the remaining commands.

## Creation

### SNMP

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *10.145.1.12*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

### Serial

**SERIAL Connection:**

- **Type of port:** TCP/IP.
- **IP address/host**: The polling IP or URL of the destination, e.g. *10145.1.12*.
- **IP port**: The port of the destination, e.g. *13000*.
- **Timeout of a single command:** 2500 ms (minimum).

## Usage

### Main View Page

This page contains the device matrix.

### General Page

This page displays generic parameters, such as:

- Version
- IP Address
- ...

### Alarm Page

This page displays the device status, such as temperatures, fan speeds, and communication state.

### Configuration Page

This page allows the user to configure the matrix size.
