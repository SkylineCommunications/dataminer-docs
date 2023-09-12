---
uid: Connector_help_BMC_Remedy_ORCA
---

# BMC Remedy ORCA

This connector is used to interface with the **Fusion Remedy**.

It will not poll any information from the Fusion Remedy. An **external source** (for example an Automation script) can send an XML request to the BMC Remedy ORCA connector. This request will then be encapsulated into an "**executeRequest**" SOAP request that will be sent towards the Fusion Remedy. The response can then be further handled by the external source.

## About

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|-----------|-----------------|---------------------|-------------------------|
| 1.0.0.x   | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1234                   |

## Configuration

### Creation

#### HTTP Main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination, *default 38080*.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

### Configuration of request fields

The **SOAP** request has some additional fields that need to be configured before any request can be sent towards Fusion Remedy. You can configure these on the Configuration page of the element:

- **Username**: The username included in the security header of the SOAP request.
- **Password**: The password included in the security header of the SOAP request.
- **Grid Name**: The grid name included in the SOAP request.
- **Process Name**: The process name included in the SOAP request.

The **BMC Remedy ORCA** will drop all requests as long as these parameters are not configured.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

### Configuration

This page groups all **configuration** for this connector (more info above).

The **request** and **response** are also displayed on this page, along with the **Status** of the communication.

### Changes Overview

The polled changes are listed in a tree control. Each change has its linked change impact entries.

### Changes

The **Changes Table** is updated automatically every 12 hours and can also be updated manually by means of the **Force Get All Changes** button. Entries are tracked in the table until the end time of the changes is more than 12 hours in the past.

The state information for changes is polled every minute for entries that are *active*. It is also polled every minute if the changes are about to start (15 minutes prior to the start time, or if the time is in the expected start range).

The **Active Change Count** parameter shows the number of current active changes.
