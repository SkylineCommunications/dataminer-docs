---
uid: Connector_help_Evertz_SC-1000
---

# Evertz SC-1000

The aim of this connector is mainly to control and monitor a matrix.

## About

The connector uses 2 connections. The main connection (*smart-serial*) implements the *Quartz* communication protocol to monitor and control a matrix. The second connection (SNMP) is used to get general device information.

### Version Info

| **Range** | **Description**                                                                   | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                                   | No                  | Yes                     |
| 2.0.0.x          | New Smart-Serial connection to support the Quartz protocol, needed for the matrix | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**   |
|------------------|-------------------------------|
| 1.0.0.x          | N/A                           |
| 2.0.0.x          | Software: 2.43 Hardware: 2.03 |



## Installation and configuration

### Creation

Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device (e.g. *172.23.40.205*).
  - **IP port**: The IP port of the device. Required, default value: *23*.
  - **Bus address**: The bus address of the device. Required, range: *1* to *16*.

SNMP Polling connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device (e.g. *161*).
- **Get community string**: The community string used when reading values from the device (e.g. *public*).
- **Set community string**: The community string used when setting values on the device (e.g. *private*).

## Usage

### Main View

This page contains the matrix.

### General

Here, you can find the following parameters: **Q-Link Version,** **Q-Link** **Address, Version, Memory, Installed Modules, Disk Usage, Upper/Lower PSU Temperature, Setup, Control State, Matrix Destination, Matrix Destination Status** and **Lock/Unlock** buttons.

### Matrix Configuration

On this page, configuration parameters are available: **Number of Inputs, Number of Outputs, Number of Levels, Local IP-Address, Remote IP-Address**. When changing the **Number of Inputs** and **Number of Outputs** parameters, the matrix size is automatically updated. Then, you need to press the **Refresh Matrix** to immediatly poll the matrix *crosspoints* and *inputs/outputs* labels.

The **Reset Router** allows to reset the matrix connections.

### Matrix Details

Following tables are displayed:

- **Source Table:** contains the labels retrieved for each input and used in the matrix on the *Main View* page
- **Destination Table:** contains the labels retrieved for each output and used in the matrix on the *Main View* page
- **Level Table:** contains the names associated to each matrix level
