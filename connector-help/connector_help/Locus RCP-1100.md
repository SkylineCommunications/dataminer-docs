---
uid: Connector_help_Locus_RCP-1100
---

# Locus RCP-1100

This is an **Serial** driver that will show the status of the different parameters of an **Locus RCP-1100** device.

# About

The ****Locus RCP-1100**** consists of a **SWO** control panel,There is no web interface to control the device.

# Configuration and Installation

## Creation

The ******Locus RCP-1100****** is a **Serial** driver. The **IP** and **Port** need to be configured during creation of the **element**.

**Serial CONNECTION**:

- **Type of port**: TCP/IP
- **IP address**: The IP of the device (e.g. 10.11.12.13)
- **IP Port**: The IP Port of the device (8080)

# Usage

## General Page

This contains some general configuration information about the the device such as:

- Power suply status
- Amplifiers Status
- Amplifiers Power

## Switch Configuration Page

This contains information about the **pins** of the 3 switches.

## Fault Status Page

This contains information about the Fault Status of the device such as:

- Aplifiers faults
- Power suply Faults
- RF Switch Faults
- ...

## Configuration Page

This page contains **parameters** to configure the **Remote Input Switch** and the **Auto Broadcast State**
