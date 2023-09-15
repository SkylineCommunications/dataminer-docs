---
uid: Connector_help_ETI_ADH_Netcom_SNMP
---

# ETI ADH Netcom SNMP

The **ETI ADH Netcom** device is an automatic air dehydrator that supplies low pressure air to keep waveguides and coaxial cables dry. The **ETI ADH Netcom SNMP** connector is the SNMP connector for this equipment, which also has a serial interface.

## About

With this connector it is possible to monitor the main environmental variables of the place where the device is installed, such as temperature and pressure. The connector also allows the user to configure the response of the equipment depending on the value of such parameters. It supports measurements in both the metric and the imperial system.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection**

- **IP address/host**: The polling IP of the device.

**SNMP Settings**

- **Port number:** The port of the connected device, by default *161.*
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

## Usage

Once created, the element can be used immediately. There are 5 pages available.

### Alarms

This page contains all the alarms provided for this device, such as low or high temperature, low or high pressure, or the state of the canisters. The information provided on this page is the result of parsing the response of the equipment to the request for the single parameter "alarms" (OID 1.3.6.1.4.1.32185.2.1.6).

### General

This page contains the relevant information coming from the standard MIB-2, such as the location, system description, etc.

### Status

This page contains all the possible status variables, such as temperature, duty cycle, compressor hours, etc. It also contains all the variables included in the parameter "statusVars" (OID 1.3.6.1.4.1.32185.2.1.4) as separate parameters.

For the sake of simplicity, the page displays the applicable measurements in both imperial and metric system units.

### Parameters

This page contains the thresholds for the device to start trying to compensate the pressure or to send alarms. The units are displayed in metric and imperial system units.

### Web Interface

This page displays the web interface of the device.

## Notes

It's important to note that in future versions of the firmware, the possible values of the parameters "alarms" and "statusVars" may change and new states may be added. As such, if any problems occur, this is where the developer should take a look first.
