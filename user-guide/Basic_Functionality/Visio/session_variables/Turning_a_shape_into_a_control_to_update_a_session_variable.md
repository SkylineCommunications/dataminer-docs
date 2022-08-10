---
uid: Turning_a_shape_into_a_control_to_update_a_session_variable
---

# Turning a shape into a control to update a session variable

Using a shape data field of type **SetVar**, you can turn a shape or a page into a control that allows users to update a session variable.

> [!TIP]
> See also:
>
> - [Adding options to a session variable control](xref:Adding_options_to_a_session_variable_control)
> - [Initializing a session variable](xref:Initializing_a_session_variable)
> - [Making a shape display the current value of a variable](xref:Making_a_shape_display_the_current_value_of_a_variable)
> - [Embedding a router control component](xref:Embedding_a_router_control_component)

> [!TIP]
> For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[data > VARIABLE1]* page.

## Configuring the shape data field

Add a shape data field of type **SetVar** to the shape or the page, and set its value as described below.

> [!NOTE]
> If the **SetVar** shape data field is applied on page level, the variable(s) you specified will be set whenever a user clicks the background of the page.

- If you want the user to be able to enter the new value in a text box:

  ```txt
  VariableName
  ```

- If you want the variable to be updated the moment someone clicks the shape:

  ```txt
  VariableName:NewValue
  ```

  > [!NOTE]
  > To initialize multiple values, separate the entries by pipe characters.

- If you want the user to be able to select the new value from a drop-down list with fixed values:

  ```txt
  VariableName:NewValue1:NewValue2:...:NewValueX
  ```

- If you want the user to be able to select the new value from a list of values stored in a (table) parameter:

  ```txt
  [Sep::X]VariableNameX[Param:dmaid/eid,pid]
  ```

  *\[Sep::X\]* allows you to specify the separator that is used in the parameter assignment to separate the variable name from its new value(s), and to separate the values found in the parameter you refer to:

  - The default separator is mentioned first: colon (":").
  - X is the separator used in the parameter, e.g. semicolon (";").

  Example: If the parameter you refer to contains the value "one;two;three", then you have to specify that the separator is ";" instead of ":". So, in the shape data field of type **SetVar**, you will enter "\[Sep::;\]VariableName;\[Param:...\]".

  > [!NOTE]
  > If the Visio file is linked to the protocol, "dmaid/eid" can be replaced by "\*".

- If you want the user to be able to select the new value from a right-click menu:

  ```txt
  Variable 1:A:Set 'Variable 1' to 'A'|Variable 2:B:Set 'Variable 2' to 'B'
  ```

  If you specify the value mentioned below, the shortcut menu will have the following two options:

  - Set 'Variable 1' to 'A', and
  - Set 'Variable 2' to 'B'

- If you want a session variable to be populated with a trace value when the user hovers the mouse over the graph in a trend component, set the value to "ValueTrace:", "MinTrace:", "MaxTrace:" or "TimeTrace:", followed by the name of the session variable.

  See [Configuring session variables to be set from trace points](xref:Linking_a_shape_to_a_trend_component#configuring-session-variables-to-be-set-from-trace-points)

## Indicating the scope of the variable

Session variables can have one of following scopes:

- Current DataMiner Cube session (default scope)
- Current DataMiner Cube card
- Current Visio page
- Current workspace (from DataMiner 9.5.9 onwards)

To a scope other than the default scope, add an additional shape data field of type **Options** to the shape, and specify the following value:

| Scope              | Value              |
| ------------------ | ------------------ |
| Current card       | CardVariable       |
| Current Visio page | PageVariable       |
| Current workspace  | WorkspaceVariable. |

## Examples

```txt
MyVar
MyVar:25
MyVar:[Param:7/124,54]
[Sep::;]MyVar;[Param:7/124,54]
MyFirstVar:0\|MySecondVar:5\|...
```
