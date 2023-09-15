---
uid: Connector_help_Axon_HDR07
---

# Axon HDR07

The **HDR07** is an HD/SD-SDI reclocking distribution amplifier.

## About

The Axon HDR07 connector makes it possible to monitor and control an Axon HDR07 card.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: The card number, e.g. *11.*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string needed to read from the device. The default value is *public*.
- **Set community string**: The community string needed to set to the device. The default value is *private.*

## Usage

### General page

This is the connector's only page. It provides an overview of the different information related to the card, and allows sets of certain parameters.
