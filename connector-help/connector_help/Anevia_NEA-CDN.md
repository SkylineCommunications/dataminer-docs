---
uid: Connector_help_Anevia_NEA-CDN
---

# Anevia NEA-CDN

The NEA-CDN product is a caching server designed to extend streaming capabilities of an OTT origin server like NEA-LIVE or NEA-DVR over managed and unmanaged networks. It is designed specifically for video streaming. It reduces network load by caching user requests and content to form a shield that protects origin servers from multiple requests.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

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

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: If the proxy server has to be bypassed, specify *BypassProxy;* otherwise specify the proxy address.

### Initialization

To make sure the driver can work properly, specify the parameters **Login** and **Password** on the **Authentication** page.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the following data pages:

- **General**: Contains the Projects table as well as the Kubernetes Cluster table.
- **Projects Overview**: Contains a tree overview of the projects, as well as the CDN clusters and CDN instances present in each project.
- **K8s Cluster Overview**: Contains an overview of the Kubernetes clusters and the instances present in each cluster.
- **CDN**: Contains two tables listing the CDN clusters and CDN instances, respectively.
- **Assets**: Contains a table listing the available instance types, and a table that displays the available algorithms in the system.
- **Sources Groups/Conditions/Operations**: These pages all contain a table listing the information relevant to the page name.
- **Authentication**: Contains the Login and Password parameters as well as the Login button. These parameters are needed for the driver to access the API of the device.
