---
uid: Connector_help_France_Televisions_InHouse
---

# France Televisions InHouse

This connector is used to monitor an FTP daemon, the **France Televisions InHouse** File Transfer System.

## About

This connector uses HTTP to monitor the state of the daemon and the status of its current jobs.

## Installation and Configuration

### Creation

This connector uses an HTTP connection and requires the following input during element creation:

**HTTP Connection:**

- **IP address/host:** The polling IP or URL of the destination, e.g. *10.11.12.13*.
- **IP port:** The IP port of the destination.
- **Bus address:** If the proxy server has to be bypassed, specify *byPassProxy.* This is enabled by default.

## Usage

This connector contains only one page.

### General

This page displays 3 parameters:

- **Daemon State**: Shows the status of the daemon. It represents the status code of the HTTP request.
- **Current Jobs**: Indicates the number of current jobs (uploading).
- **Failed Jobs**: Indicates the number of jobs in error state (failed).
