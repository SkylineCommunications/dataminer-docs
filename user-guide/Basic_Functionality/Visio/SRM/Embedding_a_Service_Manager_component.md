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
   - **FunctionTypes=** : Available from DataMiner 10.2.7/10.3.0 onwards. Can be used as a filter to only include specific types of functions.

     Should be set to a comma-separated list of values. Possible values:

     - Undefined (i.e. NULL value)
     - UserTask
     - ScriptTask
     - ResourceTask
     - Gateway
     - NoneStartEvent
     - TimeStartEvent
     - EndEvent

     This component option only works in conjunction with the options *Interface=definition* or *Interface=definitions*. It can be used in combination with the *HideChildFunctions* option, and it can be set dynamically via session variables.

     The filter will be cleared when no FunctionTypes option is specified or when the FunctionTypes option is set to an empty list of values. Parent functions that do not match the filter but have child functions that match the filter will be displayed in the function tree so that it is possible to navigate to one of the child functions.

   - **HideAddButton** : Available from DataMiner 10.2.6/10.3.0 onwards. When set to *true*, no options to add a service definition will be displayed.
   - **HideChildFunctions=*X*** : Available from DataMiner 9.5.5 onwards. Allows you to filter on particular functions that should not be displayed in the component. “X” should be a collection of GUIDs, separated by a comma. Alternatively, you can also specify *\** or *ALL*, to filter all child functions. Note that if you specify the parent GUID of a particular function, this will also block all child functions of that function. The GUIDs can be found in the function XMLs.
   - **HideDeleteButton** : Available from DataMiner 10.2.6/10.3.0 onwards. When set to *true*, no options to delete a service definition will be displayed.
   - **HideHeader=** : When set to *true*, hides the service definition header (which includes the service definition name and description).
   - **HideTabs=** : When set to *true*, hides the tab selection, so that only the diagram tab is displayed.
   - **HideNodeConfiguration=** : When set to *true*, hides the lower part of the diagram, where the selected node can be configured.
   - **HideFunctionsTree=** : When set to *true*, hides the tree view on the left-hand side with functions to drag and drop. This will typically be used together with the “ReadOnly=” option.
   - **Interface=**: Determines which part of the Service Manager user interface is displayed. Can be set to the following values:

     - **overview**: Makes the shape show the entire Services module.
     - **definition**: Links the shape to a single service definition. (The service definition is determined by the *SelectedServiceDefinition* variable, mentioned below.)
     - **definitions**: Makes the shape show the *Definitions* > *Recent* tab of the Services module. Supported from DataMiner 10.2.6/10.3.0 onwards.

   - **ReadOnly=** : When set to *true*, prevents the user from making any changes to the service definition.
   - **SessionVariablePrefix=*X*** : Defines an optional prefix (in this case “X”) for all session variable names linked with this component.
   - **ShowNodeIDs=** : Available from DataMiner 10.0.0/10.0.2 onwards. When set to *true*, displays the node IDs of the service definition.

   > [!NOTE]
   >
   > - If the AutoLoadExternalChanges and AutoIgnoreExternalChanges component options are both used, AutoLoadExternalChanges will take precedence. As long as there are no (unsaved) client-side changes, external changes will be loaded automatically. As soon as there are (unsaved) client-side changes, external changes will be discarded.
   > - The *HideChildFunctions*, *HideHeader*, *HideTabs*, *HideNodeConfiguration*, and *HideFunctionsTree* component options can only be used together with the component options *Interface=definition* or *interface=definitions*.

   > [!TIP]
   > See also: [Configuring command controls for a Service Manager component](#configuring-command-controls-for-a-service-manager-component)

Example:

| Shape data field | Value |
|--|--|
| Component | ServiceManager |
| ComponentOptions | interface=definition;SessionVariablePrefix=SKYLINE;HideHeader=true;HideTabs=true;HideNodeConfiguration=true;AutoLoadExternalChanges=true |

## Using session variables with a Service Manager component

The following session variables can be used in a Visual Overview containing a Service Manager component:

- **HasPendingChanges**: Depending on whether any unsaved changes have been made to the (selected) service definition, this variable will be set to true or false.

  Recommended when *SaveAll*/*DiscardAll* commands are used. See [Configuring command controls for a Service Manager component](#configuring-command-controls-for-a-service-manager-component).

- **CurrentHasPendingChanges**: Available from DataMiner 9.5.9 onwards. Depending on whether any unsaved changes have been made to the (selected) service definition, this variable will be set to true or false.

  Recommended when *SaveAll*/*DiscardAll* commands are used. See [Configuring command controls for a Service Manager component](#configuring-command-controls-for-a-service-manager-component).

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

     - *SaveAll*: Saves all pending changes. Can be used when the Service Manager shape has no interface value specified or when it is configured with **ComponentOptions**: *interface=overview* or *interface=definitions*.
     - *DiscardAll*: Discards all pending changes. Can be used when the Service Manager shape has no interface value specified or when it is configured with **ComponentOptions**: *interface=overview* or *interface=definitions*.
     - *SaveCurrent*: Saves pending changes for the current service definition. Can be used when the Service Manager shape is configured with **ComponentOptions**: *interface=definition*.
     - *DiscardCurrent*: Discards pending changes for the current service definition. Can be used when the Service Manager shape is configured with **ComponentOptions**: *interface=definition*.

     Optionally, you can include the command prefix specified in the shape of the Service Manager component, e.g. “*One_SaveAll*”.

   - **Scope**: Set the value to the scope of the command:

     - *Page* (default): All components that can execute the configured command on the same Visio page.
     - *Card*: All components that can execute the configured command on all pages of the current Visio file.
     - *Application*: All components that can execute the configured command anywhere in the client application (e.g. DataMiner Cube).

> [!NOTE]
>
> - If you want to use a command with *Page* scope, you must add the shape data **Options** to the ServiceManager shape and set it to *PageVariable*. Similarly, if you want to use a command with *Card* scope, you must add the shape data **Options** to the ServiceManager shape and set it to *CardVariable*. For the *Application* scope, no such restriction applies.
> - To show or hide shapes to indicate whether the commands are currently available, you can use the *HasPendingChanges* session variable. See [Using session variables with a Service Manager component](#using-session-variables-with-a-service-manager-component).

## Configuring filters for a Service Manager component

From DataMiner 10.2.6/10.3.0 onwards, when you configure a Service Manager component with the shape data field **ComponentOptions** set to *interface=definitions*, you can combine this with a **Filter** shape data field in order to filter the service definitions in the list.

> [!TIP]
> This is similar to the filtering of a *ListView* component. See [List view filters](xref:Creating_a_list_view#list-view-filters).

The following properties are supported for the filter:

- Name (String)
- Description (String)
- IsTemplate (Boolean)
- ID (GUID)
- CreatedBy (String)
- CreatedAt (DateTime)
- LastModifiedBy (String)
- LastModified (DateTime)
- NodeFunctionIDs (List\<Guid>)
- Properties (IDictionary\<string, dynamic>)
- ServiceDefinitionType (Int): This is an enum with the following possible values:

  - 0 = Default (representing the type "SRM" in Cube)
  - 1 = ProcessAutomation (representing the type "Skyline Process Automation" in Cube)
  - 2 = CustomProcessAutomation (representing the type "Custom Process Automation" in Cube)

Examples:

- This filter will only show service definitions of type "Skyline Process Automation" or "Custom Process Automation":

  | Shape data field | Value |
  |-|-|
  | Filter | ServiceDefinition.ServiceDefinitionType\[Int32] == 1 \|\| ServiceDefinition.ServiceDefinitionType\[Int32] == 2 |

- This filter will only show service definitions with the property *Virtual Platform* set to VPA:

  | Shape data field | Value |
  |-|-|
  | Filter | ServiceDefinition.Properties."Virtual Platform" == "VPA" |
