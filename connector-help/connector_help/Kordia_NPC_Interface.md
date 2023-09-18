---
uid: Connector_help_Kordia_NPC_Interface
---

# Kordia NPC Interface

This connector is used to validate JSON content received through HTTPS requests.

## About

### Version Info

| **Range**            | **Key Features**       | **Based on** | **System Impact** |
|----------------------|------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | HTTP Request Log Table | \-           | \-                |

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

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

### General page

This page contains the **Active Requests** table along with refresh and configuration buttons.

The **Request Log Config** button shows a subpage with the configuration parameters for the **Request Log Table**, which contains a list of previous requests. You can configure the maximum number of requests to be saved with the Request Log Table **Row Limit** parameter, and you can configure the maximum duration a request should be kept in the table with the **Age Limit** parameter.

### PA Debug page

This page contains debug parameters.

**Element Provisioning Status** it is a status parameter that have the values *OK* or *Fault*. If after provisioning triggered by the workflow, this parameter has the value *Fault*, this indicates that there was an issue while trying to process the device connection data, and more details can be found in the element log file. The value of this parameter **never reverts back to** ***OK*** **automatically**. You need to revert it manually by clicking the button **OK**. If you want to make use of this parameter for debug purposes, set its value to OK before triggering the workflow provisioning.

**Note**: Do **not** make use of the **Element Provisioning Status** parameter if you use **manual provisioning**. During manual provisioning, the connector never tries to process the connections data.

### HTTP Configuration

This page contains information regarding the data that is imported into DataMiner for the different HTTP requests that are done. It allows you to configure the endpoint identifier to be polled.

The **Debug HTTP** page button opens a page with information about the latest API responses received.

## Notes

In the Log Table, the status column indicates how a request was evaluated: *Valid*, *Invalid*, *Timeout*, or *Request Failed*.
