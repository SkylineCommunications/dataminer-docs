## Making a shape display the current value of a variable

Using a shape data field of type **Variable**, you can make a shape display the current value of a variable.

> [!TIP]
> See also:
> - [Initializing a session variable](Initializing_a_session_variable.md)
> - [Turning a shape into a control to update a session variable](Turning_a_shape_into_a_control_to_update_a_session_variable.md)
> - [Adding options to a session variable control](Adding_options_to_a_session_variable_control.md)

### Configuring the shape data field

Add a shape data field of type **Variable** to the shape, and set its value to:

```txt
VariableName|Options
```

Also, if the scope of the variable is not the default scope (i.e. the current DataMiner Cube session), then add an additional shape data field of type **Options**, and set its value to the correct scope. See [Indicating the scope of the variable](Turning_a_shape_into_a_control_to_update_a_session_variable.md#indicating-the-scope-of-the-variable).

### Options

You can make a shape appear, disappear, flip or rotate based on the current value of a session variable, by adding certain options to the **Variable** shape data field.

> [!TIP]
> See also:
> [Basic conditional shape manipulation actions](Basic_conditional_shape_manipulation_actions.md)

### Placeholder for variable value in shape text

The value of the session variable will appear on the shape only if you add shape text that contains a “\*” character. This character will then be replaced by the current value of the property.

To add text to a shape, just double-click the shape, and enter the text.

### Using the current value of a session variable in an expression

If you want to use the current value of a session variable in an expression (e.g. the value of some shape data field), use a *\[var:...\]*, *\[WorkspaceVar:...\]*, *\[cardvar:...\]* or *\[pagevar:...\]* placeholder (depending on the scope). This way you can e.g. link a shape to an element or view using a session variable.
