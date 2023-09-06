---
uid: Connector_help_EVS_Neuron_Chassis
---

# EVS Neuron Chassis

The EVS Neuron Chassis is the chassis of the Axon Neuron NPG3200.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.0.13                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Main Connection - Serial

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: 2072

## How to Use

The connector does not have a polling timer. It only polls the data at element startup or when polling is triggered manually via a button in the element.

After element startup, the connector enables the reception of events (unsolicited messages).
