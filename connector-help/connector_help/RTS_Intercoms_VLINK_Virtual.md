---
uid: Connector_help_RTS_Intercoms_VLINK_Virtual
---

# RTS Intercom VLINK Virtual

The VLINK Virtual Matrix is a non-blocking, all-software multi-channel/multi-access Intercom over Internet Protocol based on a dedicated server and multiple client architecture. VLINK is engineered for professional, mission-critical communication in broadcast, production, military, aerospace, and government applications.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**  |
|-----------|-------------------------|
| 1.0.0.x   | Server version 6.2.5-52 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The VLINK Virtua requires the URL *http://{{rts}}/api/v1/*.
- **IP port**: The IP default port is 80.

### Initialization

To make sure the connector can work properly, specify the **Username and Password on the General page and click Login**.

## How to Use

The DataMiner connector for the VLINK implements the API calls as per the RTS API documentation to retrieve the general status of the virtual matrix and client statistics. The connector uses the Login method to retrieve an authorization token for further calls.

### General

On the **General** page, login credentials should be specified (see "Initialization"). This page also contains information on which services should be polled with the element. If the specified credentials are correct, the information will be shown in the **Status System** table and the Client Statistics page will be updated as well.

If necessary, you can enter the credentials again and click the Login button to refresh the username and password.

### Configuration

The **Configuration** page contains the information of the IDs that were retrieved from the URL. In the column **Connect Selectors**, you can change the field to any desired selector. The button **Remove Selectors** will clear the previously entered selectors.

Each selector should have the following format: *selectorID-\[listen\|talk\|talk/listen\]*. For example: *1008-listen*.

If you want to add a list of selectors, specify them in the following format: *selector_id1-\[listen\|talk\|talk/listen\], selector_id2-\[listen\|talk\|talk/listen\],.selector_idn-\[listen\|talk\|talk/listen\]*.

When a selector is set in the column **Connect Selectors**, that selector will appear in the element with that ID, showing the type of connection (*Talk*, *Listen*, or *Listen/Talk*). Note that this is a connection between the customer ID and the ID that was set.
