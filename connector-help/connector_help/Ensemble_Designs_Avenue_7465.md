---
uid: Connector_help_Ensemble_Designs_Avenue_7465
---

# Ensemble Designs Avenue 7465

The 7465 Sync Changeover Switch module is a fail-safe protection switch for monitoring and switching critical sync reference signals. It can be used with Avenue's 7400 SPG module, or with third-party sync pulse generators. In the event of a failure of the primary sync source, the 7465 changes to the secondary source.

There are three poles or sections on the 7465. One pole tests for HD SDI and SD SDI signals. The other two poles test for AES audio, composite video, bi-level sync and tri-level sync. A drop in signal amplitude below a predetermined auto threshold will trigger the switch.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.2.3                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

## Usage

### General

This page shows the overall status of the primary and secondary channels, including the ganged channels (if present and enabled). Status indicators for each channel are colored as follows: Green = Good, Red = Faulted, Gray = Not enabled.

On the right, the **Primary Status** and **Secondary Status** parameters indicate the channel status (Good or Failed).

The **Switch Position** indicates *Primary* or *Secondary* to reflect which input is feeding the output.

**Auto Reset** and **Reset Time** controls for the switching function are also available, as well as a subpage for each of the slot modules.

### Signals

This page shows the status of each of the primary and secondary A, B and C channels.

### Config

This page allows you to configure the signal type to be detected for each of the three channels.

### Gang

This page allows you to configure the 7465 module to operate in ganged mode in conjunction with another 7465 module in an Avenue frame on the same AveNet network.

Up to four modules can be ganged together to take full advantage of protection for up to twelve signals. For gang operation, one of the modules is configured as the master and the others are configured as slaves. The master module makes all decisions about switching based on the signal status from its inputs and those from the slave modules. Channel A, B and C status signals from the slave modules are reported back to the master module and indicated with the Slave Status indicators in the Gang menu.

### Diag

On this page, the **Secondary Switch Count** reports the number of times that the module has switched from the primary to the secondary signal.
