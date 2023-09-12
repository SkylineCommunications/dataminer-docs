---
uid: Connector_help_Evertz_570ASI-X19-10GE2
---

# Evertz 570ASI-X19-10GE2

This connector allows you to manage the Evertz 570ASI-X19-10GE2 card. It communicates using SNMP.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                         | **Based on** | **System Impact**                                                                                                                               |
|----------------------|--------------------------------------------------------------------------------------------------------------------------|--------------|-------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version                                                                                                          | \-           | \-                                                                                                                                              |
| 1.0.1.x \[SLC Main\] | Added labels to display key with dropdown to select format, and changed display key column of DIN Inputs/Outputs tables. | 1.0.0.1      | DMS filters, Automation scripts, visual overviews, reports, and web API implementations referencing the changed display keys could be affected. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination, by default *161*.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the following pages:

- **System**: This page contains various system-related parameters and tables, including the **Control Port Configuration** table, **Import**/**Export** configuration file controls, and **Genlock** controls.
- **Product Features**: This page contains the **Serial Number** and **MAC Address.**
- **IP** **Input** **Control**: This page contains the **MPPM** **Control**, **IP** **Input** **Settings**, and **IP** **Packet** **Monitor** tables.
- **DIN** **Input** **Control**: This page contains the **DIN** **Inputs** table.
- **IP** **Output** **Control**: This page contains the **ASI** **IP** **Output** **Control** and **IP** **Output** **Configuration** tables.
- **DIN** **Output** **Control**: This page contains the **DIN** **Outputs** table.
- **System** **Notify**: This page contains the basic notify parameters: **Temperature** **Warning**, **Board** **Notify**, and **Port** **Link** **Notify**.
- **ASI** **Input** **Notify**: This page contains the **ASI** **Input** **Notify** controls and the **ASI** **Input** **Notifications** table.
- **IP** **Input** **Notify**: This page contains the **IP** **Input** **Notifications** table as well as the **Minimum** **Rx** **Bandwidth** **Threshold** control.
- **SNMP** **Setup**: This page contains controls for trap destinations.
- **SNMP** **Traps**: This page contains the **Traps** table as well as **Max** **Traps** and **Max** **Age** controls.
- **Trap** **Settings**: This page contains more traps controls such as **Trap** **Status**, **Timeout**, and **Automatically Deactivate Alarms After.**
