---
uid: SLNetClientTest_retrieving_scheduled_task_info
keywords: swarming scheduled tasks, SchedulerTasks, swarming troubleshooting
---

# Retrieving scheduled task information

You can retrieve information about the scheduled tasks configured in a DataMiner System. This can for instance be useful to troubleshoot issues that occur when swarming a scheduled task.

To retrieve this information:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Info* menu, select *N-Z* > *SchedulerTasks*.

   This retrieves and displays all configured scheduled tasks in the system, including their execution details and the DataMiner Agent responsible for hosting or executing each task.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
