---
uid: MO_Resource_Studio
---

# Resource Studio

The Resource Studio app helps you create and manage bookable resources efficiently. The resources can be tied to elements in the DataMiner System (e.g. devices, network interfaces, compute resources) or external entities (e.g. people, rooms, vehicles). In the following sections, we will take a closer look at the key concepts used in this application.

![Resource Studio Overview](~/solutions/images/Resource_Studio_Overview.png)

## Resources

The Resource Studio app allows you to create and manage resources. A resource can represent anything that involves managed use over time. Examples of things a resource can represent include:

- A piece of network inventory managed by DataMiner, such as an **IRD**, a **cloud-based encoder**, or a **port on a switch**.

- An entire service managed by DataMiner that can be made available for use, such as an **uplink connection** with a certain bandwidth that will be available for a certain period of time.

- Anything with limited availability that is not managed by DataMiner, such as **rooms**, **people**, **vehicles**, **satellite transponder slots**, **IP addresses**, etc.

Each resource has a _concurrency_ setting, which defines how many bookings of the resource can be made at the same time. By default, this is set to **1**. 

## Resource Pools

A _resource pool_ can be created to group a set of **interchangeable resources**. This allows users who utilize resources in other apps to refer to a pool instead of a specific resource, which allows _deferring_ resource selection until it's actually needed, rather than at booking creation.

Resources can be added to multiple pools, making them eligible for multiple purposes while keeping a single availability timeline and preventing resource conflicts.

## Example

Say we have a set of devices that can convert signals between [SDI](https://en.wikipedia.org/wiki/Serial_digital_interface) and [IP](https://en.wikipedia.org/wiki/Internet_Protocol), SDI-to-IP being an **encoder** and IP-to-SDI converter being a **decoder**. To represent these 2 types of devices, we can create 2 matching resource pools. First open the **New** resource pool popup:

![New Resource Pool](~/solutions/images/Resource_Studio_New_Resource_Pool.png)

Next, fill in the form with appropriate names (**Encoder** and **Decoder**) for the resource pools. For now you don't have to change anything else in this form:

![New Resource Pool Form](~/solutions/images/Resource_Studio_New_Resource_Pool_Form.png)

After you **Save** both resource pools, you can see them listed in the **Resource Pools** table:

![New Resource Pool Created](~/solutions/images/Resource_Studio_New_Resource_Pools_Created.png)

Now that the resource pools are created, we can proceed with creating the resources and assigning them to the resource pools. The procedure is similar to creating resource pools, only this time we navigate to the **Resources** page.

![New Resource](~/solutions/images/Resource_Studio_New_Resource.png)

Name the resources "Video Solutions 001" and "NewTek 001", set the **Type** to `Unmanaged` and **Save** them. Also, let's assume that the first resource is just an **Encoder**, while the second one can be used either as an **Encoder** or **Decoder**, but it can act as only one of those at a time.

![New Resource Form](~/solutions/images/Resource_Studio_New_Resource_Form.png)

To make both resources available for assigninment to resource pools, open up their respective **Edit** panels and **Mark complete** both of the resources.

![Mark Complete](~/solutions/images/Resource_Studio_Resource_Mark_Complete.png)

Now that both the resources are created and available for usage, we can proceed with assigning them to the pools.

![Assign Resources](~/solutions/images/Resource_Studio_Assign_Resources.png)

In the assign resources panel, at the top of the screen you can see which resource pool you're assigning to. Below you can find all the resources, which you can also filter by their name. Once you find the resource you want to add to the pool, **select** it and click the **ADD** button on the top right.

![Assign Resources Panel](~/solutions/images/Resource_Studio_Assign_Resources_Panel.png)

> [!TIP]
> If you can't find your resource in the above panel, double check if it has been "marked complete".

You should add the "Video Solutions 001" and "NewTek 001" resources to the "Encoders" resource pool. If all went well, now you should see your resources have moved to the column on the right, which means they are  part of the resource pool. After that is done, open up the "Decoders" resource pool and add only "NewTek 001" resource to it. Now you have your resources and resource pools neatly organized and ready for use in other apps such as [Scheduling](xref:MO_Scheduling) and [Resource Studio](xref:MO_Resource_Studio).

One final step is to navigate to the **Edit** panel of both resource pools and **Mark complete** each of them. These resources and resource pools now can be assigned to jobs, as you will see in other examples in the the documentation.

![Mark Complete](~/solutions/images/Resource_Studio_Mark_Complete.png)

> [!TIP]
> You can also **Change icon** of the resource pools and make them convey more visual information when used in other apps.

## Capability Management

_Capabilities_ give a **qualitative description** of a resource or pool, making it clear what they can be used for. When creating a workflow or job, users can specify the required capabilities for the resource to be used, and they can filter the resources in the system with these capability requirements in order to easily find a suitable one.

Each capability has a name and a list of values. Users can assign one or more values to a resource or a pool. Examples of capabilities include:

- Encoding: H.264, JPEG XS, JPEG 2K, etc.

- Video Format: SD, HD, UHD

- Modulation type: DVB-S, NS3, NS4

Capabilities can be assigned either to a resource or to a resource pool. If they are assigned to a resource pool, all resources in that pool will inherit the capabilities of the pool, but extra capabilities can also be added to individual resources.

![Capabilities](~/solutions/images/Resource_Studio_Capabilities.png)

## Capacity Management

_Capacities_, like capabilities, define how a resource can be used, but they are measured **numerically**. The following settings can be configured for capabilities:

- Units: The unit for the values of this capacity (MHz, Gbps, kBd, etc.).

- Min. range: The minimum value allowed for this capacity.

- Max. range: The maximum value allowed for this capacity.

- Step size: The increment that can be used to change the capacity's values.

- Decimals: The number of decimals allowed for values of this capacity.

Typical examples of capacities are bandwidths, bit rates, symbol rates, etc. When booking a resource, users book only a specific amount of capacity on the resource. If a resource has a concurrency higher than one, other jobs can still make use of the remaining capacity on that same resource. Contrary to capabilities, capacities cannot be configured on pools, but only on individual resources.

![Capacities](~/solutions/images/Resource_Studio_Capacities.png)

## Properties

Properties store extra details that don't affect resource selection, such as contact person, vendor name, geolocation, etc.
