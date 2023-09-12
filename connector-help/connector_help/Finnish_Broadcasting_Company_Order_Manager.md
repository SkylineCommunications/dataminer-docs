---
uid: Connector_help_Finnish_Broadcasting_Company_Order_Manager
---

# Finnish Broadcasting Company Order Manager

The **Finnish Broadcasting Company Order Manager** is used for the **Media Services** project and manages the updates received via **integration** elements to generate **events** and **orders** automatically.

## About

### Version Info

| **Range**            | **Key Features**                                                                                          | **Based on** | **System Impact**                                    |
|----------------------|-----------------------------------------------------------------------------------------------------------|--------------|------------------------------------------------------|
| 1.0.0.x              | Initial version.                                                                                          | \-           | \-                                                   |
| 1.0.1.x              | Improved prioritization of integration updates. Only handles updates with changed hash.                   | 1.0.0.9      | \-                                                   |
| 1.0.2.x              | Initialization of integration updates handled in order manager instead of HandleIntegrationUpdate script. | 1.0.1.13     | \-                                                   |
| 1.0.3.x \[SLC Main\] | Service configurations saved in logger table.                                                             | 1.0.2.5      | Previous service configurations no longer available. |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                               | **Exported Components** |
|-----------|---------------------|-------------------------|-------------------------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | FinnishBroadcastingCompany Media Services scripts Integration protocols (see below) | \-                      |
| 1.0.1.x   | No                  | Yes                     | FinnishBroadcastingCompany Media Services scripts Integration protocols (see below) | \-                      |
| 1.0.2.x   | No                  | Yes                     | FinnishBroadcastingCompany Media Services scripts Integration protocols (see below) | \-                      |
| 1.0.3.x   | No                  | Yes                     | FinnishBroadcastingCompany Media Services scripts Integration protocols (see below) | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

The main use of the Finnish Broadcasting Company Order Manager is to **subscribe** to the integration elements and to manage the **automatic creation of events and orders** via the **HandleIntegrationUpdate** script.
**Note that only one element using this connector should be created in the DMS.**

The following **integrations** (connectors) are supported by the Order Manager and, when enabled, will generate events and/or orders:

- **Ceiton Resource Planning**
- **Mediagenix WHATS On (Plasma)**
- **Finnish Broadcasting Company Feenix**
- **Pebble Beach EMS**
- **EBU Synopsis Web Service**

To be able to correctly subscribe to these elements, the **element IDs** need to be specified in the Order Manager element for each of these integration elements.

At startup, the Order Manager will **automatically** look for any of these elements and set the correct element ID when an element is found. When the elements are only added later or when they are recreated, they need to be **manually** referenced in the Order Manager.

## How to Use

### Integrations

The main function of the Finnish Broadcasting Company Order Manager is to manage the integration elements.

When the integration is enabled and the element is correctly configured, the Order Manager will **subscribe** to the integration element for any changes that need an event and/or order to be created or updated.
At startup, all data from the integration element will be evaluated to check what needs to be handled.

When a new update is received from an integration, it is added to the **Updates** table in the *Pending* state. A separate script (**FinnishBroadcastingCompany_HandleIntegrationUpdate**) is triggered when the next integration update can be processed.
For each integration, only one update is processed at a time. Once the script has finished processing the update, the entry in the **Updates** table will be updated to indicate whether the update was successfully processed.

### Orders and Events

The **orders** and **events** that have not yet been completed are tracked in the Order Manager. This is mainly used to **trigger** **events** linked to the start and/or end of the orders and events.

This is information that is available but should not be updated manually in the Order Manager element itself.

### User Groups

The **User Groups** table contains a list of all user groups in the DMS.

This table can be used to indicate if a user group is *internal* (i.e. an YLE user group) or *external* (i.e. a group from another company).
As external companies can have their own dedicated **EBU** element, this can also be configured in the **User Groups** table.

The user groups info is used by the event and order creation scripts to correctly filter in the UI.

### Locking

Another responsibility of the Order Manager is to manage the **locks** when an event or order is edited.
Only one user at a time can update an event and/or order, and it is the responsibility of the Order Manager to track these locks.


