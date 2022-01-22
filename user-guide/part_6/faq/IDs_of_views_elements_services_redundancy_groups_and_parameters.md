---
uid: IDs_of_views_elements_services_redundancy_groups_and_parameters
---

# IDs of views, elements, services, redundancy groups and parameters

This section contains the following topics:

- [How do I find the ID of a view?](#how-do-i-find-the-id-of-a-view)

- [How do I find the ID of an element, service or redundancy group?](#how-do-i-find-the-id-of-an-element-service-or-redundancy-group)

- [How do I find the ID of a parameter?](#how-do-i-find-the-id-of-a-parameter)

### How do I find the ID of a view?

#### Finding the ID of a view

In DataMiner Cube, right-click the view in the Surveyor and select *Properties*.

The view ID is displayed in the *general* tab, to the right of the name of the view.

#### Exporting a list of all IDs

> [!NOTE]
> This feature is only included in the legacy System Display application, and is no longer available from DataMiner 9.6.0 onwards.

Exporting a list of all IDs is only possible in System Display:

1. Open the System Display client. See [How can I open the legacy System Display and Element Display applications?](DataMiner_client_applications.md#how-can-i-open-the-legacy-system-display-and-element-display-applications).

2. Click *Admin \> Elements*.

3. In the header bar of the *Element List*, click *Export*.

4. In the *Export* dialog box, do the following:

    1. Under *Choose what you want to export*, select

        - IDs of the elements

        - Include the IDs of the views

    2. Under *Choose how to export the information*, indicate whether you want the list to be copied to the Windows Clipboard, saved in a CSV file, or printed.

    3. Click *OK*.

### How do I find the ID of an element, service or redundancy group?

#### Finding the ID of an element, a service or a redundancy group

> [!NOTE]
> The ID of an element, service or redundancy group always consists of two parts, separated by a forward slash:

- the ID of the DMA where the element, service or redundancy group was created, and

- the ID of the element, service, or redundancy group itself.

To find this ID in DataMiner Cube:

1. Open the view containing the element, service or redundancy group.

2. On the view card, go to the data side.

3. Click the *details* tab.

    The IDs of all items in the view can be found in the *ID* column.

> [!NOTE]
> Alternatively, for an element or service, you can also right-click the item in the Surveyor and select *Properties*. The ID is displayed in the *general* tab, to the right of the name of the view.

#### Exporting a list of all IDs

> [!NOTE]
> This feature is only included in the legacy System Display application, and is no longer available from DataMiner 9.6.0 onwards.

Exporting a list of all IDs is only possible in System Display:

1. Open the System Display client. See [How can I open the legacy System Display and Element Display applications?](DataMiner_client_applications.md#how-can-i-open-the-legacy-system-display-and-element-display-applications).

2. Click *Admin \> Elements*.

3. In the header bar of the *Element List*, click *Export*.

4. In the *Export* dialog box, do the following:

    1. Under *Choose what you want to export*, select *IDs of the elements*.

    2. Under *Choose how to export the information*, indicate whether you want the list to be copied to the Windows Clipboard, saved in a CSV file, or printed.

    3. Click *OK*.

### How do I find the ID of a parameter?

On the element card containing the parameter, double-click the parameter, or right-click the parameter and select *Open*.

The parameter ID is displayed to the right of the parameter.

> [!NOTE]
> For more information on how to generate a list of all parameters for a particular element, see [Generating a list of all parameters in a protocol version](xref:Advanced_protocol_functionality#generating-a-list-of-all-parameters-in-a-protocol-version).
>
