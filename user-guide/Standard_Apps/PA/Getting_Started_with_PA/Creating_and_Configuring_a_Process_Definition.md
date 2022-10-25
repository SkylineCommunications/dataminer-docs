---
uid: Creating_and_Configuring_a_Process_Definition
---

# Creating and configuring a process definition

## Create process DOM definition

Create a process DOM definition, adding all parameters that are relevant for the process.

The process DOM instance will be the only way to exchange data between activities. Therefore, make sure it contains all relevant field descriptors.

The Process DOM definition needs to be used with the “process_automation” module ID.

> [!NOTE]
> At present, there is no user interface or dedicated development environment available to create DOM definitions. Contact Skyline Communications if you want more information on how to create DOM definitions.

> [!NOTE]
> By default, TTL on the “process_automation” module ID is set to 30 days. This means that the process DOM instances will stay in the database for 30 days after the last update action.

## Create process definition

1. In DataMiner Cube, open the *Process Automation* app.

1. In the *process definitions* tab, click *New* to start creating a new process definition.

1. Specify a name for the process definition, select a Booking Application, and click *Create*. A new process definition will be created and automatically selected.

1. Drag activities from the *Functions* sidebar to the workspace on the right. To connect the activities, drag your mouse from one blue dot on the side of an activity icon to another. To remove connections, right-click the line created between activities and select *Delete*.

   Keep this in mind:

   - Always start with a *PA None Event* or *PA Timer Start Event*.

   - Make sure all branches end with a *PA End Event*.

   - For each script task that will be used in a process, make use of the generic *PA Script Task.*

   ![Process Definition](~/user-guide/images/Process_Definition.png)

1. Save the service definition with the *Save All* button.

1. Select each activity individually and give it a meaningful label using the *Edit Label* button in the bottom right corner.

   > [!NOTE]
   > Labels must be unique across the entire process definition.

## Create and assign profile instances

1. Make sure there is a profile instance for the PA None Start Event. If this profile instance does not exist yet, create one in the [*Profiles* module](xref:The_Profiles_module) that applies to the PA None Start Event and with the following values :

   - *PA Initial Process Instantiation*: Set this to *Disabled*.
   - *PA Business Key*: Leave this as *Not configured*.
   - *PA DOM Reference*: Leave this as *Not configured*.

     ![Profile_Instance](~/user-guide/images/Profile_Instance.png)

   Alternatively, start the process with a *PA Timer Start Event* that can be used to generate new tokens periodically (see Generate Tokens Periodically).

<!-- Comment: Add xref once 'Generate Tokens Periodically' has been added. -->

1. In the *Process Automation* app, select the newly created process definition.

1. Click the *Configure* button to open the process definition configuration wizard.

1. On the first page of the wizard, select the process DOM definition and click *Next*.

   A page will be shown where all nodes in the process definition are listed.

1. For each node in the process definition:

   1. Select the node and click *Configure*.

   1. Provide the requested information. This will mainly be related to the profile instance selection, profile instance creation, and the link with DOM field descriptors.

      ![Process_Definition_Configuration](~/user-guide/images/Process_Definition_Configuration.png)

      For example, for a ‘Ping IP’ script task, the following input would be needed in the wizard:

      - **Profile Definition**: The profile definition set up during the creation of the “Ping IP” script task

      - **Profile Instance**: An existing profile instance or the creation of a new instance

      - **Profile Parameters**: A list of profile parameters that are part of the profile definition

        Parameters are used to define the input and output of the activity. Input parameters can contain hard-coded values. In that case, the same value will always be used. Alternatively, they can refer to a field descriptor from the Process DOM instances. In that case, different values need to be used for each process run.

        1. Hard Coded value:

           ![Hard Coded Value](~/user-guide/images/Hard_Coded_Value.png)

        1. Dynamic value:

           ![Dynamic Value](~/user-guide/images/Dynamic_Value.png)

           For output parameters, it only makes sense to link them to the field descriptor of the Process DOM Instance.

1. Click the *Confirm* button.
