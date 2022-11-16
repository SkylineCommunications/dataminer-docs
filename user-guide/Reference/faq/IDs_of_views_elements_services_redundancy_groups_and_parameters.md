---
uid: IDs_of_views_elements_services_redundancy_groups_and_parameters
---

# IDs of views, elements, services, redundancy groups and parameters

## How do I find the ID of a view?

### Finding the ID of a view

In DataMiner Cube, right-click the view in the Surveyor and select *Properties*.

The view ID is displayed in the *general* tab, to the right of the name of the view.

## How do I find the ID of an element, service or redundancy group?

> [!NOTE]
> The ID of an element, service or redundancy group always consists of two parts, separated by a forward slash:

- the ID of the DMA where the element, service or redundancy group was created, and

- the ID of the element, service, or redundancy group itself.

To find this ID in DataMiner Cube:

1. Open the view containing the element, service or redundancy group.

1. Under BELOW THIS VIEW there is a page for each type of item that can be contained within the view. Using the ALL page will display all items within the view.

    Next to the item name, a number is displayed that indicates how many of these items are in the view. Click a page in the tree view to display a list of the items in question.

    The IDs of all items in the view can be found in the *ID* column.

> [!NOTE]
> Alternatively, for an element or service, you can also right-click the item in the Surveyor and select *Properties*. The ID is displayed in the *general* tab, to the right of the name of the view.

## How do I find the ID of a parameter?

On the element card containing the parameter, double-click the parameter, or right-click the parameter and select *Open*.

The parameter ID is displayed below the parameter, next to the ID label.

> [!NOTE]
> For more information on how to generate a list of all parameters for a particular element, see [Generating a list of all parameters in a protocol version](xref:Advanced_protocol_functionality#generating-a-list-of-all-parameters-in-a-protocol-version).
