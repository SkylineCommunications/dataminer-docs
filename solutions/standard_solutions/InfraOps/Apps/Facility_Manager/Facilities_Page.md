---
uid: Facilities_Page
---

# Facilities

The Facilities page of the Facility Manager app allows you to create, edit, and delete facilities, floors, and rooms. It displays an overview of the configured facilities on a map, based on defined geographic coordinates (latitude and longitude).

On the left, it includes a filter panel. Selecting a facility also filters the lists of floors and rooms accordingly.

![Facilities page](~/solutions/images/Facility_Manager_Facilities_Page.png)

> [!NOTE]
> To take full advantage of the map component, you will need to configure a valid Google Maps API key on the *About* page of the app. For more information on how to configure DataMiner Maps, refer to [Configuring the DataMiner Maps host servers](xref:Configuring_the_DataMiner_Maps_host_servers).

## Adding a new facility

1. In the top-left corner of the Facilities page, click *New Facility*.

1. Specify the following information:

   - The name of the facility.
   - The facility type: *Building*, *Container*, or *Truck*.
   - The ID of the facility.

1. Click *Save*.

1. In the table below the map, click the details button (ⓘ).

   This will open the *Facility details* pane.

1. Click the pencil icon in the section you want to edit, and configure the metadata you want.

   You can configure the location's description, latitude, longitude, country, city, address, and zip code.

1. When the facility is fully configured, click the *Activate* button.

   As long as this button has not been clicked, the facility is considered a draft. After it has been clicked, you can remove the facility again by clicking the *Deprecate* button.

1. To add a floor to facility, click the *Add Floor* button at the top and add the floor number.

   As soon as floors have been added to the facility, you will be able to add rooms from the *Floor details* pane.

## Adding a new room

1. In the *Floors* table on the Facilities page, click the details button (ⓘ) for the floor where you want to add a room.

   This will open the *Floor details* pane.

1. In the top-left corner of the pane, click *Add Room*.

1. Specify the name of the room as well as its width and depth, and click *Save*.

   The width and depth of the room are required to use the room in the Room Designer.

1. Close the *Floor details* pane.

1. In the *Rooms* table, click the details button (ⓘ) for the room.

   This will open the *Room details* pane.

1. Configure the room as necessary:

   - In the *Room Info* section, click the pencil icon to configure the room's description, owner, and team. The list of possible owners and teams is retrieved from the [People & Organizations](xref:People_Organizations) app.

     ![Room information Wizard](~/solutions/images/Facility_Manager_Room_Information_Wizard.png)

   - In the *Room Plan* section, click the pencil icon and then select an image to add this image as the room plan.

   - Add zones, rows, and/or desks with the buttons at the top of the pane.

1. When the room is fully configured, click the *Activate* button.

Here is an example of a fully configured, activated room:

![Room details pane](~/solutions/images/Facility_Manager_Room_Details_Side_Panel.png)


<!-- The text below is still unreviewed -->

Only active Rooms and Racks allow asset assignments.



It’s also possible for the users to add floor or room plans from the details page by selecting the edit button (🖉) on the Room Plan section. This introduces the first interaction with the Web File Manager solution:

![Edit screen for Room Plans](~/solutions/images/Facility_Manager_Edit_Screen_For_Room_Plans.png)

Currently, it allows users to upload images. These can be used, as already mentioned on the Floors and Room plans, but they can also be used to assign images to Asset Classes (more details here Asset Class Details):

![Web File Manager Main Page](~/solutions/images/Facility_Manager_Web_File_Manager_Main_Page.png)

Once on the Web File Manager app, by selecting the Upload button on the top right, the user can upload an image that can later be used with this Asset and Inventory Management solution:

![Web File Manager Upload Wizard](~/solutions/images/Facility_Manager_Web_File_Manager_Upload_Wizard.png)
