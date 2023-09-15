---
uid: Connector_help_Verizon_VSat_Database_Platform
---

# Verizon VSat Database Platform

The **Verizon Vsat Database Platform** is used to monitor proprietary information about various circuits deployed through the Verizon Satellite Network.

## About

The **Verizon Vsat Database Platform** has an associated API that will be queried via HTTPS. The protocol retrieves information on circuits from **configuration files**, processes them and proceeds to send the queries to the API.

All the received information will be stored in the **provisioning file** and duly organized in the tables of the element.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### HTTPS Main Connection

This connector uses an HTTPS connection and requires the following input during element creation:

HTTPS CONNECTION TO HTTP:

- **IP address/host**: [https://ipaddress](https://ipaddress/).
- **IP port**: The IP port of the device, by default *443*.
- **Device address**: The device address, by default *ByPassProxy.*

## Usage

### General

This page displays an overview of how many requested circuits are **Active** or **Unavailable.** With the **Update Circuits Data** button, you can start the process and request all the information from the database.

### Circuits

This page displays the **Circuits Overview** table, which contains the main information on each **Active** circuit.

- **Circuit Name**: Circuit name or circuit alias.
- **Circuit ID**: Circuit ID.
- **DNS Entity**: Verizon-assigned identifier for the circuit modem.
- **NMS**: The name of the iDirect in charge of hosting a given circuit.
- **Status**: *Active*/*Inactive* status of the circuit.
- **NOC Status**: *Managed*/*Unmanaged*.
- **Service Tier**: The service tier: *0*, *1*, *2* or *3*. Only 2 and 3 are monitored for trouble ticketing.
- **Maintenance Option**: The maintenance option for a given customer (e.g. *Next Business Day*).
- **Service Type**: The service type *Primary*/*Secondary* for a given customer.

It also displays information about customers and contact information:

- **Country Code**: The customer's country code.
- **Customer Name**: (VRF) customer name.
- **Location Name**: The ESP location name.
- **ESP Customer Name**: The ESP customer name.
- **Customer Short Name**: Short for the customer name.
- **Customer Number**: The customer number within Verizon's system.
- **Contact Name**: Customer outage contact name used in trouble ticket.
- **Contact Telephone**: Customer outage contact phone number to set in trouble ticket.
- **Contact Email**: Customer outage contact email used in trouble ticket.
- **DNS Entity Name**: Verizon-assigned identifier for the circuit modem.
- **NMS**: The name of the iDirect NMS in charge of hosting a given circuit.
- **Custom Description**: Custom column. Makes it possible to write and save relevant information about each circuit.

### Devices

This page contains information about each device available per circuit and its own description parameters. The page also contains circuit information on whether devices have deice facilities or interfaces.

- **Circuit ID**: The circuit ID.
- **Circuit Name:** The circuit alias.
- **Type**: The device type (e.g. *Antenna*, *BUC*, *Modem*).
- **Description:** The device description (e.g. *1.2 Meter Tier-3*, *Ku-Band with De-Ice*).
- **Model:** The device model (e.g. *1134-992*).
- **Serial Number:** The device serial number.
- **DNS Entity Name:** Verizon-assigned identifier for the circuit modem.
- **Has Deice:** *True*/*False*.
- **Has Interface:** *True*/*False.*

### Interfaces

This page contains information on all interfaces available per device, as well as the **Circuits ID** and some parameters to contextualize each element.

- **Type**: The interface type (e.g. *eth0*).
- **Circuit Path**: The circuit path (e.g. *Primary*).
- **VLAN**: The interface VLAN (e.g. *275*).
- **IP Address**: The interface IP.
- **Subnet**: The interface subnet.
- **PIP Circuits**: *True* or *False* depending on whether PIP circuits are available.

### PIP Circuits

This page contains information on all PIP circuits available per device, as well as the **Circuits ID**, information on interfaces, and some parameters to contextualize each element.

- **PIP Circuit ID**: Private IP circuit ID.
- **VRF**: Verizon reference to PIP circuit.
- **Teleport:** Descriptive reference.

### Unavailable Circuits Overview

The **Unavailable Circuit Table** contains the circuit names of all the circuits that have been requested but are no longer available.

### Polling Status

This page contains information on the HTTP configuration.

- **Status Code**: The last requested status code.
- **Last Request Datetime**: Date and time of the last received response.

### Configuration

This page contains different options to set up the **Vsat Database Platform.**

- **File Handling**: Master control. Enables/disables the processing of files and polling information from the database. This feature can also be stopped via the buttons in the import and export sections.
- **Circuit Request Size**: Number of circuits to be requested at a time. Contains the logic to divide the stack in the necessary requests.
- **Auto Processing Time**: Allows you to set the polling time, as well as to import, process and export files.

The Authentication section of the page contains the following parameters:

- **Username**: User name to be used in the HTTP session, to establish communication with the API.
- **Password**: Password of the HTTP session.

The Import Configuration section contains the following parameters:

- **File Import Button**: Allows the configuration files to be imported and processed, in order to create HTTP requests.
- **File Import Path**: Directory where the configuration files are stored.
- **Process Configuration File Button**: Allows you to manually activate the import/processing logic.

The Export Configuration section contains the following parameters:

- **File Export Button**: Allows the configuration files to be imported and processed, in order to create HTTP requests.

- **File Export Path**: Directory where the provisioning file will be stored.

- **Process Export File Button**: Allows you to manually activate the export/processing logic.
