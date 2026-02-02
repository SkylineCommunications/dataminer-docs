---
uid: Scheduler_UI_overview
---

# Scheduler UI overview

The Scheduler module consists of different tabs that each provide a different perspective on the task scheduled in Cube.

## List tab

In the *list* tab, all scheduled tasks are shown in a list. Next to each task, the different columns show when the task is scheduled and at what interval, the next and last time the task was run, and the result of the last time it was run.

![Scheduler](~/dataminer/images/Scheduler_list.png)<br>*Scheduler list in DataMiner 10.6.2*

In the *Last runtime result* column, the color of the entry reflects the result: red indicates that the task failed, green indicates success, and gray corresponds to a currently running task.

To quickly find a particular scheduled task, you can use the quick filter box in the top-right corner. It can be used to filter on the task name or on the content of any of the other columns.

It is possible to execute a scheduled task immediately, regardless of when it is scheduled, by selecting the task and then clicking the *Execute* button at the bottom of the card. If you do so, the task will be executed again at the time when it was originally scheduled.

## Timeline tab

The *timeline* > *tasks* tab provides an overview of all scheduled tasks, including events based on Scheduler templates. For the latter, two tasks will be displayed, a "START" and a "STOP" task. The tasks are displayed as dots on the timeline.

![Scheduler](~/dataminer/images/Scheduler_timeline_tasks.png)<br>*Scheduler timeline in DataMiner 10.6.2*

Under *timeline* > *EVENTS*, you can view only events based on Scheduler templates. These are displayed as colored rectangles: tasks that have already been completed are displayed as gray rectangles, tasks that are currently being executed as green rectangles, and future tasks as blue rectangles.

In each of the *timeline* subtabs, the large pane on the right displays the Scheduler timeline, where you can see what tasks are scheduled.

- The timeline has a preview pane at the bottom. The main timeline is an enlargement of the white section of the preview pane.

- To zoom in or out, scroll in the timeline pane or drag the mouse right or left in the preview pane.

- To zoom to a particular time, e.g. the next hour, or the past month, right-click the timeline, and select *Zoom to \[time\]*.

- Open the *Navigation* section at the bottom for more options:

  - Click a button with a particular time to zoom to this time on the timeline, e.g. Today, Last week, Next month, etc.

  - To make the timeline move along with the current time, in the lower-left corner, select *Follow mode*.

    > [!NOTE]
    > When you navigate away from the line that represents now while follow mode is enabled, follow mode will temporarily be paused. As soon as you navigate back in view of the line that represents now, follow mode will be activated again.

  - To change the time zone for the timeline pane, in the lower-right corner, select a different *Time zone*.

- To also view disabled tasks, in the *TASKS* tab, select *Include disabled tasks*.

- To only view particular tasks on the timeline, in the *TASKS* tab, select *Show only selected tasks* and select the tasks in the list below.
