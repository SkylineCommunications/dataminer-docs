---
uid: Connector_help_TeamCast_Tyger
---

# TeamCast Tyger

This protocol allows you to monitor the activity of the TeamCast Tyger satellite modulator. This modulator covers the full L-Band range and allows bit rates from 1 Mbps up to 2 Gbps with a symbol rate from 1 to 480 MBauds. It uses 8 ASI, 4x1GigE and 2x10GigE ports as inputs and accepts many different input formats.

Communication with the device happens via SNMP.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**            |
|-----------|-----------------------------------|
| 1.0.0.x   | Hw version: 128; Sw version: 1104 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: The device address.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device (default: public).
- **Set community string**: The community string used when setting values on the device (default: private).

### Web Interface

The web interface is only accessible when the client machine has network access to the product

## How to Use

The element created with this protocol consists of the following data pages:

- **General**: Displays version and configuration information, including information about the **Ethernet** connections.
- **Polling**: Allows you to enable/disable polling for specific pages of the element.
- **Configuration**: Contains numerous configuration settings.
- **Profiles**: Displays information about the device profiles.
- **Monitoring**: Displays status information for the different components of the device.
- **TSoIP**: Displays the status and settings of each of the TSoIP inputs.
- **GSE**: Displays the status and settings of each of the GSE inputs.
- **Carrier ID**: Displays information about the carrier.
- **Alarms**: Allows you to check the status of alarms. On subpages, each of the alarms can be configured.
