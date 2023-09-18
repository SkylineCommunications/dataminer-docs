---
uid: Connector_help_EATON_Power_Xpert_Gateway_PDP
---

# EATON Power Xpert Gateway PDP

The Power Xpert Gateway PDP card is a data acquisition solution for Eaton power distribution units (PDUs), remote power panels (RPPs), rack power modules (RPMs), power distribution racks (PDRs), and energy management system upgrade kits (EMSs).

Via SNMP communication, this connector retrieves the necessary information from the card so that you can monitor its state, behavior, etc.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created using this connector shows several pages with information from the device:

- **General**: Contains information about the general conditions of the device.
- **Entity**: Contains two tables with the physical and operational information of the entities.
- **Alarms**: Contains information about the active alarms on the device.
- **Digital Inputs**
- **Panels**: Contains information related to the ratings and meters of the available panels.
- **Breakers**: Contains information related to the ratings, meters, and phase meters of the available breakers.
- **Meter Demand Measures**
- **Contact**: Contains contacts information.
