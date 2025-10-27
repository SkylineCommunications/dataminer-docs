---
uid: IDs_of_views_elements_services_redundancy_groups_and_parameters
---

# Frequently asked questions about IDs of views, elements, services, redundancy groups and parameters

- [How do I find the ID of a view?](#how-do-i-find-the-id-of-a-view)

- [How do I find the ID of an element, service, or redundancy group?](#how-do-i-find-the-id-of-an-element-service-or-redundancy-group)

- [How do I find the ID of a parameter?](#how-do-i-find-the-id-of-a-parameter)

## How do I find the ID of a view?

In DataMiner Cube, right-click the view in the Surveyor and select *Properties*.

The view ID is displayed in the *general* tab, to the right of the name of the view.

## How do I find the ID of an element, service, or redundancy group?

> [!NOTE]
> The ID of an element, service or redundancy group always consists of two parts, separated by a forward slash:

- the ID of the DMA where the element, service or redundancy group was created, and

- the ID of the element, service, or redundancy group itself.

To find this ID in DataMiner Cube:

1. Open the view containing the element, service or redundancy group.

1. In the navigation panel on the left, go to *BELOW THIS VIEW > ALL*.

1. Check the *ID* column to find the ID of the element, service, or redundancy group.

> [!NOTE]
> Alternatively, for an element or service, you can also right-click the item in the Surveyor and select *Properties*. The ID is displayed in the *general* tab, to the right of the name of the view.

## How do I find the ID of a parameter?

1. Open the element card containing the parameter.
1. Double-click the parameter, or right-click the parameter and select *Open*.
1. On the *Details* tab, look for the ID displayed below the parameter name.

> [!NOTE]
> For more information on how to generate a list of all parameters for a particular element, see [Generating a list of all parameters in a protocol version](xref:Advanced_protocol_functionality#generating-a-list-of-all-parameters-in-a-protocol-version).
