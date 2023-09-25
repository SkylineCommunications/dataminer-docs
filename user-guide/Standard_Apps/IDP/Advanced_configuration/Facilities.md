---
uid: Facilities
---

# Facilities

The *Facilities* subtab of the *Admin* tab consists of the pages detailed below.

## Rack Assignment

This page displays an overview of the devices managed by the Rack Layout Manager. A toggle button at the top allows you switch between showing only assigned devices or showing only devices that have not yet been assigned to a rack.

If one or more devices in the overview table are selected, additional options become available at the top:

- **Show in Rack**: Opens the rack view in a new card.

- **Assign**: Allows you to assign the selected devices to a rack. From IDP 1.1.16 onwards, you can also select whether to assign a device to the front or rear of the rack.

- **Auto Assign**: Launches a script to automatically assign the selected devices to a rack.

  > [!NOTE]
  > If one of the selected devices has a CI Type for which auto rack assignment is not enabled, the wizard will indicate that automatic assignment is not possible for this element. In that case, the wizard will not be able to perform the automatic assignment for any of the selected elements. As such, you will need to close the wizard and either make a selection that does not include the element in question, or make sure automatic rack assignment is possible for the element before running the wizard again.

**Remove**: Removes the selected devices from the rack they are currently assigned to.

## View Settings

This page allows you to configure the rack view structure and to set prefixes for each level in the structure. You can also configure the following settings here:

- **Automatically Update Views**: This setting is considered obsolete and is no longer available from IDP version 1.1.19 onwards. When this setting is selected, rack views are automatically added or updated with elements based on the element properties detected in the DMS. From IDP 1.1.19 onwards, this behavior is by default always activated.

- **Automatically Remove Deleted Protocols**: If this setting is enabled, protocols that can no longer be found in the system are removed from the *Protocols Table*. If it is disabled, they remain in the table but are marked as *Deleted*.

- **Facilities View**: The view ID of the view containing the infrastructure configuration.

- **Rack Position**: Determines how rack slot positions are numbered. This can either be set to "bottom-up", in which case position 1 will be at the bottom of the rack, or to "top-down", in which case position 1 will be at the top of the rack.

## Racks

This page displays an overview of all racks in the system, with basic editing possibilities. Above the overview, buttons are available to add a rack or open the advanced editor for a selected rack.

## Locations

This page displays an overview of all levels of facility management and all locations on each level in the system, with basic editing possibilities. Above the table representing each level, buttons are available:

- **New**: Allows you to add an item at the relevant level.

- **Edit**: Opens the advanced editor, which allows you to:

  - Delete a location (along with any sublocations). However, this is only possible if neither the location nor any of its sublocations still contain devices.

  - Select a different plan or picture image for a location, building, room or floor. The image has a size limit of 2 MB and must have the extension .jpg, .jpeg or .png. Uploaded images are added to the Documents folder of the DMA and synchronized with other DMAs in the cluster.

  - Change the parent structure of any item below the highest level. To do so, click the *Edit* button in the editor to enter edit mode, and then specify the location, building, etc. where the item belongs. After you have clicked the *Edit* button, you can also click the *View* button to switch back to the previous mode and only modify the details related to the item.

    > [!NOTE]
    > If you select a different parent level for an item, the wizard will check if that level already contains an item with the same name as the current item. If this is the case, an error message will be displayed, as there cannot be two items with the same name under the same parent item.

- **Filter**: Filters all underlying levels based on the item selected in the table. This button is not available for the *Racks* table, as this is the lowest level.
