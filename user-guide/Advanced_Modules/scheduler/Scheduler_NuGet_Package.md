---
uid: Scheduler_NuGet_Package
---

# Using the Scheduler NuGet package

The Scheduler NuGet package provides useful functionalities to interact with the Scheduler module using Automation scripts, allowing the creation, updating, and deletion of scheduled tasks.

## Installing the Scheduler NuGet package

You can install the Scheduler package using the NuGet Package Manager:

```
PM>  Install-Package Skyline.DataMiner.Core.Scheduler.Automation 
```

## Using the Skyline.DataMiner.Core.Scheduler.Automation library

To use the library, first initialize the `Scheduler` class by passing a filter determining which scheduled tasks should be retrieved when the class is initialized:

```csharp
var scheduler = new Scheduler(task => task != null);
```

In the case presented below, all the tasks available in the DMS will be retrieved.

Now you can call methods to get and delete scheduled tasks according to a given filter:

```csharp
IEnumerable<Skyline.DataMiner.Net.Messages.SchedulerTask> tasksToGet = scheduler.GetSchedulerTasksByFilter(task => task.TaskName == "Task Name");

scheduler.DeleteSchedulerTasksByFilter(taskToDelete => taskToDelete.TaskName == "Task Name");
```

To create a scheduled task, you first need to **define the intended recurrence** for the task.

- For a task that should be **executed only once**, use the following constructor:

  ```csharp
  var scheduleOnce = new ScheduleOnce(createSchedulerEvent: true);
  ```

  > [!NOTE]
  > If the *createScheduleEvent* flag is set to true, [an event](xref:Scheduling_an_event_based_on_a_Scheduler_template) will be created.

- For a task that should be **executed on a daily basis**, follow the example below:

  ```csharp
  var now = DateTime.Now;
  var repeats = 20;
  var repetitionIntervalInMinutes = 30;
  var startDate = now.AddDays(1);
  var endDate = now.AddDays(2);
  var scheduleDaily = new ScheduleDaily(startDate, repeats, repetitionIntervalInMinutes, endDate);
  ```

  With this example, a daily task will run from tomorrow until the day after tomorrow, getting repeated every 30 minutes until it has been executed at most 20 times before the task ends.

- For a task that should be **executed weekly**, follow the example below:

  ```csharp
  var now = DateTime.Now;
  var repeats = 20;
  var repetitionIntervalInMinutes = 30;
  var endDate = now.AddDays(10);
  var weekDaysToRepeat = new List<WeekDays> { WeekDays.Saturday, WeekDays.Friday };
  var scheduleWeekly = new ScheduleWeekly(now, weekDaysToRepeat, repeats, repetitionIntervalInMinutes, endDate);
  ```

  With this example, a weekly task will run every 30 minutes, on Saturdays and Fridays, for the next 10 days until it has been executed at most 20 times before the task ends.

- For a task that is intended to be **executed monthly**, follow the example below:

  ```csharp
  var now = DateTime.Now;
  var repeats = 400;
  var repetitionIntervalInMinutes = 100;
  var endDate = now.AddYears(1);
  var monthsToRepeat = new List<Months> { Months.February, Months.August };
  var daysInMonthToRepeat = new List<int> { 1, 2, 15, 16 };
  var scheduleMonthly = new ScheduleMonthly(now, monthsToRepeat, daysInMonthToRepeat, repeats, repetitionIntervalInMinutes, endDate);
  ```
  
  With this example, a monthly task will run every 100 minutes for the next year, in February and August, on the 1st, 2nd, 15th and 16th days of the referred months, until it has been executed at most 400 times before the task ends.

Once you have defined the recurrence, you can **create the scheduled task**:

```csharp
var startRunTime = DateTime.Now;
var endRunTime = startRunTime.AddHours(2);

var schedulerTask = new SchedulerTask("Name", "Description", startRunTime, endRunTime, scheduleRepetition);
```

Assuming that it is 1 PM in this example, the task will be scheduled to run from 1 PM until 3 PM, being repeated according to the selected schedule repetition.

With the task already defined, it is time to configure the **schedule action**. Currently, this library only supports Automation script actions, which can be defined as follows:

 ```csharp
var inputScriptParams = new List<AutomationScriptInputParameter>
{
  new AutomationScriptInputParameter("InputScriptParam1", "InputValue1"),
  new AutomationScriptInputParameter("InputScriptParam2", "InputValue2"),
};

var automationScriptAction = new AutomationScriptAction("Script Name", inputScriptParams, checkSets: true, runAsync: false);

schedulerTask.ISchedulerAction = automationScriptAction;
schedulerTask.ISchedulerFinalAction = automationScriptAction;
```

This action will cause an Automation script (*runAsync* flag) named *Script Name* to be executed asynchronously. It will receive the *InputScriptParam1* and *InputScriptParam2* arguments by verifying whether a read parameter will be checked for a new value after a set command, using the optional *checkSets* flag.

Note that it is possible to define a **final action** that will be executed when the Scheduler task is removed. In the presented case, the same Automation script action will be executed.

Finally, when the task is fully ready, it can be **created or updated at DataMiner Scheduler module level** using the following method:

 ```csharp
scheduler.CreateOrUpdateSchedulerTask(schedulerTask);
```

You can create or update **multiple tasks** at the same time, making it possible to define an optional flag to indicate whether to send changes in bulk:

 ```csharp
var schedulerTasks = new List<SchedulerTask>
{
  schedulerTask1,
  schedulerTask2,
  schedulerTask3,
};

scheduler.CreateOrUpdateSchedulerTasks(schedulerTasks, sendInBulk: true);
```

## API Reference

### Scheduler Class

Initializes a new instance of the `Scheduler` class by retrieving the Scheduler tasks according to the given selector.

 ```csharp
public Scheduler(Func<Net.Messages.SchedulerTask, bool> selector = null)` 
```

#### Parameters

`selector`: Selector that will be applied to the retrieved Scheduler tasks. If left null, no Scheduler Tasks are retrieved.

#### Properties

`SchedulerTasks`: Gets the current tasks in the DataMiner Scheduler.

#### Methods

 ```csharp
public void CreateOrUpdateSchedulerTask(SchedulerTask task) 
```

Creates or updates a single Scheduler task.

##### Parameters

`task`: The SchedulerTask object to create/update.

##### Exceptions

- `ArgumentNullException`: Thrown when task is null.

- `SaveSchedulerTasks`: Saves the Scheduler tasks after creating/updating.

 ```csharp
public void CreateOrUpdateSchedulerTasks(IEnumerable<SchedulerTask> schedulerTasks, bool sendInBulk = false) 
```

 Creates or updates a collection of Scheduler tasks.

##### Parameters

- `schedulerTasks`: The collection of SchedulerTask objects to create/update.

- `sendInBulk`: A flag indicating whether to send changes in bulk. Optional, defaults to false.

##### Exceptions

- `ArgumentNullException`: Thrown when schedulerTasks is null.

- `GetSchedulerTasksByFilter`: Retrieves a collection of SchedulerTask objects based on a filter specified by the selector Func parameter.

 ```csharp
public IEnumerable<Net.Messages.SchedulerTask> GetSchedulerTasksByFilter(Func<Net.Messages.SchedulerTask, bool> selector)
```

##### Parameters

- `selector`: The function used to filter the SchedulerTask objects to return.

##### Returns

- A collection of SchedulerTask objects that match the given filter.

##### Exceptions

- `InvalidOperationException`: Thrown when the GetSchedulerTasksResponseMessage is null.

- `DeleteSchedulerTasksByFilter`: Deletes scheduler tasks based on the provided filter.

 ```csharp
public void DeleteSchedulerTasksByFilter(Func<Net.Messages.SchedulerTask, bool> selector) 
```

##### Parameters

- `selector`: Filter function used to select tasks for deletion.

##### Exceptions

- `ArgumentNullException`: Thrown when the selector parameter is null.
