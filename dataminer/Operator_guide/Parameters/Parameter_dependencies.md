---
uid: Parameter_dependencies
---

# Parameter dependencies

Parameter dependencies express relationships between two or more parameters of an element. They are defined in the element protocol.

Thanks to parameter dependencies, you can make a user specify multiple values, which will then be passed to the element in one single batch.

For example, suppose that users can have a message displayed on the front panel of a device for a certain period of time. A feature like that will normally require two values: a piece of text and a period of time.

- If the “dependency confirmation” setting is activated, then a user who sets one of the two parameters (e.g., the message) will also be asked to set the other parameter (e.g., the period of time).

- If the “dependency confirmation” setting is deactivated, then a user who sets one of the two parameters (e.g., the message) will not be asked to set the other parameter (e.g., the period of time). Instead, the current value of the other parameter (e.g., period of time) will be used. However, if no period of time has been defined yet, the user will be asked to provide a value.

Parameter dependencies can also be used to limit the possible values of one parameter depending on the value of another parameter.

##### Example

If parameter X is set to “1”, then parameter Y can be set to “A” or “B”. If, however, parameter X is set to “2”, then parameter Y can be set to “A” or “C”.

If you try to perform an action that is not allowed (e.g., set parameter Y to “C”) based on the contents of another parameter (e.g., parameter X is set to “1”), a message box will appear, indicating that the other parameter has to be changed first.
