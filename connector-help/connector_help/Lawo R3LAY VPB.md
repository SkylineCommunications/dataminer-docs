---
uid: Connector_help_Lawo_R3LAY_VPB
---

# Lawo R3LAY VPB

VPB (Virtual Patch Bay) is a PC-based audio router with mixing functionality and integrated VST audio processing engine, which manages all audio streams on a Windows PC and can "see" all audio hardware interfaces and audio software clients.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

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

#### Serial Connection - IP Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

<!-- -->

- **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device (default: 9001).

### Redundancy

There is no redundancy defined.

## How to Use

This connector uses EmberPlus. It first discovers all the possible nodes and puts them in the Ember tree. If some nodes are not available during the initial discovery, they will be discovered in the next timer sequence.

You can trigger manual discovery of nodes by clicking **Start Node Discovery** on the **General** page. This will discover the nodes again if they are available.

Every five seconds, the discovered tables are updated. If a table has not been updated for 30 minutes, this table data will be cleared.
