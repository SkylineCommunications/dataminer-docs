---
uid: Editing_a_visual_overview_in_DataMiner_Cube
---

# Editing a visual overview in DataMiner Cube

To edit a Visio drawing used within DataMiner Cube (i.e., a visual overview), you can use the right-click menu of the visual overview.

This menu provides access to the options detailed below.

## Edit mode

Edit mode allows you to edit the currently assigned drawing within DataMiner Cube, without downloading it to your client computer.

In edit mode, all "linked" objects have a gray border. Objects are considered "linked" if they have at least one shape data field that is known to DataMiner.

To modify shapes in edit mode:

1. Select a linked object.

   > [!NOTE]
   > If you select the *Make all shapes selectable* option in the *edit shape* pane, you will be able to select all shapes in the Visio drawing from a selection box, even those that do not have any DataMiner shape data.

1. In the *Edit Shape* pane on the right, link the shape to a view, element, service, redundancy group, automation script, web page, video source, etc.

1. Depending on the choice you made in the previous step, specify the necessary options in either the *Basic* tab or the *Advanced* tab.

1. When you have made all necessary modifications, click *Save*. To exit the edit mode, click *Close edit mode*.

## Edit in Visio

The *Edit in Visio* option downloads the Visio drawing that is currently assigned to the selected view, service or element, and opens it in Microsoft Visio. This allows you to edit the drawing online.

When you have made all necessary modifications, save the drawing. The new version will be uploaded back to the DMS, and the visual side of the card will be refreshed.

## Set as active Visio file

For elements, the active Visio file can be determined on protocol level or on element level. For services and views, you can assign the active Visio file via the right-click menu of the Visual page in Cube.

For more information, refer to:

- [Setting the active Visio file for an element, service, or view](xref:Set_as_active_Visio_file).
- [Managing Visio files linked to protocols](xref:Managing_Visio_files_linked_to_protocols)

## Download Visio file

The *Download Visio file* option opens the *Save As* dialog box, which allows you to save a copy of the Visio drawing on your local computer.
