---
uid: MediaOps_Resource_Studio
---

# Resource Studio

The resource studio app allows you to manage and configure all resources for which resource management is required. Resources can be devices, interfaces on devices, camera's, satellites, people, ... For every resource you can define how many times it can be booked simultaneously (aka concurrency), add capabilities (for filtering purposes), add capacities (e.g. 10Gbps for interfaces) and much more. TBC WITH TEAM WHAT DO WE SAY ABOUT CREATION IN DM.

The following pages are available in the app:

- [*Resource Pools*](#resource-pools)
- [*Resources*](#resources)
- [*Capability Management*](#capability-management)
- [*Capacity Management*](#capacity-management)
- [*Properties*](#properties)
- [*Optimize*](#optimize)
- [*Sync*](#sync)
- [*About*](#about)

## Resource Pools

A resource pool is a virtual group of resources. Typically resource pools are used in workflows and jobs to indicate a resource will be needed from the pool, but the selection of the resource still need to happen. For example, the pool could be cameras that hold a camera's of which some have the capabilities (e.g. 4k vs 8k). Then you can add the cameras pool to your job and later select a camera from the pool that is still available for the given time of the job.

The following items can be configures on resource pools:

- **Name**: The logical name of the resource pool.
- **Domain**: Pools can be grouped into domains for filtering purposes.
- **Resource pool cost**: TODO CHECK WITH REINOUT WHY WE HAVE COST CARDS ON POOLS
- **Resource pool links**: When a linked resource pool is configured, a resource from the linked resource pool must also be booked (automatically or manually).
- **Icon image**: To make it easier to differentiate resource pools from each other in workflows/jobs you can [change the icon](xref:MO_RS_Changing_Icons).
- **URL**: Link that can be used to get more information on the resource pool.
- **Profile Definition Name**: The profile definition linked to the pool. The linked profile definition contains configuration parameters that can be used to define the capabilities and capacities needed.

A resource pool can be in one of the following states:

- **Draft**: In this stage the resource pool is not (yet) available to be scheduled in workflows and jobs. In this stage the pool can still be removed directly.
- **Complete**: In this stage the resource pool is considered complete and can be used to create workflows and jobs.
- **Deprecated**: TBC WITH THE TEAM WHAT THIS MEANS
- **Error**: TBC WITH THE TEAM IF IT CAN BE REMOVED

## Resources

A resource is virtual representation of something that can be booked through a job. Every resource can have capabilities and capacities, these represent what the resource can offer. What is configured on job or workflow is what is going to be used from the resource. From the moment the job goes into a tentative state all resources will be booked according to that configuration.

The following items can be configured on resources:

- **Name**: The logical name of the resource.
- **Type**: There are four types of resources. *Unmanaged* means that the resource is not linked to any object in DM (therefor unmanaged in DM). *Element* means the resource is linked to an element in DM. *Service* means the resource is linked to a service in DM. *Virtual Function* means the resource is linked to a [virtual function](xref:implementing_function_srm) in DM. The type is defined on creation of the resource and can't be changed later.
- **Concurrency**: The max number of times the resource can be booked simultaneously.
- **Icon image**: To make it easier to differentiate resources from each other in workflows/jobs you can [change the icon](xref:RS_Changing_Icons).
- **URL**: Link that can be used to get more information on the resource.
- **Profile Definition Name**: The profile definition linked to the resource. The linked profile definition contains configuration parameters that can be used to define the capabilities and capacities needed.

## Capability Management

Capabilities are used to differentiate resources with different capabilities within the same resource pool. For example, you can have a pool of camera's where some camera's have the capability to record in 8k and some 4k. You can create a capability resolutions. Define this capability on all cameras in the pool. At this stage you can already filter on the capability when selecting a resource of the pool with the filter icon. You could go one step further and add the capability to the profile definition of the resource pool. When you then add the resource pool to your job, you can configure the desired capability. This way when selecting a resource for the job it will only show the resources matching the configuration criteria.

## Capacity Management

Capacities are used to define how much a capacity resources have. Typically this is used in combination with a higher concurrency level. For example, for IP interfaces you can reuse the interface for multiple services as long as there is sufficient bandwidth. You can create a capacity bandwidth. Define this capacity on all interfaces in the pool and add the capacity to the profile definition of the resource pool. When you then add the resource pool to your job, you can configure the desired capacity. This way when selecting a resource (network interface) for the job it will only show the resources matching the configuration criteria.

## Properties

Properties can be added to extend resources with extra information. For example, when you want to add the last maintenance date of the resource you can add this as property.

## Optimize

The optimize page is designed to get the most value out of your resources. It gives you an overview of some statistics that help to identify which resources are underused or which resources might be very valuable for your organization.

## Sync

TBC WITH THE TEAM IF THIS PAGE IS STILL NEEDED

## About
