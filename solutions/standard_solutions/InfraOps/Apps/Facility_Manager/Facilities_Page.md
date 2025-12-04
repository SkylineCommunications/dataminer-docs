---
uid: Facilities_Page
---

# Facilities Page

Displays a map of configured facilities based on defined geographic coordinates (latitude and longitude). Users can create, edit, and delete facilities, floors, and rooms.

To take full advantage of the Maps component, a Google Maps API key is needed. See also [Configuring the DataMiner Maps host servers](xref:Configuring_the_DataMiner_Maps_host_servers). For ease of use, this can also be configured on the App Settings page of the Facility Manager.

Includes a filtering panel on the left. Selecting a facility filters the Floors and Rooms tables accordingly.

![Facilities Page](~/solutions/images/Facility_Manager_Facilities_Page.png)

By pressing “New Facility” on the top left, the user will be prompted to create a new one.

A name for the facility is required, as well as the Facility type (Building, Container or Truck).

Once the facility is created, by selecting the details button (ⓘ) the user can insert more metadata into it: Description, Latitude, Longitude, Country, City, Address and Zip Code.

The Facility state can be set to Draft, Active, or Deprecated. Only active Rooms and Racks allow asset assignments.

Floors are added from the Facility details page, Rooms from the Floor details page, and Zones/Rows/Desks from the Room details page.

![Room details side panel](~/solutions/images/Facility_Manager_Room_Details_Side_Panel.png)

Specifically for Rooms, users can define the Administration section, filling in the details for the rooms Owner and Team. This information is retrieved directly from the People and Teams sections under the People and Organization app:

![Room information Wizard](~/solutions/images/Facility_Manager_Room_Information_Wizard.png)

Here, the user can define the Width and Depth of the room. This is required to use this Room in the Room Designer.

It’s also possible for the users to add floor or room plans from the details page by selecting the edit button (🖉) on the Room Plan section. This introduces the first interaction with the Web File Manager solution:

![Edit screen for Room Plans](~/solutions/images/Facility_Manager_Edit_Screen_For_Room_Plans.png)

Currently, it allows users to upload images. These can be used, as already mentioned on the Floors and Room plans, but they can also be used to assign images to Asset Classes (more details here Asset Class Details):

![Web File Manager Main Page](~/solutions/images/Facility_Manager_Web_File_Manager_Main_Page.png)

Once on the Web File Manager app, by selecting the Upload button on the top right, the user can upload an image that can later be used with this Asset and Inventory Management solution:

![Web File Manager Upload Wizard](~/solutions/images/Facility_Manager_Web_File_Manager_Upload_Wizard.png)
