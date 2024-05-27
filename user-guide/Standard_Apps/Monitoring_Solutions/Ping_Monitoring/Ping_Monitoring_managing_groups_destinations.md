---
uid: Ping_Monitoring_managing_groups_destinations
---

# Managing groups and destinations

## Managing groups

### Creating a new group

1. In the Ping Monitoring tool, go to the *Groups* page.

1. Click the *Create Group* button in the header bar.

   ![PING Monitor](~/user-guide/images/CrudActions1.png)

   This will open the *Create New Group* window.

1. Specify a name, description, alarm template, and trend template.

   For example:

   ![PING Monitor](~/user-guide/images/CrudActions2.png)

1. Click *Next*.

   At this point, an element using the Generic Ping connector will be created in DataMiner corresponding with the new group.

1. Optionally, define the properties of the newly created group.

   These properties allow you to add extra identification info for the group. By default, three properties are available, named Property 1, 2, and 3, respectively. However, you can [change these property names in DataMiner Cube](xref:Managing_element_properties#editing-custom-properties). For example:

   ![PING Monitor](~/user-guide/images/CrudActions3.png)

1. Click *Next*.

1. If necessary, specify the default settings for the destinations created in the group.

   If the default values are OK for you, you can leave these as they are.

   > [!NOTE]
   > If *Protocol* is set to *ICMP*, the *Port* field is optional, but if *Protocol* is set to *TCP*, the *Port* field must be filled in.

   ![PING Monitor](~/user-guide/images/CrudActions4.png)

1. Click *Save*.

### Editing a group

1. In the Ping Monitoring tool, go to the *Groups* page.

1. Either click the pencil icon next to the group you want to edit, or select the group and click the *Edit* button in the header bar.

   ![PING Monitor](~/user-guide/images/CrudActions5.png)

1. If necessary, edit the name and/or description.

   ![PING Monitor](~/user-guide/images/CrudActions6.png)

1. If no further changes are needed, click *Save* to save your changes and close the window; otherwise, click *Next*.

1. If necessary, edit the property values.

   ![PING Monitor](~/user-guide/images/CrudActions7.png)

1. If no further changes are needed, click *Save* to save your changes and close the window; otherwise, click *Next*.

1. If necessary, edit the default destination settings.

   ![PING Monitor](~/user-guide/images/CrudActions8.png)

1. Click *Save*.

### Deleting a group

1. In the Ping Monitoring tool, go to the *Groups* page.

1. Either click the garbage can icon next to the group you want to delete, or select the group and click the *Delete* button in the header bar.

1. In the confirmation dialog, click *Delete Group* to permanently delete the group with all the associated destinations.

   ![PING Monitor](~/user-guide/images/CrudActions9.png)

## Managing destinations

### Adding a new destination

1. In the Ping Monitoring tool, go to the *Destinations* page.

1. Click the *Add Destination* button in the header bar.

   ![PING Monitor](~/user-guide/images/CrudActions10.png)

   This will open a window with a button for each of the available groups.

1. Select the group to which you want to add the destination.

   ![PING Monitor](~/user-guide/images/CrudActions11.png)

   > [!NOTE]
   > If more than 30 groups are available, the UI will only show the first 30 created. To select a group that is not displayed, use the filter box at the top of the window to filter the displayed groups.

Once one of the groups is selected, the second screen of the UI will be displayed. This second screen will allow the user to define details about the destination they want to create, for instance the Address to ping to, and a Description about that Address that will allow the user to later identify that created Destination.

![PING Monitor](~/user-guide/images/CrudActions12.png)

Adding to that, the user will be able to define if they want to start pinging right away, or if they want to enable the ping later. This can be done in the Admin Status Dropdown.

Finally, the app will fill in the default values defined when the group was created. However, the user will be able to change this by clicking the Customize Settings button. On the contrary, if the user clicks the Add Destination button, the Destination will automatically be added to Cube, and the user will be able to follow it from the Destinations page.

![PING Monitor](~/user-guide/images/CrudActions13.png)

The Customize Settings UI is very similar to the one that allowed the user to define the default values in the Create Group UI, with the difference that now the user will also be able to add the Address, Description and Admin Status. From that screen, if the filled in values are correct, the user will be able to click the Add Destination button and this will automatically create the Destination in Cube.

![PING Monitor](~/user-guide/images/CrudActions14.png)

### Editing a destination

The user will be able to edit the defined parameters for the destination they want in two ways: from the Header bar or from the table showing the different destinations, similar to what they could do with the Groups.

![PING Monitor](~/user-guide/images/CrudActions15.png)

![PING Monitor](~/user-guide/images/CrudActions16.png)

Whatever way the user chooses to enter the Edit option, they will be redirected to the Edit Destination UI, where they will be able to edit the ping parameters they have created when creating the Destination. If the user clicks the Update Destination button those changes made will be stored in Cube.

![PING Monitor](~/user-guide/images/CrudActions17.png)

### Deleting a destination

If the user selects the Delete Destination button either from the Header bar or from the button in the Destinations Table, they will be redirected to the Delete Destination page. Here they will be informed about the risks entailing the action they are about to take, together with the Destination they plan to delete.

![PING Monitor](~/user-guide/images/CrudActions18.png)
