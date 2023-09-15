---
uid: Connector_help_Jampro_Combiner
---

# Jampro Combiner

With this connector, you can monitor the Jampro Combiner device.

## About

This connector uses serial communication to monitor the Jampro Combiner, displaying the **Power Levels**, **Alarm List**, and **Link Status**.

## Installation and configuration

### Creation

This is a **modbus** connector. The following input is required during element creation:

**Serial CONNECTION**:

- **Type of port**: TCP/IP
- **IP address**: The IP of the device, e.g. *10.11.12.13*.
- **IP Port**: The IP port of the device, *8080*.
- **Bus Address**: The bus connecting to the device.

## Usage

### General Page

This page displays general information related to the Jampro Combiner:

- **Forward Power**
- **Reflected Power**
- **Return Loss**
- **Standing Wave Ratio**

### Alarm Summary Page

This page displays a list of the states of alarms for the upper and lower limits of **Forward**, **Reflected**, **Return Loss** and **Standing Wave Ratio.**

### Ulink Status Page

This page displays a list of the link states for positions **A** to **K**.

### Coupler Page

This page displays the values of:

- **Upper Forward Coupler**
- **Lower Forward Coupler**
- **Upper Reflected Coupler**
- **Lower Reflected Coupler**

### Web Interface Page

This page displays the web interface to the Jampro Combiner device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to display the web interface.
