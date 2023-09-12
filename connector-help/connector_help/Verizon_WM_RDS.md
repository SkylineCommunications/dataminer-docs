---
uid: Connector_help_Verizon_WM_RDS
---

# Verizon WM RDS

This driver manages the interaction between the Verizon Reports and Dashboards Solution driver and the Profile Manager app. The information stored in the tables of the Verizon Reports and Dashboards Solution is stored in the Profile Manager app.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**    | **Exported Components** |
|-----------|---------------------|-------------------------|--------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | VerSatOnReportAutomation | N/A                     |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

As this is a virtual driver, **no data traffic** will be shown **in the Stream Viewer**.

There are two workflows to exchange data between the Verizon Reports and Dashboards Solution driver and the Profile Manager app:

- **OnUpdate**: Used to retrieve data from the Profile Manager and update tables in the Verizon Reports and Dashboards Solution.
- **OnChange**: Used to add/remove/edit entries in the Profile Manager.

A workflow is triggered by an action in the Verizon Reports and Dashboards Solution driver. It generates a sequence of actions (information event \> Correlation rule \> Automation script) that results in an update or change of data. For an update event, the driver will get the relevant data from the Profile Manager and update the corresponding tables. For a change event, the driver will add, edit or remove the relevant data from the Profile Manager depending on the executed action.
