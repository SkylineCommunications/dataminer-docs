---
uid: Connector_help_Finnish_Broadcasting_Company_Contract_Manager
---

# Finnish Broadcasting Company Contract Manager

This connector is part of the SRM Solution for the **Finnish Broadcasting Company (YLE)** and is used to define which functions are available for each of their customers and which properties are available in the Media Services app for each DataMiner user group.

## About

### Version Info

| **Range** | **Key Features**            | **Based on** | **System Impact** |
|-----------|-----------------------------|--------------|-------------------|
| 1.0.0.x   | Initial version             | \-           | \-                |
| 1.0.1.x   | \-                          | 1.0.0.x      | \-                |
| 1.0.2.x   | Contract filtering reworked | 1.0.1.x      | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                       | **Exported Components** |
|-----------|---------------------|-------------------------|---------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                                          | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                                          | \-                      |
| 1.0.2.x   | No                  | Yes                     | Finnish Broadcasting Media Services scripts | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

Verify if the default config file is available on the DMA and, if necessary, update the **Config File** **parameter** on the General page to point to the correct file.

### Redundancy

No redundancy is defined in the connector.

## How to Use

The element created with this connector consists of the data pages detailed below.

### General Page

This page contains the Configuration File parameter and the Companies, Contracts and User Groups tables.

- The **User Groups table** is filled out automatically and contains an entry per available user group in the DataMiner System. This table is the main configuration table and allows you to define the settings for the Media Services application that are available for each user group. Every user group needs to be linked to a company before it can be used by the Media Services application.
- The **Companies table** contains an overview of the different customers that use the Media Services app. This table has to be filled out manually via the right-click menu of the table.
- The **Contracts table** is used to define the contract(s) for a company. This includes the start and end time of each contract, the status, the available services, etc. This table needs to be filled out manually via the right-click menu of the table.

The page contains page buttons to the following subpages:

- **Order Properties**: Contains the **Order Properties table**, with an overview of all available properties for an order. This list of properties needs to be filled out manually. Once a property has been added to this table, it can be linked to a user group in the User Groups table. When an order property has been linked to a user group, a column is added on the Order Overview pages in the Media Services app for the users that are part of that user group. If an order has the specified property, that value of that property is shown on the Order Overview pages.

- **Pages**: Contains the Page Groups, Pages and Always Accessible Pages tables.

- The **Always Accessible Pages table** allows you to define the routes to the pages that should be available to everyone, regardless of the user group they are part of.
  - The **Pages table** contains the routes to the pages that can be filtered per user group. These routes are grouped together in a page group.
  - The **Page Groups table** contains a list of page groups. A page group is a group of linked pages. Once a page group is linked to a user group from the User Groups table, every user of the user group will have access to the pages that are part of that page group.

- **Scripts**: Contains the Event Scripts, Order Scripts and Icons tables.

- The **Event Scripts table** allows you to define a list of scripts that can be linked to a user group from the User Groups table. Once a script is linked to a user group, a button will be available in the Event Details in the Media Services app. The text and icon of this button are defined in the Event Scripts table. Clicking this button will cause the linked interactive Automation script to be launched. This feature can be used for example to display additional details for a specific event.
  - The **Order Scripts table** works exactly the same as the Event Scripts table, except that it applies to orders instead of events.
  - The **Icons table** allows you to define which icons are available to be linked to an event or order script from the respective tables. As the Media Services app is only able to display icons that are part of the FabricMDL2Icons font, you will need to check a list of available icons. To make an icon available for use by the event and order scripts, you will need to add its name to the Icons table. A list of available icons can be found [here](https://uifabricicons.azurewebsites.net/).

### External Requests Page

This page contains the External Requests table and a configuration parameter.

The Media Services app will request information from this connector, for example to know which options should be available for the logged-in user when creating a booking. These requests are stored in the **External Requests table**.

The configuration parameter at the bottom of the page defines for how long an external request is stored.

All changes done in this connector are immediately stored in the config file.

## Notes

This connector requires SRM to be installed on the DMA.
