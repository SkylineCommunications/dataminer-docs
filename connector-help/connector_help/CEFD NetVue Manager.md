---
uid: Connector_help_CEFD_NetVue_Manager
---

# CEFD NetVue Manager

The CEFD NetVue Manager is a virtual connector used to manage the NetVue system.

With this connector, the user can manually create one or multiple service areas. The manager will then automatically create a view and a **CEFD NetVue HUB Gateway** element for each service area. The hub gateway elements will poll the list of remote devices from the NetVue system and forward it to the manager element. In the NetVue system, the information about the remotes is located in an element using the **CEFD HTO SNMP** connector. The manager element is then in charge of creating the **CEFD NetVue Remote Gateway** elements and assigning them to the correct service area.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                                                                                                                                                                | **Exported Components** |
|-----------|---------------------|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | [CEFD NetVue HUB Gateway](/Driver%20Help/CEFD%20NetVue%20HUB%20Gateway.aspx)[CEFD NetVue Remote Gateway](/Driver%20Help/CEFD%20NetVue%20Remote%20Gateway.aspx)[CEFD HTO SNMP](xref:Connector_help_CEFD_HTO_SNMP) | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

## How to Use

On the **General** page, the NetVue system information must be configured (**Server**, **User Name**, and **Password**). The **NetVue View ID** parameter must also be filled in: this is the ID of the view where all the NetVue elements and views will be created.

The **Service Areas** page displays a table listing all the service areas. You can add or remove service areas via the right-click menu. When a service area is added, a matching DMS view is created.

The **Hub Gateways** page displays all the hub gateways. You can add or remove hub gateways via the right-click menu. When a hub gateway is added, a **CEFD NetVue Hub Gateway** element is created in the matching service area view. The purpose of the hub gateway element is to connect to the NetVue system and detect information about the remotes.

The **Remote Gateways** page displays all the remotes detected in the system. The list of remotes is retrieved by the hub gateway elements. The hub gateway elements forward the list of remotes to the manager. When a new remote is detected, a **CEFD NetVue Remote Gateway** element is created in the matching service area view.
