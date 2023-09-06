---
uid: Connector_help_NHK_Remote_Production_Manager
---

# NHK Remote Production Manager

The NHK Remote Production Manager connector can be used to visualize and manage connections between data sources. It can monitor elements that use the NHK Generic DCF connector, as well as other data source placed within the configured views.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                              | **Based on** | **System Impact** |
|----------------------|-------------------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Monitoring for all NHK Generic DCF elements and monitoring for all elements with maximum three different port configurations. | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection - Main

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

When you create an element with this connector, some initialization is required:

- Create a view in the Surveyor where new to-be-monitored elements can be added.
- On the **Element Management** page, fill in the name of this view in the **Managed Element View** parameter.

## How to use

When **new elements** are added for the connector to monitor, it will look for these elements in the specified **Managed Element View**. When an element is detected, it will show up in the **Element Management** or **Virtual Element Management** table, depending on its connection type. By default, the location will be set to "default".

You can **add new views to monitor** via the right-click menu of the **Location Management** table. When you add a row in this table, the connector will automatically create a new view in the same view as the manager. These views can then be assigned to the elements, which will automatically move to their designated view.
