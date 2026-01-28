---
uid: SwarmingScheduledTasks
---

# Swarming scheduled tasks

Starting from DataMiner version 10.6.3/10.7.0<!-- RN 44620 -->, scheduled tasks support swarming. For swarming to be possible, the scheduled tasks must be stored in a database. For more information, see [Scheduler data storage](xref:SchedulerDataStorage).

You can identify the Agent that is currently hosting a scheduled task by checking the *ExecutingDmaId* property on the task. This value is displayed in the Scheduler module in Cube in the *DataMiner* column. If you want the task to run on a different Agent, you can swarm it to another Agent in the cluster.

During the swarming process, DataMiner removes the task from the Microsoft Task Scheduler on the current hosting Agent. This means the task will not be triggered while swarming is in progress. Once the task has been swarmed, the task will be recreated on the new hosting Agent, and it will be executed at its next scheduled runtime.

For more detailed information on how to configure this, see [Configuring a script to swarm scheduled tasks](xref:SwarmingScriptScheduledTask).
