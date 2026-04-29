---
uid: Ping_Monitoring_managing_groups_destinations
---

# Managing groups and destinations

## Managing groups

### Creating a new group

1. In the Ping Monitoring tool, go to the *Groups* page.

1. Click the *Create Group* button in the header bar.

   ![Create Group button](~/dataminer/images/CrudActions1.png)

   This will open the *Create New Group* window.

1. Specify a name, description, hosting DMA, alarm template, and trend template.

   For example:

   ![Create New Group window](~/dataminer/images/CrudActions2.png)

1. Click *Next*.

   At this point, an element using the Generic Ping connector will be created in DataMiner corresponding with the new group.

1. Optionally, define the properties of the newly created group.

   These properties allow you to add extra identification info for the group. By default, three properties are available, named Property 1, 2, and 3, respectively. However, you can [change these property names in DataMiner Cube](xref:Managing_element_properties#editing-custom-properties). For example:

   ![Properties window](~/dataminer/images/CrudActions3.png)

1. Click *Next*.

1. If necessary, specify the default settings for the destinations created in the group.

   If the default values are OK for you, you can leave these as they are.

   > [!NOTE]
   > If *Protocol* is set to *ICMP*, the *Port* field is optional, but if *Protocol* is set to *TCP*, the *Port* field must be filled in.

   ![Default Destination Settings window](~/dataminer/images/CrudActions4.png)

1. Click *Save*.

### Editing a group

1. In the Ping Monitoring tool, go to the *Groups* page.

1. Either click the pencil icon next to the group you want to edit, or select the group and click the *Edit* button in the header bar.

   ![Edit group button](~/dataminer/images/CrudActions5.png)

1. If necessary, edit the name and/or description.

   ![Edit Name and Description window](~/dataminer/images/CrudActions6.png)

1. If no further changes are needed, click *Save* to save your changes and close the window; otherwise, click *Next*.

1. If necessary, edit the property values.

   ![Edit Properties window](~/dataminer/images/CrudActions7.png)

1. If no further changes are needed, click *Save* to save your changes and close the window; otherwise, click *Next*.

1. If necessary, edit the default destination settings.

   ![Edit Default Destination Settings window](~/dataminer/images/CrudActions8.png)

1. Click *Save*.

### Deleting a group

1. In the Ping Monitoring tool, go to the *Groups* page.

1. Either click the garbage can icon next to the group you want to delete, or select the group and click the *Delete* button in the header bar.

1. In the confirmation dialog, click *Delete Group* to permanently delete the group with all the associated destinations.

   ![Warning when deleting group](~/dataminer/images/CrudActions9.png)

## Managing destinations

### Adding a new destination

1. In the Ping Monitoring tool, go to the *Destinations* page.

1. Click the *Add Destination* button in the header bar.

   ![Add Destination button](~/dataminer/images/CrudActions10.png)

   This will open a window with a button for each of the available groups.

1. Select the group to which you want to add the destination.

   ![Select Group window](~/dataminer/images/CrudActions11.png)

   > [!NOTE]
   > If more than 30 groups are available, the UI will only show the first 30 created. To find a group that is not displayed, use the filter box at the top of the window.

1. Specify the settings for the destination:

   ![Add new destination window](~/dataminer/images/CrudActions12.png)

   - *Address*: The address of the destination.
   - *Description*: A description that will make it easier for users to identify the destination.
   - *Admin Status*: Set this to *Disabled* if you do not want to ping the destination yet. In that case, you can edit the destination later to enable this and start pinging.
   - Other parameters: For the other parameters, you can choose to use the default values that are filled in automatically, or you can click *Customize Settings* to modify them. These settings are similar to those for a group.

     ![Customize Settings window](~/dataminer/images/CrudActions13.png)

1. When the destination has been fully configured, click *Add Destination*.

### Editing a destination

1. In the Ping Monitoring tool, go to the *Destinations* page.

1. Either click the pencil icon next to the destination you want to edit, or select the destination and click the *Edit* button in the header bar.

   ![Pencil icon to edit destination](~/dataminer/images/CrudActions15.png)

   ![Edit destination button](~/dataminer/images/CrudActions14.png)

1. In the *Update Destination* window, edit the parameters you want to change.

   For example, if *Admin Status* is *Disabled*, you can set it to *Enabled* in order to start pinging a destination.

   ![Update Destination window](~/dataminer/images/CrudActions16.png)

1. Click *Update Destination* to save your changes.

### Deleting a destination

1. In the Ping Monitoring tool, go to the *Destinations* page.

1. Either click the garbage can icon next to the destination you want to delete, or select the destination and click the *Delete* button in the header bar.

   ![Icon to delete destination](~/dataminer/images/CrudActions18.png)

1. In the confirmation dialog, click *Next* to permanently delete the destination.

   ![Warning when deleting destination](~/dataminer/images/CrudActions17.png)
