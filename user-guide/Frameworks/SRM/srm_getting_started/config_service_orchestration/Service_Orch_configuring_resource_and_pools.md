---
uid: Service_Orch_configuring_resource_and_pools
---

# Configuring resources and resource pools

In the [Resources](xref:The_Resources_module) module, you can define resources and group them into resource pools.

Typically, virtual function resources are generated based on a *functions.xml* file. However, for very specific use cases, the SRM framework also supports the use of resources that are added manually and not based on a *functions.xml* file.

Resources can be extended with metadata:

- **Properties**
- **Concurrency**, which defines how many concurrent bookings can make use of a resource.
- **Capacities**, which define the capacity of the resource to perform specific tasks (e.g. "total bit rate" for an interface resource). Each booking making use of a resource will use part of its capacity.
- **Capabilities**, which define what a resource is capable of doing (e.g. modulations supported by a demodulator).

To make sure resources can be selected for a booking, resource capabilities and resource pools must be configured as detailed below.

> [!TIP]
> This section contains the mandatory minimum configuration. For information on more configuration options, see [Service Orchestration resources configuration](xref:Service_Orchestration_resources_advanced)

## Resource capability configuration

For every resource that needs to be used with Service Orchestration, two mandatory capabilities must be defined. If these are not configured for a resource, users will not be able to create bookings that make use of that resource.

1. In the Profiles module, make sure the *ResourceInputInterfaces* and *ResourceOutputInterfaces* capability parameters are correctly defined:

   - *Category*: *Capability*
   - *Type*: *Discrete*.
   - *Discrete Type*: *Text*.
   - Discrete values: Add a discrete value with the name of each supported input or output interface.

   > [!TIP]
   > See also:
   >
   > - [Creating profile parameters](xref:creating_profile_parameters)
   > - [Configuring profile parameters](xref:Configuring_profile_parameters)

1. In the Resources module, make sure these capabilities are added to each of the resources:

   1. Select the resource, click *Add capability*, and select *ResourceInputInterfaces*.

   1. In the dropdown box next to *ResourceInputInterfaces*, select the input interfaces supported by the resource.

   1. Click *Add capability* again and select *ResourceOutputInterfaces*.

   1. In the dropdown box next to *ResourceOutputInterfaces*, select the output interfaces supported by the resource.

For example, for an "Encoding" virtual function with an "ASI" input and an "IP" output, the associated virtual resource will need a *ResourceInputInterfaces* capability with value "ASI" and a *ResourceOutputInterfaces* capability with value "IP".

## Resource pool configuration

To make sure users can select a resource from a resource pool at booking time, the pool names must be configured in one of the following ways:

- Name consisting of two strings separated by a period, the first string being the virtual platform name, and the second the function name. For example: *SatelliteDownlink.Demodulating*.

- Custom string. In this case, the service definition will need to reference that pool: on the relevant node of the service definition, a *Resource Pool* property must be defined, and its value must be set to the name of the pool.

> [!TIP]
> See also: [Configuring pools of resources](xref:Configuring_pools_of_resources)
