---
uid: resource_studio_app
---

# Resource Studio

The Resource Studio app is used to quickly create and manage an inventory of bookable resources, both tied to elements in your DataMiner system as well as resources not managed by DataMiner. It allows users to:

* **Create and manage various types of resources**, including network inventory, services, and other things with limited availability such as people, rooms, vehicle etc.
* **Organize resources into pools** for easier management and selection.
* **Describe capabilities** of resources or pools, helping users with resource selection for workflows and jobs.
* **Manage concurrency and capacity of resources**
* **Attach metadata to resources** to store additional information relevant to resources as properties.
* **Analyze resource utilization** metrics for resource pools, aiding in optimizing resource inventory management.

![screenshot](~/user-guide/images/mediaops_rs_overview.png)

## Resources

The Resource Studio allows to create and manage resources. A resource can be used to represent anything which' usage needs to be managed over time. This could be different things. Firstly, a resource could represent a piece of network inventory managed with a DataMiner element such as an IRD, an encoder deployed in the cloud or a port on a switch. Secondly, a resource could represent an entire service managed by DataMiner that can be made available for use, such as an uplink connection with a certain bandwidth that will be available for a certain period of time. Finally, a resource can also represent anything with limited availability that is not managed by DataMiner, such as rooms, people, vehicles, satellite transponder slots, IP addresses, ...

Resources can be created either directly from the Resource Studio, through other DataMiner apps, such as the [People & Organizations app](xref:people_organizations_overview), or by syncing with third-party asset mgmt. or CMDB systems.

## Resource Pools

A resource pool can be created to group a set of interchangeable resources. This allows users that create workflows or jobs to refer to a pool of resources, rather than a specific one, which in turn allows operators to defer the selection of a specific resource to when it is really required, rather than having to select a specific resource at job creation time already. Resources can be part of multiple pools, allowing them to be eligible for multiple purposes while keeping a single availability timeline and preventing resource conflicts.

The Resource Studio app also allows to 'link' a resource pool to other resource pools. When a resource of that pool is then added to a job, the system will automatically also add resources from its linked pools to the same job. This functionality helps users creating jobs to make sure they have all the necessary resources to carry out the job. For example, a pool of OB trucks could be linked to a pool of truck drivers so that when someone adds a truck to a job, the system will automatically also add a driver for the truck to that job. There are two possible 'resource selection types' that can be selected when adding a 'linked resource pool' to a pool:

* Automatic: when adding a resource from the pool to a job, the system will automatically pick a resource from the linked pool that is available for the entire duration of the job and add it to the job. If there are no resources in the linked pool that are available for the entire duration of the job, the system will add the linked resource pool to the job instead, leaving it up to the user to make sure there is a resource in the linked resource pool that is made available and then swapping it in to the job.
* Manual: when adding a resource from the pool to a job, the system will add the linked resource pool to the job, allowing the user to swap in a specific resource from that pool at a later point in time.

## Capabilities

Capabilities give a qualitative description or a resource or pool and what they can be used for. When creating a workflow or job, users can specify the required capabilities for resource to be used, and filter the resources in the system with these capability requirements in order to easily find a suitable one.

Capabilities consist of a name and a list of possible values. When adding a capability to a resource or pool, users can assign one or more of the possible values to that resource. Typical examples of capabilities include:

* Encoding: H.264, JPEG XS, JPEG 2K, ...
* Video Format: SD, HD, UHD
* Modulation type: DVB-S, NS3, NS4

Capabilities can be either assigned to a pool, in that case all resources in that pool will inherit the capabilities of the pool, but extra capabilities can also be added to individual resources.

## Capacities

Next to capabilities, users can also assign capacities to a resource. They are similar to capabilities in the sense that they describe what a resource can be used for but, contrary to capabilities, capacities describe a numeric quantity. Capabilities have the following settings that can be configured:

* Units: the unit in which the values for this capacity are to be expressed (MHz, Gbps, kBd, ...).
* Min range: the minimum value allowed for this capacity.
* Max range: the maximum value allowed for this capacity.
* Step size: the increment that can be used to change the capacities values
* Decimals: the number of decimals allowed for values of this capacity.

Typical examples of capacities are bandwidths, bitrates, symbol rates etc. When booking a resource, users  book only that amount of capacity on the resource. If a resource has a concurrency higher than one, other jobs can still make use of the remaining capacity on that same resource. Contrary to capabilities, capacities can not be configured on pools, only on the individual resources.

## Properties

Apart from capabilities and capacities, there is sometimes extra information that users want to attach to resource that is relevant to list, but does not influence the decision of which specific resource could be used to execute a certain job. This type of information can be stored into properties, for example a contact person, the name of the equipment vendor, a reference to its geolocation etc.

## Utilization metrics

The resource studio also provides certain utilization metrics about the pools in the system, helping people that manage the resource inventory to optimize the number of deployed resources. The following metrics are reported for pools:

* Number of resources in pool
* Average number of bookings per resource
* Average time per booking
* Total time booked in pool
* Total usage of pool
* Total calculated cost of pool (see also [Cost & Billing app](xref:cost_billing_overview))
