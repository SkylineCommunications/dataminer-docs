---
uid: Triggering_an_action_when_the_mouse_pointer_hovers_over_a_shape
---

# Triggering an action when the mouse pointer hovers over a shape

A shape can be set to perform a particular action when a mouse pointer hovers over it.

> [!TIP]
> See also: [Triggering an action when a shape is dragged onto another shape](xref:Triggering_an_action_when_a_shape_is_dragged_onto_another_shape)

> [!NOTE]
>
> - For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[data > DRAG AND DROP]* page.
> - To configure a different hover style for a shape, see [Configuring the hover area of a shape](xref:Configuring_the_hover_area_of_a_shape).

## Configuring the shape data field

Add two shape data fields to the shape:

- one of type **Element** or **View**, of which you leave the value empty, and
- one of type **HoverTarget**, of which you set the value to "TRUE".

This "hover" behavior will often be implemented to take a quick peek at element or service properties.

> [!NOTE]
> This feature can only be used with shapes linked to elements, redundancy groups, services and views.

## Example of a 'hover target' that visualizes the element name

First, turn a shape into a "hover target" (i.e. a shape that will visualize data linked to shapes over which the mouse pointer will hover) by adding the following shape data items to it:

- **Element**: \<empty>
- **HoverTarget**: TRUE
- **Info**: ELEMENT NAME

> [!NOTE]
> Remember to enter an asterisk ("\*") in the shape text.

Then make sure that the shapes over which the mouse pointer will hover contain valid shape data. In this example, all these shapes should contain a valid element ID:

- **Element**: DmaID/ElementID

  Example: `111/313`

When the mouse pointer hovers over a shape with a valid element ID, the text inside the "hover target" will now display the name of the element referred to by the element ID specified in the shape data of the shape over which the mouse pointer hovers.
