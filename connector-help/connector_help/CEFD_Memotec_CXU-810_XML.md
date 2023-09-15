---
uid: Connector_help_CEFD_Memotec_CXU-810_XML
---

# CEFD MEMOTEC CXU-810

This is a connector for the configuration and monitoring of the CXU-810

## About

The connector is used to configure a CXU-810. The configuration has to be applied after changes have been made.

## Configuration and Installation

### Creation

**CEFD MEMOTEC CXU-810** is a **SNMP/HTTP over DLL** connector.

Before you will be able to use the connector, you will need to copy 2 DLL files ("**cxcuaconfigapi_SLC.dll**" and "**cxuaconfigapi.dll**" ) to the following location:**"C:\Skyline DataMiner\Files"**

Also make sure that the device is running at **firmware version 2.9.0** or higher.

Once these settings have been done it is possible to create an element of this connector using the settings below.

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*
- **Device address**: the card number eg. 11

**SNMP Settings**:

- **Port number**: the port of the connected device, default *161*
- **Get community string**: the community string in order to read from the device. The default value is *public*.
- **Set community string**: the community string in order to set to the device. The default value is *private.*

Communication

This protocol uses snmp and a dll to communicate to the device.

## Usage

Once all configurations are done, this connector will work stand alone.

All settings done in DataMiner will be done to the "**pending configuration**" of the device.

## General Page

This page contains some general data concerning the device.

## Admin Page

This page contains standard administrator parameter such as the location and name of the device.
There are also buttons to reset the device or reboot it with the alternate firmware.
On this page you can also validate the pending configuration here and apply this configuration to the running configuration of the device.

Further on there are also options to set the trap receiver IP and the redundancy here.

## Configuration - Network Page

On this page you will find the configuration of the Management interface and the wan interface.
For applying the new settings to the device you can use the apply configuration button located at the bottom of the page

> [!IMPORTANT]
> When the apply configuration button is clicked, all settings of the connector will be applied to the running configuration and not only those of the Configuration- network page.

## Configuration - E1 Ports Page

On this page you will find the configurations of the E1 ports.
Also the configuration of the Optimization can be found here.
For applying the new settings to the device you can use the apply configuration button located at the bottom of the page

**Important note:** when the apply configuration button is pressed all settings of the connector will be applied to the running configuration and not only those of the Configuration- E1 Ports Page.

## Configuration - Wan interfaces Page

On this page you will find the configuration of the Wan Interfaces.

Also the configuration of the Bandwidth Provider can be found here.

For applying the new settings to the device you can use the apply configuration button located at the bottom of the page.

**Important note:** when the apply configuration button is pressed all settings of the connector will be applied to the running configuration and not only those of the Configuration- Wan interfaces Page.

## Configuration - Clocking

On this page you will find the Clocking Configuration.
Under the page button **E1 Ports.** you will find the states of the different E1 Ports.

## Statistics - Network

On this page you are able to find the stats of the network interface.
With the clear button it is possible to clear all the statistics of the device.

## Statistics - E1 Ports

On this page you are able to find the stats of theE1 Ports.

With the clear button it is possible to clear all the statistics of the device.

## Statistics - Wan Interfaces

On this page you are able to find the stats of the Wan interfaces.

With the clear button it is possible to clear all the statistics of the device.

## Statistics - Clocking

On this page you are able to find the stats of the clocking of the device.

With the clear button it is possible to clear all the statistics of the device.

## Statistics - Optimization

On this page you are able to find the stats of the optimization of the device.

With the clear button it is possible to clear all the statistics of the device.

When pressing the button "select E1 Port" that E1 Port will be selected for the displaying the timeslot formats located under the Mapping Page button. When there is no button pressed before opening the page this will by default be port 1.

## Alarms

On this page you are able to find a table witch contains the currently active alarms and the alarm history of the device.

There is also a global alarm severity of the device available.

The clear button located at the bottom of the page is used to clear the active alarms.

Via the page button **Alarm Management**, it is possible to acknowledge an alarm.

## Test Commands

On this page it is possible to get the raw xml data from the device.

This is done in 2 steps:

- Fill in the url of the xml to get in the parameter "**XML Path"**.
- Click on the Get button. This will then get XML from the device and put it in the XML Answer Textbox.

## Web interface

On this page you will find the web interface of the device.
