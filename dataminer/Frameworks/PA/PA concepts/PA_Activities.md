---
uid: PA_Activities
---

# Activities

A process is a collection of granular activities interconnected with each other to support a main objective. Each activity is responsible for performing a specific task and is not aware of the other activities that are part of the process.

However, the different activities can exchange data using a DataMiner Object Model (DOM) instance named “process DOM instance”, which functions as a container of data that the various activities within a process can retrieve or update.

## Supported activities

Process Automation supports the following types of activities:

- **Script tasks**: A script task is an Automation script with a specific signature. It can be used to perform any custom action. The custom logic is fully part of the script and can interface with any DataMiner feature/object. See [Creating script tasks](xref:PA_Creating_script_tasks).

- **User tasks**: A user task is an activity that will wait for a user action before completing the task. This way, the token attached to that task can be completed and the next token can be generated. Typically, a user task app will be made available in the *Low-Code Apps* module so that the end user can access these user tasks and complete them. See [Creating user tasks](xref:PA_Creating_user_tasks).

- **Resource tasks**: A resource task is a combination of a C# Automation script and a function resource. It includes resource management, which ensures that the same resource will not be used by different processes at the same time. See [Creating resource tasks](xref:PA_Creating_resource_tasks).

> [!IMPORTANT]
> In case resource management is not required, we **strongly recommend that you use script tasks instead of resource tasks**, as the overhead to create resource tasks is high.

> [!NOTE]
> An activity, after performing a task, can only generate one single task (token) for the next activity.

## Examples of activities

- Send Email

- Create Booking

- Read File

- Watch Folder

- Ping IP

- Scan IP Range
