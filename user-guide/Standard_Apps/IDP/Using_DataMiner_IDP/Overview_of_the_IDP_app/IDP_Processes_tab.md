---
uid: IDP_Processes_tab
---

# Processes tab

> [!NOTE]
>
> - If you do not have Process Automation installed but would like to begin using it in an existing IDP setup, install DataMiner SRM, Process Automation and Token activity, and optionally install the Repeat Gateway. Make sure you are using IDP version 1.1.12 or higher. Then run the IDP setup wizard to activate the use of Process Automation.
> - If you are using an older IDP version (prior to IDP 1.1.20), this tab consists of two subtabs: *Schedules*, with the functionality described above, and *Activities*, which the functionality of the later *Admin* > *Activities* > *Overview* page. See [Overview](xref:Admin_activities#overview).
> - Prior to IDP 1.1.11, this tab was called *Workflows*. The *Activities* subtab was called *Automation* prior to IDP 1.1.16.

If IDP is used together with DataMiner Process Automation, this tab displays an overview of scheduled processes.

Click the *New* button to open the Process Automation wizard. In this wizard, you can create or schedule processes consisting of one or more activities. To do so:

1. In the first step of the wizard, specify:

   - The process name.

   - The activation window type: *Single Event* or *Permanent Service*.

   - The activation window: The start time, as well as the stop time or duration in case of a single event.

1. In the second step of the wizard:

   - Select an existing process to schedule it again or create a custom process.

   - In the *Start* drop-down box, select whether the process should be executed once (*Instant*) or repeated at regular intervals (*Timer*). If you select *Timer*, you will need to specify a profile and interval for the timer. Note that this drop-down box is only available if a repeat gateway is available in the DMS. If no repeat gateway is available, the process will always be executed once.

   - If you are creating a custom process, click the *Add* *Activity button* to add an activity to the process. You can use the *Delete Activity* button to remove the last activity you have added.

   - For each activity you add, select which activity should be executed. The available choices depend on the preceding activity in the process. For example, after the activity *SLC IDP Discover Data Sources*, you need to select the activity *SLC IDP Provision Element* before any other activities become available.

   - For each activity, select a profile and resource if necessary.

   - When you have selected a profile for an activity, and there are mandatory profile parameters, a value must be assigned to these before you can continue to the next step of the wizard. If there are no mandatory profile parameters, a *Show Details* label is displayed next to the arrow button below the profile. Click the arrow button to view and change the profile parameter values according to your preference. If there are mandatory profile parameters, a *Show All* label is displayed instead, and clicking the arrow button shows any profile parameters for which it is not necessary to assign a value.

   - If a suitable resource is detected for an activity, it will be selected automatically.

1. In the final step:

   - Select the profile instance that should be used for the first token of the process. For example, if the first activity is a discovery activity, you must select the profile that will determine the scan range for this activity.

     > [!NOTE]
     > For some processes (e.g. *IDP IS-04 Provision New Nodes* and *IDP IS-04 Update Existing Nodes*), selecting a start token is not possible. These make use of custom scripts instead.

   - The token selection is displayed below the start profile selection. If a suitable profile instance is available for the token, it will be selected automatically. Selecting or customizing a token profile instance in this step allows you to fine-tune the way the token will be handled by Process Automation. You can for instance indicate the priority for the token and the duration it should be allowed to stay in the queue.

   - If a profile instance and resource can be selected automatically, the token section is collapsed.

1. When the necessary configuration is done, click *Create* to create the process. The scheduled process will be added to the timeline on the *Processes* > *Schedules* tab and executed at the specified time.

> [!NOTE]
> Depending on your IDP version, activity settings **can be disabled by default**. See [Activities](xref:Admin_activities). To perform any of these actions for a specific CI Type, make sure the relevant activity is enabled.
