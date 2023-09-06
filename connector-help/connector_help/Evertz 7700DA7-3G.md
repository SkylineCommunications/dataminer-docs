---
uid: Connector_help_Evertz_7700DA7-3G
---

# Evertz 7700DA7-3G

The Evertz 7700DA7-3G is a 3G/HD/SD-SDI reclocking distribution amplifier, which fits into a 7700/7800/570 frame. It is used for distribution of SMPTE ST 424, ST 292-1, and SMPTE SST259-1 serial digital video signals, with speed rates of 3 GB/s, 1.5 GB/s and 270 MB/s.

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

#### SNMP Connection - Main

This connector uses an SNMP connection and requires the following input during element creation:

SNMP CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: Default: *161.*
  - **Device Address**: The slot ID of the card.

### Initialization

No additional configuration of parameters is necessary.

### Redundancy

There is no redundancy defined.

## How to use

Once the element has been created, the **General** page will display all metrics.
