---
uid: srm_use_cases
---

# SRM use cases

## Orchestration is not a one-size-fits-all solution

Each workflow has its optimal level of automation. To achieve this optimal level, you need a good balance between the amount of repetitive manual activity needed in the workflow and the development effort for creating and testing the automation.

On the one hand, workflows with an ad hoc nature, which are different every time, are typically not good candidates for extensive automation. In these cases, automation always sacrifices a bit of the flexibility of the workflow.

On the other hand, for **highly repetitive workflows** that need to be executed very frequently, **automation and orchestration is the natural approach** to reduce repeated manual actions (operational cost), increase resource planning efficiency (capex), and above all reduce human errors (QoS) and embed security policies (SecOps) in a consistent manner.

## Cherry-pick the right tools for the right job

From the DataMiner SRM stack, you can cherry-pick the right tools for the right job, at the right moment in time, so that you can **reach an optimal level of automation**. You can also can opt to increase or decrease the level of automation at any time.

Classically, SRM has typically been used to tackle the most repetitive and time-consuming workflows using "Service Orchestration". However we also support other workflows that allow more flexibility. The following uses cases are currently supported:

- [Resource Scheduling](xref:srm_resource_scheduling): Keeping track of all resource schedules without automating actions, for maximum flexibility.
- [Resource Automation](xref:srm_resource_automation): Intelligent resource configuration with a click of a button.
- [Resource Orchestration](xref:srm_resource_orchestration): The power of Resource Scheduling combined with automatic configuration actions at the start and end time of bookings.
- [Service Orchestration](xref:srm_service_orchestration): Orchestration of the complete lifecycle of services.

Each of these could be an intermediate step to reach a final objective, or they could be the final objective itself. A DataMiner System can support several use cases at the same time, separately or in some cases even combined.

![Use cases overview](~/dataminer/images/DataMiner_ServiceResourceManager-1.gif)

![Use cases as robots](~/dataminer/images/SRMSuite2020-1024x576.png)
