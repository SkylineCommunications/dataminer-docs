---
uid: Linking_a_shape_to_an_element_a_service_or_a_redundancy_group
---

# Linking a shape to an element, a service or a redundancy group

Using a shape data field of type **Element**, you can link a shape to an element, a service or a redundancy group.

When a user clicks such a shape, by default, the Visio drawing linked to the element, service or redundancy group will be opened.

> [!TIP]
> See also:
>
> - [Disabling the default hyperlink behavior of a linked shape](xref:Disabling_the_default_hyperlink_behavior_of_a_linked_shape)
> - [Adding options to shapes linked to elements or services](xref:Adding_options_to_shapes_linked_to_elements_or_services)
> - [Linking a shape to an element based on DCF connections](xref:Linking_a_shape_to_an_element_based_on_DCF_connections)

> [!NOTE]
>
> - Visio shapes linked to elements, services or redundancy groups will not be displayed if, for any reason, those links cannot be resolved. Link problems can occur because of insufficient user rights, missing DataMiner items, invalid parameter values, etc.
> - Depending on the configuration of a redundancy group, the right-click menu of a shape that is linked to it may contain switching options.
> - For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[linking > OBJECTS]* page.

In this section:

- [Basic shape data field configuration](#basic-shape-data-field-configuration)
- [Linking a shape to an element that is part of a service](#linking-a-shape-to-an-element-that-is-part-of-a-service)
- [Having a subshape of an Element shape display the alarm color of the element](#having-a-subshape-of-an-element-shape-display-the-alarm-color-of-the-element)
- [Having the Visio drawing opened in a new card](#having-the-visio-drawing-opened-in-a-new-card)
- [Making the shape navigate to a specific page](#making-the-shape-navigate-to-a-specific-page)
- [Service navigation](#service-navigation)

## Basic shape data field configuration

Add a shape data field of type **Element** to the shape. Set its value to the item reference, optionally followed by a pipe character ("\|") and the Visio page number (starting from 1) of the page that should be displayed.

```txt
ItemReference|VisioPage
```

If no Visio page is specified, the default page is opened when the shape is clicked.

### Item reference

You can refer to an element, service or redundancy group in the following ways:

- The ID of the DMA where the element, service or redundancy group was created, followed by a forward slash and the ID of the element, service or redundancy group. For an element, this is "DmaID/ElementID", for example 111/73.

  > [!NOTE]
  > Using the ID is preferable to using the name of the item. If the name is used, the link configured in Visio will be broken when someone changes the item's name. By using the ID, you ensure that the link keeps working as long as the item exists.

- Element name, service name, or service alias.

- Element name mask, service name mask, or service alias mask containing wildcard characters ("?" and/or "\*").

  If wildcard characters are used, the shape dynamically refers to the first element in the view to which the Visio file is linked. If no element matches the name mask in that view, then the elements in the services and subservices in that view (and, if necessary, all subviews) are also checked.

> [!NOTE]
>
> - If the Visio drawing is linked to an element, you can link the shape to that same element by using an asterisk ("\*") as element reference.
> - The item reference can contain placeholders like \[param\], \[this view\] or \[this service\].

### Examples

- To create a shape that will open the default page of the Visio drawing linked to the element, service or redundancy group with ID 111/273 (i.e. DMA ID 111, item ID 273):

  | Shape data field | Value   |
  | ---------------- | ------- |
  | Element          | 111/273 |

- To create a shape that will open the second page of the Visio drawing linked to the element, service or redundancy group with ID 111/273 (i.e. DMA ID 111, item ID 273):

  | Shape data field | Value      |
  | ---------------- | ---------- |
  | Element          | 111/273\|2 |

- To create a shape that will open the default page of the Visio drawing linked to the element called "MySpecialElement":

  | Shape data field | Value            |
  | ---------------- | ---------------- |
  | Element          | MySpecialElement |

## Linking a shape to an element that is part of a service

As service aliases are only unique within a particular service, using service aliases will only work in Visio files that are linked to a service and for items (elements or services) belonging to that service.

However, from DataMiner 9.6.12 onwards, it is possible to specify the following shape data in order to give a shape linked to a service child element or service a service context, even if the Visio file is not linked to the service:

| Shape data field | Value                              |
| ---------------- | ---------------------------------- |
| ServiceContext   | *Name, ID or alias of the service* |

For example, in a Visio file that is not linked to the service "MyService", you can create a shape linked to an element that is partially included in this service with the alias "MyPartiallyIncludedElement" as follows:

| Shape data field | Value                      |
| ---------------- | -------------------------- |
| Element          | MyPartiallyIncludedElement |
| ServiceContext   | MyService                  |

## Having a subshape of an Element shape display the alarm color of the element

If a shape is linked to an element, and a subshape of this shape should display the current alarm color of the element, add a shape data field of type **Parameter** to the subshape and set its value to "\*\|ALARM".

| Shape data field | Value     |
| ---------------- | --------- |
| Parameter        | \*\|ALARM |

This way, the subshape will show the worst alarm state of all parameters of the element, i.e. the alarm state of the element.

> [!TIP]
> See also: [Linking a shape to an alarm](xref:Linking_a_shape_to_an_alarm)

## Having the Visio drawing opened in a new card

In order to make sure that the Visio drawing of the element, service or redundancy group linked to the shape is opened in a new card, add the following shape data to the Element shape:

| Shape data field | Value         |
| ---------------- | ------------- |
| Options          | OpenInNewCard |

## Making the shape navigate to a specific page

By default, a shape linked to an element or service navigates to a Visual page when clicked. However, from DataMiner 9.6.12 onwards, you can make the shape navigate to a specific (visual, data or other) page instead.

To do so, add the following shape data to the shape:

| Shape data field | Value description |
| ---------------- | ----------------- |
| Page | \- For a Data page: "data" or "d", followed by a colon and the name of the page. To link to a subpage, add a forward slash and the name of the subpage. <br>For example: "data:performance/Task Manager"<br>- For a Visual page: "visual" or "v", followed by a colon and the name of the page.<br>For example: "v:ExamplePage"<br>- For a different page in the card side panel: a colon followed by the name of the page.<br>For example, to link to the Alarms page: ":alarms" |

## Service navigation

When, in a Visio drawing linked to a service, a user clicks a shape linked to another service, this other service is selected in the Surveyor. However, if that service is found in different locations in the Surveyor, DataMiner will use the following algorithm to determine the service to which to jump in the Surveyor:

1. Search underneath the service to which the Visio drawing is linked.
1. Search in the view containing the service to which the Visio drawing is linked.
1. Search in the entire Surveyor (top-down).
