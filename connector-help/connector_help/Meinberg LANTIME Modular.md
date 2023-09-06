---
uid: Connector_help_Meinberg_LANTIME_Modular
---

# Meinberg LANTIME Modular

Meinberg has a series of modular devices like the M1000, M2000, M3000, etc. for which this connector applies. These devices are NTP time servers that have an integrated reference clock.

The **Meinberg LANTIME Modular** connector displays both status and configuration information for the device and can be used to configure it.

## About

### Version Info

| **Range**            | **Key Features** | **Based On** | **System Impact**                                                                               |
|----------------------|------------------|--------------|-------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version. | \-           | Minimum required DataMiner version is **10.0.0.0 - 9118** due to SLManagedScripting C#7 syntax. |
| 1.0.1.x \[SLC Main\] | Dynamic units.   | 1.0.0.2      | Minimum required DataMiner version is **10.0.9.0 - 9385** due to dynamic units.                 |

### Product Info

| **Range** | **Supported Firmware** | **REST API Version** |
|-----------|------------------------|----------------------|
| 1.0.0.x   | 7.04.x                 | 8.x.y                |
| 1.0.1.x   | 7.04.x                 | 8.x.y                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       | **Exported Components**                                                                                                              |
|-----------|---------------------|-------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | DataMiner connectors:[Meinberg LANTIME IMS-BPE](/Driver%20Help/Meinberg%20LANTIME%20IMS-BPE.aspx)[Meinberg LANTIME IMS-CPE](/Driver%20Help/Meinberg%20LANTIME%20IMS-CPE.aspx)[Meinberg LANTIME IMS-ESI](/Driver%20Help/Meinberg%20LANTIME%20IMS-ESI.aspx)[Meinberg LANTIME IMS-FDM](/Driver%20Help/Meinberg%20LANTIME%20IMS-FDM.aspx)[Meinberg LANTIME IMS-GNM](/Driver%20Help/Meinberg%20LANTIME%20IMS-GNM.aspx)[Meinberg LANTIME IMS-GNS](/Driver%20Help/Meinberg%20LANTIME%20IMS-GNS.aspx)[Meinberg LANTIME IMS-GNS-UC](/Driver%20Help/Meinberg%20LANTIME%20IMS-GNS-UC.aspx)[Meinberg LANTIME IMS-GPS](/Driver%20Help/Meinberg%20LANTIME%20IMS-GPS.aspx)[Meinberg LANTIME IMS-HPS](/Driver%20Help/Meinberg%20LANTIME%20IMS-HPS.aspx)[Meinberg LANTIME IMS-LIU](/Driver%20Help/Meinberg%20LANTIME%20IMS-LIU.aspx)[Meinberg LANTIME IMS-LNO](/Driver%20Help/Meinberg%20LANTIME%20IMS-LNO.aspx)[Meinberg LANTIME IMS-MRI](/Driver%20Help/Meinberg%20LANTIME%20IMS-MRI.aspx)[Meinberg LANTIME IMS-PIO](/Driver%20Help/Meinberg%20LANTIME%20IMS-PIO.aspx)[Meinberg LANTIME IMS-PZF](/Driver%20Help/Meinberg%20LANTIME%20IMS-PZF.aspx)[Meinberg LANTIME IMS-REL](/Driver%20Help/Meinberg%20LANTIME%20IMS-REL.aspx)[Meinberg LANTIME IMS-RSC](/Driver%20Help/Meinberg%20LANTIME%20IMS-RSC.aspx)[Meinberg LANTIME IMS-SCG](/Driver%20Help/Meinberg%20LANTIME%20IMS-SCG.aspx)[Meinberg LANTIME IMS-TCR](/Driver%20Help/Meinberg%20LANTIME%20IMS-TCR.aspx)[Meinberg LANTIME IMS-VSG](/Driver%20Help/Meinberg%20LANTIME%20IMS-VSG.aspx)[Meinberg LANTIME IMS-VSI](/Driver%20Help/Meinberg%20LANTIME%20IMS-VSI.aspx) | DataMiner connector:[Meinberg LANTIME Modular - SyncMon Node](xref:Connector_help_Meinberg_LANTIME_Modular_-_SyncMon_Node) |
| 1.0.1.x   | No                  | Yes                     | DataMiner connectors:[Meinberg LANTIME IMS-BPE](/Driver%20Help/Meinberg%20LANTIME%20IMS-BPE.aspx)[Meinberg LANTIME IMS-CPE](/Driver%20Help/Meinberg%20LANTIME%20IMS-CPE.aspx)[Meinberg LANTIME IMS-ESI](/Driver%20Help/Meinberg%20LANTIME%20IMS-ESI.aspx)[Meinberg LANTIME IMS-FDM](/Driver%20Help/Meinberg%20LANTIME%20IMS-FDM.aspx)[Meinberg LANTIME IMS-GNM](/Driver%20Help/Meinberg%20LANTIME%20IMS-GNM.aspx)[Meinberg LANTIME IMS-GNS](/Driver%20Help/Meinberg%20LANTIME%20IMS-GNS.aspx)[Meinberg LANTIME IMS-GNS-UC](/Driver%20Help/Meinberg%20LANTIME%20IMS-GNS-UC.aspx)[Meinberg LANTIME IMS-GPS](/Driver%20Help/Meinberg%20LANTIME%20IMS-GPS.aspx)[Meinberg LANTIME IMS-HPS](/Driver%20Help/Meinberg%20LANTIME%20IMS-HPS.aspx)[Meinberg LANTIME IMS-LIU](/Driver%20Help/Meinberg%20LANTIME%20IMS-LIU.aspx)[Meinberg LANTIME IMS-LNO](/Driver%20Help/Meinberg%20LANTIME%20IMS-LNO.aspx)[Meinberg LANTIME IMS-MRI](/Driver%20Help/Meinberg%20LANTIME%20IMS-MRI.aspx)[Meinberg LANTIME IMS-PIO](/Driver%20Help/Meinberg%20LANTIME%20IMS-PIO.aspx)[Meinberg LANTIME IMS-PZF](/Driver%20Help/Meinberg%20LANTIME%20IMS-PZF.aspx)[Meinberg LANTIME IMS-REL](/Driver%20Help/Meinberg%20LANTIME%20IMS-REL.aspx)[Meinberg LANTIME IMS-RSC](/Driver%20Help/Meinberg%20LANTIME%20IMS-RSC.aspx)[Meinberg LANTIME IMS-SCG](/Driver%20Help/Meinberg%20LANTIME%20IMS-SCG.aspx)[Meinberg LANTIME IMS-TCR](/Driver%20Help/Meinberg%20LANTIME%20IMS-TCR.aspx)[Meinberg LANTIME IMS-VSG](/Driver%20Help/Meinberg%20LANTIME%20IMS-VSG.aspx)[Meinberg LANTIME IMS-VSI](/Driver%20Help/Meinberg%20LANTIME%20IMS-VSI.aspx) | DataMiner connector:[Meinberg LANTIME Modular - SyncMon Node](xref:Connector_help_Meinberg_LANTIME_Modular_-_SyncMon_Node) |

## Configuration

### Connections

*HTTP Main Connection*This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host:** The polling IP or URL of the destination.
- **IP port:** The IP port of the destination.
- **Bus address:** If the proxy server has to be bypassed, specify *bypassproxy*.

### Initialization

#### REST API

The HTTP communication uses a REST API, which needs to be enabled.On the device's web interface, make sure the **Enable REST API** option is selected under the **general settings** on the **System** page.

#### HTTP Credentials

The HTTP communication will not be up and running until the necessary HTTP credentials have been provided.On the **Credentials** page of the element, the **user name** and **password** must be configured.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

REST (Representational State Transfer) calls are used to retrieve the device information

### HTTP Communication

On the **HTTP Communication** page, you can track the HTTP sessions used for communicating with the device.This makes it possible to follow the communication flow and provides some useful statistics, e.g. request time, response time, time span (RTT), etc.

- **HTTP Sessions State**: If you enable this setting, the active HTTP sessions will be tracked.
- **HTTP Sessions Max Count**: This determines the maximum number of HTTP sessions that will be tracked.

### Inter App

On the **Inter App** page, an overview is provided that allows you to track the inter application communication and the related handlers.

#### Inter App Communication

Overview of the inter application communication events and messages.

The state of a communication object indicates whether it is waiting to be processed, being processed, executed successfully, or failed.

#### Inter App Handlers

Overview of the inter application handlers of the received events and messages.

Every communication object is represented by a related handler. The handler is responsible for taking the necessary actions depending on the related communication object.
