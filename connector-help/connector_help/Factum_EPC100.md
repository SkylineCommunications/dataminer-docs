---
uid: Connector_help_Factum_EPC100
---

# Factum EPC100

The **Factum EPC100** connector displays information related to the **Factum EPC100 Controller** device.

## About

This connector uses an SNMP connection to communicate with the **Factum EPC100** device.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *10.145.1.12*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

## Usage

### General Page

This page displays status parameters such as the **Agent Version**, **System Contact**, etc.

### Status Page

This page displays the main status of the device.

### GPS Page

This page displays a table with device statuses.
