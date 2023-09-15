---
uid: Connector_help_Digidia_FlexiDAB
---

# Digidia FlexiDAB

The **Digidia FlexiDAB** is a DAB/DAB+/DMB multiplexer with integrated audio and data encoders.

## About

This protocol monitors the Digidia FlexiDAB multiplexer over **SNMP**, with the possibility of receiving traps for the parameters indicating alarms.

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string:** The community string used when reading values from the device, by default *public*.
- **Set community string:** The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays basic information about the device. There are two buttons to reset specific information:

- **Reset System Configuration**
- **Reset System Equipment**

The **Refresh** button will poll all SNMP parameters again.

### Users

This page displays the device's users and access levels.

### Ethernet and Trap Settings

On this page, you can find settings and information regarding the **Ethernet cards** and **SNMP Traps**.

### Trap Notifications

This page contains the Trap **Alarm Notification Table**. The **time** and **trap counter** are at the top of the page.

### Event Log

This page contains the **Event Log Table**. A button to clear the table is available at the bottom of the page.

### Alarm Settings

This page contains the **Alarms Bool Settings Table** and **Alarms Threshold Setting Table**.

### Alarm Status

This page displays parameters that indicate specific device alarms. When a trap is received, the specific alarm value will be polled again.

Note that since these parameters are statuses, the possible values are *OK* or *Alarm*.

### Application Notification

This page contains the **Application Alarm Notification Table**.

### Alarm History

This page contains the **Global Alarm Table**.
