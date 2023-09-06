---
uid: Connector_help_Paneda_DAB_Monitor_Orchestration
---

# Paneda DAB Monitor Orchestration

The **Paneda DAB Monitor Orchestration** connector can be used to orchestrate and manage Paneda DAB multiplexers and UDP proxies.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>Supported Firmware</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x</td>
<td><ul>
<li>Document revision: rev.79</li>
<li>System version: h-2023-06-29</li>
<li>Git commit: 61967b0c</li>
</ul></td>
</tr>
</tbody>
</table>

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

This connector supports redundant polling. Because of that, two connections can be configured when creating or editing an element. When one of the connections becomes unavailable, DataMiner will automatically switch to the other connection.

#### HTTP Connection - MAIN

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: \[The polling IP or URL of the destination.\]
- **IP port**: \[The IP port of the destination. (default: *443*)\]
- **Device address**: \[If the proxy server has to be bypassed, specify *BypassProxy*.\]

#### HTTP Connection - REDUNDANT

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: \[The polling IP or URL of the destination.\]
- **IP port**: \[The IP port of the destination. (default: *443*)\]
- **Device address**: \[If the proxy server has to be bypassed, specify *BypassProxy*.\]

### Initialization

After creating a new element that uses this connector, the API authentication token must be configured on the **Configuration** page. This so called "Bearer" token can be created and obtained from the webinterface from the device.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

All communication between DataMiner and the device goes over the HTTP REST API. An OpenAPI spec file can be downloaded from the webinterface that fully describes the API. This file can be imported in tools like Postman for debugging and testing purposes.

### DAB Monitor page

The **DAB Monitor** page contains a table that lists DAB Monitors. Each row is the combination of the entity and Docker container. DAB monitor entities are the parent structure for DAB monitor containers. The DAB monitor entity is long lived and remember important meta-data about the more short lived container.

Context menus on the tables can be used to create or remove items. Entities can only be removed when the corresponding container is already removed.

When creating a new DAB monitor container, multiple sources can be configured in the source list by separating them with a comma, as shown in the following screenshot:

![image](~/connector-help/images/Paneda_DAB_Monitor_Orchestration_image.png)

UDP Proxies page

The **UDP Proxies** page contains a table with all configured UDP proxies. Also here there there is the same destinction between entity and encoder.

Configuring UDP proxies works in the same way as configuring DAB Monitors. See the section above for more information.

Network page

The **Network** page provides a list of all available (VLAN) networks on the device. These networks can be assigned to an UDP proxy.




