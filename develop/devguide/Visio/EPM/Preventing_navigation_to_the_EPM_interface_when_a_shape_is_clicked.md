---
uid: Preventing_navigation_to_the_EPM_interface_when_a_shape_is_clicked
---

# Preventing navigation to the EPM interface when a shape is clicked

When you have set the shape data field **ChildType** to “*FixedRow*”, you can set the shape data field **Navigate** to “*None*”. In EPM environments, this will prevent navigation to the EPM interface when a shape is clicked.

Note, however, that users can still navigate to the EPM interface after right-clicking a shape.

This “None” option is most useful when used in conjunction with shape data fields of type **AlarmFilter**. Clicking a shape will then only cause the Alarm Console to get filtered.

> [!TIP]
> See also:
> [Making a shape filter Alarm Console tabs when clicked](xref:Making_a_shape_filter_Alarm_Console_tabs_when_clicked)

## Configuring the shape data field

Add a shape data field of type **Navigate** to the shape, and set its value to “*None*”.
