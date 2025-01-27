---
uid: Dynamically_generating_shapes_for_elements_connected_to_views_out_of_scope
---

# Dynamically generating shapes for elements connected to views out of scope

It is possible to have shapes created dynamically for elements with external connections to views that are not displayed on the Visio drawing.

To enable this, add two shapes to the Visio drawing and configure them as follows:

1. Add a shape data field of type **Connection** to the first shape and set its value to “*UnavailableView*”. This shape will function as the template shape.

1. Optionally, apply the following additional configuration to the template shape:

   - The dynamically created shapes will be placed vertically, above and under this template shape. If you want them to be placed horizontally, add a shape data field of type **ExpandDirection** to the template shape, and set it to “*horizontal*”.

   - By default, there is no margin between the dynamically created shapes. If you want a margin, add a shape data field of type **ChildMargin** to the template shape, and specify either a fixed margin (i.e. a number of pixels) or a relative margin (in relation to its width or height). For example, for a relative margin you could specify “1/10”.

   - Optionally, the connections to be used can be filtered by connection property. To do so, add a shape data field of type **Filter** to the template shape, and set it to “*property:x=y*” (x being the name of the connection property, and y being the value of the connection property).

     In that same shape data field of type **Filter**, you can also specify a view scope. If you do so, only the unavailable views underneath the view you specified will be shown. You can specify a view ID, the \[this view\] placeholder, or a variable containing a view ID.     For an overview of the shape data fields that can be added to the template shape, refer to the following table:

   | Shape data field | Value |
   |--|--|
   | Connection | UnavailableView |
   | ExpandDirection | vertical/horizontal<br> - This setting determines the direction in which the new shapes will be created.<br> Default: vertical |
   | ChildMargin | a fixed margin size (a number of pixels), or a relative margin size (in relation to its width or height)<br> Example of a relative margin size: 1/10<br> Default: No margin |
   | Filter | property:x=y\|ViewScope=z (optional)<br> - x = name of connection property<br> -  y = value of connection property<br> - z = view ID (ID, \[this view\], or variable)<br> Default: No filter |

1. Add a shape data field of type **Connection** to the second shape and set its value to “*UnavailableViewsConnectivity*”.

   The line style of this shape will determine the line style of the connections towards the unavailable views.

   | Shape data field | Value |
   |--|--|
   | Connection | UnavailableViewsConnectivity |
