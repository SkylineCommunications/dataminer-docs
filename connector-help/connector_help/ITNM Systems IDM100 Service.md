---
uid: Connector_help_ITNM_Systems_IDM100_Service
---

# ITNM Systems IDM100 Service

The **ITNM Systems IDM100 Service** driver is used to display information about one particular service from the **ITNM Systems IDM100** analyzer. The driver uses a serial connection to send HTTP commands to the device.

## About

The **ITNM Systems IDM100 Service** driver sends HTTP commands to the IDM100 over a serial connection. The driver only polls the service information from one of the servicesof the **ITNM Systems IDM100**.

## Installation and configuration

### Creation

This driver uses a serial connection and needs the following user information:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **IP port**: The port of the connected device, e.g. *81.*

## Usage

This driver has 5 pages: **General**, **PIDs**, **Audio / Video**, **PCR / PTS/ DTS** and **Web Interface**.

### General Page

The **General** page displays general information about the service. For example: the **Service Type**, **Total Bandwidth**, etc.

### PIDs Page

The **PIDs** page displays the **Service PIDs** table. This table has an entry for each PID in this particular service.

### Audio / Video Page

The **Audio / Video** page displays 2 tables: **Audio PIDs** and **Video PIDs**. The audio PIDs from this service will be displayed in the **Audio PIDs** table, while the video PIDs will be displayed in the **Video PIDs** table.

### PCR / PTS / DTS Page

The **PCR / PTS / DTS** page contains extra information about the errors and performance of the service.

### Web Interface

The **Web Interface** page can be used to access the web interface of the device. Note that the interface must be accessible from the client PC.
