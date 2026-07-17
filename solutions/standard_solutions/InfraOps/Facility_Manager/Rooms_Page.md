---
uid: Rooms_Page
description: Go to the Floors and Rooms page of the Facility Manager to create, edit, and delete rooms, zones, rows, and desks.
---

# Floors & Rooms

The Floors & Rooms page of the Facility Manager contains an overview of floors, rooms, zones, rows, and desks. When you select an item in a table, all tables representing lower levels of the infrastructure hierarchy will automatically be filtered.

For zones, the cooling usage percentage is displayed, which is calculated based on the maximum power consumption of the assets assigned to the racks placed in the zone. This is defined in the Asset Manager app, specifically with the [asset class configuration](xref:Asset_Designer#configuring-an-asset-class).

When facilities, floors, and rooms have been added, this page is where you will typically continue your configuration by further detailing the rooms with [zones](#adding-a-zone), [rows](#adding-a-row), and/or [desks](#adding-a-desk).

![Floors & Rooms Page](~/solutions/images/Facility_Manager_Rooms_Page.png)

## Adding a new floor

1. In the header bar of the Floors & Rooms page, click *New Floor*.

1. Specify the following information:

   - The name of the floor.
   - The floor ID.
   - The facility where the floor is located.

1. Click *Save*.

1. To further configure the floor, in the *Floors* table, click the details button (ⓘ) for the floor.

   You can then:

   - Click the pencil icon in the *Floor Info* section to specify a description for the floor.
   - Click the pencil icon in the *Floor Plan* section to add an image as the floor plan.

     To have additional images available for selection, upload them using the [Web File Manager app](xref:Web_File_Manager), which you can access directly via the button in the upper-left corner.

     ![Floor plan image selection](~/solutions/images/Facility_Manager_Edit_Screen_For_Room_Plans.png)

1. When the floor is fully configured, click the *Activate* button in the floor details pane.

   As long as this button has not been clicked, the floor is considered a draft. After it has been clicked, you can remove the floor again by clicking the *Deprecate* button.

As soon as floors have been added to the facility, you will also be able to [add rooms](#adding-a-new-room).

## Adding a new room

1. In the header bar of the Floors & Rooms page, click *New Room*.

1. Specify the following information:

   - The name of the room.
   - The room ID.
   - The name of the floor where the room is located.
   - The width and depth of the room (in cm).

1. Click *Save*.

1. To further configure the room, in the *Rooms* table, click the details button (ⓘ) for the room.

   You can then:

   - Click the pencil icon in the *Room Info* section to specify a description for the room.
   - Click the pencil icon in the *Room Plan* section to add an image as the room plan. More images can be uploaded for selection using the [Web File Manager app](xref:Web_File_Manager).
   - Click the pencil icon in the *Room Info* section to configure the room's owner and team. The list of possible owners and teams is retrieved from the [People & Organizations](xref:People_Organizations) app.

   - [Add zones](#adding-a-zone), [add rows](#adding-a-row), and/or [add desks](#adding-a-desk) with the buttons at the top of the pane.

1. When the room is fully configured, click the *Activate* button in the room details pane.

   As long as this button has not been clicked, the room is considered a draft. After it has been clicked, you can remove the room again by clicking the *Deprecate* button.

   You will only be able to assign assets to a room in the [Asset Manager](xref:Asset_Manager) app when that room has been activated.

Example of a fully configured, activated room:

![Room details pane](~/solutions/images/Facility_Manager_Room_Details_Side_Panel.png)

## Adding a zone

1. In the *Rooms* table, click the details button (ⓘ) for the room where you want to add a zone.

1. At the top of the *Room details* pane, click *Add Zone*.

1. Specify the following information:

   - The name of the zone.
   - The zone ID.
   - The name of the room where the zone is located. By default, this will be set to the room for which you were viewing details.
   - The zone's cooling capacity.
   - The zone's thermal type. On the [Room Designer](xref:Room_Designer) page, the thermal type of the zone, i.e., *Warm* or *Cold*, will be highlighted in red or blue, respectively.

1. Click *Save*.

1. To further configure the zone, in the *Zones* table on the Floors & Rooms page, click the details button (ⓘ) for the zone.

   You can then:

   - Click the pencil icon in the *Zone Info* section to specify a description for the zone.
   - Click the pencil icon in the *Plan* section to add an image as the zone plan. More images can be uploaded for selection using the [Web File Manager app](xref:Web_File_Manager).

1. When the zone is fully configured, click the *Activate* button in the zone details pane.

   As long as this button has not been clicked, the zone is considered a draft. After it has been clicked, you can remove the zone again by clicking the *Deprecate* button.

## Adding a row

1. In the *Rooms* table, click the details button (ⓘ) for the room where you want to add a row.

1. At the top of the *Room details* pane, click *Add Row*.

1. Specify the following information:

   - The name of the row.
   - The row ID.
   - The label for the row.
   - The name of the room where the row is located. By default, this will be set to the room for which you were viewing details.

1. Click *Save*.

1. To further configure the row, in the *Rows* table on the Floors & Rooms page, click the details button (ⓘ) for the row.

   You can then:

   - Click the pencil icon in the *Row Info* section to specify a description for the row.
   - Click the pencil icon in the *Row Plan* section to add an image as the row plan. More images can be uploaded for selection using the [Web File Manager app](xref:Web_File_Manager).

1. When the row is fully configured, click the *Activate* button in the row details pane.

   As long as this button has not been clicked, the row is considered a draft. After it has been clicked, you can remove the row again by clicking the *Deprecate* button.

## Adding a desk

1. In the *Rooms* table, click the details button (ⓘ) for the room where you want to add a desk.

1. At the top of the *Room details* pane, click *Add Desk*.

1. Specify the following information:

   - The name of the desk.
   - The desk ID.
   - The name of the room where the desk is located. By default, this will be set to the room for which you were viewing details.

1. Click *Save*.

1. To further configure the desk, in the *Desks* table on the Floors & Rooms page, click the details button (ⓘ) for the desk.

   You can then:

   - Click the pencil icon in the *Desk Info* section to specify a description for the desk.
   - Click the pencil icon in the *Desk Plan* section to add an image as the desk plan. More images can be uploaded for selection using the [Web File Manager app](xref:Web_File_Manager).

1. When the desk is fully configured, click the *Activate* button in the desk details pane.

   As long as this button has not been clicked, the desk is considered a draft. After it has been clicked, you can remove the desk again by clicking the *Deprecate* button.
