---
uid: Room_Designer
---

# Room Designer

This page allows you to design a room in detail, including the placement of different racks and zones. It will provide a valuable visual aid when designing rooms.

![Room Designer Page](~/solutions/images/Facility_Manager_Room_Designer_Page.png)

## About the Room Designer grid

The designer consists of a grid of at most 4000 tiles. The size of each tile will be adjusted based on the size of the room.

You can adjust the way the grid is displayed by pressing specific keys on the keyboard. Click the *Help* button in the top-right corner of the page to view the available keyboard commands.

## Adding items to a room in the Room Designer

1. Select a room in the list on the right.

1. In the header bar, click *Placement Operations*.

   This will open a panel on the right.

   ![Room Designer Page with Placement Operations panel open](~/solutions/images/Facility_Manager_Room_Designer_Page_With_Placement_Operations_Panel_Open.png)

   In the *Rack Placement* section at the top, you can **add a rack**:

   1. Select the rack.

      Make sure that you select a rack that has a height, width, and depth configured, as these are required to be able to display the rack in the Room Designer.

      With the *View* button at the bottom of the section, you can take a look at a detailed view of the rack.

   1. Fill in the X and Y coordinates to indicate the position of the top-left corner of the rack. Position "0,0" starts at the top left of the grid.

      This means you need to make sure the indicated position leaves enough space for the rack to be included in the room. If, for example, you specify the lower-right corner as the rack position, this will result in the following notification because the rack would be positioned outside of the grid:

      ![Message when adding a rack outside the grid](~/solutions/images/Facility_Manager_Warning_When_Selecting_A_Rack_That_Goes_Outside_Of_The_Limits_Of_The_Room.png)

   1. Optionally, customize the color and orientation (i.e. vertical or horizontal) to adjust how the rack will be displayed.

   1. Click *Assign*.

   In the *Zone Placement* section, you can add a **zone**:

   1. Select the zone.

   1. Fill in the X and Y coordinates to indicate the position of the top-left corner of the zone. Position "0,0" starts at the top left of the grid.

   1. Fill in the width and depth to define the size of zone on the grid.

   1. Click *Assign*.

   In the *Row Placement* section, you can add a **row**:

   1. Select the row.

   1. Fill in the Y coordinate for the row.

   1. Click *Assign*.

      A label with the row name will be shown next to the grid at the indicated coordinate.

## Removing an item

To remove an item you have added to a room in the Room Designer:

1. Make sure the room is selected and click *Placement Operations*.

1. Select the item in the rack, zone, or row list, and click the appropriate *Remove* button.

## Calculating the cable length

When you have added the necessary racks to a room, you can calculate the length of the cables between the racks:

1. Make sure the room is selected.

1. In the header bar, click *Cable Length Calculator*.

1. Select the source and destination rack.

The cable length required between the racks will be displayed.

![Cable Length Calculator](~/solutions/images/Facility_Manager_Cable_Length_Calculator.png)
