---
uid: Connector_help_Generic_Trap_Forwarder
---

# Generic Trap Forwarder

The Generic Trap Forwarder is a generic connector that can be used to save all incoming traps in a table and to forward them as well. The connector is SNMP-based and processes all traps.

## About

### Version Info

| **Range**            | **Key Features**                                                               | **Based on** | **System Impact** |
|----------------------|--------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                                                               | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Adapted to show information of up to 30 bindings.Custom port to forward traps. | \-           | \-                |

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

#### SNMP Connection - Main

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: 161.
- **Get community string**: The community string used when reading values from the device (default: public).
- **Set community string**: The community string used when setting values on the device (default: private).

## How to Use

On the **Traps** page, you can find the following settings:

- **Trap IP Source**: This is the trap IP source. By default, this is the same IP address as the **device polling IP** configured in the element.
- **Trap IP Destination**: This is the destination IP address. It is the IP address that the traps will be forwarded to. If it is empty, no forwarding operation will be executed.
- **Trap Port Destination**: This is the port traps will be sent through.
- **Trap Forwarding**: This parameter enables or disables the trap forwarding operation. By default, it is set to *Enabled*; however, if the destination IP address is not specified, no traps will be forwarded.
- **Total Traps**: This parameter indicates how many traps are present in the Traps Table
- **Traps Clean Up:** This allows you to configure the **Trap Clean Up Method** (*Row Count* (default), *Trap Age* or the *combination of both*), **Max Traps, Max Age Traps** and **Trap Clean Up Amount.**
- **Traps Table**: This table contains all incoming and forwarded traps. For incoming traps, the State column will indicate *Pending*, while for forwarded traps it will either indicate *Sent* (if the forwarding was successful) or *Failed* (if the forwarding was unsuccessful).
- **Delete All**: This option will delete all entries from the Traps Table.
- **Refresh Table**: This option will execute the trap cleanup process.
