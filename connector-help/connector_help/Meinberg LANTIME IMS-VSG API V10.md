---
uid: Connector_help_Meinberg_LANTIME_IMS-VSG_API_V10
---

# Meinberg LANTIME IMS-VSG API V10

The **VSG** is used as a video signal reference for studio equipment and provides the generated signals at four BNC outputs. These are Bi-Level Sync (Black Burst) / Tri-Level Sync, Longitudinal Time and Control Code (LTC), Digital Audio Out (DARS), and Word Clock.

The VSG is synchronized by an external 10 MHz signal, 1 PPS, and a time telegram, which provides the connected reference receiver. These signals determine the accuracy of the output signals. The generated video signals, in different formats, have a phase reference to the 1 PPS.

In order to be able to provide high-precision output signals during the switchover of the RSC (IMS systems with redundant receivers), the VSG has its own oscillator.

## About

### Version Info

| **Range**            | **Key Features** | **Based On** | **System Impact**                                                                               |
|----------------------|------------------|--------------|-------------------------------------------------------------------------------------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | Minimum required DataMiner version is **10.0.0.0 - 9118** due to SLManagedScripting C#7 syntax. |

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

REST, Representational State Transfer, calls are used to retrieve the device information.

### HTTP Communication

On the **HTTP Communication** page, you can track the HTTP sessions used for communicating with the device.This makes it possible to follow the communication flow and provides some useful statistics, e.g. request time, response time, time span (RTT), etc.

- **HTTP Sessions State:** If you enable this setting, the active HTTP sessions will be tracked.
- **HTTP Sessions Max Count:** This determines the maximum number of HTTP sessions that will be tracked.
