---
uid: Connector_help_Imagine_Communications_Magellan_SDNO_Controller
---

# Imagine Communications Magellan SDNO Controller

Imagine Communications' Software-Defined Networking (SDN) framework is a hybrid approach that facilitates the seamless integration of IP technology with SDI systems. It provides the necessary tools to gradually migrate current SDI-based infrastructures to IP-based technology in phases, while enabling you to maintain operational and workflow integrity in a hybrid environment.

## About

### Version Info

| **Range**            | **Key Features**                       | **Based on** | **System Impact**                                                                                                                       |
|----------------------|----------------------------------------|--------------|-----------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                       | \-           | This implementation is considered obsolete. Please use Imagine Communications LRC instead.                                              |
| 2.0.0.x \[SLC Main\] | Support for REST API and LRC protocol. | \-           | This implementation uses the REST API as the main source of information and uses LRC for information not yet available on the REST API. |

### Product Info

| **Range** | **Supported Firmware**                                  |
|-----------|---------------------------------------------------------|
| 1.0.0.x   | 2.9.2.r1.588                                            |
| 2.0.0.x   | REST API SDNO Controller 3.6 Logical Router Control 1.5 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *52116*).

#### HTTP Connection

This driver uses an HTTP Rest API connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: 80).

### Initialization

The **Poll Configuration** page allows you to specify which information should be retrieved from the REST API and from LRC. Polling is only done on startup or on demand. The source/destination information will be updated with LRC notifications.

Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The element created with this connector has the following data pages:

- **General**: Shows general information from the active database, such as the version, the number of levels, the number of sources, and the number of destinations. Also allows you to specify whether information events should be generated when the Destinations table is updated.
- **Poll Configuration**: Allows you to customize the polling of the REST API and the LRC. Polling will only be done on startup or timeout, or can be triggered manually. The rest of the time the information will be updated based on LRC update notifications.
- **Devices**: Contains device information retrieved from the REST API. You can also configure the device-related endpoint. The endpoint information will be used by the sources and destinations.
- **Sources**: Contains source information on channel level. The information is mainly based on the REST API and updated based on LRC.
- **Destinations**: Contains destination information on channel level. The information is mainly based on the REST API and updated based on LRC.
