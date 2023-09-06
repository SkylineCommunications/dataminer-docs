---
uid: Connector_help_Atlassian_OpsGenie
---

# Atlassian Opsgenie

This driver allows the integration of DataMiner with the Atlassian Opsgenie Alert Management Platform. The driver can receive messages formatted as Opsgenie alerts from a combination of a Correlation alarm and Automation script and will process and send these alerts to the Opsgenie platform. The Automation script translates DataMiner alarms into Opsgenie alerts and sends them to the Opsgenie driver for submission to the Opsgenie platform.

The driver will handle the authentication using an Opsgenie integration key. This version is designed to work with the Enterprise version of Opsgenie.

## About

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**        |
|-----------|-------------------------------|
| 1.0.0.x   | Opsgenie Alerts API version 2 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: https://api.opsgenie.com
- **IP port**: 443
- **Bus address**: *ByPassProxy*

### Initialization

The driver requires the integration key for authentication purposes. It can be set on the **General** page using the **API Key** parameter. The format should be "GenieKey \[key\]".

The integration key can be found on the Opsgenie web interface.

### Redundancy

No redundancy is defined in the driver.

## How to Use

In order to use the driver, first configure the **API Key** in order to enable authentication. At regular intervals, the driver will retrieve the available **Teams** from the **Opsgenie** platform.

The driver can receive DataMiner-generated Opsgenie alerts, place these in a queue, and send them to the Opsgenie platform. In case there is an error with a particular alert, it will remain in the queue with an error status and a description of the error. Successfully sent alerts, which have received confirmation from the platform, will be set to a completed state and cleared from the queue.

The driver communicates with the Opsgenie platform using JSON APIs, the **Alert API** and the **Team API**. It receives serialized alert messages from DataMiner Automation scripts. A custom Correlation rule is also required.

The element created using this driver has the following data pages:

- **General**: Allows you to specify the **API Key** used for authentication.
- **Teams**: Displays the **Opsgenie Teams** table, listing the available Teams in the Opsgenie platform.
- **Messages**: Displays the **Opsgenie Operations** table, containing the message queue with the current message, **State**, **Result** and **Alert** content. The **Clear Table** button allows you to manually clear the messages that are in an error state.
