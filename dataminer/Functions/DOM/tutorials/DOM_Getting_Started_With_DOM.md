---
uid: DOM_Getting_Started_With_DOM
---
# Getting started with DOM

This tutorial shows how you can create a simple DOM model using the DOM Editor and then use it in a low-code app.

The content and screenshots for this tutorial were created in DataMiner version 10.4.1.

Expected duration: 20 minutes

> [!TIP]
> See also: [Kata #15: Getting started with DataMiner Object Models](https://community.dataminer.services/courses/kata-15/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

## Prerequisites

- A DataMiner System using DataMiner 10.3.10 or higher, which is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
- An [indexing database](xref:Indexing_Database) or [Storage as a Service](xref:STaaS).

> [!NOTE]
> If you use a [DaaS system](xref:Creating_a_DMS_in_the_cloud), these prerequisites are automatically met.

## Overview

- [Step 1: Deploy the DOM Editor script](#step-1-deploy-the-dom-editor-script)
- [Step 2: Create a DOM definition](#step-2-create-a-dom-definition)
- [Step 3: Use the DOM definition in a low-code app](#step-3-use-the-dom-definition-in-a-low-code-app)

## Step 1: Deploy the DOM Editor script

1. Go to <https://catalog.dataminer.services/details/11674850-aeac-48c4-9f35-03c387ebcf18>.

1. Click the *Deploy* button to deploy the DOM Editor script to your DMA.

## Step 2: Create a DOM definition

Now that you have deployed the DOM Editor to your DMA, you can use it to create a DOM definition:

1. [Open DataMiner Cube](xref:Connecting_to_a_DMA_with_Cube) and go to *Apps* > *Automation*.

1. In the Automation module, search for a script called **DOM Editor** and select it.

   ![Dom Editor script](~/dataminer/images/DOM_Getting_Started_script.png)

1. Click the *Execute* button in the lower-right corner to launch this script, and then click *Execute now*.

   You should now see the following window:

   ![Dom Editor](~/dataminer/images/DOM_Getting_Started_with_DOM_DOMEditor.png)

1. Click *New* to create a new DOM module.

1. In the *Module ID* box, enter `eventmanagement`.

   This is the name of the module that you are creating.

   ![Dom Editor New Module](~/dataminer/images/DOM_Getting_Started_with_DOM_DOMModule.png)

1. Click *Create*.

   This should result a new module in the list of available DOM modules:

   ![Dom Editor Module created](~/dataminer/images/DOM_Getting_Started_with_DOM_DOMModuleCreated.png)

1. Next to the module name, click *Edit*  to open the details of the module.

1. Click *Definitions* to go to the definitions overview for this module.

   ![Dom Editor Module details](~/dataminer/images/DOM_Getting_Started_with_DOM_DOMEditor_ModuleDetails.png)

1. Click *New* to create a new DOM definition.

   ![Dom Editor Dom Definitions](~/dataminer/images/DOM_Getting_Started_with_DOM_DOMEditor_Definition.png)

1. In the *Name* box, enter `Event`.

   ![Dom Editor New Dom Definition](~/dataminer/images/DOM_Getting_Started_with_DOM_DOMEditor_NewDefinition.png)

1. Confirm with *OK*, then click *Back* to go back to the main menu.

1. In the main menu, select *Section Definitions*.

   ![Dom Editor Section Definitions](~/dataminer/images/DOM_Getting_Started_with_DOM_SectionDefinitions.png)

1. Click *New* to create a new section definition.

   ![Dom Editor New Section Definition](~/dataminer/images/DOM_Getting_Started_with_DOM_SectionDefinitions_New.png)

   This section definition will allow you to group several fields to be used in your "Event" DOM definition.

1. In the *Name* box, enter `Event Info`.

   ![Dom Editor Event Info Section](~/dataminer/images/DOM_Getting_Started_with_DOM_SectionDefinitions_EventInfo.png)

1. Click the *Field Descriptors* button to add fields to the section:

   1. Click the *+* button to start adding a field to the section:

      ![Dom Editor Event Info Section](~/dataminer/images/DOM_Getting_Started_with_DOM_FieldDescriptor_New.png)

   1. Configure the new field with the name `Event Name`.

   1. In the *Type* box, select the type *String*.

      ![Dom Editor Event Name Field](~/dataminer/images/DOM_Getting_Started_with_DOM_FieldDescriptor_EventName.png)

   1. Click *Back*.

   1. Repeat these steps to also add the following fields to the section:

      |Name|Type|
      |--- |----|
      |Start|DateTime|
      |End|DateTime|
      |Notes|String|

   1. When all fields have been added, click *Back*, and then *Apply* and *OK*.

1. Click the *Back* button until you are back at the main DOM module menu.

1. Click *Definitions*.

   ![Dom Editor Module details 2](~/dataminer/images/DOM_Getting_Started_with_DOM_DOMEditor_ModuleDetails.png)

1. Next to the *Event* definition you have created, click *Edit*:

   ![Dom Editor Event Info Section](~/dataminer/images/DOM_Getting_Started_with_DOM_EditEventDefinition.png)

1. Click *Section Definition Links*.

   ![Dom Editor Event Info Section](~/dataminer/images/DOM_Getting_Started_with_DOM_SectionDefinitionLinks.png)

1. Click the + button to add a section.

   This should automatically add the *Event Info* section to the definition.

   ![Dom Editor Event Info Section](~/dataminer/images/DOM_Getting_Started_with_DOM_SectionDefinitionsLinksAdded.png)

1. Click *Back* and then *Apply* to confirm.

1. Close the DOM Editor.

   Your DOM definition is now ready.

## Step 3: Use the DOM definition in a low-code app

1. Either create a new low-code app or use an existing app where you will be able to add the DOM definition.

   > [!TIP]
   > For info on how to make a low-code app, refer to the tutorial [Creating and publishing an app](xref:Tutorial_Apps_Creating_And_Publishing)

1. Add a new page to the app and edit it.

   > [!TIP]
   > For info on how to add and configure pages in a low-code app, refer to the tutorial [Managing the pages in an app](xref:Tutorial_Apps_Managing_Pages).

1. In the *Data* tab on the right, look for the *Object Manager Definitions* section and make sure it is expanded.

   This section lists the DOM modules and definitions created in the system, including the module *eventmanagement*, which you created earlier, and below this your DOM definition *Event*.

   ![Object Manager Definitions](~/dataminer/images/DOM_Getting_Started_with_DOM_LCA_ObjectManagerDefinitions.png)

1. Drag and drop the *Event* DOM definition to the page to add a component using this data.

1. In the component, click the icon next to *Pick a visualization*.

   ![DOM Pick a visualization](~/dataminer/images/DOM_Getting_Started_with_DOM_PickVisualization.png)

1. Select *Form* as the visualization for the component.

   ![DOM Form visualization](~/dataminer/images/DOM_Getting_Started_with_DOM_LCA_FormVisualization.png)

   As a result, the app will show a form representing the fields you added to the *Event* DOM definition. This is where a user of the app can start entering data.

   ![DOM Form visualization 2](~/dataminer/images/DOM_Getting_Started_with_DOM_LCA_FormVisualization2.png)

1. Add a *Save* button so users will be able to save the form:

   1. In the pane on the left, enable the toggle button next to *Header bar* to display the header bar for the page.

   1. Click the "+" icon in the header bar.

   1. Enter the label `Save` for the button.

      ![DOM LCA Save Button](~/dataminer/images/DOM_Getting_Started_with_DOM_LCA_SaveButton.png)

   1. Optionally, add an icon to the button by selecting it under *Icon* in the pane on the left.

      You can use the filter box at the top of the list of icons to quickly find a specific icon.

   1. Under *Events* in the pane on the left, click the icon next to *On click*.

      ![DOM LCA Events](~/dataminer/images/DOM_Getting_Started_with_DOM_LCA_Events.png)

      This will open a dialog where you can define what should happen when the button is clicked.

   1. In the dialog, select *Execute component action* in the first box, *Save Current Changes* in the second box, and *Form 1* in the third box.

      "Form 1" refers to the form component you have just created by dragging and dropping the DOM definition on the page.

      ![DOM LCA Save On Click Event](~/dataminer/images/DOM_Getting_Started_with_DOM_SaveEvent.png)

   1. Click *OK* to finish adding the action.

1. Click the publish icon in the top right corner of the app.

   You have now published a first version of the app, so you can take a look at what you have created so far.

   ![DOM LCA Publish app](~/dataminer/images/DOM_Getting_Started_with_LCA_PublishApp.png)

1. In your low-code app, fill out the form and save it.

   At this point, you cannot see the created event records yet. For this, you need to add a table listing all event records in the app. This table will use a GQI query.

1. Go back to edit mode, start editing the page again, and create a query:

   1. Expand the *Queries* section in the data pane.

   1. Click the + icon to create a new query.

   1. Enter `Events` as the name of the query.

   1. In the *Select data source* box, select *Get object manager instances*.

   1. Select the module *eventmanagement*, and the definition *Event*.

   1. In the *Select operator* box, select *Select*.

      This will allow you to pick which fields of the event you want to list in the app.

   1. Select the *Event Name*, *Start*, *End*, and *Notes* fields.

   ![DOM LCA Get Dom Instances](~/dataminer/images/DOM_Getting_Started_with_DOM_GetDomInstances.png)

1. Drag and drop the newly created *Events* query on to the page next to the form to add a component using this data.

1. In the component, select *Table* as the visualization.

   ![DOM LCA Events Table Visualization](~/dataminer/images/DOM_Getting_Started_with_DOM_LCA_EventsTableVisualization.png)

1. Click the publish icon in the top right corner of the app to publish the app again.

   The app should now show a table containing the event record you created earlier.

   ![DOM LCA Events Table](~/dataminer/images/DOM_Getting_Started_with_LCA_EventsTable.png)

   At this point, if you add more records through the form, you will not immediately see the records showing up in the table. You will need to refresh the page manually first. To make the even records show up immediately as soon as they have been entered, another event has to be added to the page.

1. Go back to edit mode and add an event to the page to refresh after the *Save* action:

   1. In the pane on the left, under *Header bar* > *Events*, click the icon next to *On click*.

      This will open the dialog with the save action you configured earlier.

   1. Click *Upon completion*.

      ![DOM LCA DON Form Upon Completion](~/dataminer/images/DOM_Getting_Started_with_DOM_FormUponCompletion.png)

   1. Select *Execute component action* in the first box, *Fetch the data* in the second box, and *Table 2* in the third box.

      ![DOM LCA Save On Click Event](~/dataminer/images/DOM_Getting_Started_with_DOM_LCA_TableFetchTheData.png)

   1. Click *OK*.

1. Publish the app again and try out creating new events again.

You should now have a fully functioning app where users can add records that will show up in the table as soon as they click the *Save* button.

![DOM LCA Final Result](~/dataminer/images/DOM_Getting_Started_with_DOM_LCA_FinalResult.png)
