---
uid: srm_instantiations
---

# SRM instantiations

This section explains the instantiations in the SRM framework, which are actual objects created based on SRM definitions.

## Element

A DataMiner element **represents a data source** that is monitored by the DataMiner System. An element retrieves information from a data source based on what is defined in a connector. Typically, an element is linked to a single physical device or platform.

While the connector defines how to communicate with a data source and which information should be retrieved from the data source, the element using that connector actually retrieves the information. Usually, an element is created for each data source.

For example, an element could be created to represent a cloud-based server. The element will show all KPIs retrieved from that server.

> [!TIP]
> See also: [About elements](xref:About_elements)

## Virtual function resource

While a virtual function is a definition, a virtual function resource is the corresponding **actual virtual function instance exposed by the platform**. Consequently, this object is also known as a "virtual function instance". For example, a cloud-based platform could expose 4 encoding instances and 4 decoding instances. Each encoding instance is an instance of the virtual function "encoding".

Both the terms "virtual function resource" and "virtual function instance" are used in the SRM framework, but these mean exactly the same thing. In the example above, the 4 encoding virtual function instances exposed by the platform are represented as 4 different resources, each based on the same virtual function. These resources are managed by DataMiner Resource Manager.

The technique used by the SRM framework is very similar to the technique used to generate [Dynamic Virtual Elements](xref:Dynamic_virtual_elements) (DVEs). A virtual function is created based on a main element and only visualizes a selection of metrics of that main element, i.e. the metrics that are relevant for that particular virtual function. The main difference with DVEs is that the definition for virtual functions is not coded into the connector itself but defined in a separate *functions.xml* file.

As a resource represents a specific virtual function, and the virtual function links to a profile definition grouping multiple profile parameters, resources can expose **capacities and capabilities** listed in that linked profile definition. For example, if an encoding instance is only capable of providing SD encoding, when a resource with HD capability is requested, this encoding instance will not be a candidate.

By default, a virtual function resource is represented as a virtual element while the booking using that resource is active.

## Resource pool

A resource pool is a **container that groups several resources**. One resource can be part of one or more resource pools.

> [!NOTE]
> A resource can also be created manually in the [Resources module](xref:The_Resources_module) without a corresponding virtual function. As such, a resource could be any object you want to be able to schedule for use. However, note that in that case no orchestration or automation is supported in the SRM framework.

## Profile instance

A profile instance is **linked to a specific profile definition and has values assigned for each of the profile parameters listed in that profile definition**. Multiple profile instances can be created for the same profile definition, typically each with different values.

As a profile definition is a group of configuration, monitoring, capability, and capacity parameters, a profile instance linked to that profile definition will filter out resources that do not provide the capacity and/or capability defined in the instance. This way, when a booking is created, DataMiner SRM can check whether resources are available not only according to the requested timing, but also according to the required capacities and capabilities.

For example, an "Encoding HD" instance could contain the values for each of the profile parameters required to orchestrate a resource. As a capability, the instance could contain the "HD" value, so that resources that cannot provide this specific capability are filtered out during the booking creation process.

Profile instances are used in the context of Service Orchestration, Resource Automation, and Resource Orchestration.

### State profile instance

A state profile instance is a specific kind of profile instance that can be defined to make sure that a specific profile will be **applied when a booking is in the corresponding state** (e.g. "Start" or "Stop"). You can create such a profile instance in the [Profiles module](xref:The_Profiles_module) by specifying the name of the base profile and adding the suffix "_[state]" (e.g. "Encoding_Start").

## Service profile instance

Service profile instances are only used in the context of Service Orchestration.

A service profile instance is **linked to a specific service profile definition and has one or more specific profile instances assigned for each of the virtual functions** listed in the definition.

When users create a booking using a service profile, they can select a service profile definition, potentially one of the associated service definitions, and then a service profile instance. This almost fully defines all settings required to spin up a service. With this approach, users do not have to select profile instances for each virtual function in the service definition.

While using service profile instances requires more initial configuration effort, it will highly decrease the time spent to create each booking.

## Booking

The definition of a booking differs depending on the SRM use case, as detailed below.

### Service Orchestration

In the context of Service Orchestration, a booking is an **object linked to a service definition that has a specific time aspect**. For each of the virtual functions listed in the service definition, a corresponding resource is assigned and managed.

When users create a booking, they need to select the timing as well as a service definition. For the timing, it is possible that a start and a stop time are selected (e.g. in case of an occasional-use event), or that only a start time is selected (for a permanent event).

Based on the selected service definition, profile instances for each of the included virtual functions will filter out resources that do not have the requested capacities and/or capabilities. The resources selected by the user to be included in the booking will be considered "booked" for the full duration of the booking.

In summary, a booking mainly contains the following information:

- A list of **resources**.
- The **timing** (start time, stop time, pre-roll duration, post-roll duration, and any custom events)
- **Profile instances** defining settings to apply to resources.
- A **service definition** defining the different type of resources that are required.

The booking duration consists of:

- The **pre-roll** time: This is the period before the service goes on air. It ensures that there is a margin of time to configure resources and make sure everything is set up.
- The time when the **service is active**, i.e. the on-air time.
- The **post-roll** time: This is the period right after the service has stopped being on air. It ensures that there is a margin of time to tear down services and reconfigure devices to their base profile. It also provides a margin in case there is an overrun, as the resources remain booked during this time.

The following types of bookings are supported:

- **Single**: The booking has one single occurrence and is defined with start and stop timing.
- **Permanent**: The booking has one single occurrence and is defined with a **start time only**.

For each booking, a DataMiner service is automatically created that persists throughout the above-mentioned stages. Once the booking is completed, by default, the service is removed again.

Optionally, a DataMiner service can be made persistent and multiple (non-overlapping) bookings can be created for the same persistent service. In this case, users can also decide to create a custom service name, different from the booking name. This feature is only used in case the same service object should be reused for multiple bookings, for example in an MDC environment.

> [!NOTE]
> The SRM concurrency license defines the maximum number of overlapping bookings allowed in a cluster. Any regular booking will consume a credit, except for [contributing bookings](#contributing-booking) of type "Locked". <!-- RN 28659 -->

### Resources Orchestration or Resource Scheduling

A booking in the context of Resource Orchestration or Resource Scheduling is **similar to a Service Orchestration** booking, except that **no service definition is selected at booking creation time**. Users can freely add any available virtual function resource in the booking.

## Contributing booking

Contributing bookings are only used in the context of Service Orchestration.

A contributing booking is a **booking that is converted into a virtual function resource** so that it can be used in another booking. The resource representing a contributing booking is only available for the duration of the contributing booking itself.

This can be useful in the following situations:

- To limit or hide the complexity of service definitions when multiple nodes can be grouped together.
- To reuse part of the resources in several overlapping bookings.
- To use a generic high-level service definition, where the number of functions depends on the selected resources.

> [!TIP]
> See also: [Service Orchestration contributing bookings configuration](xref:Service_Orchestration_contrib_bookings)

## Virtual platform

A virtual platform **groups various components into a single domain**, such as a separate virtual platform for Satellite Downlink, Encoding, etc. This is used in DataMiner Systems that have multiple booking applications, to differentiate between the components that can be used by these separate applications:

- Virtual platforms can group **resource pools** to differentiate between resources that can be used by specific booking applications. This is intended to be used in cases where there are multiple booking applications, but these cannot share all resources. A virtual platform can be linked to one or more resource pools. In addition, as a resource can be added to multiple resource pools, it can also be added into resource pools of different virtual platforms, so that it is possible to share a resource between virtual platforms.
- A virtual platform can group **service definitions** in order to clearly indicate which types of bookings are available in a specific domain.
- A **booking application** is always linked to a specific virtual platform. As a result, only resource pools and service definitions that are linked to that specific virtual platform will be available for bookings created with that booking application.

> [!NOTE]
> Within the SRM framework, the virtual platform needs to be configured in the Booking Manager app (see [Deploying the SRM framework](xref:deploying_srm)), and in case Service Orchestration is used, in the [service definition](xref:Service_Orch_creating_service_definitions) as well as in each [resource pool](xref:Service_Orch_configuring_resource_and_pools).
