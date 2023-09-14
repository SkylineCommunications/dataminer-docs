---
uid: Connector_help_ManageEngine_Application_Manager
---

# ManageEngine Application Manager

The ManageEngine Application Manager is a server and application performance monitor.

## About

The **ManageEngine Application Manager** allows a user to receive and process data retrieved from the Application Manager. Specifically, it allows the user to view all Monitor Groups, Monitors and Alarms.

## Installation and configuration

### Creation

This connector uses an HTTP connection and requires the following input during element creation:

**HTTP CONNECTION**:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

## Usage

### General Page

On this page, you can find general information, mostly concerning the communication with the device, such as its **IP Address** and **API Key.**

The **API Key** is necessary for correct commands. You can find it by logging onto the Application Manager and checking for the key in "Generate Key" in the Admin tab.

### Alarms Page

This page provides an overview of all **Received Alarms** and their current **Status** (Cleared, Normal, Minor, Major, Critical). The **Alarm Table** is by default filtered to only show Alarms that are not **Monitor Groups**. This setting can be changed with the **Filter No Monitor Groups** toggle button.

### Monitors

This page provides a table with all **Monitors** that are part of the actively monitored **Monitor Groups**.

### Raw Data

This page provides two text boxes containing the **Raw Data** received from the **ListAlarms** and **ListMGDetails** commands respectively.
