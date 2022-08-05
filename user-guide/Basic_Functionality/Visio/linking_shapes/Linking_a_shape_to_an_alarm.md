---
uid: Linking_a_shape_to_an_alarm
---

# Linking a shape to an alarm

Using a shape data field of type **Alarm**, you can link a shape to an active alarm.

> [!NOTE]
>
> - Shape data fields of type **Alarm** are mostly used in combination with shape data fields of type **Info**. See [Making a shape display information about the item it is linked to](xref:Making_a_shape_display_information_about_the_item_it_is_linked_to).
> - If you want to link to the alarm state of a parameter, use a shape data field of type **Parameter** instead of **Alarm**. See [Linking a shape to an element parameter](xref:Linking_a_shape_to_an_element_parameter).
> - For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[linking > ALARM]* page.
> - If a shape is linked to an alarm, from DataMiner 10.0.2 onwards, you can use *Info* keywords in the shape text, by placing them in square brackets in the text. For example: "The value of the alarm is **\[value\]**." See [Making a shape display information about the item it is linked to](xref:Making_a_shape_display_information_about_the_item_it_is_linked_to).

## Configuring the shape data field

Add a shape data field of type **Alarm** to the shape.

- To link the shape to an alarm on a simple parameter, set the value of the shape data field to:

  ```txt
  ElementReference/ParameterID|Options
  ```

  See [ElementReference](#elementreference) and [Options](#options)

- To link the shape to an alarm on a table parameter, set the value of the shape data field to:

  ```txt
  ElementReference/ParameterID:TableRowKey|Options
  ```

  See [ElementReference](#elementreference) and [Options](#options)

  > [!NOTE]
  >
  > - Table rows can be referenced either by primary key or by display key.
  > - The table row key can contain "\*" and "?" wildcards. Example: "2/36/114:Equip\* 4\|Alarm"

- To link the shape to an alarm via the root alarm ID, set the value of the shape data field to:

  ```txt
  DmaID/RootAlarmID
  ```

  This syntax is available from DataMiner 10.0.2 onwards. The IDs are typically retrieved from session variables. If the configured alarm is not found, the shape will not be displayed.

### ElementReference

You can refer to an element in the following ways:

- DmaID/ElementID.
- Element name (though the ID is preferable, as the name can easily be adapted, which will cause the reference to become invalid).
- Element name mask containing wildcard characters ("?" and/or "\*").

  In the latter case, the shape will dynamically refer to the first element in the view of which the name matches that name mask.

> [!NOTE]
> If the Visio drawing is linked to an element, you can link the shape to that same element by using an asterisk ("\*") as element reference.

### Options

In the field value, you can use the following options.

- **ALARM**: The shape will take the color of the current alarm state.

  > [!NOTE]
  > When there is no alarm, the shape will take the "Normal" color, which is by default green (even if the parameter is not being monitored).

- **SHOW;condition**: The shape will be shown if the condition is TRUE.

- **HIDE;condition**: The shape will be hidden if the condition is TRUE.

> [!NOTE]
>
> - If you specify a SHOW or HIDE condition, the shape has to have a shape data field of type **Info** of which the value is set to the alarm property to be tested.<br>Example: If you specify "SHOW;!=critical high" in the **Alarm** field, then you have to specify "SEVERITY" in the **Info** field.
> - SHOW and HIDE conditions cannot be combined in one single **Alarm** field.
> - In conditions, both single equal signs ("=") and double equal signs ("==") are supported.

> [!TIP]
> See also: [Basic conditional shape manipulation actions](xref:Basic_conditional_shape_manipulation_actions)

## Examples

```txt
111/273/350
```

The shape will be linked to the alarm on parameter 350 of element 111/273 (i.e. DMA ID 111, Element ID 273).

```txt
111/273/350|ALARM
```

The shape will be linked to the alarm on parameter 350 of element 111/273, and it will also take the color of the current alarm state.

```txt
111/273/350|SHOW;=critical high
```

The shape will be linked to the alarm on parameter 350 of element 111/273 (i.e. DMA ID 111, Element ID 273), and it will only be shown if the alarm property specified in a separate shape data field of type **Info** (in this example, this would be "SEVERITY") has a value that is equal to "critical high".
