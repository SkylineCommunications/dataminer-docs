---
uid: MO_Resource_Studio
---

# Resource Studio

The Resource Studio app serves as a comprehensive platform for creating and managing resource utilization. Its key features include the ability to create diverse resources, ranging from network inventory to services and other limited-availability items such as rooms, people, vehicles etc. Users can organize these resources into pools, simplifying workflow and job resource selection. Capabilities and capacities can be assigned to resources, facilitating precise resource allocation based on specific job requirements. Users can also store supplementary information as properties, enhancing the resource management process. Utilization metrics provided by the app offer valuable insights, enabling users to optimize resource deployment and maximize operational efficiency.

![Resource Studio Overview](~/solutions/images/Resource_Studio_Overview.png)

> [!TIP]
> Do you prefer visual learning? Take a look at the [demo video](https://www.youtube.com/watch?v=NM4NFFCM7k8) about this app.

## App overview

The following pages are available in the app:

- ![Resource Pools](~/solutions/images/Resource_Studio_Resource_Pools.png) **Resource Pools**: Allows you to **create**, **edit**, **delete**, **search**, and **filter** [resource pools](#resource-pools). You can also **assign** [resources](#resources) to resource pools, and edit [**capabilities**](#capabilities), [**capacities**](#capacities), and [**properties**](#properties) for each resource pool.

- ![Resources](~/solutions/images/Resource_Studio_Resources.png) **Resources**: Allows you to **create** and **manage** specific [resources](#resources), and configure their **capabilities**, **capacities**, and **properties**.

- ![Capability Management](~/solutions/images/Resource_Studio_Capability_Management_icon.png) **Capability Management**: Here you can **create** and **manage** [capabilities](#capabilities), and assign the possible values they can have when associated with resources and resource pools.

- ![Capacity Management](~/solutions/images/Resource_Studio_Capacity_Management.png) **Capacity Management**: Here you can **create** and **manage** [capacities](#capacities).

- ![Configuration Management](~/solutions/images/Resource_Studio_Configuration_Management.png) **Configuration Management**: If a resource pool has **parameters** that can be defined per job in the Scheduling app, you can add those types of parameters here. You can give the configurations default values or make it mandatory to configure them upon job creation.

- ![Properties](~/solutions/images/Resource_Studio_Properties.png) **Properties**: Allows you to manage [properties](#properties) that can be used by resources and resource pools.

- ![Sync](~/solutions/images/Resource_Studio_Sync.png) **Sync**: Allows you to sync the resources from DataMiner Cube with the resource representations used in MediaOps. If you choose to sync them, before any changes are made, you will get a message specifying each change that will take place. After the sync, MediaOps resources will be updated to mirror the DataMiner resources.

- ![About](~/solutions/images/Resource_Studio_About.png) **About**: Provides information on the **version** of the MediaOps package.

<!-- TODO: Add more subpages below this page explaining how to use the different features of this app. Links to those pages with more extensive info should then be added here. At present, the info for this app is too high-level, and a lot is missing, e.g. how to import resource pools, how to configure concurrency, how to manage capabilities & capacities, what is configuration management all about and how does it work, etc. -->

## Resources

The Resource Studio app allows you to create and manage resources. A resource can represent anything that involves managed use over time. Some examples of things a resource can represent include:

- A piece of network inventory managed by DataMiner, such as an **IRD**, a **cloud-based encoder**, or a **port on a switch**.

- An entire service managed by DataMiner that can be made available for use, such as an **uplink connection** with a certain bandwidth that will be available for a certain period of time.

- Anything with limited availability that is not managed by DataMiner, such as **rooms**, **people**, **vehicles**, **satellite transponder slots**, **IP addresses**, etc.

Each resource has a **concurrency** setting, which defines how many bookings of the resource can be made at the same time. By default, this is set to 1.

## Resource pools

A resource pool can be created to group a set of **interchangeable resources**. This allows users who utilize resources in other apps to refer to a pool instead of a specific resource. This makes it possible to **defer resource selection** until the resource is actually needed, instead of assigning a specific resource at booking creation.

Resources can be added to multiple pools, making them eligible for multiple purposes while keeping a single availability timeline and preventing resource conflicts.

The resource pools displayed in the app include [teams that have been made bookable](xref:PO_Managing_Teams#making-a-team-bookable) in the People & Organizations app. These resource pools cannot be edited directly in the Resource Studio app.

> [!TIP]
> For a detailed example of how you can add resource pools and resources, refer to the tutorial [Configuring resources and resource pools](xref:Tutorial_MediaOps_Resource_Studio_Intro).

## Capabilities

Capabilities give a **qualitative description** of a resource or pool, making it clear what it can be used for.

![Capabilities](~/solutions/images/Resource_Studio_Capabilities.png)

Each capability has a name and a list of values. Users can assign one or more values to a resource or a pool. Examples of capabilities include:

- Encoding: H.264, JPEG XS, JPEG 2K, etc.

- Video Format: SD, HD, UHD

- Modulation type: DVB-S, NS3, NS4

Capabilities can be assigned either to a resource or to a resource pool. If they are assigned to a resource pool, all resources in that pool will inherit the capabilities of the pool, but extra capabilities can also be added to individual resources.

When creating a [workflow](xref:MO_Workflow_Designer#workflows) or a [job](xref:MO_Scheduling#jobs), users can specify the required capabilities of the resources to be used in the workflow or job. This will limit the resources available for picking only to those which satisfy the capability requirements, making it easier to find the suitable ones.

For example, *Location* can be an important capability when planning operations where resources need to be on-site. You can assign locations to all your resources beforehand, and then upon job creation you can choose the location your resources need to have. Then, when the resources are picked, only the ones on the actual location will be available for selection. Capabilities offer a very flexible and general way of solving this problem for a wide array of cases.

> [!TIP]
> For a hands-on example of assigning capabilities to resources and resource pools, follow the tutorial [Assigning capabilities to resources](xref:Tutorial_MediaOps_Resource_Studio_Capabilities_and_Capacities). For an example of using these capabilities when creating jobs, follow the [Scheduling a job using a resource pool with specific capabilities](xref:Tutorial_MediaOps_Scheduling_Configurations).

## Capacities

Capacities, like capabilities, define how a resource can be used, but they are measured **numerically**. The following settings can be configured for capacities:

- Units: The unit for the values of this capacity (MHz, Gbps, kBd, etc.).

- Min. range: The minimum value allowed for this capacity.

- Max. range: The maximum value allowed for this capacity.

- Step size: The increment that can be used to change the capacity's values.

- Decimals: The number of decimals allowed for values of this capacity.

Typical examples of capacities are bandwidths, bit rates, symbol rates, etc. When booking a resource, users book only a specific amount of capacity on the resource. If a resource has a concurrency higher than one, other jobs can still make use of the remaining capacity on that same resource.

Contrary to capabilities, capacities **cannot be configured on resource pools**, but only on individual resources.

However, similar to capabilities, capacities can also be used when creating jobs and workflows. You can specify capabilities on your resources, and then limit the resources available for picking in jobs and workflows based on those constraints.

![Capacities](~/solutions/images/Resource_Studio_Capacities.png)

## Properties

Properties store extra details that do not affect resource selection.

Some examples of properties include data such as:

- Contact person

- Vendor name

- Geolocation
