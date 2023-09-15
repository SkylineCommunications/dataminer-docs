---
uid: Connector_help_ETL_Systems_GRF-C900-1U
---

# ETL Systems GRF-C900-1U

The GRF-C900-1U is a compact redundancy switch chassis measuring a 1U 19" shelf, with dual-redundant PSUs holding up to 2 GRF switch modules. The unit offers manual, automatic and remote operational modes.

This connector uses an SNMP connection to show the status of the different parameters for this particular unit of the GRIFFIN chassis series.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**            |
|-----------|-----------------------------------|
| 1.0.0.x   | CPU: e500 1v14 Modules: e501 1v11 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

### General

This page contains general system information.

- **IP configuration**: You can assign a hostname to the unit of up to 15 characters; by default, this is set to the unit serial number. DHCP is enabled by default; the IP address and other network settings will be requested from the DHCP server on bootup. If DCHP is disabled, then the IP address and other network settings will have to be entered manually. Click the "Set Network Config" button to apply the changes to the network configuration; the unit will then reboot.
- **SNMP Configuration**: If the unit is to generate traps, ensure that "Enabled" is set, and specify the destination IP address and community details in the corresponding "Receiver IP Address" and "Community" boxes.

## Chassis

The Chassis page provides overall information about the chassis.

- **Switch Mode**: The two control boxes allow you to select options for "Switching Mode" and "Synchronous Mode".

## Module 1 (or 2)

The module 1 (or 2) page allows you to view and configure information for modules installed in the unit. It displays the type of module fitted, operational information, and the current switch position.

The switch position will not be changed if the chassis "Switch Mode" is *Remote* or *Auto*, or the "Sync mode" for the module is the default slave to the selected master module.
