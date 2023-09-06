---
uid: Connector_help_Evertz_XRF4
---

# Evertz XRF4

The XRF4 is a non-blocking, high-density wideband RF router for signals from 40 to 2450 MHz. Optional features include crosspoint redundancy, direct fiber input modules, an integrated spectrum analyzer and more. The XRF4 IO modules are individually software-upgradable to support LNB powering and/or automatic gain control.

## About

### Version Info

| **Range**            | **Key Features**                 | **Based on** | **System Impact**                                                 |
|----------------------|----------------------------------|--------------|-------------------------------------------------------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                 | \-           | \-                                                                |
| 1.0.1.x              | Redundant polling.               | 1.0.0.1      | Connection setting.                                               |
| 1.0.2.x \[SLC Main\] | Display discrete values changed. | 1.0.1.1      | Potentially affects alarms, Visual Overviews, Automation scripts. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.0                    |
| 1.0.1.x   | \-                     |
| 1.0.2.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

On the **General** page of the element, you can find general information about the device such as the Name Alias, Network IP Address, Gateway, etc.

The **Matrix** page displays the device matrix, where you can set crosspoints.

The **IO** **Control** page contains tables listing the inputs and outputs.
