---
uid: MO_Resource_Studio
---

# Resource Studio

The Resource Studio app is used to quickly create and manage an inventory of bookable resources. This includes both resources tied to elements in the DataMiner System (for example devices, network interfaces or compute resources) and resources that are not managed by DataMiner (for example people, rooms or vehicles). The key concepts used in this application are explained below.

## Resources

The Resource Studio app allows you to create and manage resources. A resource can be used to represent anything for which usage needs to be managed over time. This could be different things:

- A resource could represent a piece of network inventory managed with a DataMiner element such as an IRD, an encoder deployed in the cloud, or a port on a switch.

- A resource could represent an entire service managed by DataMiner that can be made available for use, such as an uplink connection with a certain bandwidth that will be available for a certain period of time.

- A resource could also represent anything with limited availability that is not managed by DataMiner, such as rooms, people, vehicles, satellite transponder slots, IP addresses, etc.

Every resource needs to have a defined concurrency. The concurrency determines the amount of bookings that can be created on that resource during the same time period. By default, this is set to one. 

## Resource Pools

A resource pool can be created to group a set of interchangeable resources. This allows users who create workflows or jobs to refer to a pool of resources rather than a specific one. This in turn makes it possible to defer the selection of a specific resource to when it is really required, so that it is not necessary to select a specific resource at job creation time already. Resources can be added to multiple pools, making them eligible for multiple purposes while keeping a single availability timeline and preventing resource conflicts.

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




