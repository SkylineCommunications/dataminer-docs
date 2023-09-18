---
uid: Connector_help_PHABRIX_Sx_TAG
---

# PHABRIX Sx TAG

The **PHABRIX Sx** series of instruments are handheld multi-standard test signal generator, analyzer, and monitoring devices.

The **PHABRIX Sx TAG** connector is used to monitor and configure Sx series devices.

## About

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.01.15491             |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### IP Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *2100*).

## How to use

The **General** page contains all the hardware and software information of the device, as well as environmental information such as temperature and power information.

The **Analyser** page contains all the information about the selected video input or output signal such as the source and video standard.
