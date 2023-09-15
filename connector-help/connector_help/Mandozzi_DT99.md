---
uid: Connector_help_Mandozzi_DT99
---

# Mandozzi DT99

With this connector, information can be gathered and viewed from the combimux **Mandozzi DT99**. The connector also makes it possible to set values on the device.

## About

This connector uses SNMP to interface with the **Mandozzi DT99** combimux.

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP Address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

This page displays general parameters for the device, such as the **System Name**, **System Description** and **SNMP Agent Version Number**.

This page also displays two buttons:

- **Trap Configuration:** Opens the trap configuration page.
- **Reset Device:** Resets the combimux.

### Trap Configuration Page

This page displays parameters related to the **Trap Configuration**:

- **Trap Alarms Destination Address**
- **M1 CCPU Alarm Status Trap**
- **M2 CCPU Alarm Status Trap**
- **M3 CCPU Alarm Status Trap**
- **M4 CCPU Alarm Status Trap**
- **M5 CCPU Alarm Status Trap**
- **M6 CCPU Alarm Status Trap**
- **M7 CCPU Alarm Status Trap**
- **M8 CCPU Alarm Status Trap**

The page also allows you to set a new **Trap Alarms Destination Address** and to toggle the **Alarm Status Traps** between enabled and disabled for each CCPU.

### Combimux Page

This page displays the CCPU alarm status parameters of the device:

- **M1 CCPU Alarm Status**
- **M2 CCPU Alarm Status**
- **M3 CCPU Alarm Status**
- **M4 CCPU Alarm Status**
- **M5 CCPU Alarm Status**
- **M6 CCPU Alarm Status**
- **M7 CCPU Alarm Status**
- **M8 CCPU Alarm Status**
