---
uid: Scheduler_NuGet_Package
---

# Using the Scheduler NuGet package

The Scheduler NuGet package provides useful functionalities to interact with the Scheduler module using Automation scripts. It enables the creation, updating, and deletion of scheduled tasks.

## Installing the Scheduler NuGet package

To install the Scheduler package, follow these steps:

1. Open the NuGet Package Manager Console in Visual Studio.

1. Run the following command:

   ```txt
   Install-Package Skyline.DataMiner.Core.Scheduler.Automation 
   ```

> [!NOTE]
> This package is currently available as a prerelease. When installing the package in Visual Studio via the NuGet Package Manager, make sure to select *Include prerelease*.

## Using the Skyline.DataMiner.Core.Scheduler.Automation library

To use the library, first initialize the [Scheduler](xref:Skyline.DataMiner.Core.Scheduler.Automation.Scheduler) class by passing a filter determining which scheduled tasks should be retrieved when the class is initialized:

```csharp
var scheduler = new Scheduler(task => task != null);
```

In the example above, all available tasks in the DMS will be retrieved.

Now you can call methods to get and delete scheduled tasks according to a given filter:

```csharp
IEnumerable<Skyline.DataMiner.Net.Messages.SchedulerTask> tasksToGet = scheduler.GetSchedulerTasksByFilter(task => task.TaskName == "Task Name");

scheduler.DeleteSchedulerTasksByFilter(taskToDelete => taskToDelete.TaskName == "Task Name");
```

### Defining the task recurrence

Before creating a scheduled task, you first need to **define its intended recurrence**.

- **One-off task**

  Use the following constructor for a task that should be executed only once:

  ```csharp
  var scheduleOnce = new ScheduleOnce(createSchedulerEvent: true);
  ```

  > [!NOTE]
  > If the *createScheduleEvent* flag is set to "true", [an event](xref:Scheduling_an_event_based_on_a_Scheduler_template) will be created.

- **Daily task**

  Use the following constructor for a task that should be executed on a daily basis:

  ```csharp
  var now = DateTime.Now;
  var repeats = 20;
  var repetitionIntervalInMinutes = 30;
  var startDate = now.AddDays(1);
  var endDate = now.AddDays(2);
  var scheduleDaily = new ScheduleDaily(startDate, repeats, repetitionIntervalInMinutes, endDate);
  ```

  With this example, a daily task will run from tomorrow until the day after tomorrow, repeating every 30 minutes, with a maximum of 20 executions.

- **Weekly task**

  Use the following constructor for a task that should be executed on a weekly basis:

  ```csharp
  var now = DateTime.Now;
  var repeats = 20;
  var repetitionIntervalInMinutes = 30;
  var endDate = now.AddDays(10);
  var weekDaysToRepeat = new List<WeekDays> { WeekDays.Saturday, WeekDays.Friday };
  var scheduleWeekly = new ScheduleWeekly(now, weekDaysToRepeat, repeats, repetitionIntervalInMinutes, endDate);
  ```

  With this example, a weekly task will run every 30 minutes on Saturdays and Fridays, for the next 10 days, with a maximum of 20 executions.

- **Monthly task**

  Use the following constructor for a task that should be executed on a monthly basis:

  ```csharp
  var now = DateTime.Now;
  var repeats = 400;
  var repetitionIntervalInMinutes = 100;
  var endDate = now.AddYears(1);
  var monthsToRepeat = new List<Months> { Months.February, Months.August };
  var daysInMonthToRepeat = new List<int> { 1, 2, 15, 16 };
  var scheduleMonthly = new ScheduleMonthly(now, monthsToRepeat, daysInMonthToRepeat, repeats, repetitionIntervalInMinutes, endDate);
  ```
  
  With this example, a monthly task will run every 100 minutes for the next year, on the 1st, 2nd, 15th, and 16th days of February and August, with a maximum of 400 executions.

### Creating the scheduled task

1. After [defining the recurrence](#defining-the-task-recurrence), you can **create the scheduled task**:

   ```csharp
   var startRunTime = DateTime.Now;
   var endRunTime = startRunTime.AddHours(2);

   var schedulerTask = new SchedulerTask("Name", "Description", startRunTime, endRunTime, scheduleRepetition);
   ```

   In this example, assuming it is 1 PM, the task will be scheduled to run from 1 PM to 3 PM, following the specified recurrence.

1. Once the task is defined, **configure the schedule action**. Currently, only Automation script actions are supported:

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

   This example sets an automation script (*runAsync* flag) named "Script Name" to be executed asynchronously, with two input parameters (*InputScriptParam1* and *InputScriptParam2*). The optional *checkSets* flag determines whether a read parameter will be checked for a new value after a set command.

   > [!NOTE]
   > It is possible to define a **final action** that will be executed when the Scheduler task is removed. In the presented case, the same Automation script action will be executed.

1. Finally, when the task is ready, you can **create or update it at the DataMiner Scheduler module level**:

   ```csharp
   scheduler.CreateOrUpdateSchedulerTask(schedulerTask);
   ```

   You can **create or update multiple tasks** simultaneously with the optional *sendInBulk* flag that allows you to indicate whether to send changes in bulk:

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

To initialize a new instance of the `Scheduler` class by retrieving the Scheduler tasks according to the given selector:

```csharp
public Scheduler(Func<Net.Messages.SchedulerTask, bool> selector = null)` 
```

- `selector`: A selector applied to the retrieved Scheduler tasks. If left null, no Scheduler tasks are retrieved.

- `SchedulerTasks`: Gets the current tasks in the DataMiner Scheduler.

### Methods

- To create or update a single Scheduler task:

  ```csharp
  public void CreateOrUpdateSchedulerTask(SchedulerTask task) 
  ```

  - `task`: The SchedulerTask object to create or update.

    > [!NOTE]
    > The following exceptions can be thrown:
    >
    > - `ArgumentNullException`: Thrown when `task` is null.
    > - `SaveSchedulerTasks`: Saves the Scheduler tasks after creating or updating.

- To create or update a collection of Scheduler tasks:

  ```csharp
  public void CreateOrUpdateSchedulerTasks(IEnumerable<SchedulerTask> schedulerTasks, bool sendInBulk = false) 
  ```

  - `schedulerTasks`: The collection of SchedulerTask objects to create or update.

  - `sendInBulk`: A flag indicating whether to send changes in bulk. By default, this flag is set to "false".

    > [!NOTE]
    > The following exceptions can be thrown:
    >
    > - `ArgumentNullException`: Thrown when `schedulerTasks` is null.
    > - `GetSchedulerTasksByFilter`: Retrieves a collection of SchedulerTask objects based on a filter specified by the *selector Func* parameter.

- To obtain a collection of SchedulerTask objects that match the given filter:

  ```csharp
  public IEnumerable<Net.Messages.SchedulerTask> GetSchedulerTasksByFilter(Func<Net.Messages.SchedulerTask, bool> selector)
  ```

  - `selector`: The function used to filter the SchedulerTask objects to return.

    > [!NOTE]
    > The following exceptions can be thrown:
    >
    > - `InvalidOperationException`: Thrown when `GetSchedulerTasksResponseMessage` is null.
    > - `DeleteSchedulerTasksByFilter`: Deletes Scheduler tasks based on the provided filter.
    >
    > ```csharp
    > public void DeleteSchedulerTasksByFilter(Func<Net.Messages.SchedulerTask, bool> selector) 
    > ```
    >
    > - `selector`: Filter function used to select tasks for deletion.
    >
    > The `ArgumentNullException` exception can be thrown when `selector` is null.
