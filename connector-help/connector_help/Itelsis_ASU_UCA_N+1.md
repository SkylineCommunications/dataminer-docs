---
uid: Connector_help_Itelsis_ASU_UCA_N+1
---

# Itelsis ASU UCA N+1

This connector monitors the **Itelsis ASU UCA N+1**, an Automatic Switching Unit that monitors several pieces of equipment. In case of failures, it can switch to backup equipment. N+1 means that there are N principal items of equipment and 1 backup item.

## About

This connector for the **Itelsis ASU UCA N+1** polls parameters of the device and captures SNMP traps. The parameters are displayed on several pages. The traps are used in order to update the values of some standalone parameters, some of which correspond to existing SNMP parameters.

This connector polls the SNMP parameters using several timers: a slow, medium and fast timer. The SNMP traps are captured and used to update parameters on the **Traps** page. When the element restarts, the old values of those parameters are restored. Some traps are used to update existing SNMP parameters in the **Equipment and Switch Table**.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *178.60.199.10*.
- **Device address**: The port number of the web interface.

**SNMP Settings:**

- **Port number**: The port number of the connected device, by default *161*. E.g. *26161.*
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

## Usage

The connector consists of the following pages:

- **Home** page: Displays general information about the device and the equipment.
- **Equipments** page: Provides an overview of all attached equipment.
- **Switch table** page.
- **Traps** page: Displays the received traps.
