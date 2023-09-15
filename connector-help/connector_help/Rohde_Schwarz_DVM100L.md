---
uid: Connector_help_Rohde_Schwarz_DVM100L
---

# Rohde Schwarz DVM100L

The Rohde Schwarz DVM100L is a device used to monitor digital TV distribution and contribution networks, including headend applications.

## About

This connector connects to the DVM100L and allows the configuration and monitoring of all streams, services and PIDs.

## Installation and configuration

### Creation

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### Tree Overview

The **tree overview** on this page is the most important part of the connector. It provides a clear overview of all the **analyzers, ports, services and their PIDs**. Specifically of importance are the different **max and min bitrates.**

### General

This page displays default parameters concerning the **system and its firmware.**

### Analyzer, Transport Stream, Service, PIDs

These pages display the same content as the **tree overview**, except in table format.

### DVB-T

On this page, you can configure and monitor all **DVB-T type ports**, including their **Center Frequency**, **Bandwidth**, **Frequency Offset**, etc.

### ETR 101 290

This page provides **priority alarming** with **3 different levels and extended checks**. This data is available for each port and consists among others of the Sync Loss, CRC Error, Bit Rate Error, etc. The data is filled in via **traps** received from the device.

### Config Monitoring Section

The **Config Monitoring section** consists of 8 different pages, each allowing the configuration and monitoring of their respective subjects. For every table in this section, polling can individually be enabled or disabled.

Note that two of the tables, **Config Alarm Table** and **Bit Rate Limits Table**, are extremely large, and polling of these tables is therefore by default disabled. Polling these large tables can take up to 3 minutes.

The following subjects are displayed in this section:

- **Device Alarm Configuration**
- **Bit Rate Limits**
- **PCT Jitter**
- **Hiding of Events**
- **Golden Stream**
- **DVB-S Configuration**
- **DVB-T Configuration**

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
