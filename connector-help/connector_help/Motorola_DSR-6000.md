---
uid: Connector_help_Motorola_DSR-6000
---

# Motorola DSR-6000

The Motorola DSR-6000 is an integrated receiver decoder (IRD) or radio, designed for broadcasters and headend operators to receive digital satellite services.

The DSR-6000 unit will process both high-definition and standard-definition video services.

After the DSR-6000 unit is properly configured, it is ready to receive authorization and control information from the satellite operator.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 0x1EE.05               |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during creation:

SNMP CONNECTION:

- **IP address/host:** The polling IP of the device.

SNMP Settings:

- **Port number:** The port of the connected device, by default *161*.
- **Get community string:** The community string used when reading values from the device, by default *public*.
- **Set community string:** The community string used when setting values on the device, by default *private*.

#### HTTP Connection

The driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host:** The polling IP or URL of the destination.
- **IP port:** The IP port of the destination.
- **Bus address:** If the proxy server has to be bypassed, specify *bypassproxy*.

### Initialization

The HTTP credentials, i.e. the username and password, need to be provided in a newly created element.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The SNMP connection is used to read and set device settings.

The HTTP connection is used both to read the system log and to retune the event log.
