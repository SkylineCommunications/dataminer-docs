---
uid: Initializing_a_session_variable
---

# Initializing a session variable

By adding a shape data field of type **InitVar** to a page of a Visio drawing, you can initialize (i.e. declare) a session variable. The session variable will be loaded as soon as the page is opened in DataMiner.

> [!TIP]
> See also:
>
> - [Making a shape display the current value of a variable](xref:Making_a_shape_display_the_current_value_of_a_variable)
> - [Turning a shape into a control to update a session variable](xref:Turning_a_shape_into_a_control_to_update_a_session_variable)
> - [Adding options to a session variable control](xref:Adding_options_to_a_session_variable_control)

> [!NOTE]
>
> - For an example of use, refer to the view "Linking Shapes" on the [Ziine Demo System](xref:ZiineDemoSystem). The example can be found on the Visual page _data > VARIABLE1_.

## Configuring the shape data field

Add a shape data field of type **InitVar** to the page, and set its value to:

```txt
VariableName:Value
```

Depending on the DataMiner version, different placeholders are supported for this shape data field:

| Minimum DataMiner version | Supported placeholders                                                                                                                                                                                                                                                                                                                                              |
| ------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 9.0.0                     | _\[Guid\]_, _\[thisusername\]_, _\[thisuserfullname\]_ and _\[thismac\]_                                                                                                                                                                                                                                                                                            |
| 9.5.1                     | _\[ThisGroup\]_                                                                                                                                                                                                                                                                                                                                                     |
| 9.5.13                    | From this version onwards, dynamic content in general is supported in this shape data. This means the following placeholders are supported: _\[This Service\]_, _\[This ServiceID\]_, _\[This EnhancedServiceID\]_, _\[This View\]_, _\[This ViewID\]_, _\[This Element\]_, _\[This ElementID\]_, _\[This Card Object\]_, _\[This Card ObjectID\]_, _\[FirstMac\]_. |

> [!NOTE]
> If you want to initialize multiple values, separate the entries by pipe characters.

## Initializing a session variable with a GUID

If you want to initialize a session variable with a GUID, use the following syntax:

```txt
VariableName:[Guid]
```

## Examples

```txt
MyCounter:0
MyVar:1
VariableName1:value|VariableName2:value|...
```
