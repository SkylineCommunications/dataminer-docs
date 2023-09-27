---
uid: Pushing_Tokens_Into_A_Process
---

# Pushing tokens into a process

When a process has at least one defined activation window (past, present, or future), it is possible to push tokens into the process using the following method:

`ProcessHelper.PushToken(<process_name>, <business_key>, <DOM_Instance_id>);`

- *ProcessHelper* is a static class from *Skyline.DataMiner.DataMinerSolutions.ProcessAutomation.MessageHandler*.

- *Process_name* is the name of the process provided during the creation of the first activation window.

- *Business_key* is a custom human-readable identifier of the token.

- *DOM_instance_id* is the ID of the process DOM instance.

> [!NOTE]
>
> - For each token pushed into a process, a new process DOM instance must be generated.
> - This method requires *ProcessAutomation.dll*

### Pushing tokens at the start of an activation window

When an activation window starts, it is possible to immediately push a token into the process. You can achieve this as follows:

1. In the *Process Automation* app, verify that the process definition contains a *PA None Start Event* node.

1. In the [*Profiles* module](xref:The_Profiles_module), go to the *Instances* tab, and create a new profile instance:

   1. Make sure it is set to apply to the *PA None Start Event* profile definition.

   1. Create a [Process DOM instance](xref:DomInstance).

   1. Define a business key (human-readable identifier of the token).

   1. Configure the following parameters:

      - **PA Business Key**: The business key that was previously defined.

      - **PA DOM Reference**: The process DOM instance that was previously defined.

      - **PA Initial Process Instantiation**: Set to *Enabled*.

1. Next, when configuring the process, select the newly created profile instance for the *PA None Start Event* node:

   1. In the *Process Automation* app, select a process definition in the sidebar on the left and click *Configure*.

   1. In the *process definition configuration* wizard, select the preferred process DOM definition and click *Next*.

      A page will be shown where all nodes in the process definition are listed.

   1. Click the *Configure* button next to the *Start* node and provide the requested information:

      - **Activity**: Start

      - **Profile definition**: *PA None Start Event*

      - **Profile instance**: Select the newly created profile instance.

   1. Click *OK* and *Confirm* to save all changes and exit the configuration wizard.

### Pushing tokens periodically

During an activation window, it is possible to push new tokens into a process on a regular basis. You can achieve this as follows:

1. In the *Process Automation* app, verify that the process definition contains a *PA Timer Start Event* node.

1. In the *Profiles* module, go to the *Instances* tab, and create a new profile instance.

   1. Make sure the instance is set to apply to the *PA Timer Start Event* profile definition.

   1. Create a [Process DOM instance](xref:DomInstance).

   1. Define a business key (human-readable identifier of the token).

   1. Configure the following parameters:

      - **PA Business Key**: The business key that was previously defined.

      - **PA DOM Reference**: The process DOM instance that was previously defined.

      - **PA Initial Process Instantiation**: Set to *Enabled*.

      - **PA Timer Start Recurring Pattern**: Serialized JSON, based on the *PaTimerStartEventRecurringPattern* class, defining the recurring pattern for token generation.

        For example, to generate two tokens with a 1-minute interval between them:

        ```json
        {"FrequencyInterval":0,"Occurrences":2,"SubdayInterval":1,"SubdayType":"Minutes"}
        ```

        > [!NOTE]
        > The *PaTimerStartEventRecurringPattern* class will support extra timing use cases in the future. However, for now, it is only possible to generate a limited or unlimited number of tokens on a regular basis.
