---
uid: Overview_MediaOps_Resource_Studio
---

# Resource Studio

The Resource Studio app is used to quickly create and manage an inventory of bookable resources. This includes both resources tied to elements in the DataMiner System and resources that are not managed by DataMiner.

This app allows users to:

- **Create and manage various types of resources**, including network inventory, services, and other things with limited availability such as people, rooms, vehicles, etc.

- **Organize resources into pools** for easier management and selection.

- **Describe capabilities** of resources or pools, for easier resource selection for workflows and jobs.

- **Manage concurrency and capacity of resources**.

- **Attach metadata to resources** to store additional information relevant to resources as properties.

![Resource Studio UI](~/dataminer-overview/images/resource_studio1.png)

## Resources

The Resource Studio app allows you to create and manage resources. A resource can be used to represent anything for which usage needs to be managed over time. This could be different things:

- A resource could represent a piece of network inventory managed with a DataMiner element such as an IRD, an encoder deployed in the cloud, or a port on a switch.

- A resource could represent an entire service managed by DataMiner that can be made available for use, such as an uplink connection with a certain bandwidth that will be available for a certain period of time.

- A resource could also represent anything with limited availability that is not managed by DataMiner, such as rooms, people, vehicles, satellite transponder slots, IP addresses, etc.

Resources can be created directly from the Resource Studio app, through other DataMiner apps such as the [People & Organizations](xref:Overview_MediaOps_People_and_Organization) app, or by syncing with third-party asset management or CMDB systems.

## Resource Pools

A resource pool can be created to group a set of interchangeable resources. This allows users who create workflows or jobs to refer to a pool of resources rather than a specific one. This in turn makes it possible to defer the selection of a specific resource to when it is really required, so that it is not necessary to select a specific resource at job creation time already. Resources can be added to multiple pools, making them eligible for multiple purposes while keeping a single availability timeline and preventing resource conflicts.

The Resource Studio app also allows you to "link" a resource pool to other resource pools. When a resource of that pool is then added to a job, the system will automatically also add resources from its linked pools to the same job. This functionality helps users who create jobs to make sure they have all the necessary resources to carry out the job. For example, a pool of OB trucks could be linked to a pool of truck drivers, so that when someone adds a truck to a job, the system will automatically also add a driver for the truck to that job. There are two possible resource selection types that can be selected when adding a linked resource pool to a pool:

- **Automatic**: When a resource is added from a pool to a job, the system will automatically pick a resource from the linked pool that is available for the entire duration of the job and add it to the job. If there are no resources in the linked pool that are available for the entire duration of the job, the system will add the linked resource pool to the job instead. This way, it is left up to the user to make sure a resource in the linked resource pool is made available and then swapped into the job.

- **Manual**: When a resource is added from a pool to a job, the system will add the linked resource pool to the job, allowing the user to swap in a specific resource from that pool at a later point in time.

## Capabilities

Capabilities give a qualitative description of a resource or pool, making it clear what they can be used for. When creating a workflow or job, users can specify the required capabilities for the resource to be used, and they can filter the resources in the system with these capability requirements in order to easily find a suitable one.

Capabilities consist of a name and a list of possible values. When adding a capability to a resource or pool, users can assign one or more of the possible values to that resource. Typical examples of capabilities include:

- Encoding: H.264, JPEG XS, JPEG 2K, etc.

- Video Format: SD, HD, UHD

- Modulation type: DVB-S, NS3, NS4

Capabilities can be assigned either to a resource or to a pool. If they are assigned to a pool, all resources in that pool will inherit the capabilities of the pool, but extra capabilities can also be added to individual resources.

## Capacities

Aside from capabilities, users can also assign capacities to a resource. They are similar to capabilities in the sense that they describe what a resource can be used for but, contrary to capabilities, they describe a numeric quantity. The following settings can be configured for capabilities:

- Units: The unit for the values of this capacity (MHz, Gbps, kBd, etc.).

- Min. range: The minimum value allowed for this capacity.

- Max. range: The maximum value allowed for this capacity.

- Step size: The increment that can be used to change the capacity's values.

- Decimals: The number of decimals allowed for values of this capacity.

Typical examples of capacities are bandwidths, bit rates, symbol rates, etc. When booking a resource, users book only a specific amount of capacity on the resource. If a resource has a concurrency higher than one, other jobs can still make use of the remaining capacity on that same resource. Contrary to capabilities, capacities cannot be configured on pools, but only on individual resources.

## Properties

Apart from capabilities and capacities, there is sometimes extra information that is relevant to list but that does not influence the decision as to which specific resource can be used to execute a job. This type of information can be stored in properties. This could for example be a contact person, the name of the equipment vendor, a reference to its geolocation, etc.
