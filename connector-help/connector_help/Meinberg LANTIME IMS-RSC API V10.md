---
uid: Connector_help_Meinberg_LANTIME_IMS-RSC_API_V10
---

# Meinberg LANTIME IMS-RSC API V10

The **RSC** module is required for redundant clock module configurations. It switches the synchronization signals from the selected clock module of the IMS backplane. (Most I/O modules use these backplane signals to generate their output signals.) A phase-neutral switchover is available for **LIU** output cards, avoiding phase jumps for telecommunication signals (E1/T1).

The RSC can be configured to automatically switch between the two clock modules based on their status, but it is also possible to manually select the clock module using the selection switches.

## About

### Version Info

| **Range**            | **Key Features** | **Based On** | **System Impact**                                                                               |
|----------------------|------------------|--------------|-------------------------------------------------------------------------------------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | Minimum required DataMiner version is **10.0.0.0 - 9118** due to SLManagedScripting C#7 syntax. |

### Product Info

| **Range** | **Supported Firmware** | **REST API Version** |
|-----------|------------------------|----------------------|
| 1.0.0.x   | 7.06.x                 | 10.x.y               |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                                                                |
|-----------|---------------------|-------------------------|----------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | DataMiner connector:[Meinberg LANTIME Modular API V10](xref:Connector_help_Meinberg_LANTIME_Modular_API_V10) |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host:** The polling IP or URL of the destination.
- **IP port:** The IP port of the destination.
- **Bus address:** If the proxy server has to be bypassed, specify *bypassproxy*.

### Initialization

#### Slot ID

The DataMiner element will not know which slot it needs to represent until the slot ID has been provided.On the **General** page, the **slot ID** must be configured.

#### REST API

The HTTP communication uses a REST API, which needs to be enabled.On the device's web interface, make sure the **Enable REST API** option is selected under the **general settings** on the **System** page.

#### HTTP Credentials

The HTTP communication will not be up and running until the necessary HTTP credentials have been provided.On the **Credentials** page of the element, the **user name** and **password** must be configured.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

REST (Representational State Transfer) calls are used to retrieve the device information.

### HTTP Communication

On the **HTTP Communication** page, you can track the HTTP sessions used for communicating with the device.This makes it possible to follow the communication flow and provides some useful statistics, e.g. request time, response time, time span (RTT), etc.

- **HTTP Sessions State:** If you enable this setting, the active HTTP sessions will be tracked.
- **HTTP Sessions Max Count:** This determines the maximum number of HTTP sessions that will be tracked.
