---
uid: SwarmingScheduledTasks
---

# Swarming Scheduled Tasks

Starting from DataMiner version 10.6.3/10.7.0, scheduled tasks support swarming. Therefore, scheduled tasks must be stored in a database. For more information, see [Scheduler data storage](xref:SchedulerDataStorage).

You can identify the agent that is currently hosting a scheduled task by checking the `ExecutingDmaId` property on the task. If you want the task to run on a different agent, you can swarm it to another agent in the cluster.

During the swarming process, DataMiner removes the task from the Microsoft Task Scheduler on the current hosting agent. This means the task will not be triggered while swarming is in progress. Once the task has been swarmed, the task will be recreated on the new hosting agent and  will execute again at its next scheduled run time.

For more detailed information on how to configure this, see [Configuring a script to swarm scheduled tasks](xref:SwarmingScriptScheduledTasks).
