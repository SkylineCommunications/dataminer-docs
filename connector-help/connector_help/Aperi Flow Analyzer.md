---
uid: Connector_help_Aperi_Flow_Analyzer
---

# Aperi Flow Analyzer

The Aperi Flow analyzer is an **IP probe** that provides real-time information on all the **flows** that are present in the network. It provides details about the **source IP, the destination IP, used protocols**, etc. of the flow.

It can also be configured to trigger an alarm if a flow goes missing.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 0.0.0.x \[SLC Main\] | Alpha release    | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 0.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 0.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP.
- **IP port**: The IP port of the destination. Make sure this is set to *443*, as the device uses HTTPS.
- **Device address**: Use the correct bus address. This depends on where the flow analyzer is activated.

### Initialization

To make sure the device can access the flows, you need to log in on the **Security Settings** page.

## How to use

The element created with this driver consists of the following data pages:

- **General**: Contains information about all the **detected and missing flows**. You can also enable or disable the function to **automatically remove missing flows.** The last update parameter shows when the last successful poll happened.
- **Security Settings**: Contains information on the **current network connection.** It also allows you to **log in.**
