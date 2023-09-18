---
uid: Connector_help_Itelsis_Amplifier_ATVD2_100W
---

# Itelsis Amplifier ATVD2 100W

This connector for the **Itelsis Amplifier ATVD2 100W** polls parameters of the device and captures traps. The parameters are displayed on several pages and the traps update the value of some standalone parameters, not corresponding to existing SNMP parameters.

## About

This connector polls SNMP parameters of the **Itelsis Amplifier ATVD2 100W** with several timers (a slow, medium and fast timer). The traps are captured and update parameters on the **Traps** page. When the element restarts, the old values of those parameters are restored.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *178.60.199.10.*
- **Device address**: The port number of the web interface.

**SNMP Settings:**

- **Port number**: Port number of the connected device, by default *161*. E.g. *24161* or *25161.*
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

The connector consists of 5 pages:

- **General** page with general information about the device.
- **Configuration** page.
- **Measures** page divided in Power Measures, Current Measures and Power Supply Measures.
- **State** page divided in Fans States, Power Alarms, Current Alarms and Power Supply Alarms.
- **Traps** page displaying the received traps.
