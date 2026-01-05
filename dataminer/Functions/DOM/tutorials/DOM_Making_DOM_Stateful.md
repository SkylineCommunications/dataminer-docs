---
uid: DOM_Making_DOM_Stateful
---

# Making DOM objects state-aware

This tutorial shows how you can make your DOM objects state-aware. This allows a DOM instance to behave differently depending on the state it transitions to. The following things can be defined for each state:

- Which fields are **visible** to the user.
- Which fields are **read-only** for the user.
- Which fields are **mandatory**.
- To which state the instance can **transition**.
- What **actions** are allowed.
- What **buttons** to show on the form.

The content and screenshots for this tutorial were created in DataMiner version 10.4.3.

Expected duration: 20 minutes

> [!TIP]
> This tutorial is included in the following Kata: [Kata #24: Making DOM objects state-aware](https://community.dataminer.services/courses/kata-24/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)
>
> If you are new to DataMiner Object Models (DOM), first watch [Kata #15: Getting started with DataMiner Object Models](https://community.dataminer.services/courses/kata-15/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

## Prerequisites

- A DataMiner System using DataMiner 10.3.10 or higher, which is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
- An [indexing database](xref:Indexing_Database) or [Storage as a Service](xref:STaaS).

> [!NOTE]
> If you use a [DaaS system](xref:Creating_a_DMS_in_the_cloud), these prerequisites are automatically met.

## Overview

- [Step 1: Deploy the DOM Editor script](#step-1-deploy-the-dom-editor-script)
- [Step 2: Deploy the Kata DOM package](#step-2-deploy-the-kata-dom-package)
- [Step 3: Define states on a DOM definition](#step-3-define-states-on-a-dom-definition)
- [Step 4: Define the state transitions](#step-4-define-the-state-transitions)
- [Step 5: Define actions to trigger state transitions](#step-5-define-actions-to-trigger-state-transitions)
- [Step 6: Define a form button to trigger the action](#step-6-define-a-form-button-to-trigger-the-action)
- [Step 7: Validate states, transitions, and buttons in the low-code app](#step-7-validate-states-transitions-and-buttons-in-the-low-code-app)

## Step 1: Deploy the DOM Editor script

> [!NOTE]
> If you have already followed the previous tutorial, [Getting started with DOM](xref:DOM_Getting_Started_With_DOM), this script has already been deployed, so you can skip to [step 2](#step-2-deploy-the-kata-dom-package).

1. Go to <https://catalog.dataminer.services/details/automation-script/3195>.

1. Click the *Deploy* button to deploy the DOM Editor package to your DMA.

1. [Open DataMiner Cube](xref:Connecting_to_a_DMA_with_Cube), go to *Apps* > *Automation*, and check whether the following scripts have become available:

   ![Dom Editor scripts](~/dataminer/images/DOM_Making_DOM_Stateful_domeditorscripts.png)

   When these are available, the package has been successfully deployed.

## Step 2: Deploy the Kata DOM package

1. Go to <https://catalog.dataminer.services/details/0e9f4b50-cab7-4d2d-855f-f2a4173f1ccc>.

1. Click the *Deploy* button to deploy the Kata DOM package to your DMA.

1. Go to the DataMiner landing page and check whether the Event Management low-code app has become available.

   If this app is available, the package has been successfully deployed.

   > [!TIP]
   > See also: [Accessing the web apps](xref:Accessing_the_web_apps).

## Step 3: Define states on a DOM definition

Now that you have deployed the DOM Editor to your DMA, you can use it to edit the existing DOM definition called *Event*:

1. In the Automation module in DataMiner Cube, search for the **Dom Editor** script and select it.

1. Click the *Execute* button in the lower-right corner to launch this script, and then click *Execute now*.

   ![Dom Editor script](~/dataminer/images/DOM_Getting_Started_script.png)

   The following window will be shown, where you should find a module called *eventmanagement*:

   ![Dom Editor modules](~/dataminer/images/DOM_Making_DOM_Stateful_modules.png)

1. Next to the *eventmanagement* module name, click *Edit* to open the details of the module.

1. Create a new behavior definition:

   1. Click *Behavior Definitions* to go to the behavior definitions overview for this module.

      ![Dom Editor behavior definitions](~/dataminer/images/DOM_Making_DOM_Stateful_behavior_definitions_click.png)

      This overview is where you can manage everything related to states of a DOM definition.

   1. Click *New*.

      ![Dom Editor new behavior definition](~/dataminer/images/DOM_Making_DOM_Stateful_Behavior_Definitions.png)

   1. In the *Name* box, enter `event behavior`.

      ![Dom Editor new event behavior definition](~/dataminer/images/DOM_Making_DOM_Stateful_event_behavior.png)

   1. Confirm by clicking *Apply*.

1. Define states for the Event DOM definition:

   1. Click *Statuses*.

      ![Dom Editor statuses](~/dataminer/images/DOM_Making_DOM_Stateful_statuses_click.png)

   1. Click *New* to create a new state.

      ![Dom Editor new status](~/dataminer/images/DOM_Making_DOM_Stateful_new_status.png)

   1. In the *Display Name* box, enter `Request`.

      ![Dom Editor new status name](~/dataminer/images/DOM_Making_DOM_Stateful_status_request.png)

   1. Click *Back* and repeat the previous two steps to create the states `Scheduled`, `In progress`, and `Done`.

   1. Finally, click *Back* again to go the event behavior page, and click *Apply*.

      ![Dom Editor apply behavior](~/dataminer/images/DOM_Making_DOM_Stateful_behavior_apply.png)

1. Click *Statuses* to go to the overview of the created states.

1. Define which sections and fields should be linked to the states you have defined:

   1. Next to the *Request* state, click *Edit*.

      ![Dom Editor edit request state](~/dataminer/images/DOM_Making_DOM_Stateful_edit_request.png)

   1. Click *Section Definition Links*.

      ![Dom Editor section definition links](~/dataminer/images/DOM_Making_DOM_Stateful_section_definition_link_click.png)

   1. Click *Add*.

      ![Dom Editor add section definition link](~/dataminer/images/DOM_Making_DOM_Stateful_section_definition_link_add.png)

      This will show a page where you can define the sections and fields linked to the state `Request`. The *Event Info* section will automatically be linked already.

   1. Click *Field Descriptors* to define a field to add to the *Event Info* section.

      ![Dom Editor add section link](~/dataminer/images/DOM_Making_DOM_Stateful_section_definition_link_field_descriptors.png)

   1. Click the `+` button **4 times** to add the 4 fields of the section to the *Request* state.

      ![Dom Editor state add field](~/dataminer/images/DOM_Making_DOM_Stateful_section_definition_link_add_field_descriptor.png)

      You should end up with the following 4 fields added:

      ![Dom Editor state all fields](~/dataminer/images/DOM_Making_DOM_Stateful_section_definition_link_all_fields_added.png)

   1. For the *Notes* field, clear the selection from the *Visible* checkbox.

      ![Dom Editor hide Notes field](~/dataminer/images/DOM_Making_DOM_Stateful_section_definition_link_hide_notes_field.png)

      This way, the *Notes* field will not be shown for the *Request* state.

   1. Click *Back* three times to go back to the overview of the different states.

   1. Repeat the steps above for the states *Scheduled*, *In progress*, and *Done*.

      - For the *Scheduled* state, set all fields to *read-only*.

      - For the remaining states, you can choose which fields to display, make required, or set to read-only.

   1. When this is done for all states, click *Back* until you are back at the event behavior page.

   1. Click *Apply*.

1. Click *OK* and *Back* to go back to the *eventmanagement* module page.

1. Click *Definitions*.

   ![Dom Editor definitions](~/dataminer/images/DOM_Making_DOM_Stateful_definitions_click.png)

1. Next to the *Event* definition name, click *Edit* to open the details of the DOM definition.

1. In the *Behavior* dropdown box, select the behavior you created above, i.e. *event behavior*.

1. Click *Apply*, *OK*, and *Back* to go back to module level.

## Step 4: Define the state transitions

1. Click *Behavior Definitions*.

1. Next to *event behavior*, click *Edit* .

1. Click *Transitions* to open the page where you can define the transitions between the different states.

   ![Dom Editor transitions](~/dataminer/images/DOM_Making_DOM_Stateful_transitions_click.png)

1. Define the following transitions:

   | ID                       | From        | To          |
   |--------------------------|-------------|-------------|
   | request_to_scheduled     | Request     | Scheduled   |
   | scheduled_to_in progress | Scheduled   | In progress |
   | in progress_to_done      | In progress | Done        |

   ![Dom Editor 3 transitions](~/dataminer/images/DOM_Making_DOM_Stateful_3_transitions.png)

1. Click *Back* and *Apply*.

## Step 5: Define actions to trigger state transitions

1. Click *Actions* to open the page where you can add actions.

   ![Dom Editor actions](~/dataminer/images/DOM_Making_DOM_Stateful_actions_click.png)

1. Click *Add* to add a new action.

1. Enter the following details for the action:

   1. In the *ID* box, enter `schedule`.

   1. In the *Script* box, enter `Event Button`.

      This is the Automation script that will be called when this action is triggered.

   ![Dom Editor add action](~/dataminer/images/DOM_Making_DOM_Stateful_add_action.png)

1. Click *Back*, *Back*, and *Apply*.

## Step 6: Define a form button to trigger the action

1. Click *Buttons* to open the page where you can add buttons.

   ![Dom Editor buttons](~/dataminer/images/DOM_Making_DOM_Stateful_buttons_click.png)

1. Click *Add* to add a new button.

1. Configure the following details for the button:

   1. In the *ID* box, enter `schedule`.

   1. In the *Text* box, enter `Schedule`.

   1. Under *Actions*, click the **+** button, and select *schedule* in the dropdown box.

      This is the action you created in [step 5](#step-5-define-actions-to-trigger-state-transitions).

   1. Under *Condition* > *Type*, select *Status*.

   1. Under *Valid Statuses*, click *Add*, and then select *Request* in the dropdown box.

      With this configuration, the button will only be shown on the form when the event instance is in the *Request* state. It will not be visible for the other states (*Scheduled*, *In progress*, and *Done*).

   ![Dom Editor add button](~/dataminer/images/DOM_Making_DOM_Stateful_add_button.png)

1. Click *Back*, *Back*, and *Apply*.

## Step 7: Validate states, transitions, and buttons in the low-code app

1. Open the **Event Management** low-code app.

   ![Empty Event Management app](~/dataminer/images/DOM_Making_DOM_Statefel_app_empty.png)

   > [!TIP]
   > See also: [Accessing the web apps](xref:Accessing_the_web_apps).

1. Click *New* to open the event form panel on the right-hand side.

1. In the *Event name* field, enter a random name for an event.

   ![App form](~/dataminer/images/DOM_Making_DOM_Stateful_form.png)

1. Click *Save*.

   This will close the panel.

1. Click the *pencil* icon next to the event you have just created to open the panel again.

   You will see that the stepper component at the top shows that the event is in the *Request* state:

   ![App stepper in Request state](~/dataminer/images/DOM_Making_DOM_Stateful_stapper_request.png)

1. In the lower-right corner of the form, click the *Schedule* button.

   ![App Schedule button](~/dataminer/images/DOM_Making_DOM_Stateful_Schedule_button.png)

   You will see the stepper component move from **Request** to **Scheduled**. The form will also change to read-only, as you configured this when defining the states.

   ![App stepper event in Schedule state](~/dataminer/images/DOM_Making_DOM_Stateful_event_scheduled.png)
