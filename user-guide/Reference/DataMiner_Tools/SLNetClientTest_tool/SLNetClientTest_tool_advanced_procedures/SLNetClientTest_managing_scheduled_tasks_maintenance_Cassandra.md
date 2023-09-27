---
uid: SLNetClientTest_managing_scheduled_tasks_maintenance_Cassandra
---

# Managing scheduled tasks for maintenance of a Cassandra database

From DataMiner 9.5.10 onwards, a set of messages are available to manage scheduled tasks for the maintenance of Cassandra databases. The messages allow you to create, update, delete and execute tasks in the Windows Task Scheduler.

To send such a message:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to the *Build Message* tab of the main window of the SLNetCLientTest tool.

1. In the *Message Type* drop-down list, select one of the following messages:

   - *GetMaintenanceTaskRequest*: Retrieves a list of the maintenance tasks for the specified DMA(s).

   - *AddMaintenanceTaskRequest*: Creates a new maintenance task or updates an existing maintenance task (when an existing GUID is passed). The response will contain the new GUID that the task received when it was created or updated.

   - *DeleteTaskRequest*: Deletes a task for the specified DMA(s). The response will indicate if the request was successful. If it was unsuccessful, the response will contain an exception detailing what went wrong.

   - *ExecuteMaintenanceTaskRequest*: Starts the execution of a scheduled maintenance task on the specified DMA(s). The response will indicate if the request was successful. If it was unsuccessful, the response will contain an exception detailing what went wrong.

1. Configure the message.

   For each of the messages, you can pass a particular DMA ID to target a specific DMA in the DMS, or you can specify -1 to target all DMAs in a DMS, without having to connect to every single one of them.

   A maintenance task has the following fields:

   - *ID*: A GUID created by the software to keep track of the tasks across clusters

   - *Name*: A string indicating the name of the task, which is used to identify the task in the Windows Task Scheduler.

   - *Tool*: A string indicating the full path to the program that needs to be executed.

   - *Arguments*: A string containing a list of optional arguments needed to run the task.

   - *Triggers*: A list of triggers that will execute the task automatically. Each trigger consists of the following fields:

     - *Slot*: A custom object containing the day of the week and the time of the next execution.

     - *Frequency*: A time span indicating the frequency at which the task needs to be run.

     Leaving the list of triggers empty will still schedule the task, but it will then only run when executed manually.

1. Click *Send Message*.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
