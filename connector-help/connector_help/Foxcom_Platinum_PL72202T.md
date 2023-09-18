---
uid: Connector_help_Foxcom_Platinum_PL72202T
---

# Foxcom Platinum PL72202T

This connector makes it possible to monitor and configure the **Foxcom Platinum PL72202T**. This device is similar to the **Foxcom Platinum PL7220T.** The Foxcom Platinum PL72202T has an extra transmitter output.

## About

This connector polls both general parameters and more specific parameters related to the transmitter. In order to configure the device, some parameters in the connector can be set.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *10.250.248.28.*
- **Device address**: Required. Range between *1* and *12*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

The connector consists of 3 pages (similar to the Foxcom Platinum PL7220T but with extra parameters for the extra transmitter):

- **General:** General parameters regarding the device.
- **Transmitter:** Parameters related to the transmitter.
- **Alarms:** Alarms related to the transmitter
