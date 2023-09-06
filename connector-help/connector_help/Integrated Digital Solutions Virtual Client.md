---
uid: Connector_help_Integrated_Digital_Solutions_Virtual_Client
---

# Integrated Digital Solutions Virtual Client

This driver allows to monitor/manage the IDS Virtual Client API

## About

The driver uses an HTTP connection to comunicate with the device and performs its function by using a JSON requests/responses mechanism.

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### HTTP Main Connection

This driver uses a HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device(Default: 80).
- **Device address**: The device address. (Default: ByPassProxy)

## Usage

### Tree View

Tree view of all the monitors with their corresponding alerts.

### Configuration

This page contains the username and password fiels, needed for establish the connection to the API.

### Alert Page

This page contains the **Alerts Table**, a list of alerts that are presently active or have been resolved in the last 15 minutes.

the last 15 minutes).

### Monitor Page

It contains the **Monitors Table**, which represents all the current stream monitors and allows to Start/Stop each one of them. In addition the page contains two pagebuttons (**Create New Monitor** and **Import/Export Monitors Info**) that link to:

\- **Create New Monitor** page: This page allows the user to manually creaty a new monitor by adding each of the required fields.

\- **Import/Export Monitors** page:This page allows to create/delete monitors in a bulk by importing/exporting the monitors information from/to a .csv file.

Revision History

DATEVERSIONAUTHORCOMMENTS30/06/2017 1.0.0.1 HPE, Skyline Initial Version21/08/2017 1.0.0.2HPE, Skyline Monitors: added field Service and "Start all Monitors" button. Changed start/stop column form togglebutton to button. Alerts: Set column Stream Monitor Id as foreign key to Monitors table; added code discreets and change the display order of some columns. Added TreeControl. Provided ability of set credentials on a new page "Configuration". Changed alerts polling time to 10 seconds.28/08/2017 1.0.0.3HPE, Skyline Saved columns contained in DisplayKey of Alerts and Monitors tables. Enabled alarming for alerts Code and Notice columns. Made the Alerts Page the default one.13/09/2017 1.0.0.4HPE, Skyline Added "Service" field to the naming for Monitors and Alarms tables. Moved Monitors group(2) to the faster timer (10 seconds), the same used by Alerts group.25/09/2017 1.0.0.5HPE, Skyline Updated Status(Monitors) discreets. Added "Skip Segment Header Download" in Monitors table. Added "Stream Monitor Status" in Alerts table. Added "Last Successful Update" column to Alerts and Monitors tables. Created Alert Code discreets.28/09/2017 1.0.0.6HPE, Skyline Created "Last Successful Update" standalone parameters for Monitors and Alarms, and removed corresponding columns parameters. Removed discreets for alerts status due to a customer request.19/10/2017 1.0.0.7HPE, Skyline Added "Delete" column button to Monitors table.27/10/2017 1.0.0.8HPE, Skyline Added ability to create/delete monitors in a bulk via a CSV file. Added "Service" parameter to the manual monitor creation. Improved JSON requests based on the latest API documentation.14/11/2017 1.0.0.9 HPE, Skyline Removed CCID field from Metadata in Json classes.17/11/2017 1.0.0.10 HPE, Skyline Added "channel" attribute to Metadata field in Json classes and the ability to import/export this field by using .csv files. Configured custom alarm property IDS Notice for column Code in Alerts table.14/12/2017 1.0.0.11 HPE, Skyline Changed name format for imported .csv file. Added ability to create/delete monitors using a parameter updated in Automation Script.04/01/2018 1.0.0.12 AIG, Skyline Update protocol to use the latest API.02/02/2018 1.0.0.13 AIG, Skyline Include new parameters.06/04/2018 1.0.0.14 AIG, Skyline Update Details Column in the Alarms Table.16/04/2018 1.0.0.15 AIG, Skyline New API call to start all monitors. 11/06/2018 1.0.0.16 AIG, Skyline Add support for new fields included in the latest API.
