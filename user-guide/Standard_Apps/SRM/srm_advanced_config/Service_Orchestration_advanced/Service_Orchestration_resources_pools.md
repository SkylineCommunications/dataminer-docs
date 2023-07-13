---
uid: Service_Orchestration_resources_advanced
---

# Service Orchestration: resources configuration

## Resource filtering configuration

In the Booking Wizard, the candidate resources for a node in the service definition are filtered based on the capacities and capabilities of the profile instance selected for that node.

### Setting up basic resource filtering

1. In the Profiles module, make sure the necessary capability and capacity parameters are defined and added to the profile definition you want to use for a specific node. See [The Profiles module](xref:The_Profiles_module).

   > [!NOTE]
   > If capabilities or capacities are defined on an interface profile definition, having the same capability or capacity parameters on multiple interfaces of the same function is not supported.

1. In the Resources module, add the necessary capacities and capabilities to your resources:

   1. Select a resource pool and then select a resource in the pool.

   1. Click *Add capability* or *Add capacity* and select the capability or capacity.

   1. Configure the possible values for the capability or capacity.

   1. Click *Save*.

### Supported capabilities and capacities for filtering

- **Capability of type text**: Supported from SRM 1.2.2 onwards. In this case, the resource is associated with a fixed string. A resource will be considered a valid candidate resource for a booking if the capability defined in the profile instance has the same value as defined on the resource. <!-- RN 25446 -->

  Capabilities of type text with **time dependency** are also supported. In this case, the resource is dynamically associated with a fixed string determined by the booking making use of it. When you configure the resource in the Resources module, instead of specifying a capability value, select *Use time-dependent*. It will then only be possible to use the resource in multiple overlapping booking if they share the same purpose.

  For example, a steerable antenna can have a "Satellite" time-dependent capability indicating the satellite it is receiving. When an antenna is provisioned with this time-dependent capability, and it is booked in the future to receive a specific satellite, it will only be possible to book that same antenna for an overlapping booking when that overlapping booking uses it to receive the same satellite.

- **Capability of type discrete**: The resource is associated with a list of items, i.e. the discrete values of the capability. A resource is considered a valid candidate resource when the capability value defined in the profile instance is one of the selected values of this capability for this resource.

- **Capability of type number**: The resource is associated with a numeric range. A resource is considered a valid candidate if the capability value defined in the profile instance is within the range configured for this capability for this resource.

- **Capacity of type number**: The resource is associated with a specific quantity, indicated by a number. Each booking will consume a part of that quantity defined in the selected profile instance (e.g. bit rate). The resource will be a valid candidate resource if there is enough capacity left for the entire booking duration when all other overlapping bookings making use of the resource are taken into account.

### Setting up additional pre-filtering

To further limit the list of candidate resources, you can configure extra pre-filtering rules. This will generate an extra page in the Booking Wizard with controls that can be used to apply the extra filtering. <!-- RN 24172 -->

To configure a pre-filtering rule:

1. In the Services module, go to the *definitions* tab.

1. Select the service definition and the node the filtering should apply to.

1. In the *properties* pane below the diagram pane, add the property *Resource Assignment*, and set its value to a JSON string in the same format as the example below:

   ```json
   {
      "Condition": "<A>",
      "Value": [{
            "Label": "A",
            "Type": "Operation",
            "Value": {
               "FirstOperand": {
                  "Link": "[var:ENC-Vendor]"
               },
               "Operator": "=",
               "SecondOperand": {
                  "Link": "RESOURCE",
                  "Capability": "ENC-NewVendor"
               }
            }
         }
      ]
   }
   ```

   The example above will generate an "ENC-Vendor" control that will list possible "ENC-NewVendor" capability values defined on the resources that are a candidate for the node.

> [!NOTE]
>
> - Multiple conditions, separated by an "AND" operator, are supported. For example: `"Condition": "<A> AND <B>"`. Each condition must be of type "Operation", and each operation must be an equal comparison between a capability on a resource and a variable representing a field that will be presented to the user.
> - In case the capability is also present on the profile instance, the list of profile instances will be filtered as well. <!-- RN 24034 -->

> [!TIP]
> See also: [Resource Assignment](xref:SRM_properties_Booking_Manager#resource-assignment)

## Resource sorting configuration

When candidate resources are presented in the Booking Wizard, these can be sorted in different ways.

- **Based on priority**: To have them sorted based on priority, in the Resources module, add a *Priority* property to each resource in a pool. The lower the value you specify for this property, the higher in the sort order it will be displayed.

  > [!TIP]
  > See also: [Priority](xref:SRM_properties_Booking_Manager#priority)

- **Alphabetically**: If priority is not specified, resources can be sorted alphabetically, if the *Alphabetically* option is selected for the *Resources Ordering Rule* setting on the *Config* > *Wizard* tab of the Booking Manager. <!-- RN 29107 -->

- **Capacity**: If priority is not specified, resources can be sorted based on the available capacity (considering all other overlapping bookings making use of those same resources), if the [Resource Sorting Capacity](xref:SRM_properties_Booking_Manager#resource-sorting-capacity) property is configured in the service definition and the *Capacity* option is selected for the *Resources Ordering Rule* setting on the *Config* > *Wizard* tab of the Booking Manager.

- **Randomly**: If priority is not specified, resources can be sorted randomly, if the *Randomly* option is selected for the *Resources Ordering Rule* setting on the *Config* > *Wizard* tab of the Booking Manager.

## Resource selection configuration

When a booking is created using Service Orchestration, a resource must be selected for each mandatory node. Several features are available to make the booking selection easier for the user.

### Customizing automatic resource selection

When a booking is **created** using the Booking Wizard, by default one of the available resources will be selected. You can configure specific nodes to make sure this does not happen for them: <!-- RN 28165 -->

1. In the Services module, go to the *definitions* tab.

1. Select the service definition and the node.

1. In the *properties* pane below the diagram pane, add the property *Auto Select Resource*, and set its value to *False*.

When a booking is **edited** using the Booking Wizard, by default no resource will be selected. From SRM version 1.2.21 onwards, you can configure specific nodes to make sure resources are always selected for them in this case: <!-- RN 31937 -->

1. In the Services module, go to the *definitions* tab.

1. Select the service definition and the node.

1. In the *properties* pane below the diagram pane, add the property *Auto Select Resource*, and set its value to *Always*.

> [!TIP]
> See also: [Auto Select Resource](xref:SRM_properties_Booking_Manager#auto-select-resource)

### Hiding resource selection if a resource is available

It is possible to automatically hide the resource selection for a specific node in the Booking Wizard if a resource is available for it. To do so:

1. In the Services module, go to the *definitions* tab.

1. Select the service definition and the node.

1. In the *properties* pane below the diagram pane, add the property *HideIfResourceAvailable*, and set its value to *Yes*.

> [!TIP]
> See also: [HideIfResourceAvailable](xref:SRM_properties_Booking_Manager#hideifresourceavailable)

### Hiding resource selection for a specific node

It is possible to hide a specific node in the Booking Wizard regardless of whether a resource is available for it. To do so: <!-- RN 19619 -->

1. In the Services module, go to the *definitions* tab.

1. Select the service definition and the node.

1. In the *properties* pane below the diagram pane, add the property *Options*, and set its value to *Hide*.

   > [!NOTE]
   > To combine multiple options in the *Options* property, use a pipe character ("|") as separator.

> [!TIP]
> See also: [Options](xref:SRM_properties_Booking_Manager#options)

### Making resource selection optional for a node

By default, a booking can only be confirmed when all mandatory resources and profiles have been selected. If you want resource selection to be optional for a specific node, you can configure this as follows: <!-- RN 20818 -->

1. In the Services module, go to the *definitions* tab.

1. Select the service definition and the node.

1. In the *properties* pane below the diagram pane, add the property *Options*, and set its value to *Optional*.

   > [!NOTE]
   > To combine multiple options in the *Options* property, use a pipe character ("|") as separator.

> [!TIP]
> See also: [Options](xref:SRM_properties_Booking_Manager#options)

### Defining the resource selection sequence

If bookings are created based on a service definition, you can define the sequence for resource selection in the service definition.

1. In the Services module, go to the *definitions* tab and select the service definition.

1. For each node of the service definition:

   1. Select the node.

   1. In the *properties* pane below the diagram pane, add the property *ConfigurationOrder*, and set its value to an integer indicating its position in the order. The lowest value will be displayed first.

> [!TIP]
> See also: [ConfigurationOrder](xref:SRM_properties_Booking_Manager#configurationorder)

### Disabling resource selection in the UI

<!-- RN 28965 -->

In some situations, resources for specific nodes can be selected automatically, without requiring user interaction. In that case, you can disable resource selection for those nodes in the Booking Wizard:

1. In the Services module, go to the *definitions* tab.

1. Select the service definition and the node.

1. In the *properties* pane below the diagram pane, add the property *ReadOnlyResourceSelectionControl*.

1. Set the property value to *True*.

> [!TIP]
> See also: [ReadOnlyResourceSelectionControl](xref:SRM_properties_Booking_Manager#readonlyresourceselectioncontrol)

## Configuring resource pool inheritance for a profile instance

See [Configuring resource pool inheritance for a profile instance](xref:Service_Orchestration_profile_instances#configuring-resource-pool-inheritance-for-a-profile-instance).
