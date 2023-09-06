---
uid: Connector_help_Ceiton_Resource_Planning
---

# Ceiton Resource Planning

This driver is used to store information from the Ceiton Resource Planning software solution. This software can be used to plan tasks into projects.

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

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: 9995).
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

### Initialization

In order to receive notifications from Ceiton, some settings need to be configured in the driver. These can be found on the **Notifications** page and include the **endpoint URL** to which the web service listens for incoming notifications, the **port** that the web service will use and the **type** of protocol. When **HTTPS** is selected as protocol, you will need to select a certificate that is installed on the system.

Enabling the web service is done through the **notifications status** parameter. When the web service is enabled, the **Web Service Status** should be *Opened*. If this is not the case, something may be wrong with the configuration. For example, another service in the system may be using the same port.

### Redundancy

Redundancy is not defined in the driver.

## How to Use

When the driver receives a notification, the notification is parsed and the information is stored in the applicable tables.

Every 5 minutes, there is a check if the tasks and external requests are stored longer than the times defined in the parameters **Remove Tasks After** and **Remove External Requests After**. If they are, these tasks or requests are removed.

If a product is not referenced by a product task, the product is removed. If a project is not referenced by a product or project task, the project is removed.

In order to actively poll a product or project, an external request has to be made. This is done by writing a JSON serialized ExternalRequest (see ExternalRequests namespace in QA1) to parameter 850. When a valid external request is received, an entry is added to the **External Requests** table and the driver will try to poll the project or product with the provided values. If the request fails or no information is returned in the request, the status of the external request will be set to *Failed*, otherwise if will be set to *Success* and the requested resource will be available in the **Project** or **Product** table.
