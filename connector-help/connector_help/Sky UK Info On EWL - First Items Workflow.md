---
uid: Connector_help_Sky_UK_Info_On_EWL_-_First_Items_Workflow
---

# Sky UK Info On EWL - First Items Workflow

This driver can be used to create an enhanced service containing elements using the driver [Sky UK VICC](xref:Connector_help_Sky_UK_VICC).

With this driver, alarms can be generated according to predefined rules.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

To use this driver, create a service that uses it as its service definition. Then configure the following child elements/parameters:

- [Sky UK VICC](xref:Connector_help_Sky_UK_VICC)

- **Channel From User**

## How to Use

A service created using this driver will have the data pages detailed below.

### Alarms

This page displays the **Early Warning List Table**,with an entry for each current and future event with their PIN due status. The table displays the Cause, Alarm State, Channel, Alarm Time and Target UI.

### Device Data

This page displays the current values of the parameters of the VICC child element that are used in the workflow.

### Subscriptions Active

This page contains a table with parameters contained within the service.
