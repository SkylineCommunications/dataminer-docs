---
uid: DOM_Making_DOM_Stateful
---
# Making DOM Stateful

This tutorial shows how you can make your DOM model state-aware. This allows a DOM instance to behave differently according to each state it transitions to. It allows to define for each state:

- which fields are **visible** to the user
- which fields are **read-only** for the user
- which fields are **mandatory**
- to which state you can **transition**
- what **actions** are allow on each state
- what **buttons** to show on the form

The content and screenshots for this tutorial were created in DataMiner version 10.4.3.

Expected duration: 20 minutes

> [!TIP]
> See also: [Kata #15: Getting started with DataMiner Object Models](https://community.dataminer.services/courses/kata-15/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

## Prerequisites

- A DataMiner System using DataMiner 10.3.10 or higher, which is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
- An [indexing database](xref:Indexing_Database) or [Storage as a Service](xref:STaaS).

> [!NOTE]
> If you use a [DaaS system](xref:Creating_a_DMS_in_the_cloud), these prerequisites are automatically met.

## Overview

- [Making DOM Stateful](#making-dom-stateful)
  - [Prerequisites](#prerequisites)
  - [Overview](#overview)
  - [Step 1: Deploy the DOM Editor script](#step-1-deploy-the-dom-editor-script)
  - [Step 2: Deploy Kata DOM package](#step-2-deploy-kata-dom-package)
  - [Step 3: Defining the states on a DOM definition](#step-3-defining-the-states-on-a-dom-definition)
  - [Step 4: Defining the state transitions](#step-4-defining-the-state-transitions)
  - [Step 5: Defining actions to trigger state transitions](#step-5-defining-actions-to-trigger-state-transitions)
  - [Step 6: Defining a form button to trigger the action](#step-6-defining-a-form-button-to-trigger-the-action)
  - [Step 7: Validate states, transitions, buttons in the low-code app](#step-7-validate-states-transitions-buttons-in-the-low-code-app)

## Step 1: Deploy the DOM Editor script

1. Go to <https://catalog.dataminer.services/details/automation-script/3195>.

1. Click the *Deploy* button to deploy the DOM Editor script to your DMA.

1. When succesful you should see the following scripts appear on your DMA:

![Dom Editor Scripts](~/user-guide/images/DOM_Making_DOM_Stateful_domeditorscripts.png)

## Step 2: Deploy Kata DOM package

1. Go to <https://catalog.dataminer.services/details/package/5995>.

1. Click the *Deploy* button to deploy the DOM Editor script to your DMA.

1. When successful you should see the Event Management low-code app appear.

## Step 3: Defining the states on a DOM definition

Now that you have deployed the DOM Editor to your DMA, you can use it to edit the existing DOM definition called Event:

1. [Open DataMiner Cube](xref:Using_the_desktop_app) and go to *Apps* > *Automation*.

1. In the Automation module, search for a script called **DOM Editor** and select it.

   ![Dom Editor Script](~/user-guide/images/DOM_Getting_Started_script.png)

1. Click the *Execute* button in the lower right corner to launch this script, and then click *Execute now*.

   You should now see the following window, where you should find a module called **eventmanagement**

   ![Dom Editor Modules](~/user-guide/images/DOM_Making_DOM_Stateful_modules.png)

1. Next to the **eventmanagement** module name, click *Edit*  to open the details of the module.

1. Click *Behavior Definitions* to go to the behavior definitions overview for this module. This is where you can manage anything related to states of a DOM definition

   ![Dom Editor Behavior Definitions](~/user-guide/images/DOM_Making_DOM_Stateful_behavior_definitions_click.png)

1. Click *New* to create a new behavior definition.

   ![Dom Editor Behavior Definitions New](~/user-guide/images/DOM_Making_DOM_Stateful_Behavior_Definitions.png)

1. In the *Name* box, enter `event behavior`.

   ![Dom Editor New Event Behavior Definition](~/user-guide/images/DOM_Making_DOM_Stateful_event_behavior.png)

1. Confirm with *Apply*.

1. Next we want to start defining some statuses for the Event DOM definition. To do that click *Statuses*

   ![Dom Editor Statuses](~/user-guide/images/DOM_Making_DOM_Stateful_statuses_click.png)

1. Click *New* to create a new status

   ![Dom Editor New Status](~/user-guide/images/DOM_Making_DOM_Stateful_new_status.png)

1. In the *Display Name* box, enter `Request`

   ![Dom Editor New Status](~/user-guide/images/DOM_Making_DOM_Stateful_status_request.png)

1. Click *Back* and repeat the same steps to create the statuses **Scheduled, In progress, Done**

1. Finally click *Back* again to go the the event behavior and click *Apply*

   ![Dom Editor Apply Behavior](~/user-guide/images/DOM_Making_DOM_Stateful_behavior_apply.png)

1. Click *Statuses* to go to the overview of created states

1. Click *Edit* next to the Request state

   ![Dom Editor Edit Request Status](~/user-guide/images/DOM_Making_DOM_Stateful_edit_request.png)

1. Click *Section Definition Links*

   ![Dom Editor Section Definition Links](~/user-guide/images/DOM_Making_DOM_Stateful_section_definition_link_click.png)

1. Click *Add*

   ![Dom Editor Add Section Definition Link](~/user-guide/images/DOM_Making_DOM_Stateful_section_definition_link_add.png)

1. Here we need to define which sections and fields we are going to link to the state `Request`. Automatically it already links the **Event Info** section. Next we need to define which field of this section we want to add. Click *Field Descriptors* to do that.

   ![Dom Editor Add Section Link](~/user-guide/images/DOM_Making_DOM_Stateful_section_definition_link_field_descriptors.png)

1. Click the `+` button **4 times** to add the 4 fields of the section to the state Request

   ![Dom Editor State Add Field](~/user-guide/images/DOM_Making_DOM_Stateful_section_definition_link_field_descriptors.png)

1. You should end up with the following 4 fields added

   ![Dom Editor State All Fields](~/user-guide/images/DOM_Making_DOM_Stateful_section_definition_link_all_fields_added.png)

1. In the state Request we do not want to show the *Notes* field, so uncheck the **visible** checkbox next to the Notes field

   ![Dom Editor Hide Notes Field](~/user-guide/images/DOM_Making_DOM_Stateful_section_definition_link_hide_notes_field.png)

1. Click *Back* three times to end up back to the overview of the different states. Repeat the same procedure for the states *Scheduled, In progress and Done*. For the *Scheduled* state put all fields in *read-only*, for the remain states you can choose which fields to display, make required or read-only

1. When done, click *Back* until returning to the event behavior page and don't forget to click *Apply*

1. Click *OK* and *Back* to arrive back at the module page, next *click* on *Definitions*

   ![Dom Editor Definitions](~/user-guide/images/DOM_Making_DOM_Stateful_definitions_click.png)

1. Next to the **Event** definition name, click *Edit*  to open the details of the DOM Definition.

1. In drop-down Behavior select the behavior, which we just created above, called **event behavior**

1. Click *Apply* and *Ok* and *Back* to arrive at module level

## Step 4: Defining the state transitions

1. Click *Behavior Definitions*

1. Click *Edit* next to `event behavior`

1. Click *Transitions* to open the page to define the transitions between the different states

   ![Dom Editor Transitions](~/user-guide/images/DOM_Making_DOM_Stateful_transitions_click.png)

1. Define the following 3 transitions

      |ID|From|To|
      |--- |----|----|
      |request_to_scheduled|Request|Scheduled|
      |scheduled_to_in progress|Scheduled|In progress|
      |in progress_to_done|In progress|Done|

   ![Dom Editor 3 Transitions](~/user-guide/images/DOM_Making_DOM_Stateful_3_transitions.png)

1. Click *Back* and *Apply*

## Step 5: Defining actions to trigger state transitions

1. Click *Actions* to open the page for adding actions

   ![Dom Editor Actions](~/user-guide/images/DOM_Making_DOM_Stateful_actions_click.png)

1. Cick *Add* to add a new action

1. Enter the following details of the action

   1. Enter `schedule` as the ID

   1. Enter `Event Button` in the Script field. This is the automation script that is going to be called when this actions is triggered
   
   ![Dom Editor Add Action](~/user-guide/images/DOM_Making_DOM_Stateful_add_action.png)

1. Click *Back*, *Back* and *Apply*

## Step 6: Defining a form button to trigger the action

1. Click *Buttons* to open the page for adding buttons

   ![Dom Editor Buttons](~/user-guide/images/DOM_Making_DOM_Stateful_buttons_click.png)

1. Cick *Add* to add a new button

1. Enter the following details of the button

   1. Enter `schedule` as the ID

   1. Enter `Schedule` as the Text

   1. Under **Actions** click the **+** button and select `schedule` from the drop-down

   1. Under **Condition > Type**, select `Status`

   1. Under Valid Statuses , click *Add*, select `Request` from the drop-down. This means that the button will only appear on the form in case the event instance is in the state `Request`, it will not be visible in the other states (Scheduled, In progress, Done)

   ![Dom Editor Add Button](~/user-guide/images/DOM_Making_DOM_Stateful_add_button.png)

1. Click *Back*, *Back* and *Apply*

## Step 7: Validate states, transitions, buttons in the low-code app

1. Open up the low-code app called **Event Management**

   ![App Empty](~/user-guide/images/DOM_Making_DOM_Statefel_app_empty.png)

1. Click *New* to open up the Event form panel on the right-hand side

1. Enter a random name of an event into the *Event name* field

   ![App Form](~/user-guide/images/DOM_Making_DOM_Stateful_form.png)

1. Click *Save* which close the panel

1. Click the *pencil* icon next to the event you have just created to open the panel again

1. Notice that the stepper component on top shows that the event is in `Request` state:

   ![App Stepper in Request state](~/user-guide/images/DOM_Making_DOM_Stateful_stapper_request.png)

1. On the bottom right of the form, click the *Schedule* button

   ![App Stepper Schedule button](~/user-guide/images/DOM_Making_DOM_Stateful_Schedule_button.png)

1. Now you should see the stepper component move from **Request** to **Scheduled**. Also notice that the form will have changed to read only as we specified when defining the states.

   ![App Stepper Event in Schedule state](~/user-guide/images/DOM_Making_DOM_Stateful_event_scheduled.png)
