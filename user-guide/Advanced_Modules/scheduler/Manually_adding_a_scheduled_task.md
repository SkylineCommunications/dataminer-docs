---
uid: Manually_adding_a_scheduled_task
---

# Manually adding a scheduled task

To add a new scheduled task without a Scheduler template:

1. In the Scheduler module, go to the *list* tab.

2. Click the *Add* button.

    > [!NOTE]
    > If you want to make a task that is very similar to an existing task, you can also select the existing task and click the *Duplicate* button. In the same manner, you can also edit existing tasks with the *Edit* button, or delete them with the *Delete* button.

3. In the *general* tab, enter a name and a description.

4. If you want the task to be immediately enabled, make sure the *Enabled* checkbox is selected.

5. Click *Next* to go to the *schedule* tab.

6. Under *Schedule*, specify at which interval the task has to be executed: once, daily, weekly or monthly.

7. Under *Time of execution*, specify when the task has to be executed. Depending on the interval, different options will be available.

    > [!NOTE]
    > Within the tasks list itself, it is also possible to immediately execute any of the existing tasks, regardless of what interval and timing has been configured for them. To do so, select the task and click the *Execute* button.

8. Click *Next* to go to the *actions* tab.

9. Under *Actions*, click *Add* and select which action should be executed:

    | Action                       | Description                                                                                                                                                                                                 |
    |--------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Information                    | Specify a message that will appear as an information event at the scheduled time.                                                                                                                           |
    | SMS                            | Specify a text message that will be sent to the cellphone of a contact person.                                                                                                                              |
    | Email                          | Compose an email message, optionally including a report or dashboard.                                                                                                                                       |
    | Upload report to FTP           | Specify an FTP server, and a report or dashboard to upload to it.                                                                                                                                           |
    | Upload report to shared folder | Specify a shared folder, and a report or dashboard to upload to it.                                                                                                                                         |
    | Script                         | Select an existing Automation script to be executed at the scheduled time. For more information on the script execution options, see [Script execution options](xref:Script_execution_options). |

    > [!NOTE]
    > 
    > - To attach a report to an email message as a separate PDF, select both *Plain text* and *Include report or dashboard*.
    > - For the *Email* or *Upload report* actions, from DataMiner 9.6.13 onwards, you can select a dashboard from the Dashboards app instead of a legacy report. The dashboards are listed in the drop-down list along with the reports. The icon in front of each item in the list shows whether the item is a dashboard or a report. From DataMiner 10.0.13 onwards, a *Configure* button is available that allows you to further configure a report based on a dashboard. See [Generating a PDF report based on a dashboard using DataMiner Cube](xref:Generating_a_report_based_on_a_dashboard_Cube).

10. To add more actions, repeat the previous step until all actions have been added.

11. To also add a number of actions to be performed when the task is removed, select the option *Execute final actions when the task is removed*, and add the necessary actions below it. These actions will then be executed when the task reaches its end time or when it has been executed for the last time.

12. When all the necessary actions have been added, click *OK*.

    The task will now be displayed in the task list.

    > [!NOTE]
    >
    > - To see tasks that have already been executed, select the *Show finished tasks* option in the lower left corner.
    > - To quickly find a particular task in the list, use the filter box in the top-right corner.
