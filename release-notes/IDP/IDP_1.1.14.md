---
uid: IDP_1.1.14
---

# IDP 1.1.14

## New features

#### Filter buttons for facility management \[ID_29606\]

On the *Admin* > *Facilities* > *Locations* tab of the IDP app, filter buttons have been added, so that it is now easier to find a specific item in the tables.

A filter button is displayed above the table for each level. Select an item in a table and click the filter button to filter all underlying levels, so that they only show items that are relevant for the selected item. For example, if you filter on a specific room in the *Rooms* table, the *Aisles* and *Racks* tables below this will only show the aisles and racks for that room.

#### New button to upload plan or picture image \[ID_29643\]\[ID_29713\]

Previously, to add a plan or picture image for a room, floor, building or location, you had to upload the image to the server and specify the full path manually.

Now, when you edit a location, building, room or floor, a button is available that opens a window where you can browse to a local folder to select the image and upload it.

The app will validate if the file is within the size limit of 2 MB and if it has a valid extension. Currently the extensions .jpg, .jpeg and .png are accepted. If an invalid file is uploaded, a warning will be mention that the upload failed.

Once an image has been uploaded, it will be added to the Documents folder of the DMA. It will also be synced with the other elements in the cluster.

#### New facility management option to change parent structure of items \[ID_30032\]

On the *Admin* > *Facilities* > *Locations* tab of the IDP app, you can now change the parent structure of any item below the location level.

To do so, select the item in the relevant table and click the *Edit* button above the table. This will open the facility management wizard. In the wizard, click the *Edit* button to enter edit mode, and then specify the location, building, etc. where the item belongs. After you have clicked the *Edit* button, you can also click the *View* button to switch back to the previous mode and only modify the details related to the item.

Note that if you select a specific parent level, the wizard will check if that level already contains an item with the same name as the current item. If this is the case, an error message will be displayed, as there cannot be two items with the same name under the same parent item.

## Changes

### Enhancements

#### Toggle buttons updated \[ID_29970\]

The toggle buttons in the IDP app have been updated to be in line with the latest DataMiner stencils and use DataMiner's theme accent color.

#### Icons.xml no longer included in app package \[ID_30021\]

The icons used by IDP have been available out of the box in DataMiner since version 9.6.0 CU5 and 9.6.11. However, the *Icons.xml* file was still included in the IDP package and could overwrite more recent icons on DMAs. As the minimum required version of IDP is now DataMiner 10.0.0 CU9, *Icons.xml* will no longer be included in the IDP app package.

### Fixes

#### Miscellaneous issues \[ID_29763\]

The following issues have been fixed in the IDP app:

- On the *Overview* page and *Facilities* page, some trend graphs could not be displayed correctly.
- On the *Inventory* > *Discovered* page, it was possible to provision an element with "Unknown" CI type.
- On the *Connectivity* > *Discovery* page, it was possible to start a discovery when the table was empty or no row was selected.
- On the *Connectivity* > *Managed* page and on the *Connectivity* > *Discovery* page, when the details were shown, you could not switch to other details by selecting another row.

#### Bus address not updated during provisioning \[ID_29868\]

In some cases, it could occur that the bus address was not updated when an element was provisioned.

#### Directory path not correctly passed to script to restore default configuration \[ID_29972\]

When the default configuration was restored, instead of the default configuration directory path, the script name was passed to the update script.

#### Problem provisioning element if provisioning previously failed \[ID_30106\]

If you attempted to provision a discovered element on the *Inventory* > *Discovered* tab for a second time, the provisioning process did not start unless the row selection had changed. This meant that in cases where the provisioning initially failed, e.g. because it was not enabled for the relevant CI type, it would continue to fail even if the reason for the initial failure was removed.
