---
uid: Connector_help_VOO_App_Store_Monitor
---

# VOO App Store Monitor

This connector is used to retrieve status information from the **VOO App Store**.

## About

This is an HTTP connector that retrieves JSON-formatted status information from an HTTP server to provide monitoring.

## Installation and configuration

### Creation

This connector uses an HTTP connection and requires the following input during element creation:

**HTTP CONNECTION:**

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

### Configuration of IP address/host

The IP address of the device must be filled in for the connections **SERIAL CONNECTION** and **APPSAVAILABLITY**.

## Usage

### General

This page displays the **Disk Space, IO, CPU, RAM** and **Service Current Availability.**

### Apps

This page displays the **Apps Table**, which shows the following information for each application: the **Name**, **Current Availability**, **Last Hour Availability,** **Last Day Availability** and **Last Week Availability**.
