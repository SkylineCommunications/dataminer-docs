---
uid: Manually_adding_a_scheduled_task
---

# Manually adding a scheduled task

To add a new scheduled task without a Scheduler template:

1. In the Scheduler module, go to the *list* tab.

1. Click the *Add* button.

   > [!NOTE]
   > If you want to make a task that is very similar to an existing task, you can also select the existing task and click the *Duplicate* button. In the same manner, you can also edit existing tasks with the *Edit* button, or delete them with the *Delete* button.

1. In the *general* tab, enter a name and a description.

1. If you want the task to be immediately enabled, make sure the *Enabled* checkbox is selected.

1. Click *Next* to go to the *schedule* tab.

1. Under *Schedule*, specify at which interval the task has to be executed: once, daily, weekly or monthly.

1. Under *Time of execution*, specify when the task has to be executed. Depending on the interval, different options will be available.

   > [!NOTE]
   > Within the tasks list itself, it is also possible to immediately execute any of the existing tasks, regardless of what interval and timing has been configured for them. To do so, select the task and click the *Execute* button.

1. Click *Next* to go to the *actions* tab.

1. Under *Actions*, click *Add* and select which action should be executed:

   - **Information**: Specify a message that will appear as an information event at the scheduled time.
   - **SMS**: Specify a text message that will be sent to the cellphone of a contact person.
   - **Email**: Compose an email message, optionally including a dashboard or (legacy) report.
   - **Upload report to FTP**: Specify an FTP server, and a dashboard or (legacy) report to upload to it. For more detailed information, see [Upload report to FTP](xref:Upload_report_to_FTP).
   - **Upload report to shared folder**: Specify a shared folder, and dashboard or (legacy) report to upload to it. For more detailed information, see [Upload report to shared folder](xref:Upload_report_to_shared_folder).
   - **Script**: Select an existing Automation script to be executed at the scheduled time. For more information on the script execution options, see [Script execution options](xref:Script_execution_options).

   > [!NOTE]
   >
   > - To attach a report to an email message as a separate PDF, HTML, or CSV, select both *Plain text* and *Include report or dashboard*.
   > - If you want to specify multiple parameters for one element, service, or protocol version in a report or dashboard, assign them all within a single line.
   > - For the *Email* action (if you add a dashboard or (legacy) report) or the *Upload report* action, an icon in front of each item in the list shows whether the item is a dashboard or a report. When you have selected a dashboard, you can click the *Configure* button to further configure the report based on the dashboard. See [Generating a report based on a dashboard using DataMiner Cube](xref:Generating_a_report_based_on_a_dashboard_Cube).
   > - If you edit an existing *Email* action that uses a dashboard that no longer exists, from DataMiner 10.4.0 [CU10]/10.5.0/10.5.1 onwards<!--RN 41364-->, the dashboard will be displayed in red.
   > - Prior to DataMiner 10.5.4/10.6.0<!--RN 41970-->, an information event will automatically be generated when an Automation script is triggered by the Scheduler module. If you also want this to happen in versions from DataMiner 10.5.4/10.6.0 onwards, you will need to set the *SkipInformationEvents* option to "false" in *MaintenanceSettings.xml*. See [Enabling information events when scripts are started by Correlation rules or scheduled tasks](xref:Configuration_of_DataMiner_processes#enabling-information-events-when-scripts-are-started-by-correlation-rules-or-scheduled-tasks).
   > - For the *Email* action, the subject and message support the following placeholders<!--RN 42985-->:
   >
   >   - `[dummyX]`: This will be replaced with the name of the specific element you want to display. X is the dummy ID.
   >   - `[user]`: This will be replaced with the name of the user executing the scheduled task.

1. To add more actions, repeat the previous step until all actions have been added.

1. To also add a number of actions to be performed when the task is removed, select the option *Execute final actions when the task is removed*, and add the necessary actions below it. These actions will then be executed when the task reaches its end time or when it has been executed for the last time.

1. When all the necessary actions have been added, click *OK*.

   The task will now be displayed in the task list.

   > [!NOTE]
   >
   > - To see tasks that have already been executed, select the *Show finished tasks* option in the lower-left corner.
   > - To quickly find a particular task in the list, use the filter box in the top-right corner.
