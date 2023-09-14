---
uid: Connector_help_NGINX_NGINX_Plus_Server
---

# NGINX NGINX Plus Server

NGINX Plus is a suite of media content delivery products such as load balancers, web servers and proxies.

## About

This connector uses an HTTP connection to retrieve information from the device.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.11.5                      |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the monitoring web interface.

## Usage

### Dashboard

This page displays an overview of the management information the element provides. It is a **summary** of the information on the other pages. This includes the total number of **connections**, the **requests** being handled and an overview of the **zones** and **streams**.

### Server Zones

This page displays a list of **managed servers**, the current **requests** and **responses** and the overall **traffic** going through them.

### Upstreams

This page displays information about the basic upstreams. Per stream there is a **set of servers** and per server there is information about **requests** and **responses**, **diagnostics** made in the recent past and **response times**.

### TCP/UDP Zones

This page displays information about the current TCP/UDP zones. Per zone, you can find information about the **current connections** and the **traffic** that is being handled.

### TCP/UDP Streams

This page displays a list of the current TCP and UDP streams. Here you will find information about **Response Times**, the **Connections**, the **Traffic** served and the **health diagnostics** carried out.

### Caches

This page provides information about the available caches, including the **Hit Ratio**, the **Cache Size** and the **Cache Status**.

### Latency Check

This page displays information about the latency of the connection. It also allows you to set **latency check** request parameters and displays **response time** results.

### Web Interface

This page provides access to the web management console. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
