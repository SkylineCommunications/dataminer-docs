---
uid: Connector_help_APC_AP7724
---

# APC AP7724

The **APC AP7724** is a rack-mount automatic transfer switch.

## About

With this connector, it is possible to monitor and configure APC AP7724 devices.

The different parameters of the device are logically distributed over multiple pages.

## Installation and configuration

### Creation

This connector retrieves information from the device via SNMP. When you create an element, the following information must be provided:

**SNMP Connection:**

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string needed to read from the device. The default value is *public*.
- **Set community string**: The community string needed to set to the device. The default value is *private*.

## Usage

### Overview Page

This page displays general information, such as:

- **Load status**
- **Software Version**
- **Serial Number**
- **Device Uptime**
- **Device Ratings**

### ATS Status Page

This page displays all the statuses of the automatic transfer switch, such as:

- **Communication status**
- **Selected Source**
- **Source A/B status**
- **Voltage/Current status**
- **5/12/24V Power Supply status**

### Configuration Page

This page allows the user to change settings on the device, such as:

- **Voltage Sensitivity**
- **Current Limit**
- **Preferred Source**
- **Front Panel Lockout**

### Input/Output Status Page

This page displays the **Input Sources** and the **Output Banks** with their load.

### Calibration Page

This page displays the **Input Phase Calibration Factor** and the **Power Supply Calibration Factors**.
