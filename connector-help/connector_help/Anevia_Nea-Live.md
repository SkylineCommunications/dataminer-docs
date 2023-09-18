---
uid: Connector_help_Anevia_Nea-Live
---

# Anevia Nea-Live

**Anevia Nea-Live** can be used to launch broadcast-quality, full-HD live and time-shifted TV services quickly, securely, and at a predictable cost.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

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

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: public
- **Set community string**: private

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the destination.
- **IP port**: 80.
- **Bus address**: Specify *bypassproxy*.

### Redundancy

Redundancy is not defined in the connector.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The connector allows you to check device information, both at device level and at task level.

HTTP calls are used to retrieve the device information.

SNMP polling is used to retrieve the Hot Spare Unit Status.
