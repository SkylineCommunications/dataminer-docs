---
uid: Room_Designer
---

# Room Designer

This page allows you to design a room in detail, including the placement of different racks and zones. It will provide a valuable visual aid when designing rooms.

![Room Designer Page](~/solutions/images/Facility_Manager_Room_Designer_Page.png)

The designer consists of a grid of at most 4000 tiles. The size of each tile will be adjusted based on the size of the room.

You can adjust the way the grid is displayed by pressing specific keys on the keyboard. Click the *Help* button in the top-right corner of the page to view the available keyboard commands.

<!-- The text below is still unreviewed -->

To place a rack in a room, the user first selects a Room, then presses on the top right the Placement Operation button. This will open a side panel that allows the user to place their Racks, Zones and Rows:

![Room Designer Page with Placement Operations panel open](~/solutions/images/Facility_Manager_Room_Designer_Page_With_Placement_Operations_Panel_Open.png)

Rack Placement:

- Rack

- X and Y: Position “0,0” starts on the top left of the grid, and the rack is placed on the coordinate selected, based on the top left of the rack. This means that, for example, if a user tries to insert a rack on the bottom right coordinate, it will not work because the rack will go outside of the grid and will be prompted with the following:

![Warning when selecting a rack that goes outside of the limits of the room](~/solutions/images/Facility_Manager_Warning_When_Selecting_A_Rack_That_Goes_Outside_Of_The_Limits_Of_The_Room.png)

- Color

- Orientation: Vertical or Horizontal

Zone Placement:

- Zone

- X and Y: Starting position of the Zone

- Width and Depth: will define where the zone will end

Row Placement:

- Row

- Y: The table of the row is then displayed outside of the grid, based on the Y coordinate defined by the user

Finally, a cable calculator is available, to present the distance between two different racks within the same room:

![Cable Length Calculator](~/solutions/images/Facility_Manager_Cable_Length_Calculator.png)
