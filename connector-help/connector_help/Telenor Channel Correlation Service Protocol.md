---
uid: Connector_help_Telenor_Channel_Correlation_Service_Protocol
---

# Telenor Channel Correlation Service Protocol

The Telenor Channel Correlation Service Protocol generates a single correlated alarm based on the state of all the components of the service.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

This driver is a service protocol driver and does not require any input during element creation.

## How to use

The **General** page displays the current severity of the elements used in the service. The **Correlated Alarms** table displays the current correlated alarm.

The **Rules** table on the **Rules** page allows you to configure the rules that will be used to create the correlated alarm.
