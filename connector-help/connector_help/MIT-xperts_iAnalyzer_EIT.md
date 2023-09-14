---
uid: Connector_help_MIT-xperts_iAnalyzer_EIT
---

# MIT-xperts iAnalyzer EIT

This connector has been designed to monitor the MIT-xperts iAnalyzer EIT with SNMP.

## About

This device decodes and displays one or more input MPTS/SPTS, and especially analyzes the EIT/EPG data for potential problems and errors (overlapping events, incorrect packaging, timing issues, etc.).

## Installation and creation

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General page

The **General** page gives an overview of the state of the iAnalyzer.

### Services page

The **Services** page displays the **Service Table** and it has a page button to the **Service Faults** page for a more detailed overview of the service fault states.

### Webpage

The webpage of the device.
