---
uid: Connector_help_Paradigm_Redundancy_Controller
---

# Paradigm Redundancy Controller

The **Redundancy Controller Unit** has been designed to control the automatic switching of redundant up and down converters, where failure is detected within the system.

## About

With this connector it is possible to monitor the main status variables within the system, as well as to control the switching priorities.

## Installation and configuration

### Creation

This connector uses a serial interface as described in the document Basic Operation Manual Paradigm Redundancy Controller, dated 10/12/2013:

**Serial Connection**

- **IP address/host**: The polling IP of the IP to Serial equipment connected to the device.

**Serial Settings**

- **Port number:** The port on the IP to Serial equipment

Please note that according to the documentation, the serial configuration to be used should be as follows: **Baud rate**, 9600. **Data bits**, 8. **Stop bits** 1. **Parity**, none.

## Usage

Once created, the element can be used immediately. There is a single page available.

### General

This page contains the **switch positions (Ku and L-Band)**, the **power supply statuses**, the **up** and **down converter modes** and the **status of the connections**. It's also possible to modify the **priorities** of the up and down converters.
