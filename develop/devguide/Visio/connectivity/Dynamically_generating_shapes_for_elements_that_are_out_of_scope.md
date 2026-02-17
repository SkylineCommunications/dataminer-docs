---
uid: Dynamically_generating_shapes_for_elements_that_are_out_of_scope
---

# Dynamically generating shapes for elements that are out of scope

To make it possible to display external connections to elements that are not displayed in the Visio drawing, shapes representing those elements can be generated dynamically.

To enable this, add two shapes to the Visio drawing and configure them as follows:

1. Add a shape data field of type **Connection** to the first shape and set its value to “*UnavailableElement*”.

1. Optionally, apply the following additional configuration to the shape:

   - The dynamically created shapes will be placed vertically, above and under this template shape. If you want them to be placed horizontally, add a shape data field of type **ExpandDirection** to the template shape, and set it to “*horizontal*”.

   - By default, there is no margin between the dynamically created shapes. If you want a margin, add a shape data field of type **ChildMargin** to the template shape, and specify either a fixed margin (i.e., a number of pixels) or a relative margin (in relation to its width or height). For example, for a relative margin you could specify “1/10”.

   - Optionally, the connections to be used can be filtered by connection property. To do so, add a shape data field of type **Filter** to the template shape, and set it to “*property:x=y*” (x being the name of the connection property, and y being the value of the connection property).

   For an overview of the shape data fields that can be added to the first shape, refer to the following table:

   | Shape data field | Value |
   |--|--|
   | Connection | *UnavailableElement* |
   | ExpandDirection | *vertical*/*horizontal*<br> - This setting determines the direction in which the new shapes will be created.<br> Default: vertical |
   | ChildMargin | A fixed margin size (a number of pixels), or a relative margin size (in relation to its width or height)<br> Example of a relative margin size: 1/10<br> Default: No margin |
   | Filter | *property:x=y*<br> - x = name of connection property<br> - y = value of connection property |

1. Add a shape data field of type **Connection** to the second shape and set its value to “*UnavailableElementsConnectivity*”.

   The line style of this shape will determine the line style of the connections towards the unavailable elements.

   | Shape data field | Value |
   |--|--|
   | Connection | UnavailableElementsConnectivity |
