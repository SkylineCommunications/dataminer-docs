---
uid: Connector_help_Belgacom_Blackout_Notifier
---

# Belgacom Blackout Notifier

With this connector it is possible to gather information regarding monitored blackouts.

## About

This connector will read an FTP file containing the information regarding the blackouts, process that information, and show it to the user.

## Installation and configuration

### Creation

**Serial Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *172.16.21.50*.
- **IP Port:** The destination port, e.g. *21*.

## Usage

### OTT Blackout Page

This page displays a table with the OTT Blackouts.

It also allows the user to add a Blackout manually, with the **Add Entry...** page button.

### BTV Blackout Page

This page displays a table with the BTV Blackouts.

It also allows the user to add a Blackout manually, with the **Add Entry...** page button.

### FTP Settings Page

On this page, the user has to fill in the necessary settings (FTP Username, FTP Password, FTP Path and FTP Filename) in order to be able to get the FTP file.

After setting these parameters, the user can click the **Get File** button. If the file is successfully retrieved, this will be indicated by the parameter **File Status**.

### Call Letters Page

This page contains a table with all unique Call Letters present in both the OTT and the BTV Blackout Table.
