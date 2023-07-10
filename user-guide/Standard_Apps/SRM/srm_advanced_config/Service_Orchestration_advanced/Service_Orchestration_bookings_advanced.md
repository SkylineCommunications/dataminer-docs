---
uid: Service_Orchestration_bookings_advanced
---

# Service Orchestration: bookings configuration

## Configuring persistent services

By default, when a booking ends, the corresponding service is removed. However, you can make the service persistent, so that multiple non-overlapping bookings can make use of the same service.

To activate this feature, in the Booking Manager app, go to the *Config* > *General* page, and enable the *Persistent Service* option.

If this option is enabled, you can select an existing persistent service during booking creation. The Booking Wizard also allows you to customize the service name.

> [!NOTE]
> The SRM framework does not allow the reuse of a service associated with a contributing booking or with a regular booking that can potentially be converted to a contributing booking. <!-- RN 30005 -->

## Configuring a custom enhanced element

<!-- RN 21215, 29890 -->

You can extend the DataMiner service associated with a booking with a custom enhanced element to perform custom logic.

> [!NOTE]
>
> - This feature is not supported for contributing bookings.
> - This feature should be used with caution, as this will generate one extra element per active booking, which **will affect the load of the system**.

1. In the Services module, go to the *definitions* tab.

1. Select the service definition where you want to add the enhanced element configuration.

1. In the pane on the right, go to the *properties* tab.

1. Click the *Add* button to add a property.

1. In the *new property* field, specify the property name *Enhanced Protocol*.

1. Set the value of the property as illustrated below:

   ```json
   {"ProtocolName" : "Name of the protocol", 
   "ProtocolVersion": "Version to use",
   "AlarmTemplate": "Name of the Alarm Template",
   "TrendTemplate": "Name of the Trend Template"}
   ```

   > [!NOTE]
   > The *AlarmTemplate* and *TrendTemplate* attributes are optional.

## Configuring the element alias

<!-- RN 25236 -->

By default, when the service associated with a booking is created, the service elements have the names of the resource DVEs.

However, you can configure SRM to use the label of the node in the service definition as the element alias instead.

To do so, in the Booking Manager app, go to the *Config* > *Wizard* page, and enable the option Use *Node Label as Element Alias*.

> [!TIP]
> See also:
>
> - [Booking wizard options settings](xref:Booking_Manager_Config_tab#booking-wizard-options-settings)
> - [Creating service definitions](xref:Service_Orch_creating_service_definitions)
