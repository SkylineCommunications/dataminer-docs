## Embedding a Service Manager component

From DataMiner 9.5.4 onwards, for systems with the appropriate licenses, it is possible to embed a Service Manager component in Visio. With this component, you can essentially embed the *Services* app in Visio.

> [!TIP]
> See also:
> [Service and Resource Management](../../part_4/SRM/SRM.md#service-and-resource-management)

In this section:

- [Basic shape data field configuration](#basic-shape-data-field-configuration)

- [Using session variables with a Service Manager component](#using-session-variables-with-a-service-manager-component)

- [Configuring command controls for a Service Manager component](#configuring-command-controls-for-a-service-manager-component)

### Basic shape data field configuration

Configure the following shape data fields on the shape that is to contain the Service Manager component:

- Shape data field: **Component**

    | Value        | Description                                                     |
    |----------------|-----------------------------------------------------------------|
    | ServiceManager | Defines the component as an embedded Service Manager component. |

- Shape data field: **ComponentOptions**

    | Value                                                  | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
    |----------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | AutoLoadExternalChanges=                                 | When set to *true*, external changes are automatically loaded, if there have been no local changes. This keeps an information bar from being displayed at the bottom of the Visual Overview, asking the user to load or discard the external changes.                                                                                                                                                                                                                                  |
    | AutoIgnoreExternalChanges=                               | Available from DataMiner 10.0.13 onwards. When set to *true*, external changes are automatically discarded. This keeps an information bar from being displayed at the bottom of the Visual Overview, asking the user to load or discard the external changes.                                                                                                                                                                                                                          |
    | HideChildFunctions=*X*    | Available from DataMiner 9.5.5 onwards. Allows you to filter on particular functions that should not be displayed in the component. “X” should be a collection of GUIDs, separated by a comma. Alternatively, you can also specify *\** or *ALL*, to filter all child functions. Note that if you specify the parent GUID of a particular function, this will also block all child functions of that function. The GUIDs can be found in the function XMLs. |
    | HideHeader=                                              | When set to *true*, hides the service definition header (which includes the service definition name and description)                                                                                                                                                                                                                                                                                                                                                                   |
    | HideTabs=                                                | When set to *true*, hides the tab selection, so that only the diagram tab is displayed.                                                                                                                                                                                                                                                                                                                                                                                                |
    | HideNodeConfiguration=                                   | When set to *true*, hides the lower part of the diagram, where the selected node can be configured.                                                                                                                                                                                                                                                                                                                                                                                    |
    | HideFunctionsTree=                                       | When set to *true*, hides the tree view on the left-hand side with functions to drag and drop. This will typically be used together with the “ReadOnly=” option.                                                                                                                                                                                                                                                                                                                       |
    | Interface=definition                                     | Links the shape to a service definition. (The service definition is determined by the *SelectedServiceDefinition* variable, mentioned below.)                                                                                                                                                                                                                                                                                                                                      |
    | ReadOnly=                                                | When set to *true*, prevents the user from making any changes to the service definition.                                                                                                                                                                                                                                                                                                                                                                                               |
    | SessionVariablePrefix=*X* | Defines an optional prefix (in this case “X”) for all session variable names linked with this component.                                                                                                                                                                                                                                                                                                                                                                                                          |
    | ShowNodeIDs=                                             | When set to *true*, displays the node IDs of the service definition.<br> Available from DataMiner 10.0.0/10.0.2 onwards.                                                                                                                                                                                                                                                                                                                                                               |

    > [!NOTE]
    > -  Separate the various *ComponentOptions* with semicolons (“;”).
    > -  If the AutoLoadExternalChanges and AutoIgnoreExternalChanges component options are both used, AutoLoadExternalChanges will take precedence. As long as there are no (unsaved) client-side changes, external changes will be loaded automatically. As soon as there are (unsaved) client-side changes, external changes will be discarded.

    > [!TIP]
    > See also:
    > [Configuring command controls for a Service Manager component](#configuring-command-controls-for-a-service-manager-component)

- Example:

    | Shape data field | Value                                                                                                                                        |
    |--------------------|----------------------------------------------------------------------------------------------------------------------------------------------|
    | Component          | ServiceManager                                                                                                                               |
    | ComponentOptions   | interface=definition;SessionVariablePrefix=SKYLINE;HideHeader=true;<br>HideTabs=true;HideNodeConfiguration=true;AutoLoadExternalChanges=true |

### Using session variables with a Service Manager component

The following session variables can be used in a Visual Overview containing a Service Manager component:

| Variable                  | Description                                                                                                                                                                                                                                                                                                                                                                              |
|---------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| HasPendingChanges         | Depending on whether any unsaved changes have been made to the service definition, this variable will be set to TRUE or FALSE.<br> To be used with the *SaveAll*/*DiscardAll* commands. See [Configuring command controls for a Service Manager component](#configuring-command-controls-for-a-service-manager-component). |
| CurrentHasPendingChanges  | Available from DataMiner 9.5.9 onwards.<br> Depending on whether any unsaved changes have been made to the service definition, this variable will be set to TRUE or FALSE.<br> To be used with the SaveCurrent/DiscardCurrent commands. See [Configuring command controls for a Service Manager component](#configuring-command-controls-for-a-service-manager-component).               |
| SelectedEdgeID            | The currently selected connection line.<br> Format: {FromNodeID}.{FromInterfaceID} -> {ToNodeID}.{ToInterfaceID}<br> Example: 1.4 -> 2.1<br> Note: The direction is determined by the interface types (in, out, inout), not by the arrow in this string.                                                                                                                                 |
| SelectedInterfaceID       | The numeric ID of the currently selected interface of the currently selected node.                                                                                                                                                                                                                                                                                                       |
| SelectedNodeID            | The numeric ID of the currently selected node on the diagram. From DataMiner 9.5.13 onwards, if multiple nodes are selected, the variable will contain a semicolon-separated list of IDs.                                                                                                                                                                                                |
| SelectedServiceDefinition | The GUID of the currently selected service definition.                                                                                                                                                                                                                                                                                                                                   |

- Example of a shape used to set the service definition selection (using the SKYLINE prefix):

    | Shape data field | Value                                                                 |
    |--------------------|-----------------------------------------------------------------------|
    | SetVar             | SKYLINESelectedServiceDefinition:a1181fba-db34-4de3-ac7e-de7af87e335e |
    | Options            | CardVariable                                                          |

- Example of a shape used to clear the current service definition selection (using the SKYLINE prefix):

    | Shape data field | Value                                                                 |
    |--------------------|-----------------------------------------------------------------------|
    | SetVar             | SKYLINESelectedServiceDefinition:00000000-0000-0000-0000-000000000000 |
    | Options            | CardVariable                                                          |

### Configuring command controls for a Service Manager component

From DataMiner 9.5.6 onwards, you can turn a shape into a command control that can be used to manipulate a Service Manager component. Depending on the configuration, the command control can be used to manipulate one particular component or several components, which can be on the same page, on the same card or anywhere in Cube.

1. Add the following shape data fields to the component shape:

    | Shape data     | Value                                                                                                                                                                                                                                           |
    |------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Component        | Name of the Visio component: *ServiceManager*.                                                                                                                                                                       |
    | CommandPrefix    | Optional prefix added to the command name (in the shape containing the command, see below) in case multiple identical commands have to be configured for different instances of the same component (e.g. “*One\_*”). |
    | ComponentOptions | To hide the default “Save” and “Discard” buttons of the Service Manager component, specify: *HideSaveDiscardButtons=true*                                                                                            |

    > [!TIP]
    > See also:
    > [Embedding a Service Manager component](#embedding-a-service-manager-component)

2. Add the following shape data fields to the command control shape:

    | Shape data | Value                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
    |--------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Command      | Name of the command to be executed when the shape is clicked. <br> The following commands are available:<br> -  *SaveAll*: Saves all pending changes.<br>Can be used when the Service Manager shape has no interface value specified or when it is configured with **ComponentOptions**: *interface=Overview*.<br> -  *DiscardAll*: Discards all pending changes.<br>Can be used when the Service Manager shape has no interface value specified or when it is configured with **ComponentOptions**: *interface=Overview*.<br> -  *SaveCurrent*: Saves pending changes for the current service definition.<br>Can be used when the Service Manager shape is configured with **ComponentOptions**: *interface=Definition*<br> -  *DiscardCurrent*: Discards pending changes for the current service definition.<br>Can be used when the Service Manager shape is configured with **ComponentOptions**: *interface=Definition*<br> Optionally, you can include the command prefix specified in the shape of the Service Manager component, e.g. “*One_SaveAll*”. |
    | Scope        | The scope of the command:<br> -  *Page* (default): All components that can execute the configured command on the same Visio page.<br> -  *Card*: All components that can execute the configured command on all pages of the current Visio file.<br> -  *Application*: All components that can execute the configured command anywhere in the client application (e.g. DataMiner Cube)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               |

> [!NOTE]
> To show or hide shapes to indicate whether the commands are currently available, you can use the *HasPendingChanges* session variable. See [Using session variables with a Service Manager component](#using-session-variables-with-a-service-manager-component).
>
