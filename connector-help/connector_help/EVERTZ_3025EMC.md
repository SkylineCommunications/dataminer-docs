---
uid: Connector_help_EVERTZ_3025EMC
---

# EVERTZ 3025EMC

The **Evertz 3025EMC** Master Control Switcher is a solution for facilities converting to SD, HD and 3Gb/s. Features of this platform include: bypass & emergency inputs, hot-swappable hardware, and redundant power supplies.

## About

This connector is used to monitor faults in the Evertz 3025EMC device. The information is retrieved via an **SNMP** connection.

## Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *10.145.1.12*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

## Usage

### Faults Page

The **Faults** page is the only page provided on this connector. It allows **Send Trap** configuration and **Fault Status** monitoring for each type of fault, designated by its **Fault Name**.
