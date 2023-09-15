---
uid: Connector_help_Red_Bee_Media_Service_Early_Warning
---

# Red Bee Media Service Early Warning

The purpose of this connector is to list service warnings and indicate at which point in time they will have a critical impact if no action is taken.

The warnings are collected via an Automation script. The user has the option to trigger the script manually or let the script be executed at a specified time interval.

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

### Initialization

An Automation script with the parameter **InputData** must be present in the DMS. The name and the input data need to be filled in on the **General** page of the element.
