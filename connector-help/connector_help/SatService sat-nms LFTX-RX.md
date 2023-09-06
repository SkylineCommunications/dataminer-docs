---
uid: Connector_help_SatService_sat-nms_LFTX-RX
---

# SatService sat-nms LFTX-RX

This connector allows you to monitor the SatService sat-nms LFTX-RX, which is fiber-optic link equipment.

Based on the type of unit, extra pages linked to the slave device can be hidden or displayed.

## About

### Version Info

| **Range**            | **Key Features**  | **Based on** | **System Impact** |
|----------------------|-------------------|--------------|-------------------|
| 1.0.0.x              | Initial version   | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Added DCF support | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.1.027 2012-09-11     |
| 1.0.1.x   | 2.1.027 2012-09-11     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection (version 1) and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the master chassis.

SNMP Settings:

- **IP port**: 161, UDP.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Initialization

No extra configuration is needed.

### Redundancy

Redundancy can be configured on the equipment via the **Setup** page.

### Web Interface

The web interface is only accessible when the client machine has network access to the product, via the **Redundancy Settings** page.

## How to Use

The connector retrieves the type of the unit. Based on this, the pages related to the slave device will be hidden or visible. In case the unit is of type *Single,* the slave pages are hidden.

In case of a redundant chassis, it is only necessary to create one element for the master chassis. The connector will automatically poll data from both the master and slave chassis and display it on the corresponding data pages.

Both chassis (master and slave) have a read-only data page, e.g. **Master Chassis**, and a page where settings can be viewed and configured, e.g. **Master Chassis Config**. The **attenuator** value is displayed on both pages and can be changed on the config page.

The **Setup** page contains the settings needed to configure redundancy on the equipment.
