---
uid: Connector_help_PagerDuty_Platform
---

# PagerDuty Platform

This connector implements a communication link between DataMiner and the PagerDuty cloud service. It allows you to construct an HTTP post message for three possible event actions (trigger, acknowledge and resolve) and then send it to PagerDuty.

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

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: [https://events.pagerduty.com](https://events.pagerduty.com/)
- **IP port**: 443
- **Device address**: Empty*.* If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

On the **General** page, you should specify the **Routing Key** (or Integration Key) of the destination (the event source of PagerDuty) where the messages must be sent.

### Redundancy

There is no redundancy defined.

## How to use

This connector has only one page (General), which is used to construct the HTTP message. The parameter fields **Event Action**, **Routing Key** and **Dedup Key** are mandatory for each type of event action. The payload parameters only have to be filled in when the event action trigger is selected.

The payload parameters Component, Group and Class are optional.
