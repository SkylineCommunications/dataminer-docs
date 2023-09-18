---
uid: Connector_help_Norkring_Modulation_Robot
---

# Norkring Modulation Robot

This connector is used to monitor a modulation robot and to set some configuration parameters.

## About

The connector communicates with the device through SNMP in order to retrieve sources and status information and to configure sources and authorizations.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host:** The polling IP of the device.
- **Device address:** Not required.

**SNMP Settings:**

- **Port number:** The port of the connected device, e.g. *161*.
- **Get community string:** The community string used when reading values from the device, e.g. *public*.
- **Set community string:** The community string used when setting values on the device, e.g. *private*.

## Usage

### General

On this page, you can choose a monitoring source (**Kies Monitoring Bron**), allow the selection of a remote emergency source (**Remote Noodbron Selectie**), and monitor and configure transmitters (**Zender**) through an SNMP table, with parameters such as the source selection \[**Kies Bron**\], source status \[**Status Bron 1/2**\], automaton status \[**Status Automaat**\] and automaton actions \[**Actie Automaat**\].
