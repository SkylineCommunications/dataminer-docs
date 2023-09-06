---
uid: Connector_help_WorldCast_Systems_APT_AoIP
---

# WorldCast Systems APT AoIP

This connector can be used to monitor a WorldCast Systems APT AoIP device.

## About

### Version Info

| **Range**            | **Key Features**                    | **Based on** | **System Impact**                               |
|----------------------|-------------------------------------|--------------|-------------------------------------------------|
| 1.0.0.x \[Obsolete\] | Initial version                     | \-           | \-                                              |
| 1.0.1.x \[SLC Main\] | Removed Unit Temperature parameter. | 1.0.0.2      | Unit Temperature parameter no longer available. |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to Use

The element displays information about the device on multiple pages and subpages:

- **General**: Displays general information such as the CPU load, software revision, and device name

- **Status**: Displays the connection status of the device. Links to the following subpages:

- **GPIO**: Displays information about output relays and optic inputs.
  - **Network**: Displays information about the available Ethernet ports and the firewall rules, among others.
  - **Performance**: Displays information about the audio levels and the ongoing streams.
  - **Audio Codec**: Displays information about the audio codecs in use.

- **Configuration**: Links to the following subpages:

- **Connection**: Displays information about the active profile in use.
  - **Audio**: Contains audio, advanced routing, and audio alarm information.
  - **Aux Relay**: Contains information about baud rates, relay control modes, input sources, etc.
  - **Streams**: Indicates which streams are active.
  - **Alarms**: Contains information about alarms of the device.
