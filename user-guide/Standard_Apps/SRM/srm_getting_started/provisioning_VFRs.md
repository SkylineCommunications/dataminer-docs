---
uid: provisioning_VFRs
---

# Provisioning virtual function resources

Once the necessary virtual functions are in place, you can provision the system with virtual function resources. Virtual function resources are typically added in resource pools. You can **add resource manually** (see [Configuring pools of resources](xref:Configuring_pools_of_resources)) **or using the script *SRM_DiscoverResources*** (included in the SRM framework).

While a virtual function definition could include multiple possible types of interfaces, a specific virtual function resource may not have all of these. When you have created the resource pools and added the virtual function resources, it is therefore important that you also **indicate which interfaces a virtual function resource can have**.

Finally, you will also need to **indicate which capabilities the resource will expose**. These depend on the profile definition assigned to the virtual function resource. Any parameters included in the profile definition will be also available as a capability or capacity of the resource. This logic results in a resource filter on capability and capacity when bookings are created, so that users always select a resource with the requested capabilities o capacities.

Follow the steps below:

1. Create the necessary resource pools, using the correct virtual platform and virtual function name (e.g. "VPA.Decoder").

1. Create the virtual function resources and add them to one or more resource pools.

1. Add the *ResourceInputInterfaces* capability to the resources and set its value to the name of the available input interfaces of the corresponding virtual function.

1. Add the *ResourceOutputInterfaces* capability to the resources and set its value to the name of the available output interfaces of the corresponding function.

   > [!NOTE]
   > To be able to add these capabilities, you will need to make sure the necessary capability profile parameters have been configured (see [Creating profile parameters](xref:implementing_function_srm)).

1. Assign any additional capacities or capabilities required to select the resource.

As a result of these steps, the virtual function resources have now been provisioned, including their capacity and capability configuration.
