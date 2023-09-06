---
uid: Connector_help_KPN_Service_Manager
---



# KPN Service Manager

The KPN Service Manager is a manager connector used to calculate the severity of every Program view and Stream view in the KPN system.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

## How to Use

### General

The **Summary Table** displays the severity of each path in every monitored view. Severities are updated using subscriptions.

The monitored views are the views located under the **Customers** view and complying with the format '(*Customer*) (*Location*) Programs/Streams'. Monitored views are detected at startup, but you can refresh them by clicking the **Refresh Subscriptions** button.
