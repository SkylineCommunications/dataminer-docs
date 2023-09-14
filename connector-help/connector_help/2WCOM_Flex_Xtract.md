---
uid: Connector_help_2WCOM_Flex_Xtract
---

# 2WCOM Flex Xtract

This connector can be used to monitor the DVB-S/DVB-S2 Flex Xtract receiver through status parameters and to configure its network and alarm settings.

## About

To retrieve data and configure settings, SNMP is used. The connector allows you to configure alarm thresholds, network configuration parameters, and so on, so that the status of important parameters can be monitored.

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address:** Not required.

SNMP Settings

- **Port number**: The port of the connected device (e.g. *161*).
- **Get community string**: The community string used when reading values from the device (e.g. *public*).
- **Set community string**: The community string used when setting values on the device (e.g. *irdprivate*).

### Configuration

To configure the **LITE functionality**, on the Network Settings page, enable the **LITE Protocol** toggle button.

## Usage

### Network Settings

On this page, you can configure communication parameters for several protocols: **TCP/IP Hostname**, **HTTP Port**, **Trap IP1** (SNMP page button), **SNTP Update Interval** (SNTP), etc.

### System Settings

This page displays global system information, such as the **System Name** and **System Description**.

It also contains the alarm configuration for **Tuner Input**, **ASI Input**, **IP 1000Base_T Input**, **DAB Data** and **Reference Clock***.* For example, for the Tuner Input, you can view the **RF Power State** and edit the **RF Power Value**, **RF Power Tolerance**, **RF Power T1**, **RF Power T2** and **RF Power Priority**, enable or disable **RF Power Traps**, etc.

### Status

This page displays the status and value of several important parameters, including **C/N**, **CFO Error**, **CE**, **FEC**, **Viterbi/LDPC BER** and **External Reference Clock State.**

The page also contains the **Event Log Table**, which shows event information received from the device through SNMP traps.

### Interface

This page displays the **Front DTE Baudrate**, **Interfaces Table** and **Address Translation Table**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
