---
uid: Connector_help_Evertz_7882IRD-S2X-10G
---

# Evertz 7882IRD-S2X-10G

This connector allows you to manage the Evertz 7882IRD-S2X-10G card. It communicates using SNMP and filters the polling per card using subtables.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact**                                                                      |
|----------------------|------------------|--------------|----------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version  | \-           | \-                                                                                     |
| 1.0.1.x              | Initial version  | 1.0.0.2      | Descriptions and parameter placement have changed.                                     |
| 1.0.2.x \[SLC Main\] | Initial version  | 1.0.1.1      | \- Connects to the card directly instead of the frame. - New OIDs for every parameter. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |
| 1.0.1.x   | 2.9.2.r1.588           |
| 1.0.2.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device (range: *1* - *100*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

The connector is designed to poll the information of a single card. The slot position within the frame needs to be configured in the element under the **Device Address**.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

### Range 1.0.0.x/1.0.1.x

The connector will communicate with the frame, but it will only poll information for the card slot defined in the element wizard.

All tables are retrieved via SNMP polling. Traps are currently not implemented for the initial version.

### Range 1.0.2.x

Starting from this range, the element connects to the card directly, so there is no need to define a bus address in the element wizard.
