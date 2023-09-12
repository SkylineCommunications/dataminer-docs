---
uid: Service_Orchestration_profile_instances
---

# Service Orchestration: profile instances configuration

## Configuring a default profile instance for a node

1. In the Services module, go to the *definitions* tab.

1. Select the service definition for which you want to configure a default profile instance.

1. In the diagram page, select the desired node.

1. In the *parameters* pane in the lower right corner, select the default profile instance in the *Profile* dropdown list.

> [!TIP]
> See also: [Using the definitions tab](xref:SRM_Services_definitions#using-the-definitions-tab)

## Configuring the profile instance assignment mode for a node

When Service Orchestration is used, a profile instance can be assigned to a node and its associated interfaces in the following ways:

- **By value**: Further updates of the profile instance will have no impact on bookings that have already been created.

- **By reference**: Further updates of the profile instance will have an impact on future bookings that make use of it. New values will be considered when orchestrating, and updated capacities/capabilities will also be taken into account.

By default, each node in a service definition is set to *By value*. During booking creation, users can select the *By reference* checkbox to change the assignment mode.

You can also make sure *By reference* is selected by default instead:

1. In the Services module, go to the *definitions* tab.

1. Select the service definition and the node.

1. In the *parameters* pane in the lower right corner, select *By reference*.

> [!TIP]
> See also: [Using the definitions tab](xref:SRM_Services_definitions#using-the-definitions-tab)

## Allowing profile instance configuration for disconnected interfaces

<!-- RN 23816 -->

If an interface is not connected to other nodes in the service definition, by default the Booking Wizard will not prompt users for profile instances related to that interface. However, you can change this behavior for specific interfaces:

1. In the Services module, go to the *definitions* tab.

1. Select the service definition and the interface.

1. In the *properties* pane in the lower right corner, add the *NoConnectivityCheck* property and set its value to *True*.

> [!TIP]
> See also: [NoConnectivityCheck](xref:SRM_properties_Booking_Manager#noconnectivitycheck)

## Setting a profile instance as optional

<!-- RN 23285 -->

In the context of Service Orchestration, you can mark a node or interface profile instance as optional:

1. In the Services module, go to the *definitions* tab.

1. Select the service definition and the node or interface.

1. In the *properties* pane in the lower right corner, add the [IsProfileInstanceOptional](xref:SRM_properties_Booking_Manager#isprofileinstanceoptional) property and set its value to *True*.

> [!TIP]
> If you want to mark a resource as optional, use the [Optional](xref:SRM_properties_Booking_Manager#options) option on the service definition node instead.

> [!NOTE]
> From SRM 1.2.20 onwards, it is not possible to create a booking if parameters still need to be configured for a node and there are no profile instances in the system for that node. If you do want it to be possible to create a booking in such a case, for example for a transport node, make sure you have set *IsProfileInstanceOptional* to *True*. <!-- RN 31534 -->

## Filtering profile instances based on resource selection

<!-- RN 24193 -->

In the context of Service Orchestration, you can configure resources so that when they are selected in the Booking Wizard, the list of profile instances is filtered to only show the profile instances matching the capabilities of the selected resources:

1. In the Resources module, select the pool and the resource.

1. Go to the *properties* tab for the resource, and click *Add*.

1. Fill in the name *FilterProfileInstance* and the value *Yes*, and click *OK*.

> [!TIP]
> See also: [FilterProfileInstance](xref:SRM_properties_Booking_Manager#filterprofileinstance)

## Configuring resource pool inheritance for a profile instance

When a booking starts and a profile instance gets selected, the values defined in the profile instance are used to apply a configuration on the resource. However, in specific situations, it might be required to not apply the exact same configuration on concurrent bookings to prevent them from interfering with each other. In such cases, resource pool inheritance can be used.

With resource pool inheritance, instead of using a fixed value defined in the selected profile instance for a specific parameter, you extend the service definition to refer to a custom resource pool. When the user selects the profile instance for the booking, they will see a list of discrete values based on the list of items in the resource pool that are available during the booking duration. When the booking is confirmed, the selected resource pool item is saved in the booking, so that it cannot be selected for overlapping bookings.

For example, when a list of multicast IPs need to be applied to encoding functions, but you need to avoid multiple encoders making use of the same multicast IP, you can use this feature to book the IP address as a resource.

To configure resource pool inheritance:

1. In the Services module, go to the *definitions* tab.

1. Select the service definition and the node.

1. In the parameters pane in the lower right corner, select the checkbox under *Value* for the relevant parameter, and add the following JSON code as the value

   ```json
   {
      "Link": "RESOURCEPOOL",
      "PoolName":"<pool name>", 
      "ShouldAutoSelectResource": <true or false>
   }
   ```

   - Replace `<pool name>` with the name of a resource pool.
   - Set *ShouldAutoSelectResource* to true to enable automatic resource selection. This is supported both for node and interface profile instances. <!-- RN 31975, 29779 -->

You can also extend resource pool inheritance to further limit the list of pool items presented to the user based on a capability defined on the selected resource: <!-- RN 25081 -->

1. Add a capability parameter on the function resource and select which discrete values the resource can support. The discrete values must be part of the custom pool. See [Setting up basic resource filtering](xref:Service_Orchestration_resources_advanced#setting-up-basic-resource-filtering).

1. In the Services module, modify the parameter with the resource inheritance configuration as follows:

   ```json
   {
      "Link": "RESOURCEPOOL",
      "PoolName":"<pool name>",
      "ResourceCapability":"<resource capability parameter name>"
   }
   ```

For example, if the resource is configured with the capability *Multicast IP*, the parameter can be configured as follows:

```json
{
   "Link": "RESOURCEPOOL",
   "PoolName": "SDMN.SAT.Multicast IP",
   "ResourceCapability": "Multicast IP"
}
```

In the resource configuration, the allowed parameter values should be specified for the corresponding capability. For example, if the *Multicast IP* capability is set to "244.0.0.2;244.0.0.3" in the resource configuration, for the parameter above only those two values will be selectable if the resource is selected. If no resource is selected, all options will be available. If a resource is selected that does not have the capability defined in the parameter, all options will also be available.
