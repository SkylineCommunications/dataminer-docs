---
uid: Connector_help_PDU_eXperts_SW-16-08H
---

# PDU eXperts SW-16-08H

The **PDU eXperts SW-16-08H** connector monitors and controls the Power Switch unit of the same name through **SNMP**.

## About

The connector polls relevant information from the device every 10 seconds or every hour.

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string used when reading values from the device. The default value is *public.*
- **Set community string**: The community string used when setting values on the device. The default value is *private.*

## Usage

This connector has several data display pages:

### General Page

This page displays general information about the system:

- **Device ID** and **Firmware Version**.
- **System Description, Up Time** and **Services**.
- **System Contact**, **Name** and **Location**.
- **Temperature** and **Humidity** of the device and their respective **Thresholds**.

### Status Page

This page contains two tables.

The **PDU Table** contains all PSU information:

- **ID**, **Model** **Name**, **Model** **Number**, **Identify**, **Current**, **Warning** and **Overload** **Thresholds**, and **Voltage.**
- **Group 1 to 8** with the corresponding linked **Outlets.** (Enter *OutletA,OutletB,0,0,0,0,0,0* in order to add both outlet A and B to the group.)

The **Outlet Table** contains all the outlet information regarding a particular PSU:

- **PDU-Outlet ID:** Indicates the PDU and Outlet ID. For example, "8-12" indicates PDU 8 and Outlet 12.
- **Outlet Current**, **Outlet Status**, **On Delay** and **Off Delay**.
