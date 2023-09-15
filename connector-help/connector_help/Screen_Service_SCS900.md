---
uid: Connector_help_Screen_Service_SCS900
---

# Screen Service SCS900

The SCS 900 model is an automatic change-over unit that controls and operates television transmitters and transposers, both analogue and digital, as well as microwave links, with configurations ranging from 1+1 to 8+1. The system management includes multiple local or remote interfaces (RS-232, RS-485, parallel contacts, SNMP, USB and LAN). The user can select either the manual or the automatic mode, and on/off or switching functions can be activated remotely.

## About

With this connector, it is possible to monitor and configure the state of the switches, switch priorities and handle notifications via traps. The different parameters from the device are displayed on multiple pages similar to the web interface layout.

## Installation and configuration

### Creation

Follow the standard procedure for SNMP managed devices. No aditional information is required

**SNMP Connection**

- **IP address/host**: The polling IP of the device.

**SNMP Settings**

- **Port number:** The port of the connected device (default: *161*).
- **Get community string:** The community string used when reading values from the device (default value: *public*).
- **Set community string:** The community string used when setting values on the device (default value: *private*).

## Usage

Once created, the element can be used immediately. There are 7 pages available.

### General

This page contains general information such as software versions, NTP settings or equipment contact/location.

### Commands

On this page, commands can be sent to the equipment to restore the system configuration or to acknowledge incoming traps.

### Measures

This page displays the configuration of the relays.

### Settings

On this page, the element can be configured: you can set up the connection with the spare unit, select the operating mode of the equipment, and do other miscellaneous configurations.

### Alarms

This page displays all the available alarms reported by this device.

### Traps

On this page, you can configure what traps are enabled and where they should they be sent.

### Web Interface

This page displays the web interface of the device.

## Notes

It's important to note that the read/write parameters that express time or dates accept values in the formats "HH:MM" and "DD/MM/YY". These values are validated before they are set and any errors are logged accordingly.
