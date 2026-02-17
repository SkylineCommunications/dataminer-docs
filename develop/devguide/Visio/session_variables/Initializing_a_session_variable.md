---
uid: Initializing_a_session_variable
description: You can initialize (i.e., declare) a session variable by adding a shape data field of type InitVar to a page of a Visio drawing.
---

# Initializing a session variable

By adding a shape data field of type **InitVar** to a page of a Visio drawing, you can initialize (i.e., declare) a session variable. The session variable will be loaded as soon as the page is opened in DataMiner.

> [!TIP]
> See also:
>
> - [Making a shape display the current value of a variable](xref:Making_a_shape_display_the_current_value_of_a_variable)
> - [Turning a shape into a control to update a session variable](xref:Turning_a_shape_into_a_control_to_update_a_session_variable)
> - [Adding options to a session variable control](xref:Adding_options_to_a_session_variable_control)

> [!TIP]
> For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[data > VARIABLE1]* page.

## Configuring the shape data field

Add a shape data field of type **InitVar** to the page, and set its value to:

```txt
VariableName:Value
```

Dynamic content is supported in this shape data. You can use the placeholders [\[Guid\]](xref:Placeholders_for_variables_in_shape_data_values#guid), [\[thisusername\]](xref:Placeholders_for_variables_in_shape_data_values#thisusername), [\[thisuserfullname\]](xref:Placeholders_for_variables_in_shape_data_values#thisuserfullname), [\[ThisGroup\]](xref:Placeholders_for_variables_in_shape_data_values#thisgroup), [\[thismac\]](xref:Placeholders_for_variables_in_shape_data_values#thismac), [\[This Service\]](xref:Placeholders_for_variables_in_shape_data_values#this-service), [\[This ServiceID\]](xref:Placeholders_for_variables_in_shape_data_values#this-serviceid), [\[This EnhancedServiceID\]](xref:Placeholders_for_variables_in_shape_data_values#this-enhancedserviceid), [\[This View\]](xref:Placeholders_for_variables_in_shape_data_values#this-view), [\[This ViewID\]](xref:Placeholders_for_variables_in_shape_data_values#this-viewid), [\[This Element\]](xref:Placeholders_for_variables_in_shape_data_values#this-element), [\[This ElementID\]](xref:Placeholders_for_variables_in_shape_data_values#this-elementid), [\[This Card Object\]](xref:Placeholders_for_variables_in_shape_data_values#this-card-object), [\[This Card ObjectID\]](xref:Placeholders_for_variables_in_shape_data_values#this-card-objectid), or [\[FirstMac\]](xref:Placeholders_for_variables_in_shape_data_values#firstmac).

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
