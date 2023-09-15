---
uid: Connector_help_General_Dynamics_ACU_980
---

# General Dynamics ACU 980

The General Dynamics ACU 980 connector is used for gathering tracking data (azimuth, elevation, polarization) from the primary monitor interface. The Model 980 control systems can be used with almost any full-motion antenna for precision satellite, spacecraft, or celestial tracking applications.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.34.1.2               |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### IP Connection

This connector uses a TCP connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination. (default: *5001*)

### Redundancy

There is no redundancy defined.

## How to use

Every 10 seconds, status parameters such as Azimuth Position, Elevation Position, and Polarization Position are retrieved from the device. You can configure alarm monitoring and trending on these status parameters to keep track of the operation of the ACU.
