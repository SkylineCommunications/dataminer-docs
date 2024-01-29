---
uid: DOM_Getting_Started_With_DOM
---
# Getting started with DOM

This tutorial shows how you can create a simple DOM model using the DOM Editor and then use it in a low-code app.

Expected duration: 20 minutes

## Overview

- [Getting started with DOM](#getting-started-with-dom)
  - [Overview](#overview)
  - [Prerequisites](#prerequisites)
  - [Step 1: Creating a DOM Definition](#step-1-creating-a-dom-definition)
  - [Step 2: Use a DOM definition within a low-code app](#step-2-use-a-dom-definition-within-a-low-code-app)
  - [Related documentation](#related-documentation)

> [!TIP]
> See also: [Kata #15: Getting started with DataMiner Object Models](https://community.dataminer.services/courses/kata-15/)
on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

## Prerequisites

- A cloud connected DataMiner system (version 10.3.10 or higher) or DAAS. Demo was created on version 10.4.1.
- Having deployed the [DOM Editor script](https://catalog.dataminer.services/details/automation-script/3195) from the catalog.  

## Step 1: Creating a DOM Definition

Open up DataMiner Cube and go to Apps > Automation. Next search for a script called **DOM Editor**. Launch this script, you should now see a screen as follows:

![Dom Editor](~/user-guide/images/DOM_Getting_Started_with_DOM_DOMEditor.png)

1. Click the *New...* button to create a new DOM Module
2. In the field *Module Id* enter *eventmanagement*, this is the name of the module that we want to create. 

    ![Dom Editor New Module](~/user-guide/images/DOM_Getting_Started_with_DOM_DOMModule.png)

3. Click *Create*. This should result a new module in the list of available DOM Modules:

    ![Dom Editor Module created](~/user-guide/images/DOM_Getting_Started_with_DOM_DOMModuleCreated.png)

4. Click *Edit...* next to the module name to open up the details of that module:

5. Click *Definitions...* to go to the definitions overview which exist within this module:

    ![Dom Editor Module details](~/user-guide/images/DOM_Getting_Started_with_DOM_DOMEditor_ModuleDetails.png)

6. Click *New...* to create a new DOM Definition

    ![Dom Editor Dom Definitions](~/user-guide/images/DOM_Getting_Started_with_DOM_DOMEditor_Definition.png)

7. In the field *Name* enter *Event*, 

    ![Dom Editor New Dom Definition](~/user-guide/images/DOM_Getting_Started_with_DOM_DOMEditor_NewDefinition.png)

8. Confirm with *OK*. Then click *Back* to back to the main menu and select *Section Definitions...*. 

   ![Dom Editor Section Definitions](~/user-guide/images/DOM_Getting_Started_with_DOM_SectionDefinitions.png)

9.  Here we can create the section definitions which will group a bunch of field to be used in the Event Dom definition. Click *New...* to create a new Section Definition.

    ![Dom Editor New Section Definition](~/user-guide/images/DOM_Getting_Started_with_DOM_SectionDefinitions_New.png)

10. Create a new Section Definition called **Event Info**.

    ![Dom Editor Event Info Section](~/user-guide/images/DOM_Getting_Started_with_DOM_SectionDefinitions_EventInfo.png)

11. Next we can add the fields we want to have defined in this section. To do this click on the button called *Field Descriptors...*. Next you can add new fields by clicking the *+* button:

    ![Dom Editor Event Info Section](~/user-guide/images/DOM_Getting_Started_with_DOM_FieldDescriptor_New.png)

12. Create a new field of Type **String** with name **Event Name**

    ![Dom Editor Event Name Field](~/user-guide/images/DOM_Getting_Started_with_DOM_FieldDescriptor_EventName.png)

13. Next to the *Event Name* field also add the following fields to the section:

    |Name|Type|
    |--- |--- |
    |Start|DateTime|
    |End|DateTime|
    |Notes|String|

14. Click on the *Apply* button when done to confirm and next click the *Back* button until you are back at the main Dom module menu. From here open up the *Definitions* again.

    ![Dom Editor Module details 2](~/user-guide/images/DOM_Getting_Started_with_DOM_DOMEditor_ModuleDetails.png)

15. Next click the *Edit...* button next to the Event definition:

    ![Dom Editor Event Info Section](~/user-guide/images/DOM_Getting_Started_with_DOM_EditEventDefinition.png)

16. Open up *Section Definition Links*.

    ![Dom Editor Event Info Section](~/user-guide/images/DOM_Getting_Started_with_DOM_SectionDefinitionLinks.png)

17. Click the + button to add a section. This should automatically add the **Event Info** section to the definition.

    ![Dom Editor Event Info Section](~/user-guide/images/DOM_Getting_Started_with_DOM_SectionDefinitionsLinksAdded.png)

18. Click the *Back* and next *Apply* to confirm.

19. Close the Dom Editor.

## Step 2: Use a DOM definition within a low-code app

Next we will start using the newly created Dom definition **Event** in a low-code app. You can use an existing app that you have already created or create a new one from scratch. More info on how to do that can be found in the following tutorial: - [Creating and publishing an app](xref:Tutorial_Apps_Creating_And_Publishing)

1. Create a new page in the app and edit it. On the right-hand side under the *Data* tab, find a section called **Object Manager Definitions**. This is where we can find all modules and definitions created in the system. Expand its contents. Here you should see the module **eventmanagement**. Expand this and under it you should find the DOM Definition we created called **Event**

   ![Object Manager Definitions](~/user-guide/images/DOM_Getting_Started_with_DOM_LCA_ObjectManagerDefinitions.png)

2. Drag and drop the **Event** DOM Definition on to the page. Click on the icon next to *Pick a visualization*

   ![DOM Pick a visualization](~/user-guide/images/DOM_Getting_Started_with_DOM_PickVisualization.png)

3. Select **Form** as the visualization for the component.

   ![DOM Form visualiation](~/user-guide/images/DOM_Getting_Started_with_DOM_LCA_FormVisualization.png)

4. As a result you should see a form representing the fields you added to the Event DOM Definition. This is where a user of the app can start entering data.

   ![DOM Form visualiation 2](~/user-guide/images/DOM_Getting_Started_with_DOM_LCA_FormVisualization2.png)

5. Next add a *Save* button to be able to save the form, enable the *Header Bar* by enabling the toggle next to it (in the left-hand column). Next click the "+" icon in the header bar and type in the "Save" name. You can also add an icon to the menu item by selecting it under the Icon sub-menu in the left-hand column.

   ![DOM LCA Save Button](~/user-guide/images/DOM_Getting_Started_with_DOM_LCA_SaveButton.png)

6. In order to define what should happen when we click this *Save* button, click on the icon under Events next to "On click".

   ![DOM LCA Events](~/user-guide/images/DOM_Getting_Started_with_DOM_LCA_Events.png)

7. This will open up a dialog where you can indicate what actions should be triggered when the button is clicked. In the first drop-down select *Execute component action*, under *I want to* select *Save Current Changes* and select the Form 1 (This is refering to the form we just created by drag an dropping the DOM definition in the app)

   ![DOM LCA Save On Click Event](~/user-guide/images/DOM_Getting_Started_with_DOM_SaveEvent.png)

8. Now you can already publish the app to have a look at what created so far. To do this click the publish icon on the top right of the app.

   ![DOM LCA Publish app](~/user-guide/images/DOM_Getting_Started_with_LCA_PublishApp.png)

9. Now you can try out filling the form and saving it. However you will not yet be able to see the created event records. For this we need to add a table listing all event records in the app. To do this we need to create a GQI query in the app. So go back to edit mode and open up the query section. Create a new query, by clicking the + icon. Enter **Events** as the name of the query. As a start of the query select *Get object manager instances* from the drop-down. Next select the module *eventmanagement*. Next select the definition *Event*. From the drop-down choose the **Select** option in order to pick which fields of the event we want to list in the app. Select *Event Name*, *Start*, *End* and *Notes* field.

   ![DOM LCA Get Dom Instances](~/user-guide/images/DOM_Getting_Started_with_DOM_GetDomInstances.png)

10. Now drag and drop the newly created *Events* query on to the page next to the form and choose **Table** as the visualization.

   ![DOM LCA Events Table Visualization](~/user-guide/images/DOM_Getting_Started_with_DOM_LCA_EventsTableVisualization.png)

11. Now publish the app again and you should see the event record you created before showing up in the table.

   ![DOM LCA Events Table](~/user-guide/images/DOM_Getting_Started_with_LCA_EventsTable.png)

12. If you start added more records throught the form, you will not immediately see the records showing up in the table. You will need to refresh the page manually first.

13. If we want the event records to show up immediately after we enter them in the form, without the need for refreshing the page, we need to add an event after the Save action. For this go back to the events of the Save button, click the **Upon completion button**:

   ![DOM LCA DON Form Upon Completion](~/user-guide/images/DOM_Getting_Started_with_DOM_FormUponCompletion.png)

14. Add a **Fetch the data** event for the Events table we have added.

   ![DOM LCA Save On Click Event](~/user-guide/images/DOM_Getting_Started_with_DOM_LCA_TableFetchTheData.png)

15. Now publish the app again and try out creating new events again. You should see them appear in the table each time you hit the **Save** button.

16. That's it, congratulations 🥳! You managed to create you DOM definition and use it in an app.

## Related documentation

To learn more about DOM you can have a look at the following tutorials:

- [DOM Tutorials](xref:DOM_tutorials)
