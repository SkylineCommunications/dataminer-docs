---
uid: Connector_help_Allot_Service_Gateway_Sigma_E
---

# Allot Service Gateway Sigma E

The Allot Service Gateway Sigma E connector is used to retrieve network and status data. It analyzes the application, subscriber, device and network topology traffic, is designed for broadband environments and is able to monitor 4G and IPv6-based networks.

## About

The monitoring information is retrieved through SNMP. Polling is based on three SNMP tables from which all data are extracted and interpreted in several custom tables.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host:** The polling IP of the device, e.g. *10.11.15.2*.
- **Device address:** Not required.

**SNMP Settings:**

- **Port number:** The port of the connected device, e.g. *161*.
- **Get community string:** The community string used when reading values from the device, e.g. *v1v2Config*.
- **Set community string:** The community string used when setting values on the device, e.g. *private*.

## Usage

### General

On this page, you can find flow statistics such as **Rx Throughput \[PPS\], Dropped Frames, HTTP CDRS Files Exported Rate**, etc.

There are several page buttons displaying the main status information. The **Fans, Power Supply, Temperatures, Software Status** and **Hardware Status** page buttons respectively show the state of the **Fans, Power Supplies, Temperatures, Software** and **Hardware**. The **CPU, Memory** and **Storage** page buttons display the usage of the **CPU, Memory** and **Storage**.

### Connections

On this page, you can find the **CER Table**, the **Connections Table** and the **Active Subscriber Sessions Table,** which respectively display the **Connection Establishment Rate,** the **current live connections number** and the **number of active subscriber sessions** for the different slots.
