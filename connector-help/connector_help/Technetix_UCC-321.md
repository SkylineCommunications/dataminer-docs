---
uid: Connector_help_Technetix_UCC-321
---

# Technetix UCC-321

The UCC-321 is a **controller combined with a splitter** and is used as part of the upstream splitter combiner solution from Technetix.

The unit monitors the alarm from the Technetix RPS-UNI power supply and **controls up to 22 USC-122 upstream splitter combiners**. A combined upstream output from all installed modules is located on the front panel.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.0                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**     |
|-----------|---------------------|-------------------------|-----------------------|-----------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | Technetix UCC-321 - USC-122 |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

This driver provides an overview of the Upstream Splitter Combiner modules connected to this controller and monitors the power supply.

It also shows the last trap message and allows configuration of the trap destination.

This driver will export different drivers based on the retrieved data. A list can be found in the section "System Info". The driver will check every hour for newly connected modules. You can speed up this process by clicking the **Refresh** button on the **Module Overview** page.

## Notes

**Only one element** can poll a device at a time. Polling one device with multiple elements at the same time could lead to unexpected behavior.
