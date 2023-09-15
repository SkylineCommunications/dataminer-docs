---
uid: Connector_help_Mankin_Media_Manager
---

# Mankin Media Manager

This connector provides a management application with ticketing, with the final purpose of supporting the workflows Guardian LifeLine and Guardian Protect.

## About

This connector is used together with Automation scripts and a Visio overlay, allowing the creation, viewing, checking and editing of tickets, in order to keep track of problems in a system.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

This connector uses a **virtual connection** and does not require any input during element creation.

## Usage

### Info

This page contains detailed information about the installation and the necessary configuration for the correct operation of the application.

### General

This page contains different basic configuration parameters, such as:

- **Ticket User Name:** The value of this parameter is automatically retrieved, since logging into DataMiner also allows you to operate the application and the ticketing module.
- **Ticket User** **Password:** The value of this parameter is also recovered from the DataMiner session, and is required in order to operate the application and the ticketing module.
- **Ticket Resolve GUID:** This GUID is obtained via a query to the Cassandra database, and is required in order to create tickets.
- **Solve Monitor Time:** This parameter allows you to specify the period of time after which a ticket that has been resolved will be activated if the failure is repeated.
- **Station Check Time**: This parameter allows you to specify the interval of time during which a station can be inactive before the user of that station is disabled.

The page also has a subpage that displays tables with general information on the operation and information that is necessary to run the application.

- **Ticket Monitor Table:** Lists the resolved tickets that remain in latency for a period of time determined by the client, during which a repetition of the failure will activate the ticket again.
- **Panel Key Assignments:** Displays the position of the engineering stations and clients in the Clear Com device, so that these panels can be reconfigured.
- **GUI Messages Table:** Displays important information for the correct operation of the application, required by Automations scripts.

### Customers

This page contains two tables with valuable information on each client and their workstations:

- **Customer Table:** This table contains detailed information on the client and its location, venue and geographical location, in addition to the basic configuration of its decoders, which will be taken into account when providing support.
- **Customer Position Table:** This table contains detailed information on each customer station, including its type and the position or port used in the Clear Com device and panel.

### Engineering

This page displays the **Engineer Station Table**, which contains detailed information on the engineering stations and the configuration of their decoders. It allows an engineer or administrator to take a station or release it when its work is done.
Your data will be taken into account in the entire management process of the engineer and for the tickets that are managed from this station.

### Markers

This page contains the **Location Markers Table**, which displays general information on the markers and their current status. A marker corresponds to data from the stations of the client and to a ticket. The longitude and latitude for the locations is also provided in order to be displayed on a map.
