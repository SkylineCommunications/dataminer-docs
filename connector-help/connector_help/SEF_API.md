---
uid: Connector_help_SEF_API
---

# SEF API

This connector makes it possible to monitor the **service health** of the SEF (Swedish Football) API.

## About

The connector communicates via **HTTP** traffic, more specifically via JSON calls.

In this version, only the HealthResponse has been implemented.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### HTTP connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination, by default *443*.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

### Configuration

On the **Communications** page, update the **Service Health URL**. The default value is */api/v1/ServiceMetas/ServiceHealth.*

This value is appended to the IP address or hostname to create the full link to the Service Health URL.

## Usage

### Overview

This page contains a tree view of the **Health Control Status**.
For each level, it shows a table with the **Full Resource Name**, **Resource Name**, **Status** and **Message**.

### Communications

On this page, you can find the **Service Health URL** that is used to retrieve the information from the API.

The page also displays the **Service Health HTTP Status** and the **Service Health Status**.
