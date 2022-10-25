---
uid: PA_Activities
---

# Activities

A process is a collection of granular activities interconnected with each other to support a main objective. Up until now, these activities did not exchange data, as each activity is responsible for performing a specific task and is not aware of the other activities that are part of the process.

A DataMiner Object Model (DOM) instance named “process DOM instance”, however, will be used as a container of data, which the various activities within a process can retrieve or update. This way, the different activities *can* exchange data.

## Supported Activities

Process Automation supports the following types of activities:

- [**Script tasks**](xref:Creating_Activities#script-tasks): A script task is an Automation script with a specific signature. It can be used to perform any custom action. The custom logic is fully part of the script and can of course interface with any DataMiner feature/object.

- [**User tasks**](xref:Creating_Activities#user-tasks): A user task is an activity that will wait for a user action before completing the task so that the token attached to that task can be completed and the next token can be generated. Typically, a User Task app will be made available so that the end user can access these User tasks and complete them.

  > [!NOTE]
  > Both script and resource tasks need to be designed in such a way that their execution does not exceed the default Automation script timeout time of 15 minutes.

<!-- Comment: User Task app? Follow up! -->

- [**Resource tasks**](xref:Creating_Activities#resource-tasks): a resource task is a combination of a C# Automation script and a function resource. It includes resource management, which ensures that the same resource will not be used by different processes at the same time.

  > [!NOTE]
  > In case resource management is not required, we strongly recommend that you use script tasks instead of resource tasks, as the overhead to create resource tasks is high.

An activity, after performing a task, can only generate one single task (token) for the next activity.

## Examples

- Send Email

- Create Booking

- Read File

- Watch Folder

- Ping IP

- Scan IP Range
