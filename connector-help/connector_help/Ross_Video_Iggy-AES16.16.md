---
uid: Connector_help_Ross_Video_Iggy-AES16.16
---

# Ross Video Iggy-AES16.16

The Iggy-AES16.16 is a live audio-over-IP to AES3 bridge. It provides 16 channels of AES conversion in each direction and supports AES67 / ST 2110-30 Level A, B and C with ST 2022-7 protection switching. IGGY also includes word clock I/O, GPI I/O and Tally.

This DataMiner connector was designed for active monitoring of Iggy's Ethernet I/O, receivers, senders and PTP configuration.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | v.1.0.0-b10            |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

This connector implements the following features:

- PTP monitoring and configuration (clock slave type).
- AES3 input status.
- Ethernet I/O information and status.
- Receivers information and status.
- Senders information and status.
