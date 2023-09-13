---
uid: Connector_help_Calrec_Artemis
---

# Calrec Artemis

This connector is used to monitor a Calrec Artemis device. This device is a remote production solution for audio consoles that use Ember+.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *62001*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The connector sends requests for all parameters it wants to poll and listens to all incoming messages. It filters and processes the useful messages. This information is then displayed on its designated page in the DataMiner element.
