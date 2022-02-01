---
uid: Adding_options_to_shapes_linked_to_elements_or_services
---

# Adding options to shapes linked to elements or services

Using a shape data field of type **ElementOptions**, you can specify options to shapes linked to elements or services.

## Configuring the shape data field

Add a shape data field of type **ElementOptions** to the shape, and set its value to one of the options listed below.

## Options

The following options can be configured for shapes linked to elements or services:

- **IgnoreDynamicInclude**: If the Visio file is linked to a service and the shape is linked to an element by means of an element reference containing a wildcard, then adding a shape data field of type **ElementOptions** containing the value “*IgnoreDynamicInclude*” will make sure the shape representing the element is always displayed, even at times when that element is dynamically being excluded from the service.

- **ServiceIncludeState=inuse,notinuse,excluded**: If the Visio file is linked to a service and the shape is linked to an element by means of an element reference containing a wildcard, then adding a shape data field of type **ElementOptions** containing the value “*ServiceIncludeState*” will make sure the shape representing the element either appears or disappears depending on the current service include state of the service item to which it is linked.

    Possible values:

    - inuse

    - notinuse

    - excluded

    You can specify multiple states, separated by commas.     Example: If you want a shape only to be visible if the item to which it is linked is “in use”, then add to that shape a shape data field of type **ElementOptions**, and set its value to “*ServiceIncludeState=inuse*”.

    > [!NOTE]
    > These “*ServiceIncludeState=inuse,notinuse,excluded*” options can also be used when generating shapes based on child items in a service. See [Generating shapes based on child items in a view or a service](xref:Generating_shapes_based_on_child_items_in_a_view_or_a_service).
    >
