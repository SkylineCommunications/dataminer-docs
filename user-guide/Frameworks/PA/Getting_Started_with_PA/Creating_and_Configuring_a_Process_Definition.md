---
uid: PA_Creating_and_Configuring_a_Process_Definition
---

# Creating and configuring a process definition

> [!NOTE]
> When creating and configuring a process definition, it is important to follow each step listed below in the specific order they occur on this page.

## Creating a process DOM definition

Create a process DOM definition, adding all parameters that are relevant for the process.

> [!NOTE]
> At present, there is no user interface or dedicated development environment available to create DOM definitions. Contact Skyline Communications if you want more information on how to create DOM definitions.

The process DOM instance will be the only way to exchange data between activities. Therefore, make sure it contains all relevant field descriptors.

The process DOM definition needs to be part of the *process_automation* module ID. The Process DOM definition is defined in the *process_automation* module.

> [!NOTE]
> By default, TTL on the *process_automation* module ID is set to 30 days. This means that process DOM instances will stay in the database for 30 days after the last update action.

## Creating a process definition

1. In DataMiner Cube, open the *Process Automation* app.

1. In the *process definitions* tab, click *New* to start creating a new process definition.

1. Specify a name for the process definition, select a Booking Manager element, and click *Create*.

   A new process definition will be created and automatically selected.

1. Drag activities from the *Functions* sidebar to the workspace on the right.

1. Connect the activities by dragging from one blue dot on the edge of an activity icon to another. To remove connections, right-click the line created between activities and select *Delete*.

   Keep this in mind:

   - Always start with a *PA None Event* or *PA Timer Start Event*.

   - Make sure all branches end with a *PA End Event*.

   - For each script task that will be used in a process, make use of the generic *PA Script Task.*

   ![Process Definition](~/user-guide/images/Process_Definition.png)

1. Save the service definition with the *Save All* button.

1. Select each activity individually and give it a meaningful label using the *Edit Label* button in the lower right corner.

   > [!NOTE]
   > Labels must be unique across the entire process definition.

## Creating and assigning profile instances

1. Make sure there is a profile instance for the PA None Start Event. If this profile instance does not exist yet, create one in the [*Profiles* module](xref:The_Profiles_module) that applies to the PA None Start Event, with the following values:

   - *PA Initial Process Instantiation*: Set this to *Disabled*.
   - *PA Business Key*: Leave this set to *Not configured*.
   - *PA DOM Reference*: Leave this set to *Not configured*.

     ![Profile_Instance](~/user-guide/images/Profile_Instance.png)

   Alternatively, start the process with a *PA Timer Start Event* that can be used to generate new tokens periodically (see [Pushing tokens periodically](xref:Pushing_Tokens_Into_A_Process#pushing-tokens-periodically)).

1. In the *Process Automation* app, select the newly created process definition.

1. Click the *Configure* button to open the *process definition configuration* wizard.

1. On the first page of the wizard, select the process DOM definition and click *Next*. A page will be shown where all nodes in the process definition are listed.

1. For each node in the process definition:

   1. Select the node and click *Configure*.

   1. Provide the requested information. This will mainly be related to the profile instance selection, profile instance creation, and the link with DOM field descriptors.

      ![Process_Definition_Configuration](~/user-guide/images/Process_Definition_Configuration.png)

      For example, for a "Ping IP" script task, the following input would be needed in the wizard:

      - **Profile Definition**: The profile definition set up during the creation of the "Ping IP" script task.

      - **Profile Instance**: An existing or new profile instance.

      - **Profile Parameters**: A list of profile parameters that are part of the profile definition.

        Parameters are used to define the input and output of the activity. Input parameters can contain hard-coded values. In that case, the same value will always be used. Alternatively, they can refer to a field descriptor from the process DOM instances. In that case, different values can be used for each process run.

        - Hard-coded value:

          ![Hard-coded Value](~/user-guide/images/Hard_Coded_Value.png)

        - Dynamic value:

          ![Dynamic Value](~/user-guide/images/Dynamic_Value.png)

        Output parameters should be linked to the field descriptor of the process DOM instance.

1. Click the *Confirm* button.

## Creating an activation window

1. In the *Process Automation* app, select the newly created process definition.

1. Click the *Activate* button.

1. On the first page of the *create activation window* wizard, specify the following information:

   - **Process name**: Specify a name for the activation window.

   - **Service group**: This information will already be filled in and can be left as is.

   - **Service info**: This identifies the process and makes it possible to push tokens into the process from custom code. To configure this, there are two options:

     - Select *Create New* to create *Service info* with the same name as the activation window.

     - Select an existing *Service info* item in case multiple activation windows need to be created that should always be linked to the same process identifier.

     - **Process definition**: This information will already be filled in and can be left as is.

     - **Process type**: This information will already be filled in and can be left as is.

   - **Time specifications**: Edit according to your own preferences.
   
   > [!NOTE]
   > Make sure all fields are populated.
   
     ![Activation Window](~/user-guide/images/Activation_Window.png)
     
1. Click the *Confirm* button.
