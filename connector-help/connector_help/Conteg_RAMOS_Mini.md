---
uid: Connector_help_Conteg_RAMOS_Mini
---

# Conteg RAMOS Mini

RAMOS (**Rack Monitoring System**) is designed to be deployed within a rack to monitor its internal and external environment. As a network-attached device, RAMOS can report the status of sensors deployed in and around racks to any location worldwide.

## About

This connector uses SNMP in order to retrieve values from a **Conteg Ramos Mini**.

All parameters are retrieved and set in several pages depending on the kind of parameter.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *172.18.10.79*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

This connector consists of the following pages:

- **General**
- **Input Dry Contacts**
- **Output Relays**
- **Sensor Values**
