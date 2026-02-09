---
uid: Linking_a_shape_to_a_resource
---

# Linking a shape to a resource

From DataMiner 10.2.0/10.1.10 onwards, it is possible to link an **Element** shape to the last-known resource using that element.

1. Link the shape to an element. See [Basic shape data field configuration](xref:Linking_a_shape_to_an_element_a_service_or_a_redundancy_group#basic-shape-data-field-configuration).

1. Add an **Options** shape data field and set its value to *UseResource=True*.

   | Shape data field   | Value            |
   |--------------------|------------------|
   | Options            | UseResource=True |

> [!NOTE]
>
> - Within a service instance connectivity chain, the elements will automatically be linked to the resource.
> - Children of an element shape that has the *UseResource* option specified will automatically inherit this setting unless it is overridden.
> - You can use any of the placeholders listed for virtual function resources under [Making a shape display information about the item it is linked to](xref:Making_a_shape_display_information_about_the_item_it_is_linked_to). However, note that *\[Element Name\]* will only refer to the name of the resource’s virtual function element if this element can be found. Otherwise, it will refer to the name of the element that the shape is linked to. *\[Name\]* will always refer to the name of the element that the shape is linked to.
