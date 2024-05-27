---
uid: Crud_actions
---

# Support management of groups and destinations 
The Ping Monitoring is a simple yet powerful tool that can help network engineers quickly identify the probable location of a network outage. In this article, we will explore why this command is so popular. The tool developed using the DataMiner platform allows network administrators to easily monitor their network infrastructure and services. You can find the tool in the DataMiner Catalog. 

The app has been ready to use for some months now, but we noticed that some more functionalities could be added to it, since its current version required the user to open DataMiner Cube and perform some actions before being able to use the Ping Monitor LCA itself. 

With this in view, we decided to try to enhance the usage of this LCA by enabling seamless integration with DataMiner Cube. The user no longer needs to open Cube to create its groups and destinations to which they want to configure the Ping to, which makes the app not only more efficient, but also easier to use. 
 
Several functionalities have been implemented both for Groups and Destinations, and these are the CRUD actions. CRUD actions correspond to Create Update and Delete actions on both Groups and Destinations, translating to the user being able to manage all their functionality from the LCA. Without further delay, let’s dive in the latest changes to the Ping Monitoring LCA 

## Support CRUD actions on Groups in the app 
### Create new Group 

Creating a 'Group' is equivalent to creating an element using the Generic Ping connector. While this had to be done from Cube before, we have now made the user’s job easier by allowing them to do it from the LCA itself.  

The UI that guides the user in the creation of the group can be accessed via a nice button in the header bar that the user can use.
 
![PING Monitor](~/user-guide/images/CrudActions1.png)

Clicking this button will guide them to the first screen of the UI. I have illustrated that first screen with an example. This boxes will appear empty to the user so that they can define the name of the group they want to add, their description and templates. Once the client clicks on Next, an element (for Dataminer it is an element, but in terms of the app we are talking about groups) will be created.

![PING Monitor](~/user-guide/images/CrudActions2.png)

This will lead the user to the second screen of the UI. This second screen allows the user to define some properties to the created group. These properties’ name can be updated from Dataminer Cube itself. Their custom name is Property 1,2 and 3 respectively. These properties are specific to the group that the user is creating and give an extra step of identification for the user, which could define in these the Country, the City and the Contract of the created group for instance.

![PING Monitor](~/user-guide/images/CrudActions3.png)

Once the user clicks next, this will lead them to the 3rd and last screen of the UI. Here the user can define some basic properties that will be default for all created destinations inside that group.  The boxes come together with error check functionality, so that if the user leaves empty boxes or defines an invalid value for any of them, they will be notified about it with a red box around the incorrectly filled box and with a message informing them of what they have done wrong. Note that the Port Box is optional for the ICMP choice, but it is not for the TCP connection. Besides that, default values will be displayed to the user so that they can efficiently create a group without having to define all of these properties. 

![PING Monitor](~/user-guide/images/CrudActions4.png)

### Edit group

On this second functionality, the LCA will allow the user to update the properties of a Group they have created previously. This UI can be accessed via two different points. On the one hand the user can access it via the Header bar. In this case, they will first have to select which group they want to update in the table of Groups beneath the Header bar and then they will need to click the Edit button. 

![PING Monitor](~/user-guide/images/CrudActions5.png)

On the other hand, they might access the Edit Group UI by clicking the pen icon next to the group they want to Edit in the Table of Groups.

![PING Monitor](~/user-guide/images/CrudActions6.png)

If the user clicks any of these two buttons, this will lead them to the Edit Group UI. The first screen of the UI looks identical to that of the Create Group. The difference is that the boxes will now be filled with the information of the Group created by the user previously. In any of the screens, the user will be able to change the made changes by clicking the Save button.

![PING Monitor](~/user-guide/images/CrudActions7.png)

If they click the next button, this will lead them to the second screen of the UI, were the user will be able to change the properties they defined in when creating the group. The boxes will also be filled in with the values that the user has defined in the Create Group page.

![PING Monitor](~/user-guide/images/CrudActions8.png)

Finally, if the user clicks the Next button, they will be redirected to the last screen of the UI. In this screen the user will have the chance to edit the default values that they have defined to the ping parameters. Once again, this screen provides an error check, that will notify the client if they incorrectly filled the boxes in the UI. Clicking the save button will lead the user to exit the Edit Group UI and will store the changes made.

![PING Monitor](~/user-guide/images/CrudActions9.png)

### Delete Group

The Delete Group UI can also be accessed via two buttons: one in the header bar and another one next to the element you want to delete. This user friendly UI will inform the client about which screen they would like to delete, and by clicking the Delete Group button, they will permanently delete the Group of their choice and all the associated destinations.

![PING Monitor](~/user-guide/images/CrudActions10.png)

## Support CRUD actions on Destinations in the app 

### Add new Destination

Another change made to the app consists on allowing the user to create a destination without having to enter Cube. This allows an easier and more efficient way of managing the destinations the user wants to ping to. For this the user will first have to navigate to the Destinations tab in the left side of the LCA, and click on the Header bar button that displays a “Add Destination” button 

![PING Monitor](~/user-guide/images/CrudActions11.png)

Clicking this button will lead the user to the first screen of the Add Destination UI. In this first screen, the user will get a list of buttons, each one with a name of group created. If more than 30 groups are available, the UI will only show the first 30 created. The rest will be accessible via the Filter box in the top of the UI.

![PING Monitor](~/user-guide/images/CrudActions12.png)

Once one of the groups is selected, the second screen of the UI will be displayed. This second screen will allow the user to define details about the destination they want to create, for instance the Address to ping to, and a Description about that Address that will allow the user to later identify that created Destination.  
Adding to that, the user will be able to define if they want to start pinging right away, or if they want to enable the ping later. This can be done in the Admin Status Dropdown. 
Finally, the app will fill in the default values defined when the group was created. However, the user will be able to change this by clicking the Customize Settings button. On the contrary, if the user clicks the Add Destination button, the Destination will automatically be added to Cube, and the user will be able to follow it from the Destinations page. 

![PING Monitor](~/user-guide/images/CrudActions13.png)

The Customize Settings UI is very similar to the one that allowed the user to define the default values in the Create Group UI, with the difference that now the user will also be able to add the Address, Description and Admin Status. From that screen, if the filled in values are correct, the user will be able to click the Add Destination button and this will automatically create the Destination in Cube. 

![PING Monitor](~/user-guide/images/CrudActions14.png)

### Edit Destination

The user will be able to edit the defined parameters for the destination they want in two ways: from the Header bar or from the table showing the different destinations, similar to what they could do with the Groups.

![PING Monitor](~/user-guide/images/CrudActions15.png)
![PING Monitor](~/user-guide/images/CrudActions16.png)

Whatever way the user chooses to enter the Edit option, they will be redirected to the Edit Destination UI, where they will be able to edit the ping parameters they have created when creating the Destination. If the user clicks the Update Destination button those changes made will be stored in Cube.

![PING Monitor](~/user-guide/images/CrudActions17.png)

### Delete Destination

If the user selects the Delete Destination button either from the Header bar or from the button in the Destinations Table, they will be redirected to the Delete Destination page. Here they will be informed about the risks entailing the action they are about to take, together with the Destination they plan to delete.

![PING Monitor](~/user-guide/images/CrudActions18.png)



