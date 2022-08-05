---
uid: Linking_a_shape_to_a_view
---

# Linking a shape to a view

Using a shape data field of type **View**, you can link a shape to view.

By default, this will cause the Visio drawing linked to that view to be opened each time a user clicks the shape.

> [!TIP]
> See also:
>
> - [Disabling the default hyperlink behavior of a linked shape](xref:Disabling_the_default_hyperlink_behavior_of_a_linked_shape)
> - [Making a shape launch the Device Discovery app](xref:Making_a_shape_launch_the_Device_Discovery_app)

> [!NOTE]
>
> - Visio shapes linked to views will not be displayed if, for any reason, those links cannot be resolved. Link problems can occur due to insufficient user rights, missing DataMiner items, invalid parameter values, etc.
> - For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[linking > OBJECTS]* page.

## Configuring the shape data field

To link to a view, add a shape data field of type **View** to the shape, and set its value to:

```txt
View ID
```

or

```txt
View name
```

To link to a particular tab page of a view, add the zero-based index of the tab page, separated from the view name or view ID with a pipe character.

```txt
View ID|tab page index
```

> [!NOTE]
>
> - If you want to link the shape to the root of the Surveyor, enter "-1", "root", or the name of the root.
> - While using the name of a view might be more convenient, we advise you to always use its (unique) ID. If, in a Visio drawing, you use the name of a view, the link to that view will be broken the moment someone changes that name. If, on the other hand, you use the view ID, the link to that view will remain, even if its name is changed.

## Customizing the displayed view alarm level

From DataMiner 10.0.5 onwards, you can specify which of the view's alarm levels should be reflected by the shape's background color: the alarm level of the monitored aggregation rules on the view, the alarm level of the child objects of the view, or a combination of both.

To do so, add a shape data field of type **AlarmLevel**, and set it to one of the values specified below:

| Shape data field | Value |
| ---------------- | ----- |
| AlarmLevel | One of the following values should be specified:<br>- **Instance**: Displays the alarm level of the monitored aggregation rules on the view.<br>- **BubbleUp**: Displays the highest alarm level of any child object.<br>- **Summary**: Displays the highest of the *Instance* and *BubbleUp* alarm levels. |

## Examples

```txt
49
```

If you set the value above, clicking the shape will open the Visio drawing linked to the view with ID 49.

```txt
MySpecialView
```

If you set the value above, clicking the shape will open the Visio drawing linked to the view named "MySpecialView".

```txt
Main Site|2
```

If you set the value above, clicking the shape will open the Visio drawing linked to the view named "Main Site", on its second tab page.
