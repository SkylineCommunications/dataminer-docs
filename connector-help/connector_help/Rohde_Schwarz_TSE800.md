---
uid: Connector_help_Rohde_Schwarz_TSE800
---

# Rohde Schwarz TSE800

The R&S TSE800 is a TV transmitter system extension that offers features such as program-specific coding and error protection by means of a Physical Layer Pipe (PLP) in the transport stream. It also has MISO (multiple input, single output) applications with multiple input paths using the Alamouti algorithm, and it has further options for configuring FFT and FEC parameters.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.47.6                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *172.16.61.11*.
- **IP port**: 161

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

## How to use

### General page

The General page provides information related to the system of the device.

### Product Information page

The Product Information page provides the software and hardware information of the device.

This page also has a subsection with more information and device settings.

### Input pages

These pages display the different input data and configurations of the device.

### Other pages

Other pages include various tables with data and settings, including commands, status information, etc.
