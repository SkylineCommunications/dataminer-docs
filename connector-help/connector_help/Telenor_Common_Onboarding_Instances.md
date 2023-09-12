---
uid: Connector_help_Telenor_Common_Onboarding_Instances
---

# Telenor Common Onboarding Instances

This connector is intended to be used to communicate with an API responsible for aggregating information about Over-The-Top (OTT) Video-On-Demand (VOD) services.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Providers table. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.0.1                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

### Connections

#### HTTP Main Connection

This driver uses an HTTPS connection to communicate with the Telenor common onboarding API.

HTTP CONNECTION:

- **IP address/host**: E.g. [https://0xgpz5t4m2.execute-api.eu-west-1.amazonaws.com](https://0xgpz5t4m2.execute-api.eu-west-1.amazonaws.com/)
- **IP port**: The IP port of the destination (default: *443*).

### Initialization

The driver requires an **API Key** and an **Instance URL** in order to start the polling. This information must be specified on the **General** page.

## How to Use

When the **API Key** and **Instance URL** have been specified, information will be retrieved and displayed in the element.

On the General page, you can change the **Polling Time**. This determines the base timer used to send commands.
