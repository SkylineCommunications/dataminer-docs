---
uid: Connector_help_Sky_UK_Playout_Manager
---

# Sky UK Playout Manager

The Sky UK Playout Manager provides an overview of the available desks and the corresponding scenarios, service groups and services from the Surveyor.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Installation and configuration

### Creation

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

## How to use

This is a virtual driver. Its data is retrieved from the Surveyor or from Visual Overview. You can find more information about the different data pages of the driver below.

### Desk Table Page

This page displays the **Desk Table**, with all info regarding the different desks. At startup, this information is retrieved from the desk view properties of all desks found in the sites view.

A new desk can be added via a pop-up page. On this page, you need to specify the **Desk Index**, **MAC** **Address**, **Name** and **Site**. The values of these last three parameters can also be changed in the table. The other column values can be set using the buffer strings from the Visual Overview: **Connection Status**, **Type**, **Selected Scenario Name** and **User Name**.

You can also remove a desk with the **Remove** button at the end of the desk row. With the **Refresh Table** button, you can update the Desk Table data with any changes from the desk views.

### Scenarios Page

This page contains the **Scenario** **Table**, with all the scenarios available in the scenarios views. This data is retrieved from the Surveyor and passed along via the **Scenario** **Table** **Buffer**. The scenarios are also all listed in the **Scenario** **List** parameter. The **Scenario** **List** **Lite** parameter lists the scenarios containing only one service group.

With the **Clear Tables** button, you can clear all tables related to the scenarios and services. The **Refresh Table** button updated the table with the latest data from the Surveyor.

### Scenario Content Page

All the service groups and services included in the scenarios are displayed in the **Scenario** **Content** **Table**. The table includes the service (group) name, service type and sorting key.

### Service Groups Page

This group lists the service groups in the **Service** **Groups** **Table**. The table includes the status and site for each service group.

## Notes

This driver requires:

- a site view containing Chilworth and Osterley views,
- a scenarios view containing scenario services
- services with the SortingKey property
- views with the Desk Mac, Desk Name, Desk Site, Desk Status, Desk Type, Loaded Scenario and User Name properties
