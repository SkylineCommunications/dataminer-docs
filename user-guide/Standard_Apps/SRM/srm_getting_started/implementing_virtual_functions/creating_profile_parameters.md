---
uid: creating_profile_parameters
---

# Creating profile parameters

To manage the service flow, SRM will need to orchestrate one or multiple virtual function resources, either ad hoc (with Resource Automation), or at the start and end of a booking (with Resource Orchestration or Service Orchestration). Configurations will need to be applied at the start and stop of each booking, and for this purpose, you will need to add [profile parameters](xref:srm_definitions#profile-parameter).

First, **for each virtual function** that you want to create, **identify the various configuration parameters** that will need to be orchestrated. Then make sure there is **a profile parameter for each of these parameters**. You can add these in the [Profiles module](xref:Configuring_profile_parameters).

For example, in DataMiner 10.2.0:

![Profile parameters in Cube](~/user-guide/images/ProfileParametersExample.png)

Secondly, it is also important to identify **capacity and capability parameters**. A specific parameter could be a capacity limitation or could be a specific capability provided by a function resource. For each identified capability and capacity, make sure there is a profile parameter in the [Profiles module](xref:Configuring_profile_parameters). The capacity or capability checkbox must be selected for these parameters.

For example, to make sure it will be possible to configure the interfaces of virtual function resources, you will need to create the ResourceInputInterfaces and ResourceOutputInterfaces capabilities (see [Provisioning virtual function resources](xref:provisioning_VFRs)).

When all profile parameters have been created, these can be used in profile definitions to orchestrate and filter out the virtual function resources.

> [!NOTE]
>
> - Instead of creating the same profile parameter multiple times, it is better to reuse profile parameters in multiple profile definitions and virtual functions.
> - It is possible to add more profile parameters later, to reflect changes in your system.
