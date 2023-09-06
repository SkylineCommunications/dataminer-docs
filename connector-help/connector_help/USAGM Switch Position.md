---
uid: Connector_help_USAGM_Switch_Position
---

# USAGM Switch Position

This is a custom connector that was designed to keep track of services and alarms.

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

#### Virtual Connection - Main

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

This connector is designed to work with an Automation script that run every 60 seconds.

The name of this Automation script needs to be configured on the **Alarm Sync** page.

### Redundancy

There is no redundancy defined.

## How to use

The main page has a switch position table. You can add an entry to this table with the Add Switch button at the bottom of the page. Such entries are used to map the service name and the state.

## Notes

This connector is used in combination with an Automation script that reads files for services that are on air and that clears and generates alarms for services that are no longer on air.
