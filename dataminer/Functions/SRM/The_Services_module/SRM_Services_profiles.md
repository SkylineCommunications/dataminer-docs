---
uid: SRM_Services_profiles
---

# Using the profiles tab

In the *profiles* tab of the Services module, you can manage service profile definitions and service profile instances. These make it possible to immediately have the right profile instances assigned to the nodes of a service definition, so that it is not necessary to make a selection for every node and interface of the service definition when making a booking. One single service profile definition can apply to several similar service definitions.

The tab consists of two panes: a tree view pane on the left listing the available service profile definitions and service profile instances, and a configuration pane on the right. At the bottom of the tree view pane, three buttons allow you to delete an item in the tree view, add a service profile instance and add a service profile definition. These options are also available via the right-click menu of the pane, which also contains a *Duplicate* option (from DataMiner 10.2.0/10.1.5 onwards).

## Configuring service profile definitions

To configure a service profile definition, select it in the list on the left. You can then configure it in the configuration pane on the right.

- Several buttons are available at the bottom of the list on the left:

  - *Add definition*: Adds a service profile definition.

  - *Add instance*: Adds a service profile instance. Note that this is not possible if the current service profile definition is a new definition that has not been saved yet.

  - *More* > *Delete*: Delete the selected definition or instance. However, to delete a service profile definition, all its instances must also be deleted.

- In the *configuration* > *by service definitions* tab, you can:

  - Add service definitions with similar nodes, to which the service profile definition will apply.

  - Link the nodes of the added service definitions to the necessary service profile nodes.

    To create a new service profile node, select *\<create new>* in the relevant dropdown box. A new service profile node will then immediately be created with the same name as the service definition node.

- In the *configuration* > *by node* tab, you can manage the nodes that have been added to the service profile definition in the *by service definition* tab.

  - You can remove a node that is no longer needed by selecting it and clicking the *Remove* button

  - You can specify a different label for a node in the *Label* box.

  - You can link the node to a different function in the *Function* dropdown box.

  - You can change the service definition node(s) the node is linked to by selecting different nodes in the *Linked to* dropdown box(es).

    If the service profile definition applies to several service definitions, a different selection is possible for each service definition. It is also possible to select no nodes for one or more service definitions.

  - In case a service created with the service profile definition will be used as a resource within another service, the *Exposed parameters* section allows you to determine whether specific parameters should be available in that other service. The parameters will only be available if they are selected in this section.

  - From DataMiner 10.2.0/10.1.2 onwards, the *Exposed parameters* section also contains parameters for node interfaces. For these, the interface name is indicated in the *Interface* column.

- In the *properties* tab, you can manage properties for the service profile definition.

  - The two buttons in the lower-right corner allow you to add or delete properties.

  - To change the name or value for a property, click the property in the list of properties and enter your changes.

## Configuring service profile instances

Service profile instances allow you to link service profile nodes to specific profile instances. If a service profile instance is selected in the pane on the left, it can be configured in the three tabs on the right:

- **Nodes**: Allows you to link the different nodes of the service profile to existing profile instances.

  - If the *By reference* toggle button is disabled, users will be allowed to override values for the profile instance; otherwise, this will not be possible.

  - Once a profile instance has been selected, any possible override values for parameters can be configured below.

  - From DataMiner 10.2.0/10.1.2 onwards, profile instance selectors are also available for all interfaces of the node. Selecting a profile instance for an interface will extend the parameter section below with the parameters for the interface, allowing you to configure override values if necessary.

- **Restrictions**: Allows you to specify whether the service profile instance applies to all service definitions included in this service profile definition or only to a limited set of service definitions.

- **Properties**: Allows you to manage properties for the service profile instance.

  - The two buttons in the lower-right corner allow you to add or delete properties.

  - To change the name or value for a property, click the property in the list of properties and enter your changes.
