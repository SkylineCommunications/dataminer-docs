---
uid: Connector_help_Inmarsat_BGAN_Manager
---

# Inmarsat BGAN Manager

The Inmarsat BGAN Manager connector is used to monitor the BGAN network and execute small operations. The BGAN network is a satellite communications network that allows voice, video and data sessions on remote terminals.

## About

### Version Info

| **Range**            | **Key Features**                          | **Based on** | **System Impact** |
|----------------------|-------------------------------------------|--------------|-------------------|
| 1.0.0.x | Poll Customers Poll Terminals and details | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Changed protocol implementation to API v3 | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination. (default: *443*)
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

The credentials must be filled in on the General page in order for any information to be polled. As long as this is not done, the element will not work. The credentials list is as follows:

- Scope
- Client ID
- Client Secret

The default scope, client ID and secret can be found in the Rest API documentation. However, they will be configurable in the network.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use (1.0.1.x)

### General

Credentials can be configured on this page, and a login can be enforced. There is also information on the current status of the authentication process.

### Customers

This page displays generic information for all customers currently accessible from the configured user.

### Terminal

This page contains a Terminals table as well as buttons to popup pages: Data Sessions, Operator Network Status, Geo Fence and Status Report.

## Data Sessions

The Data Sessions subpage contains the Running, Completed and Failed Data Sessions of the Terminals

## Operator Network Status

The Operator Network Status subpage contains the Operator Network Status of the Terminals

## Geo Fence

The Geo Fence subpage contains the Geo Fence of the Terminals

## Status Report

The Status Report contains the Geo Fence of the Terminals

### Terminal Tree Control

The Terminal Tree Control page contains a tree control with the Terminal Data linked together

### Hybrid Terminal

This page contains a Hybrid Pairs table, Hybrid Prism Table, Hybrid terminals table as well as buttons to popup pages: Hybrid Data Sessions, Hybrid Operator Network Status, Hybrid Geo Fence and Hybrid Status Report.

## Hybrid Data Sessions

The Hybrid Data Sessions subpage contains the Running, Completed and Failed Data Sessions of the Hybrid Terminals

## Hybrid Operator Network Status

The Hybrid Operator Network Status subpage contains the Operator Network Status of the Hybrid Terminals

## Hybrid Geo Fence

The Hybrid Geo Fence subpage contains the Geo Fence of the Hybrid Terminals

## Hybrid Status Report

The Hybrid Status Report contains the Status Report of the Hybrid Terminals


### Hybrid Terminal Tree Control

The Hybrid Terminal Tree Control page contains a tree control with the Hybrid Terminal Data linked together

### Events

This page contains the Events of all Non Hybrid and Hybrid Terminals.

### Poll Manager

The Poll Manager page contains a Polling Manager table which manages the polling of the API calls with individual timers. It also shows the time that the API call was last polled.

## Notes

**1.0.0.x**: **Terminal detail data is obtained per terminal**. This means that in **larger networks** this set of operations will become **slower**. The larger the network, the longer it will take to obtain all the terminal data.
**1.0.1.x**: **Terminal data is retried through a single API call**.