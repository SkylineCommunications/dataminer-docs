---
uid: Connector_help_Hiltron_HDCU
---

# Hiltron HDCU

This connector is designed to monitor an HDCU (Hiltron De-icing Control Unit) device through SNMP. The device has a de-icing sensor and a dish heating system that can be monitored with this connector. The HDCU is present on satellite antenna dishes.

## About

This connector retrieves the temperatures and the currents on the device to give an overview of the device state, particularly in critical cases (*sensor fails*, *critical temperatures* or *currents*).

It allows the user to modify some parameters such as the heating fallback time when the heating request is no longer active. The device can send traps to announce a state change, which is immediately echoed to the relevant parameters. It is also possible to change the names of the different control entities directly in the device, and to change general system information, which will be used in sent traps.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *146.220.78.205.*
- **Device address**: Not required.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

### Heater and Temperatures Monitoring

This page shows important information about the antenna heater state, such as current values and status/error information on the ambient and dish temperatures. Alarms are generated if the temperature values are outside predefined ranges.

### Current Monitoring

The **Current Monitoring** page provides information on dish and feed heater currents, and displays alarms when the currents are outside the fail limit or reach the emergency stop limit.

### System and SNMP Information

On this page, general description information can be modified (**System Name, System Location, System Description, System Contact**). It also allows the user to change the trap class.

### Web Interface

This page displays the same device information as the other pages, but through the interface developed by Hiltron (Java Applet).

The client machine has to be able to access the device. If not, it won't be possible to open the web interface.
