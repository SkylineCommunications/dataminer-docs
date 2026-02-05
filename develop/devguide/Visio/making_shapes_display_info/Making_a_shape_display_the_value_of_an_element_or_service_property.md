---
uid: Making_a_shape_display_the_value_of_an_element_or_service_property
---

# Making a shape display the value of an element or service property

Using a shape data field of type **Property**, a shape linked to an element or a service can be set to display the current value of a certain property of that element or service.

> [!TIP]
>
> - See also: [Linking a shape to an element parameter](xref:Linking_a_shape_to_an_element_parameter)
> - For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[data > PROPERTIES]* page.

## Configuring the shape data field

Add a shape data field of type **Property** to the shape, and set its value to the name of a particular property:

```txt
PropertyName|Options
```

> [!NOTE]
> PropertyName can also contain placeholders like "\[param:...\]".

## Options

Optionally, you can make a shape appear, disappear, flip, or rotate based on the current value of a property.

> [!TIP]
> See also: [Basic conditional shape manipulation actions](xref:Basic_conditional_shape_manipulation_actions)

## Placeholder for property value in shape text

The value of the property will appear on the shape only if you add shape text that contains a "\*" character. This character will then be replaced by the current value of the property.

To add text to a shape, just double-click the shape, and enter the text.

## Example

```txt
Type|HIDE;=1|ROTATE;>1,30
```

The property named "Type" will be hidden if its current value is 1, and will be rotated 30 degrees when its current value is greater than 1.
