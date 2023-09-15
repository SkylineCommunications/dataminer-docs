---
uid: Connector_help_International_Datacasting_IPE-4000
---

# International Datacasting IPE-4000

The **International Datacasting IPE-4000** connector is used as a link between IP networks and broadband DVB or ATSC networks.

## About

This connector can be used to monitor the network and control the IP Encapsulation.

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### System

This page displays the **Time** of the device and information on the device's hardware. Alarm monitoring and trending are possible, and are typically done on **Temperatures** and **Voltages.**

### Network

The **Data** and **M&C Network** are displayed separately on this page. The configuration of both networks is displayed (i.e. their **Speed** and **Duplex** mode), as well as the **Received** and **Sent** amount of **Bytes**, **Packets** and **Errors/Drops**.

### Encapsulation

On this page, you can change the settings of the **ASI Output**, **Program, Pid** and **Route**.
