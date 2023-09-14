---
uid: Connector_help_Tandberg_TT4030_HTTP
---

# Tandberg TT4030 HTTP

The TANDBERG TT4000 range of Transport Stream monitors combine advanced error detection and monitoring via a web interface in a 3RU multi-channel unit.

## About

The Tandberg TT4030 HTTP connector is used to monitor a Tandberg TT4030 device. The information is divided in several categories that are displayed in different pages. The connector uses HTTP to communicate with the device.

## Installation and configuration

### Creation

This connector uses a **Serial** connection and requires the following input during element creation:

**SERIAL CONNECTION**:

\- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

\- **IP port**: The port of the connected device, e.g. *80.*

\- **Bus address**: The bus address of the connected device: not defined.

## Usage

### TS Info page

The **TS Info** page displays the general information of the transport stream.

### ERT290 Info page

This page displays the information for the three priorities.

### Service Info Page

The **Service** **Info** page displays the **Service** **Info** table. In this table, the different services are displayed. Once services are no longer available, these rows can be removed manually by clicking the **Clear** **Services** button. They can also be removed automatically by setting the **Auto Clear Services** parameter to *Enabled*.

The **Normalize CA.** page button opens a pop-up page where, when the **Normalize** button is pressed, the user can see the **Service Info CA Normalization** table.

### PID Info Page

On this page, the **PID** **Info** table can be seen. If PIDs are no longer available, these rows can be removed manually by clicking the **Clear** **PIDs** button. They can also be removed automatically by setting the **Auto Clear PIDs** parameter to *Enabled.*

### Web Interface Page

Here the user can see the web interface of the device.

## Notes

It is recommended to set the **Auto Clear Services** and the **Auto Clear PIDs** parameters to *Enabled*, so that all the Services and PIDs that are no longer available are removed from these tables.
