---
uid: Service_Orch_configuring_resource_and_pools
---

# Configuring resources and resource pools

In the [Resources](xref:The_Resources_module) module, you can define resources and group them into resource pools.

Typically, virtual function resources are generated based on a *functions.xml* file. However, for very specific use cases, the SRM Framework also supports the use of resources that are added manually and not based on a *functions.xml* file.

Resources can be extended with metadata:

- **Properties**
- **Concurrency**, which defines how many concurrent bookings can make use of a resource.
- **Capacities**, which define the capacity of the resource to perform specific tasks (e.g. "total bit rate" for an interface resource). Each booking making use of a resource will use part of its capacity.
- **Capabilities**, which define what a resource is capable of doing (e.g. modulations supported by a demodulator).

## Mandatory configuration

To make sure resources can be selected for a booking, resource capabilities and resource pools must be configured as detailed below.

### Resource capability configuration

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

### Resource pool configuration

To make sure users can select a resource from a resource pool at booking time, the pool names must be configured in one of the following ways:

- Name consisting of two strings separated by a period, the first string being the virtual platform name, and the second the function name. For example: *SatelliteDownlink.Demodulating*.

- Custom string. In this case, the service definition will need to reference that pool: on the relevant node of the service definition, a *Resource Pool* property must be defined, and its value must be set to the name of the pool.

> [!TIP]
> See also: [Configuring pools of resources](xref:Configuring_pools_of_resources)

## Resource filtering configuration

In the Booking Wizard, the candidate resources for a node in the service definition are filtered based on the capacities and capabilities of the profile instance selected for that node.

### Setting up resource filtering

1. In the Profiles module, make sure the necessary capability and capacity parameters are defined and added to the profile definition you want to use for a specific node. See [The Profiles module](xref:The_Profiles_module).

<!-- May need more details - to be added in profile instances section later? -->

1. In the Services module, assign the profile definition to the node:

   1. Go to the *definitions* tab of the module.

   1. Select the service definition in the list on the left.

   1. Select the node in the diagram pane.

   1. Below the diagram pane, in the *parameters* tab, select the profile definition in the *Profile* box.

   1. Click *Save all changes*.

1. In the Resources module, add the necessary capacities and capabilities to your resources:

   1. Select a resource pool and then select a resource in the pool.

   1. Click *Add capability* or *Add capacity* and select the capability or capacity.

   1. Configure the possible values for the capability or capacity.

   1. Click *Save*.

### Supported capabilities and capacities

- **Capability of type string**: Supported from SRM 1.2.2 onwards (RN 25446). In this case, the resource is associated with a fixed string. A resource will be considered a valid candidate resource for a booking if the capability defined in the profile instance has the same value as defined on the resource.

  Capabilities of type string with **time dependency** are also supported. In this case, the resource is dynamically associated with a fixed string determined by the booking making use of it. When you configure the resource in the Resources module, instead of specifying a capability value, select *Use time-dependent*. It will then only be possible to use the resource in multiple overlapping booking if they share the same purpose.

  For example, a steerable antenna can have a "Satellite" time-dependent capability indicating the satellite it is receiving. When an antenna is provisioned with this time-dependent capability, and it is booked in the future to receive a specific satellite, it will only be possible to book that same antenna for an overlapping booking when that overlapping booking uses it to receive the same satellite.

<!-- It is not possible to select "String" as a type when configuring the details of a profile parameter. Is this configured elsewhere? Or does this correspond with the type "Text"? -->

- **Capability of type discrete**: The resource is associated with a list of items, i.e. the discrete values of the capability. A resource is considered a valid candidate resource when the capability value defined in the profile instance is one of the selected values of this capability for this resource.

- **Capability of type number**: The resource is associated with a numeric range. A resource is considered a valid candidate if the capability value defined in the profile instance is within the range configured for this capability for this resource.

- **Capacity of type number**: The resource is associated with a specific quantity, indicated by a number. Each booking will consume a part of that quantity defined in the selected profile instance (e.g. bit rate). The resource will be a valid candidate resource if there is enough capacity left for the entire booking duration when all other overlapping bookings making use of the resource are taken into account.

## Resource sorting configuration

When candidate resources are presented in the Booking Wizard, these can be sorted in different ways.

- **Based on priority**: To have them sorted based on priority, in the Resources module, add a *Priority* property to each resource in a pool. The lower the value you specify for this property, the higher in the sort order it will be displayed.

- **Alphabetically**: If priority is not specified, resources can be sorted alphabetically, if the *Alphabetically* option is selected for the *Resources Ordering Rule* setting on the *Config* > *Wizard* tab of the Booking Manager.

- **Capacity**: If priority is not specified, resources can be sorted based on capacity, if the [Resource Sorting Capacity](xref:SRM_properties_Booking_Manager:resource-sorting-capacity) property is configured in the service definition and the *Capacity* option is selected for the *Resources Ordering Rule* setting on the *Config* > *Wizard* tab of the Booking Manager.

- **Randomly**: If priority is not specified, resources can be sorted randomly, if the *Randomly* option is selected for the *Resources Ordering Rule* setting on the *Config* > *Wizard* tab of the Booking Manager.
