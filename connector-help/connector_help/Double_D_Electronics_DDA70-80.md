---
uid: Connector_help_Double_D_Electronics_DDA70-80
---

# Double D Electronics DDA70-80

This connector can be used to display and configure information of the **Double D Electronics DDA70-80** WG Switch.

## About

This protocol uses a serial connection to monitor and control the **Double D Electronics DDA70-80**.

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **TCP**: Connection is selected automatically.
- **Port**: The port to connect to the device.
- **Local Port**: The local IP port to be used, e.g. *8000.*
- **Bus Address**: The bus address of the device. The default value is *65.*

## Usage

### General Page

This page contains generic device information, such as the **Software Version**, **Device Name** and **General Alarms**.

When commands are sent to the device, the response status (error/ok) is displayed on this page. The button **Acknowledge** can be used to clear this status.

### Switches Page

On this page, you can monitor and configure the status and positions of the switches.

### Chains Page

On this page, you can see the status of the chains on the device.
