---
uid: Embedding_a_Service_Manager_component
---

# Embedding a Service Manager component

From DataMiner 9.5.4 onwards, for systems with the appropriate licenses, it is possible to embed a Service Manager component in Visio. With this component, you can essentially embed the *Services* app in Visio.

> [!TIP]
> See also: [Service and Resource Management](xref:SRM#service-and-resource-management)

## Basic shape data field configuration

Configure the following shape data fields on the shape that is to contain the Service Manager component:

1. To define the component as an embedded Service Manager component, add the following shape data:

   | Shape data field | Value          |
   |------------------|----------------|
   | Component        | ServiceManager |

1. To further configure the component, add the shape data field **ComponentOptions**, and specify the necessary options as its value. Separate the options by semicolons (";"). The following options are supported:

   - **AutoLoadExternalChanges=** : When set to *true*, external changes are automatically loaded, if there have been no local changes. This keeps an information bar from being displayed at the bottom of the visual overview, asking the user to load or discard the external changes.
   - **AutoIgnoreExternalChanges=** : Available from DataMiner 10.0.13 onwards. When set to *true*, external changes are automatically discarded. This keeps an information bar from being displayed at the bottom of the visual overview, asking the user to load or discard the external changes.

     > [!NOTE]
     > If the AutoLoadExternalChanges and AutoIgnoreExternalChanges component options are both used, AutoLoadExternalChanges will take precedence. As long as there are no (unsaved) client-side changes, external changes will be loaded automatically. As soon as there are (unsaved) client-side changes, external changes will be discarded.

   - **HideChildFunctions=*X*** : Available from DataMiner 9.5.5 onwards. Allows you to filter on particular functions that should not be displayed in the component. “X” should be a collection of GUIDs, separated by a comma. Alternatively, you can also specify *\** or *ALL*, to filter all child functions. Note that if you specify the parent GUID of a particular function, this will also block all child functions of that function. The GUIDs can be found in the function XMLs.
   - **HideHeader=** : When set to *true*, hides the service definition header (which includes the service definition name and description).
   - **HideTabs=** : When set to *true*, hides the tab selection, so that only the diagram tab is displayed.
   - **HideNodeConfiguration=** : When set to *true*, hides the lower part of the diagram, where the selected node can be configured.
   - **HideFunctionsTree=** : When set to *true*, hides the tree view on the left-hand side with functions to drag and drop. This will typically be used together with the “ReadOnly=” option.

     > [!NOTE]
     > The *HideChildFunctions*, *HideHeader*, *HideTabs*, *HideNodeConfiguration*, and HideFunctionsTree component options can only be used together with the component option *Interface=definition*.

   - **Interface=definition**: Links the shape to a service definition. (The service definition is determined by the *SelectedServiceDefinition* variable, mentioned below.)
   - **ReadOnly=** : When set to *true*, prevents the user from making any changes to the service definition.
   - **SessionVariablePrefix=*X*** : Defines an optional prefix (in this case “X”) for all session variable names linked with this component.
   - **ShowNodeIDs=** : Available from DataMiner 10.0.0/10.0.2 onwards. When set to *true*, displays the node IDs of the service definition.

   > [!TIP]
   > See also: [Configuring command controls for a Service Manager component](#configuring-command-controls-for-a-service-manager-component)

Example:

| Shape data field   | Value                                                                                                                                        |
|--------------------|----------------------------------------------------------------------------------------------------------------------------------------------|
| Component          | ServiceManager                                                                                                                               |
| ComponentOptions   | interface=definition;SessionVariablePrefix=SKYLINE;HideHeader=true;HideTabs=true;HideNodeConfiguration=true;AutoLoadExternalChanges=true |

## Using session variables with a Service Manager component

The following session variables can be used in a Visual Overview containing a Service Manager component:

- **HasPendingChanges**: Depending on whether any unsaved changes have been made to the service definition, this variable will be set to TRUE or FALSE.

  To be used with the *SaveAll*/*DiscardAll* commands. See [Configuring command controls for a Service Manager component](#configuring-command-controls-for-a-service-manager-component).

- **CurrentHasPendingChanges**: Available from DataMiner 9.5.9 onwards. Depending on whether any unsaved changes have been made to the service definition, this variable will be set to TRUE or FALSE.

  To be used with the *SaveCurrent*/*DiscardCurrent* commands. See [Configuring command controls for a Service Manager component](#configuring-command-controls-for-a-service-manager-component).

- **SelectedEdgeID**: The currently selected connection line.

  Format: {FromNodeID}.{FromInterfaceID} -\> {ToNodeID}.{ToInterfaceID}

  Example: `1.4 -> 2.1`

  > [!NOTE]
  > The direction is determined by the interface types (in, out, inout), not by the arrow in this string. |

- **SelectedInterfaceID**: The numeric ID of the currently selected interface of the currently selected node.
- **SelectedNodeID**: The numeric ID of the currently selected node on the diagram. From DataMiner 9.5.13 onwards, if multiple nodes are selected, the variable will contain a semicolon-separated list of IDs.
- **SelectedServiceDefinition**: The GUID of the currently selected service definition.

Examples:

- Example of a shape used to set the service definition selection (using the SKYLINE prefix):

  | Shape data field | Value |
  |-|-|
  | SetVar | SKYLINESelectedServiceDefinition:a1181fba-db34-4de3-ac7e-de7af87e335e |
  | Options | CardVariable |

- Example of a shape used to clear the current service definition selection (using the SKYLINE prefix):

  | Shape data field | Value |
  |-|-|
  | SetVar | SKYLINESelectedServiceDefinition:00000000-0000-0000-0000-000000000000 |
  | Options | CardVariable |

## Configuring command controls for a Service Manager component

From DataMiner 9.5.6 onwards, you can turn a shape into a command control that can be used to manipulate a Service Manager component. Depending on the configuration, the command control can be used to manipulate one particular component or several components, which can be on the same page, on the same card or anywhere in Cube.

1. Add the following shape data fields to the component shape:

   - **Component**: Set the value to the name of the component, i.e. *ServiceManager*.
   - **CommandPrefix**: Optional. Set the value to the prefix that should be added to the command name (in the shape containing the command, see below) in case multiple identical commands have to be configured for different instances of the same component (e.g. “*One\_*”).
   - **ComponentOptions**: To hide the default “Save” and “Discard” buttons of the Service Manager component, specify the value *HideSaveDiscardButtons=true*.

   > [!TIP]
   > See also: [Embedding a Service Manager component](#embedding-a-service-manager-component)

1. Add the following shape data fields to the command control shape:

   - **Command**: Set the value to the name of the command to be executed when the shape is clicked. The following commands are supported:

     - *SaveAll*: Saves all pending changes. Can be used when the Service Manager shape has no interface value specified or when it is configured with **ComponentOptions**: *interface=Overview*.
     - *DiscardAll*: Discards all pending changes. Can be used when the Service Manager shape has no interface value specified or when it is configured with **ComponentOptions**: *interface=Overview*.
     - *SaveCurrent*: Saves pending changes for the current service definition. Can be used when the Service Manager shape is configured with **ComponentOptions**: *interface=Definition*
     - *DiscardCurrent*: Discards pending changes for the current service definition. Can be used when the Service Manager shape is configured with **ComponentOptions**: *interface=Definition*

     Optionally, you can include the command prefix specified in the shape of the Service Manager component, e.g. “*One_SaveAll*”.

   - **Scope**: Set the value to the scope of the command:

     - *Page* (default): All components that can execute the configured command on the same Visio page.
     - *Card*: All components that can execute the configured command on all pages of the current Visio file.
     - *Application*: All components that can execute the configured command anywhere in the client application (e.g. DataMiner Cube).

> [!NOTE]
> - If you want to use a command with *Page* scope, you must add the shape data **Options** to the ServiceManager shape and set it to *PageVariable*. Similarly, if you want to use a command with *Card* scope, you must add the shape data **Options** to the ServiceManager shape and set it to *CardVariable*. For the *Application* scope, no such restriction applies.
> - To show or hide shapes to indicate whether the commands are currently available, you can use the *HasPendingChanges* session variable. See [Using session variables with a Service Manager component](#using-session-variables-with-a-service-manager-component).
