---
uid: Connector_help_Grass_Valley_Orbit
---

# Grass Valley Orbit

This connector gives access to the GV Orbit monitoring data, using the Alarm API. It shows the current state of all Grass Valley equipment, including IQ modular, Densite, multiviewers, etc.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**             |
|-----------|------------------------------------|
| 1.0.0.x   | GV Orbit Alarm API (version 1.0.0) |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                                |
|-----------|---------------------|-------------------------|-----------------------|----------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | [Grass Valley Orbit - Device](xref:Connector_help_Grass_Valley_Orbit_-_Device) |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

## Note

Within a GV Orbit system, alarms are grouped into collections based around a device (sometimes called a "Unit"). Devices may be physical, such as a modular card, or virtual, such as a categorized alarm.

Devices are identified by a path, which may be a virtual Linux-style file system path (typical on Densite/iControl equipment) or a RollCall address in the format NNNN:UU:PP. The RollCall address has a logical path built in and can therefore be resolved to a path in a network tree.
