---
uid: Connector_help_Gamatronic_UPS_GMaCi
---

# Gamatronic UPS GMaCi

The **UPS GMaCi** is a UPS monitoring card from Gamatronic. This connector provides an interface for the card in DataMiner.

## About

The **GMaCi** card for UPS systems allows continuous monitoring and control of these systems, with real-time detection of UPS faults and immediate notification through SNMP Traps. By polling the card from DataMiner, it is possible to add alarming and trending on values, adjust operational settings, and integrate the device in the DataMiner System.

## Installation and configuration

This connector primarily uses an SNMP connection and needs the following information:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

The layout of the connector is similar to that the web interface, but there is an additional page named **General**, which contains the **Identification** parameters from the **UPS** page, in order to reduce the number of parameters on the latter.

Since the SNMP interface does not allow for reading or editing of values found on the **Configuration** page and subpages from the **web interface**, these values are not included in the connector.

### UPS

This page contains the following parameter groups:

- Nominal values: **Nominals**
- Battery Status: **Battery**
- Input readings: **UPS Input Table**
- Output readings: **Output Source**, **Output Frequency** and **UPS Output Table**
- Bypass readings: **Bypass Frequency** and **UPS Bypass Table**

### Control

With the **UPS Control** group, the device can be configured to reboot after it was shut down on request or after a power failure. This is done by changing the parameter **Auto Restart**.
Furthermore, the device can be forced to stop or restart with different types of delays.

The **UPS Test** group shows the latest test results and indicates whether a test is currently running.

To run a test, select the type in **Selected Test Id** and then click **Start Selected Test**.

### Alarms

This page will show any active alarm on the device. With the **Alarms Present** counter you can monitor whether an alarm is present.

### Webpage

If the user is in the same network as the device, this page will display the web interface of the device.
