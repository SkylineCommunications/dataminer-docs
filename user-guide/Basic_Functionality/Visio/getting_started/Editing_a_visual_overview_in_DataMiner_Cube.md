---
uid: Editing_a_visual_overview_in_DataMiner_Cube
---

# Editing a visual overview in DataMiner Cube

To edit a Visio drawing used within DataMiner Cube (i.e. a visual overview), you can use the right-click menu of the visual overview.

This menu provides access to the options detailed below.

## Edit mode

Edit mode allows you to edit the currently assigned drawing within DataMiner Cube, without downloading it to your client computer.

In edit mode, all “linked” objects have a gray border. Objects are considered “linked” if they have at least one shape data field that is known to DataMiner.

To modify shapes in edit mode:

1. Select a linked object.

   > [!NOTE]
   > If you select the *Make all shapes selectable* option in the *edit shape* pane, you will be able to select all shapes in the Visio drawing from a selection box, even those that do not have any DataMiner shape data.

1. In the *Edit Shape* pane on the right, link the shape to a view, element, service, redundancy group, Automation script, web page, video source, etc.

1. Depending on the choice you made in the previous step, specify the necessary options in either the *Basic* tab or the *Advanced* tab.

1. When you have made all necessary modifications, click *Save*. To exit the edit mode, click *Close edit mode*.

## Edit in Visio

The *Edit in Visio* option downloads the Visio drawing that is currently assigned to the selected view, service or element, and opens it in Microsoft Visio. This allows you to edit the drawing online.

When you have made all necessary modifications, save the drawing. The new version will be uploaded back to the DMS, and the visual side of the card will be refreshed.

## Set as active Visio file

This option allows you to assign a different Visio file in several ways. Different possibilities are available depending on whether the visual overview you right-clicked is assigned to a service, a view or an element.

On the visual overview of an **element**, two options are available (from DataMiner 10.0.11 onwards):

- **Set as active \[protocol name\] protocol Visio file**: Assigns a different Visio file to all elements using this protocol.

  If you pick this option, the following further options are available:

  - **Custom**: Assigns the currently available custom protocol drawing to all elements using this protocol.

  - **Protocol default**: Assigns the protocol default drawing to all elements using this protocol. This is the drawing included in the protocol package.

  - **General default**: Assigns the general default drawing to all elements using this protocol. This is the drawing shipped with the DataMiner software.

  > [!TIP]
  > See also: [Managing Visio files linked to protocols](xref:Managing_Visio_files_linked_to_protocols)

- **Set as active \[element name\] element Visio file**: Assigns a different Visio file to this specific element only.

  If you pick this option, the following further options are available:

  - **New blank**: Opens a new, blank drawing in Microsoft Visio, which will automatically be assigned to the current element.

    > [!NOTE]
    > The format of the blank drawing depends on the SkylineNewDrawing template. See [Overview of the default Visio templates supplied by Skyline](xref:DataMiner_Visio_templates#overview-of-the-default-visio-templates-supplied-by-skyline).

  - **New upload**: Opens the *Open* dialog box, which allows you to upload a new drawing to the DMS and automatically assign it to the current element.

  - **Existing**: Opens the *Custom* dialog box, which allows you to assign a previously uploaded drawing to the current element:

    - Click a drawing in the list, set the default page, and click *OK*.

    - Click *Other File...* to upload additional drawings to the DMS.

On the visual overview of a **service or view**, the context menu can contain the following further options:

- **Custom** / **General default**: Only displayed in case a custom Visio file is available already. Allows you to switch between this custom file or the general default file for services or views.

- **New blank**: Opens a new, blank drawing in Microsoft Visio, which will automatically be assigned to the selected service or view.

  > [!NOTE]
  > The format of the blank drawing depends on the SkylineNewDrawing template. See [Overview of the default Visio templates supplied by Skyline](xref:DataMiner_Visio_templates#overview-of-the-default-visio-templates-supplied-by-skyline).

- **New upload**: Opens the *Open* dialog box, which allows you to upload a new drawing to the DMS and automatically assign it to the selected service or view.

- **Existing**: Opens the *Custom* dialog box, which allows you to assign a previously uploaded drawing to the selected service or view:

  - Click a drawing in the list, set the default page, and click *OK*.

  - Click *Other File...* to upload additional drawings to the DMS.

**Prior to DataMiner 10.0.11**: On the visual overview of an **element**, the context menu can contain the following further options:

- **Custom**: Assigns the available custom protocol drawing to all elements using this protocol.

- **Protocol default**: Assigns the protocol default drawing to all element using this protocol. Protocol default drawings are Visio drawings that are included in certain protocol packages. For more information, see [Managing Visio files linked to protocols](xref:Managing_Visio_files_linked_to_protocols).

- **General default**: Assigns the general default drawing to all elements using this protocol. This is the drawing shipped with the DataMiner software.

- **New blank**: Opens a new, blank drawing in Microsoft Visio, which will be used as the new custom drawing for the protocol and assigned to all elements using the protocol.

  > [!NOTE]
  > The format of the blank drawing depends on the SkylineNewDrawing template. See [Overview of the default Visio templates supplied by Skyline](xref:DataMiner_Visio_templates#overview-of-the-default-visio-templates-supplied-by-skyline).

- **New upload**: Opens the *Open* dialog box, where you can upload a new drawing that will be used as the custom drawing for the protocol and assigned to all elements using the protocol.

> [!TIP]
> See also:
>
> - [DataMiner Visio templates](xref:DataMiner_Visio_templates)
> - [Managing Visio files linked to protocols](xref:Managing_Visio_files_linked_to_protocols)
> - [Switching between different Visio files](xref:Managing_Visio_files_linked_to_protocols#switching-between-different-visio-files)

## Download Visio file

The *Download Visio file* option opens the *Save As* dialog box, which allows you to save a copy of the Visio drawing on your local computer.
