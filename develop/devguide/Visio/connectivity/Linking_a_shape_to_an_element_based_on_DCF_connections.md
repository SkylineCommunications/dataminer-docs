---
uid: Linking_a_shape_to_an_element_based_on_DCF_connections
---

# Linking a shape to an element based on DCF connections

It is possible to dynamically link a Visio shape to an element based on DCF connection information. This feature can be used to resolve a dynamic element between two fixed elements.

To link a shape to an element based on DCF connection information:

1. Draw shapes representing the two fixed elements and the dynamic element, and draw connection lines between them.

   > [!TIP]
   > For information on how to link the fixed element shapes to the relevant elements, refer to [Linking a shape to an element, a service or a redundancy group](xref:Linking_a_shape_to_an_element_a_service_or_a_redundancy_group).

1. Add the [HighlightPath](xref:Options_for_highlighting_DCF_connections#controlling-highlighting-when-using-physical-connectors) option on page level.

1. Add the following shape data fields to the dynamic shape:

   | Shape data field | Value |
   |--|--|
   | Element | \* |
   | ResolveWithDCF | *True\|ServiceFilter=ServiceIdOrServiceName*<br> Specifying a service ID or service name is optional, and requires the *ServiceFilter=* keyword. If you specify a service ID or a service name, only connections to elements in the specified service will be taken into account. |

> [!NOTE]
> Currently, this feature can only be used to resolve one dynamic element between two fixed elements. If you were to draw multiple *ResolveWithDCF* shapes between the two fixed shapes, these would all be assigned the first element found.
