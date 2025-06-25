---
uid: Stack_Orchestration
---

# Orchestration

***Maximize efficiency with powerful automation and orchestration.***

**DataMiner Service and Resource Management (SRM)** empowers ICT media and broadband teams with a versatile toolset tailored to their orchestration and automation needs. We all know there are no one-size-fits-all automation and orchestration solutions, so with DataMiner, DevOps engineers can cherry-pick the right tool for the right job, creating value in the fastest possible manner.

DataMiner supports **four different use cases** that can flexibly be combined within or across workflows:

- [Resource Scheduling](xref:srm_resource_scheduling): Keeping track of all resource schedules without automating actions, for maximum flexibility.
- [Resource Automation](xref:srm_resource_automation): Intelligent resource configuration with a click of a button.
- [Resource Orchestration](xref:srm_resource_orchestration): The power of Resource Scheduling combined with automatic configuration actions at the start and end time of bookings.
- [Service Orchestration](xref:srm_service_orchestration): Orchestration of the complete life cycle of services.

Each of the four DataMiner SRM use cases described above relies on a **combination** of different DataMiner modules, such as the **orchestration and automation stack functions**, elaborated below.

## Function Virtualization

**Replacement of network appliance hardware with virtual machines or containers.**

With DataMiner Virtual Functions, the elementary functional capabilities of a complex product are exposed as individual, elementary resources that can be monitored, configured, and used in DataMiner SRM very easily.

> [!TIP]
> For more information:
>
> - [Virtualization Engine](xref:srm_stack#virtualization-engine)
> - [SRM use cases](xref:srm_use_cases)
> - Various SRM-related videos are available in our [video collection](https://www.youtube.com/@SkylineCommu/search?query=SRM) ![Video](~/user-guide/images/video_Duo.png)
> - Various SRM use cases with screenshots are available in the [use case library](https://community.dataminer.services/use-cases/?_sf_s=SRM)
> - [Free DataMiner Orchestration and Automation training](https://community.dataminer.services/learning/courses/orchestration-automation/)

## Scheduler

**Manage a list of scheduled tasks in an automated way.**

The Scheduling Engine is the beating heart of DataMiner. It executes scheduled actions precisely, reliably, and on time. The engine can trigger a variety of DataMiner actions, including any and all Automation script executions needed by DataMiner SRM.

DataMiner Scheduler provides a wealth of features and capabilities, including but not limited to:

- Wizard for easy creation of schedules.
- Execution at a single specific point in time.
- Execution of an event at repeated user-defined points in time (e.g. daily, weekly, etc.) or multiple times with a user-defined time interval at repeated time intervals (e.g. 10 times each 5 minutes every day).
- Run only at specific times of the week (e.g. only on specific days, not in the weekend, etc.) or month (e.g. not in a specific month, not on specific days of the month, etc.).
- Definition of a start and stop time, or scheduling for indefinite time.
- Execution of special tasks when executed for the last time (e.g. send a notification e-mail, run a special wrap-up script, etc.).
- Enabling and disabling schedules, without losing the configuration.
- Real-time overview of the pending schedules.
- Calendar overview of past and ongoing scripts, as well as overview of scripts that will run on specific days in the future, etc.
- Overview of last execution and next scheduled execution of each task, and the result of the last execution (failed or succeeded).
- Ability to duplicate existing schedules, allowing easy configuration of multiple similar schedules.

> [!TIP]
> For more information:
>
> - [Scheduling Engine](xref:srm_stack#scheduling-engine)
> - [SRM use cases](xref:srm_use_cases)
> - Demo video: [How To Schedule your Resources using SRM](https://www.youtube.com/watch?v=BNK0RhlxwEc) ![Video](~/user-guide/images/video_Duo.png)
> - Various Scheduler-related videos are available in our [video collection](https://www.youtube.com/@SkylineCommu/search?query=schedule) ![Video](~/user-guide/images/video_Duo.png)
> - Various Scheduler use cases with screenshots are available in the [use case library](https://community.dataminer.services/use-cases/?_sf_s=scheduler)
> - [Free DataMiner Orchestration and Automation training](https://community.dataminer.services/learning/courses/orchestration-automation/)

## Automation Engine

**Open-architecture, fully user-definable automation engine.**

The Automation Engine performs all automation tasks in the ecosystem. Its pronounced open architecture enables operators to easily create scripts and to customize script behavior to their specific environment whenever needed. Within the user interface, you can build intricate, nested scripts that can then be scheduled for one-off or repeated execution. They can also be linked to objects shown in Microsoft Visio drawings, so that operators can trigger them with a click of a button.

Once created, scripts can be triggered in a variety of ways, ranging from manual operator initiation to event-based, change-based, or scheduled execution. The scripts fully support user interaction, so even if tasks are automated, the operator always remains in control.

By fully automating operating and business procedures or workflows, operational expenses can be drastically reduced. Automation scripts can be used in a lot of applications such as intelligent backup and service-healing routines, guided troubleshooting for operators, automatic configuration, provisioning of services, and many more.

Combined with DataMiner's integrated [Scheduler](xref:Stack_Orchestration#scheduler),you can also link Automation scripts to scheduled tasks.

> [!TIP]
> For more information:
>
> - [The Basics of DataMiner Automation Snippets](https://www.youtube.com/watch?v=i5_FLER_-tE&ab_channel=DataMinerbySkylineCommunications) ![Video](~/user-guide/images/video_Duo.png)
> - [Automation Engine](xref:srm_stack#automation-engine)
> - [SRM use cases](xref:srm_use_cases)
> - Various Automation-related videos are available in our [video collection](https://www.youtube.com/@SkylineCommu/search?query=automation), including a 60-min. [Experts & Insights webinar](https://community.dataminer.services/video/experts-insights-dataminer-automation-engine/) ![Video](~/user-guide/images/video_Duo.png)
> - Various SRM use cases with screenshots are available in the [SRM use case library](https://community.dataminer.services/use-cases/?_sf_s=SRM)
> - [Free Orchestration and Automation training](https://community.dataminer.services/learning/courses/orchestration-automation/)
> - [The Automation module in DataMiner Cube](xref:automation)

## Apps

**Out-of-the-box solutions for specific tech domains.**

A typical example as part of the automation and orchestration stack is the Booking Manager app, a standard application that allows you to create and manage bookings using DataMiner Service & Resource Management (SRM). Other examples are the DataMiner IDP (Infrastructure Discovery and Provisioning) app and the DataMiner PTP (Precision Time Protocol) app.

> [!TIP]
> For more information:
>
> - [Booking Manager app](xref:Booking_Manager_user_interface)
> - [DataMiner frameworks](xref:DataMiner_Frameworks) in the DataMiner User Guide

## Profile Manager

Configure complex resources repeatedly and reliably.

> [!TIP]
> For more information:
>
> - [Profile Manager](xref:srm_stack#profile-manager)
> - [SRM use cases](xref:srm_use_cases)

## Resource Manager

Off-the-shelf component to streamline and standardize the management of your resources.

> [!TIP]
> For more information:
>
> - [Resource Manager](xref:srm_stack#resource-manager)
> - [SRM use cases](xref:srm_use_cases)
