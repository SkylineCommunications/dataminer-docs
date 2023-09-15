---
uid: Connector_help_Astro_BC4
---

# Astro BC4

The **Astro BC4** is a controller capable of monitoring the components of a headend and interrogating the headend remotely.

## About

The Astro BC4 connector is an SNMP connector for the **Astro BC4**.

## Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *10.145.1.12*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

## Usage

### General Page

This page displays parameters such as:

- **BC4 CPU Temperature**
- **BC4 Motherboard Temperature**
- **BC4 Buscontroller**
- Etc.

### Alarms

This page displays a table with the device's trap alarms and three parameters, which can be used to perform different actions:

- **Clear Alarms**: Clears all alarms present in the table.
- **Clear Table**: Empties the table.
- **Maximum Number of Rows**: Sets the table's maximum size.

### Webpage

Displays the device's Webpage.
