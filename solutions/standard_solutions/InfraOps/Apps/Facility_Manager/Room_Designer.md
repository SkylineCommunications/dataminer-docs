---
uid: Room_Designer
---

# Room Designer

On this page, the user can accurately place the racks in their rooms, granting the user a valuable visual aid:

![Room Designer Page](~/solutions/images/Facility_Manager_Room_Designer_Page.png)

The maximum number of squares that the component allows is 4000, so the size of each tile will adapt based on the size of the room. On the top right of the page, the Help button displays a pop-up with the available commands to interact with the Room Designer component.

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
