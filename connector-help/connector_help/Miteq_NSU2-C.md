---
uid: Connector_help_Miteq_NSU2-C
---

# Miteq NSU2-C

The MITEQ NSU2-C/C23823 improves reliability for advanced satellite communications systems. The NSU2-C system consists of an NSU2 Control Unit, Switch Modules, and fiber-optic transmitters and receivers.

The NSU2 Control Unit monitors the status of each of the fiber-optic receivers and the fiber-optic transmitters. When a fault is detected on any component in a primary path, the defective path is automatically placed into standby, and the backup path is placed online using the switch modules.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra initialization is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The device information can be found on the **General** and **System** pages.

The **Alarms** page contains all alarm indicators regarding the power supplies and faults.

The **Status Indicators** page contains all alarm indicators regarding the switch positions.

The **Converters** page contains an overview of the most recent converter readings, enabling the monitoring of the polarization, gain, frequency, and attenuation.
