---
uid: MO_Resource_Studio
---

# Resource Studio

The Resource Studio app is used to quickly create and manage an inventory of bookable resources. This includes both resources tied to elements in the DataMiner System and resources that are not managed by DataMiner.

ADD IMAGE
TBC WITH TEAM WHAT DO WE SAY ABOUT CREATION IN DM. --> not allowed in Cube

## Resources

The Resource Studio app allows you to create and manage resources. A resource can be used to represent anything for which usage needs to be managed over time. This could be different things:

- A resource could represent a piece of network inventory managed with a DataMiner element such as an IRD, an encoder deployed in the cloud, or a port on a switch.

- A resource could represent an entire service managed by DataMiner that can be made available for use, such as an uplink connection with a certain bandwidth that will be available for a certain period of time.

- A resource could also represent anything with limited availability that is not managed by DataMiner, such as rooms, people, vehicles, satellite transponder slots, IP addresses, etc.

The following items can be configured on resources:

- **Name**: The logical name of the resource.
- **Type**: There are four types of resources. *Unmanaged* means that the resource is not linked to any object in DM (therefor unmanaged in DM). *Element* means the resource is linked to an element in DM. *Service* means the resource is linked to a service in DM. *Virtual Function* means the resource is linked to a [virtual function](xref:implementing_function_srm) in DM. The type is defined on creation of the resource and can't be changed later.
- **Concurrency**: The max number of times the resource can be booked simultaneously.
- **Icon image**: To make it easier to differentiate resources from each other in workflows/jobs you can [change the icon](xref:RS_Changing_Icons).
- **URL**: Link that can be used to get more information on the resource.
- **Profile Definition Name**: The profile definition linked to the resource. The linked profile definition contains configuration parameters that can be used to define the capabilities and capacities needed.

## Resource Pools

A resource pool can be created to group a set of interchangeable resources. This allows users who create workflows or jobs to refer to a pool of resources rather than a specific one. This in turn makes it possible to defer the selection of a specific resource to when it is really required, so that it is not necessary to select a specific resource at job creation time already. Resources can be added to multiple pools, making them eligible for multiple purposes while keeping a single availability timeline and preventing resource conflicts.

The following items can be configures on resource pools:

- **Name**: The logical name of the resource pool.
- **Domain**: Pools can be grouped into domains for filtering purposes.
- **Resource pool cost**: TODO CHECK WITH REINOUT WHY WE HAVE COST CARDS ON POOLS => CAN BE DELETED
- **Resource pool links**: When a linked resource pool is configured, a resource from the linked resource pool must also be booked (automatically or manually).
- **Icon image**: To make it easier to differentiate resource pools from each other in workflows/jobs you can [change the icon](xref:MO_RS_Changing_Icons).
- **URL**: Link that can be used to get more information on the resource pool.
- **Profile Definition Name**: The profile definition linked to the pool. The linked profile definition contains configuration parameters that can be used to define the capabilities and capacities needed.

A resource pool can be in one of the following states:

- **Draft**: In this stage the resource pool is not (yet) available to be scheduled in workflows and jobs. In this stage the pool can still be removed directly.
- **Complete**: In this stage the resource pool is considered complete and can be used to create workflows and jobs.
- **Deprecated**: TBC WITH THE TEAM WHAT THIS MEANS => KEEP CURRENT BEHAVIOR
- **Error**: TBC WITH THE TEAM IF IT CAN BE REMOVED

## Capability Management

Capabilities give a qualitative description of a resource or pool, making it clear what they can be used for. When creating a workflow or job, users can specify the required capabilities for the resource to be used, and they can filter the resources in the system with these capability requirements in order to easily find a suitable one.

Capabilities consist of a name and a list of possible values. When adding a capability to a resource or pool, users can assign one or more of the possible values to that resource. Typical examples of capabilities include:

- Encoding: H.264, JPEG XS, JPEG 2K, etc.

- Video Format: SD, HD, UHD

- Modulation type: DVB-S, NS3, NS4

Capabilities can be assigned either to a resource or to a pool. If they are assigned to a pool, all resources in that pool will inherit the capabilities of the pool, but extra capabilities can also be added to individual resources.


## Capacity Management

Aside from capabilities, users can also assign capacities to a resource. They are similar to capabilities in the sense that they describe what a resource can be used for but, contrary to capabilities, they describe a numeric quantity. The following settings can be configured for capabilities:

- Units: The unit for the values of this capacity (MHz, Gbps, kBd, etc.).

- Min. range: The minimum value allowed for this capacity.

- Max. range: The maximum value allowed for this capacity.

- Step size: The increment that can be used to change the capacity's values.

- Decimals: The number of decimals allowed for values of this capacity.

Typical examples of capacities are bandwidths, bit rates, symbol rates, etc. When booking a resource, users book only a specific amount of capacity on the resource. If a resource has a concurrency higher than one, other jobs can still make use of the remaining capacity on that same resource. Contrary to capabilities, capacities cannot be configured on pools, but only on individual resources.

## Properties

Apart from capabilities and capacities, there is sometimes extra information that is relevant to list but that does not influence the decision as to which specific resource can be used to execute a job. This type of information can be stored in properties. This could for example be a contact person, the name of the equipment vendor, a reference to its geolocation, etc.

## Optimize

The optimize page is designed to get the most value out of your resources. It gives you an overview of some statistics that help to identify which resources are underused or which resources might be very valuable for your organization.

## Sync

TBC WITH THE TEAM IF THIS PAGE IS STILL NEEDED => WILL BE KEPT

## About


## OBSOLETE?

The following pages are available in the app:

- [*Resource Pools*](#resource-pools)
- [*Resources*](#resources)
- [*Capability Management*](#capability-management)
- [*Capacity Management*](#capacity-management)
- [*Properties*](#properties)
- [*Optimize*](#optimize)
- [*Sync*](#sync)
- [*About*](#about)