---
uid: Connector_help_Nortel_iEMS_Log
---

# Nortel iEMS Log

The Nortel iEMS is an Integrated Element Management System that offers configuration and monitoring of Voice over Packet networks.

## About

The **Nortel iEMS Log** connector allows a user to receive and process logging from a Nortel iEMS. Logging can be saved on the local disk and the log files can be attached to and sent with scheduled e-mails.

## Installation and Configuration

### Creation

This connector uses a serial (UDP) connection and requires the following input during element creation:

**SERIAL CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *172.32.65.38.*
- **IP port**: The IP port of the device, by default *8560.*

## Usage

### General Page

This page displays general information, such as:

- The connected **Switch** name and **IP**, **Connection Loss** state.
- **Logging Fail** alarm to indicate if a write to the local disk has failed, mentioning that the Element Logging should be checked for the specific reason.
- Mail Scheduler options such as the **Interval time**, and a notification if the last mail failed, also indicating that the user should check the Element Logging for more details.

In addition, the page also contains the following page buttons:

- **File Settings**: Allows the configuration of the **log save location** and of the **auto-delete** functionality that can be executed after a file has existed for a certain time (7 days by default).
- **Compose E-Mail**: Provides a range of settings for creating and sending e-mails with information (**From, To, Subject, Body**). In addition, you can also enable or disable **attached** **log files**.

### Long Duration Calls

This page displays a table with all **currently active Long Duration Calls**. The table is updated once every hour and displays only Long Duration Calls that have a duration longer than *12 hours.* The Call Duration Columns can be monitored and have their internal value stored in a decimal value representing Hours.
