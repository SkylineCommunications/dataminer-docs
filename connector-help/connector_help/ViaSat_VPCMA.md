---
uid: Connector_help_ViaSat_VPCMA
---

# ViaSat VPCMA

This connector is used to monitor the ViaSat VPCMA device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.1.7                  |

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

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default value: *public*).
- **Set community string**: The community string used when setting values on the device (default value: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

No extra configuration is needed.

## How to Use

The connector uses the **SNMP** protocol to retrieve data from the device.

The **General** page lists the device info and the main status parameters (Lock, SNR, etc.).

On the **Setup** page, you can modify the settings of the device (Cancellation Bandwidth, Output Power Mode, etc.).

On the **Diagnostics** page, you can run tests on the device. Three kinds of tests are available: **Built-in Test**, **Continuous Wave** and **Pass Through**.

The **Alarms** page lists all the alarms active on the device.

The **Traps** page contains the **Traps Table**, which lists the most recent traps received by the device.
