---
uid: Connector_help_CISCO_D9850
---

# CISCO D9850

The **CISCO D9850** is a program receiver for satellite content distribution applications.

## About

The CISCO D9850 connector makes it possible to monitor and control the Cisco PowerVU Model D9850 with SNMP.

HTTP is used to retrieve the system alarm information.

## Installation and configuration

### Creation

This connector uses an **SNMP** and **HTTP** connection. The following information is required during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *public.*

**HTTP CONNECTION**

- **IP address/host:** The polling IP of the device, e.g. *10.11.12.13.*
- **Port number:** The port of the connected device, by default *80* (HTTP).

### Configuration HTTP

On the element page **General -\> Login**, you can enter the username and password for the device. The **Login Status** shows if the login succeeded or failed.

## Usage

### General page

The connector will only retrieve the **system alarms** **info** if a valid username and password are specified on the **Login subpage.**

With the **Reboot** button, you can reboot the device.

## System Alarms page

At the top of this page, the **Alarms Status Polling** toggle button allows you to enable or disable the polling of the alarms status.

If polling is enabled, the **System Alarms**, **System Alarms Info**, **System Warnings** and **System Warnings** **Info** parameters are filled in.

### Webpage

This page displays the webpage of the device. The web interface is only accessible when the client machine has network access to the product.
