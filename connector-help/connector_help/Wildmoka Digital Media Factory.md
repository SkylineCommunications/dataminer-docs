---
uid: Connector_help_Wildmoka_Digital_Media_Factory
---

# Wildmoka Digital Media Factory

Wildmoka offers cloud-based solutions to edit and broadcast videos both live and on demand. Its platform makes it possible to create a large variety of content such as live footage, highlights, match summaries, and replays for digital providers.

The Wildmoka Digital Media Factory connector allows you to communicate with the Wildmoka external API.

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported API**                                                                                                                                                                                                                                            |
|-----------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | Every action you request is versioned, so you can check which version of the API you are querying at any point in time for any request (for example: https://{{sub_domain}}.wildmoka.com/eapis/**2.0**/event). Most of the API calls follow the 2.0 version. |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device. e.g. *192.168.1.2*.
- **IP port**: IP port of the device. By default *443* because HTTPS is used.
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

On the **Configuration** page, add the **Username** and **Private Key** to establish a connection with the API using the correct HMAC authentication credentials.

## How to use

The **General** page of this connector shows a quick overview of the latest action that has been performed (creation, updating, or deletion of events, etc.). The Status parameter shows if the action was successful or if it failed. In case an action fails and the API response contains additional information, details are displayed explaining why the operation was not possible. It this information is not included in the API response, the details will show N/A.

On the **Streams**, **Users**,and **Templates** pages, you can monitor all the available resources. No create and update features are available for these.

On the **Events** page, you can select the time range of searched events (the maximum is a time interval of 2 months). Via the right-click menu of the table you can add and delete events; however, note that events can only be deleted if they have the Pending state.

You can update individual fields in an event, except the **live** features in case the **Live Publication Exists column** is **disabled** during the event's creation.
