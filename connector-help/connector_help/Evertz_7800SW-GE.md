---
uid: Connector_help_Evertz_7800SW-GE
---

# Evertz 7800SW-GE

This connector displays general information about the Evertz 7800SW-GE and allows you to monitor the input and output ports.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this connector has the following data pages:

- **General**: Displays general information about the device such as the **Firmware** and **Serial Number**. Also contains the **System Control** table, which allows you to **reboot** the system or perform a **factory reset**.
- **VLAN Configuration**: Displays the **VLAN State** and related information, as well as the **VLAN Ingress** and **VLAN Egress** tables.
- **Port Monitoring:** Displays statistics regarding the input and output ports, such as **Good Frames**, **Dropped Packets**, **Discarded Packets**, etc.
