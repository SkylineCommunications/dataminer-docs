# The Services module

From DataMiner 9.5.4 onwards, on a system with the proper licenses, the *Services* module is available in apps list in Cube. Prior to DataMiner 9.6.4, it is listed under the name *Service Manager*.

This module is used to configure service definitions, which determine the number and type of virtual functions included in a service and the way these virtual functions are connected within that service.

From DataMiner **9.6.4** up to DataMiner 10.0.7, the module consists of two tabs:

- The *definitions* tab, containing an overview of all service definitions and service definition templates, with the possibility to configure them. This tab is selected by default. See [Using the definitions tab](#using-the-definitions-tab).

- The *services* tab, containing an overview of all services in the system. See [Using the overview tab](#using-the-overview-tab).

From DataMiner **10.0.8** onwards, the module consists of the following tabs:

- The *overview* tab, containing an overview of all services in the system. This tab is displayed by default. See [Using the overview tab](#using-the-overview-tab).

- The *definitions* tab, containing an overview of all service definitions and service definition templates, with the possibility to configure them. This tab is selected by default. See [Using the definitions tab](#using-the-definitions-tab).

- The *profiles* tab, containing an overview of all service profile definitions and service profile instances, with the possibility to configure them. See [Using the profiles tab](#using-the-profiles-tab).

> [!NOTE]
> From DataMiner 10.0.0 onwards, if DataMiner Indexing is not installed, only the *services* or *overview* tab of this module is available.

### Using the overview tab

The *services* tab (prior to DataMiner 10.0.8) or *overview* tab (from DataMiner 10.0.8 onwards) lists all services in a dynamic, filterable list view with a default set of columns. The list can be customized as follows:

- To sort the items in the list by a particular column, click the header of that column. Click the header again to reverse the sort order.

- To filter which services are displayed in the list, click the filter icon for the column you want to apply a filter to and enter a filter in the box below the column header.

- To apply a custom column configuration, see [Creating a new column configuration](#creating-a-new-column-configuration).

#### Creating a new column configuration

1. Right-click in the list header, and apply the following configuration as you see fit:

    - Select *Add/Remove column* and indicate which columns should be added or removed.

    - Select *Alignment* and then choose a different text alignment for the columns.

    - Select *Change column name* and specify a new column name.

    - Select *Manage column configuration* (from DataMiner 10.0.4 onwards) or *Add/Remove column *\> *More* (up to DataMiner 10.0.3) to open a window where you can do the following:

        - Show or hide a column by selecting or clearing its checkbox, or by selecting it and clicking *Show* or *Hide*.

        - Move a column up or down by selecting it and clicking *Move up* or *Move down*.

        - Up to DataMiner 9.6.13, a number of additional checkboxes are available for each possible column:

            - Select the *Icon* checkbox of a particular column to have its contents replaced by icons. From DataMiner 9.6.12 onwards, this option is supported for ID columns.

            - Select the *Color* checkbox of a particular column to visualize the cells in that column as colored blocks.

        - From DataMiner 10.0.0/10.0.2 onwards, for columns based on custom properties, you can instead select a different type (e.g. *Custom icon*, *Color*) in the *Column type* drop-down lists. For the default columns, the column type cannot be changed, except for the *Alarm count* column. The latter can be set to *Color* to display the count in a circle with the color of the highest severity.

        - In the *Filter by type* section, indicate which type of columns you want to choose from (services, properties and/or service profiles). This allows you to add additional service profile columns.

2. Right-click in the list header (or click the list’s hamburger menu) and select *Save current column configuration*.

    When the module is opened again, this column configuration will be displayed. If you do not apply this last step, the column configuration will be reset when the module is closed.

#### Loading the default column configuration

- Right-click in the list header (or click the list’s hamburger menu), select *Load default column configuration*, and select the configuration you want to load.

### Using the definitions tab

In the *definitions* tab, a navigation pane on the left shows a tree view of available service definitions, while the pane on the right shows detailed information and configuration options for a selected service definition.

The navigation pane consists of two tabs:

- The *Recent* tab lists the following service definitions:

    - all service definitions that were modified during the last 7 days

    - all service definition templates (marked with a different icon containing a **T**)

    At the bottom of this pane, there are also two buttons, which can be used to delete a selected service definition or add a new service definition.     From DataMiner 9.6.6 onwards, the icon in the top-right corner of the tab allows you to toggle grouping of template service definitions and regular service definitions. This option is also available via the context menu of the tab.

    > [!NOTE]
    > Deleting service definitions is not possible until DataMiner 9.5.11.

- The *All* tab allows you to filter the list of service definitions by specifying a time range and a filter. In the filter box, you can enter the following:

    - a regular expression (preceded by the prefix “regex:”)

    - a service definition GUID

    > [!NOTE]
    > To perform an inverted search, put an exclamation mark in front of your search string.

To create a new service definition, click the *Add definition* button in the navigation pane. To edit an existing service definition, select it in the navigation pane. In either case, you will then be able to configure the service definition in the service definition pane on the right.

This service definition pane consists of a header section at the top, with three tabs below it. Configure the service definition in this pane as specified below, and then click the *Save all changes* button in the lower right corner.

#### Header section

In the header section of the service definition panel, you can specify the following:

- **Name**: The name of the service definition.

- **Description**: A general description of the service definition.

- **Template**: This checkbox determines whether the service definition is considered to be a template or not. If a service definition is configured as a service definition template, it will be treated differently while scripts to create bookings are running. This option is particularly useful in case the service definition is systematically modified during the script, in order to reduce the required resources.

- **Visio**: Allows you to select the Visio file that will be used for services generated for this service definition. Either select one of the available files in the drop-down list, or click *New upload* to add a new file.

    > [!NOTE]
    > If a default Visio file has been specified for a service definition, assigning a different Visio file to a specific generated service is only possible from DataMiner 9.5.7 onwards. Customizing the Visio file for a specific generated service is only possible after a different Visio file has been assigned to the service.

#### Configuration tab

On this page, you can configure the different virtual functions in the service that will be generated by the *Services* module when a booking is made, and determine how the virtual functions are connected.

To do so:

1. From the *Functions* list on the left-hand side of this tab, which lists all virtual function definitions available in the system, drag and drop the necessary virtual function definitions to the diagram pane on the right.

    The virtual function definitions you added will serve as nodes in the diagram, representing the virtual functions in the service.

2. In the diagram pane, drag and drop the nodes to the appropriate positions, and then click and drag from interface to interface to create connections between them.

    > [!NOTE]
    > - You will only be able to connect interfaces that are compatible according to the corresponding profile definitions. - From DataMiner 10.2.0/10.1.3 onwards, you can edit existing connections between node interfaces by dragging and dropping the endpoint of a selected connection to a different endpoint.

3. You can then further refine the created setup if necessary:

    - To define logical groups of nodes:

        1. Right-click the diagram and select *Configure groups*.

        2. Click *Add group*.

        3. Specify the group name, select the nodes to add to the group, and click OK.

        > [!NOTE]
        > Nodes that belong to particular groups will be displayed with colors matching these groups. The group colors are shown in a legend below the diagram.

    - To further refine parameters for a particular node, select the node, and, in the lower right corner, specify a parameter label and/or select one of the available profiles for the parameter. From DataMiner 10.0.9 onwards, a toggle button is also available next to the *Profile* box, which determines if the *By reference* option is selected by default during booking creation. If *By reference* is selected, users will not be able to adapt the value for the selected profile instance during booking creation.

        > [!NOTE]
        > Parameter profiles are created in the *Profiles* module. See [Configuring profile parameters](Configuring_profile_parameters.md).

    - To add properties to a particular node, interface or connection, select the node, interface or connection in the diagram, and, in the *properties* tab in the lower right corner, click the *Add* button and specify the property.

> [!NOTE]
> From DataMiner 9.5.5 onwards, when you add properties to service definition objects in Cube, these properties are also added in *PropertyConfiguration.xml*. Only properties in that file are visible in the UI. If you add properties via Automation scripts, these will remain hidden from the user if they are not defined in *PropertyConfiguration.xml*.

#### Properties tab

The second tab of the service definition pane can be used to manage properties of the service definition itself.

- To add a property, click the *Add* button in the lower right corner, and specify the property.

- To remove a property, select it in the list of properties and click the *Delete* button.

#### Actions tab

The third tab of the service definition pane allows you to specify Automation scripts that should run at a particular point during a booking. To add a script:

1. Click the *Add* button in the lower right corner.

2. In the *Name* column, select when the script should run, e.g. *START*, *STANDBY*, *PAUSE*, *STOP* or *RETIRE*.

3. In the *Script* column, select the Automation script that should be run.

4. In the *Description* column, specify an optional description.

To remove one of the added scripts, select it and click the *Delete* button in the lower right corner.

#### Profiles tab

This tab is available from DataMiner 9.6.5 onwards. It allows you to link profile definitions to the selected service definition.

In the *Add service profile* drop-down box, all profile definitions configured in the *Profiles* module are available.

To link the selected service definition with a profile, select one of the profile definitions in the drop-down box and click *Add*. However, note that this change will only be saved if the profile is linked to at least one of the parameters in the diagram.

Below the drop-down box, a list is displayed of the profiles that have already been linked to the selected service definition and of the parameters in these profiles. An “x” icon to the right of each profile name allows you to remove the profile from the service definition.

### Using the profiles tab

The *profiles* tab is available from DataMiner 10.0.8 onwards. This tab allows you to manage service profile definitions and service profile instances. These make it possible to immediately have the right profile instances assigned to the nodes of a service definition, so that it is not necessary to make a selection for every node and interface of the service definition when making a booking. One single service profile definition can apply to several similar service definitions.

The tab consists of two panes: a tree view pane on the left listing the available service profile definitions and service profile instances, and a configuration pane on the right. At the bottom of the tree view pane, three buttons allow you to delete an item in the tree view, add a service profile instance and add a service profile definition. These options are also available via the right-click menu of the pane, which also contains a *Duplicate* option (from DataMiner 10.2.0/10.1.5 onwards).

#### Configuring service profile definitions

To configure a service profile definition, select it in the list on the left. You can then configure it in the configuration pane on the right.

- Several buttons are available at the bottom of the list on the left:

    - *Add definition*: Adds a service profile definition.

    - *Add instance*: Adds a service profile instance. Note that this is not possible if the current service profile definition is a new definition that has not been saved yet.

    - *More* > *Delete*: Delete the selected definition or instance. However, to delete a service profile definition, all its instances must also be deleted.

- In the *configuration* > *by service definitions* tab, you can:

    - Add service definitions with similar nodes, to which the service profile definition will apply.

    - Link the nodes of the added service definitions to the necessary service profile nodes.

        To create a new service profile node, select *\<create new>* in the relevant drop-down box. A new service profile node will then immediately be created with the same name as the service definition node.

- In the *configuration* > *by node* tab, you can manage the nodes that have been added to the service profile definition in the *by service definition* tab.

    - You can remove a node that is no longer needed by selecting it and clicking the *Remove* button

    - You can specify a different label for a node in the *Label* box.

    - You can link the node to a different function in the *Function* drop-down box.

    - You can change the service definition node(s) the node is linked to by selecting different nodes in the *Linked to* drop-down box(es).

        If the service profile definition applies to several service definitions, a different selection is possible for each service definition. It is also possible to select no nodes for one or more service definitions.

    - In case a service created with the service profile definition will be used as a resource within another service, the *Exposed parameters* section allows you to determine whether specific parameters should be available in that other service. The parameters will only be available if they are selected in this section.

    - From DataMiner 10.2.0/10.1.2 onwards, the *Exposed parameters* section also contains parameters for node interfaces. For these, the interface name is indicated in the *Interface* column.

- In the *properties* tab, you can manage properties for the service profile definition.

    - The two buttons in the lower right corner allow you to add or delete properties.

    - To change the name or value for a property, click the property in the list of properties and enter your changes.

#### Configuring service profile instances

Service profile instances allow you to link service profile nodes to specific profile instances. If a service profile instance is selected in the pane on the left, it can be configured in the three tabs on the right:

- **Nodes**: Allows you to link the different nodes of the service profile to existing profile instances.

    - If the *By reference* toggle button is disabled, users will be allowed to override values for the profile instance; otherwise, this will not be possible.

    - Once a profile instance has been selected, any possible override values for parameters can be configured below.

    - From DataMiner 10.2.0/10.1.2 onwards, profile instance selectors are also available for all interfaces of the node. Selecting a profile instance for an interface will extend the parameter section below with the parameters for the interface, allowing you to configure override values if necessary.

- **Restrictions**: Allows you to specify whether the service profile instance applies to all service definitions included in this service profile definition or only to a limited set of service definitions.

- **Properties**: Allows you to manage properties for the service profile instance.

    - The two buttons in the lower right corner allow you to add or delete properties.

    - To change the name or value for a property, click the property in the list of properties and enter your changes.
