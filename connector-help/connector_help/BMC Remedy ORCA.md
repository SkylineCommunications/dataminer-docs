---
uid: Connector_help_BMC_Remedy_ORCA
---

# BMC Remedy ORCA

The **BMC Remedy ORCA** driver is used to interface with the **Fusion Remedy**.

## About

The **BMS Remedy ORCA** will not poll any information from the **Fusion Remedy**.

An **external source** (for example an automation script) can send an xml request to the BMC Remedy ORCA driver. This request will then be encapsulate into a "**executeRequest**" soap request that will be send towards the Fusion Remedy.

The response can then be further handled by the external source.

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | 1234                        |

## Installation and configuration

### Creation

#### HTTP Main connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: \[The polling IP or URL of the destination.\]
- **IP port**: \[The IP port of the destination, *default 38080*\]
- **Bus address**: \[If the proxy server has to be bypassed, specify *bypassproxy.*\]

### Configuration of request fields

The **soap** request has some additional fields that need to be configured before any request can be sent towards Fusion Remedy:

- **Username**: the username included in the security header of the soap request
- **Password**: the password included in the security header of the soap request
- **Grid Name**: the grid name included in the soap request
- **Process Name**: the process name included in the soap request

The **BMC Remedy ORCA** will not drop all requests as long as these parameters are not configured.

## Usage

### Configuration

This page groups all **configurations** for this driver (more info above).

The **request** and **response** are also displayed on this page along with a **Status** of the communication.

### Changes Overview

The Polled changes are listed in a tree control. Each change has it's linked Change impact entries.

### Changes

### The Changes Table is updated each 12 hours or manually by the Force Get All Changes -button. Entries are tracked in the table until the end times of the changes are past for more then 12 hours.

The States for changes are polled each minute for entries that are *active*, or if the changes is about to start (15 minutes prior to the start time, or if the time is in the expected start range).

A parameter **Active Change Count** is made available to show the current active Changes.

### Web Interface

This page can be used to access the Fusion Remedy web interface. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
