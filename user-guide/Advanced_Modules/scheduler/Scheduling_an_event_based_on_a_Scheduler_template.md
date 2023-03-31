---
uid: Scheduling_an_event_based_on_a_Scheduler_template
---

# Scheduling an event based on a Scheduler template

Scheduled events are a combination of a START and STOP task, based on a special type of Automation script called a “Scheduler template”.

In order to be able to schedule events in the *timeline \> EVENTS* tab, a Scheduler template must first be created in DataMiner Automation. See [Creating a Scheduler template](xref:Creating_a_Scheduler_template).

Each of the events in the *EVENT* column represents an action or a sequence of actions determined in the Scheduler template script. The profiles in the *PROFILE* column, in turn, are collections of preset dummies and/or parameter values for specific events.

On the timeline, the events are represented as rectangles, with the left and right edges of the rectangle representing the START and STOP task.

## Scheduling an event

1. Drag an event or profile onto the timeline.

1. In the *Task* window, specify any dummies or parameters if necessary, and click *OK*.

1. To fine-tune the timing, drag the edges of the rectangle to a different point on the timeline. While you are dragging, the exact time will be displayed below.

   > [!NOTE]
   >
   > - The starting time of any new event must lie at least one minute in the future.
   > - It is only possible to change the timing for events that have not yet been completed. If an event has already started, you will only be able to edit the end time.

When an event has not yet started, you can right-click the event’s rectangle on the timeline, and:

- Select *Edit* to change the input dummies or parameters.

- Select *Delete* to remove the event.

### Scheduling a recurring event

Once you have scheduled an event according to the procedure above, it is possible to make this a recurring event.

To do so:

1. Go to the *list* tab.

1. Both for the START and the STOP task of the event:

   1. Select the task and click the *Edit* button.

   1. In the *schedule* tab of the *Edit* window, select the interval at which the tasks should recur.

   1. Click *OK*

   > [!NOTE]
   >
   > - Make sure both tasks recur at the same interval, e.g. both daily or both weekly, but not one daily and the other weekly.
   > - Make sure their recurrence does not make the tasks overlap.
   > - Once an event has been made recurrent, it will no longer be possible to edit the event directly in the timeline. Further editing will only be possible in the *list* tab.
