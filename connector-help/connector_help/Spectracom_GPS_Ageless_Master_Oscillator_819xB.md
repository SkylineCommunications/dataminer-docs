---
uid: Connector_help_Spectracom_GPS_Ageless_Master_Oscillator_819xB
---

# Spectracom GPS Ageless Master Oscillator 819xB

The Spectracom GPS Ageless Master Oscillator 819xB connector displays information related to the Spectracom GPS Ageless Master Oscillator 819xB device.

## About

This connector gathers information from the **Spectracom GPS Ageless Master Oscillator 819xB** device using a serial connection, and displays this information on five different pages.

## Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL Connection:**

- **Type of port:** TCP/IP.
- **IP address/host**: The polling IP or URL of the destination, e.g. *10.145.1.12*.
- **IP port**: The port of the destination, e.g. *13000*.
- **Timeout of a single command:** *1500 ms* (minimum).

## Usage

### General Page

This page contains general information about the device, such as:

- **Version**
- **Time**
- **Date**
- **Battery Status**
- **Temperature**
- **Alarms Timeouts**
- **Antenna Cable Delay**

### GPS Signal Status Page

This page displays one table with the signal status of the 12 possible satellites. It also displays some other parameters regarding the signal, such as the **current number of satellites tracked** and the **GPS state**.

### Tracking History Page

This page contains a table with the tracking history, containing the number of seconds that 0 to 12 satellite were tracked for each hour.

### Oscillator Log Page

This page displays the **Oscillator Log**.

### Alarm Page

This page displays the **Alarm Log** and the current **Alarm Status**.
