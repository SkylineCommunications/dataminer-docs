---
uid: Connector_help_Finnish_Broadcasting_Company_Feenix
---

# Finnish Broadcasting Company Feenix

This HTTP connector is made specifically for YLE and consists of three major components:

- The connector sends JSON notifications via HTTP to an external API.
- The connector runs a web service to receive JSON notifications via HTTP and store them in a table.
- The connector provides an API to acquire the Source List table via HTTP.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                           | **Based on** | **System Impact** |
|----------------------|----------------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | \- Web service to receive JSON via HTTP. - API to request Source list via HTTP. - HTTP session to send JSON notifications. | \-           | \-                |
| 1.0.1.x \[SLC Main\] | \- Unicode support.                                                                                                        | 1.0.0.7      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |
| 1.0.1.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                         | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \- Finnish Broadcasting Company Order Manager | \-                      |
| 1.0.1.x   | No                  | Yes                     | \- Finnish Broadcasting Company Order Manager | \-                      |

## Configuration

### Connections

#### HTTP connection

This connector uses an HTTP connection and requires input during element creation. The URL of the destination of the stop notifications must be entered, along with the port.

### Initialization

To initialize the web service responsible for receiving the notifications and providing the API, some parameters need to be configured on the **Configuration** page. The **Notifications** **Status** must be set to *enabled* to start the web service. The **Notifications** **URI**, **Port** and **Protocol** parameters, together with the IP address of the element are used to form the complete web service URI. In case the **Notifications Protocol** parameter is set to HTTPS, a certificate can be selected in the **Notifications Certificate** parameter.

### Redundancy

There is no redundancy defined.

## How to use

### Configuration page

This page contains settings for the web service that the JSON notifications should be sent to. There are also settings for the data in the notifications table and the "stop" function.

### Notifications page

This page contains the table where the parsed JSON notifications are being stored. Each notification can be stopped using the **Stop** button.

### Sources page

This page contains the **Source List** table, which can be requested via an HTTP GET request to *\[web service URI\]/getSourceNames*.

- The **Resource Pool** parameter defines from which pool resources will be selected to fill the Source List.
- The **Capability** parameter defines which capability should be present and set to "True" within a resource for it to be added to the Source List.
- The **Custom Name Property** parameter defines the name of the property that should be checked for a custom name of the resource. This custom name is then filled in in the **HMX Name** column of the Source List.
- The **Refresh** button refreshes the available resource pools, the available capabilities and the Source List.
