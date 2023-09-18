---
uid: Connector_help_Meinberg_LANTIME_Modular_API_V10
---

# Meinberg LANTIME Modular API V10

Meinberg has a series of modular devices like the M1000, M2000, M3000, etc. for which this connector applies. These devices are NTP time servers that have an integrated reference clock.

The **Meinberg LANTIME Modular** connector displays both status and configuration information for the device and can be used to configure it.

## About

### Version Info

| **Range**            | **Key Features** | **Based On** | **System Impact**                                                               |
|----------------------|------------------|--------------|---------------------------------------------------------------------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | Minimum required DataMiner version is **10.0.9.0 - 9385** due to dynamic units. |

### Product Info

| **Range** | **Supported Firmware** | **REST API Version** |
|-----------|------------------------|----------------------|
| 1.0.0.x   | 7.06.x                 | 10.x.y               |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          | **Exported Components**                                                                                                                                   |
|-----------|---------------------|-------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | DataMiner protocols:<br>- [Meinberg LANTIME IMS-BPE API V10](xref:Connector_help_Meinberg_LANTIME_IMS-BPE_API_V10)<br>- [Meinberg LANTIME IMS-CPE API V10](xref:Connector_help_Meinberg_LANTIME_IMS-CPE_API_V10)<br>- [Meinberg LANTIME IMS-ESI API V10](xref:Connector_help_Meinberg_LANTIME_IMS-ESI_API_V10)<br>- [Meinberg LANTIME IMS-FDM API V10](xref:Connector_help_Meinberg_LANTIME_IMS-FDM_API_V10)<br>- [Meinberg LANTIME IMS-GNM API V10](xref:Connector_help_Meinberg_LANTIME_IMS-GNM_API_V10)<br>- [Meinberg LANTIME IMS-GNS API V10](xref:Connector_help_Meinberg_LANTIME_IMS-GNS_API_V10)<br>- [Meinberg LANTIME IMS-GNS-UC API V10](xref:Connector_help_Meinberg_LANTIME_IMS-GNS-UC_API_V10)<br>- [Meinberg LANTIME IMS-GPS API V10](xref:Connector_help_Meinberg_LANTIME_IMS-GPS_API_V10)<br>- [Meinberg LANTIME IMS-HPS API V10](xref:Connector_help_Meinberg_LANTIME_IMS-HPS_API_V10)<br>- [Meinberg LANTIME IMS-LIU API V10](xref:Connector_help_Meinberg_LANTIME_IMS-LIU_API_V10)<br>- [Meinberg LANTIME IMS-LNO API V10](xref:Connector_help_Meinberg_LANTIME_IMS-LNO_API_V10)<br>- [Meinberg LANTIME IMS-MRI API V10](xref:Connector_help_Meinberg_LANTIME_IMS-MRI_API_V10)<br>- [Meinberg LANTIME IMS-PIO API V10](xref:Connector_help_Meinberg_LANTIME_IMS-PIO_API_V10)<br>- [Meinberg LANTIME IMS-PZF API V10](xref:Connector_help_Meinberg_LANTIME_IMS-PZF_API_V10)<br>- [Meinberg LANTIME IMS-REL API V10](xref:Connector_help_Meinberg_LANTIME_IMS-REL_API_V10)<br>- [Meinberg LANTIME IMS-RSC API V10](xref:Connector_help_Meinberg_LANTIME_IMS-RSC_API_V10)<br>- [Meinberg LANTIME IMS-SCG API V10](xref:Connector_help_Meinberg_LANTIME_IMS-SCG_API_V10)<br>- [Meinberg LANTIME IMS-TCR API V10](xref:Connector_help_Meinberg_LANTIME_IMS-TCR_API_V10)<br>- [Meinberg LANTIME IMS-VSG API V10](xref:Connector_help_Meinberg_LANTIME_IMS-VSG_API_V10)<br>- [Meinberg LANTIME IMS-VSI API V10](xref:Connector_help_Meinberg_LANTIME_IMS-VSI_API_V10) | DataMiner connector:<br>- [Meinberg LANTIME Modular API V10 - SyncMon Node](xref:Connector_help_Meinberg_LANTIME_Modular_API_V10_-_SyncMon_Node) |

## Configuration

### Connections

*HTTP Main Connection
*This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host:** The polling IP or URL of the destination.
- **IP port:** The IP port of the destination.
- **Bus address:** If the proxy server has to be bypassed, specify *bypassproxy*.

### Initialization

#### REST API

The HTTP communication uses a REST API, which needs to be enabled.
On the device's web interface, make sure the **Enable REST API** option is selected under the **general settings** on the **System** page.

#### HTTP Credentials

The HTTP communication will not be up and running until the necessary HTTP credentials have been provided.
On the **Credentials** page of the element, the **user name** and **password** must be configured.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

REST (Representational State Transfer) calls are used to retrieve the device information

### HTTP Communication

On the **HTTP Communication** page, you can track the HTTP sessions used for communicating with the device.
This makes it possible to follow the communication flow and provides some useful statistics, e.g. request time, response time, time span (RTT), etc.

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
