---
uid: Connector_help_QVC_IP_Media_Flow_Monitor
---

# QVC IP Media Flow Monitor

This connector uses information from the Cisco DCNM and the Imagine Communications Magellan SDNO to allow the user to monitor the presence of IP flows.

## About

### Version Info

| **Range** | **Key Features**                         | **Based on** | **System Impact**                    |
|-----------|------------------------------------------|--------------|--------------------------------------|
| 1.0.0.x   | Initial version                          | \-           | \-                                   |
| 1.0.1.x   | Support for multiple Cisco DCNM elements | 1.0.0.2      | Changed single parameter to a table. |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

Specify the names of the Cisco DCNM and Imagine Communications Magellan SDNO elements from which information is to be retrieved. Also specify how often the information should be retrieved.

## How to Use

The **Last Operation Duration** parameter indicates how long it took to process the information on the last update. The polling frequency can be adjusted if necessary.

You can also enable notifications via information events on the Cisco DCNM and Imagine Communications Magellan SDNO. These information events can be used with a Correlation rule to trigger the polling of the information.
