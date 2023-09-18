---
uid: Connector_help_Integrated_Digital_Solutions_Virtual_Client
---

# Integrated Digital Solutions Virtual Client

This connector allows to monitor/manage the IDS Virtual Client API

## About

The connector uses an HTTP connection to communicate with the device and performs its function by using a JSON requests/responses mechanism.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses a HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device(Default: 80).
- **Device address**: The device address. (Default: ByPassProxy)

## Usage

### Tree View

Tree view of all the monitors with their corresponding alerts.

### Configuration

This page contains the username and password fields, needed for establish the connection to the API.

### Alert Page

This page contains the **Alerts Table**, a list of alerts that are presently active or have been resolved in the last 15 minutes.

### Monitor Page

It contains the **Monitors Table**, which represents all the current stream monitors and allows to Start/Stop each one of them. In addition the page contains two page buttons (**Create New Monitor** and **Import/Export Monitors Info**) that link to:

- **Create New Monitor** page: This page allows the user to manually create a new monitor by adding each of the required fields.
- **Import/Export Monitors** page:This page allows to create/delete monitors in a bulk by importing/exporting the monitors information from/to a .csv file.
