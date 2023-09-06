---
uid: Connector_help_VMWare_AVI_Vantage_Controller
---

# VMWare AVI Vantage Controller

AVI Vantage delivers multi-cloud application services including a Software Load Balancer, Intelligent Web Application Firewall (iWAF), and Elastic Service Mesh. The AVI Vantage Platform helps ensure a fast, scalable, and secure application experience.

With the VMWare AVI Vantage Controller connector, you will be able to see cluster information, monitor the health of virtual services, pools, and servers, and monitor other metrics like throughput, requests per second, connections per second, etc.

To achieve this, the connector uses **AVI Networks REST API**.

## About

### Version Info

| **Range**            | **Key Features**                                                       | **Based on** | **System Impact** |
|----------------------|------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Cluster Information, Virtual Services, Pools, and Pool Servers tables. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 20.1.2                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTPS Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTPS CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

When you have created the element, provide the login credentials on the **General Page** and click the **Login** button in order to start receiving data.

### Redundancy

There is no redundancy defined.

## How to use

The element created using this connector has the following data pages:

- **General**: Contains the general **cluster information**, such as the cluster'sdate, tag, version, build, etc. Also allows you to log in to receive data from the AVI Vantage (see "Initialization").

- **Virtual Service**: Displays the Virtual Services table, with general information of the virtual services, such as the tenant, the name, the service ports, and related pools. This table also shows the current health score, as well as the number of open connections, requests per second, connections per second, and throughput.

- **Pool**: Displays the Pools and Pool Servers tables.

- The **Pools** table displays information about the pools, such as the tenant, the name, the related virtual service, the number of servers (up/total), and the related cloud. This table also shows the current health score, as well as the number of open connections, requests per second and throughput.
  - The **Pool Servers** table displays information about the pool servers, such as the port, server name, IP address, status, and related pool. This table also shows the current health score, ratio, requests per second, open connections, and throughput.
