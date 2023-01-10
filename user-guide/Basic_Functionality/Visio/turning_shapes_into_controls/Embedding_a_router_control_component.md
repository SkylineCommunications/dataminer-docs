---
uid: Embedding_a_router_control_component
---

# Embedding a router control component

It is possible to embed a router control component in Visual Overview.

> [!TIP]
> See also:
> [Router Control](xref:RouterControl)

## Configuring the shape data fields

Add a shape data field of type **Component** to the shape, and set its value to “*RouterControl*”.

In addition, you can add a shape data field of type **ComponentOptions**, and set its value to:

```txt
SessionVariablePrefix=RC;ShowHeaderTabs;ShowHeaderBar
```

- **SessionVariablePrefix**: Can be used to assign a unique prefix to the set of session variable names in order to avoid any conflicts.

- **ShowHeaderTabs**: If this option is included, the header will contain all the matrix tabs for the currently activated configuration.

- **ShowHeaderBar**: If this option is included, the header will contain a bar showing “Router Control”, the selected matrix name, the configuration, and an edit button.

## Session variables used with router control components

If a router control component is embedded in Visio, you can use the following session variables:

| Session variable      | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                     |
|-----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| SelectedConfig        | The name of the currently selected configuration.                                                                                                                                                                                                                                                                                                                                                                                                               |
| SelectedMatrix        | The name of the currently selected matrix tab.                                                                                                                                                                                                                                                                                                                                                                                                                  |
| SelectedMatrixElement | A reference to the element of the currently selected matrix tab.<br> Format: dmaid/elementid                                                                                                                                                                                                                                                                                                                                                                    |
| SelectedInput         | The label of the currently selected input.                                                                                                                                                                                                                                                                                                                                                                                                                      |
| SelectedInputIndex    | The 1-based index of the input in the matrix.                                                                                                                                                                                                                                                                                                                                                                                                                   |
| SelectedOutput        | The label of the currently selected output.                                                                                                                                                                                                                                                                                                                                                                                                                     |
| SelectedOutputIndex   | The 1-based index of the input in the matrix.                                                                                                                                                                                                                                                                                                                                                                                                                   |
| Action                | A write-only session variable that can be assigned one of two values:<br> -  NavigateToSelectedInput, and<br> -  NavigateToSelectedOutput.<br> Use this option to navigate to the first occurrence of these input/output buttons to ensure that they are visible on the screen (they could be located on an unselected tab page). |
| SelectedDCFInputID    | The interface ID of the selected input. (Available from DataMiner 9.5.1 onwards.)                                                                                                                                                                                                                                                                                                                                                                               |
| SelectedDCFInputName  | The interface name of the selected input. (Available from DataMiner 9.5.1 onwards.)                                                                                                                                                                                                                                                                                                                                                                             |
| SelectedDCFOutputID   | The interface ID of the selected output. (Available from DataMiner 9.5.1 onwards.)                                                                                                                                                                                                                                                                                                                                                                              |
| SelectedDCFOutputName | The interface name of the selected output. (Available from DataMiner 9.5.1 onwards.)                                                                                                                                                                                                                                                                                                                                                                            |

> [!NOTE]
> The *SelectedMatrix* and *SelectedMatrixElement* variables are used for the same purpose, i.e. to refer to the corresponding matrix. If both variables are used at the same time, the system will first check the *SelectedMatrix* variable, and if no result is found, the *SelectedMatrixElement* variable will then be checked.

## Example

Using the router control session variables, it is possible to create a “preset” button to navigate to the desired configuration/matrix and select input and output with a single click:

```txt
SetVar:SelectedConfig:custom|SelectedMatrix:22x33|SelectedOutputIndex:1| SelectedInputIndex:1|Action:NavigateToSelectedInput| Action:NavigateToSelectedOutput
```

> [!TIP]
> See also: [Turning a shape into a control to update a session variable](xref:Turning_a_shape_into_a_control_to_update_a_session_variable)
