---
uid: Connector_help_Sky_UK_Info_On_EWL_-_Same_Item_B2B_Workflow
---

# Sky UK Info On EWL - Same Item B2B Workflow

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

- **Data Update Trigger**
  - **Channel From User**

## How to Use

A service created using this driver will have the data pages detailed below.

### Alarms

This page displays the **Early Warning List Table**,with an entry for each back-to-back scheduled video item. The table displays the Cause, Alarm State, Channel, Alarm Time and Target UI.

### Device Data

This page contains several internal parameters.

The **VICC Update** parameter indicates the last update trigger received from the VICC and will also trigger internal processing.

The **VICC DMA-Elem ID** parameter is a reference to the VICC element configured in the service. It is used to find the correct element to request data from and is automatically filled in.

The **Channel Bus** and **Service Status** are also displayed. When the latter is *Off-Air*, this workflow will not trigger any alarms. If it is *NA* or *On-Air*, the workflow will run as expected.

### Subscriptions Active

This page contains a table with parameters contained within the service.
