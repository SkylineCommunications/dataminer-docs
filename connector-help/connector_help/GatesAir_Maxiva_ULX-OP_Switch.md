---
uid: Connector_help_GatesAir_Maxiva_ULX-OP_Switch
---

# GatesAir Maxiva ULX-OP Switch

The GateSwitch N+1 provides automated switchover operations between multiple transmitters, transposers or gap fillers/repeaters to ensure transmission continuity even in the event of the failure of one of the units. This equipment stores the operating configurations of the N units in the system and automatically performs the necessary operations to substitute a failed unit with a "+1" spare unit connected to the system.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 6.0.3                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: *161*

SNMP Settings:

- **Get community string**: *public*
- **Set community string**: *private*

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to Use

The driver polls the device's general information and monitors its current status. Settings related to the device's operation are available as well. These functionalities are available on the following pages:

- **General:** Provides information related to the device's firmware, serial number and name. Information such as the point of contact, number of switches and driver on spare are available as well.

- **System Status**: Displays an overview of the current system status, which includes the communication, number of switches, on antenna/load, driver in fail and driver in restore timers.

- **Unit:** Allows you to view and configure the system date and network settings (IP address, gateway and NPT server).

- **Switch Configuration:** Contains settings related to the logic operation (e.g. Logic State and RF Tx threshold) and time (e.g. system restore time and protection time). In addition, the **Test System** functionality is available if the **Logic State** parameter is set to *Manual*.
  - **System Configuration:** Displays a system configuration table with information related to the switch enablement, IP address, Address 485, Priority and whether it is a driver or a spare.
  - **SNMP Trap Managers:** Allows you to configure SNMP trap managers.
  - **Password:** Allows you to configure the user name, password and role.

- **Switch Alarms:** Displays information related to the switch's communication, coaxial, Driver A and Driver B alarms.
