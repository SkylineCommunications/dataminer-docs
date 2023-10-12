---
uid: About_the_Scheduler_module
---

# About the Scheduler module

To access the Scheduler module:

- In DataMiner Cube, go to *Apps* > *Scheduler*.

The Scheduler module allows you to schedule events in two ways:

- By manually adding a task to the list of scheduled tasks, in the *list* tab. See [Manually adding a scheduled task](xref:Manually_adding_a_scheduled_task)

- By dragging events, based on Scheduler templates, onto a timeline, in the *timeline \> EVENTS* tab. See [Scheduling an event based on a Scheduler template](xref:Scheduling_an_event_based_on_a_Scheduler_template).

> [!TIP]
> See also:
> [Rui’s Rapid Recap – Scheduler](https://community.dataminer.services/video/ruis-rapid-recap-scheduler/) ![Video](~/user-guide/images/video_Duo.png)

## Overview of the Scheduler UI

The Scheduler module consists of different tabs that each provide a different perspective on the task scheduled in Cube.

- In the *list* tab, all scheduled tasks are shown in a list. Next to each task, the different columns show when the task is scheduled and at what interval, the next and last time the task was run, and the result of the last time it was run.

  > [!NOTE]
  >
  > - In the *Last runtime result* column, the color of the entry reflects the result: red indicates that the task failed, green indicates success, and gray corresponds to a currently running task.
  > - To quickly find a particular scheduled task, you can use the quick filter box in the top-right corner. It can be used to filter on the task name or on the content of any of the other columns.
  > - It is possible to execute a scheduled task immediately, regardless of when it is scheduled, by selecting the task and then clicking the *Execute* button at the bottom of the card. If you do so, the task will be executed again at the time when it was originally scheduled. However, note that in DataMiner versions prior to 9.0.0 CU9, the manual execution of a non-recurring task instead replaces the scheduled execution.

- In the *timeline* tab, two different subtabs provide a different view on the scheduled tasks:

  - Under *TASKS* you can view all scheduled tasks, including events based on Scheduler templates. For the latter, two tasks will be displayed, a “START” and a “STOP” task. The tasks are displayed as dots on the timeline.

  - Under *EVENTS* you can view only events based on Scheduler templates. These are displayed as colored rectangles: tasks that have already been completed are displayed as gray rectangles, tasks that are currently being executed as green rectangles, and future tasks as blue rectangles.

  In each of the *timeline* subtabs, the large pane on the right displays the Scheduler timeline, where you can see what tasks are scheduled.

  - The timeline has a preview pane at the bottom. The main timeline is an enlargement of the white section of the preview pane.

  - To zoom in or out, scroll in the timeline pane or drag the mouse right or left in the preview pane.

  - To zoom to a particular time, e.g. the next hour, or the past month, right-click the timeline, and select *Zoom to \[time\]*.

  - Open the *Navigation* section at the bottom for more options:

    - Click a button with a particular time to zoom to this time on the timeline, e.g. Today, Last week, Next month, etc.

    - To make the timeline move along with the current time, in the lower left corner, select *Follow mode*.

      > [!NOTE]
      > When you navigate away from the line that represents now while follow mode is enabled, follow mode will temporarily be paused. As soon as you navigate back in view of the line that represents now, follow mode will be activated again.

    - To change the time zone for the timeline pane, in the lower right corner, select a different *Time zone*.

  - To also view disabled tasks, in the *TASKS* tab, select *Include disabled tasks*.

  - To only view particular tasks on the timeline, in the *TASKS* tab, select *Show only selected tasks* and select the tasks in the list below.
