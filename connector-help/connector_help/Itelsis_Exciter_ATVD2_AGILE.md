---
uid: Connector_help_Itelsis_Exciter_ATVD2_AGILE
---

# Itelsis Exciter ATVD2 AGILE

This connector for the **Itelsis Exciter ATVD2 AGILE** polls parameters of the device and captures traps. The parameters are displayed on several pages. The traps are used to update the value of some standalone parameters.

## About

This connector polls SNMP parameters of the **Itelsis Exciter ATVD2 AGILE** with several timers. The traps are captured and used to update parameters on the **Traps** page. When the element restarts, the old values of those parameters are restored.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *178.60.199.10*.
- **Device address**: The port number of the web interface.

**SNMP Settings:**

- **Port number:** The port number of the connected device, by default *161*. E.g. *24161* or *25161.*
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

## Usage

The connector consists of the following pages:

- **Home** page: Displays general information about the device and allows you to reset the exciter and turn it on or off.
- **Traps** page: Displays the received traps.
