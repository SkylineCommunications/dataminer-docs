---
uid: Connector_help_Mist_WLAN_Platform
---

# Mist WLAN Platform

This connector is used to interact with the Mist WLAN Platform. This is an online platform for the managing and monitoring of one or multiple WLANs comprised of multiple access points and/or BLE beacons.

The connector uses the Mist WLAN Platform API to retrieve information about the different entities that make up the WLANs.

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

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**   |
|-----------|---------------------|-------------------------|-----------------------|---------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | Mist WLAN Platform - Site |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The URL of the Mist API; this should be set to "*admin.mist.com*".
- **IP port**: The IP port used to communicate with the API, by default set to *443*.

### Initialization

After the element is created, the **credentials** used to log in to the Mist WLAN Platform have to be entered on the **Configuration** page of the connector.

### Redundancy

Redundancy is not defined in the connector.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

When the correct credentials have been entered on the **Configuration** page of the connector, a **login request** will be sent to the Mist WLAN Platform API. The connector will periodically request the sites that the user has access to. The information from all the devices from each site will be requested and stored in DataMiner.

Webhooks can be configured on the **Configuration** page under the **Webhooks** section. Webhooks are notifications sent from the Mist WLAN Platform to the connector. When this feature is enabled, a local web service will be hosted, which listens to incoming notifications. To enable webhooks:

1. Choose a URI. This is the local endpoint that the web service will listen to.
1. Specify a port and choose the protocol.
1. If you have set the protocol to HTTPS, select a certificate in order to set up the connection.
1. Start the web service by setting the status to *enabled*.

Currently only location and device-events webhooks are supported. When a location webhook is received, the Time Since Last Location Event of the site will be reset. In case of a device-event, the device in question will be repolled.

Note that **webhooks have to be enabled on the Mist WLAN Platform** and that the webhooks **URL on the platform has to** **match the Web Service Listen URI** of the connector.
